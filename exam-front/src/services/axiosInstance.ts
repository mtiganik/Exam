import axios from 'axios'
import { baseUrl } from './baseUrl'
import { JwtResponse } from '@/domain/JwtResponse'

const axiosInstance = axios.create({
  baseURL: baseUrl
})

axiosInstance.interceptors.request.use(
  config => {
    const userDataString = localStorage.getItem("userData")
    if(userDataString){
      const userData : JwtResponse = JSON.parse(userDataString)
      config.headers['Authorization'] = 'Bearer ' + userData.jwt
    }
    return config;
  }
)

axiosInstance.interceptors.response.use(
  (response) => response,
  async(error) => {
    if(error.response && error.response.status == 401){

      const userDataString = localStorage.getItem("userData")
      console.log(userDataString)

      if(!userDataString){

        // router.push("/login")
        return Promise.reject(error)
      }else{
        try{
          const userData : JwtResponse = JSON.parse(userDataString)
          const response = await axios.post<JwtResponse>(baseUrl + "api/Account/RefreshTokenData",{
            jwt: userData.jwt,
            refreshToken: userData.refreshToken
          })
          console.log(response)

          if(response.status < 300){
            localStorage.setItem("userData",JSON.stringify( response.data));
            error.config.headers.Authorization = `Bearer ${response.data.jwt}`;
            return axios(error.config);
    
          }else{
            localStorage.removeItem("userData")
            return Promise.reject(error)

          }
        }catch(error){
          console.error("Error in interceptor,",error)
          return Promise.reject(error)
        }
      }
    }
    return Promise.reject(error);
  }
)

export default axiosInstance;