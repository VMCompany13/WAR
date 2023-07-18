using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDataService.Models
{
    public class Dish
    {
        [Key]
        [Column("dish_id")]
        public long DishId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("ccal")]
        public decimal Ccal { get; set; }

        [Column("proteins")]
        public decimal Proteins { get; set; }

        [Column("fats")]
        public decimal Fats { get; set; }

        [Column("carbohydrates")]
        public decimal Carbohydrates { get; set; }
    }
}
