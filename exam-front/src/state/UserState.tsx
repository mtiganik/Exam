"use client"
import { JwtResponse } from "@/domain/JwtResponse";
import React, {createContext, useContext, useState, useEffect, Children} from "react";
import { UserContext } from "./UserContext";
import LoadingImage from "@/assets/logo/kah-spinning-2.gif";
import Image from "next/image";


export const UserState = ({children}:Readonly<{children: React.ReactNode}>) => {
  
  const [userData, setUserData] = useState<JwtResponse | null>(null);
  const [isInitialized, setIsInitialized] = useState(false);

  useEffect(() => {
    const storedUserData = localStorage.getItem("userData");
    if(storedUserData){
      setUserData(JSON.parse(storedUserData))
    }
    setIsInitialized(true);
  },[]);

  useEffect(() => {
    // Update local storage when user data changes
    if(userData){
      localStorage.setItem('userData', JSON.stringify(userData));
    }
  }, [userData]);

  if(!isInitialized){
    return( <Image src={LoadingImage} priority={true} alt="Tutvumisportaal Kähkukas" />) 
  }
  return(
    <UserContext.Provider value={{userData, setUserData}}>
      {children}
    </UserContext.Provider>
  )
}


export const GetUserDataFromLDb = (): JwtResponse | null => {
  const userDataString = localStorage.getItem("userData");
  if (!userDataString) {
    return null;
  }
  try {
    const userData: JwtResponse = JSON.parse(userDataString);
    return userData;
  } catch (error) {
    console.error("Error parsing user data:", error);
    return null;
  }
};
