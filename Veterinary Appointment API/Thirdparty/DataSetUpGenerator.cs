using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.Thirdparty.DataGeneration;
using Veterinary_Appointment_API.WorkFolder.Data_Services;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Customer;
using Veterinary_Appointment_API.WorkFolder.Data_Services.Pets;

namespace Veterinary_Appointment_API
{
    public sealed class DataSetUpGenerator
    {
       
        public DataSetUpGenerator()
        {
            Run();
        }

        public void Run()
        {
            foreach (var customer in new CreateCustomerData().Create())
            {
                new CustomerService().Create(customer);
            }

            foreach (var pet in new CreatePetData().Create())
            {
               new PetService().Create(pet);
            }
            foreach (var appoint in new CreateAppointmentData().Create())
            {
                new AppointmentService().Create(appoint);
            }

        }
    }
}