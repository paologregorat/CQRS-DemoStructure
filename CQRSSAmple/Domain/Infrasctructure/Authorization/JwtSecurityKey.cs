using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace CQRSSAmple.Domain.Infrasctructure.Authorization
{
    public static class JwtSecurityKey  
    {  
        public static SymmetricSecurityKey Create(string secret)  
        {  
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret));  
        }  
    }  
}