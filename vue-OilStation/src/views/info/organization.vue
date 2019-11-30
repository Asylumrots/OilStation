<template>
  <div>
    <div style="margin:25px">
      <el-input placeholder="输入关键字进行过滤" v-model="filterText" style="width:450px"></el-input>
      <el-button type="success" plain @click="Add" icon="el-icon-plus">添加子机构</el-button>
      <el-button type="primary" plain @click="Update" icon="el-icon-edit">修改机构</el-button>
      <el-button type="danger" plain @click="Del" icon="el-icon-delete">删除机构</el-button>
    </div>
    <el-tree
      :data="data"
      @node-click="handleNodeClick"
      class="filter-tree"
      default-expand-all
      :filter-node-method="filterNode"
      ref="tree"
      style="margin:25px;font-size:20px"
    ></el-tree>
    <el-dialog :visible.sync="dialogVisible" :title="title" width="30%">
      <el-form ref="form" :model="form" label-width="100px" :rules="rules">
        <div>
          <el-form-item label="机构名称：" prop="name">
            <el-input v-model="form.name" name="name"></el-input>
          </el-form-item>
          <el-form-item label="职位代码：" prop="code">
            <el-input v-model="form.code" name="code"></el-input>
          </el-form-item>
        </div>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="click()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import {
  GetOrganization,
  UpdateOrganization,
  AddOrganization,
  DeleteOrganization
} from "@/api/organization";
export default {
  watch: {
    filterText(val) {
      this.$refs.tree.filter(val);
    }
  },
  data() {
    return {
      data: [],
      filterText: "",
      selectData: [],
      title: "",
      dialogVisible: false,
      form: {
        id: "",
        name: "",
        code: ""
      },
      rules: {
        name: [{ required: true, message: "请输入机构名称", trigger: "blur" }],
        code: [{ required: true, message: "请输入机构代码", trigger: "blur" }]
      }
    };
  },
  created() {
    GetOrganization().then(res => {
      this.data = res.data;
    });
  },
  methods: {
    filterNode(value, data) {
      if (!value) return true;
      return data.label.indexOf(value) !== -1;
    },
    handleNodeClick(data) {
      this.selectData = data;
    },
    Add() {
      if (this.selectData.length == 0) {
        this.$message.error("请选中行，在进行操作！");
        return false;
      }
      this.title = "添加一个子机构";
      this.dialogVisible = true;
      this.$nextTick(() => {
        this.$refs["form"].resetFields();
      });
    },
    Update() {
      if (this.selectData.length == 0) {
        this.$message.error("请选中行，在进行操作！");
        return false;
      }
      this.title = "修改机构";
      this.dialogVisible = true;
      this.$nextTick(() => {
        this.$refs["form"].resetFields();
        this.form.id = this.selectData.id;
        this.form.name = this.selectData.label;
        this.form.code = this.selectData.code;
      });
    },
    Del() {
      if (this.selectData.length == 0) {
        this.$message.error("请选中行，在进行操作！");
        return false;
      }
      console.log(this.selectData);
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {
          DeleteOrganization(this.selectData.id).then(res => {
            GetOrganization().then(res => {
              this.data = res.data;
            });
          });
        })
        .catch(() => {});
    },
    click() {
      this.$refs["form"].validate(valid => {
        if (valid) {
          if (this.title == "添加一个子机构") {
            AddOrganization(this.form).then(res => {
              this.dialogVisible=false;
              GetOrganization().then(res => {
                this.data = res.data;
              });
            });
          }
          if (this.title == "修改机构") {
            UpdateOrganization(this.form).then(res => {
              this.dialogVisible=false;
              GetOrganization().then(res => {
                this.data = res.data;
              });
            });
          }
        }
      });
    }
  }
};
</script>