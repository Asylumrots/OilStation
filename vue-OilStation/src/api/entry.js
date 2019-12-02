import request from '@/utils/request'

export function GetEntry() {
  return request({
    url: '/Entry/Entry_Get',
    method: 'get',
  })
}

export function GetEntryCheck() {
  return request({
    url: '/Entry/Entry_CheckGet',
    method: 'get',
  })
}

export function CheckEntry(model) {
  return request({
    url: '/Entry/Entry_Check',
    method: 'post',
    data: model
  })
}

export function DeleteEntry(id) {
  return request({
    url: '/Entry/Entry_Delete',
    method: 'post',
    params: {id}
  })
}

export function AddEntry(model) {
  return request({
    url: '/Entry/Entry_Add',
    method: 'post',
    data: model
  })
}