import { useEffect, useState } from 'react';
import { getEmployees, type Employee } from './api';

export default function App() {
  const [employees, setEmployees] = useState<Employee[]>([]);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    getEmployees()
      .then(setEmployees)
      .catch((e: Error) => setError(e.message));
  }, []);

  return (
    <main>
      <h1>Payroll</h1>
      <h2>Employees</h2>
      {error && <p role="alert">Could not load employees: {error}. Is the API running?</p>}
      <table>
        <thead>
          <tr>
            <th>Name</th>
            <th>Hourly rate</th>
            <th>Employment type</th>
          </tr>
        </thead>
        <tbody>
          {employees.map((employee) => (
            <tr key={employee.id}>
              <td>{employee.name}</td>
              <td>{employee.hourlyRate}</td>
              <td>{employee.employmentType}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </main>
  );
}
