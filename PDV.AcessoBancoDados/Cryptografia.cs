using System;
using System.Security.Cryptography;
using System.Text;

namespace PDV.AcessoBancoDados
{
    public class Cryptografia
    {
        string myKey;
        public Cryptografia()
        {
            myKey = "DFD@$/*9068fSiusdWSIKJKSAhgdf¨%&*&1231";
        }

        public static string MD5(string texto)
        {
            var provider = new MD5CryptoServiceProvider();
            var buffer = Encoding.UTF8.GetBytes(texto);
            buffer = provider.ComputeHash(buffer);
            var strSaida = new StringBuilder();
            foreach (var b in buffer)
            {
                strSaida.Append(b.ToString("x2").ToLower());
            }

            return strSaida.ToString().ToUpper();
        }

        TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

        public string Crypto(string texto, bool op)
        {
            if (op)
            {
                string s = Cifra(texto);
                return s;
            }
            else
            {
                string s = DeCifra(texto);
                return s;
            }
        }

        private string Cifra(string texto)
        {
            des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateEncryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(texto);
            string str = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            return str;
        }

        private string DeCifra(string texto)
        {
            des.Key = hashmd5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            des.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = des.CreateDecryptor();
            ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
            byte[] buff = Convert.FromBase64String(texto);
            string str = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            return str;
        }

    }
}
