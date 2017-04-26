using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MySerials.Models
{
    public class Serie
    {
        public int Id { get; set; }
        public int SeasonId { get; set; }
        public string Title { get; set; }

        public virtual Season Season { get; set; }
    }
}