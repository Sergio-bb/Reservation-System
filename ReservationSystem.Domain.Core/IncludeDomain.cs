using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using ReservationSystem.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class IncludeDomain : IIncludeDomain
    {
        private readonly IIncludeRepositoy _includeRepositoy;
        public IncludeDomain(IIncludeRepositoy includeRepositoy)
        {
            _includeRepositoy = includeRepositoy;
        }
        public async Task<bool> Add(Include include)
        {
            try
            {
                await _includeRepositoy.AddAsync(include);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int Id)
        {            
            try
            {
                var prop = _includeRepositoy.GetByIdAsync(Id);
                await _includeRepositoy.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception )
            {

                return false;
            }
        }

        public async Task<Include> Get(int id)
        {
            return await _includeRepositoy.GetByIdAsync(id);
        }

        public async Task<List<Include>> GetAll()
        {
            return await _includeRepositoy.GetAllAsync();
        }

        public async Task<IEnumerable<Include>> GetByCode(string code)
        {
            return await _includeRepositoy.GetByCode(code);
        }

        public  async  Task<bool> Update(Include include)
        {
            try
            {
                await _includeRepositoy.UpdateAsync(include);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
