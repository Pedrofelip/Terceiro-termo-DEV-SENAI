import { Component } from 'react';
import axios from 'axios';
import { Link } from 'react-router-dom';
import { parseJwt } from '../../services/auth';

import './cadastro.css';
import gif from '../../img/OneUp2.gif';
import Botaop from "../../components/botaoP/botaoP";

export default class cadastro extends Component{
    constructor(props){
        super(props);
        this.state = {
            // nomeEstado : valorInicial
            nome : '',
            email : '',
            senha : '',
            permissao : '1'
        }
    }

    cadastrarLogista = (event) => {
        event.preventDefault();

        let novoLogista = {
            //chave como está na API : valor que será cadastrado
            nome        :   this.state.nome,
            email       :   this.state.email,
            senha       :   this.state.senha,
            permissao   :   this.state.permissao
        };

        axios.post('http://1up-company.cf:5000/api/varejista', novoLogista, {
            headers : {
                'Authorization' : 'Bearer ' + localStorage.getItem('usuario-login'),
                'Content-Type': 'application/json'
            }
        })

        .then(resposta => {
            if  (resposta.status === 201) {
                console.log('Novo cadastro concluido com sucesso!');

                if (parseJwt().role === "1") {
                    console.log(this.props)
                    this.props.history.push('/login')
                }
            }
        })

        .catch(erro => console.log(erro))
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
            <div className="geralc">
                <div className="ladoA">
                    <img src={gif} alt="logo da OneUp" />
                </div>
                <div className="ladoB">
                    <div className="titulo">
                        <h1>Cadastre-se!</h1>
                    </div>
                    <form onSubmit={this.cadastrarLogista}>
                        <div className="inputt">
                            <div className="input2">
                                <label>Nome</label>
                                <input type="text" name="nome" value={this.state.nome} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="input2">
                                <label>E-mail</label>
                                <input type="email" name="email" value={this.state.email} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="input2">
                                <label>Senha</label>
                                <input type="password" name="senha" value={this.state.senha} onChange={this.atualizaStateCampo} />
                            </div>
                        </div>
                        <div className="recaptcha">
                            {/* <h1>recaptcha</h1> */}
                            <script src="https://www.google.com/recaptcha/api.js?hl=pt-BR" async defer></script>
                            <div class="g-recaptcha" data-sitekey="6Lc-Q94cAAAAANueym3HhmxcAGR0DmBjm9Y4IxXo"></div>
                        </div>
                        <div className="botao">
                            <div className="btnText">
                                <p>Já possui uma conta? <Link to="/login">Faça seu login!</Link></p>
                                <p>É um representante ? Clique <Link to="/cadastroR">aqui</Link></p>
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