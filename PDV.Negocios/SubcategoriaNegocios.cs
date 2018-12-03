using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class SubgrupoProdutosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "SubgrupoProdutos";

        string sqlDefault = "SELECT SubgrupoProdutosId, S.Descricao, G.Descricao AS GrupoProdutos, CASE WHEN S.Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo FROM subgrupoProdutos S LEFT JOIN GrupoProdutos G ON G.GrupoProdutosId = S.GrupoProdutosId ";

        #endregion

        #region Métodos Publicos 

        public Boolean Inserir(SubgrupoProdutos subgrupoProdutos)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(subgrupoProdutos));
        }

        public Boolean Alterar(SubgrupoProdutos subgrupoProdutos)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(subgrupoProdutos), PreencheCondicoes(subgrupoProdutos));
        }

        public Boolean Excluir(SubgrupoProdutos subgrupoProdutos)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(subgrupoProdutos));
        }

        public DataTable PesquisarPorCodigo(int usuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE S.GrupoProdutosId = {1}", sqlDefault, usuarioId));
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY Descricao", sqlDefault, nome));
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY S.Descricao", sqlDefault));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(SubgrupoProdutos subgrupoProdutos)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", subgrupoProdutos.Descricao));
            lstParametros.Add(new SqlParametros("Ativo", subgrupoProdutos.Ativo));
            lstParametros.Add(new SqlParametros("GrupoProdutosId ", subgrupoProdutos.GrupoProdutosId));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(SubgrupoProdutos subgrupoProdutos)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("SubgrupoProdutosId", subgrupoProdutos.SubgrupoProdutosId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
