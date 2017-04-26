using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySerials.Models
{
    public class Serial
    {
        public int Id { get; set; }
        public string Serial_title { get; set; }
        public string SerialDescription { get; set; }

        public virtual ICollection<Season> Seasons { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public Serial()
        {
            this.Seasons = new HashSet<Season>();
            this.Genres = new HashSet<Genre>();
        }
    }
}