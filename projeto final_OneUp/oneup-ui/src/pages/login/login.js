import { Component } from "react";
import axios from 'axios';
import { parseJwt, usuarioAutenticado } from '../../services/auth';
import { Link, useHistory } from "react-router-dom";

import gif from '../../img/OneUp2.gif';
// import img from '../../img/OneUp1.png';
import './login.css';
import Botaop from "../../components/botaoP/botaoP";

export default class login extends Component{
    constructor(props){
        super(props);
        this.state = {
            email : '',
            senha : ''
        }
    }

    efetuaLogin = (event) => {

        event.preventDefault();
        
        axios.post('http://1up-company.cf:5000/api/loginVarejista', {
            //chave como está na API
            email : this.state.email,
            senha : this.state.senha
        }, {
            headers : {
                'Content-Type' : 'application/json'
            }
        })
        
        .then(resposta => {
            // console.log('usuario-login');
            if  (resposta.status === 200) {
                localStorage.setItem('usuario-login', resposta.data.token) 
                console.log('Meu token é: ' + resposta.data.token)
                
                // Define a variável base64 que vai receber o payload do token
                let base64 = localStorage.getItem('usuario-login').split('.')[1];
                // Exibe no console o valor presente na variável base64
                console.log(base64);
                // Exibe no console o valor convertido de base64 para string
                console.log(window.atob(base64));
                // Exibe no console o valor convertido da string para JSON
                console.log(JSON.parse(window.atob(base64)));

                // Exibe no console apenas o tipo de usuário logado
                console.log(parseJwt().role);

                if  (parseJwt().role === "1") {
                    console.log(this.props);
                    this.props.history.push('/perfil')
                    console.log('estou logado: ' + usuarioAutenticado());
                }

                else  {
                    // this.props.history.push('/perfil')
                    useHistory.push('/perfil')
                }
            }
        })

        .catch(erro => console.log(erro));
    };

    atualizaStateCampo = (campo) => {
        this.setState({ [campo.target.name] : campo.target.value })
    };

    render(){
        return(
            <body>
            <link href='https://fonts.googleapis.com/css?family=Poppins' rel='stylesheet' />
            <div className="gerall">
                <script src="https://www.google.com/recaptcha/api.js?hl=pt-BR" async defer></script>
                <div className="ladoE">
                    <img src={gif} alt="logo da OneUp" />
                </div>
                <div className="ladoD">
                    <div className="titulol">
                        <h1>Faça seu login!</h1>
                    </div>
                    <form onSubmit={this.efetuaLogin}>
                        <div className="input">
                            <div className="input1">
                                <label>E-mail</label>
                                <input type="email" name="email" value={this.state.email} onChange={this.atualizaStateCampo} />
                            </div>
                            <div className="input1">
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
                                <p>Ainda não possui uma conta?</p>
                                <Link to="/cadastro">Cadastre-se já!</Link>
                            </div>
                            <Botaop />
                        </div>
                    </form>
                </div>
            </div>
            </body>
        )
    }
}