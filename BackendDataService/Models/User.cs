using System;
using NpgsqlTypes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace BackendDataService.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("date_of_birth")]
        public DateTime DateOfBirth { get; set; }

        [Column("is_blocked")]
        public bool IsBlocked { get; set; }

        [Column("is_del")]
        public bool IsDel { get; set; }

        [Column("last_login_datetime")]
        public DateTime? LastLoginDateTime { get; set; }

    }
}
