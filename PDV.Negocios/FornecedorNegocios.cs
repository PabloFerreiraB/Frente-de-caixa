using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class FornecedorNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "fornecedor";

        string sqlDefault = "SELECT F.FornecedorId,F.Nome,F.NomeFantasia,F.Ativo,F.TipoPessoa,F.CpfCnpj,F.RgIE,F.Telefone,F.Celular,F.Email,F.Contato,F.Cep,F.CidadeId,C.Nome +'-'+C.Uf AS Cidade,F.Endereco,F.Numero,F.Bairro,F.SiteFornecedor,F.Observacao,F.DataCadastro FROM Fornecedor F LEFT JOIN Cidades C ON C.CidadeId =F.CidadeId ";

        string sqlDataSource = "SELECT F.FornecedorId, F.Nome, F.CpfCnpj, CASE WHEN F.Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo, F.Telefone, F.Celular, C.Nome + '-' + C.UF AS Cidade FROM Fornecedor F LEFT JOIN Cidades C ON C.CidadeId = F.CidadeId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Fornecedor fornecedor)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(fornecedor));
        }

        public Boolean Alterar(Fornecedor fornecedor)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(fornecedor), PreencheCondicoes(fornecedor));
        }

        public Boolean Excluir(Fornecedor fornecedor)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(fornecedor));
        }

        public bool PesquisarCpfCnpjCadastrado(string cpfCnpj)
        {
            DataTable dtCPFFornecedor = conexao.Pesquisar(string.Format("{0} WHERE CpfCnpj = '{1}'", sqlDefault, cpfCnpj));

            return dtCPFFornecedor.Rows.Count > 1;
        }

        public DataTable PesquisarPorCodigo(int fornecedorId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.FornecedorId = {1}", sqlDefault, fornecedorId));
        }

        public DataTable PesquisarPorNome(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND ((Nome LIKE '%{1}%') OR (NomeFantasia LIKE '%{1}%')) ORDER BY Nome", sqlDefault, nome));
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY F.FornecedorId", sqlDataSource));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Fornecedor fornecedor)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Nome", fornecedor.Nome));
            lstParametros.Add(new SqlParametros("NomeFantasia", fornecedor.NomeFantasia));
            lstParametros.Add(new SqlParametros("Ativo", fornecedor.Ativo));
            lstParametros.Add(new SqlParametros("TipoPessoa", fornecedor.TipoPessoa));
            lstParametros.Add(new SqlParametros("CpfCnpj", fornecedor.CpfCnpj));
            lstParametros.Add(new SqlParametros("RgIE", fornecedor.RgIE));
            lstParametros.Add(new SqlParametros("Telefone", fornecedor.Telefone));
            lstParametros.Add(new SqlParametros("Celular", fornecedor.Celular));
            lstParametros.Add(new SqlParametros("Email", fornecedor.Email));
            lstParametros.Add(new SqlParametros("Contato", fornecedor.Contato));
            lstParametros.Add(new SqlParametros("Cep", fornecedor.Cep));

            if (fornecedor.CidadeId > 0)
                lstParametros.Add(new SqlParametros("CidadeId", fornecedor.CidadeId));

            lstParametros.Add(new SqlParametros("Endereco", fornecedor.Endereco));
            lstParametros.Add(new SqlParametros("Numero", fornecedor.Numero));
            lstParametros.Add(new SqlParametros("Bairro", fornecedor.Bairro));
            lstParametros.Add(new SqlParametros("SiteFornecedor", fornecedor.SiteFornecedor));
            lstParametros.Add(new SqlParametros("Observacao", fornecedor.Observacao));
            lstParametros.Add(new SqlParametros("DataCadastro", fornecedor.DataCadastro.ToString("yyyy-MM-dd HH':'mm':'ss")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Fornecedor fornecedor)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FornecedorId", fornecedor.FornecedorId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
