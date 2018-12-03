using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class VendasItensNegocios
    {

        #region Instancias

        Conexao objConexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "VendasItens";

        string sqlDefault = "SELECT VI.VendasItensId,VI.VendasId,VI.ProdutosId,P.Descricao AS Produto,P.CodigoBarras,VI.Quantidade,VI.ValorUnitario,VI.ValorTotal,VI.NumeroDocumento,VI.Tipo,VI.DataVencimento,VI.Serie,VI.Desconto,VI.Lucro,VI.PercentualLucro,VI.Custo,VI.ValorCusto,VI.EstoqueAtual,VI.EstoqueAposMovimentacao,VI.PercentualPis,VI.BaseCalculoPis,VI.ValorPis,VI.PercentualCofins,VI.BaseCalculoCofins,VI.ValorCofins,VI.PercentualIcms,VI.BaseCalculoIcms,VI.ValorIcms,VI.CstCsosn,NR.Codigo,NR.Descricao AS NaturezaReceita,P.UnidadeMedidaId,UM.Descricao AS UnidadeMedida,E.EstoqueId,ISNULL(VI.ValorIcmsST,0) AS ItemValorIcmsST,ISNULL(VI.BaseCalculoIcmsST,0) AS ItemBaseCalculoIcmsST,ISNULL(VI.PercentualIcmsST,0) AS ItemPercentualIcmsST,ISNULL(VI.IvaIcmsST,0) AS ItemIvaIcmsST,ISNULL(VI.IbptValorFederal,0) AS ItemIbptValorFederal,ISNULL(VI.IbptValorEstadual,0) AS ItemIbptValorEstadual,ISNULL(VI.IbptValorMunicipal,0) AS ItemIbptValorMunicipal FROM VendasItens VI LEFT JOIN Produtos P ON VI.ProdutosId =P.ProdutosId LEFT JOIN NaturezaReceita NR ON P.NaturezaReceitaId =NR.NaturezaReceitaId LEFT JOIN UnidadeMedida UM ON P.UnidadeMedidaId =UM.UnidadeMedidaId LEFT JOIN Estoque E ON E.VendasItensId =VI.VendasItensId ";

        //string sqlDefaultRelatorioProdutosVendidosComprados = "SELECT  cv.ComVNrDo,ComVDtEm,ProdDesc,ItenQtde,ItenPrUn,ItenPrTo,ItenSerie,ISNULL(ItenDescPerc, 0) as ItenDescPerc,ItenDescValo,ItenLucr,ItenCust,ItenPercLucr,c.Cli_Nome, ISNULL(CVI.ItemValorIcmsST,0) AS ItemValorIcmsST, ISNULL(CVI.ItemBaseCalculoIcmsST,0) AS ItemBaseCalculoIcmsST, ISNULL(CVI.ItemPercentualIcmsST,0) AS ItemPercentualIcmsST, ISNULL(CVI.ItemIvaIcmsST,0) AS ItemIvaIcmsST, COR.CorDescricao FROM CompraVendaItens cvi JOIN CompraVenda cv on cv.ComVCodi = cvi.ComVCodi LEFT JOIN Produtos p on p.ProdCodi = cvi.ProdCodi left outer join Clientes c on cv.Cli_Codi = c.Cli_Codi LEFT JOIN Cores COR ON COR.CorId = cvi.CorId  ";  //GERAL

        #endregion

        #region Métodos Publicos  

        public Boolean Inserir(VendasItens vendasItens)
        {
            return objConexao.Inserir(nomeTabela, PreencheParametros(vendasItens));
        }

        public Boolean Alterar(VendasItens vendasItens)
        {
            return objConexao.Atualizar(nomeTabela, PreencheParametros(vendasItens), PreencheCondicoes(vendasItens));
        }

        public Boolean Excluir(VendasItens vendasItens)
        {
            return objConexao.Excluir(nomeTabela, PreencheCondicoes(vendasItens));
        }

        public Boolean ExcluirItensCompraVenda(VendasItens objItensProdutosInfo)
        {
            return objConexao.Excluir(nomeTabela, PreencheCondicoesCompraVenda(objItensProdutosInfo));
        }

        public DataTable PesquisarPorCodigo(int vendasItens)
        {
            return objConexao.Pesquisar(string.Format("{0} WHERE VendasItens = {1}", sqlDefault, vendasItens));
        }

        public decimal PesquisarPrecoItemUltimaCompra(int clientesId, int produtosId)
        {
            DataTable dtPrecoItem = objConexao.Pesquisar(string.Format("SELECT TOP 1 ISNULL(VI.ValorUnitario,0) FROM Vendas V LEFT JOIN VendasItens VI ON VI.VendasId =V.VendasId WHERE V.ClientesId = {0} AND V.ProdutosId = {1} ORDER BY V.DataEmissao DESC ", clientesId, produtosId));

            return dtPrecoItem.Rows.Count > 0 ? Convert.ToDecimal(dtPrecoItem.Rows[0][0]) : 0;
        }

        
        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(VendasItens vendasItens)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("VendasId", vendasItens.VendasId));
            lstParametros.Add(new SqlParametros("ProdutosId", vendasItens.ProdutosId));
            lstParametros.Add(new SqlParametros("Quantidade", vendasItens.Quantidade.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorUnitario", vendasItens.ValorUnitario.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorTotal", vendasItens.ValorTotal.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("NumeroDocumento", vendasItens.NumeroDocumento));
            lstParametros.Add(new SqlParametros("Tipo", vendasItens.Tipo));
            if (!vendasItens.DataVencimento.ToString().Contains("01/01/0001") && !vendasItens.DataVencimento.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataVencimento", vendasItens.DataVencimento.ToString("yyyy-MM-dd")));
            lstParametros.Add(new SqlParametros("Serie", vendasItens.Serie));
            lstParametros.Add(new SqlParametros("Desconto", vendasItens.Desconto.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Lucro", vendasItens.Lucro.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("PercentualLucro", vendasItens.PercentualLucro.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Custo", vendasItens.Custo.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorCusto", vendasItens.ValorCusto.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("EstoqueAtual", vendasItens.EstoqueAtual));
            lstParametros.Add(new SqlParametros("EstoqueAposMovimentacao", vendasItens.EstoqueAposMovimentacao));

            lstParametros.Add(new SqlParametros("PercentualPis", vendasItens.PercentualPis.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoPis", vendasItens.BaseCalculoPis.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorPis", vendasItens.ValorPis.ToString().Replace(",", ".")));

            lstParametros.Add(new SqlParametros("PercentualCofins", vendasItens.PercentualCofins.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoCofins", vendasItens.BaseCalculoCofins.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorCofins", vendasItens.ValorCofins.ToString().Replace(",", ".")));

            lstParametros.Add(new SqlParametros("PercentualIcms", vendasItens.PercentualIcms.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoIcms", vendasItens.BaseCalculoIcms.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorIcms", vendasItens.ValorIcms.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("PercentualIcmsST", vendasItens.PercentualIcmsST.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoIcmsST", vendasItens.BaseCalculoIcmsST.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorIcmsST", vendasItens.ValorIcmsST.ToString().Replace(",", ".")));

            lstParametros.Add(new SqlParametros("IvaIcmsST", vendasItens.IvaIcmsST.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CstCsosn", vendasItens.CstCsosn.ToString()));

            lstParametros.Add(new SqlParametros("IbptValorFederal", vendasItens.IbptValorFederal.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IbptValorEstadual", vendasItens.IbptValorEstadual.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IbptValorMunicipal", vendasItens.IbptValorMunicipal.ToString().Replace(",", ".")));


            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(VendasItens vendasItens)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("VendasItensId", vendasItens.VendasItensId));

            return lstParametrosCondicionais;
        }


        private List<SqlParametros> PreencheCondicoesCompraVenda(VendasItens objItensProdutosInfo)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("VendasId", objItensProdutosInfo.VendasId));

            return lstParametrosCondicionais;
        }

        #endregion
    }
}
