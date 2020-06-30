using NotificationSystem.DTO.Models;
using NotificationSystem.DTO.Services;
using System;
using System.Web.Mvc;

namespace NotificationSystem.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Login")]
        public ActionResult Login(Employee employee)
        {
            LoginService loginService = new LoginService();

            if (!string.IsNullOrEmpty(employee.Email) && !string.IsNullOrEmpty(employee.Password))
            {
                var result = loginService.ValidateUser(employee);
                try
                {
                    if (result!=null)
                    {
                        Session["EmployeeId"] = result.EmployeeId.ToString();
                        Session["IsLogged"] = true;
                        if (employee.Email.Equals("admin@nagarro.com"))
                            return RedirectToAction("Index", "Admin");
                        else
                            return RedirectToAction("Event", "Home");

                    }
                    else
                    {
                        throw new Exception("Invalid Credentials");
                    }
                }
                catch (Exception e)
                {
                    ModelState.AddModelError("", e.Message);
                    return View();
                }
            }
            return View();

        }
        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            // Redirecting to Login page after deleting Session
            return RedirectToAction("Login", "Login");
        }
    }
}