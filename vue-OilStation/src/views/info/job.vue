<template>
  <div>
    <el-table
      :data="tableData.filter(data => !search || data.name.toLowerCase().includes(search.toLowerCase()))"
      style="width: 100%"
      stripe
    >
      <el-table-column label="职位名称" prop="name" align="center"></el-table-column>
      <el-table-column label="职位代码" prop="code" align="center"></el-table-column>

      <el-table-column align="right">
        <template slot="header">
          <!-- <el-input v-model="search" placeholder="输入职位搜索" :id="scope"/> slot-scope="scope" -->
          <el-button type="success" @click="AddDia()">添加</el-button>
        </template>
        <template slot-scope="scope">
          <el-button @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="修改职位" :visible.sync="dialogVisible" width="30%">
      <el-form ref="form" :model="form" label-width="100px" :rules="rules">
        <div>
          <el-form-item label="职位名称：" prop="name">
            <el-input v-model="form.name" name="name"></el-input>
          </el-form-item>
          <el-form-item label="职位代码：" prop="code">
            <el-input v-model="form.code" name="code"></el-input>
          </el-form-item>
        </div>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Update()">确 定</el-button>
      </span>
    </el-dialog>

    <el-dialog title="新增职位" :visible.sync="AdddialogVisible" width="30%">
      <el-form ref="Addform" :model="Addform" label-width="100px" :rules="rules">
        <div>
          <el-form-item label="职位名称：" prop="name">
            <el-input v-model="Addform.name" name="name"></el-input>
          </el-form-item>
          <el-form-item label="职位代码：" prop="code">
            <el-input v-model="Addform.code" name="code"></el-input>
          </el-form-item>
        </div>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="AdddialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Add()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetJob, UpdateJob, DeleteJob, AddJob } from "@/api/Job";
export default {
  data() {
    return {
      tableData: [],
      form: {
        id: "",
        name: "",
        code: ""
      },
      Addform: {
        id: "",
        name: "",
        code: ""
      },
      dialogVisible: false,
      AdddialogVisible: false,
      search: "",
      rules: {
        name: [{ required: true, message: "请输入职位名称", trigger: "blur" }],
        code: [{ required: true, message: "请输入职位代码", trigger: "blur" }]
      }
    };
  },
  created() {
    GetJob().then(res => {
      this.tableData = res.data;
    });
  },
  methods: {
    handleEdit(index, row) {
      this.dialogVisible = true;
      this.$nextTick(() => {
        this.$refs["form"].resetFields();
        this.form.name = row.name;
        this.form.code = row.code;
        this.form.id = row.id;
      });
    },
    handleDelete(index, row) {
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          DeleteJob(row.id).then(res => {
            GetJob().then(res => {
              this.tableData = res.data;
            });
          });
        })
        .catch(() => {});
    },
    Update() {
      this.$refs["form"].validate(valid => {
        if (valid) {
          UpdateJob(this.form).then(res => {
            this.dialogVisible = false;
            GetJob().then(res => {
              this.tableData = res.data;
            });
          });
        }
      });
    },
    AddDia() {
      this.AdddialogVisible = true;
    },
    Add() {
      AddJob(this.Addform).then(res => {
        this.AdddialogVisible = false;
        this.$refs["Addform"].resetFields();
        GetJob().then(res => {
          this.tableData = res.data;
        });
      });
    }
  }
};
</script>