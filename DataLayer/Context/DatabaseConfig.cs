using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Web;
using System.Data.Entity.Migrations;
using System.Net.Mail;
using System.Text;
using System.Net;

namespace DataLayer.Context
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,
            IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };
            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 8,
            };
            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug in here.
            manager.RegisterTwoFactorProvider("PhoneCode", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is: {0}"
            });
            manager.RegisterTwoFactorProvider("EmailCode", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "SecurityCode",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public Task FindByIdAsync<T>(Func<T> getUserId) where T : IConvertible
        {
            throw new NotImplementedException();
        }
    }

    // Configure the RoleManager used in the application. RoleManager is defined in the ASP.NET Identity core assembly
    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static ApplicationRoleManager Create(IdentityFactoryOptions<ApplicationRoleManager> options, IOwinContext context)
        {
            return new ApplicationRoleManager(new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>()));
        }
    }

    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your email service here to send an email.

            //MailMessage msg = new MailMessage();
            //msg.Body = message.Body;
            //msg.BodyEncoding = Encoding.UTF8;
            //msg.IsBodyHtml = true;
            //msg.From = new MailAddress("tohidhaghighi@gmail.com", "کد کده", Encoding.UTF8);
            //msg.Priority = MailPriority.Normal;
            //msg.Sender = msg.From;
            //msg.Subject = message.Subject;
            //msg.SubjectEncoding = Encoding.UTF8;
            //msg.To.Add(new MailAddress(message.Destination, "گیرنده", Encoding.UTF8));

            //SmtpClient smtp;
            //using (smtp = new SmtpClient())
            //{
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Port = 587;
            //    smtp.EnableSsl = true;
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = new NetworkCredential("tohidhaghighi@gmail.com", "Taktazegarn0123");
            //    smtp.Send(msg);
            //}
            using (MailMessage mm = new MailMessage("tohidhaghighi@gmail.com", message.Destination))
            {
                mm.Subject = message.Subject;
                string s = "<div><h2 class='text-center'>کد تایید ایمیل شما </h2></div></br>";
                string s1 = "<div><h2 class='text-center'>بعد از ثبت نام در سیستم ما باید ایمیل شما تایید شود برای همین این ایمیل برای شما ارسال شده تا هویت شما تایید شود </h2></div></br>";
                mm.Body = s + s1 + message.Body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("tohidhaghighi@gmail.com", "taktazegarn0123");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }

            //using (MailMessage mm = new MailMessage("info@dr-sina.ir", message.Destination))
            //{
            //    mm.Subject = message.Subject;
            //    string s = "<div><h2 class='text-center'>کد تایید ایمیل شما </h2></div></br>";
            //    string s1 = "<div><h2 class='text-center'>بعد از ثبت نام در سیستم ما باید ایمیل شما تایید شود برای همین این ایمیل برای شما ارسال شده تا هویت شما تایید شود </h2></div></br>";
            //    mm.Body = s + s1 + message.Body;
            //    mm.IsBodyHtml = true;
            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "mail.dr-sina.ir";
            //    smtp.EnableSsl = false;
            //    NetworkCredential NetworkCred = new NetworkCredential("info@dr-sina.ir", "taktazegarn0123");
            //    smtp.UseDefaultCredentials = true;
            //    smtp.Credentials = NetworkCred;
            //    smtp.Port = 25;
            //    smtp.Send(mm);
            //}
            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your sms service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // This is useful if you do not want to tear down the database each time you run the application.
    // public class ApplicationDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    // This example shows you how to create a new database if the Model changes
    public class ApplicationDbInitializer : DbMigrationsConfiguration<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            context.Roles.AddOrUpdate(x => x.Id,
             new IdentityRole() { Id = "a871c4ce-0260-41e5-b65e-13d3a9ea6804", Name = "Admin" },
             new IdentityRole() { Id = "9c6f3342-c84d-4a21-b1d9-e33e5ed92199", Name = "User" }
             );
            
            //InitializeIdentityForEF(context);
            base.Seed(context);
        }

        //Create User=Admin@Admin.com with password=Admin@123456 in the Admin role        
        public static void InitializeIdentityForEF(ApplicationDbContext db)
        {
            var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var roleManager = HttpContext.Current.GetOwinContext().Get<ApplicationRoleManager>();
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleresult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }

    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
            base(userManager, authenticationManager)
        { }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
