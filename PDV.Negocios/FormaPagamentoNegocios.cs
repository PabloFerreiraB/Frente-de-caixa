using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class FormaPagamentoNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "FormaPagamento";

        string sqlDefault = "SELECT F.FormaPagamentoId,F.StatusId,F.Ativo,S.Descricao AS DescricaoStatus,F.Tipo,F.Descricao,F.Forma1,F.Forma2,F.Forma3,F.Forma4,F.Forma5,F.Forma6,F.FormaCartao,F.FormaPercentualTaxa,F.FormaIntervaloEmDias,F.FormaParcelas,F.FormaPrimeiroVencimento FROM FormaPagamento F LEFT JOIN StatusOperacoes S ON S.StatusId =F.StatusId ";

        string sqlDefaultGridFormasPagamento = "SELECT F.FormaPagamentoId,F.StatusId,F.Ativo,S.Descricao AS DescricaoStatus,F.Tipo,F.Descricao,F.Forma1,F.Forma2,F.Forma3,F.Forma4,F.Forma5,F.Forma6,F.FormaCartao,F.FormaPercentualTaxa,F.FormaIntervaloEmDias,F.FormaParcelas,F.FormaPrimeiroVencimento FROM FormaPagamento F LEFT JOIN StatusOperacoes S ON S.StatusId =F.StatusId WHERE F.Ativo ='True' AND F.Tipo ='R' ORDER BY F.Descricao ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(FormaPagamento formaPagamento)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(formaPagamento));
        }

        public Boolean Alterar(FormaPagamento formaPagamento)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(formaPagamento), PreencheCondicoes(formaPagamento));
        }

        public Boolean Excluir(FormaPagamento formaPagamento)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(formaPagamento));
        }

        public DataTable PesquisarPorCodigo(int formaPagamentoId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND F.FormaPagamentoId = {1}", sqlDefault, formaPagamentoId));
        }

        public DataTable PesquisarPorNome(string descricao)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND F.Descricao LIKE '%{1}%' ORDER BY F.Descricao", sqlDefault, descricao));
        }

        public decimal PesquisarPercentualTaxa(int formaPagamentoId)
        {
            return Convert.ToDecimal(conexao.Pesquisar("SELECT FormaPercentualTaxa FROM FormaPagamento WHERE F.Ativo = 'True' AND FormaPagamentoId = " + formaPagamentoId).Rows[0][0]);
        }

        public DataTable PesquisarFormasAVista()
        {
            return conexao.Pesquisar(string.Format(@"SELECT FP.FormaPagamentoId,FP.Descricao FROM FormaPagamentoPrazos FPP INNER JOIN FormaPagamento FP ON FP.FormaPagamentoId =FPP.FormaPagamentoId WHERE FP.FormaParcelas =1 AND FP.FormaPrimeiroVencimento =0 AND {0} 
                                                      AND ((SELECT COUNT (1) FROM FormaPagamentoPrazos FPPC WHERE FP.Ativo = 'True' AND FPPC.FormaPagamentoPrazosId =FP.FormaPagamentoId)=1) ORDER BY FP.Descricao "));
        }

        public FormaPagamento PesquisarFormaPagamento(int formaPagamentoId)
        {
            DataTable dtForma = new DataTable();
            dtForma = conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND F.FormaPagamentoId = {1} ", sqlDefault, formaPagamentoId));

            if (dtForma.Rows.Count > 0 && dtForma != null)
            {
                FormaPagamento formaPagamento = new FormaPagamento();

                formaPagamento.FormaPagamentoId = Convert.ToInt32(dtForma.Rows[0]["FormaPagamentoId"].ToString());
                formaPagamento.Descricao = dtForma.Rows[0]["Descricao"].ToString();
                formaPagamento.StatusId = !string.IsNullOrEmpty(dtForma.Rows[0]["StatusId"].ToString()) ? Convert.ToInt32(dtForma.Rows[0]["StatusId"].ToString()) : 0;
                formaPagamento.DescricaoStatus = dtForma.Rows[0]["DescricaoStatus"].ToString();

                return formaPagamento;
            }
            else
                return null;
        }

        public DataTable PesquisarPorTipo(string tipo)
        { 
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND F.Tipo = '" + tipo + "' ORDER BY F.Descricao", sqlDefault));
        }


        public DataTable CarregarGridFormas()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY F.Descricao ", sqlDefault));
        }


        public DataTable PesquisarFormasReceitasCombobox()
        { 
            return conexao.Pesquisar(string.Format("{0} ORDER BY F.Descricao", sqlDefault));
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

        private List<SqlParametros> PreencheParametros(FormaPagamento formaPagamento)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Tipo", formaPagamento.Tipo));
            lstParametros.Add(new SqlParametros("Descricao", formaPagamento.Descricao));
            lstParametros.Add(new SqlParametros("Ativo", formaPagamento.Ativo));

            if (formaPagamento.Forma1 >= 0)
                lstParametros.Add(new SqlParametros("Forma1", formaPagamento.Forma1));

            if (formaPagamento.Forma2 > 0)
                lstParametros.Add(new SqlParametros("Forma2", formaPagamento.Forma2));

            if (formaPagamento.Forma3 > 0)
                lstParametros.Add(new SqlParametros("Forma3", formaPagamento.Forma3));

            if (formaPagamento.Forma4 > 0)
                lstParametros.Add(new SqlParametros("Forma4", formaPagamento.Forma4));

            if (formaPagamento.Forma5 > 0)
                lstParametros.Add(new SqlParametros("Forma5", formaPagamento.Forma5));

            if (formaPagamento.Forma6 > 0)
                lstParametros.Add(new SqlParametros("Forma6", formaPagamento.Forma6));

            if (formaPagamento.FormaCartao > 0)
            {
                lstParametros.Add(new SqlParametros("FormaCartao", formaPagamento.FormaCartao));
                lstParametros.Add(new SqlParametros("FormaPercentualTaxa", formaPagamento.FormaPercentualTaxa.ToString().Replace(",", ".")));
            }

            if (formaPagamento.StatusId > 0)
                lstParametros.Add(new SqlParametros("StatusId", formaPagamento.StatusId));

            lstParametros.Add(new SqlParametros("FormaIntervaloEmDias", formaPagamento.FormaIntervaloEmDias));
            lstParametros.Add(new SqlParametros("FormaParcelas", formaPagamento.FormaParcelas));
            lstParametros.Add(new SqlParametros("FormaPrimeiroVencimento", formaPagamento.FormaPrimeiroVencimento));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(FormaPagamento formaPagamento)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FormaPagamentoId", formaPagamento.FormaPagamentoId));

            return lstParametrosCondicionais;
        }

        #endregion
    }
}
