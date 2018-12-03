using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class SaldoCaixaNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "SaldoCaixa";

        string sqlDefault = "SELECT SaldoCaixaId,MovimentacaoVendasId,Valor FROM SaldoCaixa ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(SaldoCaixa saldoCaixa)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(saldoCaixa));
        }

        public Boolean Alterar(SaldoCaixa saldoCaixa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(saldoCaixa), PreencheCondicoes(saldoCaixa));
        }

        public Boolean Excluir(SaldoCaixa saldoCaixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(saldoCaixa));
        }

        public DataTable PesquisarPorCodigo(int saldoCaixaId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE SaldoCaixaId = {1}", sqlDefault, saldoCaixaId));
        }

        public Boolean ExcluirMovimento(SaldoCaixa saldoCaixa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(saldoCaixa));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(SaldoCaixa saldoCaixa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("MovimentacaoCaixaId", saldoCaixa.MovimentacaoCaixaId));
            lstParametros.Add(new SqlParametros("Valor", saldoCaixa.Valor.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(SaldoCaixa saldoCaixa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("MovimentacaoCaixaId", saldoCaixa.MovimentacaoCaixaId));

            return lstParametrosCondicionais;
        }

        #endregion
    }
}
