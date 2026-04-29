namespace HotelCheck.Modules.ReservationValidation;

public sealed record ReservationValidationContext(
    ReservationRequest Request,
    IReadOnlyCollection<ExistingReservation> ExistingReservations,
    bool RoomExists
);
