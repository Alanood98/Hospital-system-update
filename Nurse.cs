using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public class Nurse : Person
    {
        public int NurseID;
        public Clinic AssignedClinic;
        public Specialization NurseSpec;
        public enum Specialization
        {
            General, 
            Pediatrics, 
            Surgery
        }
        public static List<Patient> NursePatients = new List<Patient>();

        public Nurse(int nurseID, Clinic assignedClinic, Specialization nurseSpec,string name,int age,Gender gender) : base(name, age, gender)
        {
            NurseID = nurseID;
            AssignedClinic = assignedClinic;
            NurseSpec = nurseSpec;

        }
        public void AssistDoctor(Doctor doctor, Patient patient)
        {

        }
        public void CheckVitals(Patient patient)
        {

        }

        public void AdministerMedication(Patient patient, string medication)
        {

        }

        
    }
}
