using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;
using Data.Models;
using Application.Services;
using Application;

namespace HotelManagement1.Controllers
{
    public class RoomsController : Controller
    {
        
        private RoomService rs = new RoomService();

        // GET: Rooms
        public ActionResult Index()
        {
            //var roomList = db.RoomList.Include(r => r.User);
            return View(rs.GetAllRooms());
        }

        // GET: Rooms/Details/id
        public ActionResult Details(int? id)
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
            return View(room);
        }

        // GET: Rooms/Create
        public ActionResult Create()
        {
           // ViewBag.UserId = new SelectList(uow.UserRepository.GetAll(), "UserId", "Name");
            ViewBag.UserId = new SelectList(rs.ReturnUser(), "UserId", "Name");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,IsOccupied,CheckInDate,CheckOutDate,UserId")] Room room)
        {
            if (ModelState.IsValid)
            {
                rs.InsertRoom(room);
                return RedirectToAction("Index");
            }
            User u = new User();
           // ViewBag.UserId = new SelectList(uow.UserRepository.GetAll(), "UserId", "Name", room.UserId);
            ViewBag.UserId = new SelectList(rs.ReturnUser(), "UserId", "Name");
            return View(room);
        }

        // GET: Rooms/Edit/id
        public ActionResult Edit(int? id)
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
            //ViewBag.UserId = new SelectList(uow.UserRepository.GetAll(), "UserId", "Name", room.UserId);
            ViewBag.UserId = new SelectList(rs.ReturnUser(), "UserId", "Name");
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,IsOccupied,CheckInDate,CheckOutDate,UserId")] Room room)
        {
            if (ModelState.IsValid)
            {
                rs.UpdateRoom(room);
                return RedirectToAction("Index");
            }
            //ViewBag.UserId = new SelectList(uow.UserRepository.GetAll(), "UserId", "Name", room.UserId);
            ViewBag.UserId = new SelectList(rs.ReturnUser(), "UserId", "Name");
            return View(room);
        }

        // GET: Rooms/Delete/5
        public ActionResult Delete(int? id)
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
            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = rs.GetRoomByID(id);
            rs.DeleteRoom(room);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rs.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
