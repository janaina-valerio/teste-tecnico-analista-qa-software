import { expect, Page } from '@playwright/test';

// Criar Pessoa
export async function criarPessoa(page: Page, nome: string, nascimento: string) {
  // desambiguar: clicar no menu lateral
  await page.getByRole('complementary').getByRole('link', { name: 'Pessoas' }).click();
  await page.getByRole('button', { name: 'Adicionar Pessoa' }).click();
  await page.getByLabel('Nome').fill(nome);
  await page.getByLabel('Data de Nascimento').fill(nascimento);
  await page.getByRole('button', { name: 'Salvar' }).click();

  // espera o modal fechar
  await page.waitForSelector('text=Salvando...', { state: 'detached' });
}

// Criar Categoria
export async function criarCategoria(page: Page, descricao: string, tipo: string) {
  await page.getByRole('complementary').getByRole('link', { name: 'Categorias' }).click();
  await page.getByRole('button', { name: 'Adicionar Categoria' }).click();
  await page.getByLabel('Descrição').fill(descricao);
  await page.getByRole('combobox').selectOption(tipo);
  await page.getByRole('button', { name: 'Salvar' }).click();

  await page.waitForSelector('text=Salvando...', { state: 'detached' });
}

// Criar Transação
export async function criarTransacao(page: Page, {
  descricao, valor, data, tipo, pessoa, categoria
}: { descricao: string; valor: string; data: string; tipo: string; pessoa: string; categoria: string }) {
  await page.getByRole('complementary').getByRole('link', { name: 'Transações' }).click();
  await page.getByRole('button', { name: 'Adicionar Transação' }).click();
  await page.getByLabel('Descrição').fill(descricao);
  await page.getByLabel('Valor').fill(valor);
  await page.getByLabel('Data').fill(data);
  await page.getByLabel('Tipo').selectOption(tipo);

  // Seleciona pessoa
  await page.getByRole('textbox', { name: 'Lista de pessoas' }).click();
  const pessoaOption = page.getByRole('option', { name: pessoa }).first();
  await pessoaOption.waitFor({ state: 'visible' });
  await pessoaOption.click();

  // Seleciona categoria
  await page.getByRole('textbox', { name: 'Lista de categorias' }).click();
  const categoriaOption = page.locator('[role="option"]').filter({ hasText: categoria }).last();
  await categoriaOption.waitFor({ state: 'visible' });
  await categoriaOption.click();

  await page.getByRole('button', { name: 'Salvar' }).click();
  await page.waitForSelector('text=Salvando...', { state: 'detached' });

}
  
// Menus Superiores do Sistema Funcionando
export async function MenusSuperioresdoSistema (page: Page) {
  //Dashboard
  await page.getByLabel('Main navigation').getByRole('link', { name: 'Dashboard' }).click();
  await expect(page.getByRole('heading', { name: 'Bem-vindo!' })).toBeVisible();
  //Transações
  await page.getByLabel('Main navigation').getByRole('link', { name: 'Transações' }).click();
  await expect(page.getByRole('heading', { name: 'Transações' })).toBeVisible();
  //Categorias
  await page.getByLabel('Main navigation').getByRole('link', { name: 'Categorias' }).click();
  await expect(page.getByRole('heading', { name: 'Categorias' })).toBeVisible();
  //Relatórios
  await page.getByLabel('Main navigation').getByRole('link', { name: 'Relatórios' }).click();
  await expect(page.getByRole('heading', { name: 'Totais por Pessoa' })).toBeVisible();
}
  
  