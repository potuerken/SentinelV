using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class Kod : EntityBase, IEntity
    {
        public int? UstKodId { get; set; }
        public int? KodTipId { get; set; }
        public string Ad { get; set; }
    }
}
