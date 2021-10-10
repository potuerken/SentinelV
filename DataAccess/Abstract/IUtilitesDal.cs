using Core.DataAccess;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUtilitesDal : IEntityRepository<Kod>
    {
    }
}
