using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNobetSistemSubeIliskiDal : EntityFrameworkRepositoryBase<NobetSistemSubeIliski, SentinelContext>, INobetSistemSubeIliskiDal
    {
    }
}
