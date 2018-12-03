using PDV.AcessoBancoDados;
using System.Data;

namespace PDV.Negocios
{
    public class CidadesNegocios
    {
        #region Instância conexão

        Conexao conexao = new Conexao();

        #endregion

        #region Tabela / Select padrão 

        string nomeTabela = "Cidades";

        string sqlDefault = "SELECT CidadeId, CodigoIBGE, Nome, UF FROM Cidades ";

        string sqlDataSource = "SELECT CidadeId, CodigoIBGE, Nome, UF FROM Cidades ORDER BY Nome ";

        string SqlDataSourceEstados = "SELECT EstadoId,NomeEstado,Uf FROM Estados ";

        #endregion

        #region Métodos Publicos

        public DataTable PesquisarPorCodigo(int cidadeId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE CidadeId = {1}", sqlDefault, cidadeId));
        }

        public DataTable PesquisarDataSource()
        {
            return conexao.Pesquisar(string.Format("{0}", sqlDataSource));
        }

        /// <summary>
        /// ESTADOS
        /// </summary>
        /// <param name="nomeEstado"></param>
        /// <returns></returns>
        public DataTable PesquisarDataSourceEstados()
        {
            return conexao.Pesquisar(string.Format("{0} ORDER BY NomeEstado", SqlDataSourceEstados));
        }


        #endregion

    }
}
