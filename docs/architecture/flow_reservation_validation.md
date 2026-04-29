# Flow: Reservation Validation Module

```mermaid
flowchart TD
    UI[Reservation Form / UI] --> SVC[ReservationValidationService]

    SVC --> STR1[RoomExistsValidationStrategy]
    SVC --> STR2[DateRangeValidationStrategy]
    SVC --> STR3[RoomAvailabilityValidationStrategy]

    ROOM[Room existence input] --> STR1
    REQ[ReservationRequest] --> STR2
    REQ --> STR3
    RESLIST[Existing reservations input] --> STR3

    STR1 --> RESULT[ValidationResult]
    STR2 --> RESULT
    STR3 --> RESULT

    RESULT --> WORKFLOW[Reservation creation workflow]
