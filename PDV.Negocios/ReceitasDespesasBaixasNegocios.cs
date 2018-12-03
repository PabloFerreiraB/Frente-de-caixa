using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class ReceitasDespesasBaixasNegocios
    {
         
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "ReceitasDespesasBaixas";

        string sqlDefault = "SELECT ReceitasDespesasBaixasId,UsuarioId,UsuarioCancelamentoId,ReceitasDespesasId,DataHora,MultaPercentualValor,Multa,DescontoPercentualValor,Desconto,JurosPercentualValor,Juros,DataCancelamento,DiasAtraso,Valor FROM ReceitasDespesasBaixas ";

        #endregion

        #region Métodos Publicos

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public Boolean Inserir(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(receitasDespesasBaixas));
        }

        public Boolean Alterar(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(receitasDespesasBaixas), PreencheCondicoes(receitasDespesasBaixas));
        }

        public Boolean AlterarCancelado(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosCancelamento(receitasDespesasBaixas), PreencherCondicoesCancelado(receitasDespesasBaixas));
        }

        public Boolean AlterarDevolucao(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosDevolucao(receitasDespesasBaixas), PreencheCondicoes(receitasDespesasBaixas));
        }

        public Boolean Excluir(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(receitasDespesasBaixas));
        }

        public DataTable PesquisarPorCodigo(int receitasDespesasBaixasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE ReceitasDespesasBaixasId = {1}", sqlDefault, receitasDespesasBaixasId));
        }

        public DataTable PesquisarReceitasRecebidasDataSource(DateTime paramDataInicial, DateTime paramDataFinal, bool paramIgnorarPeriodo, int paramClienteID)
        {
            string sqlcommando = "SELECT CAST (0 AS BIT) AS Checked,RDB.ReceitasDespesasBaixasId,RD.ReceitasDespesasId,RD.Emissao,RD.Vencimento,RDB.DataHora,RD.ClientesId,C.Nome AS Cliente,RDB.Valor,RD.NumeroDocumento,RD.Parcela,RDB.Desconto,RDB.Multa,RDB.Juros,RD.Observacao FROM ReceitasDespesasBaixas RDB LEFT OUTER JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId = RDB.ReceitasDespesasId LEFT JOIN Clientes C ON C.ClientesId =RD.ClientesId ";

            sqlcommando += ValidarString(sqlcommando) + string.Format("RDB.UsuarioCancelamentoId IS NULL ");

            if (!paramIgnorarPeriodo)
            {
                if (paramDataInicial != null && paramDataFinal != null)
                {
                    sqlcommando += ValidarString(sqlcommando) + string.Format("RDB.DataHora BETWEEN '{0}' AND '{1}'", paramDataInicial.ToString("yyyy-MM-dd 00:00:00"), paramDataFinal.ToString("yyyy-MM-dd 23:59:59"));
                }
            }

            if (paramClienteID > 0)
            {
                sqlcommando += ValidarString(sqlcommando) + string.Format("RD.ClientesId = {0}", paramClienteID);
            }

            return conexao.Pesquisar(sqlcommando + " ORDER BY RDB.DataHora DESC ");
        }

        public DataTable PesquisarBaixaRecibo(int receitasDespesasBaixasId)
        {
            string sqlComando = "SELECT RDB.ReceitasDespesasBaixasId,RD.Vencimento,RD.NumeroDocumento,RD.Parcela,RD.Valor,RD.Observacao,RDB.DataHora,RDB.Valor,RDB.Multa,RDB.Desconto,RDB.Juros FROM ReceitasDespesasBaixas RDB LEFT OUTER JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =RDB.ReceitasDespesasId ";

            return conexao.Pesquisar(string.Format("{0} WHERE RDB.ReceitasDespesasBaixasId = {1}", sqlComando, receitasDespesasBaixasId));
        }


        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("DataHora", receitasDespesasBaixas.DataHora.ToString("yyyy-MM-dd")));

            if (receitasDespesasBaixas.UsuarioId > 0)
                lstParametros.Add(new SqlParametros("UsuarioId", receitasDespesasBaixas.UsuarioId));

            lstParametros.Add(new SqlParametros("ReceitasDespesasId", receitasDespesasBaixas.ReceitasDespesasId));
            lstParametros.Add(new SqlParametros("Valor", receitasDespesasBaixas.Valor.ToString().Replace(".", "").Replace(',', '.')));

            if (receitasDespesasBaixas.UsuarioCancelamentoId > 0)
                lstParametros.Add(new SqlParametros("UsuarioCancelamentoId", receitasDespesasBaixas.UsuarioCancelamentoId));

            lstParametros.Add(new SqlParametros("MultaPercentualValor", receitasDespesasBaixas.MultaPercentualValor));
            lstParametros.Add(new SqlParametros("Multa", receitasDespesasBaixas.Multa.ToString().Replace(".", "").Replace(',', '.')));
            lstParametros.Add(new SqlParametros("DescontoPercentualValor", receitasDespesasBaixas.DescontoPercentualValor));
            lstParametros.Add(new SqlParametros("Desconto", receitasDespesasBaixas.Desconto.ToString().Replace(".", "").Replace(',', '.')));
            lstParametros.Add(new SqlParametros("JurosPercentualValor", receitasDespesasBaixas.JurosPercentualValor));
            lstParametros.Add(new SqlParametros("Juros", receitasDespesasBaixas.Juros.ToString().Replace(".", "").Replace(',', '.')));
            lstParametros.Add(new SqlParametros("DiasAtraso", receitasDespesasBaixas.DiasAtraso));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosCancelamento(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("DataCancelamento", receitasDespesasBaixas.DataCancelamento.ToString("yyyy-MM-dd HH:mm:ss")));
            lstParametros.Add(new SqlParametros("UsuarioCancelamentoId", receitasDespesasBaixas.UsuarioCancelamentoId));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosDevolucao(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Valor", receitasDespesasBaixas.Valor.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasId", receitasDespesasBaixas.ReceitasDespesasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencherCondicoesCancelado(ReceitasDespesasBaixas receitasDespesasBaixas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasBaixasId", receitasDespesasBaixas.ReceitasDespesasBaixasId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
