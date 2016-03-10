using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace WebApplication20.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);            


            var b = builder.Entity<SlaveEntity>();
            b.HasKey(t => t.Id);
            b.HasOne(t => t.Master);
            var c = builder.Entity<MasterEntity>();
            c.HasKey(t => t.Id);
            c.HasMany(t => t.Slaves).WithOne(t => t.Master).ForeignKey(t => t.MasterId);
            c.HasMany(t => t.MasterToRoles).WithOne(t => t.Master).ForeignKey(t => t.MasterID);
            var d = builder.Entity<MasterToRole>();
            d.HasKey(t => new { t.IdentityRoleId, t.MasterID });
            d.HasOne(t => t.Role).WithMany();
            var e = builder.Entity<LookUpValue>();
            e.HasKey(t => t.Id);
            var f = builder.Entity<LookUp>();
            f.HasKey(t => t.Id);
            f.HasMany(t => t.LookUpValues).WithOne(t => t.LookUp).ForeignKey(t => t.LookUpId);
            var g = builder.Entity<Message>();
            g.HasKey(t => t.Guid);
            var h = builder.Entity<State>();
            h.HasKey(t => t.Id);
            h.HasMany(t => t.Messages).WithOne(t => t.State).ForeignKey(t => t.StateId);
            var i = builder.Entity<Page>();
            i.HasKey(t => t.Id);
            i.HasMany(t => t.PageToRoles).WithOne(t => t.Page).ForeignKey(t => t.PageId);
            var j = builder.Entity<PageToRole>();
            j.HasKey(t => new { t.IdentityRoleId, t.PageId });
            j.HasOne(t => t.Role).WithMany();

            //var r = builder.Entity<IdentityRole>();
            //r.HasMany(typeof(MasterToRole)).WithOne();
        }

        public DbSet<Message> Messages { get; set; }

        public DbSet<State> States { get; set; }
    }

    public class Page
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Url { get; set; }
        public virtual ICollection<PageToRole> PageToRoles { get; set; }
    }

    public class PageToRole
    {
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
        public int IdentityRoleId { get; set; }
        public virtual IdentityRole Role { get; set; }

    }
    public class Message
    {
        public Guid Guid { get; set; }
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }
        public int? HoursToDelete { get; set; }
        public string PasswordHash { get; set; }
        public int StateId { get; set; }
        public virtual State State { get; set; }
    }

    public class State
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

    public class LookUp
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<LookUpValue> LookUpValues { get; set; }
    }

    public class LookUpValue
    {
        public int Id { get; set; }
        public int LookUpId { get; set; }
        public virtual LookUp LookUp { get; set; }
        public string Value { get; set; }
    }

    public class SlaveEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MasterId { get; set; }
        public virtual MasterEntity Master { get; set; }
    }

    public class MasterToRole
    {
        public string IdentityRoleId { get; set; }

        public virtual IdentityRole Role { get; set; }

        public int MasterID { get; set; }

        public virtual MasterEntity Master { get; set; }
    }

    public class MasterEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<SlaveEntity> Slaves { get; set; }
        public virtual ICollection<MasterToRole> MasterToRoles { get; set; }
    }
}
