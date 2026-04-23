import { test, expect } from '@playwright/test';

test.describe('Menus Superiores do Sistema', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('http://localhost:5173');
  });

  test('menus superiores funcionando', async ({ page }) => {
    // Dashboard
    await page.getByLabel('Main navigation').getByRole('link', { name: 'Dashboard' }).click();
    await expect(page.getByRole('heading', { name: 'Bem-vindo!' })).toBeVisible();

    // Transações
    await page.getByLabel('Main navigation').getByRole('link', { name: 'Transações' }).click();
    await expect(page.getByRole('heading', { name: 'Transações' })).toBeVisible();

    // Categorias
    await page.getByLabel('Main navigation').getByRole('link', { name: 'Categorias' }).click();
    await expect(page.getByRole('heading', { name: 'Categorias' })).toBeVisible();

    // Relatórios
    await page.getByLabel('Main navigation').getByRole('link', { name: 'Relatórios' }).click();
    await expect(page.getByRole('heading', { name: 'Totais por Pessoa' })).toBeVisible();
  });
});
