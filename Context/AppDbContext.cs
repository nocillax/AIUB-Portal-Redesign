using AIUB_Portal_Redesign.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace AIUB_Portal_Redesign.Context
{
    public class AppDbContext : DbContext
    {
        // Your context has been configured to use a 'AppDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'AIUB_Portal_Redesign.Context.AppDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AppDbContext' 
        // connection string in the application configuration file.
        public AppDbContext()
            : base("name=AppDbContext.cs")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<StudentProfile> StudentProfiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOptional(u => u.StudentProfile)
                .WithRequired(sp => sp.User)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }

    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}