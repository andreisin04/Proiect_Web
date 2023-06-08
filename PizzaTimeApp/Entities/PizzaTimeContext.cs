using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaTimeApp.Entities
{
    public class PizzaTimeContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
                            UserRole, IdentityUserLogin<string>,
                            IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductDetails> ProductDetails { get; set;}
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProduct { get; set; }

        public PizzaTimeContext(DbContextOptions<PizzaTimeContext> options) : base(options) { }
        
        //configurare inainte de dependence injection
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                //.UseLazyLoadingProxies()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=PizzaTimeApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }*/

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //relatia 1:1
            builder.Entity<Product>()
                .HasOne(p => p.ProductDetails)
                .WithOne(pd => pd.Product);

            //relatia 1:M
            builder.Entity<Category>()
                 .HasMany(p => p.Products)
                 .WithOne(c => c.Category);

            //relatia 1:M
            builder.Entity<User>()
                 .HasMany(p => p.Orders)
                 .WithOne(c => c.User);

            //relatia M:M
            builder.Entity<OrderProduct>().HasKey(op => new { op.OrderId, op.ProductId });

            builder.Entity<OrderProduct>()
                .HasOne<Order>(op => op.Order)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(op => op.OrderId);

            builder.Entity<OrderProduct>()
                .HasOne<Product>(op => op.Product)
                .WithMany(p => p.OrderProduct)
                .HasForeignKey(op => op.ProductId);
        }

    }
}
