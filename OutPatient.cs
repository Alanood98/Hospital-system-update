using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public class OutPatient : Patient
    {
        public Clinic ClinicAssigned;

        public OutPatient(int pationid, string name, int age, Gender gender, string ailmenrt, Doctor doctor, Clinic clinicAssigned) : base(pationid, name, age, gender, ailmenrt, doctor)
        {
            ClinicAssigned = clinicAssigned;
        }

        public void BookAppointment(Clinic clinic, DateTime appointmentDay, TimeSpan appointmentTime , Patient patient,Doctor doctor )
        {
            clinic.BookAppointment( patient,  doctor,  appointmentDay,appointmentTime);
        }

        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($" pation id : {PatientID} , aliment : {Ailment} ,upcoming appointments :{ClinicAssigned} ");

        }

        public interface IOutPatientCare : IPatientCare
        {
            void BookAppointment();
           

        }


    }
}