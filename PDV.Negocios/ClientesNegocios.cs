using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class ClientesNegocios
    {
        #region Instância conexão

        Conexao conexao = new Conexao();

        #endregion

        #region Tabela / Select padrão 

        string nomeTabela = "Clientes";

        string sqlDefault = "SELECT [ClientesId],[Nome],[Ativo],[Sexo],[EstadoCivil],[ApelidoFantasia],[Nacionalidade],[Naturalidade],[Tipo],[CpfCnpj],[RgIE],[Nascimento],[DataCadastro],[Cep],[Endereco],[Numero],[Complemento],[CidadeId],[Bairro],[Telefone],[Celular],[Email],[LimiteCredito],[Observacao],[ImagemCliente] FROM [dbo].[Clientes] ";

        string sqlDataSource = "SELECT Cli.ClientesId, Cli.Nome, Cli.ApelidoFantasia, Cli.CpfCnpj, Cli.Telefone, Cli.Celular, C.Nome + '-' + C.UF AS Cidade FROM Clientes Cli LEFT JOIN Cidades C ON C.CidadeId = Cli.CidadeId ";

        string sqlDataSourcePDV = "SELECT Cli.ClientesId, Cli.Nome, Cli.CpfCnpj, CASE WHEN Cli.Sexo = 0 THEN 'Masculino' ELSE 'Feminino' END AS Sexo,  C.Nome + '-' + C.UF AS Cidade FROM Clientes Cli LEFT JOIN Cidades C ON C.CidadeId = Cli.CidadeId ";
   
        #endregion

        #region Métodos publicos

        public Boolean Inserir(Clientes clientes)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(clientes));
        }

        public Boolean Alterar(Clientes clientes)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(clientes), PreencheCondicoes(clientes));
        }

        public Boolean Excluir(Clientes clientes)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(clientes));
        }


        public DataTable PesquisarPorCodigo(int clienteId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE ClientesId = {1}", sqlDefault, clienteId));
        }

        public bool PesquisarCPFouCNPJCadastrado(string cpfCnpj)
        {
            DataTable dtCliente = conexao.Pesquisar(string.Format("{0} WHERE CpfCnpj = '{1}'", sqlDefault, cpfCnpj));

            return dtCliente.Rows.Count > 0;
        }

        public string VerificaCPFouCNPJ(int clientesId)
        {
            return Convert.ToString(conexao.Pesquisar("SELECT CpfCnpj FROM Clientes WHERE ClientesId =" + clientesId).Rows[0][0]);
        }

        public string PesquisarObservacaoCliente(int clientesId)
        {
            return Convert.ToString(conexao.Pesquisar("SELECT Observacao FROM Clientes WHERE ClientesId =" + clientesId).Rows[0][0]);
        }

        public DataTable CarregarGrid()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY Cli.ClientesId ", sqlDataSource));
        }

        public DataTable CarregarGridPDV()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY Cli.ClientesId ", sqlDataSourcePDV));
        }

        #endregion

        #region Métodos privados

        private List<SqlParametros> PreencheParametros(Clientes clientes)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Nome", clientes.Nome));
            lstParametros.Add(new SqlParametros("Ativo", clientes.Ativo));
            lstParametros.Add(new SqlParametros("Sexo", clientes.Sexo));
            lstParametros.Add(new SqlParametros("EstadoCivil", clientes.EstadoCivil));
            lstParametros.Add(new SqlParametros("ApelidoFantasia", clientes.ApelidoFantasia));
            lstParametros.Add(new SqlParametros("Nacionalidade", clientes.Nacionalidade));
            lstParametros.Add(new SqlParametros("Naturalidade", clientes.Naturalidade));
            lstParametros.Add(new SqlParametros("Tipo", clientes.Tipo));
            lstParametros.Add(new SqlParametros("CpfCnpj", clientes.CpfCnpj));
            lstParametros.Add(new SqlParametros("RgIE", clientes.RgIE));

            if (!clientes.Nascimento.ToString().Contains("01/01/0001") && !clientes.Nascimento.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("Nascimento", clientes.Nascimento.ToString("yyyy-MM-dd HH:mm:ss")));

            if (!clientes.DataCadastro.ToString().Contains("01/01/0001") && !clientes.DataCadastro.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataCadastro", clientes.DataCadastro.ToString("yyyy-MM-dd HH:mm:ss")));

            lstParametros.Add(new SqlParametros("Cep", clientes.Cep));
            lstParametros.Add(new SqlParametros("Endereco", clientes.Endereco));
            lstParametros.Add(new SqlParametros("Numero", clientes.Numero));
            lstParametros.Add(new SqlParametros("Complemento", clientes.Complemento));

            if (clientes.CidadeId > 0)
                lstParametros.Add(new SqlParametros("CidadeId", clientes.CidadeId));

            lstParametros.Add(new SqlParametros("Bairro", clientes.Bairro));
            lstParametros.Add(new SqlParametros("Telefone", clientes.Telefone));
            lstParametros.Add(new SqlParametros("Celular", clientes.Celular));
            lstParametros.Add(new SqlParametros("Email", clientes.Email));
            lstParametros.Add(new SqlParametros("LimiteCredito", clientes.LimiteCredito.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Observacao", clientes.Observacao));

            if (clientes.ImagemCliente != null)
                lstParametros.Add(new SqlParametros("ImagemCliente", clientes.ImagemCliente));
            else
                lstParametros.Add(new SqlParametros("ImagemCliente", string.Empty));


            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Clientes clientes)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("ClientesId", clientes.ClientesId));

            return lstParametrosCondicionais;
        }




        #endregion
    }
}
