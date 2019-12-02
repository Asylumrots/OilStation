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
          code: 'Roles',
          label: '用户角色管理',
          children: [
            {
              code: 'Roles_Get',
              label: '查看角色信息(页面)'
            },
            {
              code: 'Roles_Update',
              label: '修改角色信息(按钮)'
            }
          ]
        },
        {
          code: 'Claim',
          label: '角色声明管理',
          children: [
            {
              code: 'Claim_Get',
              label: '查看声明信息(页面)'
            },
            {
              code: 'Claim_Update',
              label: '修改声明信息(按钮)'
            }
          ]
        },
        {
          code: 'UserInfo',
          label: '用户管理',
          children: [
            {
              code: 'UserInfo_Get',
              label: '查看用户信息(页面)'
            },
            {
              code: 'UserInfo_Update',
              label: '修改用户信息(按钮)'
            },
            {
              code: 'UserInfo_Delete',
              label: '删除用户信息(按钮)'
            }
          ]
        },
        {
          code: 'Job',
          label: '职位管理',
          children: [
            {
              code: 'Job_Get',
              label: '查看职位信息(页面)'
            },
            {
              code: 'Job_Add',
              label: '添加职位信息(按钮)'
            },
            {
              code: 'Job_Update',
              label: '修改职位信息(按钮)'
            },
            {
              code: 'Job_Delete',
              label: '删除职位信息(按钮)'
            }
          ]
        },
        {
          code: 'Organization',
          label: '组织管理',
          children: [
            {
              code: 'Organization_Get',
              label: '查看组织信息(页面)'
            },
            {
              code: 'Organization_Add',
              label: '添加组织信息(按钮)'
            },
            {
              code: 'Organization_Update',
              label: '修改组织信息(按钮)'
            },
            {
              code: 'Organization_Delete',
              label: '删除组织信息(按钮)'
            }
          ]
        },
        {
          code: 'Entry',
          label: '员工入职',
          children: [
            {
              code: 'Entry_Get',
              label: '查看入职信息(页面)'
            },
            {
              code: 'Entry_CheckGet',
              label: '查看未审核入职信息(页面)'
            },
            {
              code: 'Entry_Add',
              label: '添加入职信息(按钮)'
            },
            {
              code: 'Entry_Check',
              label: '审核入职信息(按钮)'
            },
            {
              code: 'Entry_Delete',
              label: '删除入职信息(按钮)'
            },
          ]
        },
        {
          code: 'Leave',
          label: '员工离职',
          children: [
            {
              code: 'Leave_Get',
              label: '查看离职信息(页面)'
            },
            {
              code: 'Leave_CheckGet',
              label: '修改未审核离职信息(页面)'
            },
            {
              code: 'Leave_Add',
              label: '添加离职信息(按钮)'
            },
            {
              code: 'Leave_Check',
              label: '审核离职信息(按钮)'
            },
            {
              code: 'Leave_Delete',
              label: '删除离职信息(按钮)'
            }
          ]
        },
        {
          code: 'OilOrder',
          label: '油料申请',
          children: [
            {
              code: 'OilOrder_Get',
              label: '查看油料申请信息(页面)'
            },
            {
              code: 'OilOrder_CheckGet',
              label: '查看未审核油料申请信息(页面)'
            },
            {
              code: 'OilOrder_Add',
              label: '添加油料申请(按钮)'
            },
            {
              code: 'OilOrder_Check',
              label: '审核油料申请(按钮)'
            },
            {
              code: 'OilOrder_Delete',
              label: '删除油料申请(按钮)'
            }
          ]
        }
      ],
      selectData: [],
      id:''
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
}
</script>