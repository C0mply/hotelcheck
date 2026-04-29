namespace HotelCheck.Modules.ReservationValidation;

public sealed class RoomExistsValidationStrategy : IReservationValidationStrategy
{
    public ValidationResult? Validate(ReservationValidationContext context)
    {
        if (!context.RoomExists)
        {
            return ValidationResult.Failure(
                "ROOM_NOT_FOUND",
                "The selected room does not exist."
            );
        }

        return null;
    }
}
