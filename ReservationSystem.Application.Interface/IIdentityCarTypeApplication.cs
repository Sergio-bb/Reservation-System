using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IIdentityCardTypeApplication
    {
      
        Task<Response<IEnumerable<IdentityCardTypeDto>>> GetAll();
       
    }  
}
