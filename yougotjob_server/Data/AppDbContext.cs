using Microsoft.EntityFrameworkCore;
using yougotjob_server.Models;

namespace yougotjob_server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        }

        public DbSet<PatientUsers> PatientUsersTable { get; set; }
        public DbSet<HealthPractitioners> HealthPractitionersTable { get; set; }
        public DbSet<Appointment> AppointmentsTable { get; set; }

    }
}
