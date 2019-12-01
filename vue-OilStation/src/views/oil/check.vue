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
    <el-dialog :visible.sync="dialogVisible" title="审核油料申请" width="45%">
      <el-form ref="form" :model="form" label-width="125px">
        <div>
          <el-row>
            <el-col :span="12">
              <el-form-item label="申请人：" prop="ApplyPersonId">
                <el-input v-model="form.ApplyPersonId" name="ApplyPersonId" disabled></el-input>
              </el-form-item>
              <el-form-item label="申请时间：" prop="ApplyDate">
                <el-date-picker
                  v-model="form.ApplyDate"
                  type="date"
                  placeholder="选择日期"
                  name="ApplyDate"
                  style="width:100%"
                  disabled
                ></el-date-picker>
              </el-form-item>
              <el-form-item label="油料类型：" prop="OilSpec">
                <el-input v-model="form.OilSpec" name="OilSpec" disabled></el-input>
              </el-form-item>
              <el-form-item label="备注：" prop="Remark">
                <el-input v-model="form.Remark" name="Remark" disabled></el-input>
              </el-form-item>
            </el-col>
            <el-col :span="12">
              <el-form-item label="油罐容量(m3)：" prop="Volume">
                <el-input v-model="form.Volume" name="Volume" disabled></el-input>
              </el-form-item>
              <el-form-item label="油料剩余(升)：" prop="Surpuls">
                <el-input v-model="form.Surpuls" name="Surpuls" disabled></el-input>
              </el-form-item>
              <el-form-item label="日均销售(升)：" prop="DayAvg">
                <el-input v-model="form.DayAvg" name="DayAvg" disabled></el-input>
              </el-form-item>
              <el-form-item label="需要(升)：" prop="NeedAmount">
                <el-input v-model="form.NeedAmount" name="NeedAmount" disabled></el-input>
              </el-form-item>
            </el-col>
          </el-row>
          <el-row>
            <el-col :span="24" >
              <el-form ref="checkForm" :model="checkData" label-width="100px" :rules="rules" style="margin-left: 20%">
                <el-form-item label="审核状态：" prop="CheckNo">
                  <el-radio v-model="checkData.CheckNo" label="1" border>同意</el-radio>
                  <el-radio v-model="checkData.CheckNo" label="-1" border>驳回</el-radio>
                </el-form-item>
              </el-form>
            </el-col>
          </el-row>
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
import { GetOilOrderCheck, CheckOilOrder } from "@/api/oil";
export default {
  data() {
    return {
      tableData: [],
      loading: true,
      search: "",
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
    GetOilOrderCheck().then(res => {
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
      console.log(row);
      this.checkData.id = row.id;
      this.dialogVisible = true;
      this.form.ApplyPersonId = row.applyPersonId;
      this.form.ApplyDate = row.applyDate;
      this.form.Remark = row.remark;
      this.form.OilSpec = row.oilSpec;
      this.form.No = row.no;
      this.form.Volume = row.volume;
      this.form.Surpuls = row.surpuls;
      this.form.DayAvg = row.dayAvg;
      this.form.NeedAmount = row.needAmount;
    },
    Cilck() {
      this.$refs["checkForm"].validate(valid => {
        if (valid) {
          this.loading = true;
          CheckOilOrder(this.checkData).then(res => {
            GetOilOrderCheck().then(res => {
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