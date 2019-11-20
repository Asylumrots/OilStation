import request from '@/utils/request'

export function GetUserRole() {
  return request({
    url: '/User/UserRole_Get',
    method: 'get',
  })
}

export function GetRoles() {
  return request({
    url: '/User/Roles_Get',
    method: 'get'
  })
}

export function UpdateRoles(userId, roleId) {
  return request({
    url: '/User/Roles_Update',
    method: 'put',
    data: { userId, roleId }
  })
}

export function GetClaim(roleId) {
  return request({
    url: '/User/Claim_Get',
    method: 'get',
    params: { roleId }
  })
}