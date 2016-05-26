using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVCRegistrationform.Controllers;

namespace MVCRegistrationForm.Tests.ControllerTest
{
    [TestClass]
    public class RegistrationControllerTest
    {
        RegistrationController controller = new RegistrationController();
        [TestMethod]
        public void ViewRegistrationForm()
        {

            var Actual = controller.RegistrationForm() as ViewResult;
            //Assert.AreEqual("", Actual);
            //var s= Actual.ViewName;
            Assert.IsNotNull(Actual);
            Assert.AreEqual("RegistrationForm", Actual.ViewName);
        }
        [TestMethod]
        public void DeleteDetailsRedirectTest()
        {
            var actual = controller.DeleteDetails(1) as RedirectToRouteResult;
            Assert.AreEqual("RegistrationDetails", actual.RouteValues["action"]);
            //Assert.AreEqual("Registration", actual.RouteName["Controller"]);

        }
        [TestMethod]
        public void EditDetailsTest()
        {
            var view = controller.EditDetails(2) as ViewResult;
            Assert.AreEqual("EditDetails", view.ViewName);
           
        }
    }
}
