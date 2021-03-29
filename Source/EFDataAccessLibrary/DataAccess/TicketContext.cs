using EFDataAccessLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace EFDataAccessLibrary.DataAccess
{
    public class TicketContext : DbContext
    {
        public TicketContext(DbContextOptions<TicketContext> options) : base(options)
        {
        }

        public DbSet<TicketRecord> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Connection string examples for SQL server
            // https://www.connectionstrings.com/sql-server/
            // Standard Security: Server=myServerAddress;Database=myDataBase;User Id=myUsername;Password=myPassword;
            optionsBuilder.UseMySql("Server=85.227.174.43;Database=lukeskywalker;Uid=lukeskywalker;Pwd=Vader56;", new MySqlServerVersion(new System.Version(5, 0, 12)));
        }


    }
}
