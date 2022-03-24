import React from "react";
import { Link } from "react-router-dom";
import { sair } from "../../services/auth";

import "./styles.css";
import logo from "../../img/OneUp3.png"

export default function Header(){
    return(
        <div className="cabecalho">
            <div className="ca">
                <Link to="/perfil"> <img src={logo} alt="logo da OneUp" /> </Link>
            </div>
            <div className="cb">
                <button className="btnHeader" onClick={sair}><p>SAIR</p></button>
            </div>
        </div>
    );
}