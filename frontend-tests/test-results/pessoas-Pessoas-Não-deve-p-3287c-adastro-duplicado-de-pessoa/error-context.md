# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: pessoas.spec.ts >> Pessoas >> Não deve permitir cadastro duplicado de pessoa
- Location: pessoas.spec.ts:21:7

# Error details

```
Error: expect(locator).toBeVisible() failed

Locator: getByRole('alert').filter({ hasText: 'Pessoa já cadastrada' })
Expected: visible
Timeout: 5000ms
Error: element(s) not found

Call log:
  - Expect "toBeVisible" with timeout 5000ms
  - waiting for getByRole('alert').filter({ hasText: 'Pessoa já cadastrada' })

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
          - link "Pessoas" [ref=e24] [cursor=pointer]:
            - /url: /pessoas
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
          - heading "Pessoas" [level=1] [ref=e42]
          - button "Adicionar Pessoa" [active] [ref=e43] [cursor=pointer]
        - generic [ref=e44]:
          - table "Tabela de dados" [ref=e45]:
            - rowgroup [ref=e46]:
              - row "Nome Data de Nascimento Idade Ações" [ref=e47]:
                - columnheader "Nome" [ref=e48]
                - columnheader "Data de Nascimento" [ref=e49]
                - columnheader "Idade" [ref=e50]
                - columnheader "Ações" [ref=e51]
            - rowgroup [ref=e52]:
              - row "123 1/14/2026 0 Editar 019bf727-a20b-79ed-995d-272c71a8a78e Deletar 019bf727-a20b-79ed-995d-272c71a8a78e" [ref=e53]:
                - cell "123" [ref=e54]
                - cell "1/14/2026" [ref=e55]
                - cell "0" [ref=e56]
                - cell "Editar 019bf727-a20b-79ed-995d-272c71a8a78e Deletar 019bf727-a20b-79ed-995d-272c71a8a78e" [ref=e57]:
                  - button "Editar 019bf727-a20b-79ed-995d-272c71a8a78e" [ref=e58] [cursor=pointer]: Editar
                  - button "Deletar 019bf727-a20b-79ed-995d-272c71a8a78e" [ref=e59] [cursor=pointer]: Deletar
              - row "123 1/1/2016 10 Editar 019bf727-b8df-7b00-bd5e-d2a6afeb109e Deletar 019bf727-b8df-7b00-bd5e-d2a6afeb109e" [ref=e60]:
                - cell "123" [ref=e61]
                - cell "1/1/2016" [ref=e62]
                - cell "10" [ref=e63]
                - cell "Editar 019bf727-b8df-7b00-bd5e-d2a6afeb109e Deletar 019bf727-b8df-7b00-bd5e-d2a6afeb109e" [ref=e64]:
                  - button "Editar 019bf727-b8df-7b00-bd5e-d2a6afeb109e" [ref=e65] [cursor=pointer]: Editar
                  - button "Deletar 019bf727-b8df-7b00-bd5e-d2a6afeb109e" [ref=e66] [cursor=pointer]: Deletar
              - row "123 1/8/2026 0 Editar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9 Deletar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9" [ref=e67]:
                - cell "123" [ref=e68]
                - cell "1/8/2026" [ref=e69]
                - cell "0" [ref=e70]
                - cell "Editar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9 Deletar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9" [ref=e71]:
                  - button "Editar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9" [ref=e72] [cursor=pointer]: Editar
                  - button "Deletar 019bf727-cfbe-7a0a-9c1d-3e006ea19fe9" [ref=e73] [cursor=pointer]: Deletar
              - row "1234 12/29/2025 0 Editar 019bf727-8afd-7378-9ee4-b2ec92b1f28f Deletar 019bf727-8afd-7378-9ee4-b2ec92b1f28f" [ref=e74]:
                - cell "1234" [ref=e75]
                - cell "12/29/2025" [ref=e76]
                - cell "0" [ref=e77]
                - cell "Editar 019bf727-8afd-7378-9ee4-b2ec92b1f28f Deletar 019bf727-8afd-7378-9ee4-b2ec92b1f28f" [ref=e78]:
                  - button "Editar 019bf727-8afd-7378-9ee4-b2ec92b1f28f" [ref=e79] [cursor=pointer]: Editar
                  - button "Deletar 019bf727-8afd-7378-9ee4-b2ec92b1f28f" [ref=e80] [cursor=pointer]: Deletar
              - row "123a 12/29/2025 0 Editar 019bf773-ffcc-7991-a205-772fc2537c66 Deletar 019bf773-ffcc-7991-a205-772fc2537c66" [ref=e81]:
                - cell "123a" [ref=e82]
                - cell "12/29/2025" [ref=e83]
                - cell "0" [ref=e84]
                - cell "Editar 019bf773-ffcc-7991-a205-772fc2537c66 Deletar 019bf773-ffcc-7991-a205-772fc2537c66" [ref=e85]:
                  - button "Editar 019bf773-ffcc-7991-a205-772fc2537c66" [ref=e86] [cursor=pointer]: Editar
                  - button "Deletar 019bf773-ffcc-7991-a205-772fc2537c66" [ref=e87] [cursor=pointer]: Deletar
              - row "1321eq 12/30/2025 0 Editar 019bf773-c6d3-7969-8c20-8c8ac1a3372d Deletar 019bf773-c6d3-7969-8c20-8c8ac1a3372d" [ref=e88]:
                - cell "1321eq" [ref=e89]
                - cell "12/30/2025" [ref=e90]
                - cell "0" [ref=e91]
                - cell "Editar 019bf773-c6d3-7969-8c20-8c8ac1a3372d Deletar 019bf773-c6d3-7969-8c20-8c8ac1a3372d" [ref=e92]:
                  - button "Editar 019bf773-c6d3-7969-8c20-8c8ac1a3372d" [ref=e93] [cursor=pointer]: Editar
                  - button "Deletar 019bf773-c6d3-7969-8c20-8c8ac1a3372d" [ref=e94] [cursor=pointer]: Deletar
              - row "Bianca 4/12/1995 31 Editar 019db20e-33a6-7125-addb-7dd69c9a7544 Deletar 019db20e-33a6-7125-addb-7dd69c9a7544" [ref=e95]:
                - cell "Bianca" [ref=e96]
                - cell "4/12/1995" [ref=e97]
                - cell "31" [ref=e98]
                - cell "Editar 019db20e-33a6-7125-addb-7dd69c9a7544 Deletar 019db20e-33a6-7125-addb-7dd69c9a7544" [ref=e99]:
                  - button "Editar 019db20e-33a6-7125-addb-7dd69c9a7544" [ref=e100] [cursor=pointer]: Editar
                  - button "Deletar 019db20e-33a6-7125-addb-7dd69c9a7544" [ref=e101] [cursor=pointer]: Deletar
              - row "Bryan Mendes 1/10/2020 6 Editar 019db199-9f66-7e2d-9ab7-573b77b2016c Deletar 019db199-9f66-7e2d-9ab7-573b77b2016c" [ref=e102]:
                - cell "Bryan Mendes" [ref=e103]
                - cell "1/10/2020" [ref=e104]
                - cell "6" [ref=e105]
                - cell "Editar 019db199-9f66-7e2d-9ab7-573b77b2016c Deletar 019db199-9f66-7e2d-9ab7-573b77b2016c" [ref=e106]:
                  - button "Editar 019db199-9f66-7e2d-9ab7-573b77b2016c" [ref=e107] [cursor=pointer]: Editar
                  - button "Deletar 019db199-9f66-7e2d-9ab7-573b77b2016c" [ref=e108] [cursor=pointer]: Deletar
          - generic [ref=e111]:
            - generic [ref=e112]: Mostrando 1 - 8 de 121
            - generic [ref=e113]:
              - button "Anterior" [disabled] [ref=e114] [cursor=pointer]
              - button "1" [ref=e115] [cursor=pointer]
              - button "2" [ref=e116] [cursor=pointer]
              - button "3" [ref=e117] [cursor=pointer]
              - button "Próximo" [ref=e118] [cursor=pointer]
```

