using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IIncludeApplication
    {
        Task<Response<bool>> Add(IncludeDto include);
        Task<Response<bool>> Update(IncludeDto include);
        Task<Response<bool>> Delete(int Id);
        Task<Response<IncludeDto>> Get(int Id);
        Task<Response<IEnumerable<IncludeDto>>> GetAll();
        Task<Response<IEnumerable<IncludeDto>>> GetAllByCode(string code);
    }  
}
