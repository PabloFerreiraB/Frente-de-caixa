using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class FuncionariosNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Funcionarios";

        string sqlDefault = "SELECT F.FuncionarioId,F.Nome,F.Sexo,F.Endereco,F.Numero,F.Bairro,F.CEP,C.CidadeId,C.Nome +'-'+C.Uf AS Cidade,F.Cpf,F.Rg,F.Telefone,F.Celular,F.Email,F.DataCadastro,F.Admissao,F.Cargo,F.Ativo,F.Vendedor,F.TituloEleitoral,F.CTPS,F.Pis,F.DataExpedicaoRg,F.Ferias,F.DecimoTerceiroSalario,F.Demissao,F.CBO,F.Encarregado,ISNULL(F.Representante,0) AS Representante,F.Usuario,F.Senha,F.Observacao,F.Salario FROM Funcionarios F LEFT JOIN Cidades C ON C.CidadeId=F.CidadeId ";

        string sqlCarregaGridFuncionarios = "SELECT FuncionarioId,Nome,Cargo,CASE WHEN Ativo='True' THEN 'Ativo' ELSE 'Inativo' END AS Ativo,Encarregado FROM Funcionarios ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Funcionarios funcionarios)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(funcionarios));
        }

        public Boolean Alterar(Funcionarios funcionarios)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(funcionarios), PreencheCondicoes(funcionarios));
        }

        public Boolean Excluir(Funcionarios funcionarios)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(funcionarios));
        }

        public string PesquisarSenhaVendedor(string vendedorId)
        {
            DataTable dtR = new DataTable();
            dtR = conexao.Pesquisar(string.Format("SELECT Senha FROM Funcionarios WHERE Vendedor = 'True' AND FuncionarioId = {0}", vendedorId));
            return dtR.Rows.Count > 0 ? dtR.Rows[0][0].ToString() : string.Empty;
        }

        public DataTable PesquisarPorCodigo(int funcionarioId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.FuncionarioId = {1}", sqlDefault, funcionarioId));
        }

        public DataTable PesquisarVendedores(string paramNome, bool paramVendedor)
        {
            return conexao.Pesquisar(string.Format("SELECT F.FuncionarioId, F.Nome, F.Telefone, F.Comissao, F.Senha FROM Funcionarios F WHERE {1} ((F.Nome LIKE '%{0}%') OR (F.CPF = '{0}')) ORDER BY F.Nome", paramNome, paramVendedor ? "F.Vendedor = 'True' AND " : string.Empty));
        }

        public DataTable PesquisarFuncionarios(string nome, bool somenteVendedor)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE ((F.Nome LIKE '%{1}%') OR (F.CPF = '{1}')) {2} ORDER BY F.Nome", sqlDefault, nome, somenteVendedor ? "AND Vendedor = 'True' " : ""));
        }

        public DataTable PesquisarFuncionariosSimplificado(string filtro, bool somenteVendedor, bool somenteRepresentante)
        {
            return conexao.Pesquisar(string.Format("SELECT F.FuncionarioId, F.Nome, F.Telefone, F.Comissao, F.Senha FROM Funcionarios F WHERE F.Ativo = 'True' AND ((F.Nome LIKE '%{0}%') OR (F.CPF = '{0}')) {1} {2} ORDER BY F.Nome ", filtro, somenteVendedor ? "AND Vendedor = 'True' " : "", somenteRepresentante ? "AND Representante = 'True'" : ""));
        }

        public DataTable PesquisarRepresentadas(string nome)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' AND F.Representante = 'True' AND ((F.Nome LIKE '%{1}%') OR (F.CPF = '{1}')) ORDER BY F.Nome", sqlDefault, nome));
        }

        public DataTable PesquisarPorTelefone(string telefone)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE (F.Telefone = '{1}' OR F.Telefone2 ='{1}') ORDER BY F.Nome", sqlDefault, telefone));
        }

        public DataTable PesquisarPorCPF(string CPF)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.CPF = '{1}' ORDER BY F.Nome", sqlDefault, CPF));
        }

        public DataTable PesquisarFuncionariosAtivos()
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Ativo = 'True' ORDER BY F.Nome", sqlDefault));
        }

        public DataTable PesquisarFuncionariosPorSenhaVendedor(string senha)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Vendedor = 'True' and F.Senha = '{1}'", sqlDefault, senha));
        }

        public int PesquisarSePodeVenderPrecoAbaixoMinimo(string senha)
        {
            DataTable dtaVendedor = new DataTable();
            dtaVendedor = conexao.Pesquisar(string.Format("{0} WHERE F.Administrador = 'True' AND  F.Vendedor = 'True' AND F.Senha = '{1}'", sqlDefault, senha));

            if (dtaVendedor.Rows.Count > 0 && dtaVendedor != null)
                return Convert.ToInt32(dtaVendedor.Rows[0]["FuncionarioId"].ToString());
            else
                return 0;
        }

        public DataTable PesquisarFuncionariosVendedor()
        {
            return conexao.Pesquisar(string.Format("{0} WHERE F.Vendedor = 'True' ORDER BY F.Nome", sqlDefault));
        }

        public DataTable PesquisarDadosFuncionarios(int mesAniversariantes, int mesFerais, int mesDecimoTerceiro, string status)
        {
            string strCmd = sqlDefault;

            if (!string.IsNullOrEmpty(status))
            {
                if (status.Equals("Ativo"))
                    strCmd += ValidarString(strCmd) + string.Format("F.Demissao IS NULL AND F.Ativo = 'True'", status);
                else if (status.Equals("Demitido"))
                    strCmd += ValidarString(strCmd) + string.Format("F.Demissao IS NOT NULL", status);
            }

            if (mesFerais > 0)
            {
                strCmd += ValidarString(strCmd) + string.Format("F.Ferias = '{0}'", mesFerais);
            }

            if (mesDecimoTerceiro > 0)
            {
                strCmd += ValidarString(strCmd) + string.Format("F.DecimoTerceiroSalario = '{0}'", mesDecimoTerceiro);
            }

            if (mesAniversariantes > 0)
            {
                strCmd += ValidarString(strCmd) + string.Format("DATEPART(mm, F.Nascimento) BETWEEN '{0}' AND '{0}'", mesAniversariantes);
            }

            return conexao.Pesquisar(string.Format("{0} ORDER BY F.Nome", strCmd));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public string PesquisarNomeFuncionarioVendedorId(int funcionarioId)
        {
            DataTable dtR = new DataTable();
            dtR = conexao.Pesquisar(string.Format("SELECT Nome FROM Funcionarios WHERE FuncionarioId = {0}", funcionarioId));

            return dtR.Rows.Count > 0 ? dtR.Rows[0][0].ToString() : string.Empty;
        }

        public decimal PesquisarPercentualComissaoMultCell(int funcionarioId)
        {
            return Convert.ToDecimal(conexao.Pesquisar("SELECT ISNULL(Comissao, 0) AS Comissao FROM Funcionarios WHERE FuncionarioId= " + funcionarioId).Rows[0][0]);
        }

        public bool ValidarSenhaFuncionarioSupervisor(string senha)
        {
            return Convert.ToInt32(conexao.Pesquisar(string.Format("SELECT COUNT(1) FROM Funcionarios WHERE Ativo = 'True' AND Senha = '{0}'", senha)).Rows[0][0]) > 0;
        }


        public DataTable CarregarGridFuncionarios(string filtro)
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY Nome", sqlCarregaGridFuncionarios));
        }



        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Funcionarios funcionarios)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Nome", funcionarios.Nome));
            lstParametros.Add(new SqlParametros("Sexo", funcionarios.Sexo));

            if (!funcionarios.Admissao.ToString().Contains("01/01/0001") && !funcionarios.Admissao.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("Admissao", funcionarios.Admissao.ToString("yyyy-MM-dd HH:mm:ss")));

            lstParametros.Add(new SqlParametros("Ativo", funcionarios.Ativo));
            lstParametros.Add(new SqlParametros("Cpf", funcionarios.Cpf));
            lstParametros.Add(new SqlParametros("Rg", funcionarios.Rg));
            lstParametros.Add(new SqlParametros("Cargo", funcionarios.Cargo));
            lstParametros.Add(new SqlParametros("Telefone", funcionarios.Telefone));
            lstParametros.Add(new SqlParametros("Celular", funcionarios.Celular));
            lstParametros.Add(new SqlParametros("Email", funcionarios.Email));

            if (!funcionarios.DataCadastro.ToString().Contains("01/01/0001") && !funcionarios.DataCadastro.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataCadastro", funcionarios.DataCadastro.ToString("yyyy-MM-dd HH:mm:ss")));

            lstParametros.Add(new SqlParametros("Cep", funcionarios.Cep));
            lstParametros.Add(new SqlParametros("Endereco", funcionarios.Endereco));
            lstParametros.Add(new SqlParametros("Numero", funcionarios.Numero));
            lstParametros.Add(new SqlParametros("Bairro", funcionarios.Bairro));

            if (funcionarios.CidadeId > 0)
                lstParametros.Add(new SqlParametros("CidadeId", funcionarios.CidadeId));

            lstParametros.Add(new SqlParametros("Vendedor", funcionarios.Vendedor));
            lstParametros.Add(new SqlParametros("Representante", funcionarios.Representante));
            lstParametros.Add(new SqlParametros("Usuario", funcionarios.Usuario));
            lstParametros.Add(new SqlParametros("Senha", funcionarios.Senha));
            lstParametros.Add(new SqlParametros("Observacao", funcionarios.Observacao));
            lstParametros.Add(new SqlParametros("Salario", funcionarios.Salario.ToString().Replace(',', '.')));


            lstParametros.Add(new SqlParametros("TituloEleitoral", funcionarios.TituloEleitoral));
            lstParametros.Add(new SqlParametros("CTPS", funcionarios.CTPS));
            lstParametros.Add(new SqlParametros("Pis", funcionarios.Pis));

            if (!funcionarios.DataExpedicaoRg.ToString().Contains("01/01/0001") && !funcionarios.DataExpedicaoRg.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataExpedicaoRg", funcionarios.DataExpedicaoRg.ToString("yyyy-MM-dd HH:mm:ss")));

            lstParametros.Add(new SqlParametros("Ferias", funcionarios.Ferias));
            lstParametros.Add(new SqlParametros("DecimoTerceiroSalario", funcionarios.DecimoTerceiroSalario));

            if (!funcionarios.Demissao.ToString().Contains("01/01/0001") && !funcionarios.Demissao.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("Demissao", funcionarios.Demissao.ToString("yyyy-MM-dd HH:mm:ss")));

            lstParametros.Add(new SqlParametros("CBO", funcionarios.CBO));
            lstParametros.Add(new SqlParametros("Encarregado", funcionarios.Encarregado));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Funcionarios funcionarios)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FuncionarioId", funcionarios.FuncionarioId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
