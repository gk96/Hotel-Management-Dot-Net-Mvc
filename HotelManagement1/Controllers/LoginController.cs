using Application.Services;
using Data;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement1.Controllers
{
    public class LoginController : Controller
    {
        private UserService us=new UserService();
       
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Authorize(User userModel)
            {
                var userDetails = us.UserCheck(userModel.Email,userModel.Password);
                //var userDetails = db.UserList.Where(x => x.Email == userModel.Email && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                    {
                //userModel.LoginErrorMessage = "Wrong user name or password";
                        ViewBag.Msg = "Invalid Credentials";
                        TempData["Message"] = "Invalid Credentials";
                        return RedirectToAction("Index","Login");
                    }
                else
                    {
                        TempData.Remove("Message");
                        Session["userID"] = userDetails.UserId;
                        Session["userName"] = userDetails.Name;
                        Session["userIsAdmin"] = userDetails.IsAdmin;
                                   
                        if (userDetails.IsAdmin == true)
                        {
                            return RedirectToAction("Index", "Rooms");
                        }
                        else
                        {
                            return RedirectToAction("Index", "RoomSelect");
                        }
                    }

        }
        // GET: Users/Create
        public ActionResult RegisterUser()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterUser([Bind(Include = "UserId,Name,Email,Password,IsAdmin")] User user)
        {
            if (ModelState.IsValid)
            {
                us.InsertUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

    }

}
