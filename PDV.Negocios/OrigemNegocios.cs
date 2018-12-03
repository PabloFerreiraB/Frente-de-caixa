using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class OrigemNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Origem";

        string sqlDefault = "SELECT OrigemId, (CONVERT(VARCHAR(5), OrigemId) + ' - ' + CONVERT(VARCHAR(1000), Descricao)) AS Descricao FROM Origem ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Origem origem)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(origem));
        }

        public Boolean Alterar(Origem origem)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(origem), PreencheCondicoes(origem));
        }

        public Boolean Excluir(Origem origem)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(origem));
        }

        public DataTable PesquisarPorCodigo(int origemId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE OrigemId = {1}", sqlDefault, origemId));
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY Descricao", sqlDefault, descricao));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Origem origem)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", origem.Descricao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Origem origem)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("OrigemId", origem.OrigemId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
