using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static HospitalClassINhernite.Appointment;
using static HospitalClassINhernite.InPatient;
using static HospitalClassINhernite.Patient;
namespace HospitalClassINhernite
{
    public class Nurse : Person, IDisplayInfo, IOutPatientCare, IInPatientCare
    {
        public int NurseID;
        public Clinic AssignedClinic;
        public Specialization NurseSpec;
        public List<Clinic> AssignedClinics = new List<Clinic>();
        public enum Specialization
        {
            General,
            Pediatrics,
            Surgery
        }
        public List<Patient> NursePatients;
        public Doctor doctor;
        public Nurse(int nurseID, Clinic assignedClinic, Specialization nurseSpec, string name, int age, Gender gender) : base(name, age, gender)
        {
            NurseID = nurseID;
            AssignedClinic = assignedClinic;
            NurseSpec = nurseSpec;
        }
        public void AssistDoctor(Doctor doctor, Patient patient)
        {
            this.doctor = doctor;
            NursePatients.Add(patient);
            doctor.setnurse(this);
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
        public void AdministerMedication(Patient patient, string medication)
        {
            patient.Medications.Add(medication);
        }
        public void DisplayInfo()
        {
            Console.WriteLine($" nurse name : {Name} , Specialization : {NurseSpec},Clinic:{AssignedClinic}");
        }
      


        public void AssignedTOClinic(Clinic clinic, DateTime day, TimeSpan period)
        {
            // Check if the nurse is already assigned to the clinic
            if (!AssignedClinics.Contains(clinic))
            {
                // Assign the nurse to the clinic
                AssignedClinics.Add(clinic);

                // Log the assignment
                Console.WriteLine($"Nurse {Name} is now assigned to the clinic {clinic.ClinicName} starting from {day.ToShortDateString()} for the period {period}.");

                // Check if a doctor is available to assist within the clinic
                if (doctor != null)
                {
                    // Log the nurse-doctor association for the clinic
                    Console.WriteLine($"Nurse {Name} is assisting Doctor {doctor.Name} in clinic {clinic.ClinicName}.");

                    // Call the clinic method to assist the doctor and patient in the clinic
                    clinic.AssistDoctor(this, doctor, patient);
                }
                else
                {
                    // If no doctor is currently assigned
                    Console.WriteLine("No doctor assigned for this nurse yet.");
                }
            }
            else
            {
                // If the nurse is already assigned to this clinic
                Console.WriteLine($"Nurse {Name} is already assigned to the clinic {clinic.ClinicName}.");
            }
        }

    }
}