using PCO_Back_End.Models.Accounts.SaltHash;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Accounts
{
    public partial class LoginCredential
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int login_accountId { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(255)]
        public string passwordHashed { get; set; }

        [Required]
        [StringLength(255)]
        public string salt { get; set; }

        public virtual Account Account { get; set; }

        public void EncryptPassword()
        {
            DataCryptography dataCryptography = new DataCryptography();
            this.salt = dataCryptography.CreateSalt();
            this.passwordHashed = dataCryptography.GetSha256Hash(this.passwordHashed, this.salt);
        }

        public bool IsPasswordMatch(string inputPassword)
        {
            if (string.Compare(inputPassword, this.passwordHashed, false) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
