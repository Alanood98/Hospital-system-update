
using System.Numerics;

namespace HospitalClassINhernite
{
    public class Appointment
    {

        public Patient patient;
        public Doctor doctor;
        public DateTime ?AppointmentDate;
        public TimeSpan AppointmentTime;
        public bool IsBooked;
        public Appointment(Patient patient, Doctor doctor,DateTime dateappo, TimeSpan appointmentTime , bool isBooked)
        {
            this.patient = patient;
            this.doctor = doctor;
            AppointmentDate=dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = isBooked;
        }

        public void ScheduleAppointment(DateTime? dateappo, TimeSpan appointmentTime)
        {
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = true;  // Mark as booked when scheduled
        }


        public void CancelAppointment()
        {
            AppointmentDate = null;
            AppointmentTime = TimeSpan.Zero;  // Clear the appointment time
            IsBooked = false; // Mark as not booked

        }


        public void GetAppointmentDetails()
        {
            Console.WriteLine($"Appointment scheduled for {patient.Name} on {AppointmentDate.Value:MMMM dd, yyyy} at {AppointmentTime:hh\\:mm}");
        }
       



    }
}
