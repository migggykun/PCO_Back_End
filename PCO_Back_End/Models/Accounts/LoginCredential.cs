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
        public string password { get; set; }

        public virtual Account Account { get; set; }
    }
}
