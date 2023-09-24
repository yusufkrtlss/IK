﻿using BusinessLayer.Abstract;
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

        public void TDelete(Gender t)
        {
            _genderDal.Delete(t);
        }

        public Gender TGetByID(int id)
        {
            return _genderDal.GetByID(id);
        }

        public List<Gender> TGetList()
        {
            return _genderDal.GetList();
        }

        public void TInsert(Gender t)
        {
            _genderDal.Insert(t);
        }

        public void TUpdate(Gender t)
        {
            _genderDal.Update(t);
        }
    }
}
