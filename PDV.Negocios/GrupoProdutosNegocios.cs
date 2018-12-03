using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class GrupoProdutosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion
         
        #region Variáveis Default

        string nomeTabela = "GrupoProdutos";

        string sqlDefault = "SELECT GrupoProdutosId, Descricao, CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo FROM GrupoProdutos ";

        #endregion

        #region Métodos Publicos 

        public Boolean Inserir(GrupoProdutos grupoProdutos)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(grupoProdutos));
        }

        public Boolean Alterar(GrupoProdutos grupoProdutos)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(grupoProdutos), PreencheCondicoes(grupoProdutos));
        }

        public Boolean Excluir(GrupoProdutos grupoProdutos)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(grupoProdutos));
        }

        public DataTable PesquisarPorCodigo(int usuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE GrupoProdutosId = {1}", sqlDefault, usuarioId));
        }

        public DataTable PesquisarPorNome(string nome) 
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY Descricao", sqlDefault, nome));
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY GrupoProdutosId", sqlDefault));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(GrupoProdutos grupoProdutos)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", grupoProdutos.Descricao));
            lstParametros.Add(new SqlParametros("Ativo", grupoProdutos.Ativo));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(GrupoProdutos grupoProdutos)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("GrupoProdutosId", grupoProdutos.GrupoProdutosId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
