using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalClassINhernite
{
    public interface ISchedulable
    {
        void ScheduleAppointment();
        void CancelAppointment();

    }
}