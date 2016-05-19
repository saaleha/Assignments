using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCRegistrationform.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult CheckError()
        {
            throw new Exception("This is a elmah example of a controller throwing an error");
        }
    }
}
