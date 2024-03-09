﻿using Core.Entities;
using Core.Infrastructure.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection;

namespace Core.Data;
public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
{
    public ApplicationDbContext(DbContextOptions options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
    }

    public DbSet<Brand> Brands { get; set; }
    public DbSet<CarouselImage> CarouselImages { get; set; }
    public DbSet<Catalog> Catalogs { get; set; }
    public DbSet<CatalogSpecificDiscount> CatalogSpecificDiscounts { get; set; } 
    public DbSet<Comment> Comments { get; set; }
    public DbSet<CommentImage> CommentImages { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerAddress> CustomerAddresses { get; set; }
    public DbSet<Favorite> Favorites { get; set; }
    public DbSet<Manager> Managers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<ProductSpecificDiscount> ProductSpecificDiscounts { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    public DbSet<Stock> Stocks { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<TicketComment> TicketComments { get; set; }    
    public DbSet<TicketImage> TicketImages { get; set; }
}
