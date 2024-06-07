"use client"
import { useState, useEffect } from "react";
import LoadingImd from "@/assets/loading/loading-50.gif"
import Image from "next/image";
import { baseUrl } from "@/services/baseUrl";
import axios from "axios";
import FrontPageData from "@/domain/frontPageData";

export default function Home() {
  const [isLoading, setIsLoading] = useState(true);
  const [data, setData] = useState<FrontPageData[]>([])
  const loadData = async() => {
    try{
      const res = await axios.get<FrontPageData[]>(baseUrl + "api/FrontPage/frontPageGet")
      console.log(res)
      setData(res.data)
      setIsLoading(false)
    }catch(ex){
      console.error(ex)
    }
  }
  useEffect(() => {
    loadData();
  },[]);

  if (isLoading) {
    return <Image src={LoadingImd} priority={true} alt="loading" />;
  }

  return (
    <div>
      <h5>Public companies to Join:</h5>
      {data && (
        data.map((item) => (
          <div key={item.companyId}>{item.companyId} : {item.companyName}</div>
        ))
      )}
    </div>
  );
}
