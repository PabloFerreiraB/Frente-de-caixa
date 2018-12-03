using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class TributacaoFiscalEstadosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion 

        #region Variáveis Default

        string nomeTabela = "TributacaoFiscalEstados";

        string sqlDefault = "SELECT T.TributacaoFiscalEstadosId,T.OperacaoId,T.UF,T.OperacaoUFSelecionado,C.Nome AS NomeEstado,C.Uf FROM TributacaoFiscalEstados T LEFT JOIN Cidades C ON C.UF =T.UF ";

        #endregion 

        #region Métodos Publicos

        public Boolean Inserir(TributacaoFiscalEstados tributacaoFiscalEstados)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(tributacaoFiscalEstados));
        }

        public Boolean Alterar(TributacaoFiscalEstados tributacaoFiscalEstados)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(tributacaoFiscalEstados), PreencheCondicoes(tributacaoFiscalEstados));
        }

        public Boolean Excluir(TributacaoFiscalEstados tributacaoFiscalEstados)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(tributacaoFiscalEstados));
        }

        public DataTable PesquisarPorCodigo(int tributacaoFiscalEstadosId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE T.TributacaoFiscalEstadosId = {1}", sqlDefault, tributacaoFiscalEstadosId));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(TributacaoFiscalEstados tributacaoFiscalEstados)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("OperacaoId", tributacaoFiscalEstados.OperacaoId));
            lstParametros.Add(new SqlParametros("UF", tributacaoFiscalEstados.UF));
            lstParametros.Add(new SqlParametros("OperacaoUFSelecionado", tributacaoFiscalEstados.OperacaoUFSelecionado));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(TributacaoFiscalEstados tributacaoFiscalEstados)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("TributacaoFiscalEstadosId", tributacaoFiscalEstados.TributacaoFiscalEstadosId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
