using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Data.Entity;
using RefactorThis.GraphDiff;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Data.Entity.Core.Objects;
using EFSecondLevelCache;
using UrumiumMVC.DomainClasses.Entities.Comment;
using DataLayer.Migration;
using UrumiumMVC.DomainClasses.Entities.Menu;
using UrumiumMVC.DomainClasses.Entities.Setting;
using UrumiumMVC.DomainClasses.Entities.Common;
using UrumiumMVC.DomainClasses.Entities.Group;
using UrumiumMVC.DomainClasses.Entities.Product;
using UrumiumMVC.DomainClasses.Entities.Language;
using UrumiumMVC.DomainClasses.Entities.Ticket;
using UrumiumMVC.DomainClasses.Entities.Medicine;
using UrumiumMVC.DomainClasses.Entities.Pharmacy;
using UrumiumMVC.DomainClasses.Entities.Doctor;
using UrumiumMVC.DomainClasses.Entities.judge;
using UrumiumMVC.DomainClasses.Entities.Illness;
using UrumiumMVC.DomainClasses.Entities.Insurance;
using UrumiumMVC.DomainClasses.Entities.Admin;
using UrumiumMVC.DomainClasses.Entities.Visit;
using UrumiumMVC.DomainClasses.Entities.Accounting;
using UrumiumMVC.DomainClasses.Entities.Question;
using UrumiumMVC.DomainClasses.Entities.Noskhe;
using UrumiumMVC.DomainClasses.Entities.Violation;
using UrumiumMVC.DomainClasses.Entities.Nurse;
using UrumiumMVC.DomainClasses.Entities.Notification;

namespace DataLayer.Context
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public int RollId { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IUnitOfWork
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>("DefaultConnection"));
            //Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<City> Cities { get; set; }
        public DbSet<SitePagesInfo> SitePagesInfo { get; set; }
        
        public DbSet<State> States { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Detail> Details { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<FooterItem> FooterItems { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<judge> Judges { get; set; }
        public DbSet<Illness> Illnesses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceDoctor> InsuranceDoctors { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<DoctorDays> DoctorDays { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<VisitTime> VisitTimes { get; set; }
        public DbSet<VisitDoctorAccount> VisitDoctorAccounts { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<CostsPersend> CostsPersends { get; set; }
        public DbSet<Noskhe> Noskhes { get; set; }
        public DbSet<Pharmacy_Massage> Pharmacy_Massages { get; set; }
        public DbSet<IllnessMassage> IllnessMassages { get; set; }
        public DbSet<JudgeIllness> JudgeIllnesses { get; set; }
        public DbSet<Violation> Violations { get; set; }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<DoctorMoarefCode> DoctorMoarefCodes { get; set; }
        public DbSet<DoctorSubsetPassage> DoctorSubsetPassages { get; set; }
        public DbSet<Illness_Pharmacy_Massage> IllnessPharmacyMassages { get; set; }


        public DbSet<UserAnswerToQuestion> UserAnswerToQuestions { get; set; }
        public bool ValidateOnSaveEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ProxyCreationEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        bool IUnitOfWork.AutoDetectChangesEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool ForceNoTracking { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        #region UnitOfWork
        public void MarkAsDeleted<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Deleted;
        }
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public void MarkAsChanged<TEntity>(TEntity entity) where TEntity : class
        {
            Entry(entity).State = EntityState.Modified;
        }

        public IList<T> GetRows<T>(string sql, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sql, parameters).ToList();
        }

        public void ForceDatabaseInitialize()
        {
            Database.Initialize(true);
        }

        public override int SaveChanges()
        {
            return SaveAllChanges();
        }

        public int SaveAllChanges(bool invalidateCacheDependencies = true)
        {
            var changedEntityNames = GetChangedEntityNames();
            var result = base.SaveChanges();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }

        private string[] GetChangedEntityNames()
        {
            return ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Added ||
                            x.State == EntityState.Modified ||
                            x.State == EntityState.Deleted)
                .Select(x => ObjectContext.GetObjectType(x.Entity.GetType()).FullName)
                .Distinct()
                .ToArray();
        }
        public override Task<int> SaveChangesAsync()
        {
            return SaveAllChangesAsync();
        }

        public Task<int> SaveAllChangesAsync(bool invalidateCacheDependencies = true)
        {
            var changedEntityNames = GetChangedEntityNames();
            var result = base.SaveChangesAsync();
            if (invalidateCacheDependencies)
            {
                new EFCacheServiceProvider().InvalidateCacheDependencies(changedEntityNames);
            }
            return result;
        }

        public void AutoDetectChangesEnabled(bool flag = true)
        {
            Configuration.AutoDetectChangesEnabled = flag;
        }

        public IList<string> GetUserPermissions(int[] roleIds)
        {
            throw new NotImplementedException();
        }

        public void MarkAsDetached<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void MarkAsAdded<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TEntity> AddThisRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void EnableFiltering(string name)
        {
            throw new NotImplementedException();
        }

        public void EnableFiltering(string name, string parameter, object value)
        {
            throw new NotImplementedException();
        }

        public void DisableFiltering(string name)
        {
            throw new NotImplementedException();
        }

        public void BulkInsertData<T>(IList<T> data)
        {
            throw new NotImplementedException();
        }

        public T Update<T>(T entity, Expression<Func<IUpdateConfiguration<T>, object>> mapping) where T : class, new()
        {
            throw new NotImplementedException();
        }
        #endregion //UnitOfWork

    }
}
