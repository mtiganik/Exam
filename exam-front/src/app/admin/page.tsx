"use client"
// import { IUserContext, UserContext } from "@/state/UserContext";
import { IUserContext, UserContext } from "@/state/UserContext";
import { useState, useContext } from "react";
const Admin = () => {
  const [hello, setHello] = useState();
  const { userData } = useContext(UserContext) as IUserContext;
  //const {userData, setUserData} = useContext(UserContext)!;

  if(!userData?.role.includes("admin")) return (<p>Not authorized</p>)
  return(
    <>
    <p>Admin page</p>
    </>
  )
}

export default Admin