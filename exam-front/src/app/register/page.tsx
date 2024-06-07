"use client"
import { useState,useContext } from "react"
import LoginService from "@/services/loginService";
import { UserContext, IUserContext } from "@/state/UserContext";
import { useRouter } from "next/navigation";

export default function Register() {
  const [userName, setUserName] = useState("")
  const [email,setEmail] = useState("");
  const [pw, setPw] = useState("");
  const [pwConfirm, setPwConfirm] = useState("")
  const router = useRouter();
  const [errors, setErrors] = useState("")
  const [companyId, setCompanyId] = useState("");
  const { userData, setUserData } = useContext(UserContext) as IUserContext;

  const handleRegister=async() => {
    setErrors("")
    if(pw != pwConfirm){
      setErrors("pw / confirm pw do not match")
      return;
    }
    try{
      const res = await LoginService.Register(userName,companyId,email,pw)
      setUserData(res)
      router.push("/user")

    }catch(error){
      console.log("error")
    }
  }
  return(
    <>
    <label>username</label>
    <input type="text" placeholder="userName" value={userName} onChange={(e) => setUserName(e.target.value)}></input>
    <br/>
    <label>email</label>
    <input type="text" placeholder="email" value={email} onChange={(e) => setEmail(e.target.value)}></input>
    <br/>
    <label>Company Id:</label>
    <input type="text" placeholder="add Id of company here" value={companyId} onChange={(e) => setCompanyId(e.target.value)}></input>
    <br/>

    <label>password</label>
    <input type="password" placeholder="pw" value={pw} onChange={(e) => setPw(e.target.value)}></input>
    <br/>
    <label>Confirm password</label>
    <input type="password" placeholder="confirm pw" value={pwConfirm} onChange={(e) => setPwConfirm(e.target.value)}></input>
    <br/>

    <button type="submit" onClick={handleRegister}>Register</button>
    <p className="text text-danger">{errors}</p>
    </>
  )
}
