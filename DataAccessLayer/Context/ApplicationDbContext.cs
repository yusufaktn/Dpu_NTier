using EntiityLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    internal sealed class ApplicationDbContext : IdentityDbContext<AppUser, AppRole, Guid>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Universite> Universiteler { get; set; }
        public DbSet<Fakulte> Fakulteler { get; set; }
        public DbSet<Bolum> Bolumler { get; set; }
        public DbSet<Dersler> Dersler { get; set; }
        public DbSet<Ogretmen> Ogretmenler { get; set; }
        public DbSet<DersNotu> DersNotlari { get; set; }
        public DbSet<OgretmenDersler> OgretmenDersleri { get; set; }
        public DbSet<Oda> Oda { get; set; }
        public DbSet<OdaMesajları> OdaMesajları { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUser>(b =>
            {
                b.Ignore(u => u.PhoneNumber);
                b.Ignore(u => u.PhoneNumberConfirmed);
                b.Ignore(u => u.TwoFactorEnabled);
                b.Ignore(u => u.LockoutEnd);
                b.Ignore(u => u.LockoutEnabled);
                b.Ignore(u => u.AccessFailedCount);
                b.Ignore(u => u.EmailConfirmed);
                b.Ignore(u => u.ConcurrencyStamp);
                b.Ignore(u => u.SecurityStamp);
                b.Ignore(u => u.NormalizedEmail);
                b.Ignore(u => u.NormalizedUserName);
            });

            builder.Entity<AppRole>(b =>
            {
                b.Ignore(b => b.ConcurrencyStamp);
                b.Ignore(b => b.NormalizedName);
            });

            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();

            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

        void IUnitOfWork.SaveChanges()
        {
            base.SaveChanges();
        }

        Task IUnitOfWork.SaveChangesAsync(CancellationToken cancellationToken)
        {
            return SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var entity = (BaseEntity)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    entity.CreatedDate = DateTime.UtcNow;
                }

                entity.UpdatedDate = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
