"use client"
import { useState } from "react"
// import { AdminUD } from "@/domain/adminUserData"
import AdminCompany from "@/domain/adminCompany"
import AdminService from "@/services/adminService"
interface UserViewProps{
  companyData: AdminCompany
}

export const UserView:React.FC<UserViewProps> = ( {companyData}) => {
  const adminCompanyId = "d9d87ed8-a54f-4c70-8cc4-ae81fe68a7df";
  const [error, setError] = useState("");
  const deleteUser = async() => {
    try{
      await AdminService.DeleteCompany(companyData)
      window.location.reload();
    }catch(error){
      console.error(error)
      setError("Error deleting, see console")
    }
  }
  return(
    <>
    <div style={{border:"1px solid", margin:"2px", padding:"2px"}}>
      <div>Name: {companyData.companyName} IsPublic: {companyData.isPublic}</div><div>Main user: {companyData.suName} {companyData.suEmail}</div>
      { companyData.suEmail !== "admin@admin.ee" && (
        <button onClick={deleteUser}>delete</button>

      )}
      <p className="text-danger">{error}</p>
      </div>
    </>
  )
}