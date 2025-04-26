using Microsoft.EntityFrameworkCore;
using CoreFuels.ModelsEF;

public class AppDbContext : DbContext
{
    public DbSet<Authorization> Authorizations { get; set; }
    public DbSet<Product> Products { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Authorization>()
            .HasMany(a => a.Products)
            .WithMany(p => p.Users)
            .UsingEntity(j => j.ToTable("UserProducts"));

        
        modelBuilder.Entity<Product>().HasData(
            new Product { ProductId = 1, Name = "Apple", Calories = "52", Proteins = 0.3, Fats = 0.2, Carbohydrates = 14.0 },
            new Product { ProductId = 2, Name = "Banana", Calories = "96", Proteins = 1.3, Fats = 0.3, Carbohydrates = 27.0 },
            new Product { ProductId = 3, Name = "Chicken Breast", Calories = "165", Proteins = 31.0, Fats = 3.6, Carbohydrates = 0.0 },
            new Product { ProductId = 4, Name = "Rice", Calories = "130", Proteins = 2.7, Fats = 0.3, Carbohydrates = 28.0 },
            new Product { ProductId = 5, Name = "Egg", Calories = "68", Proteins = 5.5, Fats = 4.8, Carbohydrates = 0.6 },
            new Product { ProductId = 6, Name = "Milk", Calories = "42", Proteins = 3.4, Fats = 1.0, Carbohydrates = 5.0 },
            new Product { ProductId = 7, Name = "Bread", Calories = "265", Proteins = 9.0, Fats = 3.2, Carbohydrates = 49.0 },
            new Product { ProductId = 8, Name = "Cheese", Calories = "402", Proteins = 25.0, Fats = 33.0, Carbohydrates = 1.3 },
            new Product { ProductId = 9, Name = "Tomato", Calories = "18", Proteins = 0.9, Fats = 0.2, Carbohydrates = 3.9 },
            new Product { ProductId = 10, Name = "Potato", Calories = "77", Proteins = 2.0, Fats = 0.1, Carbohydrates = 17.0 },
            new Product { ProductId = 11, Name = "Carrot", Calories = "41", Proteins = 0.9, Fats = 0.2, Carbohydrates = 10.0 },
            new Product { ProductId = 12, Name = "Orange", Calories = "47", Proteins = 0.9, Fats = 0.1, Carbohydrates = 12.0 },
            new Product { ProductId = 13, Name = "Beef", Calories = "250", Proteins = 26.0, Fats = 15.0, Carbohydrates = 0.0 },
            new Product { ProductId = 14, Name = "Fish (Salmon)", Calories = "208", Proteins = 20.0, Fats = 13.0, Carbohydrates = 0.0 },
            new Product { ProductId = 15, Name = "Yogurt", Calories = "59", Proteins = 10.0, Fats = 0.4, Carbohydrates = 3.6 },
            new Product { ProductId = 16, Name = "Pineapple", Calories = "50", Proteins = 0.5, Fats = 0.1, Carbohydrates = 13.0 },
            new Product { ProductId = 17, Name = "Strawberry", Calories = "32", Proteins = 0.7, Fats = 0.3, Carbohydrates = 7.7 },
            new Product { ProductId = 18, Name = "Pasta", Calories = "131", Proteins = 5.0, Fats = 1.1, Carbohydrates = 25.0 },
            new Product { ProductId = 19, Name = "Butter", Calories = "717", Proteins = 0.9, Fats = 81.0, Carbohydrates = 0.1 },
            new Product { ProductId = 20, Name = "Lettuce", Calories = "15", Proteins = 1.4, Fats = 0.2, Carbohydrates = 2.9 },
            new Product { ProductId = 21, Name = "Cucumber", Calories = "16", Proteins = 0.6, Fats = 0.1, Carbohydrates = 3.6 },
            new Product { ProductId = 22, Name = "Honey", Calories = "304", Proteins = 0.3, Fats = 0.0, Carbohydrates = 82.4 },
            new Product { ProductId = 23, Name = "Walnuts", Calories = "654", Proteins = 15.0, Fats = 65.0, Carbohydrates = 14.0 },
            new Product { ProductId = 24, Name = "Almonds", Calories = "579", Proteins = 21.0, Fats = 50.0, Carbohydrates = 22.0 },
            new Product { ProductId = 25, Name = "Chocolate", Calories = "546", Proteins = 7.0, Fats = 31.0, Carbohydrates = 61.0 },
            new Product { ProductId = 26, Name = "Mushrooms", Calories = "22", Proteins = 3.1, Fats = 0.3, Carbohydrates = 3.3 },
            new Product { ProductId = 27, Name = "Peanut Butter", Calories = "588", Proteins = 25.0, Fats = 50.0, Carbohydrates = 20.0 },
            new Product { ProductId = 28, Name = "Avocado", Calories = "160", Proteins = 2.0, Fats = 15.0, Carbohydrates = 9.0 },
            new Product { ProductId = 29, Name = "Blueberries", Calories = "57", Proteins = 0.7, Fats = 0.3, Carbohydrates = 14.5 },
            new Product { ProductId = 30, Name = "Oats", Calories = "389", Proteins = 16.9, Fats = 6.9, Carbohydrates = 66.3 },
            new Product { ProductId = 31, Name = "Spinach", Calories = "23", Proteins = 2.9, Fats = 0.4, Carbohydrates = 3.6 },
            new Product { ProductId = 32, Name = "Coconut", Calories = "354", Proteins = 3.3, Fats = 33.5, Carbohydrates = 15.2 },
            new Product { ProductId = 33, Name = "Grapes", Calories = "69", Proteins = 0.7, Fats = 0.2, Carbohydrates = 18.1 }
        );

        base.OnModelCreating(modelBuilder);
    }
}
