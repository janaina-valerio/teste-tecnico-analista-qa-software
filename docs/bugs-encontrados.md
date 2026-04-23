## 🐞 Documentação Final dos Bugs - Minhas Finanças 2026

Documentação dos problemas identificados durante a execução dos testes.

## ☢️ CENÁRIOS DE ALTO IMPACTO

### 1. Ausência de exclusão em cascata ao deletar Pessoa
* **🗒️ Regra de Negócio:** "Exclusão em cascata de transações ao excluir pessoa"  
* **🎯 Status:** ❌ Não implementado, REPROVADO ⛔
* **📍 Localização:** `MinhasFinancas.Infrastructure/Data/MinhasFinancasDbContext.cs` → método `OnModelCreating`
* **Comportamento Atual:** Ao deletar a pessoa, as transações ficam órfãs no banco (violando integridade de dados).
* **⚠️ Impacto:** Alto risco de dados inconsistentes.  
* **☑️ Sugestão de Correção:**
```csharp
modelBuilder.Entity<Transacao>()
    .HasOne(t => t.Pessoa)
    .WithMany(p => p.Transacoes)
    .HasForeignKey(t => t.PessoaId)
    .OnDelete(DeleteBehavior.Cascade);
```
---
### 2. Ausência de bloqueio no Cadastro de Pessoa Já Cadastrada
* **👎 Comportamento Atual:** 
- Usuário abre o modal “Adicionar Pessoa”
- Preenche com dados já cadastrados anteriormente
- O sistema aceita e insere novamente na tabela

* **🗒️ Comportamento Esperado**: 
- O sistema deve validar se já existe uma pessoa com o mesmo nome e data de nascimento
- Caso exista, deve impedir o cadastro e exibir mensagem de erro clara (exemplo: “Pessoa já cadastrada”)
 
* **🎯 Status:** ⚠️ Comportamento inaceitável | REPROVADO ⛔

* **🐞 Problema:** 
- Atualmente, o sistema permite cadastrar múltiplas vezes a mesma pessoa (mesmo nome e mesma data de nascimento). 
- Isso gera registros duplicados na tabela de Pessoas.

* **⚠️ Impacto:** 
- Alto risco de dados inconsistentes
- Possibilidade de quadruplicação de registros
- Dificuldade em relatórios e análises financeira
 
* **💡 Melhoria:** 
- Implementar validação reativa no backend e frontend
- Exibir mensagem de erro ao tentar cadastrar pessoa duplicada
- Sugestão Opcional: permitir edição do registro existente em vez de novo cadastro

---

### 3. Validação de menor de idade só ocorre no Backend
* **🗒️ Regra de Negócio**: Menores de 18 anos não podem ter receitas.  
* **🎯 Status:** ⚠️ Parcialmente implementado  | REPROVADO ⛔
* **🐞 Problema:** O frontend permite selecionar uma pessoa menor e tipo "Receita" sem qualquer bloqueio visual ou validação preventiva. Só falha após salvar (erro 400).
* **⚠️ Impacto:** Péssima experência para o usuário.
* **💡 Melhoria:** Adicionar validação reativa no formulário de transação.

---

### 4. Durante o processo de Cadastro de Transações Sistema retorna erro generíco e salva o registo em branco
Realizada a aberto da issue -> **[Bug QA] Minhas Finanças – Relatórios exibem valores zerados e registros inválidos.**
* **Descrição:** Na tela Relatórios › Totais por Pessoa, aparecem registros inválidos (ex.: “123”, “aaa”) e duplicados, todos com valores zerados. Além disso, transações que não foram salvas com sucesso acabam sendo exibidas no relatório como se fossem válidas, mas com valores zerados.

* **👎 Comportamento Atual:**
- Registros inválidos e duplicados são exibidos.
- Totais aparecem como R$ 0,00 mesmo após cadastros.
- Transações não salvas são listadas no relatório.

* **🗒️ Comportamento Esperado:**
- Apenas registros válidos devem ser exibidos.
- Cada pessoa deve aparecer uma única vez, com valores corretos.
- Totais devem refletir transações realmente salvas.

* **⚠️ Impacto:**
- Alto risco de relatórios financeiros incorretos.
- Dificuldade em analisar dados reais.
- Perda de credibilidade do sistema.

**🎯 Status:** ⛔ Reprovado / Inaceitável

* **💡 Sugestão de Melhoria:**
1. Implementar validação para impedir cadastros inválidos.
2. Corrigir cálculo de totais para refletir apenas transações válidas.


## 5. Transações não listam pessoas recém‑cadastradas
Realizada a aberto da issue -> **[Bug QA] Pessoas recém‑cadastradas não aparecem no dropdown de transações.**
* **🗒️ Descrição:** Ao tentar criar uma transação, a pessoa cadastrada não aparece na lista de seleção.
* **⚠️ Impacto:** Usuário não consegue vincular transações a pessoas novas.
* **🎯 Status:** ⛔ Reprovado
* **💡 Sugestão:** Corrigir integração entre cadastro de pessoas e dropdown de transações.


## 6. Pessoas maiores de idade não exibidas
Realizada a aberto da issue -> **[Bug QA] Pessoas maiores de idade não aparecem na tabela.**
* **🗒️ Descrição:** Após cadastrar uma pessoa maior de idade (ex.: “Janaína Valério”), o registro não aparece.
* **⚠️ Impacto:** Fluxo de cadastro inválido, impossibilitando uso em transações.
* **🎯 Status:** ⛔ Reprovado
* **💡 Sugestão:** Corrigir persistência e exibição de registros.


## 7. Categorias não exibidas após cadastro
Realizada a aberto da issue ->  **[Bug QA] Categorias recém‑cadastradas não aparecem na tabela.**
* **🗒️ Descrição:** Após cadastrar uma categoria (ex.: “Empréstimo”, “Plano de Saúde”), ela não é exibida na lista.
* **⚠️ Impacto:** Usuário não consegue confirmar se o cadastro foi realizado.
* **🎯 Status:** ⛔ Reprovado
* **💡 Sugestão:** Corrigir persistência e atualização da tabela de categorias.

---

## ⚠️ FALHAS ENCONTRADAS 🚧

### 8. Mensagens de erro pouco amigáveis no Frontend
**🐞 Problema:** O usuário recebe mensagens técnicas ou genéricas como:
- "Ocorreu um erro interno no servidor". E mensagens cruas vindas do backend
* **🗒️ Exemplo:** Ao tentar cadastrar receita para menor de idade.
* **💡 Melhoria Sugerida:** Tratar erros no frontend e exibir mensagens claras em português.

### 9. Falta de Validação Preventiva nos Formulários
* **🐞 Problemas:**
1.Não há bloqueio/desabilitação do botão Salvar quando a combinação é inválida.
2.Não há feedback visual imediato (ex: vermelho no campo) ao selecionar categoria incompatível.


---

## ☑️ CONCLUSÃO DOS TESTES

- As regras de negócio estão bem implementadas no **Domínio ->  backend** .
- O frontend ainda está "burro" em relação às regras (não faz validação preventiva).
- A aplicação é funcional, mas apresenta gaps importantes de usabilidade e integridade de dados.

--- 

- Data da Documentação: 20/04/2026  
- Status dos Testes: REPROVADO ❌ | 🔁 Return to DEV 
- Data do retorno: 22/04/2026
- QA Responsável: Janaína Mayara Valério
