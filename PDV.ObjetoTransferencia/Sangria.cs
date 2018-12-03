using System;

namespace PDV.ObjetoTransferencia
{
    public class Sangria
    {
        public int SangriaId { get; set; }
        public int CaixaId { get; set; }
        public int UsuarioId { get; set; }
        public decimal ValorCaixa { get; set; }
        public decimal ValorSangria { get; set; }
        public decimal ValorAposSangria { get; set; }
        public DateTime DataHora { get; set; }
        public int Tipo { get; set; }
        public string Observacao { get; set; }
    }
}
