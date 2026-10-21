// Deletes the SQLite database. The API recreates it from the model and reloads the
// sample employees the next time it starts.
import { rmSync } from 'node:fs';

const base = new URL('../server/Payroll.Api/payroll.db', import.meta.url);
try {
  for (const suffix of ['', '-shm', '-wal']) {
    rmSync(new URL(base.href + suffix), { force: true });
  }
} catch (error) {
  if (error.code === 'EBUSY' || error.code === 'EPERM') {
    console.error('The database is in use. Stop `npm run dev` (Ctrl+C) first, then run this again.');
    process.exit(1);
  }
  throw error;
}
console.log('Database deleted. It is recreated with the sample employees when the API next starts.');
