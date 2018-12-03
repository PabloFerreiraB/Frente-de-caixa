using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class PermissoesNegociso
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Permissoes";

        string sqlDefault = "SELECT PermissoesId, UsuarioId, FormulariosId, Inserir, Alterar, Excluir, Visualizar FROM Permissoes ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Permissoes permissoes)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(permissoes));
        }

        public Boolean Excluir(Permissoes permissoes)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(permissoes));
        }

        public DataTable PesquisarPorGrupo(int grupoUsuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE UsuarioId = {1} ORDER BY FormulariosId", sqlDefault, grupoUsuarioId));
        }

        public Permissoes PesquisarPorFormulario(int usuarioId, int formulariosId)
        {
            DataTable dtPermissoes = new DataTable();
            dtPermissoes = conexao.Pesquisar(string.Format("{0} WHERE UsuarioId = {1} AND FormulariosId = {2}", sqlDefault, usuarioId, formulariosId));

            if (dtPermissoes != null && dtPermissoes.Rows.Count > 0)
            {
                var permissoes = new Permissoes()
                {
                    UsuarioId = (int)(dtPermissoes.Rows[0]["UsuarioId"]),
                    FormulariosId = (int)(dtPermissoes.Rows[0]["FormulariosId"]),
                    Inserir = (bool)(dtPermissoes.Rows[0]["Inserir"]),
                    Alterar = (bool)(dtPermissoes.Rows[0]["Alterar"]),
                    Excluir = (bool)(dtPermissoes.Rows[0]["Excluir"]),
                    Visualizar = (bool)(dtPermissoes.Rows[0]["Visualizar"])
                };

                return permissoes;
            }
            else
            {
                var permissoes = new Permissoes()
                {
                    Inserir = false,
                    Alterar = false,
                    Excluir = false,
                    Visualizar = false
                };
                return permissoes;
            }
        }

        #endregion

        #region Métodos privados 

        private List<SqlParametros> PreencheParametros(Permissoes permissoes)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("UsuarioId", permissoes.UsuarioId));
            lstParametros.Add(new SqlParametros("FormulariosId", permissoes.FormulariosId));
            lstParametros.Add(new SqlParametros("Inserir", permissoes.Inserir));
            lstParametros.Add(new SqlParametros("Alterar", permissoes.Alterar));
            lstParametros.Add(new SqlParametros("Excluir", permissoes.Excluir));
            lstParametros.Add(new SqlParametros("Visualizar", permissoes.Visualizar));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Permissoes permissoes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("UsuarioId", permissoes.UsuarioId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
