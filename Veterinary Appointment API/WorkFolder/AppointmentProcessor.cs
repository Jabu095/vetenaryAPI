using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Veterinary_Appointment_API.Thirdparty;
using Veterinary_Appointment_API.Thirdparty.DataGeneration;
using Veterinary_Appointment_API.WorkFolder.Data_Services;

namespace Veterinary_Appointment_API.WorkFolder
{
    public partial class AppointmentProcessor : IAppointmentProcessor
    {
        public AppointmentProcessor()
        {
            
        }

        /// <summary>
        /// Process_IncomingAppointment method for processing (reading, customizing and saving) the raw appointment data.
        /// </summary>
        /// <param name="rawAppointmentData">Incoming appointment data</param>
        public void Process_IncomingAppointment(string rawAppointmentData)
        {

        }
    }
}