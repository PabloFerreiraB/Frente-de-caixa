using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace PDV.AcessoBancoDados
{
    public class ConfiguracaoXML
    {
        #region INSTANCIAS

        DataSet dtSet = new DataSet();
        DataTable dtTable = new DataTable();
        TripleDESCryptoServiceProvider DESCrypto = new TripleDESCryptoServiceProvider();
        MD5CryptoServiceProvider MD5Crypto = new MD5CryptoServiceProvider();
        string MyKey;
        string patch = AppDomain.CurrentDomain.BaseDirectory + @"\Config.xml";

        #endregion

        #region PROPRIEDADES

        public string Servidor { get; set; }

        public string BancoDados { get; set; }

        public string Usuario { get; set; }

        public string Senha { get; set; }

        #endregion

        #region MÉTODOS

        public void LerConfiguracaoBanco()
        {
            MyKey = "DFD@$/*9068fSiusdWSIKJKSAhgdf¨%&*&1231";
            dtSet.ReadXml(patch);

            if (dtSet.Tables[0].Rows.Count > 0)
            {
                DESCrypto.Key = MD5Crypto.ComputeHash(ASCIIEncoding.ASCII.GetBytes(MyKey));
                DESCrypto.Mode = CipherMode.ECB;

                ICryptoTransform desdencrypt = DESCrypto.CreateDecryptor();
                ICryptoTransform desencrypt = DESCrypto.CreateEncryptor();

                ASCIIEncoding MyASCIIEncoding = new ASCIIEncoding();
                Byte[] buff;

                MyASCIIEncoding = new ASCIIEncoding();
                buff = Convert.FromBase64String(dtSet.Tables[0].Rows[0]["Senha"].ToString());

                if (buff.Length > 0)
                    Senha = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
                else
                    Senha = string.Empty;

                Servidor = dtSet.Tables[0].Rows[0]["Servidor"].ToString();
                BancoDados = dtSet.Tables[0].Rows[0]["BancoDados"].ToString();
                Usuario = dtSet.Tables[0].Rows[0]["Usuario"].ToString();
            }
        }

        #endregion
    }
}
