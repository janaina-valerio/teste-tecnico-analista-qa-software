import { test, expect } from '@playwright/test';
import { criarPessoa, criarCategoria, criarTransacao } from './actions';

test.describe('Transações', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('http://localhost:5173');
  });

  test('Impede menor de idade de registrar receita', async ({ page }) => {
    await criarPessoa(page, 'Miguel Mendes', '2020-01-10');
    await criarCategoria(page, 'Salário', 'Receita');

    await criarTransacao(page, {
      descricao: 'Mesada',
      valor: '1000',
      data: '2026-04-20',
      tipo: 'receita',
      pessoa: 'Miguel Mendes',
      categoria: 'Salário',
    });

    const alerta = page.getByRole('alert').filter({ hasText: 'Menores de 18 anos não podem' });
    await expect(alerta).toBeVisible();
  });

  test('Criar transação com pessoa maior de idade', async ({ page }) => {
    await criarPessoa(page, 'Janaína Valério', '1995-08-09');
    await criarCategoria(page, 'Investimentos', 'Receita');

    await criarTransacao(page, {
      descricao: 'Dividendos',
      valor: '1500',
      data: '2026-04-20',
      tipo: 'receita',
      pessoa: 'Janaína Valério',
      categoria: 'Investimentos',
    });

    const transacaoRow = page.getByRole('row').filter({ hasText: 'Dividendos' });
    await expect(transacaoRow).toBeVisible();
  });
});
