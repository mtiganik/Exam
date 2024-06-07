import { useState, useContext } from "react";
import Link from "next/link";
import { UserContext } from "@/state/UserContext";

export default function Identity() {
  const {userData, setUserData} = useContext(UserContext)!;
  return userData ? <LoggedIn /> : <LoggedOut/>;

}

const LoggedIn = () => {
  const { userData, setUserData } = useContext(UserContext)!;
  const doLogout = () => {
    setUserData(null);
    localStorage.removeItem("userData");
  }
  return (
    <div className="navbar">
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/" className="nav-link text-dark" > {userData?.userName}</Link>
      </div> |
      {userData?.role.includes("admin") && (
        <>
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/admin" className="nav-link text-dark">Admin</Link>
      </div>|</>
      )}
      {(userData?.role.includes("admin") || userData?.role.includes("su")) && (
<>
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/su" className="nav-link text-dark"> SU</Link>
      </div>|</>
      )}
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/user" className="nav-link text-dark"> Company</Link>
      </div>|


      <div className="nav-item">
        <Link href="/" onClick={(e) => doLogout()} className="nav-link text-dark">Logout</Link>
      </div>
    </div>
  )
}

const LoggedOut = () => {

  return (
    <>
    <ul className="nav-item">
            <Link href="/login" className="nav-link text-dark" >Login</Link>
        </ul>
            <ul className="nav-item">
            <Link href="/register" className="nav-link text-dark" >Register</Link>
        </ul>
        </>

  )
}