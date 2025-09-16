using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Entities.Identity;
using System.Reflection.Emit;


namespace MyMvcNetCore.DataLayer.Context
{
    // به‌روزرسانی DbContext برای استفاده از کلاس‌های سفارشی
    public class MyMvcNetCoreDbContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public MyMvcNetCoreDbContext(DbContextOptions<MyMvcNetCoreDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductProductTag> ProductsProductTags { get; set; }
        public DbSet<UserInformation> UserInformation { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            builder.Entity<ApplicationUser>().ToTable("ApplicationUser");
            builder.Entity<ApplicationRole>().ToTable("ApplicationRole");
            builder.Entity<ApplicationUserClaim>().ToTable("ApplicationUserClaim");
            builder.Entity<ApplicationUserRole>().ToTable("ApplicationUserRole");
            builder.Entity<ApplicationUserLogin>().ToTable("ApplicationUserLogin");
            builder.Entity<ApplicationRoleClaim>().ToTable("ApplicationRoleClaim");
            builder.Entity<ApplicationUserToken>().ToTable("ApplicationUserToken");



            builder.Entity<Cart>()
                .HasKey(c => new { c.ProductId, c.UserId });

            builder.Entity<OrderDetail>()
                .HasKey(od => new { od.ProductId, od.OrderId });

            builder.Entity<ProductProductTag>()
                .HasKey(pt => new { pt.ProductId, pt.ProductTagId });






            /////Data
            #region Category

            // Root Categories
            builder.Entity<Category>().HasData(
                new Category { Id = 1, Title = "Electronics", ParentId = null },
                new Category { Id = 2, Title = "Clothing", ParentId = null },
                new Category { Id = 3, Title = "Books", ParentId = null },
                new Category { Id = 4, Title = "Home & Kitchen", ParentId = null },
                new Category { Id = 5, Title = "Sports & Outdoors", ParentId = null },
                new Category { Id = 6, Title = "Beauty & Health", ParentId = null },
                new Category { Id = 7, Title = "Toys & Games", ParentId = null },
                new Category { Id = 8, Title = "Automotive", ParentId = null },
                new Category { Id = 9, Title = "Pet Supplies", ParentId = null },
                new Category { Id = 10, Title = "Office Products", ParentId = null }
            );

            // Electronics children
            builder.Entity<Category>().HasData(
                new Category { Id = 11, Title = "Mobile Phones", ParentId = 1 },
                new Category { Id = 12, Title = "Laptops", ParentId = 1 },
                new Category { Id = 13, Title = "Headphones", ParentId = 1 },
                new Category { Id = 14, Title = "Cameras", ParentId = 1 },
                new Category { Id = 15, Title = "Televisions", ParentId = 1 }
            );

            // Clothing children
            builder.Entity<Category>().HasData(
                new Category { Id = 16, Title = "Men's Clothing", ParentId = 2 },
                new Category { Id = 17, Title = "Women's Clothing", ParentId = 2 },
                new Category { Id = 18, Title = "Kids' Clothing", ParentId = 2 },
                new Category { Id = 19, Title = "Shoes", ParentId = 2 },
                new Category { Id = 20, Title = "Accessories", ParentId = 2 }
            );

            // Books children
            builder.Entity<Category>().HasData(
                new Category { Id = 21, Title = "Fiction", ParentId = 3 },
                new Category { Id = 22, Title = "Non-Fiction", ParentId = 3 },
                new Category { Id = 23, Title = "Comics", ParentId = 3 },
                new Category { Id = 24, Title = "Children's Books", ParentId = 3 },
                new Category { Id = 25, Title = "Science & Technology", ParentId = 3 }
            );

            // Home & Kitchen children
            builder.Entity<Category>().HasData(
                new Category { Id = 26, Title = "Furniture", ParentId = 4 },
                new Category { Id = 27, Title = "Appliances", ParentId = 4 },
                new Category { Id = 28, Title = "Kitchen Tools", ParentId = 4 },
                new Category { Id = 29, Title = "Bedding", ParentId = 4 },
                new Category { Id = 30, Title = "Home Decor", ParentId = 4 }
            );

            // Sports & Outdoors children
            builder.Entity<Category>().HasData(
                new Category { Id = 31, Title = "Fitness Equipment", ParentId = 5 },
                new Category { Id = 32, Title = "Outdoor Gear", ParentId = 5 },
                new Category { Id = 33, Title = "Team Sports", ParentId = 5 },
                new Category { Id = 34, Title = "Cycling", ParentId = 5 }
            );

            // Beauty & Health children
            builder.Entity<Category>().HasData(
                new Category { Id = 35, Title = "Skincare", ParentId = 6 },
                new Category { Id = 36, Title = "Makeup", ParentId = 6 },
                new Category { Id = 37, Title = "Personal Care", ParentId = 6 },
                new Category { Id = 38, Title = "Healthcare", ParentId = 6 }
            );

            // Toys & Games children
            builder.Entity<Category>().HasData(
                new Category { Id = 39, Title = "Action Figures", ParentId = 7 },
                new Category { Id = 40, Title = "Board Games", ParentId = 7 },
                new Category { Id = 41, Title = "Puzzles", ParentId = 7 },
                new Category { Id = 42, Title = "Dolls", ParentId = 7 }
            );

            // Automotive children
            builder.Entity<Category>().HasData(
                new Category { Id = 43, Title = "Car Accessories", ParentId = 8 },
                new Category { Id = 44, Title = "Motorbike Accessories", ParentId = 8 },
                new Category { Id = 45, Title = "Car Electronics", ParentId = 8 }
            );

            // Pet Supplies children
            builder.Entity<Category>().HasData(
                new Category { Id = 46, Title = "Dog Supplies", ParentId = 9 },
                new Category { Id = 47, Title = "Cat Supplies", ParentId = 9 },
                new Category { Id = 48, Title = "Aquatic Supplies", ParentId = 9 }
            );

            // Office Products children
            builder.Entity<Category>().HasData(
                new Category { Id = 49, Title = "Office Furniture", ParentId = 10 },
                new Category { Id = 50, Title = "Writing Supplies", ParentId = 10 },
                new Category { Id = 51, Title = "Office Electronics", ParentId = 10 },
                new Category { Id = 52, Title = "Paper Products", ParentId = 10 }
            );

            #endregion
            /////Data

        }
    }
}