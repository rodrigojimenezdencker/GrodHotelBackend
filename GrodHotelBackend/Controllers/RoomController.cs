﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GrodHotelBackend.Models;

namespace GrodHotelBackend.Controllers
{
    public class RoomController : Controller
    {
        private readonly Context _context;

        public RoomController(Context context)
        {
            _context = context;
        } 

        // GET: Room by ID
        [HttpGet("/Room/{id:int?}")]
        public ActionResult Index(int id)
        {
            ViewBag.PageName = "room";
            Rooms room = _context.Rooms.Find(id);

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Room not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = room.Name;
            return View(room);
        }

        // GET: Room by slug
        [HttpGet("/Room/{name?}")]
        public ActionResult Index(string name)
        {
            ViewBag.PageName = "room";
            Rooms room = _context.Rooms.Where(room => room.Slug.Equals(name)).FirstOrDefault();

            if (room == null)
            {
                ViewBag.NotFoundMessage = "Room not found";
                Response.StatusCode = 404;
                return View("NotFound");
            }

            ViewBag.Available = room.Availability;
            ViewBag.Title = room.Name;
            return View(room);
        }
    }
}