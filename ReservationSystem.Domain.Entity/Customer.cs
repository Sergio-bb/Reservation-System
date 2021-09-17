using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Domain.Entity
{
    [Table("Customer")]
    public class Customer : Base.Entity
    {
        [ForeignKey("IdentityCardType")]
        public int IdentityCardTypeId { get; set; }

        [StringLength(20), Required]
        public string IdentityCarNumber { get; set; }

        [StringLength(150), Required]
        public string Name { get; set; }

        [StringLength(50)]
        public string NickName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [StringLength(150), Required]
        public string Address { get; set; }

        [StringLength(50), Required]
        public string PhoneNumber { get; set; }
        [StringLength(150), Required]
        public string Email { get; set; }
        public virtual IdentityCardType IdentityCardType { get; set; }
        //public virtual IEnumerable<Reservation> Reservation { set; get; }

    }
}
