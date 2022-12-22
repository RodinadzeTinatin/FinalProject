using Domain.Final;
using Microsoft.EntityFrameworkCore;


namespace Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Loan> Loans { get; set; }

    }
}
