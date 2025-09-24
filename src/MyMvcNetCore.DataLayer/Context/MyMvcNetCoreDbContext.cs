using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyMvcNetCore.Entities;
using MyMvcNetCore.Entities.Identity;
using System.Reflection.Emit;


namespace MyMvcNetCore.DataLayer.Context
{
   
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






            //Extensive Category Seed Data
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
            // Continue the code inside the OnModelCreating method
            #region Extensive Product Seed Data

            builder.Entity<Product>().HasData(
                // Electronics
                new Product { Id = 1, Title = "Samsung Galaxy S23 Ultra", Description = "The latest flagship smartphone from Samsung, featuring a built-in S Pen and a powerful 108MP camera system.", Price = 1200, CategoryId = 11 },
                new Product { Id = 2, Title = "Apple MacBook Air M2", Description = "An ultra-lightweight laptop with Apple's M2 chip, offering unparalleled performance and a stunning Liquid Retina display.", Price = 1300, CategoryId = 12 },
                new Product { Id = 3, Title = "Sony WH-1000XM5", Description = "Industry-leading wireless headphones with superior noise-cancellation technology and exceptional audio quality.", Price = 350, CategoryId = 13 },
                new Product { Id = 4, Title = "Canon EOS R5", Description = "A full-frame mirrorless camera capable of capturing stunning 45MP photos and 8K video, with a lightning-fast autofocus system.", Price = 3899, CategoryId = 14 },
                new Product { Id = 5, Title = "LG C2 OLED TV", Description = "A 4K OLED television with perfect blacks and vibrant colors, powered by the α9 Gen 5 AI Processor for a truly cinematic experience.", Price = 1500, CategoryId = 15 },

                // Clothing
                new Product { Id = 6, Title = "Men's Slim Fit Jeans", Description = "Comfortable men's jeans with a modern slim fit and a hint of stretch for easy movement.", Price = 55, CategoryId = 16 },
                new Product { Id = 7, Title = "Women's Summer Dress", Description = "A light and breezy floral dress, perfect for warm weather and casual outings.", Price = 45, CategoryId = 17 },
                new Product { Id = 8, Title = "Unisex Hoodie", Description = "A soft and comfortable hoodie suitable for everyone, ideal for everyday wear.", Price = 35, CategoryId = 18 },
                new Product { Id = 9, Title = "Running Shoes", Description = "Lightweight athletic shoes designed with a cushioned sole for comfort and performance during runs.", Price = 80, CategoryId = 19 },
                new Product { Id = 10, Title = "Leather Wallet", Description = "A classic leather wallet with multiple card slots and a dedicated compartment for cash, offering both style and durability.", Price = 25, CategoryId = 20 },

                // Books
                new Product { Id = 11, Title = "Dune", Description = "A classic science fiction novel by Frank Herbert, exploring a feudal interstellar society on a desert planet.", Price = 20, CategoryId = 21 },
                new Product { Id = 12, Title = "Atomic Habits", Description = "A bestselling non-fiction book by James Clear, teaching how small, incremental changes can lead to remarkable results.", Price = 18, CategoryId = 22 },
                new Product { Id = 13, Title = "The Sandman Vol. 1", Description = "The first volume of the critically acclaimed comic book series by Neil Gaiman, delving into the realm of dreams.", Price = 15, CategoryId = 23 },
                new Product { Id = 14, Title = "The Little Prince", Description = "A timeless and philosophical children's book by Antoine de Saint-Exupéry, a must-read for all ages.", Price = 12, CategoryId = 24 },
                new Product { Id = 15, Title = "Cosmos", Description = "A renowned book by Carl Sagan that simplifies and explores the wonders of the universe and its history.", Price = 22, CategoryId = 25 },

                // Home & Kitchen
                new Product { Id = 16, Title = "Smart Refrigerator", Description = "A Wi-Fi enabled refrigerator with a touchscreen display, allowing you to manage groceries and stay connected.", Price = 2500, CategoryId = 27 },
                new Product { Id = 17, Title = "Stand Mixer", Description = "A powerful kitchen mixer for baking and cooking, with multiple attachments to handle various tasks.", Price = 200, CategoryId = 28 },
                new Product { Id = 18, Title = "King Size Duvet Cover Set", Description = "A luxurious duvet cover set made from soft, high-quality fabric, designed for king-size beds.", Price = 80, CategoryId = 29 },
                new Product { Id = 19, Title = "Decorative Wall Mirror", Description = "A stylish wall mirror with an ornate frame, perfect for adding light and elegance to any room.", Price = 60, CategoryId = 30 },

                // Sports & Outdoors
                new Product { Id = 20, Title = "Adjustable Dumbbells", Description = "A versatile set of dumbbells that allows you to quickly change weights, saving space and money.", Price = 150, CategoryId = 31 },
                new Product { Id = 21, Title = "Camping Tent", Description = "A durable and waterproof two-person camping tent, perfect for hiking and outdoor adventures.", Price = 90, CategoryId = 32 },
                new Product { Id = 22, Title = "Basketball", Description = "A standard-size basketball with a sturdy rubber surface, suitable for both indoor and outdoor play.", Price = 25, CategoryId = 33 },
                new Product { Id = 23, Title = "Mountain Bike", Description = "A rugged mountain bike with a lightweight frame, disk brakes, and smooth-shifting gears, perfect for off-road trails.", Price = 450, CategoryId = 34 },

                // Health & Beauty
                new Product { Id = 24, Title = "Vitamin C Serum", Description = "A facial serum enriched with Vitamin C to brighten skin tone and reduce the appearance of dark spots.", Price = 30, CategoryId = 35 },
                new Product { Id = 25, Title = "Hair Dryer", Description = "A professional hair dryer with ionic technology for fast drying and frizz-free results.", Price = 60, CategoryId = 37 },
                new Product { Id = 26, Title = "Digital Blood Pressure Monitor", Description = "An easy-to-use digital device for accurate and convenient blood pressure measurement at home.", Price = 50, CategoryId = 38 },

                // Toys & Games
                new Product { Id = 27, Title = "Action Figure Set", Description = "A collection of poseable action figures based on popular superhero characters, great for play and display.", Price = 40, CategoryId = 39 },
                new Product { Id = 28, Title = "Cards Against Humanity", Description = "A popular card game for adults, known for its humorous and often controversial content.", Price = 20, CategoryId = 40 },
                new Product { Id = 29, Title = "Jigsaw Puzzle", Description = "A 1000-piece jigsaw puzzle featuring a beautiful nature scene.", Price = 15, CategoryId = 41 },

                // Automotive
                new Product { Id = 30, Title = "Car Phone Holder", Description = "A mobile phone holder for car dashboards with a 360-degree rotating mount.", Price = 20, CategoryId = 43 },
                new Product { Id = 31, Title = "Motorcycle Helmet", Description = "A motorcycle helmet with an aerodynamic design and proper ventilation for safety and comfort.", Price = 120, CategoryId = 44 },

                // Pet Supplies
                new Product { Id = 32, Title = "Dog Leash", Description = "A durable dog leash with a comfortable handle.", Price = 10, CategoryId = 46 },
                new Product { Id = 33, Title = "Cat Scratching Post", Description = "A scratching post for cats with an attached toy.", Price = 30, CategoryId = 47 }
            );

