using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Authentication;
using System.Security.Claims;

namespace CQRSSAmple.Domain.Infrasctructure.Authorization
{
    public static class UserExtensions
    {
        private static Claim Search(ClaimsPrincipal user, string name)
        {
            return user.Claims.Where(c => c.Type == name).FirstOrDefault() ?? throw new AuthenticationException("err_claim_not_found");
        }
        public static Guid ID(this ClaimsPrincipal user)
        {
            var result = Guid.TryParse(Search(user, "ID").Value, out var id);

            return result
                ? id
                : throw new AuthenticationException("err_invalid_ID");
        } 
        
        //public static Guid Sub(this ClaimsPrincipal user)
        //{
        //    var result = Guid.TryParse(Search(user, "mv-guid").Value, out var id);
//
        //    return result
        //        ? id
        //        : throw new AuthenticationException("err_invalid_sub");
        //}
//
        //public static string Email(this ClaimsPrincipal user)
        //{
        //    static bool ValidateEmail(string address)
        //    {
        //        try
        //        {
        //            var mailAddress = new MailAddress(address);
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    }
//
        //    var address = Search(user, "mv-name").Value;
        //    var result = ValidateEmail(address);
//
        //    return result
        //        ? address
        //        : throw new AuthenticationException("err_invalid_email");
        //}
        
    }
}