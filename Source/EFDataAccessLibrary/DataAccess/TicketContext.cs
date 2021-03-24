using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFDataAccessLibrary.DataAccess
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions options) : base(options) { }

        public DbSet<TicketRecord> Tickets { get; set; }
    }
}
