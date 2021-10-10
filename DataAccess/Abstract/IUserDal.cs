using Core.DataAccess;
using Entities.Models;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<Users>
    {
        List<OperationClaims> GetClaims(Users user);
        List<OperationClaims> GetAllClaims();
        bool AddUserClaim(int userid, int claimId);
        bool RemoveUserClaim(int userClaimId);
    }
}
