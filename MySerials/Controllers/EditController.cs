using MySerials.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.SqlClient;

namespace MySerials.Controllers
{
    public class EditController:Controller
    {
        SerialContext db = new SerialContext();

        public ActionResult CatalogForEdit()
        {
            IEnumerable<Serial> serials = db.Serials;
            ViewBag.Serials = serials;
            return View();
        }

        public ActionResult SerialSeasonForEdit(int id)
        {
            IEnumerable<Season> seasons = db.Seasons.Where(c => c.SerialId == id);
            string s = "";
            int i = 0;
            foreach (Serial ser in db.Serials)
            {
                if (ser.Id == id)
                {
                    s = ser.Serial_title;
                    i = ser.Id;
                }
            }

            ViewData["Name"] = s;
            ViewData["ID"] = i;
            ViewBag.Seasons = seasons;
            return View();
        }

        [HttpGet]
        public ActionResult SeasonSerieForEdit(int id)
        {
            IEnumerable<Serie> series = db.Series.Where(c => c.SeasonId == id);
            string s = "";
            int i = 0;
            foreach (Season seas in db.Seasons)
            {
                if (seas.Id == id)
                {
                    s = seas.Season_title;
                    i = seas.Id;
                }
            }

            ViewData["Name"] = s;
            ViewData["ID"] = i;
            ViewBag.Series = series;
            return View();
        }
//----------------------------------------------------------------
        [HttpGet]
        public ActionResult SerieEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Serie serie = db.Series.Find(id);
            if (serie == null)
                return HttpNotFound();

            return View(serie);
        }

        [HttpPost]
        public ActionResult SerieEdit(Serie serie)
        {
            int t = 0;
            db.Series.Where(x => x.Id == serie.Id).ToList().ForEach(x =>
            {
                x.Title= serie.Title;t = x.SeasonId;
            });
            db.SaveChanges();
            return RedirectToAction("SeasonSerieForEdit/"+t, "Edit");
        }

        [HttpGet]
        public ActionResult SerieAdd(int? id)
        {
            if (id == null)
                return HttpNotFound();
            SelectList series = new SelectList(db.Seasons.Where(d=>d.Id==id), "Id", "Season_title");
            ViewBag.Series = series;
            return View();
        }

        [HttpPost]
        public ActionResult SerieAdd(Serie serie)
        {
            int t = serie.SeasonId;
            db.Series.Add(serie);
            db.SaveChanges();
            return RedirectToAction("SeasonSerieForEdit/" + t, "Edit");
        }

        [HttpGet]
        public ActionResult SerieDelete(int id)
        {
            Serie b = db.Series.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("SerieDelete")]
        public ActionResult SerieDeleteConfirmed(int id)
        {
            int t = 0;
            Serie b = db.Series.Find(id);
            t = b.SeasonId;
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Series.Remove(b);
            db.SaveChanges();
            return RedirectToAction("SeasonSerieForEdit/" + t, "Edit");
        }
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult SeasonAdd(int? id)
        {
            if (id == null)
                return HttpNotFound();

            SelectList serials = new SelectList(db.Serials.Where(d => d.Id == id), "Id", "Serial_title");
            ViewBag.Serials = serials;
            return View();
        }

        [HttpPost]
        public ActionResult SeasonAdd(Season season)
        {
            int t = season.SerialId;
            db.Seasons.Add(season);
            db.SaveChanges();
            return RedirectToAction("SerialSeasonForEdit/" + t, "Edit");
        }

        [HttpGet]
        public ActionResult SeasonEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Season season = db.Seasons.Find(id);
            if (season == null)
                return HttpNotFound();

            return View(season);
        }

        [HttpPost]
        public ActionResult SeasonEdit(Season season)
        {
            int t=0;
            db.Seasons.Where(x => x.Id == season.Id).ToList().ForEach(x =>
            {
                 x.Season_title = season.Season_title;t = x.SerialId;
            });
            db.SaveChanges();
            return RedirectToAction("SerialSeasonForEdit/"+t, "Edit");
        }

        [HttpGet]
        public ActionResult SeasonDelete(int id)
        {
            Season b = db.Seasons.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("SeasonDelete")]
        public ActionResult SeasonDeleteConfirmed(int id)
        {
            int t = 0;
            Season b = db.Seasons.Find(id);
            t = b.SerialId;
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Seasons.Remove(b);
            db.SaveChanges();
            return RedirectToAction("SerialSeasonForEdit/" + t, "Edit");
        }
        //----------------------------------------------------------------
        [HttpGet]
        public ActionResult SerialEdit(int? id)
        {
            if (id == null)
                return HttpNotFound();

            Serial serial = db.Serials.Find(id);
            if (serial == null)
                return HttpNotFound();

            return View(serial);
        }

        [HttpPost]
        public ActionResult SerialEdit(Serial serial)
        {
            db.Entry(serial).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectToAction("CatalogForEdit","Edit");
        }

        [HttpGet]
        public ActionResult SerialAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SerialAdd(Serial serial)
        {
            db.Serials.Add(serial);
            db.SaveChanges();
            return RedirectToAction("CatalogForEdit", "Edit");
        }

        [HttpGet]
        public ActionResult SerialDelete(int id)
        {
            Serial b = db.Serials.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            return View(b);
        }
        [HttpPost, ActionName("SerialDelete")]
        public ActionResult SerialDeleteConfirmed(int id)
        {
            Serial b = db.Serials.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Serials.Remove(b);
            db.SaveChanges();
            return RedirectToAction("CatalogForEdit", "Edit");
        }
    }
}