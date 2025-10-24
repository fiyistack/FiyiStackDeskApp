using System.Security.Cryptography;
using System.Text;

namespace FiyiStackDeskApp.Library
{
    public static class Security
    {
        public static string EncodeString(string StringToEncode)
        {
            try
            {
                UnicodeEncoding Encoder = new();
                SHA512Managed SHA512 = new();

                string EncodedString = Convert.ToBase64String(SHA512.ComputeHash(Encoder.GetBytes(StringToEncode)));

                return EncodedString;
            }
            catch (Exception) { throw; }
        }

        public enum EWaterMarkFor { MSSQLServer, CSharp, TypeScriptAndJavaScript };

        public static string WaterMark(EWaterMarkFor EWaterMarkFor)
        {
            string WaterMark = "";
            switch (EWaterMarkFor)
            {
                case EWaterMarkFor.MSSQLServer:
                    WaterMark = $@"/*
 * 
 * Coded by fiyistack.com
 * Copyright © {DateTime.Now.Year}
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */";
                    break;
                case EWaterMarkFor.CSharp:
                    WaterMark = $@"/*
 * 
 * Coded by fiyistack.com
 * Copyright © {DateTime.Now.Year}
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
 */";
                    break;
                case EWaterMarkFor.TypeScriptAndJavaScript:
                    WaterMark = $@"/*
 * 
 * Coded by fiyistack.com
 * Copyright © {DateTime.Now.Year}
 * 
 * The above copyright notice and this permission notice shall be included
 * in all copies or substantial portions of the Software.
 * 
*/";
                    break;
                default:
                    break;
            }

            return WaterMark;
        }
    }
}
