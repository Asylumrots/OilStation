import request from '@/utils/request'

export function GetOrganization() {
  return request({
    url: '/Organization/Organization_Get',
    method: 'get',
  })
}

export function UpdateOrganization(model) {
  return request({
    url: '/Organization/Organization_Update',
    method: 'post',
    data: model
  })
}

export function AddOrganization(model) {
  return request({
    url: '/Organization/Organization_Add',
    method: 'post',
    data: model
  })
}

export function DeleteOrganization(id) {
  return request({
    url: '/Organization/Organization_Delete',
    method: 'post',
    params: {id}
  })
}