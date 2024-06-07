"use client"
// import { IUserContext, UserContext } from "@/state/UserContext";
import { IUserContext, UserContext } from "@/state/UserContext";
import { useState, useContext } from "react";
import Hello from "./hello";
import Companies from "./user/companies";
const Admin = () => {
  const [hello, setHello] = useState();
  const { userData } = useContext(UserContext) as IUserContext;
  //const {userData, setUserData} = useContext(UserContext)!;

  if(!userData?.role.includes("admin")) return (<p>Not authorized</p>)
  return(
    <>
    <p>Admin page</p>
    <div className="container row">
      <div className="col-md-6">
      <Companies />
      </div>
      <div className="col-md-6">
      <Hello />
      </div>
    </div>
    </>
  )
}

export default Admin