function createReservationRequest(guestId, roomId, checkIn, checkOut) {
  return {
    guestId,
    roomId,
    checkIn,
    checkOut
  };
}

function createExistingReservations(roomId, simulateOverlap, checkIn, checkOut) {
  if (!simulateOverlap) {
    return [];
  }

  const overlapStart = new Date(checkIn);
  overlapStart.setDate(overlapStart.getDate() + 1);

  const overlapEnd = new Date(checkOut);
  overlapEnd.setDate(overlapEnd.getDate() - 1);

  return [
    {
      roomId,
      checkIn: overlapStart.toISOString().split("T")[0],
      checkOut: overlapEnd.toISOString().split("T")[0]
    }
  ];
}

function validateRoomExists(context) {
  if (!context.roomExists) {
    return {
      isValid: false,
      errorCode: "ROOM_NOT_FOUND",
      message: "The selected room does not exist."
    };
  }

  return null;
}

function validateDateRange(context) {
  if (!context.request.checkIn || !context.request.checkOut) {
    return {
      isValid: false,
      errorCode: "MISSING_DATE",
      message: "Please select both check-in and check-out dates."
    };
  }

  if (context.request.checkOut <= context.request.checkIn) {
    return {
      isValid: false,
      errorCode: "INVALID_DATE_RANGE",
      message: "Check-out date must be later than check-in date."
    };
  }

  return null;
}

function datesOverlap(requestedCheckIn, requestedCheckOut, existingCheckIn, existingCheckOut) {
  return requestedCheckIn < existingCheckOut && requestedCheckOut > existingCheckIn;
}

function validateRoomAvailability(context) {
  const hasOverlap = context.existingReservations.some((reservation) => {
    return (
      reservation.roomId === context.request.roomId &&
      datesOverlap(
        context.request.checkIn,
        context.request.checkOut,
        reservation.checkIn,
        reservation.checkOut
      )
    );
  });

  if (hasOverlap) {
    return {
      isValid: false,
      errorCode: "ROOM_UNAVAILABLE",
      message: "The room is not available for the selected dates."
    };
  }

  return null;
}

function validateReservation(context) {
  const strategies = [
    validateRoomExists,
    validateDateRange,
    validateRoomAvailability
  ];

  for (const strategy of strategies) {
    const result = strategy(context);

    if (result) {
      return result;
    }
  }

  return {
    isValid: true,
    errorCode: "OK",
    message: "Reservation request is valid."
  };
}

function showResult(message, status) {
  const resultPanel = document.getElementById("resultPanel");
  const resultText = document.getElementById("resultText");

  resultText.textContent = message;
  resultPanel.classList.remove("neutral", "success", "error");
  resultPanel.classList.add(status);
}

function setDefaultDates() {
  const checkInInput = document.getElementById("checkIn");
  const checkOutInput = document.getElementById("checkOut");

  const today = new Date();
  const tomorrow = new Date(today);
  tomorrow.setDate(today.getDate() + 1);

  const threeDaysLater = new Date(today);
  threeDaysLater.setDate(today.getDate() + 3);

  checkInInput.value = tomorrow.toISOString().split("T")[0];
  checkOutInput.value = threeDaysLater.toISOString().split("T")[0];
}

function handleValidation() {
  const guestId = Number(document.getElementById("guestId").value);
  const roomId = Number(document.getElementById("roomId").value);
  const checkIn = document.getElementById("checkIn").value;
  const checkOut = document.getElementById("checkOut").value;
  const roomExists = document.getElementById("roomExists").checked;
  const simulateOverlap = document.getElementById("simulateOverlap").checked;

  if (!Number.isInteger(guestId) || guestId <= 0) {
    showResult("Guest ID must be a valid positive integer.", "error");
    return;
  }

  if (!Number.isInteger(roomId) || roomId <= 0) {
    showResult("Room ID must be a valid positive integer.", "error");
    return;
  }

  const request = createReservationRequest(guestId, roomId, checkIn, checkOut);
  const existingReservations = createExistingReservations(
    roomId,
    simulateOverlap,
    checkIn,
    checkOut
  );

  const context = {
    request,
    existingReservations,
    roomExists
  };

  const result = validateReservation(context);

  if (result.isValid) {
    showResult(`Success: ${result.message}`, "success");
  } else {
    showResult(`Error [${result.errorCode}]: ${result.message}`, "error");
  }
}

document.addEventListener("DOMContentLoaded", () => {
  setDefaultDates();

  const validateButton = document.getElementById("validateButton");
  validateButton.addEventListener("click", handleValidation);
});
