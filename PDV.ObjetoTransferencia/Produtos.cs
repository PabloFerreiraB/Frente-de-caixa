using System;

namespace PDV.ObjetoTransferencia
{
    public class Produtos
    {
        public long ProdutosId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
        public string CodigoBarras { get; set; }
        public int UnidadeMedidaId { get; set; }
        public int GrupoProdutosId { get; set; }
        public int SubgrupoProdutosId { get; set; }
        public int TributacaoFiscalId { get; set; }
        public int FornecedorId { get; set; }
        public long TabelaIBPTId { get; set; }
        public decimal ValorCompra { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorUnitario { get; set; }
        public int EstoqueInicial { get; set; }
        public int EstoqueAtual { get; set; }
        public int EstoqueMinimo { get; set; }
        public int EstoqueMaximo { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; } 
        public DateTime UltimaCompra { get; set; }

        public Produtos()
        {

        }

        public Produtos(int produtoId)
        {
            ProdutosId = produtoId;
        }

    }
}
