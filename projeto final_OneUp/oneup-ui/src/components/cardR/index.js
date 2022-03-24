import React from "react";

// import lixo from "../../img/lixo.svg";

export default function CardR({ nome, email, celular, marca }){
    return(
        <div className="cardR">
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
            <div className="areaInf">
                <p>{nome}</p>
                <p>{email}</p>
                <p>{celular}</p>
                <p>{marca}</p>
            </div>
        </div>
    );
}