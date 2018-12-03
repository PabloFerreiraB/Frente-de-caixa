using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class CaixaNegocios
    {

        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Caixa";

        string sqlDefault = "SELECT CaixaId, UsuarioId, Abertura, Fechamento, Valor FROM Caixa";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Caixa caixa)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(caixa));
        }

        public Boolean Alterar(Caixa caixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(caixa), PreencheCondicoes(caixa));
        }

        public Boolean AlterarFechamento(Caixa caixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosFechamento(caixa), PreencheCondicoes(caixa));
        }

        public Boolean AlterarValorAbertura(Caixa caixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosValor(caixa), PreencheCondicoes(caixa));
        }

        public Boolean AlterarSaldo(Caixa caixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosAlterarSaldo(caixa), PreencheCondicoes(caixa));
        }

        public Boolean Excluir(Caixa caixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(caixa));
        }

        public DataTable PesquisarPorCodigo(int caixaId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE CaixaId = {1}", sqlDefault, caixaId));
        }

        public DataTable PesquisarPorNome(string paramNome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Abertura LIKE '%{1}%' ORDER BY Abertura", sqlDefault, paramNome));
        }

        public int VerificarSeCaixaEstaAberto()
        {
            return Convert.ToInt32(conexao.Pesquisar("SELECT ISNULL(Max(CaixaId),0) AS CaixaId FROM Caixa WHERE Fechamento IS NULL").Rows[0][0]);
        }

        public decimal PesquisarValorDeAberturaCaixa(int caixaId)
        {
            return Convert.ToDecimal(conexao.Pesquisar("SELECT Valor FROM Caixa WHERE Fechamento IS NULL AND CaixaId = " + caixaId).Rows[0][0]);
        }

        public int VerificarUsuarioAbriuCaixa(int caixaId)
        {
            return Convert.ToInt32(conexao.Pesquisar("SELECT UsuarioId FROM Caixa WHERE Fechamento IS NULL AND CaixaId = " + caixaId).Rows[0][0]);
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        /// <summary>
        /// Consultar abertura por Turnos
        /// </summary>
        /// <param name="dataInicial"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        public DataTable PesquisarAberturas(DateTime? dataInicial, DateTime? dataFinal)
        {
            string strCmd = sqlDefault;

            if (dataInicial != null && dataFinal != null)
            {
                strCmd += ValidarString(strCmd) + string.Format("Abertura BETWEEN '{0}' and '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));
            }

            return conexao.Pesquisar(string.Format("{0} ORDER BY Abertura DESC", strCmd));
        }

        public Caixa PesquisarSaldoCaixa(int caixaId)
        {
            DataTable dtCaixa = new DataTable();
            dtCaixa = conexao.Pesquisar(string.Format("{0} WHERE CaixaId = {1} ", sqlDefault.Replace("#TROCA#", "WHERE"), caixaId));

            if (dtCaixa.Rows.Count > 0 && dtCaixa != null)
            {
                Caixa caixa = new Caixa();

                caixa.CaixaId = Convert.ToInt32(dtCaixa.Rows[0]["CaixaId"].ToString());
                caixa.UsuarioId = Convert.ToInt32(dtCaixa.Rows[0]["UsuarioId"]);
                caixa.Abertura = Convert.ToDateTime(dtCaixa.Rows[0]["Abertura"].ToString());
                caixa.Fechamento = Convert.ToDateTime(dtCaixa.Rows[0]["Fechamento "].ToString());
                caixa.Valor = Convert.ToDecimal(dtCaixa.Rows[0]["Valor"].ToString().Replace(".", "").Replace(",", "."));

                return caixa;
            }
            else
                return null;
        }


        #endregion 

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Caixa caixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Abertura", caixa.Abertura.ToString("yyyy-MM-dd HH:mm:ss")));
            if (caixa.UsuarioId > 0)
                lstParametros.Add(new SqlParametros("UsuarioId", caixa.UsuarioId));
            lstParametros.Add(new SqlParametros("Valor", caixa.Valor.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosFechamento(Caixa caixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Fechamento", caixa.Fechamento.ToString("yyyy-MM-dd HH:mm:ss")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosValor(Caixa caixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Valor", caixa.Valor.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosAlterarSaldo(Caixa caixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();
            lstParametros.Add(new SqlParametros("Valor", caixa.Valor.ToString().Replace(".", "").Replace(",", ".")));
            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Caixa caixa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("CaixaId", caixa.CaixaId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
