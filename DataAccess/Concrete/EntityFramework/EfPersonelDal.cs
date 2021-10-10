﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfPersonelDal : EntityFrameworkRepositoryBase<Personel, SentinelContext>, IPersonelDal
    {
    }
}
