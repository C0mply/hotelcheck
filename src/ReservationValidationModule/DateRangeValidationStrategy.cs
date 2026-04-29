namespace HotelCheck.Modules.ReservationValidation;

public sealed class DateRangeValidationStrategy : IReservationValidationStrategy
{
    public ValidationResult? Validate(ReservationValidationContext context)
    {
        if (context.Request.CheckOut <= context.Request.CheckIn)
        {
            return ValidationResult.Failure(
                "INVALID_DATE_RANGE",
                "Check-out date must be later than check-in date."
            );
        }

        return null;
    }
}
