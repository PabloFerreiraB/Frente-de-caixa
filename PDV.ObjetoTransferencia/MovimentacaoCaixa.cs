using System;

namespace PDV.ObjetoTransferencia
{
    public class MovimentacaoCaixa
    {
        public int MovimentacaoCaixaId { get; set; }
        public int CaixaId { get; set; }
        public int ReceitasDespesasId { get; set; }
        public int ReceitasDespesasBaixasId { get; set; }
        public DateTime DataHora { get; set; }
        public decimal Valor { get; set; }
        public string Tipo { get; set; }
        public string StatusMovimentacao { get; set; }
        public string Observacao { get; set; }
    }
}
