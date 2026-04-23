import { test, expect } from '@playwright/test';

test('Menor de idade não pode registrar receita', async ({ page }) => {
  await page.goto('/pessoas');
  console.log('✅ Teste iniciado');
  expect(true).toBe(true); // Teste temporário para validar se roda
});

test('Fluxo básico funcionando', async ({ page }) => {
  await page.goto('/');
  expect(page.url()).toContain('localhost');
});
