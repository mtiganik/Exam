import axios from "axios";
import { baseUrl } from "./baseUrl";
import { JwtResponse } from "@/domain/JwtResponse";



export default class LoginService{
  private constructor(){}

  private static httpClient = axios.create({
    baseURL: baseUrl + "api/Account"
  });
  static async Register( userName: string, firstName:string, lastName:string, email:string, password:string):Promise<JwtResponse>{
    try{
      const response = 
      await LoginService.httpClient.post<JwtResponse>("/Register",{
        userName: userName,
        firstName: firstName,
        lastName: lastName,
        email: email,
        password: password
      });
      return response.data;
    }catch(error){
      console.error(error)
      throw error;
    }
  }

  static async Login(email:string, password:string): Promise<JwtResponse>{
    try{
      const response = await LoginService.httpClient.post<JwtResponse>("/Login",{
        email: email,
        password: password
      })
      console.log("Succesfully logged in")
      return response.data
    }catch(error){
      console.error(error);
      throw error
    }
  }
}
