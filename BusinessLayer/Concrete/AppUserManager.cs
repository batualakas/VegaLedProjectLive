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
    public class AppUserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public AppUserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void TAdd(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppUser> TGetAll()
        {
            throw new NotImplementedException();
        }

        public AppUser TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(AppUser entity)
        {
            throw new NotImplementedException();
        }
    }
}
