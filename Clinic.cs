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
        public bool isBooked = true;
        public enum ClinicSpecialization { Cardiology, Neurology, Dermatology }
        public List<Room> Rooms = new List<Room>();
        public Dictionary<Doctor, List<Appointment>> AvailableAppointments = new Dictionary<Doctor, List<Appointment>>();

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
            Rooms.Add(room);
        }

        public void AddAvailableAppointment(Doctor doctor, DateTime appointmentDay, TimeSpan period)
        {
            TimeSpan start = new TimeSpan(9, 0, 0);
            if (!AvailableAppointments.ContainsKey(doctor))
            {
                AvailableAppointments[doctor] = new List<Appointment>();
                for (int i = 0; i < period.TotalHours; i++)
                {
                    Appointment appointment = new Appointment();
                    appointment.ScheduleAppointment(null, appointmentDay, start.Add(new TimeSpan(i, 0, 0)), false);
                    AvailableAppointments[doctor].Add(appointment);
                    Console.WriteLine($"Appointment Scheduled for {doctor.Name} in {appointmentDay.AddHours(i).ToString("yyy-MM-dd")}  at {start.Add(new TimeSpan(i, 0, 0))}");
                }
            }
            else
            {
                Console.WriteLine($"{doctor.Name} Not Available to  Schedule Appointment in this Clinic");
            }
            Console.WriteLine("**************************************************");
        }

        public void CancelAppointment(Patient patient, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            foreach (var cancel in AvailableAppointments)
            {
                //Iterating Through Appointments:
                for (int i = 0; i < cancel.Value.Count; i++)
                {
                    if (cancel.Value[i].AppointmentDate == appointmentDay && cancel.Value[i].AppointmentTime == appointmentTime && cancel.Value[i].IsBooked)
                    {
                        cancel.Value[i].CancelAppointment(appointmentDay, appointmentTime);
                        return;
                    }
                }
            }
        }



        public void DisplayAvailableAppointments()
        {
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
            bool flage = false;
            if (AvailableAppointments.ContainsKey(doctor))
            {
                List<Appointment> appointments = AvailableAppointments[doctor];
                for (int i = 0; i < AvailableAppointments[doctor].Count; i++)
                {
                    if (!appointments[i].IsBooked && appointments[i].AppointmentTime == appointmentTime && appointments[i].AppointmentDate == appointmentDay)
                    {
                        appointments[i].ScheduleAppointment(patient, appointmentDay, appointmentTime, true);
                        Console.WriteLine($"{patient.Name} Assigned appointment on {appointmentDay.ToString("yyy-MM-dd")} at {appointmentTime}");
                        flage = true;
                    }
                }
                if (flage != true)
                    Console.WriteLine("Selected appointment is not available.");
            }
            else
            {
                Console.WriteLine("Doctor Not Found..");
            }
        }
        //public void BookAppointment(Patient patient, DateTime appointmentDay, TimeSpan appointmentTime)
        //{
        //    foreach (var b in AvailableAppointments)
        //    {
        //        for (int i = 0; i < b.Value.Count; i++)
        //        {
        //            if (b.Value[i].AppointmentDate == appointmentDay && b.Value[i].AppointmentTime == appointmentTime && !b.Value[i].IsBooked)
        //            {
        //                b.Value[i].ScheduleAppointment(patient, appointmentDay, appointmentTime, isBooked);
        //                return;
        //            }
        //        }
        //    }
        //}


    }

}