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
    public class ApplicationManager : IApplicationService
    {
        private readonly IApplicationDal _applicationDal;

        public ApplicationManager(IApplicationDal applicationDal)
        {
            _applicationDal = applicationDal;
        }

        public async Task TAddAsync(Application entity)
        {
            await _applicationDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _applicationDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<Application>> TGetAllAsync()
        {
            return await _applicationDal.GetAllAsync();
        }

        public async Task<Application> TGetByIdAsync(int id)
        {
            return await _applicationDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(Application entity)
        {
            await _applicationDal.UpdateAsync(entity);
        }
    }
}
