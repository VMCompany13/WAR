using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDataService.Models
{
    public class Date
    {
        [Key]
        [Column("date_id")]
        public long DateId { get; set; }

        [Column("when")]
        public DateTime When { get; set; }
    }
}
