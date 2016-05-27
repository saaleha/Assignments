using AutoMapper;
using MVCRegistrationform.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCRegistrationform.Filters;
using System.Web.Security;
using MVCRegistrationform.ViewModel;

namespace MVCRegistrationform.Controllers
{
    [ExceptionAttribute]
    [RoutePrefix("Registration")]
    public class RegistrationController : Controller
    {
        private SalesERPContext SalesERPContext;

        public RegistrationController()
        {
            this.SalesERPContext = new SalesERPContext();
        }
        //
        // GET: /Registration/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistrationForm()
        {
            return View("RegistrationForm");
        }

        [HttpPost]
        public ActionResult RegistrationForm(RegModel model)
        {
            if (!ModelState.IsValid)
                return View();

            RegistrationDetail Details = new RegistrationDetail();
            Mapper.CreateMap<RegModel, RegistrationDetail>();
            Mapper.Map(model, Details);
            SalesERPContext.RegistrationDetails.Add(Details);

            SalesERPContext.SaveChanges();
            return RedirectToAction("RegistrationDetails");
        }
        // [DebugFilterAttribute]
        public ActionResult RegistrationDetails()
        {

            // Logic to display the entire list of objects pulled from database through entity framework. 
            //var Data = SalesERPContext.RegistrationDetails;
            RegDetailsViewModel obj = new RegDetailsViewModel();
            obj.Details = SalesERPContext.RegistrationDetails.ToList();
            //ViewBag.UserDetails = Data;
            return View("RegistrationDetails", obj);
        }

        public ActionResult DeleteDetails(int id)
        {
            var DeleteDetails = (from s1 in SalesERPContext.RegistrationDetails where s1.Id== id select s1).FirstOrDefault();
            SalesERPContext.RegistrationDetails.Remove(DeleteDetails);
            SalesERPContext.SaveChanges();
            return RedirectToAction("RegistrationDetails");

        }
        public ActionResult EditDetails(int id)
        {
            var std = SalesERPContext.RegistrationDetails.Find(id);
            //var std = 1;
            return View("EditDetails", std);
        }
        [HttpPost]
        public ActionResult EditDetails(int id, RegistrationDetail details)
        {
            if (!ModelState.IsValid)
                return View();
            if (id != 0)
            {
                var std = SalesERPContext.RegistrationDetails.Find(id);
                TryUpdateModel(std);
                SalesERPContext.SaveChanges();
            }
            return RedirectToAction("RegistrationDetails");
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel login, string returnUrl, string command)
        {

            if (command == "Login")
            {
                if (login.UserName != null && login.Password != null)
                {
                    if (ModelState.IsValidField(login.UserName) && ModelState.IsValidField(login.Password))
                    {

                        //var isMember = Membership.ValidateUser(login.UserName, login.Password);
                        //if (isMember)
                        //{
                        //    FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                        //    Response.Redirect(Request.RawUrl);
                        //}        
                        //else
                        //{
                        //    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                        //}
                        var v = SalesERPContext.Logins.Where(a => a.UserName.Equals(login.UserName) && a.Password.Equals(login.Password)).FirstOrDefault();
                        if (v != null)
                        {
                            FormsAuthentication.SetAuthCookie(login.UserName, login.RememberMe);
                            Session["LogedUserID"] = v.UserName.ToString();
                            Session["LogedUserFullname"] = v.Password.ToString();
                            return RedirectToAction("RegistrationDetails", "Registration");
                        }
                        else
                        {
                            ModelState.AddModelError("", "The user name or password provided is incorrect.");
                            return View(login);
                        }
                    }


                }
                else if (command == "SignUp")
                {
                    if (ModelState.IsValid)
                    {
                        Login Register = new Login();

                        Mapper.CreateMap<LoginModel, Login>();
                        Mapper.Map(login, Register);
                        SalesERPContext.Logins.Add(Register);

                        SalesERPContext.SaveChanges();
                        return RedirectToAction("RegistrationDetails");
                    }

                }

            }
            return View(login);


        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            //TempData["LogoutMessage"] = "You are now successful loged out.";
            return RedirectToAction("Login");

        }
        //ViewTemplatates
        public ActionResult ViewLoginDetails(int id)
        {
            var std = SalesERPContext.Logins.Find(id);
            return View(std);
        }

    }
}
