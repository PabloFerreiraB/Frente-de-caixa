using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PDV.AcessoBancoDados
{
    public class Util
    {
        public SqlConnection conn;
        protected SqlCommand cmdgeral;
        ConfiguracaoXML configuracaoXML = new ConfiguracaoXML();

        public Util()
        {
            configuracaoXML.LerConfiguracaoBanco();
            string strConn = string.Format("Server={0};Database={1};user={2};password={3};", configuracaoXML.Servidor, configuracaoXML.BancoDados, configuracaoXML.Usuario, configuracaoXML.Senha);
            conn = new SqlConnection(strConn);

            cmdgeral = new SqlCommand();
            cmdgeral.Connection = conn;
        }

        #region Instâncias

        //private static EmailsEnviadosControl _objEmailControl = new EmailsEnviadosControl();
        //private static ClienteEmailControl _objClienteEmailControl = new ClienteEmailControl();

        #endregion

        #region PROPRIEDADES

        public SqlConnection Conexao
        {
            get { return conn; }
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Metodo responsavel por abrir a conexão com a base de dados
        /// </summary>
        public void AbrirConexao()
        {
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
        }

        /// <summary>
        /// Metodo responsavel por fechar a conexão com a base de dados
        /// </summary>
        public void FecharConexao()
        {
            conn.Close();
        }

        /// <summary>
        /// Metodo que testa a conexão com a base de dados
        /// </summary>
        /// <returns>True/False</returns>
        public Boolean TestarConexao()
        {
            try
            {
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                    return true;
                }
                return true;
            }
            catch (Exception) { return false; }
        }

        /// <summary>
        ///     Método responsável por realizar instruções de Insert,Delete e Update.
        /// </summary>
        /// <param name="sql">Instrução sql a ser executada</param>
        /// <returns>True/False</returns>
        public bool Executar(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                cmd.ExecuteNonQuery();

                return true;
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao executar a instrução SQL: {0}", ex.Message), ex);
            }

            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Metodo que realiza pesquisas na base de dados
        /// </summary>
        /// <param name="sqlquery">Comando SQL a ser executado</param>
        /// <returns>DataTable com resultados encontrados</returns>
        public DataTable Pesquisar(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            DataTable dtResultado = new DataTable();

            try
            {
                conn.Open();
                cmd.CommandTimeout = 5000;
                dtResultado.Load(cmd.ExecuteReader());

                return dtResultado;
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao executar a instrução SQL: {0}", ex.Message), ex);
            }

            finally
            {
                conn.Close();
            }
        }

        public DataTable PesquisarCEP(string sqlCEP)
        {
            SqlConnection connCEP = new SqlConnection(string.Format("Server={0};Database={1};user={2};password={3};", configuracaoXML.Servidor, "CEP", configuracaoXML.Usuario, configuracaoXML.Senha));
            SqlCommand cmd = new SqlCommand(sqlCEP, connCEP);
            DataTable dtResultado = new DataTable();

            try
            {
                connCEP.Open();
                dtResultado.Load(cmd.ExecuteReader());

                return dtResultado;
            }

            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro ao executar a instrução SQL: {0}", ex.Message), ex);
            }

            finally
            {
                connCEP.Close();
            }
        }

        /// <summary>
        ///     Método responsável por inserir registros na base de dados
        /// </summary>
        /// <param name="tabela">Nome da tabela</param>
        /// <param name="campos">Lista de campos a serem inseridos</param>
        /// <returns>True/False</returns>
        public bool Inserir(string tabela, List<SqlParametros> campos)
        {
            string _campos = string.Empty;
            string _valores = string.Empty;

            foreach (SqlParametros parametro in campos)
            {
                _campos += string.Format("{0},", parametro.Campo);
                _valores += string.Format("'{0}',", parametro.Valor);
            }

            _campos = _campos.Substring(0, _campos.Length - 1);
            _valores = _valores.Substring(0, _valores.Length - 1);

            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tabela, _campos, _valores);

            return Executar(sql);
        }

        /// <summary>
        /// Metodo responsavel por atualizar um ou mais registo da base de dados
        /// </summary>
        /// <param name="paramTabela">Nome da tabela</param>
        /// <param name="paramCampos">Lista de campos a serem atualizados</param>
        /// <param name="paramCondicoes">Lista de condições para atualização</param>
        /// <returns>True/False</returns>
        public bool Atualizar(string paramTabela, List<SqlParametros> paramCampos, List<SqlParametros> paramCondicoes)
        {
            string campos = string.Empty;

            foreach (SqlParametros parametro in paramCampos)
            {
                campos += string.Format("{0}='{1}',", parametro.Campo, parametro.Valor);
            }

            campos = campos.Substring(0, campos.Length - 1);

            string condicoes = string.Empty;

            foreach (SqlParametros condicao in paramCondicoes)
            {
                condicoes += string.Format("{0}='{1}' AND ", condicao.Campo, condicao.Valor);
            }

            condicoes = condicoes.Substring(0, condicoes.Length - 4);

            return Executar(string.Format("UPDATE {0} SET {1} WHERE ({2});", paramTabela, campos, condicoes));
        }

        /// <summary>
        ///     Método responsável por apagar um registro no banco
        /// </summary>
        /// <param name="tabela">Nome da Tabela</param>
        /// <param name="condicoes">Lista de Condições para a clausula where</param>
        /// <returns>True/False</returns>
        public bool Excluir(string tabela, List<SqlParametros> paramCondicoes)
        {
            string condicoes = string.Empty;

            foreach (SqlParametros condicao in paramCondicoes)
            {
                condicoes += string.Format("{0}='{1}' AND ", condicao.Campo, condicao.Valor);
            }

            condicoes = condicoes.Substring(0, condicoes.Length - 4);

            return Executar(string.Format("DELETE FROM {0} WHERE ({1});", tabela, condicoes));
        }

        /// <summary>
        ///     Método responsável por retornar o último número gerado por auto incremento
        /// </summary>
        /// <returns>Último ID</returns>
        public int PegarUltimoID(string tabela, string campo)
        {
            try
            {
                string sql = string.Format("SELECT MAX({0}) FROM {1};", campo, tabela);
                return Convert.ToInt32(Pesquisar(sql).Rows[0][0]);
            }
            catch
            {
                return 1;
            }
        }

        /// <summary>
        /// Método responsavel por executar uma instrução SQL retornando apenas uma string
        /// </summary>
        /// <param name="SQLQuery">Comando SQL a ser executado</param>
        /// <returns>String (Texto)</returns>
        public string ExecuteScalar(string SQLQuery)
        {
            try
            {
                object obj = Pesquisar(SQLQuery).Rows.Count > 0 ? Pesquisar(SQLQuery).Rows[0][0] : string.Empty;
                if (obj != null)
                {
                    return obj.ToString();
                }
                else
                    return string.Empty;
            }
            catch (Exception e)
            {
                throw new Exception(string.Format("Erro ao executar a instrução SQL: {0}", e.Message), e);
            }

        }

        public decimal PegarCampoDecimal(string tabela, string campo, string paramCondicao, int paramValor)
        {
            try
            {
                string sql = string.Format("SELECT ISNULL({0},0) FROM {1} WHERE {2} = {3};", campo, tabela, paramCondicao, paramValor);
                return Convert.ToDecimal(Pesquisar(sql).Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public int PegarCampoInteiro(string tabela, string campo, string paramCondicao, int paramValor)
        {
            try
            {
                string sql = string.Format("SELECT ISNULL({0},0) FROM {1} WHERE {2} = {3};", campo, tabela, paramCondicao, paramValor);
                return Convert.ToInt32(Pesquisar(sql).Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public bool PegarPorCampoBooleano(string paramNomeTabela, string paramNomeCampo)
        {
            DataRow r = Pesquisar(string.Format("SELECT ISNULL({0},0) FROM {1}", paramNomeCampo, paramNomeTabela)).Rows[0];

            return r[0].ToString().Equals("True");
        }

        public bool PesquisarPorCampoBooleano(string paramNomeTabela, string paramNomeCampo, string paramCondicao, string paramValor)
        {
            DataRow r = Pesquisar(string.Format("SELECT ISNULL({0},0) FROM {1} WHERE {2} = {3}", paramNomeCampo, paramNomeTabela, paramCondicao, paramValor)).Rows[0];

            return r[0].ToString().Equals("True");
        }


        /// <summary>
        /// Metodo que repassa Enter por Tab
        /// </summary>
        /// <param name="s">KeyEventArgs</param>
        public static void Tabfunction(KeyEventArgs s)
        {
            if (s.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
                s.SuppressKeyPress = true;
            }
        }

        public static void ShiftTabfunction(KeyEventArgs s)
        {
            if (s.KeyCode == Keys.Left)
            {
                SendKeys.Send("+{Tab}");
                s.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Metodo que verifica se um cpf é valido
        /// </summary>
        /// <param name="CPF">CPF</param>
        /// <returns>True or False</returns>
        public static bool ValidaCPF(string CPF)
        {
            int d1, d2;
            int soma = 0;
            string digitado = "";
            string calculado = "";

            // Pesos para calcular o primeiro digito
            int[] peso1 = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            // Pesos para calcular o segundo digito
            int[] peso2 = new int[] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] n = new int[11];

            if (CPF == "")
                return true;

            // Se o tamanho for < 11 entao retorna como inválido
            if (CPF.Length != 11)
                return false;

            // Caso coloque todos os numeros iguais
            switch (CPF)
            {
                case "11111111111":
                    return false;
                case "00000000000":
                    return false;
                case "22222222222":
                    return false;
                case "33333333333":
                    return false;
                case "44444444444":
                    return false;
                case "55555555555":
                    return false;
                case "66666666666":
                    return false;
                case "77777777777":
                    return false;
                case "88888888888":
                    return false;
                case "99999999999":
                    return false;
            }

            try
            {
                // Quebra cada digito do CPF
                n[0] = Convert.ToInt32(CPF.Substring(0, 1));
                n[1] = Convert.ToInt32(CPF.Substring(1, 1));
                n[2] = Convert.ToInt32(CPF.Substring(2, 1));
                n[3] = Convert.ToInt32(CPF.Substring(3, 1));
                n[4] = Convert.ToInt32(CPF.Substring(4, 1));
                n[5] = Convert.ToInt32(CPF.Substring(5, 1));
                n[6] = Convert.ToInt32(CPF.Substring(6, 1));
                n[7] = Convert.ToInt32(CPF.Substring(7, 1));
                n[8] = Convert.ToInt32(CPF.Substring(8, 1));
                n[9] = Convert.ToInt32(CPF.Substring(9, 1));
                n[10] = Convert.ToInt32(CPF.Substring(10, 1));
            }
            catch
            {
                return false;
            }

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso1.GetUpperBound(0); i++)
                soma += (peso1[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            int resto = soma % 11;

            if (resto == 1 || resto == 0)
                d1 = 0;
            else
                d1 = 11 - resto;

            soma = 0;

            // Calcula cada digito com seu respectivo peso
            for (int i = 0; i <= peso2.GetUpperBound(0); i++)
                soma += (peso2[i] * Convert.ToInt32(n[i]));

            // Pega o resto da divisao
            resto = soma % 11;
            if (resto == 1 || resto == 0)
                d2 = 0;
            else
                d2 = 11 - resto;

            calculado = d1.ToString() + d2.ToString();
            digitado = n[9].ToString() + n[10].ToString();

            // Se os ultimos dois digitos calculados bater com
            // os dois ultimos digitos do cpf entao é válido
            if (calculado == digitado)
                return (true);
            else
                return (false);
        }

        /// <summary>
        /// Metodo que verifica se um CNPJ é valido
        /// </summary>
        /// <param name="CNPJ">CNPJ</param>
        /// <returns>True or False</returns>
        public static bool ValidaCNPJ(string CNPJ)
        {
            if (CNPJ == "")
                return true;

            if (CNPJ.Length != 14)
                return false;

            // Caso coloque todos os numeros iguais
            switch (CNPJ)
            {
                case "11111111111111":
                    return false;
                case "00000000000000":
                    return false;
                case "22222222222222":
                    return false;
                case "33333333333333":
                    return false;
                case "44444444444444":
                    return false;
                case "55555555555555":
                    return false;
                case "66666666666666":
                    return false;
                case "77777777777777":
                    return false;
                case "88888888888888":
                    return false;
                case "99999999999999":
                    return false;
            }

            string l, inx, dig;
            int s1, s2, i, d1, d2, v, m1, m2;
            inx = CNPJ.Substring(12, 2);
            CNPJ = CNPJ.Substring(0, 12);
            s1 = 0;
            s2 = 0;
            m2 = 2;
            for (i = 11; i >= 0; i--)
            {
                l = CNPJ.Substring(i, 1);
                v = Convert.ToInt16(l);
                m1 = m2;
                m2 = m2 < 9 ? m2 + 1 : 2;
                s1 += v * m1;
                s2 += v * m2;
            }
            s1 %= 11;
            d1 = s1 < 2 ? 0 : 11 - s1;
            s2 = (s2 + 2 * d1) % 11;
            d2 = s2 < 2 ? 0 : 11 - s2;
            dig = d1.ToString() + d2.ToString();

            return (inx == dig);
        }

        /// <summary>
        /// Função que permite digitar-se somente numero e virgula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void NumeroAndVirgula(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((e.KeyChar < (char)Keys.D0) || (e.KeyChar > (char)Keys.D9))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    if (e.KeyChar != ',')
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                    else if (txt.Text.Contains(","))
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                }
            }
        }

        /// <summary>
        /// Função que permite digitar somente numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void SomenteNumero(object sender, KeyPressEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if ((e.KeyChar < (char)Keys.D0) || (e.KeyChar > (char)Keys.D9))
            {
                if ((e.KeyChar != (char)Keys.Back))
                {
                    if (e.KeyChar != '/')
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                    else if (txt.Text.Contains("/"))
                    {
                        e.KeyChar = (char)Keys.None;
                    }
                }
            }
        }

        /// <summary>
        /// Metodo que passa moeda para extenso sempre passar em Decimal 99,00
        /// </summary>
        /// <param name="wvalor">Valor C2</param>
        /// <returns>String</returns>
        public static string ValorParaExtenso(decimal paramValor)
        {
            string[] wunidade = { "", " e um", " e dois", " e trez", " e quatro", " e cinco", " e seis", " e sete", " e oito", " e nove" };
            string[] wdezes = { "", " e onze", " e doze", " e treze", " e quatorze", " e quinze", " e dezesseis", " e dezessete", " e dezoito", " e dezenove" };
            string[] wdezenas = { "", " e dez", " e vinte", " e trinta", " e quarenta", " e cinquenta", " e sessenta", " e setenta", " e oitenta", " e noventa" };
            string[] wcentenas = { "", " e cento", " e duzentos", " e trezentos", " e quatrocentos", " e quinhentos", " e seiscentos", " e setecentos", " e oitocentos", " e novecentos" };
            string[] wplural = { " bilhões", " milhões", " mil", "" };
            string[] wsingular = { " bilhão", " milhão", " mil", "" };
            string paramExtenso = "";
            string wfracao;
            string wnumero = paramValor.ToString().Replace(",", "").Trim();
            wnumero = wnumero.Replace(".", "").PadLeft(14, '0');
            if (Int64.Parse(wnumero.Substring(0, 12)) > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    wfracao = wnumero.Substring(i * 3, 3);
                    if (int.Parse(wfracao) != 0)
                    {
                        if (int.Parse(wfracao.Substring(0, 3)) == 100) paramExtenso += " e cem";
                        else
                        {
                            paramExtenso += wcentenas[int.Parse(wfracao.Substring(0, 1))];
                            if (int.Parse(wfracao.Substring(1, 2)) > 10 && int.Parse(wfracao.Substring(1, 2)) < 20) paramExtenso += wdezes[int.Parse(wfracao.Substring(2, 1))];
                            else
                            {
                                paramExtenso += wdezenas[int.Parse(wfracao.Substring(1, 1))];
                                paramExtenso += wunidade[int.Parse(wfracao.Substring(2, 1))];
                            }
                        }
                        if (int.Parse(wfracao) > 1) paramExtenso += wplural;
                        else paramExtenso += wsingular;
                    }
                }
                if (Int64.Parse(wnumero.Substring(0, 12)) > 1) paramExtenso += " reais";
                else paramExtenso += " real";
            }
            wfracao = wnumero.Substring(12, 2);
            if (int.Parse(wfracao) > 0)
            {
                if (int.Parse(wfracao.Substring(0, 2)) > 10 && int.Parse(wfracao.Substring(0, 2)) < 20) paramExtenso = paramExtenso + wdezes[int.Parse(wfracao.Substring(1, 1))];
                else
                {
                    paramExtenso += wdezenas[int.Parse(wfracao.Substring(0, 1))];
                    paramExtenso += wunidade[int.Parse(wfracao.Substring(1, 1))];
                }
                if (int.Parse(wfracao) > 1) paramExtenso += " centavos";
                else paramExtenso += " centavo";
            }
            if (paramExtenso != "") paramExtenso = paramExtenso.Substring(3, 1).ToUpper() + paramExtenso.Substring(4);
            else paramExtenso = "Nada";
            return paramExtenso;
        }

        //public static bool EnviarEmail(string paramSmtp, int paramPorta, string paramRemetente, string paramNomeExibicao, string paramSenha, string paramDestinatario, string paramNomeDestinatario, string paramAssunto, string paramMensagem, Attachment paramAtach, Attachment paramAtach2, bool RequerAutenticacao, enumTipoEmail paramLocalEmail, Attachment paramAtach3, List<AnexoEmail> lstAnexo)
        //{
        //SmtpClient objEmail;

        //EmailsEnviadosInfo objEmailInfo = new EmailsEnviadosInfo();
        //objEmailInfo.EmailAnexos = false;
        //objEmailInfo.EmailEnviado = false;
        //objEmailInfo.EmailTipo = Convert.ToInt32(paramLocalEmail);

        //if (paramPorta == 587 || paramPorta == 465 || paramPorta == 25)
        //{
        //    objEmail = new SmtpClient(paramSmtp, paramPorta);
        //    objEmail.Port = paramPorta;
        //    if (RequerAutenticacao)
        //        objEmail.EnableSsl = true;
        //    else
        //        objEmail.EnableSsl = false;
        //    objEmail.Timeout = 100000000;
        //    objEmail.UseDefaultCredentials = false;
        //}
        //else
        //{
        //    objEmail = new SmtpClient(paramSmtp, paramPorta);
        //    objEmail.Port = paramPorta;
        //    if (RequerAutenticacao)
        //        objEmail.EnableSsl = true;
        //    else
        //        objEmail.EnableSsl = false;
        //    objEmail.Timeout = 100000000;
        //}

        //MailAddress remetente = new MailAddress(paramRemetente, paramNomeExibicao);

        //MailMessage Mensagem = new MailMessage();
        //String[] Destinatarios = paramDestinatario.Split(',');
        //Mensagem.From = new MailAddress(paramRemetente);
        //for (int i = 0; i < Destinatarios.Length; i++)
        //{
        //    Mensagem.To.Add(Destinatarios[i]);
        //}


        //Mensagem.IsBodyHtml = true;
        //Mensagem.Body = paramMensagem;
        //Mensagem.Subject = paramAssunto;

        //if (paramAtach != null)
        //{
        //    objEmailInfo.EmailAnexos = true;
        //    Mensagem.Attachments.Add(paramAtach);
        //}

        //if (paramAtach2 != null)
        //{
        //    Mensagem.Attachments.Add(paramAtach2);
        //}

        //if (paramAtach3 != null)
        //{
        //    Mensagem.Attachments.Add(paramAtach3);
        //}

        ////string.IsNullOrEmpty(varArquivoPDF) ? null : new System.Net.Mail.Attachment(varArquivoPDF),
        //if (lstAnexo != null)
        //{
        //    foreach (var anexo in lstAnexo)
        //    {
        //        Attachment paramAnexo = new System.Net.Mail.Attachment(anexo.Anexo);
        //        Mensagem.Attachments.Add(paramAnexo);
        //    }
        //}

        //NetworkCredential credenciais = new NetworkCredential(paramRemetente, paramSenha);

        //objEmail.Credentials = credenciais;

        //try
        //{
        //    objEmail.Send(Mensagem);
        //    if (paramAtach != null)
        //    {
        //        paramAtach.Dispose();
        //    }
        //    if (paramAtach2 != null)
        //    {
        //        paramAtach2.Dispose();
        //    }
        //    if (paramAtach3 != null)
        //    {
        //        paramAtach3.Dispose();
        //    }

        //    if (lstAnexo != null)
        //    {
        //        foreach (var anexo in lstAnexo)
        //        {
        //            Attachment paramAnexo = new System.Net.Mail.Attachment(anexo.Anexo);
        //            paramAnexo.Dispose();
        //        }
        //    }

        //    objEmailInfo.EmailOrigem = paramRemetente;
        //    objEmailInfo.EmailDestino = paramDestinatario.Replace(",", ";");
        //    objEmailInfo.EmailNomeDestino = paramNomeDestinatario;
        //    objEmailInfo.EmailEnviado = true;
        //    objEmailInfo.EmailDataEnvio = DateTime.Now;
        //    objEmailInfo.Assunto = paramAssunto;
        //    objEmailInfo.Mensagem = paramMensagem;
        //    _objEmailControl.Inserir(objEmailInfo);
        //}
        //catch (Exception ex)
        //{
        //    objEmailInfo.EmailEnviado = false;
        //    if (paramAtach != null)
        //    {
        //        paramAtach.Dispose();
        //    }
        //    if (paramAtach2 != null)
        //    {
        //        paramAtach2.Dispose();
        //    }
        //    if (paramAtach3 != null)
        //    {
        //        paramAtach3.Dispose();
        //    }
        //    if (lstAnexo != null)
        //    {
        //        foreach (var anexo in lstAnexo)
        //        {
        //            Attachment paramAnexo = new System.Net.Mail.Attachment(anexo.Anexo);
        //            paramAnexo.Dispose();
        //        }
        //    }
        //}

        //return objEmailInfo.EmailEnviado;
        //}

        #region REMOVER ACENTOS

        public static string RemoveAcentos(string palavacomacentos)
        {
            return Encoding.ASCII.GetString(
                Encoding.GetEncoding("Cyrillic").GetBytes(palavacomacentos)
            );
        }

        public static string FormataChaveAcesso(string chave)
        {
            string chaveFormatada = string.Empty;

            if (chave.Length == 44)
            {
                chaveFormatada += chave.Substring(0, 4) + ".";
                chaveFormatada += chave.Substring(4, 4) + ".";
                chaveFormatada += chave.Substring(8, 4) + ".";
                chaveFormatada += chave.Substring(12, 4) + ".";
                chaveFormatada += chave.Substring(16, 4) + ".";
                chaveFormatada += chave.Substring(20, 4) + ".";
                chaveFormatada += chave.Substring(24, 4) + ".";
                chaveFormatada += chave.Substring(28, 4) + ".";
                chaveFormatada += chave.Substring(32, 4) + ".";
                chaveFormatada += chave.Substring(36, 4) + ".";
                chaveFormatada += chave.Substring(40, 4);

            }
            else
            {
                chaveFormatada = chave;
            }

            return chaveFormatada;
        }

        //public static string RemoveAcentos(string str)
        //{
        //    str = Regex.Replace(str, "[áàâãª]", "a");
        //    str = Regex.Replace(str, "[ÁÀÂÃ]", "A");
        //    str = Regex.Replace(str, "[éèê]", "e");
        //    str = Regex.Replace(str, "[ÉÈÊ]", "e");
        //    str = Regex.Replace(str, "[íìî]", "i");
        //    str = Regex.Replace(str, "[ÍÌÎ]", "I");
        //    str = Regex.Replace(str, "[óòôõº]", "o");
        //    str = Regex.Replace(str, "[ÓÒÔÕ]", "O");
        //    str = Regex.Replace(str, "[úùû]", "u");
        //    str = Regex.Replace(str, "[ÚÙÛ]", "U");
        //    str = Regex.Replace(str, "[ç]", "c");
        //    str = Regex.Replace(str, "[Ç]", "C");
        //    str = str.Replace("á", "a");
        //    str = str.Replace("ó", "o");
        //    str = str.Replace("ç", "c");
        //    str = str.Replace("ú", "u");
        //    str = str.Replace("í", "i");
        //    str = str.Replace("ê", "e");
        //    str = str.Replace("é", "e");
        //    str = str.Replace("ã", "a");
        //    str = str.Replace("õ", "o");
        //    str = str.Replace("ô", "o");
        //    str = str.Replace("û", "u");
        //    str = str.Replace("à", "a");
        //    str = str.Replace("ª", "a");
        //    str = str.Replace("°", "o");
        //    str = str.Replace("Ç", "C");
        //    str = str.Replace("&", "E");
        //    str = str.Replace("{", "");
        //    str = str.Replace("}", "");
        //    str = str.Replace("'", "");
        //    str = str.Replace("\"", "");
        //    str = str.Replace("°", "");
        //    str = str.Replace("´", "");
        //    str = str.Replace("`", "");
        //    str = str.Replace("¦", "");
        //    str = str.Replace("|", "");
        //    str = str.TrimEnd();
        //    return str;
        //}

        #endregion

        #region Tira o ponto e a virgula

        public static string TiraPontVirgTracBarra(string Campo)
        {
            string Concatenando = "";
            for (int i = 0; i < Campo.Length; i++)
            {
                string vl = Campo.Substring(i, 1);
                if (vl != "" && vl != "." && vl != "," && vl != "-" && vl != "/" && vl != " " && vl != "(" && vl != ")")
                {
                    Concatenando = Concatenando + vl;
                }
            }
            return Concatenando;
        }

        #endregion

        #region FORMATA O CNPJ

        public static string FormatarCnpj(string cnpj)
        {
            try
            {
                //cnpj = "47.836.838/0009-30";
                string Retorna = "";
                for (int i = 0; i < cnpj.Length; i++)
                {
                    if (cnpj[i] != '.' && cnpj[i] != '/' && cnpj[i] != '-')
                    {
                        Retorna += cnpj[i];
                    }
                }
                return Retorna;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Importar e-mail para tabela nova
        //public static void ImportaEmail(string paramEmail, int paramClienteID)
        //{
        //    ClienteEmailInfo objClientesEmailInfo = new ClienteEmailInfo();
        //    objClientesEmailInfo.ClienteID = paramClienteID;
        //    objClientesEmailInfo.Email = paramEmail;
        //    _objClienteEmailControl.Inserir(objClientesEmailInfo);

        //    _objClienteEmailControl.AtualizarEmailAntigos(paramClienteID);
        //}
        #endregion

        /// <summary>
        /// Função que formata CPF/CNPJ
        /// </summary>
        /// <param name="paramDocumento">Numero do documento</param>
        /// <returns></returns>
        public static string FormataCPFCNPJ(string paramDocumento)
        {
            if (paramDocumento.Length == 11)
            {
                string cpftemp = string.Empty;
                cpftemp = paramDocumento.Substring(0, 3);
                cpftemp += "." + paramDocumento.Substring(3, 3);
                cpftemp += "." + paramDocumento.Substring(6, 3);
                cpftemp += "-" + paramDocumento.Substring(9, 2);

                return cpftemp;
            }
            else if (paramDocumento.Length == 14)
            {
                string cnpjtemp = string.Empty;
                cnpjtemp = paramDocumento.Substring(0, 2);
                cnpjtemp += "." + paramDocumento.Substring(2, 3);
                cnpjtemp += "." + paramDocumento.Substring(5, 3);
                cnpjtemp += "/" + paramDocumento.Substring(8, 4);
                cnpjtemp += "-" + paramDocumento.Substring(12, 2);

                return cnpjtemp;
            }

            return string.Empty;
        }

        /// <summary>
        /// Validações de Códigos de Barra padrão GTIN, 8, 12, 13 e 14
        /// </summary>
        /// <param name="codigoGTIN">Cógigo GTIN 8,12,13,14</param>
        /// <returns>True se válido</returns>
        public static bool ValidaCodigoGTIN(string codigoGTIN)
        {
            if (codigoGTIN != (new Regex("[^0-9]")).Replace(codigoGTIN, string.Empty))
                return false;

            switch (codigoGTIN.Length)
            {
                case 8:
                    codigoGTIN = "000000" + codigoGTIN;
                    break;
                case 12:
                    codigoGTIN = "00" + codigoGTIN;
                    break;
                case 13:
                    codigoGTIN = "0" + codigoGTIN;
                    break;
                case 14:
                    break;
                default:
                    return false;
            }

            //Calculando dígito verificador
            int[] a = new int[13];
            a[0] = int.Parse(codigoGTIN[0].ToString()) * 3;
            a[1] = int.Parse(codigoGTIN[1].ToString());
            a[2] = int.Parse(codigoGTIN[2].ToString()) * 3;
            a[3] = int.Parse(codigoGTIN[3].ToString());
            a[4] = int.Parse(codigoGTIN[4].ToString()) * 3;
            a[5] = int.Parse(codigoGTIN[5].ToString());
            a[6] = int.Parse(codigoGTIN[6].ToString()) * 3;
            a[7] = int.Parse(codigoGTIN[7].ToString());
            a[8] = int.Parse(codigoGTIN[8].ToString()) * 3;
            a[9] = int.Parse(codigoGTIN[9].ToString());
            a[10] = int.Parse(codigoGTIN[10].ToString()) * 3;
            a[11] = int.Parse(codigoGTIN[11].ToString());
            a[12] = int.Parse(codigoGTIN[12].ToString()) * 3;
            int sum = a[0] + a[1] + a[2] + a[3] + a[4] + a[5] + a[6] + a[7] + a[8] + a[9] + a[10] + a[11] + a[12];
            int check = (10 - (sum % 10)) % 10;

            //Checando
            int last = int.Parse(codigoGTIN[13].ToString());
            return check == last;
        }

        public static string CalcularDigitoVerificadorCodigoBarraEAN13(string codigoBarra)
        {
            string texto = codigoBarra;

            //Verifica se o tamanho do texto tem 12 carateres
            if (texto.Length != 12) return string.Empty;

            int[] digitos = new int[12];

            int pos = 0;

            //Percorre todos os caracteres
            foreach (char letra in texto)
            {
                //Verifica se só é digito
                if (!char.IsDigit(letra)) return string.Empty;

                //Popula o array convertendo a letra em digito
                digitos[pos++] = letra - 0x30;
            }

            int soma = 0;
            soma += digitos[0];
            soma += digitos[1] * 3;
            soma += digitos[2];
            soma += digitos[3] * 3;
            soma += digitos[4];
            soma += digitos[5] * 3;
            soma += digitos[6];
            soma += digitos[7] * 3;
            soma += digitos[8];
            soma += digitos[9] * 3;
            soma += digitos[10];
            soma += digitos[11] * 3;

            //Calcula o digito verificador
            int mod = soma % 10;
            int digitoVerificador = mod == 0 ? 0 : 10 - mod;

            return digitoVerificador.ToString();
        }

        public static string RetornaValorNewConfiguracoes(DataTable dtNewConfig, string campo)
        {
            DataRow[] statusConfiguracaoPedidoAposFaturar = dtNewConfig.Select("ConfiguracaoCampo = '" + campo + "'");
            return statusConfiguracaoPedidoAposFaturar[0].ItemArray[1].ToString();
        }

        #endregion

        #region VALOR POR EXTENSO - ESCROTA

        private static string[] strUnidades = { "", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
        private static string[] strDezenas = { "", "dez", "vinte", "trinta", "quarenta", "cinqüenta", "sessenta", "setenta", "oitenta", "noventa" };
        private static string[] strCentenas = { "", "cem", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };
        private static string strErrorString = "Valor fora da faixa";
        private static decimal decMin = 0.01M;
        private static decimal decMax = 999999999999999.99M;
        private static string strMoeda = " real ";
        private static string strMoedas = " reais ";
        private static string strCentesimo = " centavo ";
        private static string strCentesimos = " centavos ";
        private static string ConversaoRecursiva(Int64 intNumero)
        {
            Int64 intResto = 0;
            if ((intNumero >= 1) && (intNumero <= 19))
                return strUnidades[intNumero];
            else if ((intNumero == 20) || (intNumero == 30) || (intNumero == 40) ||
            (intNumero == 50) || (intNumero == 60) || (intNumero == 70) ||
            (intNumero == 80) || (intNumero == 90))
                return strDezenas[Math.DivRem(intNumero, 10, out intResto)] + " ";
            else if ((intNumero >= 21) && (intNumero <= 29) ||
            (intNumero >= 31) && (intNumero <= 39) ||
            (intNumero >= 41) && (intNumero <= 49) ||
            (intNumero >= 51) && (intNumero <= 59) ||
            (intNumero >= 61) && (intNumero <= 69) ||
            (intNumero >= 71) && (intNumero <= 79) ||
            (intNumero >= 81) && (intNumero <= 89) ||
            (intNumero >= 91) && (intNumero <= 99))
                return strDezenas[Math.DivRem(intNumero, 10, out intResto)] + " e " + ConversaoRecursiva(intNumero % 10);
            else if ((intNumero == 100) || (intNumero == 200) || (intNumero == 300) ||
            (intNumero == 400) || (intNumero == 500) || (intNumero == 600) ||
            (intNumero == 700) || (intNumero == 800) || (intNumero == 900))
                return strCentenas[Math.DivRem(intNumero, 100, out intResto)] + " ";
            else if ((intNumero >= 101) && (intNumero <= 199))
                return " cento e " + ConversaoRecursiva(intNumero % 100);
            else if ((intNumero >= 201) && (intNumero <= 299) ||
            (intNumero >= 301) && (intNumero <= 399) ||
            (intNumero >= 401) && (intNumero <= 499) ||
            (intNumero >= 501) && (intNumero <= 599) ||
            (intNumero >= 601) && (intNumero <= 699) ||
            (intNumero >= 701) && (intNumero <= 799) ||
            (intNumero >= 801) && (intNumero <= 899) ||
            (intNumero >= 901) && (intNumero <= 999))
                return strCentenas[Math.DivRem(intNumero, 100, out intResto)] + " e " + ConversaoRecursiva(intNumero % 100);
            else if ((intNumero >= 1000) && (intNumero <= 999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000, out intResto)) + " mil " + ConversaoRecursiva(intNumero % 1000);
            else if ((intNumero >= 1000000) && (intNumero <= 1999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000, out intResto)) + " milhão " + ConversaoRecursiva(intNumero % 1000000);
            else if ((intNumero >= 2000000) && (intNumero <= 999999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000, out intResto)) + " milhões " + ConversaoRecursiva(intNumero % 1000000);
            else if ((intNumero >= 1000000000) && (intNumero <= 1999999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000000, out intResto)) + " bilhão " + ConversaoRecursiva(intNumero % 1000000000);
            else if ((intNumero >= 2000000000) && (intNumero <= 999999999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000000, out intResto)) + " bilhões " + ConversaoRecursiva(intNumero % 1000000000);
            else if ((intNumero >= 1000000000000) && (intNumero <= 1999999999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000000000, out intResto)) + " trilhão " + ConversaoRecursiva(intNumero % 1000000000000);
            else if ((intNumero >= 2000000000000) && (intNumero <= 999999999999999))
                return ConversaoRecursiva(Math.DivRem(intNumero, 1000000000000, out intResto)) + " trilhões " + ConversaoRecursiva(intNumero % 1000000000000);
            else
                return "";
        }
        private static string LimpaEspacos(string strTexto)
        {
            string strRetorno = "";
            bool booUltIs32 = false;
            foreach (char chrChar in strTexto)
            {
                if ((int)chrChar != 32)
                {
                    strRetorno += chrChar;
                    booUltIs32 = false;
                }
                else if (!booUltIs32)
                {
                    strRetorno += chrChar;
                    booUltIs32 = true;
                }
            }
            return strRetorno.Trim();
        }
        public static string NumeroParaExtenso(decimal decNumero)
        {
            if (decNumero < 0)
                decNumero = decNumero * -1;
            string strRetorno = "";
            if ((decNumero >= decMin) && (decNumero <= decMax))
            {
                Int64 intInteiro = Convert.ToInt64(Math.Truncate(decNumero));
                Int64 intCentavos = Convert.ToInt64(Math.Truncate((decNumero - Math.Truncate(decNumero)) * 100));
                strRetorno += ConversaoRecursiva(intInteiro) + (string)(intInteiro <= 1 ? strMoeda : strMoedas);
                if (intCentavos > 0)
                    strRetorno += " e " + ConversaoRecursiva(intCentavos) + (string)(intCentavos == 1 ? strCentesimo : strCentesimos);
            }
            else
                throw new Exception(strErrorString);
            return LimpaEspacos(strRetorno);
        }

        #endregion


        public static string toExtenso(decimal valor)
        {
            if (valor <= 0 | valor >= 1000000000000000)
                return "Valor não suportado pelo sistema.";
            else
            {
                string strValor = valor.ToString("000000000000000.00");
                string valor_por_extenso = string.Empty;

                for (int i = 0; i <= 15; i += 3)
                {
                    valor_por_extenso += escreva_parte(Convert.ToDecimal(strValor.Substring(i, 3)));
                    if (i == 0 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                            valor_por_extenso += " TRILHÃO" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                            valor_por_extenso += " TRILHÕES" + ((Convert.ToDecimal(strValor.Substring(3, 12)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 3 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                            valor_por_extenso += " BILHÃO" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                            valor_por_extenso += " BILHÕES" + ((Convert.ToDecimal(strValor.Substring(6, 9)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 6 & valor_por_extenso != string.Empty)
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valor_por_extenso += " MILHÃO" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valor_por_extenso += " MILHÕES" + ((Convert.ToDecimal(strValor.Substring(9, 6)) > 0) ? " E " : string.Empty);
                    }
                    else if (i == 9 & valor_por_extenso != string.Empty)
                        if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                            valor_por_extenso += " MIL" + ((Convert.ToDecimal(strValor.Substring(12, 3)) > 0) ? " E " : string.Empty);

                    if (i == 12)
                    {
                        if (valor_por_extenso.Length > 8)
                            if (valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "BILHÃO" | valor_por_extenso.Substring(valor_por_extenso.Length - 6, 6) == "MILHÃO")
                                valor_por_extenso += " DE";
                            else
                                if (valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "BILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 7, 7) == "MILHÕES" | valor_por_extenso.Substring(valor_por_extenso.Length - 8, 7) == "TRILHÕES")
                                valor_por_extenso += " DE";
                            else
                                    if (valor_por_extenso.Substring(valor_por_extenso.Length - 8, 8) == "TRILHÕES")
                                valor_por_extenso += " DE";

                        if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                            valor_por_extenso += " REAL";
                        else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                            valor_por_extenso += " REAIS";

                        if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valor_por_extenso != string.Empty)
                            valor_por_extenso += " E ";
                    }

                    if (i == 15)
                        if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                            valor_por_extenso += " CENTAVO";
                        else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                            valor_por_extenso += " CENTAVOS";
                }
                return valor_por_extenso;
            }
        }

        static string escreva_parte(decimal valor)
        {
            if (valor <= 0)
                return string.Empty;
            else
            {
                string montagem = string.Empty;
                if (valor > 0 & valor < 1)
                {
                    valor *= 100;
                }
                string strValor = valor.ToString("000");
                int a = Convert.ToInt32(strValor.Substring(0, 1));
                int b = Convert.ToInt32(strValor.Substring(1, 1));
                int c = Convert.ToInt32(strValor.Substring(2, 1));

                if (a == 1) montagem += (b + c == 0) ? "CEM" : "CENTO";
                else if (a == 2) montagem += "DUZENTOS";
                else if (a == 3) montagem += "TREZENTOS";
                else if (a == 4) montagem += "QUATROCENTOS";
                else if (a == 5) montagem += "QUINHENTOS";
                else if (a == 6) montagem += "SEISCENTOS";
                else if (a == 7) montagem += "SETECENTOS";
                else if (a == 8) montagem += "OITOCENTOS";
                else if (a == 9) montagem += "NOVECENTOS";

                if (b == 1)
                {
                    if (c == 0) montagem += ((a > 0) ? " E " : string.Empty) + "DEZ";
                    else if (c == 1) montagem += ((a > 0) ? " E " : string.Empty) + "ONZE";
                    else if (c == 2) montagem += ((a > 0) ? " E " : string.Empty) + "DOZE";
                    else if (c == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TREZE";
                    else if (c == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUATORZE";
                    else if (c == 5) montagem += ((a > 0) ? " E " : string.Empty) + "QUINZE";
                    else if (c == 6) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSEIS";
                    else if (c == 7) montagem += ((a > 0) ? " E " : string.Empty) + "DEZESSETE";
                    else if (c == 8) montagem += ((a > 0) ? " E " : string.Empty) + "DEZOITO";
                    else if (c == 9) montagem += ((a > 0) ? " E " : string.Empty) + "DEZENOVE";
                }
                else if (b == 2) montagem += ((a > 0) ? " E " : string.Empty) + "VINTE";
                else if (b == 3) montagem += ((a > 0) ? " E " : string.Empty) + "TRINTA";
                else if (b == 4) montagem += ((a > 0) ? " E " : string.Empty) + "QUARENTA";
                else if (b == 5) montagem += ((a > 0) ? " E " : string.Empty) + "CINQUENTA";
                else if (b == 6) montagem += ((a > 0) ? " E " : string.Empty) + "SESSENTA";
                else if (b == 7) montagem += ((a > 0) ? " E " : string.Empty) + "SETENTA";
                else if (b == 8) montagem += ((a > 0) ? " E " : string.Empty) + "OITENTA";
                else if (b == 9) montagem += ((a > 0) ? " E " : string.Empty) + "NOVENTA";

                if (strValor.Substring(1, 1) != "1" & c != 0 & montagem != string.Empty) montagem += " E ";

                if (strValor.Substring(1, 1) != "1")
                    if (c == 1) montagem += "UM";
                    else if (c == 2) montagem += "DOIS";
                    else if (c == 3) montagem += "TRÊS";
                    else if (c == 4) montagem += "QUATRO";
                    else if (c == 5) montagem += "CINCO";
                    else if (c == 6) montagem += "SEIS";
                    else if (c == 7) montagem += "SETE";
                    else if (c == 8) montagem += "OITO";
                    else if (c == 9) montagem += "NOVE";

                return montagem;
            }
        }

        /// <summary>
        /// Validações de Emails
        /// </summary>
        /// <returns>True se válido</returns>
        public static bool ValidarEmail(string email)
        {
            Regex regex = new Regex(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z");

            if (regex.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
