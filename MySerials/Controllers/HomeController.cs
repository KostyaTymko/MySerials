using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySerials.Models;

namespace MySerials.Controllers
{
    public class HomeController : Controller
    {
        SerialContext db = new SerialContext();
        MainFunction a = new MainFunction();
        public ActionResult Index()
        {
            // var seasons = db.Seasons.Include(s => s.Serial).OrderByDescending(u => u.Serial.Date);
            // return View(seasons.ToList());
            //return View(a.Index());
            return View("~/Views/Home/Index.cshtml", "_Layout", a.Index());
        }
        public ActionResult Catalog()
        {
            IEnumerable<Serial> serials = db.Serials;
            ViewBag.Serials = serials;
            return View("~/Views/Home/Catalog.cshtml", "_Layout");
        }

        // [HttpGet]
        public ActionResult Search(string Search)
        {
            return View("~/Views/Home/Search.cshtml", "_Layout",a.Search(Search));
        }

        [HttpGet]
        public ActionResult SerialSeason(int id)
        {
            IEnumerable<Season> seasons = db.Seasons.Where(c => c.SerialId == id);
            string s="";
            foreach (Serial ser in db.Serials)
               {
                if(ser.Id== id)
                s = ser.Serial_title;
               }

            ViewData["Name"] = s;
            ViewBag.Seasons = seasons;
            return View();
        }

        [HttpGet]
        public ActionResult SeasonSerie(int id)
        {
            IEnumerable<Serie> series = db.Series.Where(c => c.SeasonId == id);
            string s = "";
            foreach (Season seas in db.Seasons)
            {
                if (seas.Id == id)
                    s = seas.Season_title;
            }

            ViewData["Name"] = s;
            ViewBag.Series = series;
            return View();
        }
        public ActionResult Rating()
        {
            return View();
        }

        public ActionResult MySerials()
        {
            return View();
        }

        public ActionResult MyArticles()
        {
            return View();
        }

        public ActionResult Schedule()
        {
            return View();
        }

        public ActionResult Lists()
        {
            return View();
        }

    }
}