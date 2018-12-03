namespace PDV.ObjetoTransferencia
{
    public class TributacaoFiscal
    {
        public int TributacaoFiscalId { get; set; }
        public string Descricao { get; set; }
        public int RegimeTributario { get; set; }
        public int Tipo { get; set; }
        public int Icms_Issqn { get; set; }
        public string Cfop { get; set; }
        public bool CalcularIBPT { get; set; }
        public bool MovimentaEstoque { get; set; }
        public bool GerarFinanceiro { get; set; }
        public string IcmsCst { get; set; }
        public int IcmsOrigem { get; set; }
        public decimal IcmsPercentualBC { get; set; }
        public decimal IcmsPercentual { get; set; }
        public decimal IcmsValor { get; set; } //não tem na tabela
        public bool CalcularSTIcms { get; set; }

        public string IpiCst { get; set; }
        public decimal IpiPercentualBC { get; set; }
        public decimal IpiPercentual { get; set; }
        public string IpiCodigo { get; set; }

        public string PisCst { get; set; }
        public decimal PisValor { get; set; } //não tem na tabela
        public decimal PisPercentualBC { get; set; }
        public decimal PisPercentual { get; set; }
        public bool PisGerarST { get; set; }
        public decimal PisSTPercentualBC { get; set; }
        public decimal PisSTPercentual { get; set; }

        public string CofinsCst { get; set; } 
        public decimal CofinsValor { get; set; } //não tem na tabela
        public decimal CofinsPercentualBC { get; set; }
        public decimal CofinsPercentual { get; set; }
        public bool CofinsGerarST { get; set; }
        public decimal CofinsSTPercentualBC { get; set; }
        public decimal CofinsSTPercentual { get; set; }

        public decimal IbptAliquotaFederal { get; set; } //não tem na tabela
        public decimal IbptAliquotaEstadual { get; set; } //não tem na tabela
        public decimal IbptAliquotaMunicipal { get; set; } //não tem na tabela
    }
}
