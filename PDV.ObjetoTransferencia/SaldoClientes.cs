using System;

namespace PDV.ObjetoTransferencia
{
    public class SaldoClientes
    {
        public int SaldoClientesId { get; set; }
        public long ClientesId { get; set; }
        public int FuncionarioId { get; set; }
        public long VendasId { get; set; }
        public int CaixaId { get; set; }
        public int ReceitasDespesasId { get; set; }
        public int Operacao { get; set; }
        public decimal Valor { get; set; }
        public string Observacao { get; set; }
        public DateTime DataHora { get; set; }
        public string Situacao { get; set; }
        public int Referencia { get; set; }
        public int Devolucao { get; set; }
        public decimal SaldoUtilizado { get; set; }
    }
}
