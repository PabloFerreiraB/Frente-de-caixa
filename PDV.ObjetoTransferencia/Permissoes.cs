namespace PDV.ObjetoTransferencia
{
    public class Permissoes
    {
        public int PermissoesId { get; set; }
        public int UsuarioId { get; set; }
        public int FormulariosId { get; set; }
        public bool Inserir { get; set; }
        public bool Alterar { get; set; }
        public bool Excluir { get; set; }
        public bool Visualizar { get; set; }
    }
}
