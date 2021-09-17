using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IDestinationApplication
    {
        Task<Response<bool>> Add(DestinationDto destinationDto);
        Task<Response<bool>> Update(DestinationDto destinationDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<DestinationDto>> Get(int Id);
        Task<Response<IEnumerable<DestinationDto>>> GetAll();
        Task<Response<IEnumerable<DestinationDto>>> GetAllByCode(string code);
    }
}
