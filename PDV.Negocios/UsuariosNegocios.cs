using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class UsuariosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Usuarios";

        string sqlDefault = "SELECT UsuarioId, Nome, CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo, NomeLogin, Senha, Perfil, DataCadastro FROM Usuarios ";

        string sqlDataSource = "SELECT UsuarioId, Nome, CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo, NomeLogin, Senha, Perfil, DataCadastro FROM Usuarios ";

        #endregion

        #region Métodos Publicos 

        public Boolean Inserir(Usuarios usuarios)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(usuarios));
        }

        public Boolean Alterar(Usuarios usuarios)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(usuarios), PreencheCondicoes(usuarios));
        }

        public Boolean Excluir(Usuarios usuarios)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(usuarios));
        }

        public DataTable PesquisarPorCodigo(int usuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE UsuarioId = {1}", sqlDefault, usuarioId));
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Nome LIKE '%{1}%' ORDER BY Nome", sqlDefault, nome));
        }

        public DataTable PesquisarPorUsuario(string nomeLogin)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE NomeLogin = '{1}' ORDER BY NomeLogin", sqlDefault, nomeLogin));
        }

        public int PesquisarUsuarioSenha(string senha)
        {
            DataTable dtUsuario = new DataTable();
            dtUsuario = conexao.Pesquisar(string.Format("{0} WHERE Ativo = 'True' AND Senha = '{1}'", sqlDefault, senha));

            if (dtUsuario.Rows.Count > 0 && dtUsuario != null)
            {
                return Convert.ToInt32(dtUsuario.Rows[0]["UsuarioId"].ToString());
            }
            else
            {
                return 0;
            }
        }

        public DataTable PesquisarUsuarioAtivos()
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Ativo = 'True'", sqlDefault));
        }

        public DataTable PesquisarPorFormulario(int Formulario)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Formulario = {1}", sqlDefault, Formulario));
        }

        public DataTable PesquisarPorPemissaoUsuarios(int usuarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE UsuarioId = {1} ORDER BY Formulario", sqlDefault, usuarioId));
        }

        public DataTable CarregarGridUsuario()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY Nome", sqlDataSource));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Usuarios usuario)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Nome", usuario.Nome));
            lstParametros.Add(new SqlParametros("Ativo", usuario.Ativo));
            lstParametros.Add(new SqlParametros("NomeLogin", usuario.NomeLogin));
            lstParametros.Add(new SqlParametros("Senha", usuario.Senha));
            lstParametros.Add(new SqlParametros("Perfil", usuario.Perfil));
            lstParametros.Add(new SqlParametros("DataCadastro", usuario.DataCadastro.ToString("yyyy-MM-dd HH':'mm':'ss")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Usuarios usuario)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("UsuarioId", usuario.UsuarioId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
