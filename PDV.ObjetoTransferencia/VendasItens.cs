using System;

namespace PDV.ObjetoTransferencia
{
    public class VendasItens
    {
        public long VendasItensId { get; set; }
        public long VendasId { get; set; }
        public long ProdutosId { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal { get; set; }
        public string NumeroDocumento { get; set; }
        public string Tipo { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Serie { get; set; }
        public decimal Desconto { get; set; }
        public decimal Lucro { get; set; }
        public decimal PercentualLucro { get; set; }
        public decimal Custo { get; set; }
        public decimal ValorCusto { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueAposMovimentacao { get; set; }
        public decimal PercentualPis { get; set; }
        public decimal BaseCalculoPis { get; set; }
        public decimal ValorPis { get; set; }
        public decimal PercentualCofins { get; set; }
        public decimal BaseCalculoCofins { get; set; }
        public decimal ValorCofins { get; set; }
        public decimal PercentualIcms { get; set; }
        public decimal BaseCalculoIcms { get; set; }
        public decimal ValorIcms { get; set; }
        public decimal ValorIcmsST { get; set; }
        public decimal BaseCalculoIcmsST { get; set; }
        public decimal PercentualIcmsST { get; set; }
        public decimal IvaIcmsST { get; set; }
        public string CstCsosn { get; set; }
        public decimal IbptValorFederal { get; set; }
        public decimal IbptValorEstadual { get; set; }
        public decimal IbptValorMunicipal { get; set; }

        public VendasItens()
        {

        }

        public VendasItens(int vendasId)
        {
            VendasId = vendasId;
        }
    }
}
