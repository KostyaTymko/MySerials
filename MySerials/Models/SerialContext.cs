using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MySerials.Models
{
    public class SerialContext:DbContext
    {
        public DbSet<Serial> Serials { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Serie> Series { get; set; }
        public DbSet<Genre> Genres { get; set; }
    }
}