import request from '@/utils/request'

export function login(data) {
  console.log(data)
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

export function logout() {
  return request({
    url: '/User/Logout',
    method: 'get'
  })
}
