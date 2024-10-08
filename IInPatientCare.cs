using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public interface IInPatientCare: IPatientCare
    {
        void AssigningRooms(InPatient inPatient, Room room);
        void DischargingPatients(InPatient inPatient, Room room);
        void CheckVitals(Patient patient);


    }
}