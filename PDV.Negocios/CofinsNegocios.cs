using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class CofinsNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Cofins";

        string sqlDefault = "SELECT CofinsId, CofinsCst, Descricao, Tipo FROM Cofins ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Cofins cofins)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(cofins));
        }

        public Boolean Alterar(Cofins cofins)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(cofins), PreencheCondicoes(cofins));
        }

        public Boolean Excluir(Cofins cofins)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(cofins));
        }

        public DataTable PesquisarCofinsDataSource(int tipo)
        {
            string sqlComand = "SELECT CofinsCst, (CofinsCst +' - '+ CONVERT (VARCHAR (1000),Descricao)) AS Descricao, Tipo FROM Cofins ";

            return conexao.Pesquisar(string.Format("{0} WHERE Tipo = {1}", sqlComand, tipo));
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY Descricao", sqlDefault, descricao));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Cofins cofins)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("CofinsCst", cofins.CofinsCst));
            lstParametros.Add(new SqlParametros("Descricao", cofins.Descricao));
            lstParametros.Add(new SqlParametros("Tipo", cofins.Tipo));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Cofins cofins)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("CofinsId", cofins.CofinsId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
