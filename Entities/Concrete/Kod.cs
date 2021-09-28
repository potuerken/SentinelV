using Core.Entities;
using Entities.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Kod : EntityBase, IEntity
    {
        public long UstKodId { get; set; }
        public long KodTipId { get; set; }
        public string Ad { get; set; }
    }
}
