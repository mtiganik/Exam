"use client"
import { useState, useEffect } from "react"
import { HwData } from "@/domain/HwData"
import { FrontPageData } from "@/domain/frontPageData"
import StudentService from "@/services/StudentService"
import Image from "next/image"
import LoadingImd from "@/assets/loading/loading-50.gif"

export default function Home(){
  const [isLoading, setIsLoading] = useState(true)
  const [hws, setHws] = useState<HwData[]>([])
  const [subs, setSubs] = useState<FrontPageData[]>([])

  const loadData = async() => {
    try{
      const subRes = await StudentService.getStudentSubjects();
      const hwRes = await StudentService.getStudentHWs();
      console.log(subRes)
      console.log(hwRes)
      setSubs(subRes)
      setHws(hwRes)
      setIsLoading(false)
    }catch(error){
      console.error(error)
    }
  }

  useEffect(() => {
    loadData()
  },[])
  if(isLoading) return (<Image priority={true} src={LoadingImd} alt="loading"/>)
  
    return(
      <>
      <h3>homeWorks</h3>
      {hws && (
        hws.map((hw) => (
          <div key={hw.Title}>
            <div>{hw.Description}</div>
            <div>Subject: {hw.SubjectName}</div>
            <div>Done: {formatDate(hw.DateDone)}</div>
            <div>DL: {formatDate(hw.Deadline)}</div>
            <div>Grade: {hw.GradeAsString}</div>
          </div>
        ))
      )}

      <h3>My Subjects</h3>
      {subs.length > 0 ? (
        subs.map((sub) => (
          <div key={sub.Title} className="container">
            <h6>{sub.Title}</h6>
            <div>Description: {sub.Description}</div>
            <div>Students: {sub.StudentsCnt}</div>
            <div>Teacher: {sub.Teacher}</div>
          </div>
        ))
      ) : (
        <div>No subjects available</div>
      )}
      
      </>
    )
}


function formatDate(inputDate:string) {
  const date = new Date(inputDate);
  
  // Extract the day, month, and year
  const day = String(date.getUTCDate()).padStart(2, '0');
  const month = String(date.getUTCMonth() + 1).padStart(2, '0'); // Months are 0-based, so add 1
  const year = date.getUTCFullYear();

  // Format and return the date as dd:mm:yyyy
  return `${day}:${month}:${year}`;
}