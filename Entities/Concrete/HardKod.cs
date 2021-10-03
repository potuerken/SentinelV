using Core.Entities;
using Entities.Base;

namespace Entities.Concrete
{
    public class HardKod : EntityBase, IEntity
    {
        public int UstKodId { get; set; }
        public string Ad { get; set; }
    }
}
