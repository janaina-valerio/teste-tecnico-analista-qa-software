# Instructions

- Following Playwright test failed.
- Explain why, be concise, respect Playwright best practices.
- Provide a snippet of code with the fix, if possible.

# Test info

- Name: transacao.spec.ts >> Transações >> Criar transação com pessoa maior de idade
- Location: transacao.spec.ts:26:7

# Error details

```
Test timeout of 30000ms exceeded.
```

```
Error: locator.waitFor: Test timeout of 30000ms exceeded.
Call log:
  - waiting for getByRole('option', { name: 'Janaína Valério' }).first() to be visible

```

# Page snapshot

```yaml
- generic:
  - generic:
    - generic:
      - banner:
        - generic:
          - generic:
            - generic:
              - generic: Minhas Finanças
              - generic: Gerencie seu dinheiro
          - navigation:
            - link:
              - /url: /
              - text: Dashboard
            - link:
              - /url: /transacoes
              - text: Transações
            - link:
              - /url: /categorias
              - text: Categorias
            - link:
              - /url: /totais
              - text: Relatórios
        - generic:
          - generic:
            - navigation:
              - list:
                - listitem:
                  - link:
                    - /url: /
                    - text: Home
                - listitem:
                  - generic: /
                  - link:
                    - /url: /transacoes
                    - text: Transacoes
      - generic:
        - complementary:
          - navigation:
            - list:
              - listitem:
                - link:
                  - /url: /
                  - text: Dashboard
              - listitem:
                - link:
                  - /url: /transacoes
                  - text: Transações
              - listitem:
                - link:
                  - /url: /categorias
                  - text: Categorias
              - listitem:
                - link:
                  - /url: /pessoas
                  - text: Pessoas
              - listitem:
                - link:
                  - /url: /totais
                  - text: Relatórios
        - main:
          - generic:
            - generic:
              - heading [level=1]: Transações
              - button [expanded]: Adicionar Transação
            - generic:
              - table:
                - rowgroup:
                  - row:
                    - columnheader: Data
                    - columnheader: Descrição
                    - columnheader: Valor
                    - columnheader: Tipo
                    - columnheader: Categoria
                    - columnheader: Pessoa
                - rowgroup:
                  - row:
                    - cell: 21/04/2026
                    - cell: pix transporte
                    - cell: R$ 200,00
                    - cell: Despesa
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Unimed
                    - cell: R$ 780,00
                    - cell: Despesa
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
                  - row:
                    - cell: 20/04/2026
                    - cell: Dividendos
                    - cell: R$ 1.500,00
                    - cell: Receita
                    - cell
                    - cell
              - generic:
                - generic:
                  - generic:
                    - generic: Mostrando 1 - 8 de 13
                    - generic:
                      - button [disabled]: Anterior
                      - button: "1"
                      - button: "2"
                      - button: Próximo
  - dialog "Adicionar Transação" [ref=e2]:
    - heading "Adicionar Transação" [level=2] [ref=e4]
    - generic [ref=e5]:
      - generic [ref=e6]:
        - text: Descrição
        - textbox "Descrição" [ref=e7]:
          - /placeholder: Digite a descrição
          - text: Dividendos
      - generic [ref=e8]:
        - text: Valor
        - spinbutton "Valor" [ref=e9]: "1500"
      - generic [ref=e10]:
        - text: Data
        - textbox "Data" [ref=e11]: 2026-04-20
      - generic [ref=e13]:
        - text: Tipo
        - combobox "Tipo" [ref=e14]:
          - option "Despesa"
          - option "Receita" [selected]
      - generic [ref=e15]:
        - text: Pessoa
        - generic [ref=e16]:
          - generic [ref=e17]:
            - textbox "Lista de pessoas" [active] [ref=e18]:
              - /placeholder: Pesquisar pessoas...
            - button "Fechar lista" [expanded] [ref=e19] [cursor=pointer]: Fechar
          - listbox "Lista de pessoas" [ref=e20]:
            - option "123" [ref=e21] [cursor=pointer]
            - option "123" [ref=e22] [cursor=pointer]
            - option "123" [ref=e23] [cursor=pointer]
            - option "1234" [ref=e24] [cursor=pointer]
            - option "123a" [ref=e25] [cursor=pointer]
            - option "1321eq" [ref=e26] [cursor=pointer]
            - option "Bianca" [ref=e27] [cursor=pointer]
            - option "Bryan Mendes" [ref=e28] [cursor=pointer]
            - option "Bryan Mendes" [ref=e29] [cursor=pointer]
            - option "Bryan Mendes" [ref=e30] [cursor=pointer]
            - button "Carregar mais" [ref=e32] [cursor=pointer]
      - generic [ref=e33]:
        - text: Categoria
        - generic [ref=e35]:
          - textbox "Lista de categorias" [ref=e36]:
            - /placeholder: Pesquisar categorias...
          - button "Abrir lista" [ref=e37] [cursor=pointer]: Abrir
      - generic [ref=e38]:
        - button "Cancelar" [ref=e39] [cursor=pointer]
        - button "Salvar" [ref=e40] [cursor=pointer]
    - button "Close" [ref=e41] [cursor=pointer]:
      - img [ref=e42]
      - generic [ref=e45]: Close
```

