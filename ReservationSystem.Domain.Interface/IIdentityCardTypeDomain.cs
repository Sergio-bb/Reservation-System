using ReservationSystem.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IIdentityCardTypeDomain
    {
       
        Task<List<IdentityCardType>> GetAll();
        Task<IdentityCardType> Get(int id);

    }
}
