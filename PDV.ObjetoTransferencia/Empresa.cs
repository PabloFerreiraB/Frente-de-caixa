using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDV.ObjetoTransferencia
{
    public class Empresa
    {
        public int EmpresaId { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string Cep { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public string Cnpj { get; set; }
        public string IE { get; set; }
        public string IM { get; set; }
        public string SiteEmpresa { get; set; }
        public string Email { get; set; }
        public int RegimeTributario { get; set; }
        public int TipoAtividade { get; set; }
        public int Csosn { get; set; }

        public string NomeC { get; set; }
        public string CpfC { get; set; }
        public string CRCC { get; set; }
        public string TelefoneC { get; set; }
        public string CelularC { get; set; }
        public string EmailC { get; set; }
        public int CidadeCId { get; set; }

        public string Logotipo { get; set; }
    }
}
