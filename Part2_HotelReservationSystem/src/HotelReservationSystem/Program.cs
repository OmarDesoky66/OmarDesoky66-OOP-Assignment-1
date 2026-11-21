namespace HotelReservationSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
                No double-booking (challenge): a room should not be allowed to have two active (non-cancelled,
                non-checked-out) reservations with overlapping date ranges. Decide which class is responsible for
                checking this before a new reservation is created.
            */

            // Answer =>  There Should be a class "HOTEL"  that manages the rooms and reservations 
            //, and it should be responsible for checking for double booking before creating a new reservation 
             
        }
    }
}
