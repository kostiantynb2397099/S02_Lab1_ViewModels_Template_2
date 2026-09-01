using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Force { get; set; }
        public decimal Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string? Image { get; set; }
        public int Qty { get; set; }
        public int QtyBought { get; set; }
    }

}
