using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MySerials.Models
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext()
            : base("SerialContext") { }

        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}