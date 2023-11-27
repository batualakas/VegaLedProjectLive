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
    public class HizmetlerimizManager :IHizmetlerimizService
    {
        IHizmetlerimizDal _hizmetlerimizDal;

        public HizmetlerimizManager(IHizmetlerimizDal hizmetlerimizDal)
        {
                _hizmetlerimizDal= hizmetlerimizDal;
        }

        public void TAdd(Hizmetlerimiz entity)
        {
           _hizmetlerimizDal.Add(entity);
        }

    

        public void TDelete(int id)
        {
            _hizmetlerimizDal.Delete(id);
        }

        public List<Hizmetlerimiz> TGetAll()
        {
           return _hizmetlerimizDal.GetAll();
        }

        public Hizmetlerimiz TGetById(int id)
        {
            return _hizmetlerimizDal.GetById(id);
        }

        public void TUpdate(Hizmetlerimiz entity)
        {
            _hizmetlerimizDal.Update(entity);
        }
    }
}
