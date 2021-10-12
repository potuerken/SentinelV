using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfNobetSistemDal : EntityFrameworkRepositoryBase<NobetSistem, SentinelContext>, INobetSistemiDal
    {
    }
}

