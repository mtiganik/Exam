import { FrontPageData } from "@/domain/frontPageData";
import axiosInstance from "./axiosInstance";
import { HwData } from "@/domain/HwData";

export default class StudentService{
  private constructor(){}

  static async getStudentSubjects(): Promise<FrontPageData[]>{
    try{
      const response = await axiosInstance
      .get<FrontPageData[]>("api/Student/getStudentSubs")
      return response.data
    }catch(error){
      console.error(error)
      return []
    }
  }

  static async getStudentHWs(): Promise<HwData[]>{
    try{
      const response = await axiosInstance
      .get<HwData[]>("api/Student/HW")
      return response.data
    }catch(error){
      console.error(error)
      return [];
    }
  }

  static async studentsForSub(subjectId:string): Promise<string[]>{
    try{
      const response = await axiosInstance
      .get<string[]>(`
      /api/Student/studentsForSub?subjectId=${subjectId}`)
      return response.data
    }catch(error){
      console.error(error)
      return [];
    }
  }
}