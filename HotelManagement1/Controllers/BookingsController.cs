using Application;
using Application.Services;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HotelManagement1.Controllers
{
    public class BookingsController : Controller
    {
        private RoomService rs = new RoomService();

        // GET: Bookings
        public ActionResult Index()
        {
            //var roomList = uow.UserRepository.GetByID((int)Session["userID"]);
            return View(rs.GetRoomsByUserId((int)Session["userID"]));
        }
        [HttpGet]
        public ActionResult Checkout(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Room room = rs.GetRoomByID(id);
            if (room == null)
            {
                return HttpNotFound();
            }
            // ViewBag.UserId = new SelectList(uow.UserRepository.GetAll(), "UserId", "Name", room.UserId);
            return View(room);
        }
        [HttpPost]
        public ActionResult Checkout([Bind(Include = "Id,Name,Price,IsOccupied,CheckInDate,CheckOutDate,UserId")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.IsOccupied = false;
                room.UserId = null;
                room.CheckInDate = null;
                room.CheckOutDate = null;                
                rs.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.UserList, "UserId", "Name", room.UserId);
            return View(room);
        }
    }
}