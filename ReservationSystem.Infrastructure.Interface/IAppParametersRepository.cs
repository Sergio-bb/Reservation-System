using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
    public interface IAppParametersRepository :IRepository<AppParameters>
    {
        Task<List<AppParameters>> GetByCode(string Code);
    }
}
