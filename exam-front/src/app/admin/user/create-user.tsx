"use client"
import { useState } from "react"
import { AdminUD } from "@/domain/adminUserData"
import { AdminUserDataWithPw } from "@/domain/adminUserData-w-pw"
import AdminService from "@/services/adminService"

export default function CreateUser(){
  const [fn, setFn] = useState("")
  const [ln, setLn] = useState("")
  const [un, setUn] = useState("")
  const [email, setEmail] = useState("")
  const [pw, setPw] = useState("")
  const createSU = async() => {
    try{
      const payload : AdminUserDataWithPw = {
        firstName : fn,
        lastName : ln,
        userName : un,
        email : email,
        password : pw
      }
      var res = await AdminService.CreateSuperUser(payload)
      window.location.reload();
    }catch(error){
      console.log("error")
    }
  }
  return(
    <>Create superUser
    <input type="input" placeholder="firstName" onChange={(e) => setFn(e.target.value)} />
    <input type="input" placeholder="lastName" onChange={(e) => setLn(e.target.value)} />
    <input type="input" placeholder="userName" onChange={(e) => setUn(e.target.value)} />
    <input type="input" placeholder="email" onChange={(e) => setEmail(e.target.value)} />
    <input type="input" placeholder="pasword" onChange={(e) => setPw(e.target.value)} />
    <button type="submit" onClick={createSU}>Create</button>
    </>
  )
}