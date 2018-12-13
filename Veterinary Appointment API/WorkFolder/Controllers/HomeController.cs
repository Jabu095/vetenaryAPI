using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using RedirectResult = System.Web.Mvc.RedirectResult;

namespace Veterinary_Appointment_API.WorkFolder.Controllers
{
    /// <summary>
    /// This is an example controller.
    /// </summary>
    public class HomeController : Controller
    {

        
        public ActionResult Index()
        {
            return new RedirectResult("~/swagger/ui/index");
        }
    }
}
