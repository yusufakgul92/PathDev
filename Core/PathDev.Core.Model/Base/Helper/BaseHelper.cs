using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace PathDev.Core.Model.Base.Helper
{
    public static class BaseHelper
    {
        public static string TelefonNumarasiDuzenle(string eskiTel)
        {
            var tel = "";
            try
            {
                if (string.IsNullOrEmpty(eskiTel)) return "";
                eskiTel = eskiTel.Trim();
                eskiTel = eskiTel.Replace(" ", "");
                eskiTel = eskiTel.Replace("(", "");
                eskiTel = eskiTel.Replace(")", "");
                eskiTel = eskiTel.Replace("-", "");
                eskiTel = eskiTel.Replace("_", "");
                var rakamlar = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                var bozukKarakterler = new List<string>();
                for (var i = 0; i < eskiTel.Length; i++)
                {
                    var karakter = eskiTel.Substring(i, 1);
                    if (!rakamlar.Contains(karakter)) bozukKarakterler.Add(karakter);
                }
                bozukKarakterler.Distinct();
                for (var i = 0; i < bozukKarakterler.Count; i++)
                {
                    eskiTel = eskiTel.Replace(bozukKarakterler[i], "");
                }

                if (eskiTel.Length >= 10) eskiTel = eskiTel.StartsWith("0") ? eskiTel : $@"0{eskiTel}";
                tel = eskiTel;
            }
            catch (Exception)
            {
            }
            return tel;
        }
        public static string TelefonNumarasiDuzenleGoldenSms(string eskiTel)
        {
            var tel = "";
            try
            {
                if (string.IsNullOrEmpty(eskiTel)) return "";
                eskiTel = eskiTel.Trim();
                eskiTel = eskiTel.Replace(" ", "");
                eskiTel = eskiTel.Replace("(", "");
                eskiTel = eskiTel.Replace(")", "");
                eskiTel = eskiTel.Replace("-", "");
                eskiTel = eskiTel.Replace("_", "");
                var rakamlar = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
                var bozukKarakterler = new List<string>();
                for (var i = 0; i < eskiTel.Length; i++)
                {
                    var karakter = eskiTel.Substring(i, 1);
                    if (!rakamlar.Contains(karakter)) bozukKarakterler.Add(karakter);
                }
                bozukKarakterler.Distinct();
                for (var i = 0; i < bozukKarakterler.Count; i++)
                {
                    eskiTel = eskiTel.Replace(bozukKarakterler[i], "");
                }

                if (eskiTel.Length == 10)
                {
                    eskiTel = "90" + eskiTel;
                }
                else if (eskiTel.Length == 11)
                {
                    eskiTel = "9" + eskiTel;
                }
                tel = eskiTel;
            }
            catch (Exception)
            {
            }
            return tel;
        }
        public static string HashPasswordUsingMD5(string password)
        {
            using (var md5 = MD5.Create())
            {
                byte[] passwordBytes = Encoding.ASCII.GetBytes(password);

                byte[] hash = md5.ComputeHash(passwordBytes);

                var stringBuilder = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                    stringBuilder.Append(hash[i].ToString("X2"));

                return stringBuilder.ToString();
            }
        }
        public static SymmetricSecurityKey CreateSecurityKey(string Key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
        }
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, algorithm: SecurityAlgorithms.HmacSha256Signature);
        }

        public static string GenerateSlug(string phrase)
        {
            var s = phrase.ToLower();
            s = Regex.Replace(s, @"\s+", " ").Trim();                       // single space
            s = s.Substring(0, s.Length <= 45 ? s.Length : 45).Trim();      // cut and trim
            s = Regex.Replace(s, @"\s", "-");                               // insert hyphens
            //s = s.Replace("ş", "s").Replace("Ş", "s").Replace("ç", "c").Replace("Ç", "c").Replace("ö", "o").Replace("Ö", "o").Replace("ü", "u").Replace("Ü", "u").Replace("İ", "i").Replace("ı", "i").Replace("ğ", "g").Replace("Ğ", "g");                   // remove invalid characters
            s = Regex.Replace(s, @"[^a-z0-9\s-]", "");                      // remove invalid characters
            return s.ToLower();
        }

    }
}
