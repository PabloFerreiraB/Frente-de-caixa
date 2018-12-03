using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PDV.AcessoBancoDados
{
    public class Conexao
    {
        public SqlConnection conn;
        protected SqlCommand cmdgeral;

        public Conexao()
        {
            ConfiguracaoXML objReadXml = new ConfiguracaoXML();
            objReadXml.LerConfiguracaoBanco();
            string strConn = string.Format("Server={0};Database={1};user={2};password={3};", objReadXml.Servidor, objReadXml.BancoDados, objReadXml.Usuario, objReadXml.Senha);
            conn = new SqlConnection(strConn);

            cmdgeral = new SqlCommand();
            cmdgeral.Connection = conn;
        }



        #region METODOS

        /// <summary>
        /// Método responsável por realizar instruções de Insert,Delete e Update.
        /// </summary>
        /// <param name="sql">Instrução sql a ser executada</param>
        /// <returns>True/False</returns>
        public bool Executar(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);

            try
            {
                //Operacao no servidor principal
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

        /// <summary>
        /// Método que realiza pesquisas na base de dados
        /// </summary>
        /// <param name="sqlquery">Comando SQL a ser executado</param>
        /// <returns>DataTable com resultados encontrados</returns>
        public DataTable Pesquisar(string sqlquery)
        {
            SqlCommand cmd = new SqlCommand(sqlquery, conn);
            cmd.CommandTimeout = int.MaxValue;
            DataTable dtResultado = new DataTable();

            try
            {
                conn.Open();
                dtResultado.Load(cmd.ExecuteReader());

                return dtResultado;
            }

            catch (SqlException ex)
            {
                throw new Exception(string.Format("Erro ao executar a instrução SQL: {0}", ex.Message), ex);
            }
            finally
            {
                conn.Close();
            }
        }

        /// <summary>
        /// Método responsável por inserir registros na base de dados
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

                try
                {
                    _valores += string.Format("'{0}',", parametro.Valor.ToString().Replace("'", "''"));
                }
                catch (Exception)
                { _valores += string.Format("'{0}',", parametro.Valor); }
            }

            _campos = _campos.Substring(0, _campos.Length - 1);
            _valores = _valores.Substring(0, _valores.Length - 1);

            string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2});", tabela, _campos, _valores);

            return Executar(sql);
        }

        /// <summary>
        /// Método responsavel por atualizar um ou mais registo da base de dados
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
                try
                {
                    campos += string.Format("{0}='{1}',", parametro.Campo, parametro.Valor.ToString().Replace("'", "''"));
                }
                catch (Exception)
                { campos += string.Format("{0}='{1}',", parametro.Campo, parametro.Valor); }
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
        /// Método responsável por apagar um registro no banco
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
        /// Método responsável por retornar o último número gerado por auto incremento
        /// </summary>
        /// <returns>Último ID</returns>
        public int RetornarUltimoId(string tabela, string campo)
        {
            string sql = string.Format("SELECT MAX({0}) FROM {1};", campo, tabela);
            return Convert.ToInt32(Pesquisar(sql).Rows[0][0]);
        }

        /// <summary>
        /// Método responsável por retornar valores das configurações setadas do sistema
        /// </summary>
        /// <param name="dtConfiguracoes"></param>
        /// <param name="campo"></param>
        /// <returns></returns>
        public static string RetornaConfiguracoes(DataTable dtConfiguracoes, string campo)
        {
            DataRow[] ValorCampo = dtConfiguracoes.Select("Campo = '" + campo + "'");
            return ValorCampo[0].ItemArray[1].ToString();
        }

        #endregion

    }
}
