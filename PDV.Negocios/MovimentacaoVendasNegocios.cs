using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class MovimentacaoVendasNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "MovimentacaoVendas";

        string sqlDefault = "SELECT M.MovimentacaoVendasId,M.ReceitasDespesasId,RD.NumeroDocumento,RD.Parcela,M.CaixaId,M.TransferenciaSaldoClientesId,M.ReceitasDespesasBaixasId,M.ClientesId,CL.Nome AS Cliente,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,FP.FormaPagamentoId,FP.Descricao AS FormaPagamento FROM MovimentacaoVendas M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes CL ON CL.ClientesId =RD.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =RD.FornecedorId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =RD.FormaPagamentoId ";

        #endregion

        #region Métodos Publicos

        public Boolean InserirNovo(MovimentacaoVendas movimentacaoVendas)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(movimentacaoVendas));
        }

        public Boolean Alterar(MovimentacaoVendas movimentacaoVendas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(movimentacaoVendas), PreencheCondicoesMovimento(movimentacaoVendas));
        }

        public Boolean Excluir(MovimentacaoVendas movimentacaoVendas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(movimentacaoVendas));
        }

        //Baixa Nova
        public Boolean ExcluirReceitaDespesaBaixa(MovimentacaoVendas movimentacaoVendas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesReceitasDespesasBaixa(movimentacaoVendas));
        }

        public Boolean ApagarMovimentoTransferencias(int transferenciaSaldoClientesId)
        {
            return conexao.Executar(string.Format("DELETE FROM {0} WHERE TransferenciaSaldoClientesId = {1}", nomeTabela, transferenciaSaldoClientesId));
        }

        public Boolean ExcluirMovimento(MovimentacaoVendas movimentacaoVendas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesMovimento(movimentacaoVendas));
        }

        public DataTable PesquisarPorCodigo(int movimentacaoVendasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE M.MovimentacaoVendasId={1}", sqlDefault, movimentacaoVendasId));
        }

        public DataTable PesquisarMovimento_ReceitaDespesa(int receitasDespesasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE M.ReceitasDespesasId = {1} ORDER BY M.DataHora", sqlDefault, receitasDespesasId));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public DataTable PesquisarMovimentos(int? caixaId, DateTime? dataInicial, DateTime? dataFinal, string statusMovimentacao)
        {
            string strCmd = sqlDefault;

            if (caixaId > 0)
                strCmd += ValidarString(strCmd) + string.Format("M.CaixaId = {0}", caixaId);

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora between '{0}' and '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(statusMovimentacao))
                strCmd += ValidarString(strCmd) + string.Format("StatusMovimentacao = '{0}'", statusMovimentacao);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosEntrada(int? caixaId, DateTime? dataInicial, DateTime? dataFinal, string statusMovimentacao)
        {
            string strCmd = "SELECT M.MovimentacaoVendasId,M.ReceitasDespesasId,RD.NumeroDocumento,RD.Parcela,C.CaixaId,M.TransferenciaSaldoClientesId,M.ReceitasDespesasBaixasId,M.ClientesId,CL.Nome AS Cliente,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,FP.FormaPagamentoId,FP.Descricao AS FormaPagamento FROM MovimentacaoVendas M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes CL ON CL.ClientesId =RD.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =RD.FornecedorId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =RD.FormaPagamentoId WHERE M.Tipo = 'R' ";

            if (caixaId > 0)
                strCmd += ValidarString(strCmd) + string.Format("M.CaixaId = {0}", caixaId);

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora between '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(statusMovimentacao))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", statusMovimentacao);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosSaida(int? caixaId, DateTime? dataInicial, DateTime? dataFinal, string statusMovimentacao)
        {
            string strCmd = "SELECT M.MovimentacaoVendasId,M.ReceitasDespesasId,RD.NumeroDocumento,RD.Parcela,C.CaixaId,M.TransferenciaSaldoClientesId,M.ReceitasDespesasBaixasId,M.ClientesId,CL.Nome AS Cliente,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,FP.FormaPagamentoId,FP.Descricao AS FormaPagamento FROM MovimentacaoVendas M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes CL ON CL.ClientesId =RD.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =RD.FornecedorId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =RD.FormaPagamentoId WHERE M.Tipo = 'D' ";

            if (caixaId > 0)
                strCmd += ValidarString(strCmd) + string.Format("M.CaixaId = {0}", caixaId);

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora between '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(statusMovimentacao))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", statusMovimentacao);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosPorFuncionario(int caixaId, DateTime? dataAbertura, DateTime? dataFechamento, string statusMovimentacao)
        {
            string strCmd = "SELECT M.MovimentacaoVendasId,M.ReceitasDespesasId,C.CaixaId,M.ClientesId,CL.Nome AS Cliente,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,FP.FormaPagamentoId,FP.Descricao AS FormaPagamento FROM MovimentacaoVendas M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Vendas V ON V.VendasId =RD.VendasId LEFT JOIN Clientes CL ON CL.ClientesId =RD.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =RD.FornecedorId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =RD.FormaPagamentoId ";

            if (caixaId > 0)
                strCmd += ValidarString(strCmd) + string.Format("C.CaixaId = '{0}'", caixaId);
            else if (dataAbertura != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora between '{0}' and '{1}'", dataAbertura.Value.ToString("yyyy-MM-dd HH:mm:ss"), dataFechamento.Value.ToString("yyyy-MM-dd HH:mm:ss"));

            if (!string.IsNullOrEmpty(statusMovimentacao))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", statusMovimentacao);

            return conexao.Pesquisar(strCmd);
        }

        public decimal PesquisarValoresRecebidosAndPago(DateTime? dataInicial, DateTime? dataFinal, string tipo, int caixaId)
        {
            string sqlCommand = "SELECT SUM(M.Valor) AS Valor FROM MovimentacaoVendas M LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId = M.ReceitasDespesasId ";

            if (caixaId.Equals(0))
            {
                if (dataInicial != null)
                    sqlCommand += ValidarString(sqlCommand) + string.Format("M.DataHora between '{0}' and '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));
            }

            if (!string.IsNullOrEmpty(tipo))
                sqlCommand += ValidarString(sqlCommand) + string.Format("M.Tipo = '{0}' ", tipo);

            try
            {
                return Convert.ToDecimal(conexao.Pesquisar(sqlCommand).Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public MovimentacaoVendas PesquisarMovimento(int receitasDespesasId)
        {
            Conexao conexao = new Conexao();

            string UltimoMovimentoDaReceita = conexao.ExecuteScalar("SELECT MAX(MovimentacaoVendasId) AS MovimentacaoVendasId FROM MovimentacaoVendas WHERE ReceitasDespesasId = " + receitasDespesasId);

            if (!string.IsNullOrEmpty(UltimoMovimentoDaReceita))
            {
                DataTable dtMovimento = new DataTable();
                dtMovimento = conexao.Pesquisar(string.Format("{0} WHERE M.MovimentacaoVendasId = {1}", sqlDefault, UltimoMovimentoDaReceita));

                if (dtMovimento != null && dtMovimento.Rows.Count > 0)
                {
                    var movimentacaoVendas = new MovimentacaoVendas()
                    {
                        MovimentacaoVendasId = Convert.ToInt32(dtMovimento.Rows[0]["MovimentacaoVendasId"]),
                        CaixaId = Convert.ToInt32(dtMovimento.Rows[0]["CaixaId"]),
                        DataHora = Convert.ToDateTime(dtMovimento.Rows[0]["DataHora"]),
                        Observacao = dtMovimento.Rows[0]["Observacao"].ToString(),
                        StatusMovimentacao = dtMovimento.Rows[0]["StatusMovimentacao"].ToString(),
                        Tipo = dtMovimento.Rows[0]["Tipo"].ToString(),
                        Valor = Convert.ToDecimal(dtMovimento.Rows[0]["Valor"]),
                        ReceitasDespesasId = Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasId"]),
                    };
                    return movimentacaoVendas;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public MovimentacaoVendas PesquisarMovimentoBaixaNova(int receitasDespesasBaixasId)
        {
            DataTable dtMovimento = new DataTable();
            dtMovimento = conexao.Pesquisar(string.Format("{0} WHERE M.ReceitasDespesasBaixasId = {1}", sqlDefault, receitasDespesasBaixasId));

            if (dtMovimento != null && dtMovimento.Rows.Count > 0)
            {
                var objMovimentoTemp = new MovimentacaoVendas()
                {
                    MovimentacaoVendasId = Convert.ToInt32(dtMovimento.Rows[0]["MovimentacaoVendasId"]),
                    CaixaId = Convert.ToInt32(dtMovimento.Rows[0]["CaixaId"]),
                    DataHora = Convert.ToDateTime(dtMovimento.Rows[0]["DataHora"]),
                    Observacao = dtMovimento.Rows[0]["Observacao"].ToString(),
                    StatusMovimentacao = dtMovimento.Rows[0]["StatusMovimentacao"].ToString(),
                    Tipo = dtMovimento.Rows[0]["Tipo"].ToString(),
                    Valor = Convert.ToDecimal(dtMovimento.Rows[0]["Valor"]),
                    ReceitasDespesasId = Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasId"]),
                    ReceitasDespesasBaixaId = !string.IsNullOrEmpty(dtMovimento.Rows[0]["ReceitasDespesasBaixaId"].ToString()) ? Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasBaixaId"]) : 0,
                };
                return objMovimentoTemp;
            }
            else
                return null;
        }

        public DataTable PesquisarMovimentosAberturaFechamentoCaixa(int caixaId)
        {
            string strCmd = "SELECT M.MovimentacaoVendasId,M.ReceitasDespesasId,M.CaixaId,M.ClientesId,CL.Nome AS Cliente,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN M.Valor ELSE (M.Valor * -1) END AS Valor,M.StatusMovimentacao,M.Observacao FROM MovimentacaoVendas M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes CL ON CL.ClientesId =RD.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =RD.FornecedorId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =RD.FormaPagamentoId ";

            strCmd += ValidarString(strCmd) + string.Format("M.CaixaId = '{0}'", caixaId);

            return conexao.Pesquisar(strCmd);
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(MovimentacaoVendas movimentacaoVendas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (!movimentacaoVendas.DataHora.ToString().Contains("01/01/0001") && !movimentacaoVendas.DataHora.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataHora", movimentacaoVendas.DataHora.ToString("yyyy-MM-dd HH:mm:ss")));

            if (movimentacaoVendas.ReceitasDespesasId > 0)
                lstParametros.Add(new SqlParametros("ReceitasDespesasId", movimentacaoVendas.ReceitasDespesasId));

            lstParametros.Add(new SqlParametros("Valor", movimentacaoVendas.Valor.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Tipo", movimentacaoVendas.Tipo));
            lstParametros.Add(new SqlParametros("StatusMovimentacao", movimentacaoVendas.StatusMovimentacao));
            lstParametros.Add(new SqlParametros("Observacao", movimentacaoVendas.Observacao));

            if (movimentacaoVendas.CaixaId > 0)
                lstParametros.Add(new SqlParametros("CaixaId", movimentacaoVendas.CaixaId));

            if (movimentacaoVendas.TransferenciaSaldoClientesId > 0)
                lstParametros.Add(new SqlParametros("TransferenciaSaldoClientesId", movimentacaoVendas.TransferenciaSaldoClientesId));

            if (movimentacaoVendas.ReceitasDespesasBaixaId > 0)
                lstParametros.Add(new SqlParametros("ReceitasDespesasBaixaId", movimentacaoVendas.ReceitasDespesasBaixaId));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(MovimentacaoVendas movimentacaoVendas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasId", movimentacaoVendas.ReceitasDespesasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesMovimento(MovimentacaoVendas movimentacaoVendas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("MovimentacaoVendasId", movimentacaoVendas.MovimentacaoVendasId));

            return lstParametrosCondicionais;
        }

        //Baixa Nova
        private List<SqlParametros> PreencheCondicoesReceitasDespesasBaixa(MovimentacaoVendas movimentacaoVendas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasBaixaId", movimentacaoVendas.ReceitasDespesasBaixaId));

            return lstParametrosCondicionais;
        }

        #endregion 

    }
}
