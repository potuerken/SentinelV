using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Base
{
    public class EntityBase
    {
        public long Id { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IKT { get; set; }
        public long IKTId { get; set; }
        public DateTime SKT { get; set; }
        public long SKKId { get; set; }
    }
}
