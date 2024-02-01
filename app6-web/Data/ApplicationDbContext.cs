using app6_web.Models;
using Microsoft.EntityFrameworkCore;

namespace app6_web.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { }
        public DbSet <Category> Categories { get; set; }
    }
}
