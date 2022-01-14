namespace GroceryStore.Controllers
{
    using GroceryStore.Data;
    using GroceryStore.Data.Model;
    using GroceryStore.Models.Products;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;

    public class ProductController : Controller
    {
        private readonly ApplicationDbContext data;

        public ProductController(ApplicationDbContext data) 
            => this.data = data;

        public IActionResult Add() => View(new AddProductFormModel
        {
            Categories = this.GetProductCategories()
        });

        [HttpPost]
        public IActionResult Add(AddProductFormModel model)
        {
            var productData = new Product 
            { 
                Name=model.Name,
                Origin=model.Origin,
                Price=model.Price,
                CategoryId=model.CategoryId
            };

            this.data.Add(productData);
            this.data.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        private IEnumerable<ProductCategoryViewModel> GetProductCategories()
            => this.data
            .Categories
            .Select(c => new ProductCategoryViewModel
            {
                Id = c.Id,
                Name = c.Name
            })
            .ToList();
    }
}
