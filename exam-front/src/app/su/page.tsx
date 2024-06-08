"use client"
import AddItems from "./add-items"
import ExecuteShuffle from "./execute-shuffle"
export default function Home() {

  return(
  <>
  <p>Super user page</p>
  <ExecuteShuffle/>
  <AddItems/>
  </>
  )
}