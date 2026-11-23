namespace HotelReservationSystem;

internal class Guest
{
    public int GuestID { get; }
    public string FullName { get; }
    public string PhoneNumber { get; }
    private List<Reservation> Reservations = new List<Reservation>();

    public IReadOnlyList<Reservation> Reservation => Reservations.AsReadOnly();
    public Guest(int guestID, string fullName, string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(fullName))
        {
            throw new ArgumentException("Full name cannot be empty.");
        }
        if (string.IsNullOrWhiteSpace(PhoneNumber))
        {
            throw new ArgumentException("Phone number cannot be empty.");
        }
        GuestID = guestID;
        FullName = fullName;
        PhoneNumber = phoneNumber;

    }

    public void AddReservation(Reservation reservation)
    {
        Reservations.Add(reservation);//Adding a reservation to the guest's list of reservations
    }
} 
