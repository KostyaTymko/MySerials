using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MySerials.Models
{
   
    public class MainFunction
    {
        SerialContext db = new SerialContext();
        public List<Season> Index()
        {
            var seasons = db.Seasons.Include(s => s.Serial).OrderByDescending(u => u.Serial.Date);
            return seasons.ToList();
        }

        public List<Season> Search(string Search)
        {
            var seasons = db.Seasons.Where(s => s.Serial.Serial_title.Contains(Search));
            return seasons.ToList();
        }
    }
}