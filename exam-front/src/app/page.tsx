"use client"
import { useState, useEffect } from "react";
import { FrontPageData } from "@/domain/frontPageData";
import LoadingImd from "@/assets/loading/loading-50.gif"
import FrontPageService from "@/services/frontPageService";
import Image from "next/image";
export default function Home() {
  const [subs, setSubs] = useState<FrontPageData[] | null>();
  const [isLoading, setIsLoading] = useState(true)
  
  const loadData = async() => {
    try{
      const res = await FrontPageService.GetFrontPageSubs();
      setSubs(res);
      setIsLoading(false)
    }catch(error){
      console.error(error)
    }
  }

  useEffect(() => {
    loadData();
  } ,[])
  if(isLoading) return(<Image src={LoadingImd} priority={true} alt="loading"/>) 

  return (
    <div>
      <h5> Available Subjects</h5>
      {subs && (
        <>
        {subs.map((sub) => (
          <div className="container" key={sub.Title}>
            <h6>{sub.Title}</h6>
            <div>Description: {sub.Description}</div>
            <div>Students: {sub.StudentsCnt}</div>
            <div>Teacher: {sub.Teacher}</div>

          </div>
        ))}
        </>
      )}
    </div>

);
}
