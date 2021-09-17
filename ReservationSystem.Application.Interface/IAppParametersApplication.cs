using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IAppParametersApplication
    {
        Task<Response<bool>> Add(AppParametersDto appParametersDto);
        Task<Response<bool>> Update(AppParametersDto appParametersDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<AppParametersDto>> Get(int Id);
        Task<Response<IEnumerable<AppParametersDto>>> GetAll();
        Task<Response<IEnumerable<AppParametersDto>>> GetAllByCode(string code);
    }
}
