using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNobetListesiDetayDal : EntityFrameworkRepositoryBase<NobetListesiDetay, SentinelContext>, INobetListesiDetayDal
    {
    }
}
