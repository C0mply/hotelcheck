# AI Implementation Prompt

Implement a reservation validation module in C# using the **Strategy** pattern.

Requirements:
- The module belongs to a hotel reservation management system.
- The module must validate reservation requests.
- Validation rules:
  - the room must exist
  - check-out date must be later than check-in date
  - the room must not have overlapping reservations
- Each validation rule must be implemented as a separate strategy.
- A coordinator/service should execute all strategies and return the first validation failure, or success if all checks pass.
- Keep the code modular, readable, and aligned with AGENTS.md.
- Do not introduce unnecessary dependencies.
- Do not add UI code, database code, or side effects.
- Use clear naming and small classes.
