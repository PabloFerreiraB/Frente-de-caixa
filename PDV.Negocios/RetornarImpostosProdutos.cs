using PDV.ObjetoTransferencia;
using System;
using System.Data;

namespace PDV.Negocios
{
    public class RetornarImpostosProdutos
    {
        public TributacaoFiscal CalcularImpostos(Empresa empresa, int produtoId, decimal totalItem)
        {
            ProdutosNegocios produtosNegocios = new ProdutosNegocios();
            DataTable dtProduto = produtosNegocios.PesquisarPorCodigo(produtoId);

            TributacaoFiscal tributacaoFiscal = new TributacaoFiscal();

            DataTable dtGrupoImposto = new DataTable();
            TributacaoFiscalNegocios tributacaoFiscalNegocios = new TributacaoFiscalNegocios();
            dtGrupoImposto = tributacaoFiscalNegocios.PesquisarPorCodigo(Convert.ToInt32(dtProduto.Rows[0]["TributacaoFiscalId"]));

            #region ICMS

            tributacaoFiscal.Cfop = dtGrupoImposto.Rows[0]["Cfop"].ToString();
            tributacaoFiscal.IcmsOrigem = Convert.ToInt32(dtGrupoImposto.Rows[0]["IcmsOrigem"]);
            tributacaoFiscal.IcmsCst = dtGrupoImposto.Rows[0]["IcmsCst"].ToString();
            tributacaoFiscal.IcmsPercentual = Convert.ToDecimal(dtGrupoImposto.Rows[0]["IcmsPercentual"]);

            tributacaoFiscal.IcmsPercentualBC = tributacaoFiscal.IcmsValor = 0;
            if (tributacaoFiscal.IcmsPercentual > 0)
            {
                tributacaoFiscal.IcmsPercentualBC = totalItem;
                tributacaoFiscal.IcmsValor = tributacaoFiscal.IcmsValor = Convert.ToDecimal(Convert.ToDecimal((tributacaoFiscal.IcmsPercentualBC * tributacaoFiscal.IcmsPercentual) / 100).ToString("N2"));
            }

            #endregion

            #region PIS

            tributacaoFiscal.PisCst = dtGrupoImposto.Rows[0]["PisCst"].ToString();
            tributacaoFiscal.PisPercentual = Convert.ToDecimal(dtGrupoImposto.Rows[0]["PisPercentual"]);
            if (tributacaoFiscal.PisPercentual > 0)
            {
                tributacaoFiscal.PisPercentualBC = totalItem;
                tributacaoFiscal.PisValor = Convert.ToDecimal(Convert.ToDecimal((tributacaoFiscal.PisPercentualBC * tributacaoFiscal.PisPercentual) / 100).ToString("N2"));
            }

            #endregion

            #region COFINS

            tributacaoFiscal.CofinsCst = dtGrupoImposto.Rows[0]["CofinsCst"].ToString();
            tributacaoFiscal.CofinsPercentual = Convert.ToDecimal(dtGrupoImposto.Rows[0]["CofinsPercentual"]);
            if (tributacaoFiscal.CofinsPercentual > 0)
            {
                tributacaoFiscal.CofinsPercentualBC = totalItem;
                tributacaoFiscal.CofinsValor = Convert.ToDecimal(Convert.ToDecimal((tributacaoFiscal.CofinsPercentualBC * tributacaoFiscal.CofinsPercentual) / 100).ToString("N2"));
            }

            #endregion

            if (string.IsNullOrEmpty(tributacaoFiscal.IcmsCst))
            {
                tributacaoFiscal.IcmsOrigem = 0;
                if (empresa.RegimeTributario.Equals(3)) //LUCRO REAL OU LUCRO PRESUMIDO
                    tributacaoFiscal.IcmsCst = "40"; //ISENTO
                else
                    tributacaoFiscal.IcmsCst = "102";
            }

            if (string.IsNullOrEmpty(tributacaoFiscal.PisCst))
            {
                if (tributacaoFiscal.PisValor > 0)
                    tributacaoFiscal.PisCst = "01"; //TRIBUTADO
                else
                    tributacaoFiscal.PisCst = "07"; //ISENTO
            }

            if (string.IsNullOrEmpty(tributacaoFiscal.CofinsCst))
            {
                if (tributacaoFiscal.CofinsValor > 0)
                    tributacaoFiscal.CofinsCst = "01"; //TRIBUTADO
                else
                    tributacaoFiscal.CofinsCst = "07"; //ISENTO
            }

            tributacaoFiscal.IbptAliquotaFederal = tributacaoFiscal.IbptAliquotaEstadual = tributacaoFiscal.IbptAliquotaMunicipal = 0;

            if (!string.IsNullOrEmpty(dtProduto.Rows[0]["Aliq_Federal_Nacional"].ToString()))
            {
                tributacaoFiscal.IbptAliquotaFederal = (totalItem / 100) * Convert.ToDecimal(dtProduto.Rows[0]["Aliq_Federal_Nacional"]);
            }

            if (!string.IsNullOrEmpty(dtProduto.Rows[0]["Aliq_Estadual"].ToString()))
            {
                tributacaoFiscal.IbptAliquotaEstadual = (totalItem / 100) * Convert.ToDecimal(dtProduto.Rows[0]["Aliq_Estadual"]);
            }

            if (!string.IsNullOrEmpty(dtProduto.Rows[0]["Aliq_Municipal"].ToString()))
            {
                tributacaoFiscal.IbptAliquotaMunicipal = (totalItem / 100) * Convert.ToDecimal(dtProduto.Rows[0]["Aliq_Municipal"]);
            }

            return tributacaoFiscal;
        }

    }
}
