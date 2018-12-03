using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class TabelaIBPTNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "TabelaIBPT";

        string sqlDefault = "SELECT TabelaIBPTId,NCM,Ex,Tipo,Descricao,ISNULL(Aliq_Federal_Nacional,0) AS Aliq_Federal_Nacional,ISNULL(Aliq_Federal_Importado,0) AS Aliq_Federal_Importado,ISNULL(Aliq_Estadual,0) AS Aliq_Estadual,ISNULL(Aliq_Municipal,0) AS Aliq_Municipal,VigenciaInicio,VigenciaFim,Versao FROM TabelaIBPT ";

        #endregion 

        #region Métodos Publicos

        public Boolean Inserir(TabelaIBPT tabelaIBPT)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(tabelaIBPT));
        }

        public Boolean Alterar(TabelaIBPT tabelaIBPT)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(tabelaIBPT), PreencheCondicoes(tabelaIBPT));
        }

        public Boolean Excluir(TabelaIBPT tabelaIBPT)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(tabelaIBPT));
        }

        public DataTable PesquisarPorCodigo()
        {
            return conexao.Pesquisar(string.Format("{0}", sqlDefault));
        }

        public DataTable PesquisarPorCodigo(int tabelaIBPTId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE TabelaIBPTId = {1}", sqlDefault, tabelaIBPTId));
        }

        public bool ExcluirRegistros()
        {
            return conexao.Executar("DELETE FROM TabelaIBPT");
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE (Descricao LIKE '%{1}%') OR (NCM LIKE '%{1}%') ORDER BY NCM ", sqlDefault, descricao));
        }

        public decimal PesquisarAliquota(string ncm)
        {
            try
            {
                return Convert.ToDecimal(conexao.Pesquisar("SELECT Aliq_Federal_Nacional FROM TabelaIBPT WHERE NCM = '" + ncm + "'").Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public TabelaIBPT PesquisarAliquotasFederalEstadualMunicipal(string ncm)
        {
            DataTable dt = new DataTable();
            dt = conexao.Pesquisar(string.Format("{0} WHERE NCM = '{1}'", sqlDefault, ncm));

            TabelaIBPT ibpt = new TabelaIBPT();

            if (dt.Rows.Count > 0 && dt != null)
            {
                ibpt.Aliq_Federal_Nacional = Convert.ToDecimal(dt.Rows[0]["Aliq_Federal_Nacional"]);
                ibpt.Aliq_Federal_Importado = Convert.ToDecimal(dt.Rows[0]["Aliq_Federal_Importado"]);
                ibpt.Aliq_Estadual = Convert.ToDecimal(dt.Rows[0]["Aliq_Estadual"]);
                ibpt.Aliq_Municipal = Convert.ToDecimal(dt.Rows[0]["Aliq_Municipal"]);
            }

            return ibpt;
        }

        public TabelaIBPT PesquisarValoresIBPT(string ncm)
        {
            TabelaIBPT ibpt = new TabelaIBPT();

            if (ncm.Length.Equals(8))
            {
                DataTable dtResult = new DataTable();
                for (int i = 8; i > 0; i--)
                {
                    dtResult = conexao.Pesquisar("SELECT ISNULL(Aliq_Federal_Nacional, 0) AS Aliq_Federal_Nacional, ISNULL(Aliq_Federal_Importado, 0) AS Aliq_Federal_Importado, ISNULL(Aliq_Estadual, 0) AS Aliq_Estadual, ISNULL(Aliq_Municipal, 0) AS Aliq_Municipal FROM TabelaIBPT WHERE NCM = " + ncm.Substring(0, i));
                    if (dtResult.Rows.Count > 0)
                    {
                        ibpt.Aliq_Federal_Nacional = Convert.ToDecimal(dtResult.Rows[0]["Aliq_Federal_Nacional"]);
                        ibpt.Aliq_Federal_Importado = Convert.ToDecimal(dtResult.Rows[0]["Aliq_Federal_Importado"]);
                        ibpt.Aliq_Estadual = Convert.ToDecimal(dtResult.Rows[0]["Aliq_Estadual"]);
                        ibpt.Aliq_Municipal = Convert.ToDecimal(dtResult.Rows[0]["Aliq_Municipal"]);

                        break;
                    }
                }
            }

            return ibpt;
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(TabelaIBPT tabelaIBPT)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("NCM", tabelaIBPT.NCM));
            lstParametros.Add(new SqlParametros("Ex", tabelaIBPT.Ex));
            lstParametros.Add(new SqlParametros("Tipo", tabelaIBPT.Tipo));
            lstParametros.Add(new SqlParametros("Descricao", tabelaIBPT.Descricao));
            lstParametros.Add(new SqlParametros("Aliq_Federal_Nacional", tabelaIBPT.Aliq_Federal_Nacional.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Aliq_Federal_Importado", tabelaIBPT.Aliq_Federal_Importado.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Aliq_Estadual", tabelaIBPT.Aliq_Estadual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Aliq_Municipal", tabelaIBPT.Aliq_Municipal.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(TabelaIBPT tabelaIBPT)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("NCM", tabelaIBPT.NCM));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
