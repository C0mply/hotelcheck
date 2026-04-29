using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace HotelCheck.Modules.ReservationValidation.UI;

public partial class ReservationValidationDemoWindow : Window
{
    public ReservationValidationDemoWindow()
    {
        InitializeComponent();

        CheckInDatePicker.SelectedDate = DateTime.Today.AddDays(1);
        CheckOutDatePicker.SelectedDate = DateTime.Today.AddDays(3);
    }

    private void ValidateButton_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(GuestIdTextBox.Text, out int guestId))
        {
            ShowMessage("Guest ID must be a valid integer.", false);
            return;
        }

        if (!int.TryParse(RoomIdTextBox.Text, out int roomId))
        {
            ShowMessage("Room ID must be a valid integer.", false);
            return;
        }

        if (CheckInDatePicker.SelectedDate is null || CheckOutDatePicker.SelectedDate is null)
        {
            ShowMessage("Please select both check-in and check-out dates.", false);
            return;
        }

        var request = new ReservationRequest(
            guestId,
            roomId,
            DateOnly.FromDateTime(CheckInDatePicker.SelectedDate.Value),
            DateOnly.FromDateTime(CheckOutDatePicker.SelectedDate.Value)
        );

        IReadOnlyCollection<ExistingReservation> existingReservations =
            CreateExistingReservations(roomId, OverlapCheckBox.IsChecked == true, request.CheckIn, request.CheckOut);

        var context = new ReservationValidationContext(
            request,
            existingReservations,
            RoomExistsCheckBox.IsChecked == true
        );

        var service = new ReservationValidationService(
            new IReservationValidationStrategy[]
            {
                new RoomExistsValidationStrategy(),
                new DateRangeValidationStrategy(),
                new RoomAvailabilityValidationStrategy()
            }
        );

        ValidationResult result = service.Validate(context);

        if (result.IsValid)
        {
            ShowMessage($"Success: {result.Message}", true);
        }
        else
        {
            ShowMessage($"Error [{result.ErrorCode}]: {result.Message}", false);
        }
    }

    private static IReadOnlyCollection<ExistingReservation> CreateExistingReservations(
        int roomId,
        bool simulateOverlap,
        DateOnly checkIn,
        DateOnly checkOut)
    {
        if (!simulateOverlap)
        {
            return Array.Empty<ExistingReservation>();
        }

        return new[]
        {
            new ExistingReservation(
                roomId,
                checkIn.AddDays(1),
                checkOut.AddDays(-1))
        };
    }

    private void ShowMessage(string message, bool isSuccess)
    {
        ResultTextBlock.Text = message;

        if (isSuccess)
        {
            ResultBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ECFDF5"));
            ResultBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#16A34A"));
            ResultTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#166534"));
        }
        else
        {
            ResultBorder.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FEF2F2"));
            ResultBorder.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#DC2626"));
            ResultTextBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#991B1B"));
        }
    }
}
