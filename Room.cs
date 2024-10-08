using System.Xml.Linq;
using static HospitalClassINhernite.Room;
namespace HospitalClassINhernite
{
    public class Room : IDisplayInfo , IRoomManagement
    {
        public static List<Patient> roomlist = new List<Patient>();
        public int RoomNumber;
        public Room Clinic;
        public enum RoomType { IPR, OPR }
        public RoomType R { get; set; }
        public bool IsOccupied;
        public Clinic AssignedClinic;
        public Room(int roomNumber, RoomType roomType)
        {
            RoomNumber = roomNumber;
            R = roomType;
        }
        public void OccupyRoom()
        {
            if (IsOccupied)
            {
                Console.WriteLine("<!>This room is already booked :( <!>");
            }
            else
            {
                IsOccupied = true;
            }
        }
        public void VacateRoom()
        {
            if (!IsOccupied)
            {
                Console.WriteLine("<!>This room is not occupied :( <!>");
            }
            else
            {
                IsOccupied = false;
            }
        }
        public void AssignToClinic(Clinic clinic)
        {
            AssignedClinic = clinic;
        }

        public void occupancyStatus()
        {
            // Check the current status of the room
            if (IsOccupied)
            {
                // If the room is occupied, display its current status
                Console.WriteLine($"Room Number {RoomNumber} (Type: {R}) is currently OCCUPIED.");
            }
            else
            {
                // If the room is available, display its current status
                Console.WriteLine($"Room Number {RoomNumber} (Type: {R}) is AVAILABLE for use.");
            }
        }

        public void DisplayInfo()
        {

            Console.WriteLine($"Room Number:{RoomNumber},room Type : {R} ");

        }
    }
}