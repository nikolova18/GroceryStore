namespace GroceryStore.Infrastructure
{
    using GroceryStore.Data;
    using GroceryStore.Data.Model;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder PrepareDatabase(
            this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var data = scopedServices.ServiceProvider.GetService<ApplicationDbContext>();

            data.Database.Migrate();

            SeedCategories(data);

            return app;
        }

        private static void SeedCategories(ApplicationDbContext data)
        {
            if (data.Categories.Any())
            {
                return;
            }

            data.Categories.AddRange(new[]
            {
                new Category { Name = "Vegetable" },
                new Category { Name = "Fruit" },
                new Category { Name = "Meat" },
                new Category { Name = "Dairy" },
                new Category { Name = "Bread" },
                new Category { Name = "Spices" }
            });

            data.SaveChanges();
        }
    }
}
