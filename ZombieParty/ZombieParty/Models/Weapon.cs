using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        [DisplayName("Weapon's "), Required, StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }

        [DisplayName("Weapon's "), Required, DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(0, 500)]
        public decimal Force { get; set; }

        [DisplayName("Price"), Range(0, 100000, ErrorMessage = "The {0} has to be between {1} {2}"), DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DisplayName("Created Date"), DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [DisplayName("Weapon's "), DataType(DataType.ImageUrl)]
        public string? Image { get; set; }
        
        public int Qty { get; set; }

        [DisplayName("Qty Bought")]
        public int QtyBought { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }
    }

}
