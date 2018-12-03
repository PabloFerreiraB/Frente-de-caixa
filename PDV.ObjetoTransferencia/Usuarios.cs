using System;

namespace PDV.ObjetoTransferencia
{
    public class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string NomeLogin { get; set; }
        public string Senha { get; set; }
        public string Perfil { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
