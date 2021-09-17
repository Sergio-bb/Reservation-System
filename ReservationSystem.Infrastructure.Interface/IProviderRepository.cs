using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface IProviderRepository : IRepository<Provider>
    {
        Task<List<Provider>> GetAllWithDocumentType();
    }
}
