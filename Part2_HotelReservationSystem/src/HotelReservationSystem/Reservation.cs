
using System.Net.NetworkInformation;

namespace HotelReservationSystem;

internal class Reservation
{
    public int ReservationID { get; }
    
    public DateTime CheckInDate { get; }
    public DateTime CheckOutDate { get; }
    public ReservationStatus ReservationStatus { get; private set; }
    public Room Room { get; }
    public int NumberOfNights => (CheckOutDate - CheckInDate).Days;
    public decimal TotalCost => NumberOfNights *Room.NightlyRate;


    public Reservation(int reservationID, DateTime checkInDate, DateTime checkOutDate, Room room)
    {
        if (checkOutDate <= checkInDate)
        {
            throw new ArgumentException("Check-out date must be after check-in date.");
        }
        if (room == null)
        {
            throw new ArgumentNullException(nameof(room));
        }

        // Check maintenance status
        if (room.IsUnderMaintenance)
        {
            throw new InvalidOperationException(
                "Cannot create a reservation for a room under maintenance.");
        }
        ReservationID = reservationID;
        CheckInDate = checkInDate;
        CheckOutDate = checkOutDate;
        Room = room;
        ReservationStatus = ReservationStatus.Pending;
    }

    public void Confirm()
    {
        if (ReservationStatus == ReservationStatus.Pending)
            ReservationStatus = ReservationStatus.Confirmed;
    }

    public void CheckIn()
    {
        if (ReservationStatus == ReservationStatus.Confirmed)
            ReservationStatus = ReservationStatus.CheckedIn;
    }

    public void CheckOut()
    {
        if (ReservationStatus == ReservationStatus.CheckedIn)
            ReservationStatus = ReservationStatus.CheckedOut;
    }
    public void Cancel()
    {
        if (ReservationStatus == ReservationStatus.Pending || ReservationStatus == ReservationStatus.Confirmed)
            ReservationStatus = ReservationStatus.Cancelled;
    }
}
