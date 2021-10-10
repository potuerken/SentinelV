using Entities.Models;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaims> GetClaims(Users user);
        void Add(Users user);
        Users GetByMail(string email);
    }
}