# Test source

```ts
  1  | import { test, expect } from '@playwright/test';
  2  | import { criarPessoa } from './actions';
  3  | 
  4  | test.describe('Pessoas', () => {
  5  |   test.beforeEach(async ({ page }) => {
  6  |     await page.goto('http://localhost:5173');
  7  |   });
  8  | 
  9  |   test('Criar pessoa menor de idade', async ({ page }) => {
  10 |     await criarPessoa(page, 'Bryan Mendes', '2020-01-10');
  11 |     const pessoaRow = page.getByRole('row').filter({ hasText: 'Bryan Mendes' });
  12 |     await expect(pessoaRow).toBeVisible();
  13 |   });
  14 | 
  15 |   test('Criar pessoa maior de idade', async ({ page }) => {
  16 |     await criarPessoa(page, 'Janaína Valério', '1995-08-09');
  17 |     const pessoaRow = page.getByRole('row').filter({ hasText: 'Janaína Valério' });
  18 |     await expect(pessoaRow).toBeVisible();
  19 |   });
  20 | 
  21 |   test('Não deve permitir cadastro duplicado de pessoa', async ({ page }) => {
  22 |     await criarPessoa(page, 'Victor Valério', '1998-03-16');
  23 |     await criarPessoa(page, 'Victor Valério', '1998-03-16');
  24 | 
  25 |     const alerta = page.getByRole('alert').filter({ hasText: 'Pessoa já cadastrada' });
> 26 |     await expect(alerta).toBeVisible();
     |                          ^ Error: expect(locator).toBeVisible() failed
  27 |   });
  28 | });
  29 | 
```