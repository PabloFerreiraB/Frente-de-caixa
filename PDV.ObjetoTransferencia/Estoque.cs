using System;

namespace PDV.ObjetoTransferencia
{
    public class Estoque
    {
        public long EstoqueId { get; set; }
        public long EstoqueEntradaId { get; set; }
        public long EstoqueSaidaId { get; set; }
        public int ProdutosId { get; set; }
        public long VendasItensId { get; set; }
        public DateTime DataHora { get; set; }
        public int Tipo { get; set; }
        public int Quantidade { get; set; }
        public int Serie { get; set; }
        public bool MovimentacaoSerie { get; set; }
    }
}
