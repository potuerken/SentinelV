using System;

namespace Check.DTO
{
    public class BaseEntity
    {
        public int UserId { get; set; }
        public int MethodId { get; set; }
        public int ControllerId { get; set; }
        public long Id { get; set; }
        public bool AktifMi { get; set; }
        public DateTime IKT { get; set; }
        public long IKTId { get; set; }
        public DateTime SKT { get; set; }
        public long SKKId { get; set; }
    }
}
