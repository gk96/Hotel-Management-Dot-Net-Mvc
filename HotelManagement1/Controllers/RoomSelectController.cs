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
    public class RoomSelectController : Controller
    {
        private RoomService rs = new RoomService();
        
        // GET: RoomSelect
        public ActionResult Index()
        {
            return View(rs.GetAllRooms());
        }
        [HttpGet]
        public ActionResult ConfirmRoom(int? id)
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
        public ActionResult ConfirmRoom([Bind(Include = "Id,Name,Price,IsOccupied,CheckInDate,CheckOutDate,UserId")] Room room)
        {
            
            if (ModelState.IsValid)
            {
                room.IsOccupied = true;
                room.UserId = Convert.ToInt32(Session["userID"]);
                //System.Diagnostics.Debug.WriteLine(rs.GetPrice((int)room.Id));
                rs.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(db.UserList, "UserId", "Name", room.UserId);
            return View(room);
        }
    }
}