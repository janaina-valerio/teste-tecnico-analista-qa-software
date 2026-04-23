## Título no Jira: [Bug QA] - Minhas Finanças -  Relatórios exibem valores zerados e registros inválidos

### 🐞 Descrição:  
Na tela Relatórios › Totais por Pessoa, são exibidos registros inválidos (ex.: “123”, “aaa”), todos com valores zerados. Isso compromete a confiabilidade dos relatórios.
Durante um Cadastro de uma transação que não foi salva com sucesso, o sistema registrou essa transação como válida no Relatório > Totais por Pessoa.

## Passos para Reproduzir:
1. Acessar a tela -> Transações
2. Clicar em -> Adicionar Transação
3. Preencher com dados -> (exemplo: Nome: “Eliane Valério”, Valor: "50.00" , Data: "01/01/2020", Tipo: "Despesa", Pessoa:"Eliane Valério", Categoria: "Aluguel")
4. Salvar o Cadastro
5. Sistema retornará uma mensagem de erro
6. Ao verificar na tela Relatórios -> Totais por Pessoa a transação que não foi salva aparecerá com os valores zerados.

## 💾 Evidência: 
[IMAGEM ANEXADA](docs/evidencias/erro-durante-o-cadastro-registrou-relatorios.png)

## Comportamento Atual:
- Registros com nomes inválidos (números ou strings de teste) são exibidos.
- Totais de receitas, despesas e saldo aparecem como R$ 0,00, mesmo após cadastros de transações.
- Quando o cadastro de uma transação não é finalizada como esperado, essa transação é exibida no Relatório 

## ☑️ Comportamento Esperado:
- Cada pessoa deve aparecer com o seu valor preenchido respectivo a sua transação no relatório.
- Apenas registros válidos devem ser exibidos.
- Totais devem refletir corretamente as transações associadas a cada pessoa.

## ☢️ Impacto:
- Alto risco de relatórios financeiros incorretos.
- Dificuldade em analisar dados reais.
- Perda de credibilidade do sistema.

## Status: ⛔ Reprovado / Inaceitável

## 💡 Sugestão de Melhoria:
1. Implementar validação para impedir cadastros com nomes inválidos.
2. Corrigir cálculo de totais para refletir transações reais.

--- 

- Data: 20/04/2026
- Demanda Original: Testes Minhas Finanças
- QA Responsável: Janaína Mayara Valério