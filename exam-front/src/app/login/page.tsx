"use client"
import { useState,useContext } from "react"
import LoginService from "@/services/loginService";
import { UserContext, IUserContext } from "@/state/UserContext";
import { useRouter } from "next/navigation";
export default function Login() {
  const [email,setEmail] = useState("");
  const [pw, setPw] = useState("");
  const router = useRouter();

  const { userData, setUserData } = useContext(UserContext) as IUserContext;

  const handleLogin =async() =>{
    try{
      var res = await LoginService.Login(email,pw)
      console.log(res)
      setUserData(res)
      if(res.role.includes("admin")){
        router.push("/admin")
      }
      else if(res.role.includes("su")){
        router.push("/su")
      }else{
        router.push("/user")
      }

    }catch(error){
      console.log(error)
    }
  }
  return(
    <div>
      <label>Email</label>
      <input type="email" placeholder="email" onChange={(e) => setEmail(e.target.value)}></input>
      <br/>
      <label>Password</label>
      <input type="password" placeholder="password" onChange={(e) => setPw(e.target.value)}></input>
      <br/>
      <button className="btn btn-success" onClick={handleLogin}>Login</button>
    </div>
  )
}