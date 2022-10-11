using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguage> Brands { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<GithubSocial> GithubSocials { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //if (!optionsBuilder.IsConfigured)
            //    base.OnConfiguring(
            //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("SomeConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //databasei sil önce
            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.Property(p => p.IsActive).HasColumnName("IsActive");
            });

            modelBuilder.Entity<Technology>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });

            modelBuilder.Entity<GithubSocial>(a =>
            {
                a.ToTable("GithubSocials").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.HasOne(p => p.User);
            });

            modelBuilder.Entity<User>(b =>
            {
                b.ToTable("Users");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Email).HasColumnName("Email");
                b.Property(p => p.Status).HasColumnName("Status");
                b.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");
                b.Property(p => p.FirstName).HasColumnName("FirstName");
                b.Property(p => p.LastName).HasColumnName("LastName");
                b.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                b.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");

                b.HasMany(c => c.UserOperationClaims);
                b.HasMany(c => c.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(b =>
            {
                b.ToTable("OperationClaims");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(b =>
            {
                b.ToTable("UserOperationClaims");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");
                b.Property(p => p.UserId).HasColumnName("UserId");

                b.HasOne(c => c.OperationClaim);
                b.HasOne(c => c.User);
            });

            modelBuilder.Entity<RefreshToken>(b =>
            {
                b.ToTable("RefreshTokens");
                b.Property(p => p.Id).HasColumnName("Id");
                b.Property(p => p.Created).HasColumnName("Created");
                b.Property(p => p.Expires).HasColumnName("Expires");
                b.Property(p => p.Revoked).HasColumnName("Revoked");
                b.Property(p => p.UserId).HasColumnName("UserId");
                b.Property(p => p.Token).HasColumnName("Token");
                b.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");
                b.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                b.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                b.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            });



            ProgrammingLanguage[] brandEntitySeeds = { new(1, "C#",true), new(2, "Java", true) };
            Technology[] technologyEntitySeeds = { new(1, "WPF", 1,true), new(2, "ASP.NET",2, true) };
            modelBuilder.Entity<ProgrammingLanguage>().HasData(brandEntitySeeds);
            modelBuilder.Entity<Technology>().HasData(technologyEntitySeeds);


        }
    }
}
