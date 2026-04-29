```markdown
# HotelCheck Roadmap

## Project Vision
HotelCheck should become a simple and maintainable hotel reservation management system for small hotel administration needs.

## MVP Scope
The MVP includes:
- room management
- guest management
- reservation management
- basic validation of input data
- local JSON-based data persistence
- a usable desktop interface for core workflows

## Planned Stages

### Stage 1 — Foundation Review
- review the existing project structure
- confirm the main domain entities: rooms, guests, reservations
- clean up obvious inconsistencies in the current codebase
- document project rules and roadmap

### Stage 2 — Core Data Management
- improve room management
- improve guest management
- ensure create, edit, and delete operations work reliably
- improve saving and loading of local data

### Stage 3 — Reservation Workflow (**Complete**)
- improve reservation creation flow
- connect reservations clearly to rooms and guests
- validate reservation dates
- reduce the risk of incorrect booking records
- implement reservation validation module using the Strategy pattern

### Stage 4 — MVP Stabilization
- improve UI clarity and usability
- remove obvious bugs
- improve code readability and maintainability
- prepare the project for demonstration and course reporting

## Scope Adjustments
- Reservation validation was separated into a dedicated module.
- Validation logic is now structured as independent strategies instead of a single combined method.
- This improves maintainability and makes future validation rules easier to add.

## Deferred to Future Releases
The following items are outside the MVP and may be added later:
- database integration
- authentication and user roles
- advanced search and filtering
- conflict detection for overlapping bookings
- reporting and analytics
- online or multi-user synchronization

## Definition of Done for MVP
The MVP is considered complete when:
- the user can manage rooms, guests, and reservations
- data can be saved and loaded correctly
- the application supports the main hotel administration workflow
- the codebase remains understandable and maintainable
