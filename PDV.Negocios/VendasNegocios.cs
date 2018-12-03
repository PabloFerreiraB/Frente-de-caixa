using PDV.AcessoBancoDados;
using PDV.ObjetoTransferencia;
using PFSoftwares.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.Data;

namespace PDV.Negocios
{
    public class VendasNegocios
    {
        #region Instancias

        Conexao conexao = new Conexao();

        #endregion

        #region Variáveis Default

        string nomeTabela = "Vendas";

        string sqlDefault = "SELECT V.VendasId,V.CaixaId,V.UsuarioId,V.ClientesId,V.ProdutosId,V.FormaPagamentoId,FP.Descricao AS DescricaoFormaPagamento,V.StatusId,V.FornecedorId,V.FuncionarioId,FU.Nome AS NomeFuncionario,FU.Senha AS SenhaFuncionario,V.NumeroDocumento,V.DataEmissao,V.DataVendaFinalizada,V.Cpf,V.Cfop,V.Subtotal,V.Total,V.Desconto,V.LucroVenda,V.CustoVenda,ISNULL(V.Troco,0) AS Troco,V.Tipo,CASE WHEN V.StatusVenda ='Cancelado' THEN 'Cancelado' ELSE 'Emitido' END AS StatusVenda,ISNULL(S.Descricao,'Emitido') AS DescricaoStatus,V.BaseCalculoIcms,V.BaseCalculoIcmsST,V.BaseCalculoPis,V.BaseCalculoCofins,V.ValorIcms,V.ValorIcmsST,V.ValorIpi,V.ValorPis,V.ValorCofins,V.Serie,V.Observacao,V.CupomFiscal,V.NumeroCupomFiscal,V.PercentualLucroVenda,V.DescricaoFormaPagamento,V.SaldoClienteUtilizado,V.VendaNumeroCFe,V.VendaChaveAcessoCFe,V.VendaNumeroSerieSatCFe,V.VendaNumeroCancelamentoCFe,V.VendaAssinaturaQRCODECFe,V.VendaChaveAcessoCancelamentoCFe,V.VendaDataHoraCancelamentoCFe,V.VendaQRCODECancelamentoCFe,V.VendaDataHoraAutorizacao,V.VendaNFCeNumero,V.VendaNFCeAmbiente,V.VendaNFCeSerie,V.VendaNFCeChaveAcesso,V.VendaNFCeNumeroRecibo,V.VendaNFCeDataHoraAutorizacao,V.VendaNFCeProtocoloAutorizacao,V.VendaNFCeDataHoraCancelamento,V.VendaNFCeProtocoloCancelamento,V.VendaNFCeQrCode,V.VendaSpedIcmsBaseCalculo,V.VendaSpedIcmsValor,V.VendaSpedIpiBaseCalculo,V.VendaSpedIpiValor,V.VendaSpedPisBaseCalculo,V.VendaSpedPisValor,V.VendaSpedCofinsBaseCalculo,V.VendaSpedCofinsValor FROM Vendas V LEFT JOIN Clientes C ON C.ClientesId =V.ClientesId LEFT JOIN Fornecedor F ON F.FornecedorId =V.FornecedorId LEFT JOIN Funcionarios FU ON FU.FuncionarioId =V.FuncionarioId LEFT JOIN Caixa CA ON CA.CaixaId =V.CaixaId LEFT JOIN Usuarios U ON U.UsuarioId =V.UsuarioId LEFT JOIN Produtos P ON P.ProdutosId =V.ProdutosId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =V.FormaPagamentoId LEFT JOIN Cidades CI ON CI.CidadeId =V.CidadeId LEFT JOIN StatusOperacoes S ON S.StatusId =V.StatusId ";

