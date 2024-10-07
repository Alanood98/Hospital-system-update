using System.Numerics;
using System.Xml.Linq;
using static HospitalClassINhernite.Appointment;
using static HospitalClassINhernite.Patient;
namespace HospitalClassINhernite
{
    public class Appointment: IDisplayInfo
    {
        public Patient patient;
        public Doctor doctor;
        public DateTime? AppointmentDate;
        public TimeSpan AppointmentTime;
        public bool IsBooked = false;
        public Appointment(Patient patient, Doctor doctor, DateTime dateappo, TimeSpan appointmentTime, bool isBooked)
        {
            this.patient = patient;
            this.doctor = doctor;
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = isBooked;
        }
        public void ScheduleAppointment(Patient patient, Doctor doctor, DateTime dateappo, TimeSpan appointmentTime, bool IsBooked)
        {
            this.patient = patient;
            AppointmentDate = dateappo;
            AppointmentTime = appointmentTime;
            IsBooked = true;  // Mark as booked when scheduled
        }
        public void CancelAppointment(Patient patient, DateTime date, TimeSpan period)
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
        public interface IDisplayInfo
        {
            void DisplayInfo();


        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Appointment scheduled for {patient.Name} on {AppointmentDate.Value:MMMM dd, yyyy} at {AppointmentTime:hh\\:mm}");
        }

        public interface ISchedulable
        {
            void ScheduleAppointment();
            void CancelAppointment();

        }
    }
}