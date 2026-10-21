export type EmploymentType = 'FullTime' | 'PartTime' | 'Casual';

export interface Employee {
  id: number;
  name: string;
  hourlyRate: number;
  employmentType: EmploymentType;
}

export async function getEmployees(): Promise<Employee[]> {
  const response = await fetch('/api/employees');
  if (!response.ok) {
    // Error responses are problem details JSON; `detail` holds the reason.
    const problem = await response.json().catch(() => null);
    throw new Error(problem?.detail ?? `GET /api/employees failed with ${response.status}`);
  }
  return response.json();
}
