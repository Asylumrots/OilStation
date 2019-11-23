<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <!-- v-for="(item,index) in tableData" :key="item.id" -->
      <el-table-column type="expand">
        <template slot-scope="props">
          <el-form label-position="left" inline class="demo-table-expand">
            <el-form-item label="用户名">
              <span>{{ props.row.userName }}</span>
            </el-form-item>
            <el-form-item label="性别">
              <span>{{ props.row.userSex }}</span>
            </el-form-item>
            <el-form-item label="邮箱">
              <span>{{ props.row.email }}</span>
            </el-form-item>
            <el-form-item label="电话">
              <span>{{ props.row.phoneNumber }}</span>
            </el-form-item>
            <el-form-item label="地址">
              <span>{{ props.row.address }}</span>
            </el-form-item>
            <el-form-item label="生日">
              <span>{{ props.row.birthDay }}</span>
            </el-form-item>
          </el-form>
        </template>
      </el-table-column>
      <el-table-column label="用户名" prop="userName"></el-table-column>
      <el-table-column label="角色名" prop="roleName"></el-table-column>
      <el-table-column label="操作" prop="id">
        <template slot-scope="props">
          <el-button type="primary" plain icon="el-icon-edit" @click="OpenDia(props.$index)">修改</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="修改角色" :visible.sync="dialogVisible" width="30%">
      <el-form :model="form">
        <el-form-item label="用户名：" label-width="130px">
          <el-input v-model="username" autocomplete="off" style="width:204px" disabled="disabled"></el-input>
        </el-form-item>
        <el-form-item label="角色：" label-width="130px">
          <el-select v-model="form.region" placeholder="请选择角色" >
            <!-- <el-option label="暂无" value="暂无"></el-option> -->
            <el-option :label="item.name" :value="item.id" v-for="item in rolesData" v-bind:key="item.id"></el-option>
          </el-select>
        </el-form-item>
      </el-form>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="UpdateRoles()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetUserRole,GetRoles,UpdateRoles } from "@/api/authorize";
export default {
  data() {
    return {
      tableData: [],
      rolesData: [],
      dialogVisible: false,
      username: "null",
      form: {
        region: ""
      },
      userID:"",
    };
  },
  created() {
    this.GetData();
    this.GetRoles();
  },
  methods: {
    GetData() {
      GetUserRole().then(res => {
        this.tableData = res.data;
      });
    },
    GetRoles() {
      GetRoles().then(res => {
        this.rolesData=res.data;
      });
    },
    OpenDia(index) {
      //console.log(index)
      this.userID=this.tableData[index].id;
      this.dialogVisible = true;
      this.username = this.tableData[index].userName;
      this.form.region = this.tableData[index].roleName;
    },
    UpdateRoles(){
      //console.log(this.form);
      this.dialogVisible = false
      UpdateRoles(this.userID,this.form.region).then(res=>{
        //刷新数据
        this.GetData();
        this.GetRoles();
      })
    }
  }
};
</script>

<style>
.demo-table-expand {
  font-size: 0;
}
.demo-table-expand label {
  width: 90px;
  color: #99a9bf;
}
.demo-table-expand .el-form-item {
  margin-right: 0;
  margin-bottom: 0;
  width: 50%;
}
</style>