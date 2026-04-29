namespace HotelCheck.Modules.ReservationValidation;

public sealed record ReservationRequest(
    int GuestId,
    int RoomId,
    DateOnly CheckIn,
    DateOnly CheckOut
);
