using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenderManager : IGenderService
    {
        private readonly IGenderDal _genderDal;

        public GenderManager(IGenderDal genderDal)
        {
            _genderDal = genderDal;
        }

        public async Task TAddAsync(Gender entity)
        {
            await _genderDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _genderDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Gender>> TGetAllAsync()
        {
            return await _genderDal.GetAllAsync();
        }

        public async Task<Gender> TGetByIdAsync(int id)
        {
            return await _genderDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Gender entity)
        {
            await _genderDal.UpdateAsync(entity);
        }
    }
}
