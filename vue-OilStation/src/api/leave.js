import request from '@/utils/request'

export function GetLeave() {
  return request({
    url: '/Leave/Leave_Get',
    method: 'get',
  })
}

export function GetLeaveCheck() {
  return request({
    url: '/Leave/Leave_CheckGet',
    method: 'get',
  })
}

export function CheckLeave(model) {
  return request({
    url: '/Leave/Leave_Check',
    method: 'put',
    data: model
  })
}

export function DeleteLeave(id) {
  return request({
    url: '/Leave/Leave_Delete',
    method: 'delete',
    params: {id}
  })
}

export function AddLeave(model) {
  return request({
    url: '/Leave/Leave_Add',
    method: 'post',
    data: model
  })
}