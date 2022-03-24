import React from 'react';
import ReactDOM from 'react-dom';
import { BrowserRouter as Router, Switch, Route, Redirect } from 'react-router-dom';

import { usuarioAutenticado , parseJwt } from './services/auth';

import './index.css';

import login from './pages/login/login';
import perfil from './pages/perfil/perfil';
import cadastroR from './pages/cadastroR/cadastroR';
import cadastro from './pages/cadastro/cadastro';
import agendamento from './pages/agendamento/agendamento';
import notFound from './pages/notFound/notFound';
import representantes from './pages/representantes/representantes';

const PermissaoAdm = ({ component : Component }) => (
  <Route 
    render = { props =>
      usuarioAutenticado() && parseJwt().role === "1" ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }
  />
)

const PermissaoLogado = ({ component : Component }) => (
  <Route 
    render = { props =>
      usuarioAutenticado() && (parseJwt().role === "1" || parseJwt().role === "2") ?
      <Component {...props} /> : 
      <Redirect to="/login" />
    }
  />
)

const routing = (
  <Router>
    <Switch>
      <Route exact path="/" component={login}/>
      <Route path="/login" component={login} />
      <Route path="/cadastro" component={cadastro} />
      {/* <PermissaoLogado path="/perfil" component={perfil} /> */}
      <Route path="/perfil" component={perfil} />
      <Route path="/cadastroR" component={cadastroR} />
      {/* <PermissaoLogado path="/agendamento" component={agendamento} /> */}
      <Route path="/agendamento" component={agendamento} />
      {/* <PermissaoAdm path="/representantes" component={representantes} /> */}
      <Route path="/representantes" component={representantes} />
      <Route exact path="/notFound" component={notFound} />
      <Redirect to="/notFound" />
    </Switch>
  </Router>
);

// var Recaptcha = require ( 'react-recaptcha' );

ReactDOM.render(routing, document.getElementById('root')

// ,<Recaptcha 
//     sitekey = "6Lc-Q94cAAAAANueym3HhmxcAGR0DmBjm9Y4IxXo"
//   />,
//   document.getElementById('recaptcha')

);