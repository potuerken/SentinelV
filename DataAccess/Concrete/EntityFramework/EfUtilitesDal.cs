using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Connection;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUtilitesDal : EntityFrameworkRepositoryBase<Kod, SentinelContext>, IUtilitesDal
    {

    }
}
