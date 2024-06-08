"use client"
import { useState } from "react"
import SuService from "@/services/suService";
import LoadingImg from "@/assets/loading/loading-50.gif"
import Image from "next/image";

export default function AddItems(){
  const [items, setItems] = useState("")
  const [isLoading, setIsLoading] = useState(false)
  const [result, setResult] = useState("")
  const handleAdd = async() => {
    setIsLoading(true)
    const data = items.split(",")
    const res = SuService.AddItems(data)
    setResult(JSON.stringify(res))
    setIsLoading(false)
  }
  return(
    <>
    <p>Add items</p>
    <input type="text" placeholder="items, separate by comma" onChange={(e) => setItems(e.target.value)}/>
    {isLoading && (<Image src={LoadingImg} priority={true} alt="loading" />)}
    <button type="submit" onClick={handleAdd}>Add</button>
    <div>{result}</div>
    </>
  )
}