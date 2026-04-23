import { test, expect } from '@playwright/test';
import { criarPessoa } from './actions';

test.describe('Pessoas', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('http://localhost:5173');
  });

  test('Criar pessoa menor de idade', async ({ page }) => {
    await criarPessoa(page, 'Bryan Mendes', '2020-01-10');
    const pessoaRow = page.getByRole('row').filter({ hasText: 'Bryan Mendes' });
    await expect(pessoaRow).toBeVisible();
  });

  test('Criar pessoa maior de idade', async ({ page }) => {
    await criarPessoa(page, 'Janaína Valério', '1995-08-09');
    const pessoaRow = page.getByRole('row').filter({ hasText: 'Janaína Valério' });
    await expect(pessoaRow).toBeVisible();
  });

  test('Não deve permitir cadastro duplicado de pessoa', async ({ page }) => {
    await criarPessoa(page, 'Victor Valério', '1998-03-16');
    await criarPessoa(page, 'Victor Valério', '1998-03-16');

    const alerta = page.getByRole('alert').filter({ hasText: 'Pessoa já cadastrada' });
    await expect(alerta).toBeVisible();
  });
});