        string sqlDefaultVendasClientes = "SELECT V.NumeroDocumento,V.VendasId,V.DataEmissao,V.Serie,V.DataVendaFinalizada,V.ClientesId,C.Nome,C.ApelidoFantasia,C.CpfCnpj,C.RgIE,C.Cep,C.Endereco,C.Numero,C.Complemento,CI.CidadeId,CI.Nome AS Cidade,CI.UF,C.Bairro,C.Telefone,C.Celular,C.Email,V.StatusVenda,V.LucroVenda,P.FornecedorId,V.CustoVenda,V.NumeroCupomFiscal,V.ValorIcms,V.ValorIcmsST,V.ValorIpi,UN.Descricao AS UnidadeMedida,V.Subtotal,V.Total,V.Desconto,V.Observacao,VI.ProdutosId,P.Descricao AS Produto,P.CodigoBarras,VI.EstoqueAtual,VI.ValorUnitario,VI.ValorTotal,EP.Logotipo,EP.RazaoSocial,EP.NomeFantasia,EP.CNPJ,EP.Endereco,EP.Telefone,EP.Celular,EP.Bairro,EP.Cep,EP.Numero,V.FuncionarioId,F.Nome AS Funcionario,V.Tipo,ISNULL(V.FormaPagamentoId,0) AS FormaPagamentoId,FP.Descricao AS FormaPagamento,U.Nome,(SELECT SUM(SC.Valor)* -1 FROM SaldoClientes SC WHERE SC.VendasId =V.VendasId) AS Valor FROM Empresa EP,Vendas V LEFT OUTER JOIN Clientes C ON C.CidadeId =V.CidadeId LEFT JOIN Cidades CI ON CI.CidadeId =C.CidadeId LEFT JOIN Funcionarios F ON F.FuncionarioId =V.FuncionarioId LEFT JOIN VendasItens VI ON VI.VendasId =V.VendasId LEFT JOIN Produtos P ON P.ProdutosId =VI.ProdutosId LEFT JOIN Empresa EM ON EM.CidadeId =CI.CidadeId LEFT JOIN FormaPagamento FP ON FP.FormaPagamentoId =V.FormaPagamentoId LEFT JOIN Usuarios U ON U.UsuarioId =V.UsuarioId LEFT JOIN UnidadeMedida UN ON UN.UnidadeMedidaId =P.UnidadeMedidaId ";

        #endregion

        #region Métodos Publicos

        public Boolean Inserir(Vendas vendas)
        {
            return conexao.Inserir(nomeTabela, PreencheParametros(vendas));
        }

        public Boolean Alterar(Vendas vendas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametros(vendas), PreencheCondicoes(vendas));
        }

        public Boolean AlterarImpostosSpedFiscal(Vendas vendas)
        {
            return conexao.Atualizar(nomeTabela, PreencheParametrosAtualizaImpostosSpedFiscal(vendas), PreencheCondicoes(vendas));
        }

        public Boolean Excluir(Vendas vendas)
        {
            return conexao.Excluir(nomeTabela, PreencheCondicoes(vendas));
        }

        public bool AlterarDataSaida(DateTime paramDataSaida, int paramCompraVendaID)
        {
            return conexao.Executar(string.Format("UPDATE COMPRAVENDA SET ComVDtSa = '{0}' WHERE ComVCodi = {1}", paramDataSaida.ToString("yyyy-MM-dd HH:mm:ss"), paramCompraVendaID));
        }

