# Bugs Encontrados

Documentação dos problemas identificados durante a execução dos testes.

## Bugs Críticos

### 1. Ausência de exclusão em cascata ao deletar Pessoa
**Regra de Negócio**: "Exclusão em cascata de transações ao excluir pessoa"  
**Status**: ❌ Não implementado  
**Localização**: `MinhasFinancasDbContext.OnModelCreating()`  
**Impacto**: Ao excluir uma pessoa, as transações ficam órfãs no banco.  
**Sugestão**: Adicionar `.OnDelete(DeleteBehavior.Cascade)` no relacionamento.

---

### 2. Validação de menor de idade só ocorre no backend
**Regra de Negócio**: Menor de 18 anos não pode ter receitas  
**Status**: ⚠️ Parcialmente implementado  
**Problema**: O frontend permite selecionar uma pessoa menor e tipo "Receita" sem bloqueio visual. Só falha após salvar (erro 400).  
**Melhoria**: Adicionar validação reativa no formulário de transação.

---

## Bugs Médios

### 3. Mensagens de erro pouco amigáveis no frontend
**Problema**: Usuário vê "Ocorreu um erro interno no servidor" ou mensagens técnicas.  
**Exemplo**: Ao tentar cadastrar receita para menor.  
**Impacto**: Experiência ruim do usuário.

### 4. Categoria permite combinação inválida no frontend
**Problema**: É possível escolher uma categoria de "Despesa" e tentar cadastrar uma "Receita" sem aviso prévio.  
**Local**: Formulário de Transação.

### 5. Falta de feedback visual claro nos formulários
Não há desabilitação de campos ou mensagens preventivas antes de salvar.

---

## Observações Gerais

- As regras de negócio estão bem implementadas **no backend** (domínio).
- O frontend ainda está "burro" em relação às regras (não faz validação preventiva).
- Nenhum bug impede o funcionamento básico, mas compromete a experiência e integridade dos dados.

Data: 19/04/2026  
Testador: Janaína