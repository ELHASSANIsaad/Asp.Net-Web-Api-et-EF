using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Model;
using System.Net;

namespace Repository.DataContext
{
    public class DataContext : DbContext
    {

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }




        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Cuisine> Cuisines { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            

            //modelBuilder.Entity<Cuisine>()
            //    .HasOne(_ => _.Restaurant)
            //    .WithMany(a => a.Cuisines)
            //    .HasForeignKey(p => p.RestaurantId);



            modelBuilder.Entity<Restaurant>(entity =>
            {


                entity.HasKey(e => e.Id).HasName("PK_Restaurant");
                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd(); // Auto-increment   

                //entity.HasMany(e => e.Cuisines)
                //.WithOne(r => r.Restaurant)
                //.HasForeignKey(p => p.RestaurantId)
                //.HasConstraintName("FK_Cuisins_RestaurantId");

                //entity.HasOne(p => p.Contact)
                //.WithOne(a => a.Restaurant)
                //.HasForeignKey<Contact>(a => a.Id);


            });


            modelBuilder.Entity<Cuisine>(entity =>
            {

                entity.HasKey(e => e.Id).HasName("PK_Cuisine");
                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd(); // Auto-increment 

                entity.HasOne(_ => _.Restaurant)
                .WithMany(a => a.Cuisines)
                .HasForeignKey(p => p.RestaurantId);

            });

            modelBuilder.Entity<Contact>(entity =>
            {

                entity.HasKey(e => e.Id).HasName("PK_Contact");
                entity.Property(e => e.Id).HasColumnName("id").ValueGeneratedOnAdd(); // Auto-increment 

                entity.HasOne(_ => _.Restaurant)
                .WithMany(a => a.Contact)
                .HasForeignKey(p => p.RestaurantId);

            });


        }





    }
}
