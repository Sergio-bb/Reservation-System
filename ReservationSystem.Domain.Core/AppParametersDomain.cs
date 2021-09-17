using ReservationSystem.Domain.Entity;
using ReservationSystem.Domain.Interface;
using ReservationSystem.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReservationSystem.Domain.Core
{
    public class AppParametersDomain : IAppParametersDomain
    {
        private readonly IAppParametersRepository _aapParametersRepository;
        public AppParametersDomain(IAppParametersRepository appParametersRepository)
        {
            _aapParametersRepository = appParametersRepository;
        }

        public async Task<bool> Add(AppParameters appParameters)
        {
            try
            {
                await _aapParametersRepository.AddAsync(appParameters);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int appParametersId)
        {
            try
            {
                var prop = _aapParametersRepository.GetByIdAsync(appParametersId);
                await _aapParametersRepository.DeleteAsync(prop.Result);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<AppParameters> Get(int appParametersId)
        {
            return await _aapParametersRepository.GetByIdAsync(appParametersId);
        }

        public async Task<List<AppParameters>> GetAll()
        {
            return await _aapParametersRepository.GetAllAsync();
        }

        public async Task<IEnumerable<AppParameters>> GetByCode(string code)
        {
            return await _aapParametersRepository.GetByCode(code);
        }

        public async Task<bool> Update(AppParameters appParameters)
        {
            try
            {
                await _aapParametersRepository.UpdateAsync(appParameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
