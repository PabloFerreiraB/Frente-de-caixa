using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class IcmsNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Icms";
         
        string sqlDefault = "SELECT IcmsCst,(IcmsCst+' - '+CONVERT (VARCHAR (1000),Descricao)) AS Descricao,Tipo FROM Icms ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Icms icms)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(icms));
        }

        public Boolean Alterar(Icms icms)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(icms), PreencheCondicoes(icms));
        }

        public Boolean Excluir(Icms icms)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(icms));
        }

        public DataTable PesquisarPorCodigo(int icmsCst)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE IcmsCst = {1}", sqlDefault, icmsCst));
        }

        public DataTable PesquisarPorNome(string icmsCst)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE IcmsCst LIKE '%{1}%' ORDER BY IcmsCst", sqlDefault, icmsCst));
        }

        public DataTable PesquisarCst(string icmsCst)
        {
            string sqlComando = "SELECT IcmsId, IcmsCst, Descricao, Tipo FROM Icms";

            return conexao.Pesquisar(string.Format("{0} WHERE IcmsCst LIKE '%{1}%' ORDER BY IcmsCst", sqlComando, icmsCst));
        }

        public DataTable PesquisarPorTipo(int tipo)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Tipo = {1}", sqlDefault, tipo));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Icms icms)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("IcmsCst", icms.IcmsCst));
            lstParametros.Add(new SqlParametros("Descricao", icms.Descricao));
            lstParametros.Add(new SqlParametros("Tipo", icms.Tipo));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Icms icms)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("IcmsId", icms.IcmsId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
