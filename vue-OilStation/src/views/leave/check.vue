<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || tableData.staffName.toLowerCase().includes(search.toLowerCase()))"
      v-loading="loading"
      style="width: 100%"
      height="635px"
      :default-sort="{prop: 'createTime', order: 'descending'}"
    >
      <el-table-column label="申请时间" prop="applyTime" fixed width="200%" sortable>
        <!-- :formatter="convertToDate" -->
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.applyTime"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:80%"
          ></el-date-picker>
        </template>
      </el-table-column>
      <el-table-column label="姓名" prop="staffName"></el-table-column>
      <el-table-column label="职位" prop="jobId"></el-table-column>
      <el-table-column label="类型" prop="leaveType"></el-table-column>
      <el-table-column label="理由" prop="reason"></el-table-column>
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
    <el-dialog :visible.sync="dialogVisible" title="审核离职信息" width="45%">
      <el-form ref="form" :model="form" label-width="100px">
        <div>
          <el-form-item label="姓名：" prop="StaffName">
            <el-input v-model="form.StaffName" name="StaffName" disabled></el-input>
          </el-form-item>
          <el-form-item label="类型：" prop="LeaveType">
            <el-radio-group v-model="form.LeaveType" disabled>
              <el-radio-button label="0">离职</el-radio-button>
              <el-radio-button label="1">辞退</el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="理由：" prop="Reason">
            <el-input v-model="form.Reason" name="Reason" disabled></el-input>
          </el-form-item>
          <el-form-item label="离职时间：" prop="ApplyTime" disabled>
            <el-date-picker
              v-model="form.ApplyTime"
              type="date"
              placeholder="选择日期"
              name="ApplyTime"
              style="width:100%"
              disabled
            ></el-date-picker>
          </el-form-item>
          <el-form-item label="离职职位：" prop="JobId">
            <el-input v-model="form.JobId" name="JobId" disabled></el-input>
          </el-form-item>
          <el-form ref="checkForm" :model="checkData" label-width="100px" :rules="rules">
            <el-form-item label="审核状态：" prop="CheckNo">
              <el-radio v-model="checkData.CheckNo" label="1" border>同意</el-radio>
              <el-radio v-model="checkData.CheckNo" label="-1" border>驳回</el-radio>
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
import { GetLeaveCheck, CheckLeave } from "@/api/leave";
export default {
  data() {
    return {
      tableData: [],
      loading: true,
      search: "",
      dialogVisible: false,
      form: {
        StaffName: "",
        LeaveType: "",
        ApplyTime: "",
        Reason: "",
        CreateTime: "",
        No: "",
        JobId: ""
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
    GetLeaveCheck().then(res => {
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
        console.log(row)
      this.checkData.id = row.id;
      this.dialogVisible = true;
      this.form.StaffName = row.staffName;
      this.form.LeaveType = row.leaveType;
      this.form.ApplyTime = row.applyTime;
      this.form.Reason = row.reason;
      this.form.CreateTime = row.createTime;
      this.form.No = row.no;
      this.form.JobId = row.jobId;
    },
    Cilck() {
      this.$refs["checkForm"].validate(valid => {
        if (valid) {
          this.loading = true;
          CheckLeave(this.checkData).then(res => {
            GetLeaveCheck().then(res => {
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