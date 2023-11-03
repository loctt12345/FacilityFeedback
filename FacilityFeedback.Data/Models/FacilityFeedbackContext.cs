using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacilityFeedback.Data.Models
{
    public partial class FacilityFeedbackContext : DbContext
    {
        public FacilityFeedbackContext()
        {

        }
        public FacilityFeedbackContext(DbContextOptions<FacilityFeedbackContext> options) : base(options) { 

        }
        public DbSet<Device> Device { get; set; } = null!;
        public DbSet<DeviceType> DeviceType { get; set; } = null!;
        public DbSet<Floor> Floor { get; set; } = null!;
        public DbSet<Problem> Problem { get; set; } = null!;
        public DbSet<Room> Room { get; set; } = null!;
        public DbSet<RoomType> RoomType { get; set; } = null!;
        public DbSet<TaskProcess> TaskProcess { get; set; } = null!;
        public DbSet<ResourceMaterial> ResourceMaterial { get; set; } = null!;
        public DbSet<Account> Account { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"
                    ), options => options.EnableRetryOnFailure());
            }
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}
