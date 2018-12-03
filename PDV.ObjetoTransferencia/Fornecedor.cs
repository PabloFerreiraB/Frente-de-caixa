using System;

namespace PDV.ObjetoTransferencia
{
    public class Fornecedor
    {
        public int FornecedorId { get; set; }
        public string Nome { get; set; }
        public string NomeFantasia { get; set; }
        public bool Ativo { get; set; }
        public string TipoPessoa { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIE { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Contato { get; set; }
        public string Cep { get; set; }
        public int CidadeId { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string SiteFornecedor { get; set; }
        public string Observacao { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
