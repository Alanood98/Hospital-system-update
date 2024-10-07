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
        public Specialization nurseSpec;
        public enum Specialization
        {
            General, 
            Pediatrics, 
            Surgery
        }
        public static List<Patient> NursePatients = new List<Patient>();
    }
}
