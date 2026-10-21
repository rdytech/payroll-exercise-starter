import { defineConfig } from 'vitest/config';
import react from '@vitejs/plugin-react';

export default defineConfig({
  plugins: [react()],
  server: {
    port: 5173,
    strictPort: true,
    // Calls to /api go to the .NET API, so the browser never needs CORS.
    proxy: {
      '/api': 'http://localhost:5080',
    },
  },
  test: {
    environment: 'node',
  },
});
