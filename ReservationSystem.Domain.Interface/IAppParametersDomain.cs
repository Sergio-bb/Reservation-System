using ReservationSystem.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Interface
{
    public interface IAppParametersDomain
    {
        Task<bool> Add(AppParameters appParameters);
        Task<bool> Update(AppParameters appParameters);
        Task<bool> Delete(int appParametersId);
        Task<AppParameters> Get(int appParametersId);
        Task<List<AppParameters>> GetAll();
        Task<IEnumerable<AppParameters>> GetByCode(string code);
    }
}
