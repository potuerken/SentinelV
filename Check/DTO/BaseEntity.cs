using System;

namespace Check.DTO
{
    public class BaseEntity
    {
        public int UserId { get; set; }
        public int MethodId { get; set; }
        public int ControllerId { get; set; }
        public int Id { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IKT { get; set; }
        public int IKKId { get; set; }
        public DateTime SKT { get; set; }
        public int SKKId { get; set; }
    }
}
