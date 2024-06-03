"use client"
import { useState, useEffect } from "react"
import LoadingImg from "@/assets/loading/loading-50.gif"
import Image from "next/image"
import { AdminUD } from "@/domain/adminUserData"
import AdminService from "@/services/adminService"
import CreateUser from "./create-user"
import { UserView } from "./user-view"
export default function Users(){
  const [users, setUsers] = useState<AdminUD[]>([])
  const [isLoading, setIsLoading] = useState(true)

  const loadData = async() => {
    try{
      const res = await AdminService.GetAllUsers();
      console.log(res)
      setUsers(res)
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
      users.map((user) => (
        <UserView key={user.email} userData = {user} />
      ))
    )}
      from users page
    </>
  )
}