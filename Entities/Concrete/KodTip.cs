using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class KodTip : EntityBase, IEntity
    {
        public long UstKodId { get; set; }
        public long HardKodId { get; set; }
        public string Ad { get; set; }
    }
}
