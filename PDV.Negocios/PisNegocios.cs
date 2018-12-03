using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class PisNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Pis";

        string sqlDefault = "SELECT PisId, PisCst, Descricao, Tipo FROM Pis ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Pis pis)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(pis));
        }

        public Boolean Alterar(Pis pis)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(pis), PreencheCondicoes(pis));
        }

        public Boolean Excluir(Pis pis)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(pis));
        }

        public DataTable PesquisarPisDataSource(int tipo)
        {
            string sqlComand = "SELECT PisCst,(PisCst +' - '+ CONVERT (VARCHAR (1000),Descricao)) AS Descricao, Tipo FROM Pis ";

            return conexao.Pesquisar(string.Format("{0} WHERE Tipo = {1}", sqlComand, tipo));
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY Descricao", sqlDefault, descricao));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Pis pis)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("PisCst", pis.PisCst));
            lstParametros.Add(new SqlParametros("Descricao", pis.Descricao));
            lstParametros.Add(new SqlParametros("Tipo", pis.Tipo));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Pis pis)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("PisId", pis.PisId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
