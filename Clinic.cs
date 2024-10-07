using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HospitalClassINhernite
{
    public class Clinic
    {
        public int ClinicID { get; set; }
        public string ClinicName { get; set; }
        public Specialization ClinicSpec { get; set; }
        public enum ClinicSpecialization { Cardiology, Neurology, Dermatology }
        public List<Room> Rooms = new List<Room>();
        public Dictionary<Doctor, List<Appointment>> AvailableAppointments = new Dictionary<Doctor, List<Appointment>>() ;
        public enum Specialization
        {
            Cardiology,
            Neurology,
            Dermatology
        }
        // Constructor
        public Clinic(int clinicID, string clinicName, Specialization clinicSpec)
        {
            ClinicID = clinicID;
            ClinicName = clinicName;
            ClinicSpec = clinicSpec;
        }
        public void AddRoom(Room room)
        {
            Console.WriteLine("......Add Room.......");
            if (room != null)
            {
                Rooms.Add(room);
                room.OccupyRoom();
            }
            else
            {
                Console.WriteLine("invalid");
            }
        }
        public void AddAvailableAppointment(Doctor doctor, DateTime appointmentDay, TimeSpan period)
        {
            Console.WriteLine("......Add Available Appointment.......");
            TimeSpan start = new TimeSpan(9, 0, 0);
            TimeSpan end = new TimeSpan(11, 0, 0);
            if (!AvailableAppointments.ContainsKey(doctor))
            {
                AvailableAppointments[doctor] = new List<Appointment>();
                for (int i = 0; i < period.TotalHours && start.Add(new TimeSpan(i, 0, 0)) <= end; i++)
                {
                    Appointment appointment = new Appointment(null, doctor, appointmentDay, period,false);
                    appointment.ScheduleAppointment(null, doctor, appointmentDay, start.Add(new TimeSpan(i, 0, 0)), false);
                    AvailableAppointments[doctor].Add(appointment);
                    Console.WriteLine($"Appointment Scheduled for {doctor.Name} in {appointmentDay.AddHours(i).ToString("yyy-MM-dd")}  at {start.Add(new TimeSpan(i, 0, 0))}");
                }
            }
            else
            {
                Console.WriteLine($"{doctor.Name} Not Available to  Schedule Appointment in this Clinic");
            }
            Console.WriteLine(".................................................");
        }
        public void CancelAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            Console.WriteLine("......Cancel Appointment.......");
            foreach (var cencel in AvailableAppointments)
            {
                for (int i = 0; i < cencel.Value.Count; i++)
                {
                    if (cencel.Value[i].AppointmentDate == appointmentDay && cencel.Value[i].AppointmentTime == appointmentTime && cencel.Value[i].IsBooked)
                    {
                        cencel.Value[i].CancelAppointment(patient, appointmentDay, appointmentTime);
                        Console.WriteLine("Appointment is cancel");
                        return;
                    }
                }
            }
        }
        public void DisplayAvailableAppointments()
        {
            Console.WriteLine("............Display Available Appointments..........");
            if (AvailableAppointments.Count == 0)
            {
                Console.WriteLine("No available appointments at the moment.");
                return;
            }
            foreach (var doctorAppointments in AvailableAppointments)
            {
                Doctor doctor = doctorAppointments.Key;
                List<Appointment> appointments = doctorAppointments.Value;
                Console.WriteLine($"\nDoctor: Dr. {doctor.Name} (ID: {doctor.DoctorID})");
                Console.WriteLine("Available Appointments:");
                foreach (var appointment in appointments)
                {
                    Console.WriteLine($"- {appointment.AppointmentDate:MMMM dd, yyyy - h:mm tt}");
                }
            }
        }
        public void BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            Console.WriteLine("**************Book Appointment***********************");
            bool booked = false;
            if (AvailableAppointments.ContainsKey(doctor))
            {
                List<Appointment> appointments = AvailableAppointments[doctor];
                for (int i = 0; i < AvailableAppointments[doctor].Count; i++)
                {
                    if (!appointments[i].IsBooked && appointments[i].AppointmentTime == appointmentTime && appointments[i].AppointmentDate == appointmentDay)
                    {
                        appointments[i].ScheduleAppointment(patient, doctor, appointmentDay, appointmentTime, true);
                        Console.WriteLine($"{patient.Name} Assigned appointment on {appointmentDay.ToString("yyy-MM-dd")} at {appointmentTime}");
                        booked = true;
                    }
                }
                if (booked != true)
                    Console.WriteLine("Selected appointment is not available.");
            }
            else
            {
                Console.WriteLine("Doctor Not Found..");
            }
        }
    }
}