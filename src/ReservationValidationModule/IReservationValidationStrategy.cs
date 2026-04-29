namespace HotelCheck.Modules.ReservationValidation;

public interface IReservationValidationStrategy
{
    ValidationResult? Validate(ReservationValidationContext context);
}
