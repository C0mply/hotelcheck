# Flow: Reservation Validation

```mermaid
flowchart TD
    A[Start reservation request] --> B[Check input data]
    B --> C{Check-out date > Check-in date?}

    C -- No --> D[Return validation error: invalid date range]
    C -- Yes --> E[Check room availability for selected dates]

    E --> F{Room available?}
    F -- No --> G[Return validation error: room unavailable]
    F -- Yes --> H[Return success: reservation can be created]

    D --> I[End]
    G --> I
    H --> I
