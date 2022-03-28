using Microsoft.EntityFrameworkCore;
using PracticalLesson1.Api.Models;

namespace PracticalLesson1.Api.Data
{
    public class PracticalDbContext : DbContext
    {

        public PracticalDbContext(DbContextOptions<PracticalDbContext> options) :
            base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }

    }
}
