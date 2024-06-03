"use client"
import { useState } from "react"
import { AdminUD } from "@/domain/adminUserData"
import AdminService from "@/services/adminService"
interface UserViewProps{
  userData: AdminUD
}

export const UserView:React.FC<UserViewProps> = ( {userData}) => {
  const [error, setError] = useState("");
  const deleteUser = async() => {
    try{
      await AdminService.DeleteUser(userData)
      window.location.reload();
    }catch(error){
      console.error(error)
      setError("Error deleting, see console")
    }
  }
  return(
    <>
    <div style={{border:"1px solid", margin:"2px", padding:"2px"}}>
      <div>{userData.firstName} {userData.lastName}</div><div> {userData.userName} {userData.email}</div>
      <button onClick={deleteUser}>delete</button>
      <p className="text-danger">{error}</p>
      </div>
    </>
  )
}