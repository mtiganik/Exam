"use client"
import { useState } from "react"
import SuService from "@/services/suService"
import LoadingImg from "@/assets/loading/loading-50.gif"
import Image from "next/image";

export default function ExecuteShuffle(){
  const [result, setResult] = useState("")
  const [isLoading, setIsLoading] = useState(false)
  const executeShuffle = async() => {
    setIsLoading(true)
    const result = await SuService.ExecuteSuffle();
    setResult(JSON.stringify(result))
    setIsLoading(false)

  }
  return(
    <>
    <button type="button" onClick={executeShuffle}>Execute Shuffle</button>
    {isLoading && (<Image src={LoadingImg} priority={true} alt="loading" />)}
    <div>{result}</div>
    </>
  )
}