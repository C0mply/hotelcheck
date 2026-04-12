# AGENTS.md

## Project Overview
- This repository contains **HotelCheck**, a desktop hotel reservation management system.
- The project is intended for small hotel administration workflows.
- Core domain entities:
  - Rooms
  - Guests
  - Reservations
- Main goals of the system:
  - manage rooms
  - manage guest records
  - manage reservations
  - save and load data reliably

## Tech Stack
- Language: C#
- Framework: .NET 8
- UI Framework: WPF
- Data storage: local JSON file

## Rules for AI Agents
- Always preserve the existing project structure unless explicitly instructed otherwise.
- Prefer small, incremental changes over large rewrites.
- Do not introduce unnecessary dependencies or frameworks.
- Do not replace WPF with another UI framework.
- Keep the code simple, readable, and maintainable.
- Follow existing naming conventions and file organization.
- Avoid adding speculative features that are not part of the current project scope.
- Always consult the `/docs` folder before making implementation decisions.

## Coding Style
- Use clear and descriptive class, method, and variable names.
- Prefer small methods with a single responsibility.
- Avoid unnecessary duplication.
- Keep business logic separate from UI logic when possible.
- Add comments only when they improve clarity.

## Constraints
- The project should remain suitable for incremental course development.
- Changes should align with the MVP plan in `/docs/plans/roadmap.md`.
- If requirements are unclear, prefer the simplest solution that matches the documented scope.

## Required Reading
- `/docs/pm_approach.md`
- `/docs/plans/roadmap.md`
