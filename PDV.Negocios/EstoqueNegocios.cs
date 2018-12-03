using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;

namespace PDV.Negocios
{
    public class EstoqueNegocios
    {

        #region Instancias

        Conexao objConexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Estoque";

        string sqlDefault = "SELECT EstoqueId,EstoqueEntradaId,EstoqueSaidaId,ProdutosId,VendasItensId,DataHora,Tipo,Quantidade,Serie,MovimentacaoSerie FROM Estoque ";

        #endregion

        #region Métodos Publicos 

        public Boolean Inserir(Estoque estoque)
        {
            return objConexao.Inserir(nomeTabela, PreencheParametros(estoque));
        }

        public Boolean ExcluirSaidaManual(Estoque estoque)
        {
            return objConexao.Excluir(nomeTabela, PreencheCondicoesSaidaManual(estoque));
        }

        public Boolean ExcluirEntradaManual(Estoque estoque)
        {
            return objConexao.Excluir(nomeTabela, PreencheCondicoesEntradaManual(estoque));
        }

        public decimal PesquisarEstoquePorProduto(int produtosId) //ESTOQUE NAO FISCAL
        {
            try
            {
                decimal estoque = 0; decimal estoqueInicial = 0;

                estoqueInicial = Convert.ToDecimal(objConexao.Pesquisar("SELECT SUM(EstoqueInicial) AS EstoqueInicial FROM Produtos WHERE ProdutosId = " + produtosId).Rows[0][0]);
                estoque = Convert.ToDecimal(objConexao.Pesquisar(" SELECT ISNULL(SUM(Quantidade),0) AS Quantidade FROM Estoque WHERE ProdutosId = " + produtosId).Rows[0][0]);

                return (estoqueInicial + estoque);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public decimal PesquisarEstoqueFiscalPorProduto(int produtosId) //ESTOQUE NAO FISCAL
        {
            try
            {
                decimal estoque = 0; decimal estoqueInicial = 0;

                //EstoqueSerie = 2 representa fiscal
                estoque = Convert.ToDecimal(objConexao.Pesquisar("SELECT ISNULL(SUM(Quantidade),0) AS Quantidade FROM Estoque WHERE Serie = 2 AND ProdutosId = " + produtosId).Rows[0][0]);

                return (estoqueInicial + estoque);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Estoque estoque)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (estoque.EstoqueEntradaId > 0)
                lstParametros.Add(new SqlParametros("EstoqueEntradaId", estoque.EstoqueEntradaId));

            if (estoque.EstoqueSaidaId > 0)
                lstParametros.Add(new SqlParametros("EstoqueSaidaId", estoque.EstoqueSaidaId));

            lstParametros.Add(new SqlParametros("ProdutosId", estoque.ProdutosId));
            lstParametros.Add(new SqlParametros("VendasItensId", estoque.VendasItensId));
            lstParametros.Add(new SqlParametros("DataHora", estoque.DataHora.ToString("yyyy-MM-dd HH:mm:ss")));
            lstParametros.Add(new SqlParametros("Tipo", estoque.Tipo));
            lstParametros.Add(new SqlParametros("Quantidade", estoque.Quantidade));
            lstParametros.Add(new SqlParametros("Serie", estoque.Serie));
            lstParametros.Add(new SqlParametros("MovimentacaoSerie", estoque.MovimentacaoSerie));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosAlterarQuantidadeDevolucao(Estoque estoque)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Quantidade", estoque.Quantidade.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosEstoqueFiscal(Estoque estoque)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Serie", estoque.Serie));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoesSaidaManual(Estoque estoque)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("EstoqueSaidaId", estoque.EstoqueSaidaId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesEntradaManual(Estoque estoque)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("EstoqueEntradaId", estoque.EstoqueEntradaId));

            return lstParametrosCondicionais;
        }


        #endregion

    }
}
