using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class ReceitasDespesasNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion 

        #region Variáveis Default

        string nomeTabela = "ReceitasDespesas";

        string sqlDefault = "SELECT RD.ReceitasDespesasId,RD.Emissao,RD.Vencimento,RD.ClientesId,C.Nome AS Cliente,RD.VendasId,RD.FormaPagamentoId,RD.FornecedorId,F.Descricao AS FormaPagamento,RD.Valor,RD.Parcela,RD.Observacao,RD.ValorPago,RD.DataPagamento,RD.StatusPagamento,RD.ValorExtenso,RD.ValorFatura,RD.NumeroDocumento,RD.MultaAposVencimento,RD.MultaPorDia,RD.DiasAtraso,RD.BaixaParcial,RD.Desconto,RD.MultaAposVencimentoPercentualValor,RD.MultaAoDiaPercentualValor,RD.PagouComCartão FROM ReceitasDespesas RD LEFT JOIN Clientes C ON C.ClientesId =RD.ClientesId LEFT JOIN FormaPagamento F ON F.FormaPagamentoId =RD.FormaPagamentoId ";

        string sqlDefaultReceitasRecebidasNova = "SELECT E.EmprNome, E.EmprFant, E.EmprEnde, E.EmprBair, E.EmprTele, E.EmprNume, E.EmprCep, E.EmprCnpj, E.EmprInsc,RD.Cli_Codi,C.Cli_Nome, M.MuniNome, C.Cli_Fonp, RD.ReDeCodi, RD.ReDeDtEm, RD.ReDeDtVe, RD.PrazCodi, FP.PrazDesc, RD.PlanCodi,P.PlanDesc, RDB.DiasAtraso AS ReDeDiasAtras,    (RDB.Valor - ISNULL(RDB.ValorJuros,0) + ISNULL(RDB.ValorDesconto,0)) as ReDeValo ,RD.ReDeParc,RD.ReDeObse, RDB.Valor AS ReDeVlPg, RDB.Data AS ReDeDtPg, RD.ReDeNume,  RDB.ValorMulta AS ReDeMultAposVenc, RDB.ValorJuros,RD.ReDeNumeCheque, (CASE WHEN (SELECT DATEDIFF(DAY, GETDATE(), RD.ReDeDtVe)) < 0 THEN (((SELECT DATEDIFF(DAY, GETDATE(), RD.ReDeDtVe)) * - RDB.ValorJuros) +  RDB.ValorMulta) ELSE '0' END) AS MultaTotal, ContaID, RD.StatusID, ISNULL(S.StatusNome,'ABERTO') AS StatusNome, RD.TipoPagamentoRecebimentoID,TPR.TipoDescricao, ISNULL(RDB.ValorDesconto,0) AS ReDeDesconto, RD.SituacaoLancamento, FP.PrazDesc, BancNome   FROM Empresa E, ReceitasDespesas RD     LEFT OUTER JOIN PlanoContas P on P.PlanCodi=RD.PlanCodi    LEFT OUTER JOIN Clientes C on C.Cli_Codi=RD.Cli_Codi  LEFT JOIN Municipios M ON C.Mun_Codi = M.Mun_Codi LEFT OUTER JOIN FormasPagamentos FP on RD.PrazCodi = FP.PrazCodi LEFT JOIN StatusOperacoes S ON S.StatusID = RD.StatusID LEFT JOIN TipoPagamentoRecebimento TPR on RD.TipoPagamentoRecebimentoID = TPR.TipoID  LEFT JOIN Bancos B ON RD.BancoID = B.BancCodi  LEFT JOIN ReceitasDespesasBaixas RDB ON RD.ReDeCodi = RDB.ReceitaID ";

        #endregion

        #region Métodos Publicos

        public Boolean InserirNovo(ReceitasDespesas receitasDespesas)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(receitasDespesas));
        }

        public Boolean Alterar(ReceitasDespesas receitasDespesas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(receitasDespesas), PreencheCondicoes(receitasDespesas));
        }

        public Boolean AlterarDevolucao(ReceitasDespesas receitasDespesas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosDevolucao(receitasDespesas), PreencheCondicoes(receitasDespesas));
        }

        public Boolean AlterarStatusReceitaDespesa(ReceitasDespesas receitasDespesas) //Usado para baixa nova
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosReceitaDespesaPaga(receitasDespesas), PreencheCondicoes(receitasDespesas));
        }

        public Boolean ExcluirNovo(ReceitasDespesas receitasDespesas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(receitasDespesas));
        }

        public Boolean ExcluirReceitaDespesaCompraVenda(ReceitasDespesas receitasDespesas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoesCompraVenda(receitasDespesas));
        }

        public DataTable PesquisarPorCodigo(int receitasDespesasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE RD.ReceitasDespesasId = {1}", sqlDefault, receitasDespesasId));
        }

        public bool AlterarStatus(int receitasDespesasId, string statusPagamento)
        {
            return conexao.Executar("UPDATE ReceitasDespesas SET StatusPagamento = '" + statusPagamento + "' WHERE ReceitasDespesasId = " + receitasDespesasId);
        }

        public DataTable PesquisarPorNome(string paramNome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE RD.Emissao LIKE '%{1}%' ORDER BY RD.Emissao", sqlDefault, paramNome));
        }

        public DataTable PesquisarPorCodigoVenda(int vendaId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE VendaId = {1} ORDER BY Vencimento", sqlDefault, vendaId));
        }

        public DataTable PesquisarUltimaReceitaDespesas()
        {
            return conexao.Pesquisar("SELECT MAX(ReceitasDespesasId) AS ReceitasDespesasId FROM ReceitasDespesas");
        }

        public int PesquisarUltimaReceita()
        {
            DataTable dtReceita = conexao.Pesquisar("SELECT MAX(ReceitasDespesasId) AS ReceitasDespesasId FROM ReceitasDespesas WHERE ClienteId IS NOT NULL");

            return dtReceita.Rows.Count > 0 ? Convert.ToInt32(dtReceita.Rows[0][0]) : 0;
        }

        //PESQUISA AS DUPLICATAS
        public DataTable PesquisarReceitaDespesaPorCodigoCompraVendaStatus(int vendasId, string statusPagamento)
        {
            string comandoSql = sqlDefault;

            if (!string.IsNullOrEmpty(statusPagamento))
                comandoSql += ValidarString(comandoSql) + string.Format("RD.StatusPagamento = '{0}'", statusPagamento);

            if (vendasId > 0)
                comandoSql += ValidarString(comandoSql) + string.Format("RD.VendasId = {0}", vendasId);

            return conexao.Pesquisar(string.Format("{0}", comandoSql));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(ReceitasDespesas receitasDespesas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (!receitasDespesas.Emissao.ToString().Contains("01/01/0001") && !receitasDespesas.Emissao.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("Emissao", receitasDespesas.Emissao.ToString("yyyy-MM-dd HH:mm:ss")));

            if (!receitasDespesas.Vencimento.ToString().Contains("01/01/0001") && !receitasDespesas.Vencimento.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("Vencimento", receitasDespesas.Vencimento.ToString("yyyy-MM-dd HH:mm:ss")));

            if (receitasDespesas.ClientesId > 0)
                lstParametros.Add(new SqlParametros("ClientesId", receitasDespesas.ClientesId));

            if (receitasDespesas.FormaPagamentoId > 0)
                lstParametros.Add(new SqlParametros("FormaPagamentoId", receitasDespesas.FormaPagamentoId));

            if (receitasDespesas.FornecedorId > 0)
                lstParametros.Add(new SqlParametros("FornecedorId", receitasDespesas.FornecedorId));

            if (receitasDespesas.VendasId > 0)
                lstParametros.Add(new SqlParametros("VendasId", receitasDespesas.VendasId));

            if (receitasDespesas.Valor != 0)
                lstParametros.Add(new SqlParametros("Valor", receitasDespesas.Valor.ToString().Replace(',', '.')));

            if (!string.IsNullOrEmpty(receitasDespesas.Parcela))
                lstParametros.Add(new SqlParametros("Parcela", receitasDespesas.Parcela));

            if (!string.IsNullOrEmpty(receitasDespesas.Observacao))
                lstParametros.Add(new SqlParametros("Observacao", receitasDespesas.Observacao));

            if (receitasDespesas.ValorPago != 0)
                lstParametros.Add(new SqlParametros("ValorPago", receitasDespesas.ValorPago.ToString().Replace(',', '.')));

            if (receitasDespesas.Pagando == true)
            {
                if (!receitasDespesas.DataPagamento.ToString().Contains("01/01/0001") && !receitasDespesas.DataPagamento.ToString().Contains("1/1/0001"))
                    lstParametros.Add(new SqlParametros("DataPagamento", receitasDespesas.DataPagamento.ToString("yyyy-MM-dd")));
            }

            if (receitasDespesas.Extorno == true)
            {
                lstParametros.Add(new SqlParametros("ValorPago", "0.00"));
                lstParametros.Add(new SqlParametros("DataPagamento", null));
            }

            lstParametros.Add(new SqlParametros("StatusPagamento", receitasDespesas.StatusPagamento));

            if (!string.IsNullOrEmpty(receitasDespesas.ValorExtenso))
                lstParametros.Add(new SqlParametros("ValorExtenso", receitasDespesas.ValorExtenso.ToUpper()));

            if (receitasDespesas.ValorFatura != 0)
                lstParametros.Add(new SqlParametros("ValorFatura", receitasDespesas.ValorFatura.ToString().Replace(',', '.')));

            if (!string.IsNullOrEmpty(receitasDespesas.NumeroDocumento))
                lstParametros.Add(new SqlParametros("NumeroDocumento", receitasDespesas.NumeroDocumento));

            lstParametros.Add(new SqlParametros("DiasAtraso", receitasDespesas.DiasAtraso));

            lstParametros.Add(new SqlParametros("MultaAposVencimento", receitasDespesas.MultaAposVencimento.ToString().Replace(',', '.')));

            lstParametros.Add(new SqlParametros("MultaPorDia", receitasDespesas.MultaPorDia.ToString().Replace(',', '.')));

            if (receitasDespesas.BaixaParcial > 0)
                lstParametros.Add(new SqlParametros("BaixaParcial", receitasDespesas.BaixaParcial));

            lstParametros.Add(new SqlParametros("PagouComCartão", receitasDespesas.PagouComCartão));
            lstParametros.Add(new SqlParametros("Desconto", receitasDespesas.Desconto.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("MultaAposVencimentoPercentualValor", receitasDespesas.MultaAposVencimentoPercentualValor));
            lstParametros.Add(new SqlParametros("MultaAoDiaPercentualValor", receitasDespesas.MultaAoDiaPercentualValor));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(ReceitasDespesas receitasDespesas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ReceitasDespesasId", receitasDespesas.ReceitasDespesasId));

            return lstParametrosCondicionais;
        }

        private List<SqlParametros> PreencheParametrosDevolucao(ReceitasDespesas receitasDespesas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();
            lstParametros.Add(new SqlParametros("Valor", receitasDespesas.Valor.ToString().Replace(".", "").Replace(',', '.')));
            lstParametros.Add(new SqlParametros("ValorPago", receitasDespesas.ValorPago.ToString().Replace(".", "").Replace(',', '.')));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosReceitaDespesaPaga(ReceitasDespesas receitasDespesas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();
            lstParametros.Add(new SqlParametros("StatusPagamento", receitasDespesas.StatusPagamento));
            lstParametros.Add(new SqlParametros("DataPagamento", receitasDespesas.DataPagamento.ToString("yyyy-MM-dd HH:mm:ss")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoesCompraVenda(ReceitasDespesas receitasDespesas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("VendasId", receitasDespesas.VendasId));

            return lstParametrosCondicionais;
        }


        #endregion
    }
}
