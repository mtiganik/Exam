import axios from "axios";
import { baseUrl } from "./baseUrl";
import { FrontPageData } from "@/domain/frontPageData";
export default class FrontPageService{
  private constructor(){}

  private static httpClient = axios.create({
    baseURL: baseUrl + "api/FrontPage"
  });

  static async GetFrontPageSubs()
  :Promise<FrontPageData[]>
  {
    try{
      console.log("Start of fetch")

      const response = await FrontPageService.httpClient.get<FrontPageData[]>("");
      console.log("response")

      console.log(response)
      //return []
      return response.data
    }catch(error){
      console.log(error)
      return []
    }
  }

}