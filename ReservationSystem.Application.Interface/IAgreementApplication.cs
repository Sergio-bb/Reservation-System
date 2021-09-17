using ReservationSystem.Application.DTO;
using ReservationSystem.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Application.Interface
{
    public interface IAgreementApplication
    {     
        Task<Response<bool>> Add(AgreementDto agreementDto);
        Task<Response<bool>> Update(AgreementDto agreementDto);
        Task<Response<bool>> Delete(int Id);
        Task<Response<AgreementDto>> Get(int Id);
        Task<Response<IEnumerable<AgreementDto>>> GetAll();
        Task<Response<IEnumerable<AgreementDto>>> GetAllByCode(string code);
    }
}
