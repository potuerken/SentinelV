using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Connection;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelDal : EntityFrameworkRepositoryBase<Personel, SentinelContext>, IPersonelDal
    {
    }
}
