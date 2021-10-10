using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Models
{
    public partial class Users
    {
        public Users()
        {
            UserOperationClaims = new HashSet<UserOperationClaims>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool AktifMi { get; set; }

        public virtual ICollection<UserOperationClaims> UserOperationClaims { get; set; }
    }
}
