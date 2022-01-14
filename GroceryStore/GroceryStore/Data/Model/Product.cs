using System.ComponentModel.DataAnnotations;
using static GroceryStore.Data.DataConstants;

namespace GroceryStore.Data.Model
{
    public class Product
    {
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Origin { get; init; }

        [Required]
        [Range(typeof(decimal),"0","999.99")]
        public decimal Price { get; init; }

        public int CategoryId { get; init; }

        public Category Category { get; init; }
    }
}
