<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || data.userName.toLowerCase().includes(search.toLowerCase()))"
      style="width: 100%"
    >
      <el-table-column label="姓名" prop="userName"></el-table-column>
      <el-table-column label="性别" prop="userSex"></el-table-column>
      <el-table-column label="职位" prop="jobName"></el-table-column>
      <el-table-column label="电话" prop="phoneNumber"></el-table-column>
      <el-table-column label="邮箱" prop="email"></el-table-column>
      <el-table-column label="地址" prop="address"></el-table-column>
      <el-table-column label="生日" prop="birthDay">
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.birthDay"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:100%"
          ></el-date-picker>
        </template>
      </el-table-column>

      <el-table-column align="right">
        <template slot="header" slot-scope="scope">
          <el-input v-model="search" size="mini" placeholder="输入用户名搜索" :id="scope" />
          <!-- <el-button type="success" @click="Add()">添加用户</el-button> -->
        </template>
        <template slot-scope="scope">
          <el-button size="mini" @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="修改信息" :visible.sync="dialogVisible" width="40%">
      <el-form ref="form" :model="form" label-width="80px" :rules="rules">
        <el-row>
          <el-col :span="12">
            <div>
              <el-form-item label="用户名" prop="userName">
                <el-input v-model="form.userName" name="userName"></el-input>
              </el-form-item>
              <el-form-item label="性别" prop="userSex">
                <el-radio-group v-model="form.userSex">
                  <el-radio-button label="男"></el-radio-button>
                  <el-radio-button label="女"></el-radio-button>
                </el-radio-group>
              </el-form-item>
              <el-form-item label="职位：">
                <el-select v-model="form.job" placeholder="请选择职位">
                  <el-option
                    :label="item.name"
                    :value="item.id"
                    v-for="item in JobData"
                    v-bind:key="item.id"
                  ></el-option>
                </el-select>
              </el-form-item>
              <el-form-item label="电话" prop="phoneNumber">
                <el-input v-model="form.phoneNumber"></el-input>
              </el-form-item>
            </div>
          </el-col>
          <el-col :span="12">
            <div>
              <el-form-item label="邮箱" prop="email">
                <el-input v-model="form.email"></el-input>
              </el-form-item>
              <el-form-item label="地址" prop="address">
                <el-input v-model="form.address"></el-input>
              </el-form-item>
              <el-form-item label="出生日期" prop="birthDay">
                <el-date-picker
                  v-model="form.birthDay"
                  type="date"
                  placeholder="选择日期"
                  style="width:100%"
                ></el-date-picker>
              </el-form-item>
            </div>
          </el-col>
        </el-row>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Update()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetUserRole } from "@/api/authorize";
import { UpdateInfo, DeleteInfo } from "@/api/user";
import { GetJob } from "@/api/Job";
export default {
  data() {
    return {
      tableData: [],
      JobData: [],
      form: {
        id: "",
        userName: "",
        userSex: "",
        phoneNumber: "",
        email: "",
        address: "",
        birthDay: "",
        job: ""
      },
      dialogVisible: false,
      search: "",
      rules: {
        userName: [
          { required: true, message: "请输入用户名", trigger: "blur" }
        ],
        userSex: [{ required: true, message: "请选择性别", trigger: "blur" }],
        phoneNumber: [
          { required: true, message: "请输入电话号码", trigger: "blur" }
        ],
        email: [{ required: true, message: "输入邮箱", trigger: "blur" }],
        address: [{ required: true, message: "请输入地址", trigger: "blur" }],
        birthDay: [{ required: true, message: "请选择日期", trigger: "change" }]
      }
    };
  },
  created() {
    this.GetUserRole();
    this.GetJob();
  },
  methods: {
    handleEdit(index, row) {
      this.dialogVisible = true;
      this.$nextTick(() => {
        this.$refs["form"].resetFields();
        this.form.id = row.id;
        this.form.userName = row.userName;
        this.form.userSex = row.userSex;
        this.form.phoneNumber = row.phoneNumber;
        this.form.address = row.address;
        this.form.email = row.email;
        this.form.birthDay = row.birthDay;
        this.form.job = String(row.jobId);
      });
    },
    handleDelete(index, row) {
      //console.log(index, row);
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          DeleteInfo(row.id).then(res => {
            this.GetUserRole();
          });
        })
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除"
          });
        });
    },
    GetUserRole() {
      GetUserRole().then(res => {
        this.tableData = res.data;
      });
    },
    GetJob() {
      GetJob().then(res => {
        this.JobData = res.data;
      });
    },
    Update() {
      this.$refs["form"].validate(valid => {
        //console.log(this.form)
        if (valid) {
          UpdateInfo(this.form).then(res => {
            this.dialogVisible = false;
            this.GetUserRole();
          });
        } else {
          this.dialogVisible = false;
          console.log("error submit!!");
          return false;
        }
      });
    },
    Add() {
      console.log(this.search);
      //this.dialogVisible = true;
    }
  }
};
</script>