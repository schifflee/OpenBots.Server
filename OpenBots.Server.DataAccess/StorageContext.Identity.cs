using OpenBots.Server.Model.Core;
using OpenBots.Server.Model.Identity;
using OpenBots.Server.Model.Report;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.DataAccess
{
    public partial class StorageContext
    {
        #region Identity 
        public DbSet<EmailVerification> EmailVerifications { get; set; }
        public DbSet<PasswordPolicy> PasswordPolicies { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonCredential> PersonCredentials { get; set; }
        public DbSet<PersonEmail> PersonEmails { get; set; }
        public DbSet<PersonPhone> PersonPhones { get; set; }
        public DbSet<UserConsent> UserConsents { get; set; }
        public DbSet<UserAgreement> UserAgreements { get; set; }
        public DbSet<AspNetUsers> AspNetUsers { get; set; }

        #endregion Identity


        protected static void CreateIdentityModel(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                return;
            CreateEmailVerificationModel(modelBuilder.Entity<EmailVerification>());
            CreatePasswordPolicyModel(modelBuilder.Entity<PasswordPolicy>());
            CreatePersonModel(modelBuilder.Entity<Person>());
            CreatePersonCredentialModel(modelBuilder.Entity<PersonCredential>());
            CreatePersonEmailModel(modelBuilder.Entity<PersonEmail>());
            CreatePersonPhoneModel(modelBuilder.Entity<PersonPhone>());

            CreateUserConsent(modelBuilder.Entity<UserConsent>());
            CreateUserAgreement(modelBuilder.Entity<UserAgreement>());

        }

        protected static void CreateEmailVerificationModel(EntityTypeBuilder<EmailVerification> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
        protected static void CreatePasswordPolicyModel(EntityTypeBuilder<PasswordPolicy> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
        protected static void CreatePersonModel(EntityTypeBuilder<Person> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
        protected static void CreatePersonCredentialModel(EntityTypeBuilder<PersonCredential> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
        protected static void CreatePersonEmailModel(EntityTypeBuilder<PersonEmail> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }
        protected static void CreatePersonPhoneModel(EntityTypeBuilder<PersonPhone> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }

        protected static void CreateUserAgreement(EntityTypeBuilder<UserAgreement> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }

        protected static void CreateUserConsent(EntityTypeBuilder<UserConsent> entity)
        {
            if (entity == null) return;
            entity.Property(e => e.IsDeleted).HasDefaultValue(false);
            entity.Property(e => e.CreatedOn).HasDefaultValueSql("getutcdate()");
            entity.Property(e => e.Id).HasDefaultValueSql("newid()");
        }



    }
}
