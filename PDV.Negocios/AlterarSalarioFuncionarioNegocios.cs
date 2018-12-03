using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class AlterarSalarioFuncionarioNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "AlterarSalarioFuncionario";

        string sqlDefault = "SELECT A.AlterarSalarioFuncionarioId, A.FuncionarioId, A.DataHora, A.Valor, F.Nome AS Funcionario FROM AlterarSalarioFuncionario A JOIN Funcionarios F ON F.FuncionarioId = A.FuncionarioId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(AlterarSalarioFuncionario alterarSalarioFuncionario)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(alterarSalarioFuncionario));
        }

        public Boolean Alterar(AlterarSalarioFuncionario alterarSalarioFuncionario)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(alterarSalarioFuncionario), PreencheCondicoes(alterarSalarioFuncionario));
        }

        public Boolean Excluir(AlterarSalarioFuncionario alterarSalarioFuncionario)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(alterarSalarioFuncionario));
        }

        public DataTable PesquisarAlteracoesSalariais(int funcionarioId, DateTime dataInicial, DateTime dataFinal)
        {
            if (funcionarioId > 0)
                return conexao.Pesquisar(string.Format("{0} WHERE A.FuncionarioId = {1} AND A.DataHora BETWEEN '{2} 00:00' AND '{3} 23:59' ORDER BY F.Funcionario", sqlDefault, funcionarioId, dataInicial.ToString("yyyy-MM-dd"), dataFinal.ToString("yyyy-MM-dd")));
            else
                return conexao.Pesquisar(string.Format("{0} WHERE A.DataHora BETWEEN '{1} 00:00' AND '{2} 23:59' ORDER BY F.Funcionario", sqlDefault, dataInicial.ToString("yyyy-MM-dd"), dataFinal.ToString("yyyy-MM-dd")));
        }

        #endregion 

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(AlterarSalarioFuncionario alterarSalarioFuncionario)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("FuncionarioId", alterarSalarioFuncionario.FuncionarioId));
            lstParametros.Add(new SqlParametros("DataHora", alterarSalarioFuncionario.DataHora.ToString("yyyy-MM-dd HH:mm")));
            lstParametros.Add(new SqlParametros("Valor", alterarSalarioFuncionario.Valor.ToString().Replace(".", "").Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(AlterarSalarioFuncionario alterarSalarioFuncionario)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("FuncionarioId", alterarSalarioFuncionario.FuncionarioId));

            return lstParametrosCondicionais;

        }

        #endregion
    }
}
