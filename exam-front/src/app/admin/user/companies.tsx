"use client"
import { useState, useEffect } from "react"
import LoadingImg from "@/assets/loading/loading-50.gif"
import Image from "next/image"
import AdminCompany from "@/domain/adminCompany"
import AdminService from "@/services/adminService"
import CreateUser from "./create-user"
import { UserView } from "./user-view"
export default function Companies(){
  const [companies, setCompanies] = useState<AdminCompany[]>([])
  const [isLoading, setIsLoading] = useState(true)

  const loadData = async() => {
    try{
      const res = await AdminService.GetAllCompanies();
      console.log(res)
      setCompanies(res)
      setIsLoading(false)
    }catch(error){
      console.error("Error loading data: ", error)
    }
  }

  useEffect(() => {
    loadData();
  } , []);
  return(
    <>
    <CreateUser />
    {isLoading && (<Image src={LoadingImg} alt="loading" />)}
    {!isLoading && (
      <>
      <h3>All companies</h3>
      {companies.map((company) => (
        <UserView key={company.id} companyData = {company} />
      ))}
      </>
    )}
      from users page
    </>
  )
}