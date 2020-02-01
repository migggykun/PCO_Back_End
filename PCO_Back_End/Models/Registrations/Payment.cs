using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace PCO_Back_End.Models.Registrations
{
    public partial class Payment
    {
        [Key]
        public int paymentRegistrationId { get; set; }

        [Required]
        [StringLength(50)]
        public string transactionNo { get; set; }

        public DateTime paymentSubmissionDate { get; set; }

        [Required]
        [StringLength(10)]
        public string amountPaid { get; set; }

        [Required]
        [MaxLength(255)]
        public byte[] proofOfPayment { get; set; }

        public bool isPaymentConfirmed { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
