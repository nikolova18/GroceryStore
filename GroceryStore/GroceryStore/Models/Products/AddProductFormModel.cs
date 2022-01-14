namespace GroceryStore.Models.Products
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class AddProductFormModel
    {
        [Required]
        [StringLength(NameMaxLength,MinimumLength=NameMinLength)]
        [Display(Name ="Name")]
        public string Name { get; init; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        [Display(Name = "Origin of the product")]
        public string Origin { get; init; }

        [Required]
        [Range(typeof(decimal), "0", "999.99",
            ErrorMessage = "The price must be greater than 0.")]
        [Display(Name = "Price in BGN")]
        public decimal Price { get; init; }


        [Display(Name = "Category name")]
        public int CategoryId { get; init; }

        public IEnumerable<ProductCategoryViewModel> Categories { get; set; }
    }
}
