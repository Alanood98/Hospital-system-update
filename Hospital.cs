using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public class Hospital
    {

      public static List<Patient> patients=new List<Patient>();
        public static List <Doctor> doctors=new List<Doctor>();
        public static List<Room> rooms=new List<Room>();

        public Hospital( Patient patient,Doctor doctor,Room rooms)
        {
            Patient patients =patient;
            Doctor doctors = doctor;
            Room room = rooms;

        }

        public void AddDoctor(Doctor doctor)
        {
            doctors.Add(doctor);
        }

        public void AddPatient(Patient patient)
        {
            patients.Add(patient);
        }

        public void AssignRoomToPatient(Patient patient, Room room)
        {
            if (!rooms.Contains(room))
            {
                rooms.Add(room);
            }
            room.OccupyRoom();
            patient.AssignedRoom = room;
        }



        public void GetDoctorPatients(Doctor doctor)
        {
            Console.WriteLine($"Doctor ID: {doctor.DoctorID} | Doctor Name: {doctor.Name}");

            foreach (Patient patient in Doctor.DoctorPatients)
            {
                Console.WriteLine($"Patient Name: {patient.Name}");
            }
            Console.WriteLine("\n");
        }

    }
}
