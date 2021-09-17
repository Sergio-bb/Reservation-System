using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IProviderApplication
    {
        Task<Response<bool>> Add(ProviderDto supplierDto);
        Task<Response<bool>> Update(ProviderDto supplierDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<ProviderGetDto>> Get(int Id);
        Task<Response<IEnumerable<ProviderGetDto>>> GetAll();
    }
}
