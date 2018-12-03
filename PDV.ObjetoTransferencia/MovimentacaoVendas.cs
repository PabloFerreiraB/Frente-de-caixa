using System;

namespace PDV.ObjetoTransferencia
{
    public class MovimentacaoVendas
    {
        public int MovimentacaoVendasId { get; set; }
        public int ReceitasDespesasId { get; set; }
        public int CaixaId { get; set; }
        public int TransferenciaSaldoClientesId { get; set; }
        public int ReceitasDespesasBaixaId { get; set; }
        public long ClientesId { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string StatusMovimentacao { get; set; }
        public string Observacao { get; set; }
    }
}
