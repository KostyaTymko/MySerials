using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySerials.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Genre_title { get; set; }

        public virtual ICollection<Serial> Serials { get; set; }

        public Genre()
        {
            this.Serials = new HashSet<Serial>();
        }
    }
}