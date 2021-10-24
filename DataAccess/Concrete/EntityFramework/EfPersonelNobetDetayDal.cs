using Check.DTO;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelNobetDetayDal : EntityFrameworkRepositoryBase<PersonelNobetDetay, SentinelContext>, IPersonelNobetDetayDal
    {
        public List<PersonelDTO> NobetSistemeGorePersonelleriGetir(int nobetSistemId)
        {
            using (var context = new SentinelContext())
            {
                var result = from nSI in context.NobetSistemSubeIliski
                             join nS in context.NobetSistem
                                on nSI.Id equals nS.Id
                             join nL in context.NobetListesi
                                on nS.Id equals nL.NobetSistemId
                             join p in context.Personel
                                on nSI.SubeKodId equals p.SubeKodId
                             where nS.Id == nobetSistemId && nS.AktifMi == true && nSI.AktifMi == true
                             && nL.AktifMi == true && p.AktifMi == true
                             select new PersonelDTO { Ad = p.Ad };
                return result.ToList();
            }
        }
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
    }
}
