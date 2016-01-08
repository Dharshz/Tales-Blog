using ClassLibrary1;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Tales.Data;

namespace Tales.AngularWeb.Infrastructure
{
    public class TalesUserManager : UserManager<User>
    {

        public TalesUserManager(IUserStore<User> store)
            : base(store)
        {
        }

        public static TalesUserManager Create(IdentityFactoryOptions<TalesUserManager> options, IOwinContext context)
        {
            var manager = new TalesUserManager(new UserStore<User>(context.Get<BlogEntities>()));

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<User>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Password Validations
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<User>(dataProtectionProvider.Create("ASP.NET Identity"));
            }

            return manager;
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(User user, string authenticationType)
        {
            var userIdentity = await CreateIdentityAsync(user, authenticationType);

            return userIdentity;
        }

    }
}