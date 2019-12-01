import request from '@/utils/request'

export function GetOilOrder() {
  return request({
    url: '/Oil/OilOrder_Get',
    method: 'get',
  })
}

export function GetOilOrderCheck() {
  return request({
    url: '/Oil/OilOrder_CheckGet',
    method: 'get',
  })
}

export function CheckOilOrder(model) {
  return request({
    url: '/Oil/OilOrder_Check',
    method: 'put',
    data: model
  })
}

export function DeleteOilOrder(id) {
  return request({
    url: '/Oil/OilOrder_Delete',
    method: 'delete',
    params: {id}
  })
}

export function AddOilOrder(model) {
  return request({
    url: '/Oil/OilOrder_Add',
    method: 'post',
    data: model
  })
}