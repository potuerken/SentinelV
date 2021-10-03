using Core.Entities;
using Entities.Base;
using System;

namespace Entities.Concrete
{
    public class Personel : EntityBase, IEntity
    {
        public string Sicil { get; set; }
        public string Tckn { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int CinsiyetKodId { get; set; }
        public int RutbeKodId { get; set; }
        public int SubeKodId { get; set; }
        public bool NobetTutabilirMi { get; set; }
        public bool CocukDurumu { get; set; }
        public string CepNo { get; set; }
        public string Dahili { get; set; }
        public DateTime BirimBaslamaTarihi { get; set; }
    }
}
