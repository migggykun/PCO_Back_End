using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PCO_Back_End.Models.Accounts;
using PCO_Back_End.Models.Conferences;
using PCO_Back_End.Models.Conferences.Promos;
using PCO_Back_End.Models.Registrations;

namespace PCO_Back_End.Models.Entities
{
    public partial class PCO_Context : DbContext
    {
        public PCO_Context()
            : base("name=PCO_Context")
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Conference> Conferences { get; set; }
        public virtual DbSet<DailyAttendanceRecord> DailyAttendanceRecords { get; set; }
        public virtual DbSet<LoginCredential> LoginCredentials { get; set; }
        public virtual DbSet<MembershipType> MembershipTypes { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Period> Periods { get; set; }
        public virtual DbSet<PRCDetail> PRCDetails { get; set; }
        public virtual DbSet<PromoMember> PromoMembers { get; set; }
        public virtual DbSet<Promo> Promos { get; set; }
        public virtual DbSet<Rate> Rates { get; set; }
        public virtual DbSet<Registration> Registrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.firstName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.middleName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.lastName)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.contactNo)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .Property(e => e.location)
                .IsFixedLength();

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.LoginCredential)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Account>()
                .HasOptional(e => e.PRCDetail)
                .WithRequired(e => e.Account);

            modelBuilder.Entity<Account>()
                .HasRequired<MembershipType>(e => e.membershipType);

            modelBuilder.Entity<Conference>()
                .HasOptional(e => e.Promo)
                .WithRequired(e => e.Conference)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Conference>()
                .HasMany(e => e.Rates)
                .WithRequired(e => e.Conference)
                .WillCascadeOnDelete(true);

            //TODO: For Confirmation
            //modelBuilder.Entity<Conference>()
            //    .HasMany(e => e.Registrations)
            //    .WithRequired(e => e.Conference)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<MembershipType>()
                .Property(e => e.membershipTypeName)
                .IsFixedLength();

            //TODO: For Confirmation
            //modelBuilder.Entity<MembershipType>()
            //    .HasMany(e => e.Rates)
            //    .WithRequired(e => e.MembershipType)
            //    .WillCascadeOnDelete(false);

            //TODO: For Confirmation
            //modelBuilder.Entity<MembershipType>()
            //    .HasMany(e => e.PromoMembers)
            //    .WithRequired(e => e.MembershipType)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.amountPaid)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .Property(e => e.proofOfPayment)
                .IsFixedLength();

            modelBuilder.Entity<Period>()
                .Property(e => e.periodName)
                .IsFixedLength();

            //TODO: For Confirmation
            //modelBuilder.Entity<Period>()
            //    .HasMany(e => e.DailyAttendanceRecords)
            //    .WithRequired(e => e.Period)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<PRCDetail>()
                .Property(e => e.prcNo)
                .IsFixedLength();

            modelBuilder.Entity<Promo>()
                .HasMany(e => e.PromoMembers)
                .WithRequired(e => e.Promo)
                .WillCascadeOnDelete(false);

            //TODO: For Confirmation
            //modelBuilder.Entity<Registration>()
            //    .HasMany(e => e.DailyAttendanceRecords)
            //    .WithRequired(e => e.Registration)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Registration>()
                .HasOptional(e => e.Payment)
                .WithRequired(e => e.Registration);
        }
    }
}
