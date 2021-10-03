using System;

namespace Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IKT { get; set; }
        public int IKKId { get; set; }
        public DateTime? SKT { get; set; }
        public int? SKKId { get; set; }
    }
}
