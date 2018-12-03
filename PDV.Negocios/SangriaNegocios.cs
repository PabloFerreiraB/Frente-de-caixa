using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class SangriaNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Sangria";

        string sqlDefault = "SELECT SangriaId,CaixaId,S.UsuarioId,U.NomeLogin AS Usuario,ValorCaixa,ValorSangria,ValorAposSangria,DataHora,CASE WHEN Tipo='1' THEN 'Sangria' ELSE 'Suprimento' END AS Tipo,Observacao FROM Sangria S LEFT JOIN Usuarios U ON U.UsuarioId =S.UsuarioId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Sangria sangria)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(sangria));
        }

        public Boolean Alterar(Sangria sangria)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(sangria), PreencheCondicoes(sangria));
        }

        public Boolean Excluir(Sangria sangria)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(sangria));
        }

        public DataTable PesquisarPorCodigo(int caixaId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE CaixaId = {1}", sqlDefault, caixaId));
        }

        public DataTable CarregarGrid(DateTime dataInicio, DateTime dataFim)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE DataHora BETWEEN '{1} 00:00:00' AND '{2} 23:59:59' ORDER BY DataHora DESC", sqlDefault, dataInicio.ToString("yyyy-MM-dd"), dataFim.ToString("yyyy-MM-dd")));
        }

        public DataTable PesquisarMovimentosCaixa(DateTime? abertura, DateTime? fechamento, int caixaId)
        {
            string sql = sqlDefault; ;

            if (caixaId > 0 && abertura != null)
            {
                sql += ValidarString(sql) + string.Format("DataHora between '{0}' and '{1}'", abertura.Value.ToString("yyyy-MM-dd 00:00:00"), fechamento.Value.ToString("yyyy-MM-dd 23:59:59"));
            }

            sql += " ORDER BY DataHora";

            return conexao.Pesquisar(sql);
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        #endregion 

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Sangria sangria)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (sangria.CaixaId > 0)
                lstParametros.Add(new SqlParametros("CaixaId", sangria.CaixaId));
            if (sangria.UsuarioId > 0)
                lstParametros.Add(new SqlParametros("UsuarioId", sangria.UsuarioId));
            lstParametros.Add(new SqlParametros("ValorCaixa", sangria.ValorCaixa.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorSangria", sangria.ValorSangria.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorAposSangria", sangria.ValorAposSangria.ToString().Replace(".", "").Replace(",", ".")));
            lstParametros.Add(new SqlParametros("DataHora", sangria.DataHora.ToString("yyyy-MM-dd HH:mm:ss")));
            lstParametros.Add(new SqlParametros("Tipo", sangria.Tipo));
            lstParametros.Add(new SqlParametros("Observacao", sangria.Observacao));

            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Sangria sangria)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("SangriaId", sangria.SangriaId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
