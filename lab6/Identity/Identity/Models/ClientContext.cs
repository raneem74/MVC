using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Identity.Models
{
    public class ClientContext : DbContext
    {
        public ClientContext() : base("IdentityConnectionString")
        {

        }
        
        public DbSet<Client> Clients { get; set; }

    }
}