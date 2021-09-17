using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface ICustomerApplication
    {
        Task<Response<bool>> Add(CustomerDto customerDto);
        Task<Response<bool>> Update(CustomerDto customerDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<CustomerGetDto>> Get(int Id);
        Task<Response<IEnumerable<CustomerGetDto>>> GetAll();
    }
}
