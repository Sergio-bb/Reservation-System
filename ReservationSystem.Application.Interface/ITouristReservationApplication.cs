using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface ITouristReservationApplication
    {
        Task<Response<ReservationDto>> Add(ReservationDto touristReservationDto);
        Task<Response<bool>> Update(ReservationDto touristReservationDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<ReservationGetDto>> Get(int Id);
        Task<Response<IEnumerable<ReservationGetDto>>> GetAll();
        Task<Response<IEnumerable<ReservationDto>>> GetAllByCode(string code);
        Task<Response<IEnumerable<ReservationGetDto>>> GetAllUnderpayment();
    }  
}
