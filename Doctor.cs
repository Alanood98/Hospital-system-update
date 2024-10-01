
using System.Globalization;
using System.Reflection;

namespace HospitalClassINhernite
{
    public class Doctor:Person
    {


      

        public int DoctorID;
        public string Specialization;
        public static List<Patient> DoctorPatients = new List<Patient>();
        public static List<Room> AssignedClinics = new List<Room>();


        public Doctor(int did , string name,int age , Gender Gender,string spec):base(name, age, Gender)
        {
            DoctorID = did;
            Specialization = spec;
        }

        public void AddPatient(Patient patient)
        {

            DoctorPatients.Add(patient);
        }

        public void RemovePatient(Patient patient)
        {
            DoctorPatients.Remove(patient);
        }



        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" doctor id : {DoctorID } , Specialization : {Specialization} ");

        }
        public void AssignToClinic(Clinic clinic, DateTime day, TimeSpan period)
        {
            // Calculate the number of hours for the period
            int totalHours = (int)period.TotalHours;

            // Generate 1-hour slots for the period
            for (int i = 0; i < totalHours; i++)
            {
                // Create the start time for the slot
                DateTime appointmentTime = day.AddHours(i);

                // Create an appointment for this time slot
                Appointment appointment = new Appointment(null, this, appointmentTime, TimeSpan.FromHours(1), false); // Assuming the constructor requires Patient, Doctor, DateTime, TimeSpan, and a booked status

                // Add the appointment to the clinic's dictionary under this doctor
                if (clinic.AvailableAppointments.ContainsKey(this))
                {
                    clinic.AvailableAppointments[this].Add(appointment);
                }
                else
                {
                    // Create a new list if the doctor doesn't have appointments yet
                    clinic.AvailableAppointments[this] = new List<Appointment> { appointment };
                }

                Console.WriteLine($"Assigned Doctor {DoctorID} to clinic on {appointmentTime}");
            }
        }


        public void DisplayAssignedClinics() //Displays all clinics the doctor is assigned to.
        {
            if (AssignedClinics.Count == 0)
            {
                Console.WriteLine($"Doctor {DoctorID} has no clinics assigned.");
            }
            else
            {
                Console.WriteLine($"Doctor {DoctorID} is assigned to the following clinics:");
                foreach (var clinic in AssignedClinics)
                {
                    Console.WriteLine($"- Clinic ID: {clinic.AssignedClinic}, Name: {clinic.AssignedClinic}, Specialization: {clinic.AssignedClinic}");
                }
            }
        }


    }
}
