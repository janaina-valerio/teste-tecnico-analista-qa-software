import React, { useEffect, useState } from 'react';
import { getTotaisPorPessoa, createTransacao } from './api';

function Totais() {
  const [totais, setTotais] = useState([]);

  useEffect(() => {
    // Buscar totais por pessoa ao carregar
    getTotaisPorPessoa().then(response => {
      setTotais(response.data.items);
    });
  }, []);

  const adicionarTransacao = () => {
    // Exemplo: criar uma transação vinculada a pessoa/categoria
    createTransacao({
      descricao: "Compra supermercado",
      valor: 150.00,
      categoriaId: "019db372-9694-7027-80af-1c36245918bf",
      pessoaId: "019db33c-9998-7f24-891c-08c8b1c3f5d1"
    }).then(() => {
      // Atualizar totais depois de criar transação
      getTotaisPorPessoa().then(res => setTotais(res.data.items));
    });
  };

  return (
    <div>
      <h1>Totais por Pessoa</h1>
      <ul>
        {totais.map(p => (
          <li key={p.pessoaId}>
            {p.nome} → Receitas: {p.totalReceitas} | Despesas: {p.totalDespesas} | Saldo: {p.saldo}
          </li>
        ))}
      </ul>
      <button onClick={adicionarTransacao}>Adicionar Transação</button>
    </div>
  );
}

export default Totais;
