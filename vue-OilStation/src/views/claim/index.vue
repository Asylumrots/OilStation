<template>
  <div>
    <el-table :data="tableData" style="width: 100%">
      <!-- <el-table-column type="index"></el-table-column> -->
      <el-table-column prop="id" label="ID" sortable></el-table-column>
      <el-table-column prop="name" label="名称" sortable></el-table-column>
      <el-table-column label="操作">
        <template slot-scope="props">
          <el-button type="primary" plain icon="el-icon-edit" @click="OpenDia(props.$index)">修改</el-button>
        </template>
      </el-table-column>
    </el-table>
    <el-dialog title="修改声明" :visible.sync="dialogVisible" width="30%">
      <el-tree :data="data" show-checkbox node-key="code" ref="tree"></el-tree>
      <span slot="footer" class="dialog-footer">
        <el-button @click="dialogVisible = false">取 消</el-button>
        <el-button type="primary" @click="Update()">确 定</el-button>
      </span>
    </el-dialog>
  </div>
</template>

<script>
import { GetRoles, GetClaim, UpdateClaim } from "@/api/authorize";
// :default-expanded-keys="[2, 3]"
// :default-checked-keys="[5]"
export default {
  data() {
    return {
      tableData: [],
      dialogVisible: false,
      data: [
        {
          code: "Roles",
          label: "用户角色管理",
          children: [
            {
              code: "Roles_Get",
              label: "查看信息"
            },
            {
              code: "Roles_Update",
              label: "修改信息"
            }
          ]
        },
        {
          code: "Claim",
          label: "角色声明管理",
          children: [
            {
              code: "Claim_Get",
              label: "查看信息"
            },
            {
              code: "Claim_Update",
              label: "修改信息"
            }
          ]
        }
      ],
      selectData: [],
      id:""
    };
  },
  created() {
    this.GetRoles();
  },
  methods: {
    GetRoles() {
      GetRoles().then(res => {
        this.tableData = res.data;
      });
    },
    // GetClaim(RoleId) {
    //   GetClaim(RoleId).then(res => {
    //     this.selectData = res.data;
    //   });
    // },
    OpenDia(index) {
      //获取Claim
      this.id=this.tableData[index].id;
      GetClaim(this.tableData[index].id).then(res => {
        this.selectData = res.data;
        this.dialogVisible = true;
        //等待
        this.$nextTick(() => {
          this.$refs.tree.setCheckedKeys(this.selectData);
        });
      });
    },
    Update() {
      UpdateClaim(this.id,this.$refs.tree.getCheckedKeys()).then(res=>{
        console.log(res)
      })
      this.dialogVisible = false;
      //console.log(this.$refs.tree.getCheckedKeys());
    }
  }
};
</script>