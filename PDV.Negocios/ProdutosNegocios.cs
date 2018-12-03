using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class ProdutosNegocios
    {

        #region Instancias

        Conexao conexao = new Conexao();

        #endregion 

        #region Variáveis Default 
         
        string nomeTabela = "Produtos";

        string sqlDefault = "SELECT P.ProdutosId,P.CodigoBarras,P.Descricao,P.TabelaIBPTId,TI.NCM,CASE WHEN P.Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo,P.UnidadeMedidaId,U.Descricao AS UnidadeMedida,P.grupoProdutosId,P.SubgrupoProdutosId,P.TributacaoFiscalId,T.Descricao AS DescricaoTributacaoFiscal,G.Descricao AS GrupoProdutos,P.FornecedorId,F.Nome AS Fornecedor,P.ValorCompra,P.ValorVenda,P.ValorUnitario,P.EstoqueInicial,CASE WHEN P.EstoqueAtual =0 THEN P.EstoqueInicial ELSE P.EstoqueAtual END EstoqueAtual,P.EstoqueMinimo,P.EstoqueMaximo,P.Observacao,P.DataCadastro,P.UltimaCompra,ISNULL((SELECT TOP 1 Aliq_Federal_Nacional FROM TabelaIBPT I WHERE P.TabelaIBPTId =I.TabelaIBPTId),0) AS Aliq_Federal_Nacional, ISNULL((SELECT TOP 1 Aliq_Estadual FROM TabelaIBPT I WHERE P.TabelaIBPTId = I.TabelaIBPTId),0) AS Aliq_Estadual, ISNULL((SELECT TOP 1 Aliq_Municipal FROM TabelaIBPT I WHERE P.TabelaIBPTId = I.TabelaIBPTId),0) AS Aliq_Municipal FROM Produtos P LEFT JOIN UnidadeMedida U ON U.UnidadeMedidaId =P.UnidadeMedidaId LEFT JOIN GrupoProdutos G ON G.GrupoProdutosId =P.grupoProdutosId LEFT JOIN Fornecedor F ON F.FornecedorId =P.FornecedorId LEFT JOIN TributacaoFiscal T ON T.TributacaoFiscalId =P.TributacaoFiscalId LEFT JOIN TabelaIBPT TI ON TI.TabelaIBPTId =P.TabelaIBPTId ";

        string sqlListaProdutos = "SELECT ProdutosId,CodigoBarras,Descricao,ValorUnitario,CASE WHEN EstoqueAtual= 0 THEN EstoqueInicial ELSE EstoqueAtual END EstoqueAtual,Observacao FROM Produtos WHERE Ativo= 1 ORDER BY ProdutosId ";

        #endregion

        #region Métodos publicos 

        public Boolean Inserir(Produtos produtos)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(produtos));
        }

        public Boolean Alterar(Produtos produtos)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(produtos), PreencheCondicoes(produtos));
        }

        public Boolean Excluir(Produtos produtos)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(produtos));
        }

        public string GerarCodigoBarras()
        {
            DataTable dtResult = new DataTable();
            dtResult = conexao.Pesquisar("SELECT TOP 1 ISNULL(ProdutosId,0) FROM PRODUTOS ORDER BY ProdutosId DESC");

            return dtResult.Rows.Count > 0 ? (Convert.ToInt32(dtResult.Rows[0][0]) + 1).ToString().PadLeft(10, '0') : "0000000001";
        }

        public DataTable PesquisarPorCodigo(int produtosId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE P.ProdutosId = {1} ORDER BY P.ProdutosId ", sqlDefault, produtosId));
        }

        public int RetornarUltimoId()
        {
            return Convert.ToInt32(conexao.Pesquisar("SELECT MAX(ProdutosId) FROM Produtos").Rows[0][0]);
        }

        public DataTable PesquisarPorCodigoOuCodigoBarras(string filtro)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE (P.ProdutosId LIKE '{1}') OR (P.CodigoBarras LIKE '{1}') ORDER BY P.ProdutosId ", sqlDefault, filtro));
        }

        public bool PesquisarProdutoExistePelaDescricao(string descricao, int produtoId)
        {
            DataTable dtProduto = conexao.Pesquisar(string.Format("{0} WHERE P.Descricao = '{1}' AND P.ProdutosId <> {2}", sqlDefault, descricao, produtoId));

            if (dtProduto.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0}", sqlDefault));
        }

        public DataTable CarregarListaProdutosGrid()
        {
            return conexao.Pesquisar(string.Format("{0}", sqlListaProdutos));
        }

        public void ReporEstoque(int estoqueAtual, int produtosId)
        {
            conexao.Pesquisar(string.Format("UPDATE Produtos SET EstoqueAtual = {0} WHERE ProdutosId = {1}", estoqueAtual, produtosId));
        }

        public Produtos VerificaSeJaTemCodigoBarrasInformado(string codigoBarras)
        {
            string sqlComando = string.Format(@"SELECT ProdutosId, Descricao FROM Produtos WHERE CodigoBarras = '{0}'", codigoBarras);

            DataTable dtProduto = conexao.Pesquisar(sqlComando);
            if (dtProduto.Rows.Count > 0)
            {
                Produtos produtos = new Produtos()
                {
                    ProdutosId = Convert.ToInt32(dtProduto.Rows[0]["ProdutosId"].ToString()),
                    Descricao = dtProduto.Rows[0]["Descricao"].ToString()
                };

                return produtos;
            }

            return new Produtos();
        }


        #region VERIFICA O ESTOQUE FISCAL E NÃO FISCAL

        public int VerificaEstoque(int produtosId) //ESTOQUE NAO FISCAL
        {
            int QtdeEstoque = 0;
            try
            {
                DataTable dtaEstoque = new DataTable();
                dtaEstoque = conexao.Pesquisar(string.Format("{0} WHERE P.ProdutosId = {1} ORDER BY P.Descricao ", sqlDefault, produtosId));

                return (Convert.ToInt32(dtaEstoque.Rows[0]["P.EstoqueAtual"].ToString()));
            }
            catch (Exception)
            {
                return QtdeEstoque;
            }
        }

        public int VerificaEstoqueFiscal(int produtosId) //ESTOQUE FISCAL
        {
            int QtdeEstoque = 0;
            try
            {
                DataTable dtaEstoque = new DataTable();
                dtaEstoque = conexao.Pesquisar(string.Format("{0} WHERE P.ProdutosId={1} ORDER BY P.Descricao ", sqlDefault, produtosId));

                return (Convert.ToInt32(dtaEstoque.Rows[0]["P.EstoqueAtual"].ToString()));
            }
            catch (Exception)
            {
                return QtdeEstoque;
            }
        }

        #endregion


        #endregion

        #region Métodos privados

        private List<SqlParametros> PreencheParametros(Produtos produtos)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", produtos.Descricao.ToString().Replace("'", "")));
            if (produtos.TabelaIBPTId > 0)
                lstParametros.Add(new SqlParametros("TabelaIBPTId", produtos.TabelaIBPTId));
            lstParametros.Add(new SqlParametros("CodigoBarras", produtos.CodigoBarras));
            lstParametros.Add(new SqlParametros("Ativo", produtos.Ativo));
            lstParametros.Add(new SqlParametros("UnidadeMedidaId", produtos.UnidadeMedidaId));
            lstParametros.Add(new SqlParametros("GrupoProdutosId", produtos.GrupoProdutosId));
            lstParametros.Add(new SqlParametros("SubgrupoProdutosId", produtos.SubgrupoProdutosId));
            if (produtos.TributacaoFiscalId > 0)
                lstParametros.Add(new SqlParametros("TributacaoFiscalId", produtos.TributacaoFiscalId));
            if (produtos.FornecedorId > 0)
                lstParametros.Add(new SqlParametros("FornecedorId", produtos.FornecedorId));
            lstParametros.Add(new SqlParametros("ValorCompra", produtos.ValorCompra.ToString().Replace(',', '.')));
            lstParametros.Add(new SqlParametros("ValorVenda", produtos.ValorVenda.ToString().Replace(',', '.')));
            lstParametros.Add(new SqlParametros("ValorUnitario", produtos.ValorUnitario.ToString().Replace(',', '.')));
            lstParametros.Add(new SqlParametros("EstoqueInicial", produtos.EstoqueInicial));
            lstParametros.Add(new SqlParametros("EstoqueMinimo", produtos.EstoqueMinimo));
            lstParametros.Add(new SqlParametros("EstoqueMaximo", produtos.EstoqueMaximo));
            lstParametros.Add(new SqlParametros("EstoqueAtual", produtos.EstoqueAtual));
            lstParametros.Add(new SqlParametros("Observacao", produtos.Observacao.ToString().Replace(',', '.')));
            lstParametros.Add(new SqlParametros("DataCadastro", produtos.DataCadastro.ToString("yyyy-MM-dd HH:mm")));
            lstParametros.Add(new SqlParametros("UltimaCompra", produtos.UltimaCompra.ToString("yyyy-MM-dd HH:mm")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Produtos produtos)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ProdutosId", produtos.ProdutosId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
