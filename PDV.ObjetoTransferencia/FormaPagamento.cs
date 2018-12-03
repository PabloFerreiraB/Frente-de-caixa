namespace PDV.ObjetoTransferencia
{
    public class FormaPagamento
    {
        public int FormaPagamentoId { get; set; }
        public bool Ativo { get; set; }
        public string Descricao { get; set; }
        public int StatusId { get; set; }
        public int Forma1 { get; set; }
        public int Forma2 { get; set; }
        public int Forma3 { get; set; }
        public int Forma4 { get; set; }
        public int Forma5 { get; set; }
        public int Forma6 { get; set; }
        public int FormaCartao { get; set; }
        public decimal FormaPercentualTaxa { get; set; }
        public int FormaIntervaloEmDias { get; set; }
        public int FormaParcelas { get; set; }
        public int FormaPrimeiroVencimento { get; set; }
        public string Tipo { get; set; }

        public FormaPagamento()
        {

        }

        public FormaPagamento(int formaPagamentoId)
        {
            FormaPagamentoId = formaPagamentoId;
        }

        public FormaPagamento(int formaPagamentoId, string descricao)
        {
            FormaPagamentoId = formaPagamentoId;
            Descricao = descricao;
        }





        public string DescricaoStatus { get; set; }

    }
}
