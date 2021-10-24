using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNobetListesiDal : EntityFrameworkRepositoryBase<NobetListesi, SentinelContext>, INobetListesiDal
    {
    }
}
