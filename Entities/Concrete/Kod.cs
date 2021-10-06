using Core.Entities;
using Entities.Base;
using System;

namespace Entities.Concrete
{
    public class Kod : EntityBase, IEntity
    {
        public Kod()
        {
            IKT = DateTime.Now;
            AktifMi = true;
        }
        public int? UstKodId { get; set; }
        public int? KodTipId { get; set; }
        public string Ad { get; set; }
    }
}
