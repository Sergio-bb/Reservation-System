using ReservationSystem.Domain.Entity;
using ReservationSystem.Infrastructure.Interface.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Infrastructure.Interface
{
     public interface IIncludeRepositoy: IRepository<Include>
    {
        Task<List<Include>> GetByCode(string Code);
    }
}
