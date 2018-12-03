using System;

namespace PDV.ObjetoTransferencia
{
    public class Clientes
    {
        public long ClientesId { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public int Sexo { get; set; }
        public int EstadoCivil { get; set; }
        public string ApelidoFantasia { get; set; }
        public string Nacionalidade { get; set; }
        public string Naturalidade { get; set; }
        public string Tipo { get; set; }
        public string CpfCnpj { get; set; }
        public string RgIE { get; set; }
        public DateTime Nascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public int CidadeId { get; set; }
        public string Bairro { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public decimal LimiteCredito { get; set; }
        public string Observacao { get; set; }
        public string ImagemCliente { get; set; }

    }
}
