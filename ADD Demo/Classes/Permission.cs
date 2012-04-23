using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Principal;
using System.Web.Security;

namespace ADD_Demo.Classes
{
 
    public class Permission
    {
        public bool UserAccess { get { return CheckUserAccess(user); } }
        public bool Add { get { return CheckAdd(user); } }
        public bool Edit { get { return CheckEdit(user); } }
        public bool Delete { get { return CheckDelete(user); } }
        public bool Display { get { return CheckDisplay(user); } }
        public bool Report { get { return CheckReport(user); } }

        private IPrincipal user;

        public Permission(IPrincipal user)
        {
           this.user = user;
        }

        private static bool CheckUserAccess(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/User Access", user, "GET");
        }

        private static bool CheckAdd(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/Add", user, "GET");
        }

        private static bool CheckEdit(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/Edit", user, "GET");
        }

        private static bool CheckDelete(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/Delete", user, "GET");
        }

        private static bool CheckDisplay(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/Display", user, "GET");
        }

        private static bool CheckReport(IPrincipal user)
        {
            return UrlAuthorizationModule.CheckUrlAccessForPrincipal("/Permissions/Report", user, "GET");
        }
    }
}