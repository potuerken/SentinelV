using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO
{
    public class PersonelDTO : IDto
    {
        public long Id { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IKT { get; set; }
        public long IKTId { get; set; }
        public DateTime SKT { get; set; }
        public long SKKId { get; set; }
        public string Sicil { get; set; }
        public string Tckn { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string CepNo { get; set; }
        public string Dahili { get; set; }
        public int RutbeKodId { get; set; }
        public int SubeKodId { get; set; }
        public int CinsiyetKodId { get; set; }
        public bool NobetTutabilirMi { get; set; }
        public bool CocukDurumu { get; set; }
        public DateTime BirimBaslamaTarihi { get; set; }
    }
}
