import request from '@/utils/request'

export function login(data) {
  return request({
    url: '/User/Login',
    method: 'post',
    data
  })
}

export function getInfo(token) {
  return request({
    url: '/User/Info',
    method: 'post',
    params: { token }
  })
}

export function refreshToken(token) {
  return request({
    url: '/User/RefreshToken',
    method: 'post',
    params: { token }
  })
}

export function logout() {
  return request({
    url: '/User/Logout',
    method: 'get'
  })
}


export function GetUserInfo() {
  return request({
    url: '/User/UserInfo_Get',
    method: 'get'
  })
}

export function UpdateInfo(model) {
  return request({
    url: '/User/UserInfo_Update',
    method: 'put',
    data: model
  })
}

export function DeleteInfo(id) {
  return request({
    url: '/User/UserInfo_Delete',
    method: 'delete',
    params:{id}
  })
}
