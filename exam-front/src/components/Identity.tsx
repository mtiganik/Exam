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
      </div>
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/homeworkss" className="nav-link text-dark">Homeworks</Link>
      </div>
      <div className="nav-item"style={{marginLeft:"10px"}}>
        <Link href="/my-subjects" className="nav-link text-dark"> My Subjects</Link>
      </div>

      <div className="nav-item">
        <Link href="/" onClick={(e) => doLogout()} className="nav-link text-dark">Logout</Link>
      </div>
    </div>
  )
}

const LoggedOut = () => {

  return (
    <li className="nav-item">
            <Link href="/login" className="nav-link text-dark" >Login</Link>
        </li>

  )
}