// Faz a importação do axios
import axios from 'axios';

// Define a constate api para a chamada das requisições
export const api = axios.create({
  // Define a URL base para as requisições à API
  baseURL: 'http://1up-company.cf:5000/api',
});

export default api;