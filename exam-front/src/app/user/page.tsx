"use client"
import UserGetUsers from "@/domain/user/userGetUsers"
import UserService from "@/services/userService"
import { useEffect, useState } from "react"
import LoadingImg from "@/assets/loading/loading-50.gif"
import Image from "next/image"

export default function Home(){
  const [items, setItems] = useState<string[]>([])
  const [users, setUsers] = useState<UserGetUsers[]>([])
  const [isLoading,setIsLoading] = useState(true)
  const [logWork, setLogWork] = useState<number>(0)
  const [logLoading, setLogLoading] = useState(false)
  const [logRes, setLogResult] = useState<number|null>(null)
  const loadData = async() => {
    try{
      const cpyUsers = await UserService.GetCompanyUsers();
      const items = await UserService.GetYourItems();
      setItems(items)
      setUsers(cpyUsers)
      setIsLoading(false)
    }catch(error){
      console.error(error)
    }
  }

  const handleLogWorkChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    setLogWork(Number(e.target.value));
  }


  useEffect(() => {
    loadData();
  },[])

  const handleLogWork = async() => {
    try{
      setLogLoading(true)
      const res = await UserService.LogWork(logWork)
      console.log(res)
      setLogResult(res)
      setLogLoading(false)
    }catch(error){
      console.error(error)
    }
  }

  if (isLoading) {
    return <Image src={LoadingImg} priority={true} alt="loading" />;
  }

  return(
    <>
    <label>Log work</label>
    <input type="number" placeholder="Log work" value={logWork} onChange={handleLogWorkChange}></input>
    {logLoading && (<Image src={LoadingImg} priority={true} alt="loading" />)}
    <button type="submit" onClick={handleLogWork} >Log</button>
    {logRes && (
      <div>Work logged. You have logged total of {logRes} minutes</div>
    )}
    <br/>

      {items && (
        <>
        <h3>My items</h3>
        {items.map((item) => (
          <div key = {item}>{item}</div>
        ))}
        </>
      )}
      {users && (
        <>
        <h3>Users In this company</h3>
        {users.map((user)=> (
          <div key={user.userEmail}>{user.userName} {user.userEmail}</div>
        ))}
        </>
      )}
    </>
  )
}