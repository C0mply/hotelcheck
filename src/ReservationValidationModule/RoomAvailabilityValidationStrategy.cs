namespace HotelCheck.Modules.ReservationValidation;

public sealed class RoomAvailabilityValidationStrategy : IReservationValidationStrategy
{
    public ValidationResult? Validate(ReservationValidationContext context)
    {
        bool hasOverlap = context.ExistingReservations.Any(r =>
            r.RoomId == context.Request.RoomId &&
            DatesOverlap(
                context.Request.CheckIn,
                context.Request.CheckOut,
                r.CheckIn,
                r.CheckOut));

        if (hasOverlap)
        {
            return ValidationResult.Failure(
                "ROOM_UNAVAILABLE",
                "The room is not available for the selected dates."
            );
        }

        return null;
    }

    private static bool DatesOverlap(
        DateOnly requestedCheckIn,
        DateOnly requestedCheckOut,
        DateOnly existingCheckIn,
        DateOnly existingCheckOut)
    {
        return requestedCheckIn < existingCheckOut &&
               requestedCheckOut > existingCheckIn;
    }
}
