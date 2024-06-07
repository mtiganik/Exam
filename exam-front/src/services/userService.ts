import axiosInstance from "./axiosInstance";
import { baseUrl } from "./baseUrl";
import UserGetUsers from "@/domain/user/userGetUsers";

export default class UserService{
  private constructor(){}

  static async GetCompanyUsers() : Promise<UserGetUsers[]>{
    const res = await axiosInstance.get<UserGetUsers[]>
    (baseUrl + "api/User/GetCompanyUsers")
    return res.data
  }

  static async GetYourItems() : Promise<string[]>{
    const res = await axiosInstance.get<string[]>
    (baseUrl + "api/User/GetYourItems")
    return res.data
  }

  static async LogWork(minutes : number) : Promise<number>{
    const res = await axiosInstance.put<number>
    (`${baseUrl}api/User/LogWork?minutes=${minutes}`)
    return res.data;
  }
}
