using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace NewSDRR
{
    public static class SecuritySupport
    {
        public static String FileToEncrypt { get; set;  }
        public static String FileToDecrypt { get;set; }
        public static String OutputEncrypt { get; set; }
        public static String OutputDecrypt { get; set; }
        public static FileStream fsInput;
        public static FileStream fsOutput;
        static string PasswordHash = "cfsSc&@";
        static string SaltKey = "S@sTsKEYd";
        static string VIKey = "@bcdc3D4adv6d7H8";
        public enum CrypToAction
        {
            ActionEncrypt,
            ActionDecrypt,
            File
        }

        public static byte[] CreateKey(String Pass)
        {
            Pass = Pass.Replace("'", "");
            //plainText += "'" + HttpContext.Current.Request.UserHostAddress;
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Pass);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }

            return cipherTextBytes;
     }
        public static String GetSHA1Digest(String message)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(message);
                System.Security.Cryptography.SHA1 sha1 = new
                System.Security.Cryptography.SHA1CryptoServiceProvider();
                byte[] result = sha1.ComputeHash(data);
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                for (int i = 0; i < result.Length; i++)
                    sb.Append(result[i].ToString("X2"));
                return sb.ToString().ToLower();
            }
            catch (Exception)
            {
                return "";
            }
        }
        public static String Encrypt(this String plainText)
        {
            plainText = plainText.Replace("'", "");
            //plainText += "'" + HttpContext.Current.Request.UserHostAddress;
            //plainText = GetSHA1Digest(plainText);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

            byte[] cipherTextBytes;

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                    cryptoStream.FlushFinalBlock();
                    cipherTextBytes = memoryStream.ToArray();
                    cryptoStream.Close();
                }
                memoryStream.Close();
            }
            return Convert.ToBase64String(cipherTextBytes);
        }
        public static String Decrypt(this String encryptedText)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
            byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];

            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray()).Split(new String[] { "'" }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
        public static String GetMD5Digest(String FileName)
        {
            FileStream file = new FileStream(FileName, FileMode.Open);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] retVal = md5.ComputeHash(file);
            file.Close();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < retVal.Length; i++)
            {
                sb.Append(retVal[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static void EncryptOrDecryptFile(String Pass, String InputFile, String OutputFile,bool IsEncrypt)
        {
            fsInput = new FileStream(InputFile, FileMode.Open, FileAccess.Read);
            fsOutput = new FileStream(OutputFile, FileMode.OpenOrCreate, FileAccess.Write);
            fsOutput.SetLength(0);

            CryptoStream csCryptoStream;
            RijndaelManaged cspRijndael = new RijndaelManaged();
            Byte[] Buffer = new Byte[4096];
            long BytesProcessed = 0;
            long FileLength = fsInput.Length;
            int ByteInCurrentBlock;
            Byte[] Key = CreateKey(Pass);
            Byte[] VIKey = CreateKey(Pass);

            if (IsEncrypt == true)            
                csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateEncryptor(Key, VIKey), CryptoStreamMode.Write);
            else
                csCryptoStream = new CryptoStream(fsOutput, cspRijndael.CreateDecryptor(Key, VIKey), CryptoStreamMode.Write);
            

            //'Use While to loop until all of the file is processed.
             do
             {
                //'Read file with the input filestream.
                ByteInCurrentBlock = fsInput.Read(Buffer, 0, 4096);
                //'Write output file with the cryptostream.
                csCryptoStream.Write(Buffer, 0, ByteInCurrentBlock);
                //'Update lngBytesProcessed
                BytesProcessed = BytesProcessed + ByteInCurrentBlock;
                //'Update Progress Bar
                //pbStatus.Value = CInt((lngBytesProcessed / lngFileLength) * 100)
            }while (BytesProcessed < FileLength);

            //'Close FileStreams and CryptoStream.
            csCryptoStream.Close();
            fsInput.Close();
            fsOutput.Close();
        }
    }
}
