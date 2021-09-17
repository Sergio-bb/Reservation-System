using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IIncludeDomain
    {
        Task<bool> Add(Include include);
        Task<bool> Update(Include include);
        Task<bool> Delete(int Id);
        Task<Include> Get(int Id);
        Task<List<Include>> GetAll();
        Task<IEnumerable<Include>> GetByCode(string code);
  
    }
}
