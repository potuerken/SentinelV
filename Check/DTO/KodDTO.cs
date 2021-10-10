using Check.Concrete;
using Check.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class KodDTO : IDto
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public short? SiraNo { get; set; }
        public KodTipEnum UstKodId { get; set; }
        public int IKKId { get; set; }
        public int SKKId { get; set; }
    }
}
