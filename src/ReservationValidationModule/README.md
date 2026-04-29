# Reservation Validation Module

## Selected Pattern
This module uses the **Strategy** pattern.

## Why Strategy is the Best Fit
Reservation validation consists of several independent rules:
- checking whether the room exists
- checking whether the date range is valid
- checking whether the room is available

These rules are easier to maintain when each one is implemented as a separate validation strategy.  
This avoids placing all logic in one large method and makes the module easier to extend in the future.

## Interaction with Other Components
This module is intended to be called by the reservation workflow in the application.

Expected interaction:
1. The UI or reservation form collects reservation input.
2. The application creates a `ReservationValidationContext`.
3. `ReservationValidationService` runs the validation strategies.
4. The module returns a `ValidationResult`.
5. Only if validation succeeds should the application proceed to reservation creation or persistence.

## Design Notes
- The module is focused only on validation logic.
- It should not save data, update UI, or perform external side effects.
- Validation behavior is separated into small, replaceable components.
