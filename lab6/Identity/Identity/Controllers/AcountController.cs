using Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [AllowAnonymous]
    public class AcountController : Controller
    {
        // GET: Acount
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Client client)
        {
            //check if valid user (ModelState.IsValid)
            //Insert newUser into DB
            //Create User Identity for this user Using Claims (Name, Email, Password, Phone)
            //Owin Cookie middleware, user identity to create cookie for this user to authenticate him

            // Redirect to Home/Index

            if (ModelState.IsValid)
            {
                ClientContext context = new ClientContext();

                context.Clients.Add(client);
                context.SaveChanges();

                var userIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim("Name", client.ClientName),
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                //Owin Authentication manager
                Request.GetOwinContext().Authentication.SignIn(userIdentity);

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Client client)
        {
            //get User from Db
            //check user is not null
            //if not null { OWIN }
            //else return view

            ClientContext context = new ClientContext();

            var loggedUser = context.Clients.FirstOrDefault(
                i => i.Email == client.Email && i.Password == client.Password);

            if (loggedUser != null)
            {
                var signInIdentity = new ClaimsIdentity(new List<Claim>()
                {
                    new Claim(ClaimTypes.Email, client.Email),
                    new Claim("Password", client.Password)
                }, "AppCookie");

                //Owin Authentication manager
                Request.GetOwinContext().Authentication.SignIn(signInIdentity);
                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("Password", "Email or password incorrect");

                return View();
            }
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("AppCookie");
            return RedirectToAction("Login");
        }
    }
}