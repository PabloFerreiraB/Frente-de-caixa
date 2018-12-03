using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class TributacaoFiscalNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "TributacaoFiscal";

        string sqlDefault = "SELECT DISTINCT TributacaoFiscalId,T.Descricao,RegimeTributario,Tipo,Icms_Issqn,Cfop,C.Descricao AS DescricaoCFOP,CalcularIBPT,GerarFinanceiro,MovimentaEstoque,IcmsCst,IcmsOrigem,IcmsPercentualBC,IcmsPercentual,IpiCst,IpiPercentualBC,IpiPercentual,IpiCodigo,PisCst,PisPercentualBC,PisPercentual,PisGerarST,PisSTPercentualBC,PisSTPercentual,CofinsCst,CofinsPercentualBC,CofinsPercentual,CofinsGerarST,CofinsSTPercentualBC,CofinsSTPercentual,CalcularSTIcms FROM TributacaoFiscal T LEFT JOIN Cfop C ON C.Codigo =T.Cfop ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(TributacaoFiscal tributacaoFiscal)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(tributacaoFiscal));
        }

        public Boolean Alterar(TributacaoFiscal tributacaoFiscal)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(tributacaoFiscal), PreencheCondicoes(tributacaoFiscal));
        }

        public Boolean Excluir(TributacaoFiscal tributacaoFiscal)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(tributacaoFiscal));
        }

        public DataTable PesquisarPorCodigo(int tributacaoFiscalId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE TributacaoFiscalId = {1}", sqlDefault, tributacaoFiscalId));
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE T.Descricao LIKE '%{1}%' ORDER BY T.Descricao", sqlDefault, descricao));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }


        //paramRegimeTributacao = SIMPLES NACIONAL | REGIME NORMAL
        public DataTable PesquisarTributacoesFiscaisDataSource(int tipo, int regimeTributario)
        {
            string sql = "SELECT DISTINCT T.TributacaoFiscalId,T.Descricao AS Descricao,T.RegimeTributario,CASE WHEN T.Tipo ='0' THEN '0 - Entrada' WHEN T.Tipo ='1' THEN '1 - Saida' ELSE '0 - Saida' END AS Tipo,CASE WHEN T.Icms_Issqn ='1' THEN '1 - ICMS' WHEN T.Icms_Issqn='2' THEN '2 - ISSQN' ELSE '1 - ICMS' END AS Icms_Issqn,(T.CFOP +' - '+CONVERT (VARCHAR (1000),C.Descricao)) AS Cfop,CASE WHEN T.MovimentaEstoque ='1' THEN 'Sim' WHEN T.MovimentaEstoque ='0' THEN 'Não' ELSE 'Sim' END AS MovimentaEstoque,CASE WHEN T.GerarFinanceiro ='1' THEN 'Sim' WHEN T.GerarFinanceiro ='0' THEN 'Não' ELSE 'Sim' END AS GerarFinanceiro,CASE WHEN T.CalcularIBPT ='1' THEN 'Sim' WHEN T.CalcularIBPT ='0' THEN 'Não' ELSE 'Sim' END AS CalcularIBPT,(T.IcmsCst +' - '+CONVERT (VARCHAR (1000),IC.Descricao)) AS IcmsCst,(CONVERT (VARCHAR (2),T.IcmsOrigem)+' - '+CONVERT (VARCHAR (1000),O.Descricao)) AS Origem,IcmsPercentualBC,IcmsPercentual,(T.IpiCst +' - '+CONVERT (VARCHAR (1000),I.Descricao)) AS IpiCst,IpiPercentualBC,IpiPercentual,(T.PisCst +' - '+CONVERT (VARCHAR (1000),P.Descricao)) AS PisCst,PisPercentualBC,PisPercentual AS PercentualPis,(T.CofinsCst +' - '+CONVERT (VARCHAR (1000),CO.Descricao)) AS CofinsCst,CofinsPercentualBC,CofinsPercentual FROM TributacaoFiscal T LEFT JOIN Cfop C ON C.Codigo =T.Cfop LEFT JOIN Icms IC ON IC.IcmsCst =T.IcmsCst LEFT JOIN Origem O ON O.OrigemId =T.IcmsOrigem LEFT JOIN Ipi I ON I.IpiCst =T.IpiCst LEFT JOIN Pis P ON P.PisCst =T.PisCst LEFT JOIN Cofins CO ON CO.CofinsCst =T.CofinsCst ";

            if (tipo >= 0)
                sql += ValidarString(sql) + string.Format("T.Tipo = {0}", tipo);

            sql += ValidarString(sql) + string.Format("T.RegimeTributario = {0}", regimeTributario);

            return conexao.Pesquisar(string.Format("{0}", sql));
        }

        public DataTable PesquisarOperacoesPorTipo(int tipo)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE T.Tipo = {1}", sqlDefault, tipo));
        }


        public DataTable PesquisarGruposImpostosEntrada()
        {
            string sql = "SELECT TributacaoFiscalId, Descricao FROM TributacaoFiscal ";

            sql += ValidarString(sql) + string.Format("Tipo = 0");

            return conexao.Pesquisar(string.Format("{0} ORDER BY Descricao ", sql));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(TributacaoFiscal tributacaoFiscal)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", tributacaoFiscal.Descricao));
            lstParametros.Add(new SqlParametros("RegimeTributario", tributacaoFiscal.RegimeTributario));
            lstParametros.Add(new SqlParametros("Tipo", tributacaoFiscal.Tipo));
            lstParametros.Add(new SqlParametros("Icms_Issqn", tributacaoFiscal.Icms_Issqn));
            lstParametros.Add(new SqlParametros("Cfop", tributacaoFiscal.Cfop));
            lstParametros.Add(new SqlParametros("CalcularIBPT", tributacaoFiscal.CalcularIBPT));
            lstParametros.Add(new SqlParametros("MovimentaEstoque", tributacaoFiscal.MovimentaEstoque));
            lstParametros.Add(new SqlParametros("GerarFinanceiro", tributacaoFiscal.GerarFinanceiro));
            lstParametros.Add(new SqlParametros("IcmsCst", tributacaoFiscal.IcmsCst));
            lstParametros.Add(new SqlParametros("IcmsOrigem", tributacaoFiscal.IcmsOrigem));
            lstParametros.Add(new SqlParametros("IcmsPercentualBC", tributacaoFiscal.IcmsPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IcmsPercentual", tributacaoFiscal.IcmsPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IpiCst", tributacaoFiscal.IpiCst));
            lstParametros.Add(new SqlParametros("IpiPercentualBC", tributacaoFiscal.IpiPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IpiPercentual", tributacaoFiscal.IpiPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("IpiCodigo", tributacaoFiscal.IpiCodigo));
            lstParametros.Add(new SqlParametros("PisCst", tributacaoFiscal.PisCst)); //Pis
            lstParametros.Add(new SqlParametros("PisPercentualBC", tributacaoFiscal.PisPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("PisPercentual", tributacaoFiscal.PisPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("PisGerarST", tributacaoFiscal.PisGerarST));
            lstParametros.Add(new SqlParametros("PisSTPercentualBC", tributacaoFiscal.PisSTPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("PisSTPercentual", tributacaoFiscal.PisSTPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CofinsCst", tributacaoFiscal.CofinsCst)); //Cofins
            lstParametros.Add(new SqlParametros("CofinsPercentualBC", tributacaoFiscal.CofinsPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CofinsPercentual", tributacaoFiscal.CofinsPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CofinsGerarST", tributacaoFiscal.CofinsGerarST));
            lstParametros.Add(new SqlParametros("CofinsSTPercentualBC", tributacaoFiscal.CofinsSTPercentualBC.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CofinsSTPercentual", tributacaoFiscal.CofinsSTPercentual.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CalcularSTIcms", tributacaoFiscal.CalcularSTIcms));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(TributacaoFiscal TributacaoFiscal)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("TributacaoFiscalId", TributacaoFiscal.TributacaoFiscalId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
