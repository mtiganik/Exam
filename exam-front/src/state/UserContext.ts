"use client"

import { createContext } from "react";
import { JwtResponse } from "@/domain/JwtResponse";

export interface IUserContext{
  userData: JwtResponse | null;
  setUserData: (userData: JwtResponse | null) => void;
}

export const UserContext = createContext<IUserContext | null>(null)


