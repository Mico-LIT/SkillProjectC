using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;

namespace CSharp
{
    internal class WorkTime
    {
        static Random random = new Random();

        public void Main()
        {
            TMP();

            Console.Read();
        }

        public class OperatorInfo
        {
            public int RefId { get; set; }
            public string Description { get; set; }
            public string Brand { get; set; }
            public string DesktopDomain { get; set; }
            public string MobileDomain { get; set; }
            public string MerchantCode { get; set; }
            public string VendorId { get; set; }
            public string MerchantPasscode { get; set; }
        }

        private static void TMP()
        {
        }

        [DataContract]
        public class Response
        {
            [DataMember(EmitDefaultValue = false)] public string channelId { get; set; }
            [DataMember(EmitDefaultValue = false)] public string accountId { get; set; }
            [DataMember(EmitDefaultValue = false)] public decimal? balance { get; set; }
            [DataMember(EmitDefaultValue = false)] public string currency { get; set; }
            [DataMember] public int errorCode { get; set; }
            [DataMember(EmitDefaultValue = false)] public string returnTime { get; set; }
            [DataMember(EmitDefaultValue = false)] public string nickName { get; set; }
        }

        [Serializable]
        public class LoginRequestTryToPlayResponse
        {
            public int ErrorMsgId { get; set; }
            public string ErrorMsg { get; set; }
            public string Token { get; set; }
            public string DisplayName { get; set; }
            public string SlotGameURL { get; set; }
            public string GameURL { get; set; }
        }

        internal static T Deserialize<T>(string raw)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(raw)))
            {
                return (T)ser.Deserialize(stream);
            }
        }

        internal static string DESEncrypt(string input)
        {
            var encryptKey = Encoding.ASCII.GetBytes("g9G16nTs");

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, new DESCryptoServiceProvider().CreateEncryptor(encryptKey, encryptKey), CryptoStreamMode.Write))
                {
                    using (var sw = new StreamWriter(cs))
                    {
                        sw.Write(input);
                        sw.Flush();
                        cs.FlushFinalBlock();
                        sw.Flush();
                        return Convert.ToBase64String(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));

                    }
                }
            }
        }

        public static string GetMd5Hash(byte[] input)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            using (MD5 md5Hasher = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hasher.ComputeHash(input);

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                StringBuilder sBuilder = new StringBuilder();

                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                // Return the hexadecimal string.
                return sBuilder.ToString();
            }
        }

    }
}
