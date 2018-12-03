using System;

namespace PDV.ObjetoTransferencia
{
    public class Caixa
    {
        public int CaixaId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Abertura { get; set; }
        public DateTime Fechamento { get; set; }
        public decimal Valor { get; set; }

    }
}
