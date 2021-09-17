using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Provider")]
    public class Provider: Base.Entity
    {

        [ForeignKey("IdentityCardType")]
        public int IdentityCardTypeId { get; set; }
        [StringLength(20), Required]
        public string IdentityCardNumber { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        [StringLength(50), Required]
        public string Contact { get; set; }

        [StringLength(150), Required]
        public string Address { get; set; }

        [StringLength(50), Required]
        public string PhoneNumber { get; set; }
   
        [StringLength(150), Required]
        public string Email { get; set; }
        public virtual IdentityCardType IdentityCardType { get; set; }

    }
}
