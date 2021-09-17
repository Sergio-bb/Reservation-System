using ReservationSystem.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IAgreementDomain
    {
        Task<bool> Add(Agreement agreement);
        Task<bool> Update(Agreement agreement);
        Task<bool> Delete(int id);
        Task<Agreement> Get(int id);
        Task<List<Agreement>> GetAll();
        Task<IEnumerable<Agreement>> GetByCode(string code);
    }
}
