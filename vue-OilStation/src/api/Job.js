import request from '@/utils/request'

export function GetJob() {
  return request({
    url: '/Job/Job_Get',
    method: 'get',
  })
}

export function UpdateJob(model) {
  return request({
    url: '/Job/Job_Update',
    method: 'put',
    data: model
  })
}

export function DeleteJob(id) {
  return request({
    url: '/Job/Job_Delete',
    method: 'delete',
    params: {id}
  })
}

export function AddJob(model) {
  return request({
    url: '/Job/Job_Add',
    method: 'post',
    data: model
  })
}