            #endregion




            #region Product Image Seed Data

            builder.Entity<ProductImage>().HasData(
                // تصاویر برای Samsung Galaxy S23 Ultra (ProductId = 1)
                new ProductImage { Id = 1, Title = "Front View", ImageUrl = "/images/products/samsung_s23_ultra_1.jpg", TypeImage = TypeImage.Default, DisplayOrder = 1, ProductId = 1 },
                new ProductImage { Id = 2, Title = "Back View", ImageUrl = "/images/products/samsung_s23_ultra_2.jpg", TypeImage = TypeImage.Hover, DisplayOrder = 2, ProductId = 1 },
                new ProductImage { Id = 3, Title = "Side View", ImageUrl = "/images/products/samsung_s23_ultra_3.jpg", TypeImage = TypeImage.Other, DisplayOrder = 3, ProductId = 1 }

                //// تصاویر برای Apple MacBook Air M2 (ProductId = 2)
                //new ProductImage { Id = 4, Title = "Open Laptop", ImageUrl = "/images/products/macbook_air_m2_1.jpg", TypeImage = TypeImage.Default, DisplayOrder = 1, ProductId = 2 },
                //new ProductImage { Id = 5, Title = "Closed Laptop", ImageUrl = "/images/products/macbook_air_m2_2.jpg", TypeImage = TypeImage.Hover, DisplayOrder = 2, ProductId = 2 },
                //new ProductImage { Id = 6, Title = "Keyboard View", ImageUrl = "/images/products/macbook_air_m2_3.jpg", TypeImage = TypeImage.Other, DisplayOrder = 3, ProductId = 2 },
                //new ProductImage { Id = 7, Title = "Side Ports", ImageUrl = "/images/products/macbook_air_m2_4.jpg", TypeImage = TypeImage.Other, DisplayOrder = 4, ProductId = 2 }
                #endregion
            );
        }
    }
}