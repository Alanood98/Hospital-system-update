using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public class OutPatient : Patient
    {
        public Clinic ClinicAssigned;

        public OutPatient(int pationid, string name, int age, Gender gender, string ailmenrt, Doctor doctor, Clinic clinicAssigned) : base(pationid, name, age, gender, ailmenrt,doctor)
        {
            ClinicAssigned = clinicAssigned;
        }


        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" pation id : {PatientID} , aliment : {Ailment} ,upcoming appointments :{ClinicAssigned} ");

        }
    }
}
