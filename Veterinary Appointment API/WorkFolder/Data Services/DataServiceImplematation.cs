using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Appointments;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Customer;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Pets;

namespace Veterinary_Appointment_API.WorkFolder.Data_Services
{
    public class DataServiceImplematation : IDataService
    {
        public IAppontment AppontmentService => new AppointmentService();

        public ICustomerService CustomerService => new CustomerService();

        public IPetService PetService => new PetService();
    }
}