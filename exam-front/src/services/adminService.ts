import { AdminUD } from "@/domain/adminUserData";
import axiosInstance from "./axiosInstance";
import { baseUrl } from "./baseUrl";
import { AdminUserDataWithPw } from "@/domain/adminUserData-w-pw";

// api/Admin/CreateSU
// api/Admin/GetAllUsers
// api/Admin/DeleteUser
export default class AdminService{
  private constructor(){}

  static async GetAllUsers(): Promise<AdminUD[]>{
    try{
      // console.log("get users")
      const res = await axiosInstance.get<AdminUD[]>(baseUrl + "api/Admin/GetAllUsers")
      // console.log("got users")
      return res.data
    }catch(error){
      console.error(error)
      return []
    }
  }

  static async CreateSuperUser(userdata: AdminUserDataWithPw): Promise<void>{
    try{
      const res = await axiosInstance.put(baseUrl + "api/Admin/CreateSU", userdata)
      console.log("succesfully created user")
    }catch (error) {
      // Handle the error as needed
      console.error('Error creating super user', error);
      throw error;
    }
  }

  static async DeleteUser(userData: AdminUD): Promise<void>{
    await axiosInstance.delete(baseUrl + "api/Admin/DeleteUser", {
      data: userData});
  }
}