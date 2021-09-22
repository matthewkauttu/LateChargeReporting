using System.Security.Principal;

namespace MvcLocalSecurity.AccessControl {
    public class ApplicationPrincipal : IPrincipal {
        private readonly IPrincipal principal;

        public ApplicationPrincipal( IPrincipal principal, int userSecurity, string userName ) {
            this.principal = principal;
            SecurityLevel = userSecurity;
            Name = userName;
        }

        public int SecurityLevel { get; }
        public string Name { get; }

        public IIdentity Identity {
            get {
                return principal.Identity;
            }
        }

        public bool IsInRole( string role ) {
            return int.Parse(role) == SecurityLevel;
        }
    }
}