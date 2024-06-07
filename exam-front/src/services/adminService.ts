// import { AdminUD } from "@/domain/adminUserData";
import axiosInstance from "./axiosInstance";
import { baseUrl } from "./baseUrl";
// import { AdminUserDataWithPw } from "@/domain/adminUserData-w-pw";
import AdminCompany from "@/domain/adminCompany";

// api/Admin/GetAllCompanies
// api/Admin/CompanyDelete
// api/Admin/CompanyUpdate
export default class AdminService{
  private constructor(){}

  static async GetAllCompanies(): Promise<AdminCompany[]>{
    try{
      const res = await axiosInstance.get<AdminCompany[]>(baseUrl + "api/Admin/GetAllCompanies")
      console.log(res)
      return res.data
    }catch(error){
      console.error(error)
      return []
    }
  }
// api/Admin/AddCompany

  static async AddCompany(userdata: AdminCompany): Promise<void>{
    try{
      const res = await axiosInstance.put(baseUrl + "api/Admin/AddCompany", userdata)
      console.log("succesfully created user")
    }catch (error) {
      // Handle the error as needed
      console.error('Error creating super user', error);
      throw error;
    }
  }

  // api/Admin/CompanyDelete

  static async DeleteCompany(userData: AdminCompany): Promise<void>{
    await axiosInstance.delete(baseUrl + "api/Admin/CompanyDelete", {
      data: userData});
  }
}