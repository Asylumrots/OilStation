<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || tableData.staffName.toLowerCase().includes(search.toLowerCase()))"
      v-loading="loading"
      style="width: 100%"
      height="635px"
      :default-sort="{prop: 'createTime', order: 'descending'}"
    >
      <el-table-column label="申请时间" prop="createTime" fixed width="200%" sortable>
        <!-- :formatter="convertToDate" -->
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.createTime"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:80%"
          ></el-date-picker>
        </template>
      </el-table-column>
      <el-table-column label="姓名" prop="staffName"></el-table-column>
      <el-table-column label="性别" prop="sex"></el-table-column>
      <el-table-column label="生日" prop="birthDay" width="200%">
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.birthDay"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:80%"
          ></el-date-picker>
        </template>
      </el-table-column>
      <el-table-column label="地址" prop="address"></el-table-column>
      <el-table-column label="电话" prop="tel"></el-table-column>
      <el-table-column label="邮箱" prop="email" width="150%"></el-table-column>
      <el-table-column label="入职时间" prop="entryDate" width="200%" sortable>
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.entryDate"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:80%"
          ></el-date-picker>
        </template>
      </el-table-column>
      <el-table-column label="入职职位" prop="workNumber"></el-table-column>
      <el-table-column label="实习薪水" prop="probationarySalary"></el-table-column>
      <el-table-column label="正式薪水" prop="correctSalary"></el-table-column>
      <el-table-column align="right" fixed="right" width="160%">
        <template slot="header" slot-scope="scope">
          <!-- <el-input
          v-model="search"
          size="mini"
          placeholder="输入关键字搜索"
          :id="scope"
          style="width:100%"
          />-->
          <el-button type="primary" :id="scope" plain @click="dialogVisible=true">添加入职信息</el-button>
        </template>
        <template slot-scope="scope">
          <el-button
            :type="scope.row.no | statusFilter"
            :icon="scope.row.no | icoFilter"
            circle
            @click="showCheck(scope.row.no,scope.row.title)"
            style="margin-right: 10px"
          ></el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog :visible.sync="dialogVisible" title="添加入职信息" width="45%">
      <el-form ref="form" :model="form" label-width="100px" :rules="rules">
        <div>
          <el-row>
            <el-col :span="12">
              <el-form-item label="姓名：" prop="StaffName">
                <el-input v-model="form.StaffName" name="StaffName"></el-input>
              </el-form-item>
              <el-form-item label="性别：" prop="Sex">
                <el-radio-group v-model="form.Sex">
                  <el-radio-button label="男"></el-radio-button>
                  <el-radio-button label="女"></el-radio-button>
                </el-radio-group>
              </el-form-item>
              <el-form-item label="出生日期：" prop="BirthDay">
                <el-date-picker
                  v-model="form.BirthDay"
                  type="date"
                  placeholder="选择日期"
                  name="BirthDay"
                  style="width:100%"
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="地址：" prop="Address">
                <el-input v-model="form.Address" name="Address"></el-input>
              </el-form-item>
              <el-form-item label="邮箱：" prop="Email">
                <el-input v-model="form.Email" name="Email"></el-input>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="电话：" prop="Tel">
                <el-input v-model="form.Tel" name="Tel"></el-input>
              </el-form-item>
              <el-form-item label="入职时间：" prop="EntryDate">
                <el-date-picker
                  v-model="form.EntryDate"
                  type="date"
                  placeholder="选择日期"
                  name="EntryDate"
                  style="width:100%"
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="入职职位：" prop="WorkNumber">
                <!-- <el-input v-model="form.WorkNumber" name="WorkNumber"></el-input> -->
                <el-select v-model="form.WorkNumber" placeholder="请选择职位" style="width:100%">
                  <el-option
                    :label="item.name"
                    :value="item.id"
                    v-for="item in JobData"
                    v-bind:key="item.id"
                  ></el-option>
                </el-select>
              </el-form-item>
              <el-form-item label="实习薪水：" prop="ProbationarySalary">
                <el-input v-model="form.ProbationarySalary" name="ProbationarySalary"></el-input>
              </el-form-item>
              <el-form-item label="入职薪水：" prop="CorrectSalary">
                <el-input v-model="form.CorrectSalary" name="CorrectSalary"></el-input>
              </el-form-item>
            </el-col>
          </el-row>
        </div>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Add()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetEntry, DeleteEntry, AddEntry } from "@/api/entry";
