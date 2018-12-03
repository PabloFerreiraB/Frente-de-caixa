using PDV.AcessoBancoDados;
using PDV.Apresentacao.MovimentacaoCaixa.OperacoesPDV;
using PDV.Apresentacao.Utils;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace PDV.Apresentacao.MovimentacaoCaixa
{
    public partial class FrmPDV : Form
    {
        public FrmPDV()
        {
            InitializeComponent();
        }

        #region Instâncias

        readonly ProdutosNegocios produtosNegocios = new ProdutosNegocios();
        readonly UsuariosNegocios usuariosNegocios = new UsuariosNegocios();
        readonly Cryptografia cryptografia = new Cryptografia();
        readonly CaixaNegocios caixaNegocios = new CaixaNegocios();
        readonly VendasNegocios vendasNegocios = new VendasNegocios();
        readonly SaldoClientesNegocios saldoClientesNegocios = new SaldoClientesNegocios();
        readonly Conexao conexao = new Conexao();
        readonly ReceitasDespesasNegocios receitasDespesasNegocios = new ReceitasDespesasNegocios();
        readonly ReceitasDespesasBaixasNegocios receitasDespesasBaixasNegocios = new ReceitasDespesasBaixasNegocios();
        readonly FormaPagamentoNegocios formaPagamentoNegocios = new FormaPagamentoNegocios();
        readonly MovimentacaoCaixaNegocios movimentacaoCaixaNegocios = new MovimentacaoCaixaNegocios();
        readonly VendasItensNegocios vendasItensNegocios = new VendasItensNegocios();
        readonly EstoqueNegocios estoqueNegocios = new EstoqueNegocios();
        readonly RetornarImpostosProdutos retornarImpostosProdutos = new RetornarImpostosProdutos();

        #endregion

        #region Propriedade

        public int _ClientesId { get; set; }

        public string _Cliente { get; set; }

        public string _CpfCnpj { get; set; }

        public string _NumeroFatura { get; set; }

        public string _Cfop { get; set; }

        public bool _CupomFiscalAberto { get; set; }

        public decimal _LucroVenda { get; set; }

        public decimal _CustoVenda { get; set; }

        public decimal _PercentualLucroVenda { get; set; }


        #endregion

        #region Veriáveis

        bool encerrouVenda = false;
        bool novaVenda = false;
        bool desconto = false;
        int produtosId = 0;
        int senhaCorreta = 0;
        string motivoDesconto = string.Empty;
        string numeroVenda = string.Empty;
        int codigoVenda = 0;
        decimal saldoDoCLiente = 0;
        bool utilizarSaldoCliente = false;
        decimal saldoUtilizadoNaVenda = 0;
        string valorVenda = "0";
        decimal valorSaldoAposVenda = 0;
        int ultimoId = 0;
        int ultimoCaixaAberto = 0;
        DataTable dtVenda;

        //IMPOSTOS
        decimal ValorPisGeral = 0; decimal BaseCalculoPisGeral = 0; decimal ValorCofinsGeral = 0;
        decimal BaseCalculoCofinsGeral = 0; decimal BaseCalculoIpiGeral = 0; decimal ValorIpiGeral = 0;
        decimal BaseCalculoIcmsSTGeral = 0; decimal ValorIcmsSTGeral = 0; decimal BaseCalculoIcmsGeral = 0;
        decimal ValorIcmsGeral = 0;

        #endregion

        #region Métodos

        //PABLO - FUNÇÕES PARA EMITIR CUPOM FISCAL
        #region FUNÇÕES PARA EMITIR CUPOM FISCAL

        //#region ABRIR PORTA SERIAL

        ////************************ABRINDO PORTA SERIAL*****************************************
        //private bool AbrePortaSerial(string impressora)
        //{
        //    try
        //    {
        //        int retornoAbrePorta = 10;
        //        if (impressora == "2")
        //        {
        //            retornoAbrePorta = ECFSWEDA.ECF_AbrePortaSerial();
        //            if (retornoAbrePorta == 1)
        //            {
        //                //_Mensagens.MensagensSucesso("Comunicação realizada com sucesso!");
        //                return true;
        //            }
        //            else
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir porta serial " + retornoAbrePorta);
        //                return false;
        //            }
        //        }
        //        else if (impressora == "1")
        //        {
        //            retornoAbrePorta = Bematech.Bematech_FI_AbrePortaSerial();
        //            if (retornoAbrePorta == 1)
        //            {
        //                //_Mensagens.MensagensSucesso("Comunicação realizada com sucesso!");
        //                return true;
        //            }
        //            else if (retornoAbrePorta == -4)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir porta serial, arquivo BemaFI32.ini não encontrado, " + retornoAbrePorta);
        //                return false;
        //            }
        //            else if (retornoAbrePorta == -5)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir porta serial " + retornoAbrePorta);
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //        return false;
        //    }
        //}
        ////*************************************************************************************
        //#endregion

        //#region ABRIR CUPOM FISCAL

        //private bool AbrirCupom(string impressora)
        //{
        //    try
        //    {
        //        int retornoAbrirCumpom = 10;
        //        if (impressora == "2") //SWEDA
        //        {
        //            retornoAbrirCumpom = ECFSWEDA.ECF_AbreCupom(lblCpfConsumidor.Text);
        //            if (retornoAbrirCumpom != 1)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir cupom " + retornoAbrirCumpom);
        //                return false;
        //            }
        //            else
        //            {

        //                return true;
        //            }
        //        }
        //        else if (impressora == "1") // bematech
        //        {
        //            retornoAbrirCumpom = Bematech.Bematech_FI_AbreCupom(lblCpfConsumidor.Text);
        //            if (retornoAbrirCumpom == 1)
        //            {
        //                //ALTERAR QUE FOI UM CUPOM FISCAL
        //                CompraVendaInfo _CompraVendaInfo = new CompraVendaInfo();
        //                _CompraVendaInfo.ComVFisc = true;
        //                if (codigoOperacao <= 0)
        //                    _CompraVendaInfo.ComVNrDo = NumeroVenda;
        //                else
        //                    _CompraVendaInfo.ComVNrDo = txtNumeroDocumento.Text; ;

        //                string Cupom = new string('\x20', 14);
        //                int retorno = Bematech.Bematech_FI_NumeroCupom(ref Cupom);
        //                NumeroCupomFiscal = Cupom;
        //                _CompraVendaInfo.ComVNumeCupo = Cupom.ToString();
        //                _objCompraVendaControl.Alterar_CupomFiscal(_CompraVendaInfo);
        //                return true;
        //            }
        //            else if (retornoAbrirCumpom == -2)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir cupom, Parâmetro inválido " + retornoAbrirCumpom);
        //                return false;
        //            }
        //            else if (retornoAbrirCumpom == -4)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir cupom, arquivo BemaFI32.ini não encontrado " + retornoAbrirCumpom);
        //                return false;
        //            }
        //            else if (retornoAbrirCumpom == -5)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir a porta de comunicação " + retornoAbrirCumpom);
        //                return false;
        //            }
        //            else
        //                return false;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Mensagens.MensagensErro(ex.Message);
        //        return false;
        //    }
        //}
        ////************************************************************************
        //#endregion

        //#region FECHAR CUPOM FISCAL
        ////**************************FECHANDO O CUPOM FISCAL************************
        //private bool FecharCupom(string impressora, string FormaPagamento)
        //{
        //    try
        //    {
        //        //string MensagemFinal = "Valor dos impostos: " + (ValorPis + ValorIcms + ValorCofins).ToString("N2") + "\n\nObrigado pela preferência!!!";
        //        string MensagemFinal = "\nTrib aprox R$: " + (varIbptImpostoFederal).ToString("N2") + " Federal, " + (varIbptImpostoEstadual).ToString("N2") + " Estadual e " + (varIbptImpostoMunicipal).ToString("N2") + " Municipal | Fonte: IBPT\n\nObrigado pela preferência!!!";

        //        int retornoFechamento = 10;
        //        if (impressora == "2")
        //        {
        //            retornoFechamento = ECFSWEDA.ECF_FechaCupom(FormaPagamento, "D", "$", txtDescontoCompraVenda.Text, txtSubTotalCompraVenda.Text, MensagemFinal);
        //            if (retornoFechamento == 1)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                _Mensagens.MensagensErro("Erro ao fechar cupom " + retornoFechamento);
        //                return false;
        //            }
        //        }
        //        else if (impressora == "1")
        //        {
        //            retornoFechamento = Bematech.Bematech_FI_FechaCupom(FormaPagamento, "D", "$", txtDescontoCompraVenda.Text, txtSubTotalCompraVenda.Text, "Cliente:" + txtTipoPessoa.Text + "\n\n" + MensagemFinal);

        //            if (retornoFechamento != 1)
        //            {
        //                retornoFechamento = Bematech.Bematech_FI_FechaCupom("Dinheiro", Convert.ToDecimal(txtAcrescimoCompraVenda.Text) > 0 ? "A" : "D", "$", Convert.ToDecimal(txtAcrescimoCompraVenda.Text) > 0 ? txtAcrescimoCompraVenda.Text : txtDescontoCompraVenda.Text, txtSubTotalCompraVenda.Text, "Cliente:" + txtTipoPessoa.Text + "\n\n" + MensagemFinal);
        //            }

        //            if (retornoFechamento == 1)
        //            {
        //                return true;
        //            }
        //            else if (retornoFechamento == -2)
        //            {
        //                _Mensagens.MensagensErro("Erro ao fechar cupom, Parâmetro inválido " + retornoFechamento);
        //                return false;
        //            }
        //            else if (retornoFechamento == -4)
        //            {
        //                _Mensagens.MensagensErro("Erro ao fechar cupom, arquivo BemaFI32.ini não encontrado no diretório do Windows, " + retornoFechamento);
        //                return false;
        //            }
        //            else if (retornoFechamento == -5)
        //            {
        //                _Mensagens.MensagensErro("Erro ao fechar cupom, Erro ao abrir porta de comunicação " + retornoFechamento);
        //                return false;
        //            }
        //            else
        //                return false;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Mensagens.MensagensErro(ex.Message);
        //        return false;
        //    }
        //}
        ////*************************************************************************
        //#endregion

        //#region CANCELAR ULTIMO CUPOM FISCAL
        ////**************************CANCELAR CUPOM*********************************
        //private bool CancelarCupom(string impressora)
        //{
        //    try
        //    {
        //        int retornoCancelarCupom = 10;
        //        if (impressora == "2")
        //        {
        //            retornoCancelarCupom = ECFSWEDA.ECF_CancelaCupom();
        //            if (retornoCancelarCupom == 1)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                _Mensagens.MensagensErro("Erro de comunicação " + retornoCancelarCupom);
        //                return false;
        //            }
        //        }
        //        else if (impressora == "1")
        //        {
        //            retornoCancelarCupom = Bematech.Bematech_FI_CancelaCupom();
        //            if (retornoCancelarCupom == 1)
        //            {
        //                _Mensagens.MensagensSucesso("Cupom Cancelado com sucesso!");
        //                return true;
        //            }
        //            else if (retornoCancelarCupom == -4)
        //            {
        //                _Mensagens.MensagensErro("Arquivo BemaFI32.ini não encontrado no diretório do Windows " + retornoCancelarCupom);
        //                return false;
        //            }
        //            else if (retornoCancelarCupom == -5)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir porta de comunicação " + retornoCancelarCupom);
        //                return false;
        //            }
        //            else
        //                return false;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Mensagens.MensagensErro(ex.Message);
        //        return false;
        //    }
        //}
        ////***********************************************************************************
        //#endregion

        //#region FECHAR PORTA SERIAL
        ////*****************************FECHAR PORTA SERIAL***********************************
        //private void FecharPortaSerial(string impressora)
        //{
        //    try
        //    {
        //        int retornoFechaPortaSerial = 10;
        //        if (impressora == "2")
        //        {
        //            retornoFechaPortaSerial = ECFSWEDA.ECF_FechaPortaSerial();
        //            if (retornoFechaPortaSerial != 1)
        //                _Mensagens.MensagensErro("Erro ao fechar a porta serial!");
        //        }
        //        else if (impressora == "1")
        //        {
        //            retornoFechaPortaSerial = Bematech.Bematech_FI_FechaPortaSerial();
        //            if (retornoFechaPortaSerial != 1)
        //                _Mensagens.MensagensErro("Erro ao fechar a porta serial!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _Mensagens.MensagensErro(ex.Message);
        //    }
        //}
        ////*************************************************************************************
        //#endregion

        //#region CANCELAR ULTIMO ITEM VENDIDO
        ////**************************CANCELAR CUPOM*********************************
        //private bool CancelarUltimoItemVendido(string impressora)
        //{
        //    try
        //    {
        //        int retornoCancelamentoItem = 10;
        //        if (impressora == "2")
        //        {
        //            retornoCancelamentoItem = ECFSWEDA.ECF_CancelaItemAnterior();
        //            if (retornoCancelamentoItem == 1)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                _Mensagens.MensagensErro("Erro de comunicação " + retornoCancelamentoItem);
        //                return false;
        //            }
        //        }
        //        else if (impressora == "1")
        //        {
        //            retornoCancelamentoItem = Bematech.Bematech_FI_CancelaItemAnterior();
        //            if (retornoCancelamentoItem == 1)
        //            {
        //                _Mensagens.MensagensSucesso("Item cancelado!");
        //                return true;
        //            }
        //            else if (retornoCancelamentoItem == -4)
        //            {
        //                _Mensagens.MensagensErro("Arquivo BemaFI32.ini não encontrado no diretório do Windows " + retornoCancelamentoItem);
        //                return false;
        //            }
        //            else if (retornoCancelamentoItem == -5)
        //            {
        //                _Mensagens.MensagensErro("Erro ao abrir porta de comunicação " + retornoCancelamentoItem);
        //                return false;
        //            }
        //            else
        //                return false;
        //        }
        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        _Mensagens.MensagensErro(ex.Message);
        //        return false;
        //    }
        //}
        ////***********************************************************************************
        //#endregion

        #endregion


        //decimal varIbptImpostoFederal = 0;
        //decimal varIbptImpostoEstadual = 0;
        //decimal varIbptImpostoMunicipal = 0;
        //decimal varGeralBaseCalculoImpostoIbpt = 0;
        //private bool ImprimindoCupomFiscalCaixa()
        //{
        //    try
        //    {
        //        if (AbrePortaSerial(impressoraFiscal) == true)
        //        {
        //            if (cupomFiscalAberto == false)
        //            {
        //                if (AbrirCupom(impressoraFiscal) == true)
        //                {
        //                    //VENDENDO OS ITENS
        //                    cupomFiscalAberto = true;
        //                    varGeralBaseCalculoImpostoIbpt = varIbptImpostoFederal = 0;
        //                    for (int i = 0; i < grid.Rows.Count; i++)
        //                    {
        //                        int retornoVendeItem = 99; string UnidadeMedida = string.Empty;

        //                        UnidadeMedida = _objProdutoControl.PesquisarUnidadeMedida(Convert.ToInt32(grid.Rows[i].Cells["ProdCodi"].Value.ToString()));
        //                        if (!string.IsNullOrEmpty(UnidadeMedida))
        //                        {
        //                            if (UnidadeMedida.Length > 2)
        //                                UnidadeMedida = UnidadeMedida.Substring(0, 2);
        //                        }

        //                        if (Convert.ToDecimal(grid.Rows[i].Cells["ItenQtde"].Value) > 0)
        //                        {
        //                            retornoVendeItem = Bematech.Bematech_FI_VendeItemDepartamento(grid.Rows[i].Cells["ProdCodi"].Value.ToString(),
        //                                                                              grid.Rows[i].Cells["ProdDesc"].Value.ToString().TrimEnd(),
        //                                                                             _objProdutoControl.PesquisarAliquotaECF(Convert.ToInt32(grid.Rows[i].Cells["ProdCodi"].Value)),
        //                                                                             Convert.ToDecimal(grid.Rows[i].Cells["ItenPrUn"].Value).ToString("N3"),
        //                                                                             Convert.ToDecimal(grid.Rows[i].Cells["ItenQtde"].Value).ToString("N3"),
        //                                                                             "0",
        //                                                                             "0",
        //                                                                             "03",
        //                                                                             UnidadeMedida);
        //                        }

        //                        Bematech.Analisa_iRetorno(retornoVendeItem);

        //                        string NcmItem = _objProdutoControl.PesquisarNCM(Convert.ToInt32(grid.Rows[i].Cells["ProdCodi"].Value.ToString()));

        //                        IBPTInfo objIbtpInfo = new IBPTInfo();
        //                        objIbtpInfo = _objIbptControl.PesquisarAliquotasFederalEstadualMunicipal(NcmItem);

        //                        if (objIbtpInfo != null)
        //                        {
        //                            varIbptImpostoFederal += (Convert.ToDecimal(grid.Rows[i].Cells["ItenPrTo"].Value) / 100) * objIbtpInfo.IbptAliquotaNacional;
        //                            varIbptImpostoEstadual += (Convert.ToDecimal(grid.Rows[i].Cells["ItenPrTo"].Value) / 100) * objIbtpInfo.IbptAliquotaEstadual;
        //                            varIbptImpostoMunicipal += (Convert.ToDecimal(grid.Rows[i].Cells["ItenPrTo"].Value) / 100) * objIbtpInfo.IbptAliquotaMunicipal;
        //                            varGeralBaseCalculoImpostoIbpt += Convert.ToDecimal(grid.Rows[i].Cells["ItenPrTo"].Value);
        //                        }
        //                    }
        //                    return true;
        //                }
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        return false;
        //    }
        //    catch
        //    { return false; }
        //}

        private void LancarSaldoCliente(int vendasId, decimal valor, string numeroVenda)
        {
            SaldoClientes saldoClientes = new SaldoClientes();

            saldoClientes.ClientesId = _ClientesId;
            saldoClientes.Observacao = "Saldo retirado referente ao Pedido - " + numeroVenda;

            saldoClientes.Operacao = 2;//Somar 1   subtrair 2
            saldoClientes.Valor = valor;
            saldoClientes.DataHora = DateTime.Now;
            saldoClientes.CaixaId = 0;
            saldoClientes.VendasId = vendasId;

            //Situação do saldo do cliente
            saldoClientesNegocios.DescontarSaldoCliente(saldoClientes);
        }

        private void InserirItens(int vendasItensId)
        {
            try
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    VendasItens vendasItens = new VendasItens();

                    vendasItens.VendasItensId = vendasItensId;
                    vendasItens.NumeroDocumento = numeroVenda;
                    vendasItens.ProdutosId = Convert.ToInt32(grid.Rows[i].Cells["ProdutosId"].Value);
                    vendasItens.Quantidade = Convert.ToInt32(grid.Rows[i].Cells["Quantidade"].Value);
                    vendasItens.ValorUnitario = Convert.ToDecimal(grid.Rows[i].Cells["ValorUnitario"].Value);
                    vendasItens.ValorTotal = Convert.ToDecimal(grid.Rows[i].Cells["ValorTotal"].Value);
                    vendasItens.DataVencimento = DateTime.Now;
                    vendasItens.Desconto = Convert.ToDecimal(grid.Rows[i].Cells["Desconto"].Value);
                    vendasItens.Lucro = Convert.ToDecimal(grid.Rows[i].Cells["Lucro"].Value);
                    vendasItens.Custo = Convert.ToDecimal(grid.Rows[i].Cells["Custo"].Value);
                    vendasItens.PercentualLucro = Convert.ToDecimal(grid.Rows[i].Cells["PercentualLucro"].Value);

                    //PABLO - VERIFICAR AQUI SE ESTARÁ ABAIXANDO OU ACRESCENTANDO O ESTOQUE NORMALMENTE
                    vendasItens.EstoqueAtual = produtosNegocios.VerificaEstoque(Convert.ToInt32(grid.Rows[i].Cells["ProdutosId"].Value));
                    vendasItens.EstoqueAposMovimentacao = vendasItens.EstoqueAtual - vendasItens.EstoqueAtual;

                    vendasItens.PercentualPis = Convert.ToDecimal(grid.Rows[i].Cells["PercentualPis"].Value);
                    vendasItens.BaseCalculoPis = Convert.ToDecimal(grid.Rows[i].Cells["BaseCalculoPis"].Value);
                    vendasItens.ValorPis = Convert.ToDecimal(grid.Rows[i].Cells["ValorPis"].Value);

                    vendasItens.PercentualCofins = Convert.ToDecimal(grid.Rows[i].Cells["PercentualCofins"].Value);
                    vendasItens.BaseCalculoCofins = Convert.ToDecimal(grid.Rows[i].Cells["BaseCalculoCofins"].Value);
                    vendasItens.ValorCofins = Convert.ToDecimal(grid.Rows[i].Cells["ValorCofins"].Value);

                    vendasItens.PercentualIcms = Convert.ToDecimal(grid.Rows[i].Cells["PercentualIcms"].Value);
                    vendasItens.BaseCalculoIcms = Convert.ToDecimal(grid.Rows[i].Cells["BaseCalculoIcms"].Value);
                    vendasItens.ValorIcms = Convert.ToDecimal(grid.Rows[i].Cells["ValorIcms"].Value);
                    vendasItens.CstCsosn = Convert.ToString(grid.Rows[i].Cells["CstCsosn"].Value);

                    vendasItens.PercentualIcmsST = Convert.ToDecimal(grid.Rows[i].Cells["PercentualIcmsST"].Value);
                    vendasItens.BaseCalculoIcmsST = Convert.ToDecimal(grid.Rows[i].Cells["BaseCalculoIcmsST"].Value);
                    vendasItens.ValorIcmsST = Convert.ToDecimal(grid.Rows[i].Cells["ValorIcmsST"].Value);
                    vendasItens.IvaIcmsST = Convert.ToDecimal(grid.Rows[i].Cells["IvaIcmsST"].Value);

                    vendasItens.IbptValorFederal = !string.IsNullOrEmpty(grid.Rows[i].Cells["IbptValorFederal"].Value.ToString()) ? Convert.ToDecimal(grid.Rows[i].Cells["IbptValorFederal"].Value) : 0;
                    vendasItens.IbptValorEstadual = !string.IsNullOrEmpty(grid.Rows[i].Cells["IbptValorEstadual"].Value.ToString()) ? Convert.ToDecimal(grid.Rows[i].Cells["IbptValorEstadual"].Value) : 0;
                    vendasItens.IbptValorMunicipal = !string.IsNullOrEmpty(grid.Rows[i].Cells["IbptValorMunicipal"].Value.ToString()) ? Convert.ToDecimal(grid.Rows[i].Cells["IbptValorMunicipal"].Value) : 0;

                    int ultimoId = 0;
                    vendasItensNegocios.Inserir(vendasItens);


                    //Estoque Novo 
                    ultimoId = conexao.RetornarUltimoId("VendasItens", "VendasItensId");
                    Estoque estoque = new Estoque();

                    estoque.ProdutosId = Convert.ToInt32(vendasItens.ProdutosId);
                    estoque.DataHora = DateTime.Now;
                    estoque.Tipo = Convert.ToInt32((enumEstoque)Enum.Parse(typeof(enumEstoque), "Saida"));
                    estoque.Quantidade = vendasItens.Quantidade * -1;
                    estoque.Serie = 1; // 001
                    estoque.VendasItensId = ultimoId;
                    estoque.MovimentacaoSerie = true;

                    if (estoque.VendasItensId > 0)
                        estoqueNegocios.Inserir(estoque);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar os produtos da venda!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);


                if (!Directory.Exists(Application.StartupPath.ToString() + "\\logVenda.txt"))
                    Directory.CreateDirectory(Application.StartupPath.ToString() + "\\logVenda.txt");

                StreamWriter sw = new StreamWriter(Application.StartupPath.ToString() + "\\logVenda.txt");
                sw.Write(ex.Message);
                sw.Write(ex.StackTrace);
                sw.Flush();
                sw.Close();
            }
        }


        private string BuscaUltimaVenda()
        {
            return vendasNegocios.PesquisarUltimaCompraVenda();
        }

        private void CalcularTotalGeral()
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    decimal totalGeral = 0;
                    foreach (DataGridViewRow r in grid.Rows)
                    {
                        totalGeral += Convert.ToDecimal(r.Cells["ValorTotal"].Value);
                    }

                    txtSubtotalGeral.Text = totalGeral.ToString("N2"); // PABLO - SubTotal Geral - Incluir desconto na soma
                    txtTotalGeral.Text = totalGeral.ToString("N2");
                }
                else
                    txtTotalGeral.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cálcular o Total Geral!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Limpar()
        {
            txtCodigo.Clear();
            txtQuantidade.Text = "1";
            txtUnitario.Text = "0,00";
            txtSubtotal.Text = "0,00";
            txtTotal.Text = "0,00";
            txtLancarValor.Text = "0,00";

            if (encerrouVenda)
                grid.Rows.Clear();
            else if (novaVenda)
                grid.Rows.Clear();

            encerrouVenda = false;
            novaVenda = false;
        }

        #endregion


        private void FrmPDV_Load(object sender, EventArgs e)
        {
            lblOperador.Text = "Operador: " + FrmLogin.nomeLogin.ToUpper();
            lblTerminal.Text = "Terminal: " + Environment.MachineName.ToUpper();

            lblStatusCaixa.Text = "CAIXA DISPONÍVEL";

            txtCodigo.Select();
            txtCodigo.Focus();

            // Verifica se o caixa está aberto
            ultimoCaixaAberto = caixaNegocios.VerificarSeCaixaEstaAberto();
            if (ultimoCaixaAberto == 0)
            {
                MessageBox.Show("Caixa fechado.\n\nPor favor efetue a abertura do caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void FrmPDV_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F1)
            {
                novaVenda = true;
                Limpar();
                lblDescricaoProduto.Text = "";
                txtTotalGeral.Text = "0,00";
                lblStatusCaixa.Text = "CAIXA DISPONÍVEL";
                txtCodigo.Focus();
            }
            else if (e.KeyCode == Keys.F2)
            {
                try
                {
                    if (grid.Rows.Count > 0)
                    {
                        FrmPermissao frmPermitirDesconto = new FrmPermissao();
                        frmPermitirDesconto.ShowInTaskbar = false;
                        frmPermitirDesconto.ShowDialog();

                        if (!string.IsNullOrEmpty(frmPermitirDesconto._Senha))
                        {
                            senhaCorreta = usuariosNegocios.PesquisarUsuarioSenha(cryptografia.Crypto(frmPermitirDesconto._Senha, true));
                            if (senhaCorreta.Equals(0))
                            {
                                MessageBox.Show("Senha inválida!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            else
                            {
                                motivoDesconto = frmPermitirDesconto._Motivo;

                                FrmCancelarItem frmCancelarItem = new FrmCancelarItem();
                                frmCancelarItem.ShowInTaskbar = false;
                                frmCancelarItem.ShowDialog();

                                if (frmCancelarItem._Item > 0)
                                {
                                    bool encontrouItem = false;
                                    DataGridViewRow row = new DataGridViewRow();
                                    for (int i = 0; i < grid.Rows.Count; i++)
                                    {
                                        row = grid.Rows[i];
                                        if (row.Cells["numeroItem"].Value.Equals(frmCancelarItem._Item))
                                        {
                                            grid.FirstDisplayedScrollingRowIndex = i;
                                            grid.CurrentCell = row.Cells["numeroItem"];
                                            row.Selected = true;
                                            encontrouItem = true;
                                            break;
                                        }
                                    }

                                    if (encontrouItem)
                                    {
                                        grid.Rows.Remove(grid.Rows[grid.CurrentRow.Index]);
                                        grid.Refresh();

                                        CalcularTotalGeral();
                                        Limpar();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Item não encontrado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Senha não informada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cancelar o item!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (e.KeyCode == Keys.F3) //CANCELAR A VENDA
            {


            }
            else if (e.KeyCode == Keys.F4) //CRIAR RELATÓRIO DE ORÇAMENTO
            {

            }
            else if (e.KeyCode == Keys.F5) //PRODUTOS
            {
                FrmPesquisarProdutos frmPesquisarProdutos = new FrmPesquisarProdutos();
                frmPesquisarProdutos.ShowInTaskbar = false;
                frmPesquisarProdutos.ShowDialog();

                if (frmPesquisarProdutos._ProdutosId > 0)
                {
                    txtCodigo.Text = frmPesquisarProdutos._ProdutosId.ToString();
                    txtCodigo_Leave(sender, e);

                    //lblDescricaoProduto.Text = frmPesquisarProdutos._Descricao;
                    //txtCodigo.Text = frmPesquisarProdutos._ProdutosId.ToString();
                    //txtQuantidade.Text = "1";
                    //txtUnitario.Text = Convert.ToDecimal(frmPesquisarProdutos._ValorUnitario).ToString("N2");
                    //txtSubtotal.Text = (Convert.ToDecimal(txtQuantidade.Text) * Convert.ToDecimal(txtUnitario.Text)).ToString("N2");

                    //txtCodigo.Select();
                    //txtCodigo.Focus();
                }
            }
            else if (e.KeyCode == Keys.F6) //CLIENTES
            {
                FrmClientesCadastrados frmClientesCadastrados = new FrmClientesCadastrados();
                frmClientesCadastrados.ShowInTaskbar = false;
                frmClientesCadastrados._PDV = true;
                frmClientesCadastrados.ShowDialog();

                if (frmClientesCadastrados._ClientesId > 0)
                {
                    _ClientesId = frmClientesCadastrados._ClientesId;
                    _Cliente = frmClientesCadastrados._Cliente;
                    _CpfCnpj = frmClientesCadastrados._CpfCnpj;
                }
            }
            else if (e.KeyCode == Keys.F7) //FINALIZAR VENDA
            {
                try
                {
                    if (grid.Rows.Count > 0)
                    {
                        btnFinalizarVenda_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Nenhum item informado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (e.Control && e.KeyCode == Keys.Q)
            {
                txtQuantidade.ReadOnly = false;
                txtQuantidade.SelectAll();
                txtQuantidade.Focus();
            }
        }

        #region Eventos - KeyDowns e Leave / Código ou Código de Barras

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtCodigo.Text.Trim().Length > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtCodigo_Leave(sender, e);
                }
            }
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            try
            {
                txtCodigo.Text = txtCodigo.Text.Replace("'", "");
                if (txtCodigo.Text.Trim().Length > 0 && txtCodigo.Focused)
                {
                    lblStatusCaixa.Text = "CAIXA OCUPADO";

                    DataTable dtProduto = new DataTable();
                    dtProduto = produtosNegocios.PesquisarPorCodigoOuCodigoBarras(txtCodigo.Text.ToUpper());

                    if (dtProduto.Rows.Count > 0)
                    {
                        produtosId = Convert.ToInt32(dtProduto.Rows[0]["ProdutosId"]);

                        if (dtProduto.Rows[0]["Ativo"].ToString().Equals("False"))
                        {
                            MessageBox.Show("Produto inativo, verifique o cadastro!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();
                            txtCodigo.Clear();
                            txtCodigo.Focus();
                            return;
                        }

                        // Pesquisar os impostos do produto
                        TributacaoFiscal tributacaoFiscal = new TributacaoFiscal();
                        tributacaoFiscal = retornarImpostosProdutos.CalcularImpostos(FrmPrincipal.dadosEmpresa, produtosId, Convert.ToDecimal(txtTotalGeral.Text));

                        txtTotalGeral.Text = Convert.ToDecimal(txtTotalGeral.Text).ToString("N2");
                        decimal novoValorUnitario = Convert.ToDecimal(txtUnitario.Text);

                        grid.Rows.Add(grid.Rows.Count + 1,                       // CONTAGEM DE LINHAS DA GRID
                                      !string.IsNullOrEmpty(dtProduto.Rows[0]["CodigoBarras"].ToString()) ? dtProduto.Rows[0]["CodigoBarras"].ToString() : produtosId.ToString(), // CÓDIGO DO PRODUTO ou CÓDIGO DE BARRAS
                                      dtProduto.Rows[0]["Descricao"].ToString(), // DESCRIÇÃO DO PRODUTO
                                      txtQuantidade.Text,                        // QUANTIDADE DE ITEM
                                      Convert.ToDecimal(dtProduto.Rows[0]["ValorUnitario"]).ToString("N2"), // VALOR UNITÁRIO
                                      ((Convert.ToInt32(txtQuantidade.Text)) * Convert.ToDecimal(dtProduto.Rows[0]["ValorUnitario"])).ToString("N2"), // VALOR SUBTOTAL
                                      tributacaoFiscal.PisCst,                   // PIS CST
                                      tributacaoFiscal.PisPercentual,            // PERCENTUAL DO PIS
                                      tributacaoFiscal.PisPercentualBC,          // BASE CALCULO PIS
                                      tributacaoFiscal.PisValor,                 // VALOR DO PIS
                                      tributacaoFiscal.CofinsCst,                // COFINS CST
                                      tributacaoFiscal.CofinsPercentual,         // PERCENTUAL COFINS
                                      tributacaoFiscal.CofinsPercentualBC,       // BASE CALCULO COFINS
                                      tributacaoFiscal.CofinsValor,              // VALOR DO COFINS
                                      tributacaoFiscal.IcmsPercentual,           // PERCENTUAL DO ICMS
                                      tributacaoFiscal.IcmsPercentualBC,         // BASE CALCULO ICMS
                                      tributacaoFiscal.IcmsValor,                // VALOR DO ICMS
                                      tributacaoFiscal.IcmsCst,                  // CST OU CSOSN ICMS
                                      0,                                         // BASE CALCULO IPI
                                      0,                                         // VALOR IPI
                                      0, 0, 0, 0,                                // VALORES ICMS ST
                                      tributacaoFiscal.IbptAliquotaFederal,     
                                      tributacaoFiscal.IbptAliquotaEstadual,
                                      tributacaoFiscal.IbptAliquotaMunicipal,
                                      tributacaoFiscal.Cfop
                        );

                        grid.FirstDisplayedScrollingRowIndex = grid.Rows.Count - 1;
                        grid.Refresh();
                        grid.ClearSelection();
                        grid.Rows[grid.Rows.Count - 1].Selected = true;

                        CalcularTotalGeral();

                        grid.Refresh();
                        Limpar();
                        txtCodigo.Select();
                        txtCodigo.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar o produto!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos - Enter e Leave / Quantidade


        private void txtQuantidade_Enter(object sender, EventArgs e)
        {
            if (txtQuantidade.Text.Length > 0)
            {
                txtQuantidade.SelectAll();
                txtQuantidade.Focus();
            }
            else
                txtQuantidade.Focus();
        }

        private void txtQuantidade_Leave(object sender, EventArgs e)
        {
            try
            {
                //CalcularTotal();
                txtQuantidade.ReadOnly = true;
                txtCodigo.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cálcular o total do produto!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                lblDescricaoProduto.Text = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString().ToUpper();
                txtCodigo.Text = grid.Rows[grid.CurrentRow.Index].Cells["ProdutosId_"].Value.ToString();
                txtQuantidade.Text = grid.Rows[grid.CurrentRow.Index].Cells["Quantidade"].Value.ToString();
                txtUnitario.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorUnitario"].Value.ToString();
                txtSubtotal.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorTotal"].Value.ToString();
                txtTotal.Text = grid.Rows[grid.CurrentRow.Index].Cells["ValorTotal"].Value.ToString();
            }
        }

        private void btnFinalizarVenda_Click(object sender, EventArgs e)
        {
            try
            {
                //Se o caixa já estiver aberto, verifica se é o mesmo operador que está fazendo a venda!
                int UsuarioAbriuCaixa = caixaNegocios.VerificarUsuarioAbriuCaixa(ultimoCaixaAberto);
                if (FrmLogin.usuarioId != UsuarioAbriuCaixa)
                {
                    MessageBox.Show("Não é possivel realizar a venda, pois o operador logado não é o mesmo que abriu o caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (codigoVenda.Equals(0))
                    numeroVenda = BuscaUltimaVenda();

                //PABLO - Utilizando o saldo que o cliente tem para descontar na venda
                if (_ClientesId > 0)
                {
                    saldoDoCLiente = saldoClientesNegocios.PesquisarSaldoCliente(_ClientesId);
                    saldoDoCLiente += saldoUtilizadoNaVenda;

                    if (saldoDoCLiente > 0)
                    {
                        if (MessageBox.Show("O cliente selecionado possui um saldo de: " + saldoDoCLiente.ToString("N2") + "\n\nDeseja utiliza-lo na venda?", "Pergunta do sistema!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            utilizarSaldoCliente = true;
                        }
                    }
                }


                FrmFormasPagamento frmFormasPagamento = new FrmFormasPagamento();
                frmFormasPagamento.ShowInTaskbar = false;
                frmFormasPagamento._Tipo = "R";
                frmFormasPagamento._Emissao = DateTime.Now;
                frmFormasPagamento._Valortotal = Convert.ToDecimal(txtSubtotalGeral.Text);
                numeroVenda = BuscaUltimaVenda();
                frmFormasPagamento._CompraNumero = numeroVenda;
                if (_NumeroFatura == "" || _NumeroFatura == null)
                    frmFormasPagamento._NumeroFatura = numeroVenda;
                else
                    frmFormasPagamento._NumeroFatura = _NumeroFatura;


                if (codigoVenda > 0)
                {
                    if (Convert.ToDecimal(txtSubtotalGeral.Text) > saldoDoCLiente)
                    {
                        if ((Convert.ToDecimal(valorVenda) > Convert.ToDecimal(txtTotal.Text)) || (Convert.ToDecimal(valorVenda) < Convert.ToDecimal(txtTotal.Text)))
                        {
                            frmFormasPagamento._AlterouVenda = true;
                            MessageBox.Show("VENDA ALTERADA!\n\nO sistema não atualizará o contas a Receber, por favor excluir todas as duplicatas [F3] e gerar novamente!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            frmFormasPagamento._AlterouVenda = false;
                        }
                    }

                    frmFormasPagamento._NumeroDocumentoVenda = codigoVenda;
                }

                if (_ClientesId > 0)
                    frmFormasPagamento._ClienteId = _ClientesId;
                else
                    frmFormasPagamento._ClienteId = 0; // CLIENTE NÃO IDENTIFICADO


                if (utilizarSaldoCliente)
                {
                    valorSaldoAposVenda = saldoDoCLiente - Convert.ToDecimal(txtSubtotalGeral.Text);
                    if (valorSaldoAposVenda >= 0)
                    {
                        frmFormasPagamento._GravouFormaPagamento = true;
                    }
                    else
                    {
                        frmFormasPagamento._Valortotal = Convert.ToDecimal(txtSubtotalGeral.Text) - saldoDoCLiente;
                        frmFormasPagamento.ShowDialog();
                    }
                }
                else
                    frmFormasPagamento.ShowDialog();


                //PABLO - PAREI AQUI
                if (frmFormasPagamento._GravouFormaPagamento)
                {
                    if (codigoVenda > 0)
                    {
                        if (saldoUtilizadoNaVenda > 0)
                        {
                            string sqlSaldo = string.Format("SELECT Referencia FROM SaldoClientes WHERE Valor < 0 AND VendasId = {0}", codigoVenda);
                            DataTable dtSaldoEstornar = conexao.Pesquisar(sqlSaldo);

                            if (dtSaldoEstornar.Rows.Count > 0)
                            {
                                string sqlUpdateSaldo = string.Format("UPDATE SaldoClientes SET Situacao = 'AB' WHERE SaldoClientesId = {0}", dtSaldoEstornar.Rows[0]["Referencia"].ToString());
                                conexao.Executar(sqlUpdateSaldo);
                            }

                            conexao.Executar("DELETE FROM SaldoClientes WHERE Valor < 0 AND VendasId = " + codigoVenda);
                        }
                    }

                    if (codigoVenda > 0)
                        conexao.Executar(string.Format("UPDATE Vendas SET FornecedorId = NULL WHERE VendasId = {0}", codigoVenda));


                    Vendas vendas = new Vendas();

                    vendas.Troco = frmFormasPagamento._Troco;
                    if (_ClientesId > 0)
                        vendas.ClientesId = _ClientesId;
                    else
                        vendas.ClientesId = 0; //CLIENTE NÃO IDENTIFICADO

                    vendas.Cfop = _Cfop;
                    vendas.DataEmissao = DateTime.Now;
                    vendas.DataVendaFinalizada = DateTime.Now;
                    vendas.Observacao = "Venda realizado com sucesso!";
                    vendas.Tipo = "V";
                    vendas.Desconto = frmFormasPagamento._ValorDesconto;
                    vendas.Subtotal = Convert.ToDecimal(txtSubtotalGeral.Text);
                    vendas.Total = Convert.ToDecimal(txtTotalGeral.Text);
                    vendas.Cpf = _CpfCnpj;
                    if (_CupomFiscalAberto)
                        vendas.CupomFiscal = true;
                    else
                        vendas.CupomFiscal = false;
                    //vendas.PlanCodi = Convert.ToInt32(planoContaCompraVenda);
                    if (codigoVenda == 0)
                        vendas.VendasId = 0;
                    vendas.Serie = "001";
                    vendas.StatusVenda = "FINALIZADA";
                    vendas.LucroVenda = _LucroVenda;
                    vendas.CustoVenda = _CustoVenda;
                    vendas.PercentualLucroVenda = _PercentualLucroVenda;
                    vendas.UsuarioId = FrmLogin.usuarioId;
                    vendas.FuncionarioId = FrmLogin.usuarioId; // Funcionario logado
                    vendas.FormaPagamentoId = frmFormasPagamento._FormaPagamentoId;

                    if (utilizarSaldoCliente)
                    {
                        if (valorSaldoAposVenda >= 0)
                            vendas.SaldoClienteUtilizado = Convert.ToDecimal(txtSubtotalGeral.Text);
                        else
                            vendas.SaldoClienteUtilizado = saldoDoCLiente;
                    }

                    vendas.CaixaId = caixaNegocios.VerificarSeCaixaEstaAberto();
                    vendas.DescricaoFormaPagamento = frmFormasPagamento._FormaPagamentoCupomFiscal;
                    vendas.StatusId = 1;

                    #region IMPOSTOS FISCAIS

                    vendas.BaseCalculoPis = BaseCalculoPisGeral;
                    vendas.ValorPis = ValorPisGeral;

                    vendas.BaseCalculoCofins = BaseCalculoCofinsGeral;
                    vendas.ValorCofins = ValorCofinsGeral;

                    vendas.VendaSpedIpiBaseCalculo = BaseCalculoIpiGeral;
                    vendas.ValorIpi = ValorIpiGeral;

                    vendas.BaseCalculoIcms = BaseCalculoIcmsGeral;
                    vendas.ValorIcms = ValorIcmsGeral;

                    vendas.BaseCalculoIcmsST = BaseCalculoIcmsSTGeral;
                    vendas.ValorIcmsST = ValorIcmsSTGeral;

                    vendas.VendaSpedIcmsBaseCalculo = 0;
                    vendas.VendaSpedIcmsValor = 0;
                    vendas.VendaSpedIpiValor = 0;
                    vendas.VendaSpedPisBaseCalculo = 0;
                    vendas.VendaSpedPisValor = 0;
                    vendas.VendaSpedCofinsBaseCalculo = 0;
                    vendas.VendaSpedCofinsValor = 0;

                    #endregion

                    // PABLO - Aqui é onde armazeno todos dados pra gerar o cupom e o relatório após a venda
                    dtVenda = new DataTable();

                    if (!Directory.Exists(Application.StartupPath.ToString() + "\\Vendas"))
                        Directory.CreateDirectory(Application.StartupPath.ToString() + "\\Vendas");

                    try
                    {
                        if (vendasNegocios.Inserir(vendas))
                        {
                            ultimoId = vendasNegocios.RetornarUltimoId();
                            InserirItens(ultimoId);


                            if (utilizarSaldoCliente)
                            {
                                if (valorSaldoAposVenda >= 0)
                                    LancarSaldoCliente(ultimoId, Convert.ToDecimal(txtSubtotalGeral.Text) * (-1), numeroVenda);
                                else
                                    LancarSaldoCliente(ultimoId, saldoDoCLiente * (-1), numeroVenda);
                            }

                            if (frmFormasPagamento._ListaReceitaDespesas != null)
                            {
                                foreach (ReceitasDespesas receitasDespesas in frmFormasPagamento._ListaReceitaDespesas)
                                {
                                    receitasDespesas.ReceitasDespesasId = ultimoId;
                                    receitasDespesas.NumeroDocumento = numeroVenda;
                                    receitasDespesas.Observacao = "Referente à venda: " + numeroVenda;
                                    if (string.IsNullOrEmpty(_NumeroFatura))
                                        receitasDespesas.Parcela = receitasDespesas.Parcela;
                                    else
                                        receitasDespesas.Parcela = receitasDespesas.Parcela;

                                    receitasDespesasNegocios.InserirNovo(receitasDespesas);


                                    //Busca o código da Receita ou Despesa que foi cadastrado
                                    DataTable dtaUltimaReceitaDespesa = new DataTable();
                                    dtaUltimaReceitaDespesa = receitasDespesasNegocios.PesquisarUltimaReceitaDespesas();

                                    if (receitasDespesas.ValorPago > 0)
                                    {
                                        //Inserindo a baixa nova
                                        ReceitasDespesasBaixas receitasDespesasBaixas = new ReceitasDespesasBaixas();

                                        receitasDespesasBaixas.DataHora = receitasDespesas.Emissao;
                                        receitasDespesasBaixas.UsuarioId = FrmLogin.usuarioId;
                                        receitasDespesasBaixas.ReceitasDespesasId = Convert.ToInt32(dtaUltimaReceitaDespesa.Rows[0]["ReceitasDespesasId"].ToString());
                                        receitasDespesasBaixas.Valor = receitasDespesas.Valor;
                                        // PABLO - Criar configuracoes pra setar aqui
                                        receitasDespesasBaixas.MultaPercentualValor = 0; //FrmPrincipal.dadosConfiguracao.Config_TipoMultaAposVencimento; 
                                        receitasDespesasBaixas.Multa = 0; // FrmPrincipal.dadosConfiguracao.Config_MultaAposVencimento;
                                        receitasDespesasBaixas.DescontoPercentualValor = 1;
                                        receitasDespesasBaixas.Desconto = 0;
                                        receitasDespesasBaixas.JurosPercentualValor = 0; // FrmPrincipal.dadosConfiguracao.Config_TipoAcrescimoAoDia;
                                        receitasDespesasBaixas.Juros = 0; // FrmPrincipal.dadosConfiguracao.Config_AcrescimoAoDia;
                                        receitasDespesasBaixas.DiasAtraso = 0;

                                        receitasDespesasBaixasNegocios.Inserir(receitasDespesasBaixas);
                                    }

                                    //Se o código for maior que zero, gera movimentação
                                    DataTable dtaMovimentaFluxoCaixa = new DataTable();
                                    dtaMovimentaFluxoCaixa = formaPagamentoNegocios.PesquisarPorCodigo(receitasDespesas.ReceitasDespesasId);

                                    if (dtaMovimentaFluxoCaixa.Rows[0]["FluxoCaixa"].ToString() == "True")
                                    {
                                        //Gerando a movimentação do caixa
                                        ObjetoTransferencia.MovimentacaoCaixa movimentacaoCaixa = new ObjetoTransferencia.MovimentacaoCaixa();

                                        movimentacaoCaixa.DataHora = DateTime.Now;
                                        movimentacaoCaixa.Observacao = receitasDespesas.Observacao;
                                        movimentacaoCaixa.StatusMovimentacao = "N";
                                        if (receitasDespesas.ClientesId > 0)
                                            movimentacaoCaixa.Tipo = "R";
                                        else
                                            movimentacaoCaixa.Tipo = "D";
                                        movimentacaoCaixa.Valor = receitasDespesas.Valor;
                                        movimentacaoCaixa.ReceitasDespesasId = Convert.ToInt32(dtaUltimaReceitaDespesa.Rows[0]["ReceitasDespesasId"].ToString());
                                        movimentacaoCaixa.CaixaId = caixaNegocios.VerificarSeCaixaEstaAberto();

                                        movimentacaoCaixaNegocios.InserirNovo(movimentacaoCaixa);

                                        // Caixa nova
                                        int ultimoId = conexao.RetornarUltimoId("MovimentacaoCaixa", "MovimentacaoCaixaId");
                                        movimentacaoCaixaNegocios.MovimentoCaixa(ultimoId, movimentacaoCaixa.Valor);
                                    }
                                }
                            }

                            //PABLO - InserirLogs
                            // InserirLogs("N° Venda: " + numeroVenda, Convert.ToInt32(numeroVenda), 0);
                            MessageBox.Show(string.Format("{0} realizado com sucesso! \nNumero da {0} = {1} !", "Venda", numeroVenda), "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            dtVenda = vendasNegocios.PesquisarVendaCliente(numeroVenda);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao gravar os dados solicitados!\n\n" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    if (MessageBox.Show("Cupom Fiscal será impresso!", "Aviso do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string _cpfCnpj = string.Empty;

                        FrmInformeCpfCnpj frmInformeCpfCnpj = new FrmInformeCpfCnpj();

                        if (MessageBox.Show("Deseja informar o CPF ou CNPJ no Cupom Fiscal?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            frmInformeCpfCnpj.ShowInTaskbar = false;
                            frmInformeCpfCnpj.ShowDialog();
                            _cpfCnpj = frmInformeCpfCnpj._CpfCnpj;
                        }

                        //EMITIR O CUPOM FISCAL
                        //    ImprimindoCupomFiscalCaixa();

                        //    if (dtaPagamento.Rows[0]["PrazDescImpresFisc"].ToString() != "")
                        //        FecharCupom(impressoraFiscal, dtaPagamento.Rows[0]["PrazDescImpresFisc"].ToString().ToUpper());
                        //    else
                        //        FecharCupom(impressoraFiscal, frmPagamento.formaPagamentoCupomfiscal.ToUpper());

                        //    if (Convert.ToBoolean(dtaPagamento.Rows[0]["PrazPergEmitiGerencial"].ToString()) == true)
                        //    {
                        //        if (MessageBox.Show("Deseja imprimir relatorio gerencial?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //        {
                        //            ImprimiRelatorioGerencial(dtpEmissao.Value.ToString("dd/MM/yyyy"), txtSubTotalCompraVenda.Text, impressoraFiscal);
                        //        }
                        //    }

                        //    TransformarEmEstoqueFiscal(codigoOperacao > 0 ? codigoOperacao : ultimoID);

                        //    cupomFiscalAberto = false;
                        //    if (chkImprimir.Checked)
                        //        SelecionaImpressora(impressoraVenda, dtVendaCompra);
                        //    LimparCampos(); HabilitarCampos(true);
                        //    if (codigoClienteConfiguracao.Equals(0))
                        //        btnPesquisaPessoa.Focus();
                        //    else if (codigoClienteConfiguracao > 0 && txtSenhaVendedor.Visible)
                        //        txtSenhaVendedor.Focus();
                        //    else
                        //        txtCodigoProduto.Focus();
                        //    if (finalizandoVendaCaixa)
                        //        this.Close();
                        //    return;
                        //}

                        //try
                        //{
                        //    if (vendaCFeID == 0) //Se for igual a zero não emiti o CFe, entao deixa realizar a impressao do Pedido
                        //    {
                        //        if (ImprimirComPergunta)
                        //        {
                        //            if (MessageBox.Show("Deseja imprimir o pedido?", "Informação do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        //            {
                        //                SelecionaImpressora(impressoraVenda, dtVendaCompra);
                        //            }
                        //        }
                        //        else if (chkImprimir.Checked && chkImprimir.Enabled)
                        //        {
                        //            SelecionaImpressora(impressoraVenda, dtVendaCompra);
                        //        }
                        //    }
                        //}
                        //catch (Exception ee)
                        //{
                        //    MessageBox.Show("Ocorreu um erro ao realizar a impressão do pedido, informe o problema abaixo ao suporte da Play Info Sistemas!\n\n" + ee.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}

                        //if (chkEnviarPorEmail.Checked)
                        //    EnviarEmailPedido(dtVendaCompra.Rows[0]["ComVNrDo"].ToString());

                        //btnNovoPedido_Click(sender, e);

                        //if (finalizandoVendaCaixa)
                        //    this.Close();
                    }
                    else
                    {
                        //txtCodigoProduto.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
