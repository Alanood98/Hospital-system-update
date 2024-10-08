using System.Globalization;
using System.Numerics;
using System.Reflection;
namespace HospitalClassINhernite
{
    public class Doctor : Person , IOutPatientCare, IInPatientCare
    {
        public int DoctorID;
        public enum DocSpec
        {
            Cardiology, Neurology, Dermatology
        }
        public DocSpec Specialization;
        public List<Patient> DoctorPatients = new List<Patient>();
        public List<Clinic> AssignedClinics = new List<Clinic>();
        public Nurse nurse;
        public Doctor(int did, string name, int age, Gender Gender, DocSpec specialization) : base(name, age, Gender)
        {
            this.DoctorID = did;
            this.Specialization = specialization;
        }
        public void AddPatient(Patient patient)
        {
            DoctorPatients.Add(patient);
        }
        public void RemovePatient(Patient patient)
        {
            DoctorPatients.Remove(patient);
        }
        //public override void DisplayInfo()
        //{
        //    base.DisplayInfo();
        //    Console.WriteLine($" doctor id : {DoctorID} , Specialization : {Specialization} ");
        //}
        //Assigns the doctor to a specific clinic
        public void AssignToClinic(Clinic clinic, DateTime day, TimeSpan period)
        {
            if (!AssignedClinics.Contains(clinic))
            {
                clinic.AddAvailableAppointment(this, day, period);
                AssignedClinics.Add(clinic);
            }
            else
            {
                Console.WriteLine("the clinic in the list");
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
                    Console.WriteLine($" Name: {clinic.ClinicName}, Specialization: {clinic.ClinicSpec}");
                }
            }
        }
        public void setnurse(Nurse nurse)
        {
            this.nurse = nurse;
        }

        public void CheckVitals(Patient patient)
        {
            double Temperature;
            int HeartRate;
            int BloodPressure;
            Console.WriteLine($"Entering vitals for patient: {patient.Name}");
            Console.Write("Enter Temperature: ");
            patient.Temperature = Double.Parse(Console.ReadLine());
            Console.Write("Enter Heart Rate: ");
            patient.HeartRate = int.Parse(Console.ReadLine());
            Console.Write("Enter Blood Pressure: ");
            patient.BloodPressure = int.Parse(Console.ReadLine());
            Console.WriteLine("\nVital signs updated.");
        
    }

    }
}