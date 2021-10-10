using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUtilitesDal : EntityFrameworkRepositoryBase<Kod, SentinelContext>, IUtilitesDal
    {

    }
}
