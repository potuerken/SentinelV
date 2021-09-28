using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DataAccess.Connection;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EntityFrameworkRepositoryBase<User, SentinelContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new SentinelContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }


        public List<OperationClaim> GetAllClaims()
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
                db.UserOperationClaims.Add(new UserOperationClaim
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
