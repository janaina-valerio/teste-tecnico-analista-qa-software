## Título no Jira: [Bug QA] - Minhas Finanças - Ausência de bloqueio no cadastro de pessoa já existente 

## 🐞 Descrição:  
O sistema permite cadastrar múltiplas vezes a mesma pessoa (mesmo nome e mesma data de nascimento). Isso gera registros duplicados na tabela de Pessoas.

## Passos para Reproduzir:
1. Acessar a tela -> Pessoas
2. Clicar em -> Adicionar Pessoa
3. Preencher com dados já cadastrados anteriormente (exemplo: Nome: “Maria Silva”, Data de Nascimento: “10/05/1990”)
4. Salvar o Cadastro
5. Repetir o processo com os mesmos dados
6. Ao repetir o processo o Sistema irá permitir o cadastro com os mesmos dados

## Resultado Obtido:
- O sistema aceita o cadastro duplicado, triplicado,quadruplicado e assim vai.. e insere novamente na tabela como se fosse um novo cadastro.

## ☑️ Resultado Esperado:
- O sistema deve validar se já existe uma pessoa com o mesmo nome e data de nascimento.
- Caso exista, deve impedir o cadastro e exibir mensagem de erro clara (exemplo: “Pessoa já cadastrada, utilize a função Editar”).

## ☢️ Alto Impacto:
- Alto risco de dados inconsistentes
- Possibilidade de registros duplicados/quadruplicados
- Dificuldade em relatórios e análises financeiras

## Status: ⛔ Reprovado 

## 💡 Sugestão de Melhoria:
- Implementar validação reativa no backend e frontend
- Exibir mensagem de erro ao tentar cadastrar pessoa duplicada
- Sugestão Opcional: 
1. Deixar o botão Editar mais chamativo e destacado.
2. Ou exibir um novo botão redirecionando para a edição do cadastro

--- 

- Data: 19/04/2026
- Demanda Original: Testes Minhas Finanças
- QA Responsável: Janaína Mayara Valério