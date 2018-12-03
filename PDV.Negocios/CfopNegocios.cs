using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class CfopNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "CFOP";

        string sqlDefault = "SELECT CfopId, Codigo, Grupo, Descricao, Aplica FROM Cfop ";

        #endregion

        #region Métodos Publicos

        public DataTable PesquisarDataSourcePorCFOPId(int codigo)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE Codigo = {1}", sqlDefault, codigo));
        }

        public Cfop PesquisarPorCFOPId(int cfopId)
        {
            return PreencheObjInfo(conexao.Pesquisar(string.Format("{0} WHERE CfopId = {1}", sqlDefault, cfopId)).Rows[0]);
        }

        public DataTable PesquisarCFOP(string descricao, string aplicacao, string tipo)
        {
            if (string.IsNullOrEmpty(aplicacao))
            {
                if (tipo.Equals("E")) //entrada
                    return conexao.Pesquisar(string.Format("{0} WHERE (Codigo LIKE '{1}' OR Descricao LIKE '%{1}%') AND SUBSTRING(Codigo, 1, 1) IN (1, 2, 3) ORDER BY Codigo", sqlDefault, descricao));
                else if (tipo.Equals("S")) //saida
                    return conexao.Pesquisar(string.Format("{0} WHERE (Codigo LIKE '{1}' OR Descricao LIKE '%{1}%') AND SUBSTRING(Codigo, 1, 1) IN (5, 6, 7) ORDER BY Codigo", sqlDefault, descricao));
                else //ambos
                    return conexao.Pesquisar(string.Format("{0} WHERE (Codigo LIKE '{1}' OR Descricao LIKE '%{1}%') ORDER BY Codigo", sqlDefault, descricao));
            }
            else if (aplicacao.Length == 1)
            {
                return conexao.Pesquisar(string.Format("{0} WHERE (Codigo LIKE '{1}' OR Descricao LIKE '%{1}%') AND SUBSTRING(Codigo, 1, 1) LIKE {2} ORDER BY Codigo", sqlDefault, descricao, aplicacao));
            }
            else
            {
                return conexao.Pesquisar(string.Format("{0} WHERE (Codigo LIKE '{1}' OR Descricao LIKE '%{1}%') AND (SUBSTRING(Codigo, 1, 1) LIKE {2} OR SUBSTRING(Codigo, 1, 1) LIKE {3}) ORDER BY Codigo", sqlDefault, descricao, aplicacao[0], aplicacao[1]));
            }
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

        private List<SqlParametros> PreencheParametros(Cfop cfop)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            lstParametros.Add(new SqlParametros("Codigo", cfop.Codigo));
            lstParametros.Add(new SqlParametros("Grupo", cfop.Grupo));
            lstParametros.Add(new SqlParametros("Descricao", cfop.Descricao));
            lstParametros.Add(new SqlParametros("Aplica", cfop.Aplica));

            return lstParametros;

        }

        private Cfop PreencheObjInfo(DataRow row)
        {
            Cfop cfop = new Cfop();

            cfop.CfopId = Convert.ToInt16(row["CfopId"]);
            cfop.Codigo = row["Codigo"].ToString();
            cfop.Grupo = Convert.ToBoolean(row["Grupo"]);
            cfop.Descricao = row["Descricao"].ToString();
            cfop.Aplica = row["Aplica"].ToString();

            return cfop;
        }

        private List<Cfop> PreencheLista(DataTable dt)
        {
            List<Cfop> listacfop = new List<Cfop>();
            foreach (DataRow r in dt.Rows)
            {
                Cfop cfop = PreencheObjInfo(r);
                listacfop.Add(cfop);
            }
            return listacfop;
        }

        #endregion

    }
}