import { GetJob } from "@/api/Job";
export default {
  filters: {
    statusFilter(status) {
      const statusMap = {
        "1": "success",
        "0": "info",
        "-1": "danger"
      };
      return statusMap[status];
    },
    icoFilter(status) {
      const statusMap = {
        "1": "el-icon-check",
        "0": "el-icon-message",
        "-1": "el-icon-close"
      };
      return statusMap[status];
    }
  },
  data() {
    return {
      tableData: [],
      JobData:[],
      search: "",
      loading: true,
      dialogVisible: false,
      form: {
        StaffName: "",
        Sex: "",
        BirthDay: "",
        Address: "",
        Email: "",
        Tel: "",
        ProbationarySalary: "",
        CorrectSalary: "",
        EntryDate: "",
        CreateStaffeId: "",
        WorkNumber: ""
      },
      rules: {
        StaffName: [{ required: true, message: "输入用户名", trigger: "blur" }],
        Sex: [{ required: true, message: "选择性别", trigger: "blur" }],
        BirthDay: [{ required: true, message: "输入生日", trigger: "blur" }],
        Address: [{ required: true, message: "输入地址", trigger: "blur" }],
        Email: [{ required: true, message: "输入邮箱", trigger: "blur" }],
        Tel: [{ required: true, message: "输入电话", trigger: "blur" }],
        ProbationarySalary: [
          { required: true, message: "输入实习薪水", trigger: "blur" }
        ],
        CorrectSalary: [
          { required: true, message: "输入入职薪水", trigger: "blur" }
        ],
        EntryDate: [
          { required: true, message: "输入入职时间", trigger: "blur" }
        ],
        WorkNumber: [
          { required: true, message: "输入入职职位", trigger: "blur" }
        ]
      }
    };
  },
  created() {
    GetEntry().then(res => {
      this.tableData = res.data;
      this.loading = false;
    });
    GetJob().then(res=>{
      this.JobData=res.data;
    })
  },
  methods: {
    convertToDate(row, column) {
      //console.log(row.createTime)
      var date = new Date(row.createTime);
      var y = date.getFullYear();
      var m = date.getMonth() + 1;
      var d = date.getDate();
      m = m < 10 ? "0" + m : m; //月份如果小于10，则在前面加一个0
      d = d < 10 ? "0" + d : d; //day如果小于10，则在前面加一个0
      return y + "-" + m + "-" + d;
    },
    handleDelete(index, row) {
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          this.loading = true;
          DeleteEntry(row.id).then(res => {
            GetEntry().then(res => {
              this.tableData = res.data;
              this.loading = false;
            });
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除"
          });
        });
    },
    showCheck(no, msg) {
      if (no == "0") {
        if (msg == null) {
          msg = "暂无审批意见 ";
        }
        this.$message(msg);
      } else if (no == "1") {
        if (msg == null) {
          msg = "";
        }
        msg = "审核通过 " + msg;
        this.$message({
          message: msg,
          type: "success"
        });
      } else if (no == "-1") {
        if (msg == null) {
          msg = "";
        }
        msg = "审核驳回 " + msg;
        this.$message.error(msg);
      }
    },
    Add() {
      //console.log(this.form)
      this.$refs["form"].validate(valid => {
        if (valid) {
          this.form.CreateStaffeId = this.$store.getters.name;
          this.loading = true;
          this.dialogVisible = false;
          AddEntry(this.form).then(res => {
            GetEntry().then(res => {
              this.tableData = res.data;
              this.loading = false;
              this.$refs["form"].resetFields();
            });
          });
        }
      });
    }
  }
};
</script>