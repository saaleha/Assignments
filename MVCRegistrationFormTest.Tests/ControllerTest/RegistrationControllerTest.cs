using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVCRegistrationform.Controllers;
using Moq;
using MVCRegistrationform.Models;
using System.Collections;

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
       // [TestMethod]
        //public void EditDetailsTest()
        //{
        //    var view = controller.EditDetails(2) as ViewResult;
        //    Assert.AreEqual("EditDetails", view.ViewName);
           
        //}
        [TestMethod]
        public void RegistrationFormTest()
        {
          //Mock<MVCRegistrationform.RegistrationDetail> ca=new Mock<MVCRegistrationform.RegistrationDetail>();
            RegModel model = new RegModel();
            model.Name = "saleha";
            model.Email = "saleha472@gmail.com";
            model.Address = "BTM new";
            model.Phone = "9980795757";
           // arr.Add("");
          RegistrationController controller = new RegistrationController();
          controller.RegistrationForm(model);
 
        }
    }
}
