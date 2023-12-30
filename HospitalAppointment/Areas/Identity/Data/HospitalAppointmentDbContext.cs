using HospitalAppointment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalAppointment.Areas.Identity.Data;

public class HospitalAppointmentDbContext : IdentityDbContext<ApplicationUser>
{
    public HospitalAppointmentDbContext(DbContextOptions<HospitalAppointmentDbContext> options)
        : base(options)
    {
    }
    public DbSet<Doctor> Doctor { get; set; }
    public DbSet<Department> Department { get; set; }
    



    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
    
}
