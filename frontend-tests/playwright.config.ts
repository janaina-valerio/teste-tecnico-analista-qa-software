import { defineConfig } from '@playwright/test';

export default defineConfig({
  testDir: './frontend-tests/tests',
  timeout: 30 * 1000, // tempo máximo por teste (30s)
  expect: {
    timeout: 10 * 1000, // tempo máximo para cada expect (10s)
  },
  reporter: [['list'], ['html', { outputFolder: 'playwright-report' }]],
  use: {
    baseURL: 'http://localhost:5173',
    headless: true,
    screenshot: 'only-on-failure',
    video: 'retain-on-failure',
  },
});
