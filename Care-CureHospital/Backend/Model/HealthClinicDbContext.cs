using Backend.Model.BlogAndNotification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Model
{
    public class HealthClinicDbContext : DbContext
    {
        public DbSet<PatientFeedback> PatientFeedbacks { get; set; }
        public HealthClinicDbContext(DbContextOptions<HealthClinicDbContext> options) : base(options) { }

        // only for testing purposes
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PatientFeedback>().HasData(
                new PatientFeedback { Id = 1, IsForPublishing = true, IsPublished = true, IsAnonymous = true, Patient = null, PublishingDate = new DateTime(), Text = "text1" },
                new PatientFeedback { Id = 2, IsForPublishing = true, IsPublished = true, IsAnonymous = true, Patient = null, PublishingDate = new DateTime(), Text = "text2" },
                new PatientFeedback { Id = 3, IsForPublishing = true, IsPublished = true, IsAnonymous = true, Patient = null, PublishingDate = new DateTime(), Text = "text3" }
            );

        }
    }
}
