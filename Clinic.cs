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
        public List<Room> Rooms;
        public Dictionary<Doctor, List<Appointment>> AvailableAppointments;

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
            int numberOfSlots = (int)period.TotalHours;

            List<Appointment> newAppointments = new List<Appointment>();

            for (int i = 0; i < numberOfSlots; i++)
            {
                DateTime appointmentTime = appointmentDay.AddHours(i);
                Appointment appointment = new Appointment(null, doctor, appointmentDay, period,  false);  // Null patient initially

                newAppointments.Add(appointment);
            }

            if (AvailableAppointments.ContainsKey(doctor))
            {
                AvailableAppointments[doctor].AddRange(newAppointments);
            }
            else
            {
                AvailableAppointments[doctor] = newAppointments;
            }

            Console.WriteLine($"Added {numberOfSlots} available appointments for Dr. {doctor.Name} on {appointmentDay.ToShortDateString()}");
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

        public bool BookAppointment(Patient patient, Doctor doctor, DateTime appointmentDay, TimeSpan appointmentTime)
        {
            if (AvailableAppointments.ContainsKey(doctor))
            {
                List<Appointment> doctorAppointments = AvailableAppointments[doctor];

                foreach (var availableAppointment in doctorAppointments)
                {
                    if (availableAppointment.AppointmentDate.HasValue &&
                        availableAppointment.AppointmentDate.Value.Date == appointmentDay.Date &&
                        availableAppointment.AppointmentTime == appointmentTime)
                    {
                        if (!availableAppointment.IsBooked)
                        {
                            availableAppointment.patient = patient;
                            availableAppointment.IsBooked = true;

                            Console.WriteLine($"Appointment booked for {patient.Name} with Dr. {doctor.Name} on {appointmentDay:MMMM dd, yyyy} at {appointmentTime:hh\\:mm}.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine("The selected time slot is already booked.");
                            return false;
                        }
                    }
                }

                Console.WriteLine("The selected time slot is not available.");
                return false;
            }
            else
            {
                Console.WriteLine("No available appointments for the selected doctor.");
                return false;
            }
        }


    }

}

