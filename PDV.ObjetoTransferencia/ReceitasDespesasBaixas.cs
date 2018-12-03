using System;

namespace PDV.ObjetoTransferencia
{
    public class ReceitasDespesasBaixas
    {
        public int ReceitasDespesasBaixasId { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioCancelamentoId { get; set; }
        public int ReceitasDespesasId { get; set; }
        public DateTime DataHora { get; set; }
        public int MultaPercentualValor { get; set; } //0-PERCENTUAL   1-VALOR
        public decimal Multa { get; set; }
        public int DescontoPercentualValor { get; set; } //0-PERCENTUAL   1-VALOR
        public decimal Desconto { get; set; }
        public int JurosPercentualValor { get; set; } //0-PERCENTUAL   1-VALOR
        public decimal Juros { get; set; }
        public DateTime DataCancelamento { get; set; }
        public int DiasAtraso { get; set; }
        public decimal Valor { get; set; }
    }
}
