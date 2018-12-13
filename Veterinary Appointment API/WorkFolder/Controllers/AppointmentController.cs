
using Helper;
using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using System.Web.Mvc;
using Veterinary_Appointment_API.Helpers;
using Veterinary_Appointment_API.Thirdparty.DataGeneration;
using Veterinary_Appointment_API.WorkFolder.Data_Services;

namespace Veterinary_Appointment_API.WorkFolder.Controllers
{
    /// <summary>
    /// Appointments 
    /// </summary>
    /// <seealso cref="Veterinary_Appointment_API.WorkFolder.Controllers.BaseController" />
    /// 
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AppointmentController : BaseController
    {
       private readonly IDataService DataService;

        public AppointmentController(IDataService dataService)
        {
            DataService = dataService;
        }


        /// <summary>Get appontment by id</summary>
        /// <param name="id">appointment id</param>
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseViewModel<AppointmentDetailViewModel>))]
        public IHttpActionResult Get(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return BadRequest("id required");
                }
                var response = DataService.AppontmentService.GetAppointmentById(id);
                
                return Ok(new ResponseViewModel<AppointmentDetailViewModel> { data = response, message = "successfull", statusCode = 200 });
            }catch(Exception ex)
            {
               
            }
            return BadRequest();
        }

        /// <summary>Get all appontments </summary>
        /// 
        [System.Web.Http.HttpGet]
        [ResponseType(typeof(ResponseViewModel<ICollection<AppontmentResponseViewModel>>))]
        public IHttpActionResult Get()
        {
            try
            {

                var response = DataService.AppontmentService.GetAllAppointments();

                return Ok(new ResponseViewModel<ICollection<AppontmentResponseViewModel>> { data = response, message = "successfull", statusCode = 200 });
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }


        /// <summary>Cancel an appointment</summary>
        /// <param name="Id">appointmentID</param>
        [System.Web.Http.HttpDelete]
        [ResponseType(typeof(ResponseViewModel<bool>))]
        public IHttpActionResult Delete(string Id)
        {
            try
            {

                var response = DataService.AppontmentService.Cancel(Id);

                return Ok(new ResponseViewModel<bool> { data = response, message = "successfull", statusCode = 200 });
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }
    }
}