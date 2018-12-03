namespace PDV.ObjetoTransferencia
{
    public class FormaPagamentoPrazos
    {
        public int FormaPagamentoPrazosId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int Parcela { get; set; }
        public int Valor { get; set; }
        public decimal ValorCoeficiente { get; set; }
    }
}
