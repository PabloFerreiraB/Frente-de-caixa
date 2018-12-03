using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class FormaPagamentoPrazosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "FormaPagamentoPrazos";

        string sqlDefault = "SELECT FormaPagamentoPrazosId, FormaPagamentoId, Parcela, Valor, ValorCoeficiente FROM FormaPagamentoPrazos ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(FormaPagamentoPrazos formaPagamentoPrazos)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(formaPagamentoPrazos));
        }

        public Boolean Alterar(FormaPagamentoPrazos formaPagamentoPrazos)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(formaPagamentoPrazos), PreencheCondicoes(formaPagamentoPrazos));
        }

        public Boolean Excluir(FormaPagamentoPrazos formaPagamentoPrazos)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(formaPagamentoPrazos));
        }

        public DataTable PesquisarPorCodigo(int formaPagamentoId)
        {
            string sql = "SELECT FormaPagamentoPrazosId,FPP.FormaPagamentoId,Parcela,Valor,ValorCoeficiente,FP.FormaCartao FROM FormaPagamentoPrazos FPP LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =FPP.FormaPagamentoId ";

            return conexao.Pesquisar(string.Format("{0} WHERE FP.FormaPagamentoId = {1} ORDER BY FP.Descricao", sql, formaPagamentoId));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(FormaPagamentoPrazos formaPagamentoPrazos)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("FormaPagamentoId", formaPagamentoPrazos.FormaPagamentoId));
            lstParametros.Add(new SqlParametros("Parcela", formaPagamentoPrazos.Parcela));
            lstParametros.Add(new SqlParametros("Valor", formaPagamentoPrazos.Valor));
            lstParametros.Add(new SqlParametros("ValorCoeficiente", formaPagamentoPrazos.ValorCoeficiente.ToString().Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(FormaPagamentoPrazos formaPagamentoPrazos)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FormaPagamentoId", formaPagamentoPrazos.FormaPagamentoId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
