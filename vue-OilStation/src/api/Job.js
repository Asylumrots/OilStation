import request from '@/utils/request'

export function GetJob() {
  return request({
    url: '/Job/Job_Get',
    method: 'get',
  })
}