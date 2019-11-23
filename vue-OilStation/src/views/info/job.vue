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
        <template slot="header" >
          <!-- <el-input v-model="search" placeholder="输入职位搜索" :id="scope"/> slot-scope="scope" -->
          <el-button type="success" @click="Add()">添加</el-button>
        </template>
        <template slot-scope="scope">
          <el-button @click="handleEdit(scope.$index, scope.row)">编辑</el-button>
          <el-button type="danger" @click="handleDelete(scope.$index, scope.row)">删除</el-button>
        </template>
      </el-table-column>
    </el-table>
  </div>
</template>

<script>
import { GetJob } from "@/api/Job";
export default {
  data() {
    return {
      tableData: [],
      dialogVisible: false,
      search: "",
      rules: {}
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
      this.$nextTick(() => {});
    },
    handleDelete(index, row) {
      //console.log(index, row);
      this.$confirm("此操作将永久删除, 是否继续?", "提示", {
        confirmButtonText: "确定",
        cancelButtonText: "取消",
        type: "warning"
      })
        .then(() => {})
        .catch(() => {
          this.$message({
            type: "info",
            message: "已取消删除"
          });
        });
    }
  }
};
</script>