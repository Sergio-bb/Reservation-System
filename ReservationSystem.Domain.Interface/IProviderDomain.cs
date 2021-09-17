using ReservationSystem.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IProviderDomain
    {
        Task<bool> Add(Provider supplier);
        Task<bool> Update(Provider supplier);
        Task<bool> Delete(int supplierId);
        Task<Provider> Get(int supplierId);
        Task<List<Provider>> GetAll();
        Task<List<Provider>> GetAllWithDocumentType();
    }
}