# Test source

```ts
  1  | import { expect, Page } from '@playwright/test';
  2  | 
  3  | // Criar Pessoa
  4  | export async function criarPessoa(page: Page, nome: string, nascimento: string) {
  5  |   // desambiguar: clicar no menu lateral
  6  |   await page.getByRole('complementary').getByRole('link', { name: 'Pessoas' }).click();
  7  |   await page.getByRole('button', { name: 'Adicionar Pessoa' }).click();
  8  |   await page.getByLabel('Nome').fill(nome);
  9  |   await page.getByLabel('Data de Nascimento').fill(nascimento);
  10 |   await page.getByRole('button', { name: 'Salvar' }).click();
  11 | 
  12 |   // espera o modal fechar
  13 |   await page.waitForSelector('text=Salvando...', { state: 'detached' });
  14 | }
  15 | 
  16 | // Criar Categoria
  17 | export async function criarCategoria(page: Page, descricao: string, tipo: string) {
  18 |   await page.getByRole('complementary').getByRole('link', { name: 'Categorias' }).click();
  19 |   await page.getByRole('button', { name: 'Adicionar Categoria' }).click();
  20 |   await page.getByLabel('Descrição').fill(descricao);
  21 |   await page.getByRole('combobox').selectOption(tipo);
  22 |   await page.getByRole('button', { name: 'Salvar' }).click();
  23 | 
  24 |   await page.waitForSelector('text=Salvando...', { state: 'detached' });
  25 | }
  26 | 
  27 | // Criar Transação
  28 | export async function criarTransacao(page: Page, {
  29 |   descricao, valor, data, tipo, pessoa, categoria
  30 | }: { descricao: string; valor: string; data: string; tipo: string; pessoa: string; categoria: string }) {
  31 |   await page.getByRole('complementary').getByRole('link', { name: 'Transações' }).click();
  32 |   await page.getByRole('button', { name: 'Adicionar Transação' }).click();
  33 |   await page.getByLabel('Descrição').fill(descricao);
  34 |   await page.getByLabel('Valor').fill(valor);
  35 |   await page.getByLabel('Data').fill(data);
  36 |   await page.getByLabel('Tipo').selectOption(tipo);
  37 | 
  38 |   // Seleciona pessoa
  39 |   await page.getByRole('textbox', { name: 'Lista de pessoas' }).click();
  40 |   const pessoaOption = page.getByRole('option', { name: pessoa }).first();
> 41 |   await pessoaOption.waitFor({ state: 'visible' });
     |                      ^ Error: locator.waitFor: Test timeout of 30000ms exceeded.
  42 |   await pessoaOption.click();
  43 | 
  44 |   // Seleciona categoria
  45 |   await page.getByRole('textbox', { name: 'Lista de categorias' }).click();
  46 |   const categoriaOption = page.locator('[role="option"]').filter({ hasText: categoria }).last();
  47 |   await categoriaOption.waitFor({ state: 'visible' });
  48 |   await categoriaOption.click();
  49 | 
  50 |   await page.getByRole('button', { name: 'Salvar' }).click();
  51 |   await page.waitForSelector('text=Salvando...', { state: 'detached' });
  52 | 
  53 | }
  54 |   
  55 | // Menus Superiores do Sistema Funcionando
  56 | export async function MenusSuperioresdoSistema (page: Page) {
  57 |   //Dashboard
  58 |   await page.getByLabel('Main navigation').getByRole('link', { name: 'Dashboard' }).click();
  59 |   await expect(page.getByRole('heading', { name: 'Bem-vindo!' })).toBeVisible();
  60 |   //Transações
  61 |   await page.getByLabel('Main navigation').getByRole('link', { name: 'Transações' }).click();
  62 |   await expect(page.getByRole('heading', { name: 'Transações' })).toBeVisible();
  63 |   //Categorias
  64 |   await page.getByLabel('Main navigation').getByRole('link', { name: 'Categorias' }).click();
  65 |   await expect(page.getByRole('heading', { name: 'Categorias' })).toBeVisible();
  66 |   //Relatórios
  67 |   await page.getByLabel('Main navigation').getByRole('link', { name: 'Relatórios' }).click();
  68 |   await expect(page.getByRole('heading', { name: 'Totais por Pessoa' })).toBeVisible();
  69 | }
  70 |   
  71 |   
```