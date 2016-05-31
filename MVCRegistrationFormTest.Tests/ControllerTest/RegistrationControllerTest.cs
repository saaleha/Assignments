using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using MVCRegistrationform.Controllers;
using Moq;
using MVCRegistrationform.Models;
using System.Collections;
using MVCRegistrationform;
using System.Collections.Generic;
using MVCRegistrationform.ViewModel;

namespace MVCRegistrationForm.Tests.ControllerTest
{
    [TestClass]
    public class RegistrationControllerTest
    {
        RegistrationController controller = new RegistrationController();
        Mock<SalesERPContext> mockdb = new Mock<SalesERPContext>();
        FakeDbSet<RegistrationDetail> fakedbset = new FakeDbSet<RegistrationDetail>();
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
        public void EditDetailsTest()
        {
            var view = controller.EditDetails(2) as ViewResult;
            Assert.AreEqual("EditDetails", view.ViewName);

        }
        [TestMethod]
        public void RegistrationFormTest()
        {
            //Mock<MVCRegistrationform.RegistrationDetail> ca=new Mock<MVCRegistrationform.RegistrationDetail>();
            RegModel model = new RegModel();
            model.Name = "saleha new added";
            model.Email = "saleha472@gmail.com";
            model.Address = "BTM new";
            model.Phone = "9980795757";
            Mock<SalesERPContext> mockContext = new Mock<SalesERPContext>();
            FakeDbSet<RegistrationDetail> rd = new FakeDbSet<RegistrationDetail>();
            mockContext.Setup(DBContext => DBContext.RegistrationDetails).Returns(rd);
            mockContext.Setup(x => x.SaveChanges()).Returns(1);
            controller.SalesERPContext = mockContext.Object;
            //var dbSet = new Mock<DbSet<T>>();
            //dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            var Result = controller.RegistrationForm(model) as RedirectToRouteResult;
            //mockContext.Verify(r => r.SaveChanges());

            Assert.AreEqual("RegistrationDetails", Result.RouteValues["action"]);

        }
        [TestMethod]
        public void DeleteDetailsRedirectTest(int id)
        {
            id = 1;
            var actual = controller.DeleteDetails(id) as RedirectToRouteResult;
            Assert.AreEqual("RegistrationDetails", actual.RouteValues["action"]);
            //Assert.AreEqual("Registration", actual.RouteName["Controller"]);

        }
        [TestMethod]
        public void RegistrationDetailsTest()
        {
            //var details = controller.RegistrationDetails() as ViewResult;

            mockdb.Setup(db => db.RegistrationDetails).Returns(fakedbset);
            controller.SalesERPContext = mockdb.Object;
            var output = controller.RegistrationDetails() as ViewResult;
            Assert.AreEqual("RegistrationDetails", output.ViewName);
        }
        [TestMethod]
        public void LoginTest(Login login)
        {
            login.UserName = "saleha";
            login.Password = "saleha";
            FakeDbSet<Login> fb = new FakeDbSet<Login>();
            mockdb.Setup(db => db.Logins).Returns(fb);
            var output = controller.Login() as ViewResult;
            Assert.AreEqual("", output.ViewName);
        }
    }
}
