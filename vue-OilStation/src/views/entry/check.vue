<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || tableData.staffName.toLowerCase().includes(search.toLowerCase()))"
      v-loading="loading"
      style="width: 100%"
      height="635px"
      :default-sort="{prop: 'createTime', order: 'descending'}"
    >
      <el-table-column label="申请时间" prop="createTime" width="200%" sortable>
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
      <el-table-column label="地址" prop="address"></el-table-column>
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
          <el-input
            v-model="search"
            size="mini"
            placeholder="输入关键字搜索"
            :id="scope"
            style="width:100%"
          />
        </template>
        <template slot-scope="scope">
          <el-button
            type="primary"
            round
            icon="el-icon-edit"
            @click="Check(scope.$index, scope.row)"
          >审核</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog :visible.sync="dialogVisible" title="审核入职信息" width="45%">
      <el-form ref="form" :model="form" label-width="100px">
        <div>
          <el-row>
            <el-col :span="12">
              <el-form-item label="姓名：" prop="StaffName">
                <el-input v-model="form.StaffName" name="StaffName" disabled></el-input>
              </el-form-item>
              <el-form-item label="性别：" prop="Sex">
                <el-radio-group v-model="form.Sex" disabled>
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
                  disabled
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="地址：" prop="Address">
                <el-input v-model="form.Address" name="Address" disabled></el-input>
              </el-form-item>
              <el-form-item label="邮箱：" prop="Email">
                <el-input v-model="form.Email" name="Email" disabled></el-input>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="电话：" prop="Tel">
                <el-input v-model="form.Tel" name="Tel" disabled></el-input>
              </el-form-item>
              <el-form-item label="入职时间：" prop="EntryDate">
                <el-date-picker
                  v-model="form.EntryDate"
                  type="date"
                  placeholder="选择日期"
                  name="EntryDate"
                  style="width:100%"
                  disabled
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="入职职位：" prop="WorkNumber">
                <el-input v-model="form.WorkNumber" name="WorkNumber" disabled></el-input>
              </el-form-item>
              <el-form-item label="实习薪水：" prop="ProbationarySalary">
                <el-input v-model="form.ProbationarySalary" name="ProbationarySalary" disabled></el-input>
              </el-form-item>
              <el-form-item label="入职薪水：" prop="CorrectSalary">
                <el-input v-model="form.CorrectSalary" name="CorrectSalary" disabled></el-input>
              </el-form-item>
            </el-col>
          </el-row>
          <el-form ref="checkForm" :model="checkData" label-width="100px" :rules="rules">
            <el-form-item label="审核状态：" prop="CheckNo">
              <el-radio v-model="checkData.CheckNo" label="1" border>同意</el-radio>
              <el-radio v-model="checkData.CheckNo" label="-1" border>驳回</el-radio>
            </el-form-item>
            <el-form-item label="审核理由：" prop="CheckTitle">
              <el-input v-model="checkData.CheckTitle" name="CheckTitle"></el-input>
            </el-form-item>
          </el-form>
        </div>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Cilck()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetEntryCheck, CheckEntry } from "@/api/entry";
export default {
  data() {
    return {
      tableData: [],
      loading: true,
      search: "",
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
      checkData: {
        id: "",
        CheckNo: "",
        CheckTitle: ""
      },
      rules: {
        CheckNo: [{ required: true, message: "选择审核类型", trigger: "blur" }]
      }
    };
  },
  created() {
    GetEntryCheck().then(res => {
      this.tableData = res.data;
      this.loading = false;
    });
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
    Check(index, row) {
      this.checkData.id = row.id;
      this.dialogVisible = true;
      this.form.StaffName = row.staffName;
      this.form.Sex = row.sex;
      this.form.BirthDay = row.birthDay;
      this.form.Address = row.address;
      this.form.Email = row.email;
      this.form.Tel = row.tel;
      this.form.ProbationarySalary = row.probationarySalary;
      this.form.CorrectSalary = row.correctSalary;
      this.form.EntryDate = row.entryDate;
      this.form.CreateStaffeId = row.createStaffeId;
      this.form.WorkNumber = row.workNumber;
    },
    Cilck() {
      this.$refs["checkForm"].validate(valid => {
        if (valid) {
          this.loading = true;
          CheckEntry(this.checkData).then(res => {
            GetEntryCheck().then(res => {
              this.tableData = res.data;
              this.loading = false;
              this.dialogVisible = false;
              this.$refs["checkForm"].resetFields();
            });
          });
        }
      });
    }
  }
};
</script>