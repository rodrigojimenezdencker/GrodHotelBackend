using GrodHotelBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GrodHotelBackend.Controllers
{
    public class ApiSearchController : Controller
    {
        private readonly Context _context;

        public ApiSearchController(Context context)
        {
            _context = context;
        }

        [HttpPost]
        public ActionResult Index()
        {
            Dictionary<string, string> jsonRequest = GetJsonRequest();

            Filters filters = new Filters();
            if (jsonRequest.ContainsKey("EntryDate"))
            {
                filters.EntryDate = DateTime.Parse(jsonRequest["EntryDate"]);
            }
            if (jsonRequest.ContainsKey("LeavingDate"))
            {
                filters.LeavingDate = DateTime.Parse(jsonRequest["LeavingDate"]);
            }
            if (jsonRequest.ContainsKey("AdultNumbers"))
            {
                filters.AdultNumbers = int.Parse(jsonRequest["AdultNumbers"]);
            }
            if (jsonRequest.ContainsKey("MinorNumbers"))
            {
                filters.MinorNumbers = int.Parse(jsonRequest["MinorNumbers"]);
            }
            if (jsonRequest.ContainsKey("MaximumPrice"))
            {
                filters.MaximumPrice = decimal.Parse(jsonRequest["MaximumPrice"]);
            }
            if (jsonRequest.ContainsKey("City"))
            {
                filters.City = int.Parse(jsonRequest["City"]);
            }
            Searcher searcher = new Searcher(_context);
            var queryResponse = searcher.Run(filters);
            
            var jsonResponse = new
            {
                rooms = queryResponse
            };

            return Json(jsonResponse);
        }

        private Dictionary<string, string> GetJsonRequest()
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(ReadRequestBody());
        }

        private string ReadRequestBody()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                return reader.ReadToEnd();
            }
        }
    }
}