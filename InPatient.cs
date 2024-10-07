using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static HospitalClassINhernite.Patient;

namespace HospitalClassINhernite
{
    public class InPatient : Patient 
    {
        public Room Room;
        public Doctor AssignedDoctor;
        public DateTime AdmissionDate;



        public InPatient(int pationid, string name, int age, Gender gender, string ailmenrt, Doctor assignedDoctor, Room room, DateTime admissionDate) : base(pationid, name, age, gender, ailmenrt, assignedDoctor)
        {
            Room = room;
            AssignedDoctor = assignedDoctor;
            AdmissionDate = admissionDate;
        }
        public void AssignRoom(Room room)
        {

            room.OccupyRoom();
            AssignedRoom = room;

        }

        public void Discharge()
        {
            AssignedRoom.VacateRoom();
            AssignedRoom = null;
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" pation id : {PatientID} , aliment : {Ailment}  , room :{AssignRoom},doctor:{AssignedDoctor}");



        }

        public interface IInPatientCare : IPatientCare
        {
            void Discharge();
            void AssignRoom();

        }

    }
}