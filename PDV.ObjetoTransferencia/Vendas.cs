using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.ObjetoTransferencia
{
    public class Vendas
    {
        public long VendasId { get; set; }
        public int  CaixaId { get; set; }
        public int UsuarioId { get; set; }
        public long ClientesId { get; set; }
        public long ProdutosId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int StatusId { get; set; }
        public int FornecedorId { get; set; }
        public int FuncionarioId { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime DataEmissao { get; set; }
        public DateTime DataVendaFinalizada { get; set; }
        public string Cpf { get; set; }
        public string Cfop { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }
        public decimal Desconto { get; set; }
        public decimal LucroVenda { get; set; }
        public decimal CustoVenda { get; set; }
        public decimal Troco { get; set; }
        public string Tipo { get; set; }
        public string StatusVenda { get; set; }
        public decimal BaseCalculoIcms { get; set; }
        public decimal BaseCalculoIcmsST { get; set; }
        public decimal BaseCalculoPis { get; set; }
        public decimal BaseCalculoCofins { get; set; }
        public decimal ValorIcms { get; set; }
        public decimal ValorIcmsST { get; set; }
        public decimal ValorIpi { get; set; }
        public decimal ValorPis { get; set; }
        public decimal ValorCofins { get; set; }
        public string Serie { get; set; }
        public string Observacao { get; set; }
        public bool CupomFiscal { get; set; }
        public string NumeroCupomFiscal { get; set; }
        public decimal PercentualLucroVenda { get; set; }
        public string DescricaoFormaPagamento { get; set; }
        public decimal SaldoClienteUtilizado { get; set; }

        public string VendaNumeroCFe { get; set; }
        public string VendaChaveAcessoCFe { get; set; }
        public string VendaNumeroSerieSatCFe { get; set; }
        public string VendaNumeroCancelamentoCFe { get; set; }
        public string VendaAssinaturaQRCODECFe { get; set; }
        public string VendaChaveAcessoCancelamentoCFe { get; set; }
        public DateTime VendaDataHoraCancelamentoCFe { get; set; }
        public string VendaQRCODECancelamentoCFe { get; set; }
        public DateTime VendaDataHoraAutorizacao { get; set; }
        public int VendaNFCeNumero { get; set; }
        public int VendaNFCeAmbiente { get; set; }
        public int VendaNFCeSerie { get; set; }
        public string VendaNFCeChaveAcesso { get; set; }
        public string VendaNFCeNumeroRecibo { get; set; }
        public DateTime VendaNFCeDataHoraAutorizacao { get; set; }
        public string VendaNFCeProtocoloAutorizacao { get; set; }
        public DateTime VendaNFCeDataHoraCancelamento { get; set; }
        public string VendaNFCeProtocoloCancelamento { get; set; }
        public string VendaNFCeQrCode { get; set; }
        
        public decimal VendaSpedIcmsBaseCalculo { get; set; }
        public decimal VendaSpedIcmsValor { get; set; }
        public decimal VendaSpedIpiBaseCalculo { get; set; }
        public decimal VendaSpedIpiValor { get; set; }
        public decimal VendaSpedPisBaseCalculo { get; set; }
        public decimal VendaSpedPisValor { get; set; }
        public decimal VendaSpedCofinsBaseCalculo { get; set; }
        public decimal VendaSpedCofinsValor { get; set; }

    }
}
