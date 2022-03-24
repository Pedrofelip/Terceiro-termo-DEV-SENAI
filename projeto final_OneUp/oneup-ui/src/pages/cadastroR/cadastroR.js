import { Component } from "react";
import axios from 'axios';
import { parseJwt } from "../../services/auth";
import { Link } from "react-router-dom";

import gif from '../../img/OneUp2.gif';
import './cadastroR.css';
import Botaop from "../../components/botaoP/botaoP";

export default class cadastroR extends Component{
    constructor(props){
        super(props);
        this.state = {
            nome : '',
            email : '',
            celular : '',
            marca : '',
            senha : '',
            permissao : '2'
        }
    }

    cadastrarRepresentante = (event) => {
        event.preventDefault();

        let novoRepresentante = {
            //chave como está na API : valor que será cadastrado
            nome                : this.state.nome,
            email               : this.state.email,
            contato             : this.state.celular,
            marca               : this.state.marca,
            senha               : this.state.senha,
            permissao           : this.state.permissao
        };

        axios.post('http://1up-company.cf:5000/api/representante', novoRepresentante, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usario-login'),
                'Content-Type': 'application/json'
            }
        })

        .then(resposta => {
            if  (resposta.status === 201) {
                console.log('Novo representante cadastrado!')

                if (parseJwt().role === "2") {
                    console.log(this.props)
                    this.props.history.push('/login')
                }
            }
        })

        .catch(erro => console.log(erro))
    }

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
                <div className="geralr">
                <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
                    <div className="ladA">
                        <img src={gif} alt="logo da OneUp" />
                    </div>
                    <div className="ladB">
                        <form onSubmit={this.cadastrarRepresentante}>
                            <div className="titulo1">
                                <h1>Cadastre-se!</h1>
                            </div>
                            <div className="inpt">
                                <div className="input5">
                                    <label>Nome</label>
                                    <input type="text" name="nome" value={this.state.nome} onChange={this.atualizaStateCampo} />
                                </div>
                                <div className="input5">
                                    <label>E-mail</label>
                                    <input type="email" name="email" value={this.state.email} onChange={this.atualizaStateCampo} />
                                </div>
                                <div className="input5">
                                    <label>Celular</label>
                                    <input type="text" name="celular" value={this.state.celular} onChange={this.atualizaStateCampo} />
                                </div>
                                <div className="input5">
                                    <label>Marca</label>
                                    <input type="text" name="marca" value={this.state.marca} onChange={this.atualizaStateCampo} />
                                </div>
                                <div className="input5">
                                    <label>Senha</label>
                                    <input type="password" name="senha" value={this.state.senha} onChange={this.atualizaStateCampo} />
                                </div>
                            </div>
                            <div className="recaptchaR">
                                {/* <h1>recaptcha</h1> */}
                                <script src="https://www.google.com/recaptcha/api.js?hl=pt-BR" async defer></script>
                                <div class="g-recaptcha" data-sitekey="6Lc-Q94cAAAAANueym3HhmxcAGR0DmBjm9Y4IxXo"></div>
                            </div>
                            <div className="botao">
                                <div className="btnText">
                                    <p>Já possui uma conta? <Link to="/login">Faça seu login!</Link></p>
                                </div>
                                <Botaop />
                            </div>
                        </form>
                    </div>
                </div>
            </body>
        );
    }
}