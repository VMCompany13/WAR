using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDataService.Models
{
    public class DishToDate
    {
        [Column("id")]
        public long Id { get; set; }

        [Column("dish_id")]
        public long DishId { get; set; }

        [Column("date_id")]
        public long DateId { get; set; }
    }
}
