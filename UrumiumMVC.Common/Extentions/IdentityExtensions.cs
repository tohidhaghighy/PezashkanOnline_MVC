using System.Security.Claims;
using System.Security.Principal;

namespace OstanAg.Common.Extentions
{
    public static class IdentityExtensions

    {
        public static string FullName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FullName");
            return (claim != null) ? claim.Value : "";
        }

        public static string Avatar(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Avatar");

            return (claim != null) ? claim.Value : "";
        }

    }
}
