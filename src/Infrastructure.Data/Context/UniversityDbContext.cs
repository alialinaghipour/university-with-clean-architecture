using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context;

public class UniversityDbContext:IdentityDbContext
{
    public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
        :base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Course> Courses { get; set; }
    public DbSet<User> Users { get; set; }
}