import axiosInstance from "./axiosInstance";
import { baseUrl } from "./baseUrl";
import ItemDTO from "@/domain/su/itemDTO";
import ShuffleResult from "@/domain/su/shuffleResult";
export default class SuService{
  private constructor(){}


  static async AddItems(items: string[]) : Promise<ItemDTO[]>{
    const res = await axiosInstance
    .post<ItemDTO[]>(baseUrl + "api/Su/AddItems", {items: items})
    return res.data
    }
  // api/Su/ExecuteSuffle
  static async ExecuteSuffle() :Promise<ShuffleResult[]>{
    const res = await axiosInstance
    .post<ShuffleResult[]>(baseUrl + "api/Su/ExecuteSuffle")
    return res.data
  }

}

