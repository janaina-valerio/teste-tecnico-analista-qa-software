import axios from 'axios';

const api = axios.create({
  baseURL: 'http://localhost:5000/api/v1'
});

// Pessoas
export const getPessoas = () => api.get('/Pessoas');
export const createPessoa = (data) => api.post('/Pessoas', data);

// Categorias
export const getCategorias = () => api.get('/Categorias');
export const createCategoria = (data) => api.post('/Categorias', data);

// Transações
export const getTransacoes = () => api.get('/Transacoes');
export const createTransacao = (data) => api.post('/Transacoes', data);

// Totais
export const getTotaisPorPessoa = (params) => api.get('/Totais/pessoas', { params });
export const getTotaisPorCategoria = (params) => api.get('/Totais/categorias', { params });
