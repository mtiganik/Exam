import Link from "next/link"
import Logo from "@/assets/logo/exam logo.png"
import Image from "next/image"
import Identity from "./Identity"
export default function Header () {

return(
  <>
        <header className="header">
            <nav className="navbar navbar-expand-sm navbar-toggleable-sm navbar-light  box-shadow mb-3">
                <div className="container">
                    <a className="navbar-brand" href="/">
                      <Image src={Logo} alt="logo" />
                    </a>
                        <Identity />
                </div>
            </nav>
        </header>
  </>
)
}