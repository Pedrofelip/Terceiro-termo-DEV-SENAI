import React from "react";

import './styles.css';
// import nao from "../../img/nao.svg";
// import sim from "../../img/sim.svg";

export default function CardA({ marca, presenca, nome, descricao, data, hora }){
    return(
        <div className="espacoCard">
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
            <button className="card" type="button">
                <div className="cima">
                    <h2>{marca}</h2>
                    <span>{presenca}</span>
                </div>
                <div className="baixo">
                    <div className="esquerda">
                        <p>{nome}</p>
                        <p>{descricao}</p>
                    </div>
                    <div className="direita">
                        <p>{data}</p>
                        <p>{hora}</p>
                    </div>
                </div>
            </button>
        </div>
    );
}