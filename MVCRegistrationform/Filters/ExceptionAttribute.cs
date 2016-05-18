using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;

namespace MVCRegistrationform.Filters
{
    public class ExceptionAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //throw new NotImplementedException();
            if (filterContext.ExceptionHandled)
            {
                return;
            }
            else
            {
                string actionname = filterContext.RouteData.Values["action"].ToString();
                Type controllerType = filterContext.Controller.GetType();
                //var method = controllerType.GetMethod(actionname);
                //var returnType = method.ReturnType;
                Type ExceptionType = filterContext.Exception.GetType();
                //if (returnType.Equals(typeof(ActionResult)) || (returnType).IsSubclassOf(typeof(ActionResult)))
                ////if(returnType.GetMethod("Parse", new [] {typeof(string)})
                //{

                //}

                if (ExceptionType == typeof(SqlException))
                {

                }

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml"
                };

            }
            filterContext.ExceptionHandled = true;
        }
    }
}