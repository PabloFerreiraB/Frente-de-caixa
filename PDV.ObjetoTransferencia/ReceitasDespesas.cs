using System;

namespace PDV.ObjetoTransferencia
{
    public class ReceitasDespesas
    {
        public int ReceitasDespesasId { get; set; }
        public DateTime Emissao { get; set; }
        public DateTime Vencimento { get; set; }
        public long ClientesId { get; set; }
        public long VendasId { get; set; }
        public int FormaPagamentoId { get; set; }
        public int FornecedorId { get; set; }
        public decimal Valor { get; set; }
        public string Parcela { get; set; }
        public string Observacao { get; set; }
        public decimal ValorPago { get; set; }
        public DateTime DataPagamento { get; set; }
        public string StatusPagamento { get; set; }
        public string ValorExtenso { get; set; }
        public decimal ValorFatura { get; set; }
        public string NumeroDocumento { get; set; }
        public decimal MultaAposVencimento { get; set; }
        public decimal MultaPorDia { get; set; }
        public string DiasAtraso { get; set; }
        public int BaixaParcial { get; set; }
        public decimal Desconto { get; set; }
        public int MultaAposVencimentoPercentualValor { get; set; }
        public int MultaAoDiaPercentualValor { get; set; }
        public bool PagouComCartão { get; set; }

        public ReceitasDespesas()
        {

        }

        public ReceitasDespesas(int receitasDespesasId)
        {
            ReceitasDespesasId = receitasDespesasId;
        }


        public bool Pagando { get; set; }
        public bool Extorno { get; set; }  //VERIFICA SE ESTOU EXTORNANDO UMA CONTA A PAGAR OU RECEBER

    }
}
