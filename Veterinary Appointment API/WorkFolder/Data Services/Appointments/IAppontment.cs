using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services.Appointments
{
    public interface IAppontment
    {
        void Create(string data);
        bool Cancel(string id);
        ICollection<AppontmentResponseViewModel> GetAllAppointments();
        AppointmentDetailViewModel GetAppointmentById(string Id);

    }
}
