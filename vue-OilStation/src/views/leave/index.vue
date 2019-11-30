<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || tableData.staffName.toLowerCase().includes(search.toLowerCase()))"
      v-loading="loading"
      style="width: 100%"
      height="635px"
      :default-sort="{prop: 'applyTime', order: 'descending'}"
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
          <!-- <el-input
          v-model="search"
          size="mini"
          placeholder="输入关键字搜索"
          :id="scope"
          style="width:100%"
          />-->
          <el-button type="primary" :id="scope" plain @click="dialogVisible=true">添加离职信息</el-button>
        </template>
        <template slot-scope="scope">
          <el-button
            :type="scope.row.no | statusFilter"
            :icon="scope.row.no | icoFilter"
            circle
            @click="showCheck(scope.row.no,scope.row.reason)"
            style="margin-right: 10px"
          ></el-button>
          <el-button size="mini" type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog :visible.sync="dialogVisible" title="添加离职信息" width="30%">
      <el-form ref="form" :model="form" label-width="100px" :rules="rules">
        <div>
          <el-form-item label="姓名：" prop="StaffName">
            <el-input v-model="form.StaffName" name="StaffName"></el-input>
          </el-form-item>
          <el-form-item label="类型：" prop="LeaveType">
            <el-radio-group v-model="form.LeaveType">
              <el-radio-button label="离职"></el-radio-button>
              <el-radio-button label="辞退"></el-radio-button>
            </el-radio-group>
          </el-form-item>
          <el-form-item label="理由：" prop="Reason">
            <el-input v-model="form.Reason" name="Reason"></el-input>
          </el-form-item>
          <el-form-item label="离职时间：" prop="ApplyTime">
            <el-date-picker
              v-model="form.ApplyTime"
              type="date"
              placeholder="选择日期"
              name="ApplyTime"
              style="width:100%"
            ></el-date-picker>
          </el-form-item>
          <el-form-item label="离职职位：" prop="JobId">
            <!-- <el-input v-model="form.WorkNumber" name="WorkNumber"></el-input> -->
            <el-select v-model="form.JobId" placeholder="请选择职位" style="width:100%">
              <el-option
                :label="item.name"
                :value="item.id"
                v-for="item in JobData"
                v-bind:key="item.id"
              ></el-option>
            </el-select>
          </el-form-item>
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
import { GetLeave, DeleteLeave, AddLeave } from "@/api/leave";
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
      JobData: [],
      search: "",
      loading: true,
      dialogVisible: false,
      form: {
        StaffName: "",
        LeaveType: "",
        ApplyTime: "",
        Reason: "",
        CreateTime: "2000-10-12",
        No: "",
        JobId: ""
      },
      rules: {
        StaffName: [{ required: true, message: "输入用户名", trigger: "blur" }],
        LeaveType: [
          { required: true, message: "选择离职类型", trigger: "blur" }
        ],
        ApplyTime: [
          { required: true, message: "输入离职时间", trigger: "blur" }
        ],
        JobId: [{ required: true, message: "输入离职职位", trigger: "blur" }]
      }
    };
  },
  created() {
    GetLeave().then(res => {
      this.tableData = res.data;
      this.loading = false;
    });
    GetJob().then(res => {
      this.JobData = res.data;
    });
  },
  methods: {
    handleDelete(index, row) {
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          this.loading = true;
          DeleteLeave(row.id).then(res => {
            GetLeave().then(res => {
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
          msg = "暂无审批意见 ";
        this.$message(msg);
      } else if (no == "1") {
        msg = "审核通过 ";
        this.$message({
          message: msg,
          type: "success"
        });
      } else if (no == "-1") {
        msg = "审核驳回 ";
        this.$message.error(msg);
      }
    },
    Add() {
      //console.log(this.form);
      this.$refs["form"].validate(valid => {
        if (valid) {
          this.loading = true;
          this.dialogVisible = false;
          AddLeave(this.form).then(res => {
            GetLeave().then(res => {
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