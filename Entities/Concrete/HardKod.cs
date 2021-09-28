using Core.Entities;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class HardKod : EntityBase, IEntity
    {
        public long UstKodId { get; set; }
        public string Ad { get; set; }
    }
}
