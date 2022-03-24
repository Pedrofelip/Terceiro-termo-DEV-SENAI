import { Component } from "react";
import UIModal from '../../components/modal/index';

import "./perfil.css";
import Header from "../../components/cabecalho/cabecalho";
import CardA from "../../components/cardA";
import sim from "../../img/sim.svg";
import nao from "../../img/nao.svg";
import axios from "axios";

export default class perfil extends Component{
    constructor(props){
        super(props);
        this.state = {
            listaDeAgendamentos : [],
            listaDeSituacoes : [],
            listaDeArquivos : [],
            presenca : '',
            isModalOpen : false,
            btnCancela : 'Cancelado',
            btnConfirma : 'Confirmado'
        }
    }

    btnAgendamento = () => {
        window.location.href = "/agendamento";
    }

    btnRepresentante = () => {
        window.location.href = "/representantes";
    }

    buscarAgendamentos = () => {
        axios('http://1up-company.cf:5000/api/agendamento', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type' : 'application/json'
            }
        })

        .then(resposta => {
            if  (resposta.status === 200) {
                this.setState({ listaDeAgendamentos : resposta.data })

                console.log(this.state.listaDeAgendamentos)
            }
        })

        .catch(erro => console.log(erro));
    };

    // buscarSituacoes = () => {
    //     console.log('Esta função lista todas as presencas.');

    //     fetch('http://1up-company.cf:5000/api/presenca', {
    //         headers : {
    //             'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
    //             'Content-Type' : 'application/json'
    //         }
    //     })

    //     .then(resposta => {
    //         if (resposta.status !== 200) {
    //             throw Error();
    //         };

    //         return resposta.json();
    //     })

    //     .then(resposta => this.setState({ listaDeSituacoes : resposta }))

    //     .catch(erro => console.log(erro));
    // }

    buscarArquivos = () => {
        console.log('Esta função lista todas os arquivos');

        fetch('http://1up-company.cf:5000/api/arquivo', {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type' : 'application/json'
            }
        })

        .then(resposta => {
            if (resposta.status !== 200) {
                throw Error();
            };

            return resposta.json();
        })

        .then(resposta => this.setState({ listaDeArquivos : resposta }))

        .catch(erro => console.log(erro));
    }


    componentDidMount(){
        this.buscarAgendamentos();
        //this.buscarSituacoes();
        //this.buscarArquivos();
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
            <div className="geralP">
                <Header />
                <div className="tituloP">
                    <h1>Meus agendamentos</h1>
                </div>
                <div className="cardsArea">
                    {this.state.listaDeAgendamentos.map( ag => {
                        return(
                            <div className="flex">
                                <CardA onClick={() => this.setState({ isModalOpen : true })}
                                    key={ag.idAgendamento}
                                    marca={ag.marca}
                                    presenca={ag.presencas.situacao}
                                    nome={ag.idRepresentanteNavigation.nome}
                                    descricao={ag.descricao}
                                    data={ag.data}
                                    hora={ag.hora}
                                    link={ag.link}
                                />
                                <div className="presenca">
                                    <div className="espacoPresenca">
                                        <button id="buttonS" value={this.state.btnCancela} name="buttonS" className="btnNao" onClick={() => this.setState({ presenca : this.state.btnCancela })}>
                                            <img src={nao} alt="cancelado" />
                                        </button>
                                        <button id="buttonS" value={this.state.btnConfirma} name="buttonS" className="btnSim" onClick={() => this.setState({ presenca : this.state.btnConfirma })}>
                                            <img src={sim} alt="confirmado" />
                                        </button>
                                    </div>
                                </div>
                                <UIModal isOpen={this.state.isModalOpen}>
                                    <div className="modal-header">
                                        <button type="button" className="ui-modal__close-button" onClick={() => this.setState({ isModalOpen : false })}><p>X</p></button>
                                        <h2>{ag.marca}</h2>
                                    </div>
                                    <div className="modal-body">
                                        <h3>Link :</h3>
                                        <p>{ag.link}</p>
                                        <h3>Arquivos :</h3>
                                        <div>
                                            {ag.idArquivoNavigation.caminhoArquivo}
                                        </div>
                                    </div>
                                </UIModal>
                            </div>
                        );
                    })
                    }


                    <div className="flex">
                        <div className="espacoCard">
                            <button className="card" type="button" onClick={() => this.setState({ isModalOpen : true })}>
                                <div className="cima" for="buttonS">
                                    <h2>Marca</h2>
                                    <span for="buttonS" onChange={this.atualizaStateCampo}>{this.state.presenca}</span>
                                </div>
                                <div className="baixo">
                                    <div className="esquerda">
                                        <p>Nome</p>
                                        <p>Descrição</p>
                                    </div>
                                    <div className="direita">
                                        <p>Data</p>
                                        <p>Hora</p>
                                    </div>
                                </div>
                            </button>
                        </div>
                        <div className="presenca">
                            <div className="espacoPresenca">
                                <button id="buttonN" value={this.state.btnCancela} name="buttonN" className="btnNao" onClick={() => this.setState({ presenca : this.state.btnCancela })}>
                                    <img src={nao} alt="cancelado" />
                                </button>
                                <button id="buttonS" value={this.state.btnConfirma} name="buttonS" className="btnSim" onClick={() => this.setState({ presenca : this.state.btnConfirma })}>
                                    <img src={sim} alt="confirmado" />
                                </button>
                            </div>
                        </div>
                        <UIModal isOpen={this.state.isModalOpen}>
                            <div className="modal-header">
                                <button type="button" className="ui-modal__close-button" onClick={() => this.setState({ isModalOpen : false })}><p>X</p></button>
                                <h2>Marca</h2>
                            </div>
                            <div className="modal-body">
                                <h3>Link :</h3>
                                <p>www.meet.com/thg-dsf-o8i</p>
                                <h3>Arquivos :</h3>
                                <p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>
                            </div>
                        </UIModal>
                    </div>


                </div>
                <div className="areaBtn">
                    <div className="espacoBtn">
                        <div className="btnEsq">
                            <button className="btnG" type="button" onClick={this.btnAgendamento}>Novo agendamento</button>
                        </div>                            
                        <div className="btnDir">
                            <button className="btnG" type="button" onClick={this.btnRepresentante}>Representantes</button>
                        </div>
                    </div>
                </div>
            </div>
            </body>
        );
    }
}