        public DataTable PesquisarPorCodigo(int vendasId)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE V.VendasId = {1}", sqlDefault, vendasId));
        }

        public int PesquisarIDPorNumeroPedido(string vendasId)
        {
            DataTable dt = conexao.Pesquisar(string.Format("SELECT ISNULL(V.VendasId, 0) AS VendasId FROM CompraVenda CV WHERE V.NumeroDocumento LIKE '{0}' ORDER BY V.VendasId", vendasId));

            if (dt.Rows.Count > 0 && dt != null)
                return Convert.ToInt32(dt.Rows[0]["VendasId"].ToString());
            else
                return 0;
        }

        public DataTable PesquisarPorNumeroPedido(string numeroDocumento)
        {
            return conexao.Pesquisar(string.Format("SELECT ISNULL(V.VendasId, 0) AS VendasId, ISNULL(S.StatusVenda, 'EMITIDO') AS StatusVenda FROM CompraVenda CV LEFT JOIN StatusOperacoes S ON S.StatusId = V.StatusId WHERE V.NumeroDocumento LIKE '{0}' ORDER BY V.ComVCodi", numeroDocumento));
        }
        
        public string PesquisarUltimoDocumento()
        {
            return conexao.Pesquisar("SELECT MAX(NumeroDocumento) FROM Vendas").Rows[0][0].ToString();
        }

        public int RetornarUltimoId()
        {
            return Convert.ToInt32(conexao.Pesquisar("SELECT ISNULL(MAX(VendasId),0) FROM Vendas").Rows[0][0]);
        }

        public DataTable PesquisarDocumentoPorNumero(string numeroDocumento)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE V.NumeroDocumento ='{1}' ORDER BY V.NumeroDocumento", sqlDefault, numeroDocumento));
        }

        public string PesquisarUltimaCompraVenda()
        {
            int UltimoNumero = Convert.ToInt32(conexao.Pesquisar("SELECT ISNULL(MAX(NumeroDocumento), 1) AS NumeroDocumento FROM Vendas").Rows[0][0].ToString());

            return (UltimoNumero + 1).ToString().PadLeft(8, '0');
        }

        public DataTable PesquisaPedidos(DateTime? dataInicial, DateTime? dataFinal, int fornecedorId, int clienteId, int caixaId)
        {
            string strCmd = sqlDefault;

            if (dataInicial != null && dataFinal != null && caixaId.Equals(0))
                strCmd += ValidarString(strCmd) + string.Format("V.DataEmissao between '{0}' AND '{1}'", dataInicial.Value.ToString("yyyy-MM-dd 00:00:00"), dataFinal.Value.ToString("yyyy-MM-dd 23:59:59"));

            if (clienteId > 0)
                strCmd += ValidarString(strCmd) + string.Format("V.StatusVenda <> 'CA' AND V.ClientesId = {0}", clienteId);
            else
                strCmd += ValidarString(strCmd) + string.Format("V.FornecedorId IS NULL");

            if (caixaId > 0)
                strCmd += ValidarString(strCmd) + string.Format("V.CaixaId= {0}", caixaId);

            return conexao.Pesquisar(string.Format("{0} ORDER BY V.NumeroDocumento DESC", strCmd));
        }

        private string ValidarString(string str)
        {
            if (str.Contains("WHERE"))
                return " AND ";
            else
                return " WHERE ";
        }

        public DataTable PesquisarVendaCliente(string numeroDocumento)
        {
            return conexao.Pesquisar(string.Format("{0} WHERE CV.ComVNrDo ='{1}' ORDER BY ComVNrDo", sqlDefaultVendasClientes, numeroDocumento));
        }

        #endregion

        #region Metodos Privados

        private List<SqlParametros> PreencheParametros(Vendas vendas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();

            if (vendas.CaixaId > 0)
                lstParametros.Add(new SqlParametros("CaixaId", vendas.CaixaId));

            if (vendas.UsuarioId > 0)
                lstParametros.Add(new SqlParametros("UsuarioId", vendas.UsuarioId));

            if (vendas.ProdutosId > 0)
                lstParametros.Add(new SqlParametros("ProdutosId", vendas.ProdutosId));

            if (vendas.FormaPagamentoId > 0)
                lstParametros.Add(new SqlParametros("FormaPagamentoId", vendas.FormaPagamentoId));

            if (vendas.StatusId > 0)
                lstParametros.Add(new SqlParametros("StatusId", vendas.StatusId));

            if (vendas.FornecedorId > 0)
                lstParametros.Add(new SqlParametros("FornecedorId", vendas.FornecedorId));

            if (vendas.FuncionarioId > 0)
                lstParametros.Add(new SqlParametros("FuncionarioId", vendas.FuncionarioId));

            lstParametros.Add(new SqlParametros("NumeroDocumento", vendas.NumeroDocumento));

            if (!vendas.DataEmissao.ToString().Contains("01/01/0001") && !vendas.DataEmissao.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataEmissao", vendas.DataEmissao.ToString("yyyy-MM-dd HH:mm:ss")));

            if (!vendas.DataVendaFinalizada.ToString().Contains("01/01/0001") && !vendas.DataVendaFinalizada.ToString().Contains("1/1/0001"))
                lstParametros.Add(new SqlParametros("DataVendaFinalizada", vendas.DataVendaFinalizada.ToString("yyyy-MM-dd")));

            lstParametros.Add(new SqlParametros("Cpf", vendas.Cpf));
            lstParametros.Add(new SqlParametros("Cfop", vendas.Cfop));
            lstParametros.Add(new SqlParametros("Subtotal", vendas.Subtotal.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Total", vendas.Total.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Desconto", vendas.Desconto.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("LucroVenda", vendas.LucroVenda.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("CustoVenda", vendas.CustoVenda.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Troco", vendas.Troco.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Tipo", vendas.Tipo));
            lstParametros.Add(new SqlParametros("StatusVenda", vendas.StatusVenda));
            lstParametros.Add(new SqlParametros("BaseCalculoIcms", vendas.BaseCalculoIcms.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoIcmsST", vendas.BaseCalculoIcmsST.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoPis", vendas.BaseCalculoPis.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("BaseCalculoCofins", vendas.BaseCalculoCofins.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorIcms", vendas.ValorIcms.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorIcmsST", vendas.ValorIcmsST.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorIpi", vendas.ValorIpi.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorPis", vendas.ValorPis.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("ValorCofins", vendas.ValorCofins.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("Serie", vendas.Serie));
            lstParametros.Add(new SqlParametros("Observacao", vendas.Observacao));
            lstParametros.Add(new SqlParametros("NumeroCupomFiscal", vendas.NumeroCupomFiscal));
            lstParametros.Add(new SqlParametros("PercentualLucroVenda", vendas.PercentualLucroVenda.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("DescricaoFormaPagamento", vendas.DescricaoFormaPagamento));
            lstParametros.Add(new SqlParametros("SaldoClienteUtilizado", vendas.SaldoClienteUtilizado.ToString().Replace(",", ".")));

            return lstParametros;
        }

        private List<SqlParametros> PreencheParametrosAtualizaImpostosSpedFiscal(Vendas vendas)
        {
            List<SqlParametros> lstParametros = new List<SqlParametros>();
            lstParametros.Add(new SqlParametros("VendaSpedIcmsBaseCalculo", vendas.VendaSpedIcmsBaseCalculo.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedIcmsValor", vendas.VendaSpedIcmsValor.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedIpiBaseCalculo", vendas.VendaSpedIpiBaseCalculo.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedIpiValor", vendas.VendaSpedIpiValor.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedPisBaseCalculo", vendas.VendaSpedPisBaseCalculo.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedPisValor", vendas.VendaSpedPisValor.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedCofinsBaseCalculo", vendas.VendaSpedCofinsBaseCalculo.ToString().Replace(",", ".")));
            lstParametros.Add(new SqlParametros("VendaSpedCofinsValor", vendas.VendaSpedCofinsValor.ToString().Replace(",", ".")));
            return lstParametros;
        }

        private List<SqlParametros> PreencheCondicoes(Vendas vendas)
        {
            List<SqlParametros> lstParametrosCondicionais = new List<SqlParametros>();

            lstParametrosCondicionais.Add(new SqlParametros("VendasId", vendas.VendasId));

            return lstParametrosCondicionais;
        }

        #endregion

    }
}
