﻿using Check.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Check.DTO
{
    public class KodDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public KodTipEnum UstKodId { get; set; }
        public int IKKId { get; set; }
    }
}
