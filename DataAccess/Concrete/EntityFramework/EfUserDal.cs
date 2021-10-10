using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityFrameworkRepositoryBase<Users, SentinelContext>, IUserDal
    {
        public List<OperationClaims> GetClaims(Users user)
        {
            using (var context = new SentinelContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaims { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }


        public List<OperationClaims> GetAllClaims()
        {
            using (var db = new SentinelContext())
            {
                return db.OperationClaims.ToList();
            }
        }


        public bool AddUserClaim(int userid, int claimId)
        {
            using (var db = new SentinelContext())
            {
                db.UserOperationClaims.Add(new UserOperationClaims
                {
                    UserId = userid,
                    OperationClaimId = claimId
                });

                return db.SaveChanges() > 0 ? true : false;
            }
        }

        public bool RemoveUserClaim(int userClaimId)
        {
            using (var db = new SentinelContext())
            {
                var uoc = db.UserOperationClaims.Find(userClaimId);

                if (uoc != null)
                {
                    db.UserOperationClaims.Remove(uoc);
                }

                return db.SaveChanges() > 0 ? true : false;
            }
        }
    }
}
