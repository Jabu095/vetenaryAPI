using Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Veterinary_Appointment_API.Helpers;

namespace Veterinary_Appointment_API.WorkFolder.Controllers
{
    public class BaseController: ApiController
    {

       
        protected HttpResponseMessage EasyServerError(Exception ex)
        {
            if (ex is BadRequestException)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,ex.Message.ToString());
            if (ex is TimeoutException)
                return Request.CreateErrorResponse(HttpStatusCode.RequestTimeout, ex.Message.ToString());
            if (ex is BadGateWayException)
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, ex.Message.ToString());
            if (ex is ServerErrorException)
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
            if (ex is ServiceUnavailableException)
                return Request.CreateErrorResponse(HttpStatusCode.ServiceUnavailable, ex.Message.ToString());
            if (ex is ForbiddenException)
            {
                return Request.CreateErrorResponse(HttpStatusCode.Forbidden, ex.Message.ToString());
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message.ToString());
        }
    }
}