using System.Numerics;
using System.Runtime.CompilerServices;

namespace HospitalClassINhernite
{
    public class Appointment
    {

        public Patient patient=null;
        public Doctor doctor;
        public DateTime? AppointmentDate;
        public TimeSpan AppointmentTime;
        public bool IsBooked;
        public Appointment(Patient patient, Doctor doctor, DateTime dateappo, TimeSpan appointmentTime, bool isBooked)
        {
            this.patient = patient;
            this.doctor = doctor;
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = isBooked;
        }
        public Appointment()
        {
            
        }

        public void ScheduleAppointment(Patient patient, DateTime? dateappo, TimeSpan appointmentTime,bool IsBooked)
        {
            this.patient = patient;
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = true;  // Mark as booked when scheduled
        }
        public void ScheduleAppointment( DateTime? dateappo, TimeSpan appointmentTime)
        {
            
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
       
        }

        public void CancelAppointment(DateTime date, TimeSpan period)
        {
            AppointmentDate = null;
            AppointmentTime = TimeSpan.Zero;  // Clear the appointment time
            this.patient = null;
            IsBooked = false; // Mark as not booked

        }


        public void GetAppointmentDetails()
        {
            Console.WriteLine($"Appointment scheduled for {patient.Name} on {AppointmentDate.Value:MMMM dd, yyyy} at {AppointmentTime:hh\\:mm}");
        }




    }
}