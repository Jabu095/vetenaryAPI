using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Appointments;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Customer;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Pets;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services
{
    public interface IDataService
    {
        ICustomerService CustomerService { get; }
        IPetService PetService { get; }
        IAppontment AppontmentService { get; }
    }
}
