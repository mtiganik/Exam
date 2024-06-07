"use client"
import { useState } from "react"
// import { AdminUD } from "@/domain/adminUserData"
// import { AdminUserDataWithPw } from "@/domain/adminUserData-w-pw"
import AdminCompany from "@/domain/adminCompany"

import AdminService from "@/services/adminService"
/*
"companyName": string;
"isPublic": boolean;
"suName": string;
"suEmail": string;
"suPw": string;
"activityMinutes": number;

*/
export default function CreateUser(){
  const [cn, setCn] = useState("")
  const [isPublic, setIsPublic] = useState(true)
  const [suN, setSuN] = useState("")
  const [suEmail, setSuEmail] = useState("")
  const [suPw, setSuPw] = useState("")
  const [activityMinutes, setActivityMinutes] = useState<number>(10)
  const createSU = async() => {
    try{
      const payload : AdminCompany = {
        companyName : cn,
        isPublic : isPublic,
        suName : suN,
        suEmail : suEmail,
        suPw : suPw,
        activityMinutes : activityMinutes,
        id: null,
        sort1: 1,
        sort2: 2,
        tag: "hello"
      }
      const res = await AdminService.AddCompany(payload)
      window.location.reload();
    }catch(error){
      console.log("error")
    }
  }

  return(
    <><h3>Create new Company</h3> 
    <input type="input" placeholder="Company name" onChange={(e) => setCn(e.target.value)} />
    <input type="checkbox" placeholder="IsPublic" checked={isPublic} onChange={() =>setIsPublic(!isPublic)} />
    <input type="input" placeholder="Main user Name" onChange={(e) => setSuN(e.target.value)} />
    <input type="input" placeholder="Main user email" onChange={(e) => setSuEmail(e.target.value)} />
    <input type="input" placeholder="Main user password" onChange={(e) => setSuPw(e.target.value)} />
    <input type="number" placeholder="activity minutes" onChange={(e) => setSuPw(e.target.value)} />
    <button type="submit" onClick={createSU}>Create</button>
    </>
  )
}