# Feature: Reservation Validation

## User Story
As a hotel administrator, I want to create a reservation only when the selected dates are valid and the room is available, so that booking data remains correct and reliable.

## Acceptance Criteria

### AC1: Reservation with valid dates and available room
Given a room exists and is available for the selected check-in and check-out dates  
When the administrator submits a reservation request with valid guest, room, check-in, and check-out data  
Then the system should accept the reservation request and return a successful validation result

### AC2: Check-out date must be later than check-in date
Given a room exists  
When the administrator submits a reservation request where the check-out date is earlier than or equal to the check-in date  
Then the system should reject the reservation request and return a validation error

### AC3: Reservation must be rejected if room is not available
Given a room already has an overlapping reservation for the selected dates  
When the administrator submits a new reservation request for the same room and overlapping date range  
Then the system should reject the reservation request and return a room availability error
