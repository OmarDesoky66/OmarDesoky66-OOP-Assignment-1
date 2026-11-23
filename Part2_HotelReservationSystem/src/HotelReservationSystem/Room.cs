
using System.Data;

namespace HotelReservationSystem;

internal class Room
{

    public int RoomNumber { get; }
    public RoomType RoomType { get; }
    public bool IsUnderMaintenance { get; private set; }

    public decimal NightlyRate { get; private set; }


    public Room(int roomNumber, RoomType roomType, decimal nightlyRate)
    {
        if(nightlyRate <= 0)
        {
            throw new ArgumentException("Nightly rate cannot be negative or Zero.");
        }

        RoomNumber = roomNumber;
        RoomType = roomType;
        NightlyRate = nightlyRate;
        IsUnderMaintenance = false;
    }


    public void UpdateNightlyRate(decimal newRate)
    {
        NightlyRate = newRate;
    }

    public void StartMaintenance ()
    {
        IsUnderMaintenance = true;
    }

    public void EndMaintenance()
    {
        IsUnderMaintenance = false;
    }
}
