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
        public string Status;
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
            // Check the current status of the room and store it in roomStatus
            if (IsOccupied)
            {
                Status = "OCCUPIED";
            }
            else
            {
                Status = "AVAILABLE";
            }

            // Optionally print the status here if you want immediate feedback
            Console.WriteLine($"Room Number {RoomNumber}  is currently {Status}.");
        }

        // DisplayInfo method to print room details along with occupancy status
        public void DisplayInfo()
        {
            // Print room information and the stored room status
            Console.WriteLine($"Room Number: {RoomNumber}, Room Type: {R}, Room Status: {Status}");
        }
    }
}