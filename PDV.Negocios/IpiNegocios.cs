using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class IpiNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Ipi";

        string sqlDefault = "SELECT IpiId,(IpiCst + ' - ' + Descricao) AS Descricao ,Tipo FROM Ipi ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Ipi ipi)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(ipi));
        }

        public Boolean Alterar(Ipi ipi)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(ipi), PreencheCondicoes(ipi));
        }

        public Boolean Excluir(Ipi ipi)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(ipi));
        }

        public DataTable PesquisarPorCodigo(int ipiId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE IpiId = {1}", sqlDefault, ipiId));
        }

        public DataTable PesquisarPorNome(string ipiCst)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE IpiCst LIKE '%{1}%' ORDER BY IpiCst", sqlDefault, ipiCst));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public DataTable PesquisarCst(int tipo)
        {
            if (tipo >= 0)
            {
                sqlDefault += ValidarString(sqlDefault) + string.Format("Tipo = '{0}' ", tipo);
            }

            return conexao.Pesquisar(string.Format("{0}", sqlDefault));
        }

        public DataTable PesquisarIpi(int tipo)
        {
            string sqlComando = "SELECT IpiCst, (IpiCst + ' - ' + CONVERT(VARCHAR(1000),Descricao))  AS Descricao, Tipo FROM Ipi";

            return conexao.Pesquisar(string.Format("{0} WHERE Tipo = {1}", sqlComando, tipo));

        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Ipi ipi)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("IpiCst", ipi.IpiCst));
            lstParametros.Add(new SqlParametros("Tipo", ipi.Tipo));
            lstParametros.Add(new SqlParametros("Descricao", ipi.Descricao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Ipi ipi)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("IpiId", ipi.IpiId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
