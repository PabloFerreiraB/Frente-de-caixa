using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class SaldoClientesNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "SaldoClientes";

        string sqlDefault = "SELECT S.SaldoClientesId,S.ClientesId,C.Nome AS Cliente,S.FuncionarioId,F.Nome AS Funcionario,S.VendasId,S.ReceitasDespesasId,S.CaixaId,S.Operacao,S.Valor,S.Observacao,S.DataHora,S.Situacao,S.Referencia,S.Devolucao FROM SaldoClientes S LEFT OUTER JOIN Clientes C ON C.ClientesId =S.ClientesId LEFT OUTER JOIN Funcionarios F ON F.FuncionarioId =S.FuncionarioId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(SaldoClientes saldoClientes)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(saldoClientes));
        }

        public Boolean Alterar(SaldoClientes saldoClientes)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(saldoClientes), PreencheCondicoes(saldoClientes));
        }

        public Boolean AlterarSituacaoPorID(SaldoClientes saldoClientes)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosAtualizarSituacao(saldoClientes), PreencheCondicoesSaldo(saldoClientes));
        }

        public Boolean AlterarSituacaoPorDevolucaoID(SaldoClientes saldoClientes)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosAtualizarSituacao(saldoClientes), PreencheCondicoesDevolucao(saldoClientes));
        }

        public Boolean Excluir(SaldoClientes saldoClientes)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(saldoClientes));
        }

        public Boolean ExcluirSaldoPedido(SaldoClientes saldoClientes)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesPedido(saldoClientes));
        }

        public DataTable PesquisarPorCliente(int clientesId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE S.ClientesId = {1}", sqlDefault, clientesId));
        }

        public DataTable PesquisarPorCodigo(int saldoClientesId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE S.SaldoClientesId = {1}", sqlDefault, saldoClientesId));
        }

        public DataTable PesquisarPorReceitaDespesa(int receitasDespesasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE S.ReceitasDespesasId = {1}", sqlDefault, receitasDespesasId));
        }

        public decimal PesquisarSaldoCliente(int clienteId)
        {
            return Convert.ToDecimal(conexao.Pesquisar("SELECT ISNULL(SUM(Valor), 0) FROM SaldoClientes WHERE ClientesId = " + clienteId).Rows[0][0]);
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public DataTable PesquisarLancamentos(int clienteId, int funcionarioId, int vendasId)
        {
            string strCmd = sqlDefault;

            if (clienteId > 0)
                strCmd += ValidarString(strCmd) + string.Format("S.ClientesId ='{0}'", clienteId);

            if (funcionarioId > 0)
                strCmd += ValidarString(strCmd) + string.Format("S.FuncionarioId = '{0}' ", funcionarioId);

            if (vendasId > 0)
                strCmd += ValidarString(strCmd) + string.Format("S.VendasId = '{0}' ", vendasId);

            return conexao.Pesquisar(string.Format("{0}", strCmd));
        }

        public DataTable PesquisarSaldoCliente(int clientesId, bool totalizar, bool ignorarPeriodo, DateTime dataInicial, DateTime dataFinal)
        {
            string strCmd = string.Empty;

            if (!totalizar)
            {
                strCmd = @"SELECT MAX (C.Nome) AS Cliente,SUM (S.Valor) AS Valor FROM SaldoClientes S INNER JOIN Clientes C ON C.ClientesId = S.ClientesId ";

                if (clientesId > 0)
                    strCmd += ValidarString(strCmd) + string.Format(" S.ClientesId = '{0}' ", clientesId);

                if (ignorarPeriodo == false)
                    strCmd += ValidarString(strCmd) + string.Format("S.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.ToString("yyyy-MM-dd 00:00:00"), dataFinal.ToString("yyyy-MM-dd 23:59:59"));

                strCmd += @" GROUP BY C.Nome HAVING SUM(S.Valor) > 0 ORDER BY C.Nome ASC";
            }
            else
            {
                strCmd = @"SELECT S.ClientesId,C.Nome,S.Valor,S.Observacao, S.Operacao, S.DataHora FROM SaldoClientes S INNER JOIN Clientes C ON C.ClientesId = S.ClientesId ";

                if (clientesId > 0)
                    strCmd += ValidarString(strCmd) + string.Format(" S.ClientesId = '{0}'", clientesId);

                if (ignorarPeriodo == false)
                    strCmd += ValidarString(strCmd) + string.Format("S.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.ToString("yyyy-MM-dd 00:00:00"), dataFinal.ToString("yyyy-MM-dd 23:59:59"));

                strCmd += " ORDER BY C.Nome ASC";
            }

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarSaldoDevolucaoExtratoCliente(int clientesId, DateTime? dataInicial, DateTime? dataFinal, bool ignorarPeriodo)
        {
            string sqlCommand = @"SELECT S.SaldoClientesId,S.DataHora,S.ClientesId,C.Nome AS Cliente,S.Valor,S.Observacao,ISNULL((
                                SELECT SUM (SC.Valor) FROM SaldoClientes SC WHERE SC.Devolucao =S.Devolucao AND SC.Operacao =2),0) AS SaldoUtilizado 
                                FROM SaldoClientes S INNER JOIN Clientes C ON C.ClientesId =S.ClientesId WHERE S.Devolucao IS NOT NULL ";

            if (!ignorarPeriodo)
            {
                if (dataInicial != null && dataFinal != null)
                    sqlCommand += ValidarString(sqlCommand) + string.Format("(S.SaldoData between '{0}' and '{1}')", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));
            }

            if (clientesId > 0)
                sqlCommand += ValidarString(sqlCommand) + string.Format("S.ClienteID = '{0}' ", clientesId);

            sqlCommand += ValidarString(sqlCommand) + "SaldoOperacao = 1";
            sqlCommand += ValidarString(sqlCommand) + "SaldoSituacao = 'AB'";

            return conexao.Pesquisar(sqlCommand);
        }

        public decimal PesquisarSaldoLancadoDaVenda(int vendasId)
        {
            return Convert.ToDecimal(conexao.Pesquisar("SELECT ISNULL(SUM(Valor), 0) AS Valor FROM SaldoClientes WHERE Valor > 0 AND VendasId = " + vendasId).Rows[0][0]);
        }

        public Boolean ExcluirSaldoClientePorReceitaDespesa(SaldoClientes saldoClientes)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesReceitasDespesas(saldoClientes));
        }

        public SaldoClientes PesquisarSaldoClienteUtilizado(int clientesId)
        {
            string qry = string.Format(@"SELECT TOP 1 S.SaldoClientesId,S.ClientesId,S.Operacao,S.Valor,S.Situacao,S.DataHora,ISNULL(S.VendasId,0) AS VendasId,ISNULL(S.CaixaId,0) AS CaixaId,ISNULL(S.ReceitasDespesasId,0) AS ReceitasDespesasId,ISNULL(S.Devolucao,0) AS Devolucao,ISNULL(S.Referencia,0) AS Referencia,ISNULL((
                                         SELECT SUM (SC.Valor) FROM SaldoClientes SC WHERE S.Referencia =S.SaldoClientesId AND S.Operacao = 2),0) AS SaldoUtilizado FROM SaldoClientes S WHERE (S.Situacao ='AB' OR S.Situacao IS NULL) AND S.Operacao = 1 AND S.ClientesId = {0} ORDER BY S.DataHora ASC ", clientesId);

            DataTable ds = conexao.Pesquisar(qry);
            SaldoClientes SaldoClientes = new SaldoClientes();

            SaldoClientes.SaldoClientesId = Convert.ToInt32(ds.Rows[0]["SaldoClientesId"].ToString());
            SaldoClientes.ClientesId = Convert.ToInt32(ds.Rows[0]["ClientesId"].ToString());
            SaldoClientes.Operacao = Convert.ToInt32(ds.Rows[0]["Operacao"].ToString());
            SaldoClientes.Valor = Convert.ToDecimal(Convert.ToDecimal(ds.Rows[0]["Valor"].ToString()));
            SaldoClientes.Situacao = ds.Rows[0]["Situacao"].ToString();
            SaldoClientes.DataHora = Convert.ToDateTime(ds.Rows[0]["DataHora"].ToString());
            SaldoClientes.VendasId = Convert.ToInt32(ds.Rows[0]["VendasId"].ToString());
            SaldoClientes.CaixaId = Convert.ToInt32(ds.Rows[0]["CaixaId"].ToString());
            SaldoClientes.ReceitasDespesasId = Convert.ToInt32(ds.Rows[0]["ReceitasDespesasId"].ToString());
            SaldoClientes.Referencia = Convert.ToInt32(ds.Rows[0]["Referencia"].ToString());
            SaldoClientes.Devolucao = Convert.ToInt32(ds.Rows[0]["Devolucao"].ToString());
            SaldoClientes.SaldoUtilizado = Convert.ToDecimal(ds.Rows[0]["SaldoUtilizado"].ToString());

            return SaldoClientes;
        }

        #region Descontar saldo devolução

        //Situação do saldo do cliente
        public void DescontarSaldoCliente(SaldoClientes requisicao)
        {
            SaldoClientes utilizado = PesquisarSaldoClienteUtilizado(Convert.ToInt32(requisicao.ClientesId));

            decimal saldoADescontar = utilizado.Valor + utilizado.SaldoUtilizado;
            decimal valorADescontar = requisicao.Valor * -1;

            if (valorADescontar < saldoADescontar)
            {
                //DESCONTAR O SALDO
                requisicao.Devolucao = utilizado.Devolucao;
                requisicao.Referencia = utilizado.SaldoClientesId;
                Inserir(requisicao);
            }
            else if (valorADescontar == saldoADescontar)
            {
                //DESCONTAR O SALDO
                requisicao.Devolucao = utilizado.Devolucao;
                requisicao.Referencia = utilizado.SaldoClientesId;
                Inserir(requisicao);

                //ATUALIZAR O STATUS DO SALDO PRINCIPAL
                SaldoClientes atualizaStatus = new SaldoClientes();
                atualizaStatus.Situacao = "PG";
                atualizaStatus.SaldoClientesId = utilizado.SaldoClientesId;
                AlterarSituacaoPorID(atualizaStatus);
            }
            else if (valorADescontar > saldoADescontar)
            {
                //DESCONTAR O SALDO
                requisicao.Valor = (saldoADescontar * -1);
                requisicao.Devolucao = utilizado.Devolucao;
                requisicao.Referencia = utilizado.SaldoClientesId;
                Inserir(requisicao);

                //ATUALIZAR O STATUS DO SALDO PRINCIPAL
                SaldoClientes atualizaStatus = new SaldoClientes();
                atualizaStatus.Situacao = "PG";
                atualizaStatus.SaldoClientesId = utilizado.SaldoClientesId;
                AlterarSituacaoPorID(atualizaStatus);

                //CHAMAR O MÉTODO RECURSIVO
                requisicao.Valor = (saldoADescontar - valorADescontar);
                DescontarSaldoCliente(requisicao);
            }
        }

        public decimal PesquisarTotalDevolucaoAberto(int devolucao)
        {
            string sqlCommand = string.Format("SELECT ISNULL(SUM(Valor), 0) AS Total FROM SaldoClientes WHERE Referencia IS NULL AND Situacao = 'AB' AND Devolucao = {0}", devolucao.ToString());

            DataTable dtTotal = conexao.Pesquisar(sqlCommand);

            if (dtTotal.Rows.Count > 0)
                return Convert.ToDecimal(dtTotal.Rows[0][0]);
            else
                return 0;
        }

        public Boolean ExcluirSaldoClientePorDevolucao(int devolucao)
        {
            return conexao.Executar("DELETE FROM SaldoClientes WHERE Devolucao = " + devolucao);
        }

        #endregion

        #endregion

        #region Métodos Privados

        private List<SqlParametros> PreencheParametros(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("ClientesId", saldoClientes.ClientesId));
            lstParametros.Add(new SqlParametros("Operacao", saldoClientes.Operacao));
            lstParametros.Add(new SqlParametros("Valor", saldoClientes.Valor.ToString().Replace(".", "").Replace(",", ".")));

            if (saldoClientes.FuncionarioId > 0)
                lstParametros.Add(new SqlParametros("FuncionarioId", saldoClientes.FuncionarioId));

            lstParametros.Add(new SqlParametros("Observacao", saldoClientes.Observacao));
            lstParametros.Add(new SqlParametros("DataHora", saldoClientes.DataHora.ToString("yyyy-MM-dd")));

            if (saldoClientes.VendasId > 0)
                lstParametros.Add(new SqlParametros("VendasId", saldoClientes.VendasId));

            if (saldoClientes.CaixaId > 0)
                lstParametros.Add(new SqlParametros("CaixaId", saldoClientes.CaixaId));

            if (saldoClientes.ReceitasDespesasId > 0)
                lstParametros.Add(new SqlParametros("ReceitasDespesasId", saldoClientes.ReceitasDespesasId));

            if (saldoClientes.Devolucao > 0)
                lstParametros.Add(new SqlParametros("Devolucao", saldoClientes.Devolucao));

            lstParametros.Add(new SqlParametros("Situacao", !string.IsNullOrEmpty(saldoClientes.Situacao) ? saldoClientes.Situacao : "AB"));

            if (saldoClientes.Referencia > 0)
                lstParametros.Add(new SqlParametros("Referencia", saldoClientes.Referencia));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosAtualizarSituacao(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Situacao", saldoClientes.Situacao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoesSaldo(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("SaldoClientesId", saldoClientes.SaldoClientesId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoes(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ClientesId", saldoClientes.ClientesId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesPedido(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("VendasId", saldoClientes.VendasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesReceitasDespesas(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasId", saldoClientes.ReceitasDespesasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesDevolucao(SaldoClientes saldoClientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("Devolucao", saldoClientes.Devolucao));

            return lstParametrosCondicionais;
        }

        #endregion
    }
}
