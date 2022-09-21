using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Text;


namespace Paycore.Base.Util
{
    public class Util
    {
        public static string HashToMD5(string password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] array = Encoding.UTF8.GetBytes(password);
            array= md5.ComputeHash(array);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (byte item in array)
            {
                //In more depth the argument "X2" is a "format string" that tells the ToString() method 
                //how it should format the string.In this case, "X2" indicates the string should be formatted in Hexadecimal.

                stringBuilder.Append(item.ToString("x2").ToLower());
            }

            return stringBuilder.ToString();
        }
        
        public static int GetIdFromToken(string bearerToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(bearerToken);
            var jti = jwtSecurityToken.Claims.First(claim => claim.Type == "ID").Value;
            return int.Parse(jti);
        }
    }
}
