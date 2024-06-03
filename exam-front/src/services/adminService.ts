import { AdminUD } from "@/domain/adminUserData";
import axiosInstance from "./axiosInstance";
import { baseUrl } from "./baseUrl";


// api/Admin/CreateSU
// api/Admin/GetAllUsers
// api/Admin/DeleteUser
export default class AdminService{
  private constructor(){}

  static async GetAllUsers(): Promise<AdminUD[]>{
    try{
      const res = await axiosInstance.get<AdminUD[]>(baseUrl + "api/Admin/GetAllUsers")
      return res.data
    }catch(error){
      console.error(error)
      return []
    }
  }

  static async CreateSuperUser(userdata: AdminUD, pw: string): Promise<void>{
    try{
      const payload = {
        firstName: userdata.firstName,
        lastName: userdata. lastName,
        userName: userdata.userName,
        email: userdata.email,
        password: pw
      }
      const res = await axiosInstance.put(baseUrl + "api/Admin/CreateSU", payload)
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