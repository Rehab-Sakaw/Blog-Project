using Blog.Models;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Blog
{
    public class AuthProvider: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            string UserNameval = context.UserName;
            string PassVal = context.Password;
            BlogContext ObjContext = new BlogContext();
            var userdata = ObjContext.User.Where(u => u.Name == context.UserName && u.Password == context.Password).FirstOrDefault();
            //var userdata = ObjContext.User.FirstOrDefault(u=>u.Name == UserNameval );
            if (userdata != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userdata.Role));
                identity.AddClaim(new Claim(ClaimTypes.Name, userdata.Name));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                context.Rejected();
            }
        }
    }
}