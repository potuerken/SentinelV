using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class UserOperationClaims
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IlkKayitTarihi { get; set; }
        public int IlkKaydedenKullaniciId { get; set; }
        public DateTime? SonKayitTarihi { get; set; }
        public int? SonKaydedenKullaniciId { get; set; }

        public virtual OperationClaims OperationClaim { get; set; }
        public virtual Users User { get; set; }
    }
}
