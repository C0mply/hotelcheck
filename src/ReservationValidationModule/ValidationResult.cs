namespace HotelCheck.Modules.ReservationValidation;

public sealed record ValidationResult(
    bool IsValid,
    string ErrorCode,
    string Message
)
{
    public static ValidationResult Success() =>
        new(true, "OK", "Reservation request is valid.");

    public static ValidationResult Failure(string errorCode, string message) =>
        new(false, errorCode, message);
}
