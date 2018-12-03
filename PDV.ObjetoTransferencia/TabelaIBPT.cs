using System;

namespace PDV.ObjetoTransferencia
{
    public class TabelaIBPT
    {
        public long TabelaIBPTId { get; set; }
        public string NCM { get; set; }
        public int Ex { get; set; }
        public int Tipo { get; set; }
        public string Descricao { get; set; }
        public decimal Aliq_Federal_Nacional { get; set; }
        public decimal Aliq_Federal_Importado { get; set; }
        public decimal Aliq_Estadual { get; set; }
        public decimal Aliq_Municipal { get; set; }
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFim { get; set; }
        public string Versao { get; set; }
    }
}
