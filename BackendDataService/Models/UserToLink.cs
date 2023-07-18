using System.ComponentModel.DataAnnotations.Schema;

namespace BackendDataService.Models
{
    public class UserToLink
    {
        [Column("user_id")]
        public long UserId { get; set; }

        [Column("link_id")]
        public long LinkId { get; set; }
    }
}
