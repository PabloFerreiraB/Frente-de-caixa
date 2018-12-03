using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class FormulariosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Formularios";

        string sqlDefault = "SELECT FormulariosId, Nome FROM Formularios ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Formularios formularios)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(formularios));
        }

        public Boolean Alterar(Formularios formularios)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(formularios), PreencheCondicoes(formularios));
        }

        public Boolean Excluir(Formularios formularios)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(formularios));
        }

        public DataTable PesquisarPorCodigo(int formulariosId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE FormulariosId = {1}", sqlDefault, formulariosId));
        }

        public DataTable PesquisarPorDescricao(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Nome LIKE '%{1}%' ORDER BY FormulariosId ", sqlDefault, nome));
        }

        public DataTable CarregarGridFormularios()
        {
            return conexao.Pesquisar(string.Format("{0} ", sqlDefault));
        }


        #endregion 

        #region Métodos Privados

        private List<SqlParametros> PreencheParametros(Formularios formularios)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Nome", formularios.Nome));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Formularios formularios)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FormulariosId", formularios.FormulariosId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
