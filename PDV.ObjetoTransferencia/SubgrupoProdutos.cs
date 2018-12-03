namespace PDV.ObjetoTransferencia
{
    public class SubgrupoProdutos
    {
        public int SubgrupoProdutosId { get; set; }
        public int GrupoProdutosId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
