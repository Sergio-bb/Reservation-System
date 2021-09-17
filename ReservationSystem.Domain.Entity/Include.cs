using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Include")]
    public class Include : Base.Entity
    {
        [StringLength(4), Required]
        public string Code { get; set; }
        [StringLength(150), Required]
        public string Description { get; set; }
    }
}
