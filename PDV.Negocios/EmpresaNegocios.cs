using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class EmpresaNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion 

        #region Variáveis Default

        string nomeTabela = "Empresa";

        string sqlDefault = "SELECT E.EmpresaId,E.RazaoSocial,E.NomeFantasia,E.Telefone,E.Celular,E.Cep,E.Endereco,E.Numero,E.Bairro,E.CidadeId,C.Nome AS Cidade,E.Cnpj,E.IE,E.IM,E.SiteEmpresa,E.Email,E.RegimeTributario,E.TipoAtividade,E.Csosn,E.NomeC,E.CpfC,E.CRCC,E.TelefoneC,E.CelularC,E.EmailC,E.CidadeCId, E.Logotipo FROM Empresa E LEFT JOIN Cidades C ON C.CidadeId=E.CidadeId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Empresa empresa)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(empresa));
        }

        public Boolean Alterar(Empresa empresa)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(empresa), PreencheCondicoes(empresa));
        }

        public Boolean Excluir(Empresa empresa)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(empresa));
        }

        public DataTable PesquisarPorCodigo(int empresaId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE E.EmpresaId = {1}", sqlDefault, empresaId));
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE E.RazaoSocial LIKE '%{1}%' ORDER BY RazaoSocial", sqlDefault, nome));
        }

        public DataTable PesquisarEmpresa()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY E.RazaoSocial", sqlDefault));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Empresa empresa)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("RazaoSocial", empresa.RazaoSocial));
            lstParametros.Add(new SqlParametros("NomeFantasia", empresa.NomeFantasia));
            lstParametros.Add(new SqlParametros("Telefone", empresa.Telefone));
            lstParametros.Add(new SqlParametros("Celular", empresa.Celular));
            lstParametros.Add(new SqlParametros("Cep", empresa.Cep));
            lstParametros.Add(new SqlParametros("Endereco", empresa.Endereco));
            lstParametros.Add(new SqlParametros("Bairro", empresa.Bairro));
            lstParametros.Add(new SqlParametros("Numero", empresa.Numero));
            if (empresa.CidadeId > 0)
                lstParametros.Add(new SqlParametros("CidadeId", empresa.CidadeId));
            lstParametros.Add(new SqlParametros("Cnpj", empresa.Cnpj));
            lstParametros.Add(new SqlParametros("IE", empresa.IE));
            lstParametros.Add(new SqlParametros("IM", empresa.IM));
            lstParametros.Add(new SqlParametros("SiteEmpresa", empresa.SiteEmpresa));
            lstParametros.Add(new SqlParametros("Email", empresa.Email));
            lstParametros.Add(new SqlParametros("RegimeTributario", empresa.RegimeTributario));
            lstParametros.Add(new SqlParametros("TipoAtividade", empresa.TipoAtividade));
            lstParametros.Add(new SqlParametros("Csosn", empresa.Csosn));

            lstParametros.Add(new SqlParametros("NomeC", empresa.NomeC));
            lstParametros.Add(new SqlParametros("CpfC", empresa.CpfC));
            lstParametros.Add(new SqlParametros("CRCC", empresa.CRCC));
            lstParametros.Add(new SqlParametros("TelefoneC", empresa.TelefoneC));
            lstParametros.Add(new SqlParametros("CelularC", empresa.CelularC));
            lstParametros.Add(new SqlParametros("EmailC", empresa.EmailC));
            if (empresa.CidadeCId > 0)
                lstParametros.Add(new SqlParametros("CidadeCId ", empresa.CidadeCId));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Empresa empresa)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("EmpresaId", empresa.EmpresaId));

            return lstParametrosCondicionais;
        }

        #endregion 

    }
}
