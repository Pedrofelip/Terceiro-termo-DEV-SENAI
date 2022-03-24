import { Component } from "react";
import Header from "../../components/cabecalho/cabecalho";
import CardR from "../../components/cardR/index";

import './representantes.css';
import lixo from "../../img/lixo.svg";
import axios from "axios";

export default class representantes extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaRepresentantes : []
        }
    }

    buscarRepresentantes = () => {
        axios('http://1up-company.cf:5000/api/representante', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type': 'application/json'
            }
        })
        .then(resposta => {
            if (resposta.status === 200) {
                this.setState({ listaRepresentantes : resposta.data })

                console.log(this.state.listaRepresentantes);
            }
        })
        .catch(erro => console.log(erro))
    };

    componentDidMount(){
        this.buscarRepresentantes();
    }

    excluirRepresentante = (representante) => {
        console.log('O representante será excluido');

        fetch('http://localhost:5000/api/representante/' + representante.idRepresentante,
        {
            method : 'DELETE',

            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type': 'application/json'
            }
        })

        .then(resposta => {
            if (resposta.status === 204) {
                console.log('Representante ' + representante.idRepresentante + 'excluído!')
            };
        })

        .catch(erro => console.log(erro))

        .then(this.buscarRepresentantes)
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
                <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
                <Header />
                <div className="tituloR">
                    <h1>Representantes</h1>
                </div>
                <div className="espaço representante">
                    {this.state.listaRepresentantes.map( rp => {
                        return(
                            <div className="flexR">
                                <CardR
                                    key={rp.idRepresentante}
                                    nome={rp.nome}
                                    email={rp.email}
                                    celular={rp.contato}
                                    marca={rp.marca}
                                />
                                <div className="areaBtnr">
                                    <button className="btnLixo" type="button" onClick={this.excluirRepresentante}> <img src={lixo} alt="lixo" /> </button>
                                </div>
                            </div>
                        );
                    })
                    }
                    <div className="flexR">
                        <div className="cardR">
                            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
                            <div className="areaInf">
                                <p>nome</p>
                                <p>email</p>
                                <p>celular</p>
                                <p>marca</p>
                            </div>
                        </div>
                        <div className="areaBtnr">
                            <button className="btnLixo" type="button" onClick={this.excluirRepresentante}> <img src={lixo} alt="lixo" /> </button>
                        </div>
                    </div>
                </div>
            </body>
        )
    }
}