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

        public void TDelete(Application t)
        {
            _applicationDal.Delete(t);
        }

        public Application TGetByID(int id)
        {
            return _applicationDal.GetByID(id);
        }

        public List<Application> TGetList()
        {
            return _applicationDal.GetList();
        }

        public void TInsert(Application t)
        {
            _applicationDal.Insert(t);
        }

        public void TUpdate(Application t)
        {
            _applicationDal.Update(t);  
        }
    }
}
