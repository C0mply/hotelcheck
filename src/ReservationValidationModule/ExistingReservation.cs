namespace HotelCheck.Modules.ReservationValidation;

public sealed record ExistingReservation(
    int RoomId,
    DateOnly CheckIn,
    DateOnly CheckOut
);
