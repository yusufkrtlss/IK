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
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public async Task TAddAsync(AppUser entity)
        {
            await _userDal.AddAsync(entity);
        }

        public async Task TDeleteAsync(int id)
        {
            await _userDal.DeleteAsync(id);
        }

        public async Task<IEnumerable<AppUser>> TGetAllAsync()
        {
            return await _userDal.GetAllAsync();
        }

        public async Task<AppUser> TGetByIdAsync(int id)
        {
            return await _userDal.GetByIdAsync(id);
        }

        public async Task TUpdateAsync(AppUser entity)
        {
            await _userDal.UpdateAsync(entity);
        }
    }
}
