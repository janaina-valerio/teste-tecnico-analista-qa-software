import { test, expect } from '@playwright/test';
import { criarCategoria } from './actions';

test.describe('Categorias', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('http://localhost:5173');
  });

  test('Criar categoria de receita', async ({ page }) => {
    await criarCategoria(page, 'Empréstimo', 'Receita');
    const categoriaRow = page.getByRole('row').filter({ hasText: 'Empréstimo' });
    await expect(categoriaRow).toBeVisible();
  });

  test('Criar categoria de despesa', async ({ page }) => {
    await criarCategoria(page, 'Plano de Saúde', 'Despesa');
    const categoriaRow = page.getByRole('row').filter({ hasText: 'Plano de Saúde' });
    await expect(categoriaRow).toBeVisible();
  });
});
