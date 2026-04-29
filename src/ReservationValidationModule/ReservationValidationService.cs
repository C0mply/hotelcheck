namespace HotelCheck.Modules.ReservationValidation;

public sealed class ReservationValidationService
{
    private readonly IReadOnlyCollection<IReservationValidationStrategy> _strategies;

    public ReservationValidationService(
        IReadOnlyCollection<IReservationValidationStrategy> strategies)
    {
        _strategies = strategies;
    }

    public ValidationResult Validate(ReservationValidationContext context)
    {
        foreach (IReservationValidationStrategy strategy in _strategies)
        {
            ValidationResult? result = strategy.Validate(context);

            if (result is not null)
            {
                return result;
            }
        }

        return ValidationResult.Success();
    }
}
