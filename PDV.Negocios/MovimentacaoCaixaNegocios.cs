using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class MovimentacaoCaixaNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();
        SaldoCaixaNegocios saldoCaixaNegocios = new SaldoCaixaNegocios();

        #endregion

        #region Variáveis Default

        string nomeTabela = "MovimentacaoCaixa";

        string sqlDefault = "SELECT M.MovimentacaoCaixaId,M.CaixaId,M.ReceitasDespesasId,M.ReceitasDespesasBaixasId,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,CL.Nome AS Cliente,RD.NumeroDocumento,RD.Parcela,F.Descricao AS FormaPagamento FROM MovimentacaoCaixa M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes Cl ON CL.ClientesId =RD.ClientesId LEFT JOIN FormaPagamento F ON F.FormaPagamentoId =RD.FormaPagamentoId ";

        #endregion

        #region Métodos Publicos

        public Boolean InserirNovo(MovimentacaoCaixa movimentacaoCaixa)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(movimentacaoCaixa));
        }

        public Boolean Alterar(MovimentacaoCaixa movimentacaoCaixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(movimentacaoCaixa), PreencheCondicoesMovimento(movimentacaoCaixa));
        }

        public Boolean Excluir(MovimentacaoCaixa movimentacaoCaixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(movimentacaoCaixa));
        }

        //Baixa Nova
        public Boolean ExcluirReceitaDespesaBaixa(MovimentacaoCaixa movimentacaoCaixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesReceitasDespesasBaixa(movimentacaoCaixa));
        }

        public Boolean ExcluirMovimento(MovimentacaoCaixa movimentacaoCaixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesMovimento(movimentacaoCaixa));
        }

        public DataTable PesquisarPorCodigo(int paramCodigo)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE M.MoviCodi={1}", sqlDefault, paramCodigo));
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

        public DataTable PesquisarMovimentos(DateTime? dataInicial, DateTime? dataFinal, string status)
        {
            string strCmd = sqlDefault;

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(status))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", status);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosEntrada(DateTime? dataInicial, DateTime? dataFinal, string status)
        {
            string strCmd = "SELECT M.MovimentacaoCaixaId,M.CaixaId,M.ReceitasDespesasId,M.ReceitasDespesasBaixasId,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,CL.Nome AS Cliente,RD.NumeroDocumento,RD.Parcela,F.Descricao AS FormaPagamento FROM MovimentacaoCaixa M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes Cl ON CL.ClientesId =RD.ClientesId LEFT JOIN FormaPagamento F ON F.FormaPagamentoId =RD.FormaPagamentoId WHERE M.Tipo ='R' ";

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(status))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", status);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosSaida(DateTime? dataInicial, DateTime? dataFinal, string status)
        {
            string strCmd = "SELECT M.MovimentacaoCaixaId,M.CaixaId,M.ReceitasDespesasId,M.ReceitasDespesasBaixasId,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,CL.Nome AS Cliente,RD.NumeroDocumento,RD.Parcela,F.Descricao AS FormaPagamento FROM MovimentacaoCaixa M LEFT JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT JOIN Clientes Cl ON CL.ClientesId =RD.ClientesId LEFT JOIN FormaPagamento F ON F.FormaPagamentoId =RD.FormaPagamentoId WHERE M.Tipo ='D' ";

            if (dataInicial != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(status))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", status);

            strCmd += " ORDER BY M.DataHora";

            return conexao.Pesquisar(strCmd);
        }

        public DataTable PesquisarMovimentosPorFuncionario(DateTime? dataAbertura, DateTime? dataFechamento, string status)
        {
            string strCmd = "SELECT M.MovimentacaoCaixaId,M.CaixaId,M.ReceitasDespesasId,M.ReceitasDespesasBaixasId,M.DataHora,M.Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,CL.Nome AS Cliente,RD.NumeroDocumento,RD.Parcela,F.Descricao AS FormaPagamento FROM MovimentacaoCaixa M JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT OUTER JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT OUTER JOIN Clientes Cl ON CL.ClientesId =RD.ClientesId LEFT JOIN FormaPagamento F ON F.FormaPagamentoId =RD.FormaPagamentoId LEFT OUTER JOIN Vendas V ON V.VendasId =RD.VendasId ";

            if (dataAbertura != null)
                strCmd += ValidarString(strCmd) + string.Format("M.DataHora BETWEEN '{0}' AND '{1}'", dataAbertura.Value.ToString("yyyy-MM-dd 00:00:00"), dataFechamento.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (!string.IsNullOrEmpty(status))
                strCmd += ValidarString(strCmd) + string.Format("M.StatusMovimentacao = '{0}'", status);

            return conexao.Pesquisar(strCmd);
        }

        public decimal PesquisarValoresRecebidosAndPago(DateTime? dataInicial, DateTime? dataFinal, string tipo, int caixaId)
        {
            string sqlCommand = "SELECT SUM(RD.Valor) AS Valor FROM MovimentacaoCaixa M LEFT JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId = M.ReceitasDespesasId ";

            if (caixaId > 0)
                sqlCommand += ValidarString(sqlCommand) + string.Format("RD.CaixaId = '{0}' ", caixaId);

            if (caixaId.Equals(0))
            {
                if (dataInicial != null)
                    sqlCommand += ValidarString(sqlCommand) + string.Format("M.DataHora BETWEEN '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));
            }

            if (!string.IsNullOrEmpty(tipo))
                sqlCommand += ValidarString(sqlCommand) + string.Format("Tipo = '{0}' ", tipo);

            try
            {
                return Convert.ToDecimal(conexao.Pesquisar(sqlCommand).Rows[0][0]);
            }
            catch
            {
                return 0;
            }
        }

        public MovimentacaoCaixa PesquisarMovimento(int receitasDespesasId)
        {
            Conexao conexao = new Conexao();

            string ultimoMovimentoDaReceita = conexao.ExecuteScalar("SELECT MAX(MovimentacaoCaixaId) AS MovimentacaoCaixaId FROM MovimentacaoCaixa WHERE ReceitasDespesasId = " + receitasDespesasId);

            if (!string.IsNullOrEmpty(ultimoMovimentoDaReceita))
            {
                DataTable dtMovimento = new DataTable();
                dtMovimento = conexao.Pesquisar(string.Format("{0} WHERE M.MovimentacaoCaixaId = {1}", sqlDefault, ultimoMovimentoDaReceita));

                if (dtMovimento != null && dtMovimento.Rows.Count > 0)
                {
                    var movimentacaoCaixa = new MovimentacaoCaixa()
                    {
                        CaixaId = Convert.ToInt32(dtMovimento.Rows[0]["CaixaId"]),
                        MovimentacaoCaixaId = Convert.ToInt32(dtMovimento.Rows[0]["MovimentacaoCaixaId"]),
                        DataHora = Convert.ToDateTime(dtMovimento.Rows[0]["DataHora"]),
                        Observacao = dtMovimento.Rows[0]["Observacao"].ToString(),
                        StatusMovimentacao = dtMovimento.Rows[0]["StatusMovimentacao"].ToString(),
                        Tipo = dtMovimento.Rows[0]["Tipo"].ToString(),
                        Valor = Convert.ToDecimal(dtMovimento.Rows[0]["Valor"]),
                        ReceitasDespesasId = Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasId"]),
                    };
                    return movimentacaoCaixa;
                }
                else
                    return null;
            }
            else
                return null;
        }

        public MovimentacaoCaixa PesquisarMovimentoBaixaNova(int receitasDespesasBaixasId)
        {
            DataTable dtMovimento = new DataTable();
            dtMovimento = conexao.Pesquisar(string.Format("{0} WHERE M.ReceitasDespesasBaixasId = {1}", sqlDefault, receitasDespesasBaixasId));

            if (dtMovimento != null && dtMovimento.Rows.Count > 0)
            {
                var movimentacaoCaixa = new MovimentacaoCaixa()
                {
                    CaixaId = Convert.ToInt32(dtMovimento.Rows[0]["CaixaId"]),
                    MovimentacaoCaixaId = Convert.ToInt32(dtMovimento.Rows[0]["MovimentacaoCaixaId"]),
                    DataHora = Convert.ToDateTime(dtMovimento.Rows[0]["DataHora"]),
                    Observacao = dtMovimento.Rows[0]["Observacao"].ToString(),
                    StatusMovimentacao = dtMovimento.Rows[0]["StatusMovimentacao"].ToString(),
                    Tipo = dtMovimento.Rows[0]["Tipo"].ToString(),
                    Valor = Convert.ToDecimal(dtMovimento.Rows[0]["Valor"]),
                    ReceitasDespesasId = Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasId"]),
                    ReceitasDespesasBaixasId = !string.IsNullOrEmpty(dtMovimento.Rows[0]["ReceitasDespesasBaixasId"].ToString()) ? Convert.ToInt32(dtMovimento.Rows[0]["ReceitasDespesasBaixasId"]) : 0,
                };
                return movimentacaoCaixa;
            }
            else
                return null;
        }

        public DataTable PesquisarMovimentosAberturaFechamentoCaixa(int caixaId)
        {
            string strCmd = "SELECT M.MovimentacaoCaixaId,M.CaixaId,M.ReceitasDespesasId,M.DataHora,CASE WHEN M.Tipo ='R' THEN M.Valor ELSE (M.Valor * -1) END AS Valor,CASE WHEN M.Tipo ='R' THEN 'Receita' ELSE 'Despesa' END AS Tipo,M.StatusMovimentacao,M.Observacao,CL.Nome AS Cliente FROM MovimentacaoCaixa M JOIN Caixa C ON C.CaixaId =M.CaixaId LEFT OUTER JOIN ReceitasDespesas RD ON RD.ReceitasDespesasId =M.ReceitasDespesasId LEFT OUTER JOIN Clientes Cl ON CL.ClientesId =RD.ClientesId LEFT OUTER JOIN Vendas V ON V.VendasId =RD.VendasId ";

            strCmd += ValidarString(strCmd) + string.Format("M.CaixaId = '{0}'", caixaId);

            return conexao.Pesquisar(strCmd);
        }



        public void MovimentoCaixa(int movimentacaoCaixaId, decimal valor)
        {
            SaldoCaixa saldoCaixa = new SaldoCaixa();

            saldoCaixa.MovimentacaoCaixaId = movimentacaoCaixaId;
            saldoCaixa.Valor = valor;

            saldoCaixaNegocios.Inserir(saldoCaixa);
        }

        public void Excluir(int movimentacaoCaixaId)
        {
            SaldoCaixa saldoCaixa = new SaldoCaixa();

            saldoCaixa.MovimentacaoCaixaId = movimentacaoCaixaId;

            saldoCaixaNegocios.Excluir(saldoCaixa);
        }


        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(MovimentacaoCaixa movimentacaoCaixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (movimentacaoCaixa.MovimentacaoCaixaId > 0)
                lstParametros.Add(new SqlParametros("MovimentacaoCaixaId", movimentacaoCaixa.MovimentacaoCaixaId));

            lstParametros.Add(new SqlParametros("CaixaId", movimentacaoCaixa.CaixaId));

            if (movimentacaoCaixa.ReceitasDespesasId > 0)
                lstParametros.Add(new SqlParametros("ReceitasDespesasId", movimentacaoCaixa.ReceitasDespesasId));

            if (movimentacaoCaixa.ReceitasDespesasBaixasId > 0)
                lstParametros.Add(new SqlParametros("ReceitasDespesasBaixasId", movimentacaoCaixa.ReceitasDespesasBaixasId));

            if (!movimentacaoCaixa.DataHora.ToString().Contains("01/01/0001") && !movimentacaoCaixa.DataHora.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataHora", movimentacaoCaixa.DataHora.ToString("yyyy-MM-dd HH:mm:ss")));
            
            lstParametros.Add(new SqlParametros("Valor", movimentacaoCaixa.Valor.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Tipo", movimentacaoCaixa.Tipo));
            lstParametros.Add(new SqlParametros("StatusMovimentacao", movimentacaoCaixa.StatusMovimentacao));
            lstParametros.Add(new SqlParametros("Observacao", movimentacaoCaixa.Observacao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(MovimentacaoCaixa movimentacaoCaixa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasId", movimentacaoCaixa.ReceitasDespesasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheCondicoesMovimento(MovimentacaoCaixa movimentacaoCaixa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("MovimentacaoCaixaId", movimentacaoCaixa.MovimentacaoCaixaId));

            return lstParametrosCondicionais;
        }

        //Baixa Nova
        private List<SqlParametros> PreencheCondicoesReceitasDespesasBaixa(MovimentacaoCaixa movimentacaoCaixa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasBaixasId", movimentacaoCaixa.ReceitasDespesasBaixasId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
