"use client"
import { useState, useEffect } from "react";
import LoadingImd from "@/assets/loading/loading-50.gif"
import Image from "next/image";
import { baseUrl } from "@/services/baseUrl";
import axios from "axios";

export default function Home() {
  const [isLoading, setIsLoading] = useState(true);
  const [data, setData] = useState<string[]>([])
  const loadData = async() => {
    try{
      const res = await axios.get<string[]>(baseUrl + "api/FrontPage/frontPageGet")
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
      <h5>Available Subjects</h5>
      {data && (
        data.map((item) => (
          <div key={item}>{item}</div>
        ))
      )}
    </div>
  );
}
