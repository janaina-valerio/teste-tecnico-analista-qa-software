# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: categorias.spec.ts >> Categorias >> Criar categoria de receita
- Location: categorias.spec.ts:9:7

# Error details

```
Error: expect(locator).toBeVisible() failed

Locator: getByRole('row').filter({ hasText: 'Empréstimo' })
Expected: visible
Timeout: 5000ms
Error: element(s) not found

Call log:
  - Expect "toBeVisible" with timeout 5000ms
  - waiting for getByRole('row').filter({ hasText: 'Empréstimo' })

```

# Page snapshot

```yaml
- generic [ref=e3]:
  - banner [ref=e4]:
    - generic [ref=e5]:
      - generic [ref=e8]:
        - generic [ref=e9]: Minhas Finanças
        - generic [ref=e10]: Gerencie seu dinheiro
      - navigation "Main navigation" [ref=e11]:
        - link "Dashboard" [ref=e12] [cursor=pointer]:
          - /url: /
        - link "Transações" [ref=e13] [cursor=pointer]:
          - /url: /transacoes
        - link "Categorias" [ref=e14] [cursor=pointer]:
          - /url: /categorias
        - link "Relatórios" [ref=e15] [cursor=pointer]:
          - /url: /totais
    - navigation "breadcrumb" [ref=e18]:
      - list [ref=e19]:
        - listitem [ref=e20]:
          - link "Home" [ref=e21] [cursor=pointer]:
            - /url: /
        - listitem [ref=e22]:
          - generic [ref=e23]: /
          - link "Categorias" [ref=e24] [cursor=pointer]:
            - /url: /categorias
  - generic [ref=e25]:
    - complementary [ref=e26]:
      - navigation [ref=e27]:
        - list [ref=e28]:
          - listitem [ref=e29]:
            - link "Dashboard" [ref=e30] [cursor=pointer]:
              - /url: /
          - listitem [ref=e31]:
            - link "Transações" [ref=e32] [cursor=pointer]:
              - /url: /transacoes
          - listitem [ref=e33]:
            - link "Categorias" [ref=e34] [cursor=pointer]:
              - /url: /categorias
          - listitem [ref=e35]:
            - link "Pessoas" [ref=e36] [cursor=pointer]:
              - /url: /pessoas
          - listitem [ref=e37]:
            - link "Relatórios" [ref=e38] [cursor=pointer]:
              - /url: /totais
    - main [ref=e39]:
      - generic [ref=e40]:
        - generic [ref=e41]:
          - heading "Categorias" [level=1] [ref=e42]
          - button "Adicionar Categoria" [active] [ref=e43] [cursor=pointer]
        - generic [ref=e44]:
          - table "Tabela de dados" [ref=e45]:
            - rowgroup [ref=e46]:
              - row "Descrição Finalidade" [ref=e47]:
                - columnheader "Descrição" [ref=e48]
                - columnheader "Finalidade" [ref=e49]
            - rowgroup [ref=e50]:
              - row "123 Despesa" [ref=e51]:
                - cell "123" [ref=e52]
                - cell "Despesa" [ref=e53]
              - row "Alimentação Despesa" [ref=e54]:
                - cell "Alimentação" [ref=e55]
                - cell "Despesa" [ref=e56]
              - row "Aluguel Despesa" [ref=e57]:
                - cell "Aluguel" [ref=e58]
                - cell "Despesa" [ref=e59]
              - row "Aluguel Despesa" [ref=e60]:
                - cell "Aluguel" [ref=e61]
                - cell "Despesa" [ref=e62]
              - row "Aluguel Despesa" [ref=e63]:
                - cell "Aluguel" [ref=e64]
                - cell "Despesa" [ref=e65]
              - row "Aluguel Despesa" [ref=e66]:
                - cell "Aluguel" [ref=e67]
                - cell "Despesa" [ref=e68]
              - row "Aluguel Despesa" [ref=e69]:
                - cell "Aluguel" [ref=e70]
                - cell "Despesa" [ref=e71]
              - row "Aluguel Despesa" [ref=e72]:
                - cell "Aluguel" [ref=e73]
                - cell "Despesa" [ref=e74]
          - generic [ref=e77]:
            - generic [ref=e78]: Mostrando 1 - 8 de 100
            - generic [ref=e79]:
              - button "Anterior" [disabled] [ref=e80] [cursor=pointer]
              - button "1" [ref=e81] [cursor=pointer]
              - button "2" [ref=e82] [cursor=pointer]
              - button "3" [ref=e83] [cursor=pointer]
              - button "Próximo" [ref=e84] [cursor=pointer]
```

# Test source

```ts
  1  | import { test, expect } from '@playwright/test';
  2  | import { criarCategoria } from './actions';
  3  | 
  4  | test.describe('Categorias', () => {
  5  |   test.beforeEach(async ({ page }) => {
  6  |     await page.goto('http://localhost:5173');
  7  |   });
  8  | 
  9  |   test('Criar categoria de receita', async ({ page }) => {
  10 |     await criarCategoria(page, 'Empréstimo', 'Receita');
  11 |     const categoriaRow = page.getByRole('row').filter({ hasText: 'Empréstimo' });
> 12 |     await expect(categoriaRow).toBeVisible();
     |                                ^ Error: expect(locator).toBeVisible() failed
  13 |   });
  14 | 
  15 |   test('Criar categoria de despesa', async ({ page }) => {
  16 |     await criarCategoria(page, 'Plano de Saúde', 'Despesa');
  17 |     const categoriaRow = page.getByRole('row').filter({ hasText: 'Plano de Saúde' });
  18 |     await expect(categoriaRow).toBeVisible();
  19 |   });
  20 | });
  21 | 
```