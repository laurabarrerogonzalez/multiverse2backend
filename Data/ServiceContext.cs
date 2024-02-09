using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Reflection.Emit;
using Data;

namespace Data
{
    public class ServiceContext : DbContext
    {
        public ServiceContext(DbContextOptions<ServiceContext> options) : base(options) { }

        //public DbSet<ProductItem> Products { get; set; }
        //public DbSet<Categories> Categories { get; set; }
        //public DbSet<OrderItem> Orders { get; set; }

        public DbSet<UserItem> UserItem { get; set; }
        public DbSet<RolItem> RolItem { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<UserItem>(entity =>
            {
                entity.ToTable("Users");
                //entity.HasOne<RolItem>().WithMany().HasForeignKey(u => u.IdRol);
                //entity.HasKey(u => u.IdUsuario);
            });

            builder.Entity<RolItem>(entity =>
            {
                entity.ToTable("RollUser");
                entity.HasKey(u => u.IdRol);

            });

            //builder.Entity<ProductItem>(entity => {
            //    entity.ToTable("Products");
            //    entity.HasOne<Categories>().WithMany().HasForeignKey(p => p.IdCategories);
            //    entity.HasKey(p => p.IdProduct);
            //});

            //builder.Entity<Categories>(entity =>
            //{
            //    entity.ToTable("Categories");
            //});

            //builder.Entity<OrderItem>(entity =>
            //{
            //    entity.ToTable("Orders");
            //    entity.HasKey(dp => dp.IdOrder);
            //    entity.HasOne<UserItem>()
            //        .WithMany()
            //        .HasForeignKey(dp => dp.IdUsuario);
            //    entity.HasOne<ProductItem>()
            //       .WithMany()
            //       .HasForeignKey(dp => dp.IdProduct);

            //});


        }



    }
}
public class ServiceContextFactory : IDesignTimeDbContextFactory<ServiceContext>
{
    public ServiceContext CreateDbContext(string[] args)
    {
        var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", false, true);
        var config = builder.Build();
        var connectionString = config.GetConnectionString("ServiceContext");
        var optionsBuilder = new DbContextOptionsBuilder<ServiceContext>();
        optionsBuilder.UseSqlServer(config.GetConnectionString("ServiceContext"));

        return new ServiceContext(optionsBuilder.Options);
    }
}


