using Business.Abstract;
using DataAccess.Abstract;
using Entities.Models;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaims> GetClaims(Users user)
        {
            return _userDal.GetClaims(user);
        }

        public void Add(Users user)
        {
            _userDal.Add(user);
        }

        public Users GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
    }
}
