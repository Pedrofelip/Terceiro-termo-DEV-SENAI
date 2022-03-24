import { Component } from "react";
import axios from "axios";
import api from "../../services/api";

import Header from "../../components/cabecalho/cabecalho";
import Botaop from "../../components/botaoP/botaoP";
import './agendamento.css';
import { Router as router } from "react-router";

export default class agendamento extends Component{
    constructor(props){
        super(props);
        this.state = {
            marca : '',
            nome : '',
            link : '',
            produto : '',
            data : new Date(),
            hora : '',
            arquivo : '',
            presenca : '',
            listaRepresentantes : []
        };
    };

    // cadastrarAgendamento = (event) => {
    //     event.preventDefault();

    //     let novoAgendamento = {
    //         //chave como está na API : valor que será cadastrado
    //         marca           :   this.state.marca,
    //         nome            :   this.state.nome,
    //         link            :   this.state.link,
    //         produto         :   this.state.produto,
    //         data            :   this.state.data,
    //         hora            :   this.state.hora,
    //         arquivo         :   this.state.arquivo
    //     };

    //     axios.post('http://1up-company.cf:5000/api/Agendamento', novoAgendamento, {
    //         headers : {
    //             'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login')
    //         }
    //     })

    //     .then(resposta => {
    //         if  (resposta.status === 201) {
    //             console.log('Agendado com sucesso!');
    //         }
    //     })

    //     .catch(erro => console.log(erro))

    //     .then(this.buscarAgendamento);
    // };


    cadastrarAgendamentoFormData = (event) => {
        event.preventDefault();

        const fd = new FormData();

        fd.append('arquivo', this.state.arquivo, this.state.arquivo.name);
        fd.append('marca', this.state.marca);
        fd.append('nome', this.state.nome);
        fd.append('link', this.state.link);
        fd.append('produto', this.state.produto);
        fd.append('data', this.state.data);
        fd.append('hora', this.state.hora);

        try {
            const { status } = async() => await api.post('api/Agendamento', fd);
            
            if (status === 200) {
                //toggleRegisterManagerModal();
                router.push(router.pathname);
            }
        }

        catch (error) {
            throw new Error(error.message)
        }
    };

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

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
                <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
                <Header />
                <div className="tituloA">
                    <h1>Novo agendamento</h1>
                </div>
                <form className="areaForm" onSubmit={this.cadastrarAgendamentoFormData}>
                    <div className="aInputs">
                        <div className="inputsE">
                            <div className="inputsA">
                                <label>Marca</label>
                                <select name="marca" value={this.state.marca} onChange={this.atualizaStateCampo}>
                                    <option value="0">Selecione a marca</option>
                                    {
                                        this.state.listaRepresentantes.map( representantes => {
                                            return(
                                                <option key={representantes.idRepresentante} value={representantes.idRepresentante}>
                                                    {representantes.marca}
                                                </option>
                                            );
                                        })
                                    }
                                </select>
                            </div>
                            <div className="inputsA">
                                <label>Representante</label>
                                <select name="representante" value={this.state.nome} onChange={this.atualizaStateCampo}>
                                    <option value="0">Selecione o representante</option>
                                    {
                                        this.state.listaRepresentantes.map( representantes => {
                                            return(
                                                <option key={representantes.idRepresentante} value={representantes.idRepresentante}>
                                                    {representantes.nome}
                                                </option>
                                            );
                                        })
                                    }
                                </select>
                            </div>
                            <div className="inputsA">
                                <label>Link da reunião</label>
                                <input type="url" name="link" value={this.state.link} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="inputsA">
                                <label>Produto</label>
                                <input type="text" name="produto" value={this.state.produto} onChange={this.atualizaStateCampo} />
                            </div>
                        </div>
                        <div className="inputsD">
                            <div className="inputsA">
                                <label>Data</label>
                                <input type="date" name="data" value={this.state.data} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="inputsA">
                                <label>Hora</label>
                                <input type="time" name="hora" value={this.state.hora} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="inputsAA">
                                <p>Arquivo</p>
                                <label for="arquivo">
                                    <span className="span1">{this.state.arquivo}</span>
                                    <span className="span2">Buscar</span>
                                </label>
                                <input type="file" id="arquivo" name="arquivo" value={this.state.arquivo} onChange={this.atualizaStateCampo} />
                            </div>
                        </div>
                    </div>
                    <div className="aBtn">
                        <div className="eBtn">
                            <div className="btnPosition">
                                <Botaop />
                            </div>
                        </div>
                    </div>
                </form>
            </body>
        )
    }
}