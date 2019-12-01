<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || tableData.applyPersonId.toLowerCase().includes(search.toLowerCase()))"
      v-loading="loading"
      style="width: 100%"
      height="635px"
      :default-sort="{prop: 'applyDate', order: 'descending'}"
    >
      <el-table-column label="申请时间" prop="applyDate" fixed width="200%" sortable>
        <!-- :formatter="convertToDate" -->
        <template slot-scope="props">
          <el-date-picker
            v-model="props.row.applyDate"
            type="date"
            placeholder="选择日期"
            readonly="readonly"
            style="width:80%"
          ></el-date-picker>
        </template>
      </el-table-column>
      <el-table-column label="申请人" prop="applyPersonId"></el-table-column>
      <el-table-column label="油料类型" prop="oilSpec"></el-table-column>
      <el-table-column label="油罐容积(m3)" prop="volume"></el-table-column>
      <el-table-column label="剩余(升)" prop="surpuls"></el-table-column>
      <el-table-column label="日均销售(升)" prop="dayAvg"></el-table-column>
      <el-table-column label="需要(升)" prop="needAmount"></el-table-column>
      <el-table-column label="备注" prop="remark"></el-table-column>
      <el-table-column align="right" fixed="right" width="160%">
        <template slot="header" slot-scope="scope">
          <!-- <el-input
          v-model="search"
          size="mini"
          placeholder="输入关键字搜索"
          :id="scope"
          style="width:100%"
          />-->
          <el-button type="primary" :id="scope" plain @click="dialogVisible=true">添加油料申请</el-button>
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
    <el-dialog :visible.sync="dialogVisible" title="添加油料申请" width="45%">
      <el-form ref="form" :model="form" label-width="125px" :rules="rules">
        <div>
          <el-row>
            <el-col :span="12">
              <el-form-item label="申请人：" prop="ApplyPersonId">
                <el-input v-model="form.ApplyPersonId" name="ApplyPersonId"></el-input>
              </el-form-item>
              <el-form-item label="申请时间：" prop="ApplyDate">
                <el-date-picker
                  v-model="form.ApplyDate"
                  type="date"
                  placeholder="选择日期"
                  name="ApplyDate"
                  style="width:100%"
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="油料类型：" prop="OilSpec">
                <el-input v-model="form.OilSpec" name="OilSpec"></el-input>
              </el-form-item>
              <el-form-item label="备注：" prop="Remark">
                <el-input v-model="form.Remark" name="Remark"></el-input>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="油罐容量(m3)：" prop="Volume">
                <el-input v-model="form.Volume" name="Volume"></el-input>
              </el-form-item>
              <el-form-item label="油料剩余(升)：" prop="Surpuls">
                <el-input v-model="form.Surpuls" name="Surpuls"></el-input>
              </el-form-item>
              <el-form-item label="日均销售(升)：" prop="DayAvg">
                <el-input v-model="form.DayAvg" name="DayAvg"></el-input>
              </el-form-item>
              <el-form-item label="需要(升)：" prop="NeedAmount">
                <el-input v-model="form.NeedAmount" name="NeedAmount"></el-input>
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
import { GetOilOrder, DeleteOilOrder, AddOilOrder } from "@/api/oil";
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
      search: "",
      loading: true,
      dialogVisible: false,
      form: {
        ApplyPersonId: "",
        ApplyDate: "",
        Remark: "",
        OilSpec: "",
        Volume: "",
        Surpuls: "",
        DayAvg: "",
        NeedAmount: "",
        No: ""
      },
      rules: {
        ApplyPersonId: [
          { required: true, message: "输入申请人", trigger: "blur" }
        ],
        ApplyDate: [
          { required: true, message: "输入申请时间", trigger: "blur" }
        ],
        OilSpec: [{ required: true, message: "输入油料类型", trigger: "blur" }],
        Volume: [
          { required: true, message: "输入油罐容量(m3)", trigger: "blur" }
        ],
        Surpuls: [
          { required: true, message: "输入油料剩余(升)", trigger: "blur" }
        ],
        DayAvg: [
          { required: true, message: "输入日均销售(升)", trigger: "blur" }
        ],
        NeedAmount: [
          { required: true, message: "输入需要(升)", trigger: "blur" }
        ]
      }
    };
  },
  created() {
    GetOilOrder().then(res => {
      this.tableData = res.data;
      this.loading = false;
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
          DeleteOilOrder(row.id).then(res => {
            GetOilOrder().then(res => {
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
          AddOilOrder(this.form).then(res => {
            GetOilOrder().then(res => {
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