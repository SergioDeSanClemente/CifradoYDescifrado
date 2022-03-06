using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMvcSergioDeSanClemente.Helpers {
    public static class HelperCryptography {
        public static string GenerateSalt() {
            Random random = new Random();
            string salt = "";
            for (int i = 0; i < 27; i++) {
                int numero = random.Next(65, 90);
                char letra = Convert.ToChar(numero);
                salt += letra;
            }
            return salt;
            
        }
        public static bool CompareArrays(byte[] a, byte[] b) {
            bool iguales = true;
            if (a.Length != b.Length) {
                iguales = false;
            }
            else {
                for (int i = 0; i < a.Length; i++) {
                    if (a[i].Equals(b[i]) == false) {
                        iguales = false;
                        break;
                    }
                }
            }
            return iguales;    
        }
        public static byte[] EncriptarPassword(string password, string salt) {
            string contenido = password + salt;
            SHA256Managed sha = new SHA256Managed();
            byte[] salida = Encoding.UTF8.GetBytes(contenido);
            for (int i = 0; i < 255; i++) {
                salida = sha.ComputeHash(salida);
            }
            sha.Clear();
            return salida;
        }
        public static string EncryptString(string plainText, string key)  
        {  
            byte[] iv = new byte[16];  
            byte[] array;  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(key+"2post");  
                aes.IV = iv;  
  
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream())  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))  
                    {  
                        using (StreamWriter streamWriter = new StreamWriter((Stream)cryptoStream))  
                        {  
                            streamWriter.Write(plainText);  
                        }  
  
                        array = memoryStream.ToArray();  
                    }  
                }  
            }  
  
            return Convert.ToBase64String(array);  
        }  
  
        public static string DecryptString(string cipherText, string key)  
        {  
            byte[] iv = new byte[16];  
            byte[] buffer = Convert.FromBase64String(cipherText);  
  
            using (Aes aes = Aes.Create())  
            {  
                aes.Key = Encoding.UTF8.GetBytes(key + "2post");  
                aes.IV = iv;  
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);  
  
                using (MemoryStream memoryStream = new MemoryStream(buffer))  
                {  
                    using (CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))  
                    {  
                        using (StreamReader streamReader = new StreamReader((Stream)cryptoStream))  
                        {  
                            return streamReader.ReadToEnd();  
                        }  
                    }  
                }  
            }  
        }  
    }
}
