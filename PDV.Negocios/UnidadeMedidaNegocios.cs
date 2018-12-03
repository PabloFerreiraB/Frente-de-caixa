using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class UnidadeMedidaNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "UnidadeMedida";

        string sqlDefault = "SELECT UnidadeMedidaId, Descricao FROM UnidadeMedida ";

        #endregion

        #region Métodos Publicos 

        public Boolean Inserir(UnidadeMedida unidadeMedida)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(unidadeMedida));
        }

        public Boolean Alterar(UnidadeMedida unidadeMedida)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(unidadeMedida), PreencheCondicoes(unidadeMedida));
        }

        public Boolean Excluir(UnidadeMedida unidadeMedida)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(unidadeMedida));
        }

        public DataTable PesquisarPorCodigo(int usuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE UnidadeMedidaId = {1}", sqlDefault, usuarioId));
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Descricao LIKE '%{1}%' ORDER BY UnidadeMedidaId ", sqlDefault, nome));
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY UnidadeMedidaId", sqlDefault));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(UnidadeMedida unidadeMedida)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Descricao", unidadeMedida.Descricao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(UnidadeMedida unidadeMedida)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("UnidadeMedidaId", unidadeMedida.UnidadeMedidaId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
