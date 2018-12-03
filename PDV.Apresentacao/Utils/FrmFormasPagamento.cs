using PDV.AcessoBancoDados;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Utils
{
    public partial class FrmFormasPagamento : Form
    {
        public FrmFormasPagamento()
        {
            InitializeComponent();
        }

        public class PrazosFormaPagamento
        {
            public int Id { get; set; }

            public int Prazo { get; set; }

            public int Cartao { get; set; }
        }

        #region Instâncias

        readonly FormaPagamentoNegocios formaPagamentoNegocios = new FormaPagamentoNegocios();
        readonly FormaPagamentoPrazosNegocios formaPagamentoPrazosNegocios = new FormaPagamentoPrazosNegocios();
        readonly ReceitasDespesasNegocios receitasDespesasNegocios = new ReceitasDespesasNegocios();
        readonly CaixaNegocios caixaNegocios = new CaixaNegocios();
        readonly MovimentacaoCaixaNegocios movimentacaoCaixaNegocios = new MovimentacaoCaixaNegocios();
        readonly ReceitasDespesasBaixasNegocios receitasDespesasBaixasNegocios = new ReceitasDespesasBaixasNegocios();

        #endregion

        #region Variáveis

        private decimal valorTotalParcelasJaExistia = 0;
        int statusId = 0;
        int quantidadeParcela = 0;
        int parcelas = 1;
        string vencimento = string.Empty;
        bool possuiDuplicataPagas = false;
        string status = "AB";
        string pagamento;
        string valorPago;

        #endregion

        #region Propriedades

        public int _FormaPagamentoId { get; set; }

        public bool _GravouFormaPagamento { get; set; }

        public string _Tipo { get; set; }

        public decimal _Valortotal { get; set; }

        public decimal _TotalValorAberto { get; set; }

        public decimal _ValorDesconto { get; set; }

        public decimal _ValorTaxa { get; set; }

        public decimal _Troco { get; set; }

        public int _ClienteId { get; set; }

        public int _NumeroDocumentoVenda { get; set; }

        public bool _AlterouVenda { get; set; }

        public DateTime _Emissao { get; set; }

        public string _CompraNumero { get; set; }

        public string _NumeroFatura { get; set; }

        public List<ReceitasDespesas> _ListaReceitaDespesas { get; set; }

        //Botão Finalizar
        public string _FormaPagamentoCupomFiscal { get; set; }


        #endregion

        #region Métodos

        public void ExcluirBaixa(int receitasDespesasId)
        {
            ReceitasDespesasBaixas receitasDespesasBaixas = new ReceitasDespesasBaixas();
            receitasDespesasBaixas.ReceitasDespesasId = receitasDespesasId;

            receitasDespesasBaixasNegocios.Excluir(receitasDespesasBaixas);
        }


        private void OrganizarParcela()
        {
            int _quantidadeLinhaVisivel = 0;
            int _quantidadeParcelas = 1;
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Visible)
                {
                    _quantidadeLinhaVisivel++;
                }
            }
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].Visible)
                {
                    grid.Rows[i].Cells["Parcela_"].Value = _quantidadeParcelas + "/" + _quantidadeLinhaVisivel;
                    _quantidadeParcelas++;
                }
            }
        }


        private void CalculaTroco()
        {
            try
            {
                if (Convert.ToDecimal(txtPagando.Text) > Convert.ToDecimal(txtRestantePagar.Text))
                {
                    txtTroco.Text = (Convert.ToDecimal(txtPagando.Text) - Convert.ToDecimal(txtRestantePagar.Text)).ToString("N2");
                }
                else
                {
                    txtTroco.Text = "0,00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cálcular o troco!\n\nPor favor informe ao administrador do sistema.\n\nDetalhe técnico:" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void VerificaTaxaCartao(decimal total, int formaPagamento, int quantidadeParcelas)
        {
            try
            {
                _ValorTaxa = ((total * formaPagamentoNegocios.PesquisarPercentualTaxa(formaPagamento)) / 100) / quantidadeParcelas;
            }
            catch
            { }
        }


        private void VerificarCaixa()
        {
            try
            {
                int usuarioAbriuCaixa = caixaNegocios.VerificarSeCaixaEstaAberto();
                if (usuarioAbriuCaixa == 0)
                {
                    MessageBox.Show("Por favor, efetue a abertura do caixa!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    int UsuarioAbriuCaixa = caixaNegocios.VerificarUsuarioAbriuCaixa(usuarioAbriuCaixa);
                    if (FrmLogin.usuarioId != UsuarioAbriuCaixa)
                    {
                        MessageBox.Show("Não é possivel concluir o pedido, usuário logado não é o mesmo que abriu o caixa!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            catch
            { }
        }

        private void CarregaFormasPagamento()
        {
            cbbFormaPagamento.DisplayMember = "Descricao";
            cbbFormaPagamento.ValueMember = "FormaPagamentoId";
            DataTable dtForma = formaPagamentoNegocios.PesquisarFormasReceitasCombobox();
            cbbFormaPagamento.DataSource = dtForma;
            cbbFormaPagamento.SelectedIndex = -1;
        }

        private void CalcularRestante()
        {
            decimal totalGrid = 0;

            if (grid.Rows.Count > 0)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(grid.Rows[i].Cells["PagouComCartão_"].Value).Equals(false))
                        totalGrid += Convert.ToDecimal(grid.Rows[i].Cells["Valor_"].Value);
                }

                decimal valor = 0;
                if (txtPercentualDesconto.Text.Trim().Length > 0)
                    valor = (Convert.ToDecimal(txtValorTotal.Text) * (Convert.ToDecimal(txtPercentualDesconto.Text) / 100));

                totalGrid += Convert.ToDecimal(Convert.ToDecimal(valor).ToString("N2"));
            }

            txtRestantePagar.Text = (Convert.ToDecimal(txtValorTotal.Text) - totalGrid).ToString("N2");

            if (txtRestantePagar.Text != "0,00" && grid.Rows.Count > 0)
            {
                if ((Convert.ToDecimal(txtRestantePagar.Text) > (Convert.ToDecimal("-0,10"))) && (Convert.ToDecimal(txtRestantePagar.Text) < (Convert.ToDecimal("0,10"))))
                {
                    try
                    {
                        if ((Convert.ToDecimal(txtRestantePagar.Text) <= Convert.ToDecimal("0,10")) ||
                            (Convert.ToDecimal(txtRestantePagar.Text) < 0))
                        {
                            decimal valor = Convert.ToDecimal(txtRestantePagar.Text);
                            txtRestantePagar.Text = "0,00";

                            if (grid.Rows[grid.Rows.Count - 1].Visible)
                                grid.Rows[grid.Rows.Count - 1].Cells["Valor_"].Value = Convert.ToDecimal(grid.Rows[grid.Rows.Count - 1].Cells["Valor_"].Value) - (valor) * (-1);
                            else
                                grid.Rows[grid.Rows.Count - 2].Cells["Valor_"].Value = Convert.ToDecimal(grid.Rows[grid.Rows.Count - 2].Cells["Valor_"].Value) - (valor) * (-1);

                            return;
                        }
                    }
                    catch { }
                }
            }

            if (grid.Rows.Count > 0 && txtRestantePagar.Text == "0,00")
            {
                btnConfirmar.Enabled = true;
            }

            if (txtRestantePagar.Text != "0,00")
                cbbFormaPagamento.Focus();
            else
                btnConfirmar.Focus();

            if (btnConfirmar.Enabled)
                btnConfirmar.Focus();

            if (_AlterouVenda)
                btnAdicionar.Enabled = false;
        }


        #endregion


        private void FrmFormasPagamento_Load(object sender, EventArgs e)
        {
            CarregaFormasPagamento();

            txtValorTotal.Text = _Valortotal.ToString("N2");
            txtRestantePagar.Text = _Valortotal.ToString("N2");
            btnConfirmar.Enabled = false;

            if (_AlterouVenda == true)
                btnAdicionar.Enabled = false;
            else
                btnAdicionar.Enabled = true;

            btnConfirmar.Enabled = false;
            btnAdicionar.Enabled = grid.Rows.Count == 0;

            if (_FormaPagamentoId != 0)
            {
                cbbFormaPagamento.SelectedValue = _FormaPagamentoId;
                txtPagando.Focus();
                txtPagando.Text = "0,00";
            }
            else
            {
                cbbFormaPagamento.SelectedIndex = -1;
                cbbFormaPagamento.Select();
                cbbFormaPagamento.Focus();
            }

            CalcularRestante();

            //Calcula o valor total atual                                
            valorTotalParcelasJaExistia = 0;
            foreach (DataGridViewRow row in grid.Rows)
            {
                decimal valorParcela = 0;
                //Pega o valor na grid
                Decimal.TryParse(row.Cells["Valor_"].Value.ToString(), out valorParcela);

                //Soma no total
                valorTotalParcelasJaExistia += valorParcela;
            }
        }

        private void FrmFormasPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        #region EVENTOS cbbFormaPagamento

        private void cbbFormaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPercentualDesconto.Focus();
            }
        }

        private void cbbFormaPagamento_Leave(object sender, EventArgs e)
        {
            if (txtPercentualDesconto.Text.Trim().Length <= 0)
                txtPercentualDesconto.Focus();
            else
                txtPagando.Focus();

            if (!string.IsNullOrEmpty(cbbFormaPagamento.Text))
            {
                FormaPagamento formasPagamentos = new FormaPagamento();
                formasPagamentos = formaPagamentoNegocios.PesquisarFormaPagamento(Convert.ToInt32(cbbFormaPagamento.SelectedValue));

                if (formasPagamentos.StatusId > 0)
                    statusId = formasPagamentos.StatusId;
            }
        }

        List<PrazosFormaPagamento> lstPrazos = new List<PrazosFormaPagamento>();
        string[] arrai = new string[7];
        private void cbbFormaPagamento_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(cbbFormaPagamento.Text))
                {
                    DataTable dtable = new DataTable();
                    dtable = formaPagamentoPrazosNegocios.PesquisarPorCodigo(Convert.ToInt32(cbbFormaPagamento.SelectedValue));
                    lstPrazos.Clear(); quantidadeParcela = 0;

                    foreach (DataRow r in dtable.Rows)
                    {
                        PrazosFormaPagamento prazosFormaPagamento = new PrazosFormaPagamento();
                        prazosFormaPagamento.Id = Convert.ToInt32(r["FormaPagamentoId"].ToString());
                        prazosFormaPagamento.Prazo = Convert.ToInt32(r["Valor"].ToString());
                        prazosFormaPagamento.Cartao = Convert.ToInt32(r["FormaCartao"].ToString());

                        lstPrazos.Add(prazosFormaPagamento);

                        quantidadeParcela++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na operação realizada!\n\nDetalhe técnico:" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region EVENTO txtValorTotal

        private void txtValorTotal_Enter(object sender, EventArgs e)
        {
            if (txtValorTotal.Text.Equals("0,00") || string.IsNullOrEmpty(txtValorTotal.Text))
            {
                txtValorTotal.Clear();
                txtValorTotal.Focus();
            }
        }

        #endregion

        #region EVENTOS txtPercentualDesconto

        private void txtPercentualDesconto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString() == ",")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtPercentualDesconto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count <= 0)
                {
                    if (txtPercentualDesconto.Text.Trim().Length > 0)
                    {
                        _ValorDesconto = (Convert.ToDecimal(txtValorTotal.Text) * (Convert.ToDecimal(txtPercentualDesconto.Text) / 100));
                        txtRestantePagar.Text = (Convert.ToDecimal(txtValorTotal.Text) - _ValorDesconto).ToString("N2");
                    }
                    else
                        txtRestantePagar.Text = txtValorTotal.Text;

                    txtPagando.Focus();
                }
            }
            catch
            { }
        }




        #endregion

        #region EVENTOS txtPagando

        private void txtPagando_Enter(object sender, EventArgs e)
        {
            if (txtPagando.Text == "0,00")
                txtPagando.Clear();
        }

        private void txtPagando_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString() == ",")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtPagando_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtPagando.Text.Trim().Length > 0)
                {
                    txtPagando.Text = Convert.ToDecimal(txtPagando.Text).ToString("N2");
                }
                else
                    txtPagando.Text = "0,00";
            }
            catch
            { }
        }


        #endregion

        #region EVENTOS NumericUpDown

        private void numVencimentoTodoDia_ValueChanged(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                if (numVencimentoTodoDia.Value > 0)
                {
                    string PrimeiroMes = Convert.ToDateTime(grid.Rows[0].Cells["Vencimento_"].Value.ToString()).ToString("MM");

                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            grid.Rows[i].Cells["Vencimento_"].Value = numVencimentoTodoDia.Value.ToString().PadLeft(2, '0') + grid.Rows[i].Cells["Vencimento_"].Value.ToString().Substring(2, 8);
                        }
                        else
                        {
                            string Data = Convert.ToDateTime(grid.Rows[i - 1].Cells["Vencimento_"].Value).AddMonths(Convert.ToInt32(1)).ToString("dd/MM/yyyy");
                            grid.Rows[i].Cells["Vencimento_"].Value = Data;
                        }
                    }
                }
            }
        }

        private void numPrimeiroMes_ValueChanged(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                if (numPrimeiroMes.Value > 0)
                {
                    string PrimeiroMes = Convert.ToDateTime(grid.Rows[0].Cells["Vencimento_"].Value.ToString()).ToString("MM");
                    for (int i = 0; i < grid.Rows.Count; i++)
                    {
                        if (i == 0)
                        {
                            grid.Rows[i].Cells["Vencimento_"].Value = grid.Rows[i].Cells["Vencimento_"].Value.ToString().Substring(0, 3) +
                                                                     numPrimeiroMes.Value.ToString().PadLeft(2, '0') +
                                                                     grid.Rows[i].Cells["Vencimento_"].Value.ToString().Substring(5, 5);
                        }
                        else
                        {
                            string Data = Convert.ToDateTime(grid.Rows[i - 1].Cells["Vencimento_"].Value).AddMonths(Convert.ToInt32(1)).ToString("dd/MM/yyyy");
                            grid.Rows[i].Cells["Vencimento_"].Value = grid.Rows[i].Cells["Vencimento_"].Value.ToString().Substring(0, 3) + Data.Substring(3, 7);
                        }
                    }
                }
            }
        }


        #endregion

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cbbFormaPagamento.Text))
                {
                    MessageBox.Show("Por favor, escolha a Forma de Pagamento!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbFormaPagamento.Focus();
                    return;
                }

                VerificarCaixa();

                numVencimentoTodoDia.Value = 0;
                DateTime dataAtual = _Emissao;


                if (txtPagando.Text.Trim() != "0,00")
                {
                    for (int i = 0; i < lstPrazos.Count; i++)
                    {
                        if (lstPrazos[0].Cartao != 1)
                        {
                            if (txtPagando.Text.Equals("") || txtPagando.Text.Equals("0,00"))
                            {
                                VerificaTaxaCartao(Convert.ToDecimal(txtRestantePagar.Text), Convert.ToInt32(cbbFormaPagamento.SelectedValue), lstPrazos.Count);
                            }
                            else
                            {
                                VerificaTaxaCartao(Convert.ToDecimal(txtPagando.Text) <= Convert.ToDecimal(txtRestantePagar.Text) ? Convert.ToDecimal(txtPagando.Text) : Convert.ToDecimal(txtRestantePagar.Text),
                                                   Convert.ToInt32(cbbFormaPagamento.SelectedValue), lstPrazos.Count);
                            }
                        }


                        vencimento = string.Empty;
                        if (lstPrazos[i].Prazo.Equals(0))
                        {
                            status = "PG";
                            pagamento = _Emissao.ToString("dd/MM/yyyy");
                            status = Convert.ToDecimal((Convert.ToDecimal(txtPagando.Text) - Convert.ToDecimal(txtTroco.Text) - _ValorTaxa) / quantidadeParcela).ToString("N2");
                            possuiDuplicataPagas = true;
                        }
                        else
                        {
                            status = "AB";

                            pagamento = null;
                            valorPago = null;
                        }

                        if (status == "AB")
                            _TotalValorAberto += Convert.ToDecimal(Convert.ToDecimal(txtRestantePagar.Text) / quantidadeParcela);

                        if (Convert.ToDecimal(txtPagando.Text) < Convert.ToDecimal(txtRestantePagar.Text))
                        {
                            vencimento = dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy");

                            if (numVencimentoTodoDia.Value > 0)
                                vencimento = numVencimentoTodoDia.Value.ToString().PadLeft(2, '0') + vencimento.Substring(2, 8);

                            grid.Rows.Add(dataAtual,
                                          numVencimentoTodoDia.Value.Equals(0) ? dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy") : vencimento,
                                          _ClienteId,
                                          cbbFormaPagamento.SelectedValue,
                                          cbbFormaPagamento.Text,
                                          Convert.ToDecimal((Convert.ToDecimal(txtPagando.Text)) / quantidadeParcela).ToString("N2"),
                                          (i + 1) + "/" + quantidadeParcela,
                                          "Referente ao " + (_Tipo.Equals("P") ? "Compra" : "Pedido: ") + _CompraNumero,
                                          status,
                                          valorPago,
                                          pagamento,
                                          false,
                                          statusId);
                            parcelas++;
                        }

                        if (_ValorTaxa > 0)
                        {
                            grid.Rows.Add(dataAtual, numVencimentoTodoDia.Value.Equals(0) ? dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy") : vencimento,
                                            cbbFormaPagamento.SelectedValue, _ClienteId, cbbFormaPagamento.Text, (_ValorTaxa).ToString("N2"), 1 + "/" + quantidadeParcela,
                                            "Referente a taxa do cartão do Pedido: " + _CompraNumero,
                                            grid.Rows[grid.Rows.Count - 1].Cells["StatusPagamento_"].Value.ToString().Equals("AB") ? "AB" : "PG", null, pagamento, true, statusId);

                            _ValorTaxa = 0;

                            grid.Rows[grid.Rows.Count - 1].Visible = false;
                        }
                    }
                }
                else // ENTER DIRETO
                {
                    for (int i = 0; i < lstPrazos.Count; i++) //1° passo
                    {
                        if (lstPrazos[0].Cartao != 1)
                        {
                            if (txtPagando.Text.Equals("") || txtPagando.Text.Equals("0,00"))
                            {
                                VerificaTaxaCartao(Convert.ToDecimal(txtRestantePagar.Text), Convert.ToInt32(cbbFormaPagamento.SelectedValue), lstPrazos.Count);
                            }
                            else
                            {
                                VerificaTaxaCartao(Convert.ToDecimal(txtPagando.Text), Convert.ToInt32(cbbFormaPagamento.SelectedValue), lstPrazos.Count);
                            }
                        }

                        vencimento = string.Empty;
                        if (lstPrazos[i].Prazo.Equals(0))
                        {
                            //2° passo
                            status = "PG";
                            pagamento = _Emissao.ToString("dd/MM/yyyy");
                            valorPago = Convert.ToDecimal((Convert.ToDecimal(txtRestantePagar.Text) - Convert.ToDecimal(txtTroco.Text) - _ValorTaxa) / quantidadeParcela).ToString("N2");
                            possuiDuplicataPagas = true;
                        }
                        else
                        {
                            status = "AB";
                            pagamento = null;
                            valorPago = null;
                        }

                        if (status == "AB")
                            _TotalValorAberto += Convert.ToDecimal(Convert.ToDecimal(txtRestantePagar.Text) / quantidadeParcela);

                        //3° passo
                        vencimento = dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy");
                        if (numVencimentoTodoDia.Value > 0)
                            vencimento = numVencimentoTodoDia.Value.ToString().PadLeft(2, '0') + vencimento.Substring(2, 8);

                        grid.Rows.Add(dataAtual, numVencimentoTodoDia.Value.Equals(0) ? dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy") : vencimento,
                        cbbFormaPagamento.SelectedValue, _ClienteId, cbbFormaPagamento.Text, Convert.ToDecimal((Convert.ToDecimal(txtRestantePagar.Text)) / quantidadeParcela).ToString("N2"),
                        (i + 1) + "/" + quantidadeParcela, "Referente ao " + (_Tipo.Equals("P") ? "Compra" : "Venda: ") + _CompraNumero, status, valorPago, pagamento, false,
                        statusId);

                        parcelas++;

                        if (_ValorTaxa > 0)
                        {
                            grid.Rows.Add(dataAtual, numVencimentoTodoDia.Value.Equals(0) ? dataAtual.AddDays(Convert.ToInt32(lstPrazos[i].Prazo)).ToString("dd/MM/yyyy") : vencimento,
                                            cbbFormaPagamento.SelectedValue, _ClienteId, cbbFormaPagamento.Text, (_ValorTaxa).ToString("N2"), 1 + "/" + quantidadeParcela,
                                            "Referente a taxa do cartão da Venda: " + _CompraNumero, grid.Rows[grid.Rows.Count - 1].Cells["StatusPagamento_"].Value.ToString().Equals("AB") ? "AB" : "PG",
                                            null, pagamento, true, statusId);
                            _ValorTaxa = 0;

                            grid.Rows[grid.Rows.Count - 1].Visible = false;
                        }
                    }
                }

                //4° passo
                CalculaTroco();
                OrganizarParcela();
                CalcularRestante();

                txtPagando.Text = "0,00";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro na operação realizada!\n\nDetalhe técnico:" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntExcluirParcelas_Click(object sender, EventArgs e)
        {
            try
            {
                cbbFormaPagamento.Focus();

                if (grid.Rows.Count > 0)
                {
                    _TotalValorAberto = 0;
                    grid.Rows.Clear();
                    _AlterouVenda = false;
                    txtRestantePagar.Text = txtValorTotal.Text;

                    CalcularRestante();
                    btnConfirmar.Enabled = false;
                }

                txtPercentualDesconto.Clear();
                quantidadeParcela = statusId = 0;

                cbbFormaPagamento_SelectedIndexChanged(sender, e);
                cbbFormaPagamento.Focus();
            }
            catch
            { }
        }


        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Verifica se tem pendencia financeira vencida

                //if (objConfigInfo.Config_VerificarPendenciaFinanceiraEmAtraso)
                //{
                //    if (totalValorAberto > 0 && CodigoCliente > 0)
                //    {
                //        if (FrmPrincipal.dadosConfiguracao.Config_Financeiro_ValidarPendenciaFinanceiroEmDias <= 0)
                //        {
                //            //Ja existia isso no sistema antes de colocar a quantidade de dias na configuracao do sistema, quem estiver usando vai funcionar normal (By Pedro)
                //            if (_objReceitaDespesaControl.PesquisarPendenciaFinanceira(CodigoCliente) > 0)
                //            {
                //                MessageBox.Show("Cliente possui pendências financeiras!\n\n" + (!objPermissaoVenderContasEmAtrasoInfo.PermSalv ? "Usuário logado não tem permissão para concluir quando o cliente tem parcelas em atraso, consulte o gerente!" : ""), "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //                if (!objPermissaoVenderContasEmAtrasoInfo.PermSalv)
                //                    return;
                //            }
                //        }
                //        else
                //        {
                //            if (_objReceitaDespesaControl.VerificaPendenciaFinanceiraEmDias(CodigoCliente, FrmPrincipal.dadosConfiguracao.Config_Financeiro_ValidarPendenciaFinanceiroEmDias))
                //            {
                //                _Mensagens.MensagensAviso("Cliente possui débito superior à " + FrmPrincipal.dadosConfiguracao.Config_Financeiro_ValidarPendenciaFinanceiroEmDias.ToString() + " dias, informe a senha do vendedor supervisor para prosseguir com a venda.");
                //                FrmGetSenha frmGetSenha = new FrmGetSenha();
                //                frmGetSenha.ShowInTaskbar = false;
                //                frmGetSenha.ShowDialog();
                //                if (string.IsNullOrEmpty(frmGetSenha.SenhaInformada))
                //                {
                //                    _Mensagens.MensagensAviso("Por favor informe a senha de supervisor para prosseguir com a venda!");
                //                    return;
                //                }

                //                if (!_objFuncionarioControl.ValidarSenhaFuncionarioSupervisor(frmGetSenha.SenhaInformada))
                //                {
                //                    _Mensagens.MensagensAviso("Senha informada não é uma senha válida de supervisor, por favor verifique!");
                //                    return;
                //                }
                //            }
                //        }
                //    }
                //}

                #endregion

                #region Verifica o limite de crédito do cliente

                //if (CodigoCliente > 0)
                //{
                //    if (_objClientesControl.PesquisarSeLimiteEstaAtivo(CodigoCliente) && _ImportoPedido.Equals(false))
                //    {
                //        decimal LimiteCliente = _objClientesControl.PesquisarLimiteCliente(CodigoCliente);

                //        decimal DividaCliente = _objReceitaDespesaControl.PesquisarDividaTotalCliente(CodigoCliente);

                //        if ((TotalEmAberto + DividaCliente - valorTotalParcelasJaExistia) > LimiteCliente)
                //        {
                //            if (!objPermissaoBloquearVendasLimitiUltrapassar.PermSalv)
                //            {
                //                if (_Mensagens.MensagensConfirma("O Limite de crédito do cliente foi ultrapassado! \n\nLimite do cliente: " + LimiteCliente + "!\nDivida do cliente: " + DividaCliente + "!\nDivida do cliente após esse Pedido: " + (TotalEmAberto + DividaCliente) + "!\n\nDeseja Continuar?") == false)
                //                    return;
                //            }
                //            else
                //            {
                //                _Mensagens.MensagensAviso("O Limite de crédito do cliente foi ultrapassado! \n\nLimite do cliente: " + LimiteCliente + "!\nDivida do cliente: " + DividaCliente + "!\nDivida do cliente após esse Pedido: " + (TotalEmAberto + DividaCliente) + "\n\nUsuário logado não tem permissão para vender a prazo quando ultrapassar o limite do cliente, Consulte o gerente!");
                //                return;
                //            }
                //        }
                //    }
                //}

                #endregion

                if (grid.Rows.Count > 0)
                    _FormaPagamentoCupomFiscal = grid.Rows[0].Cells["FormaPagamento_"].Value.ToString();

                DataTable dtReceitas = new DataTable();
                List<ReceitasDespesas> listaReceitaDespesas = new List<ReceitasDespesas>();

                if (grid.Rows.Count > 0)
                {
                    if (possuiDuplicataPagas == true)
                    {
                        foreach (DataGridViewRow gridRow in grid.Rows)
                        {
                            ReceitasDespesas receitasDespesas = new ReceitasDespesas();

                            if (Convert.ToInt32(gridRow.Cells["ClientesId_"].Value) > 0)
                                receitasDespesas.ClientesId = Convert.ToInt32(gridRow.Cells["ClientesId_"].Value);

                            receitasDespesas.Emissao = _Emissao;
                            receitasDespesas.Vencimento = Convert.ToDateTime(gridRow.Cells["Vencimento_"].Value);
                            receitasDespesas.Observacao = gridRow.Cells["Observacao_"].Value.ToString();
                            receitasDespesas.Parcela = gridRow.Cells["Parcela_"].Value.ToString();
                            _FormaPagamentoId = Convert.ToInt32(gridRow.Cells["FormaPagamentoId_"].Value);
                            receitasDespesas.Valor = Convert.ToDecimal(gridRow.Cells["Valor_"].Value);
                            receitasDespesas.FormaPagamentoId = Convert.ToInt32(gridRow.Cells["FormaPagamentoId_"].Value.ToString());
                            if (Convert.ToDecimal(gridRow.Cells["Valor_"].Value) > 0)
                                receitasDespesas.ValorExtenso = Util.NumeroParaExtenso(Convert.ToDecimal(gridRow.Cells["Valor_"].Value));
                            else
                                receitasDespesas.ValorExtenso = "VALOR NEGATIVO";
                            receitasDespesas.NumeroDocumento = _NumeroFatura;
                            receitasDespesas.ValorFatura = Convert.ToDecimal(txtValorTotal.Text);

                            if (Convert.ToInt32(gridRow.Cells["ClientesId_"].Value) > 0)
                            {
                                receitasDespesas.MultaAposVencimentoPercentualValor = 0;
                                receitasDespesas.MultaAoDiaPercentualValor = 0;
                                receitasDespesas.MultaAposVencimento = 0;
                                receitasDespesas.MultaPorDia = 0;
                            }
                            else //CLIENTE NÃO IDENTIFICADO
                            {
                                receitasDespesas.MultaAposVencimento = 0;
                                receitasDespesas.MultaPorDia = 0;
                            }

                            receitasDespesas.PagouComCartão = Convert.ToBoolean(gridRow.Cells["PagouComCartão_"].Value);

                            if (Convert.ToString(gridRow.Cells["StatusPagamento_"].Value) == "PG")
                            {
                                receitasDespesas.StatusPagamento = "PG";
                                receitasDespesas.DataPagamento = Convert.ToDateTime(gridRow.Cells["DataPagamento_"].Value); //adicionar hora
                                receitasDespesas.ValorPago = Convert.ToDecimal(gridRow.Cells["ValorPago_"].Value);
                                receitasDespesas.Pagando = true;
                            }

                            listaReceitaDespesas.Add(receitasDespesas);
                        }

                        _ListaReceitaDespesas = listaReceitaDespesas;

                        _GravouFormaPagamento = true;
                        _Troco = Convert.ToDecimal(txtTroco.Text);

                        this.Close();
                    }
                    else // Entra aqui se o pagamento for PARCELADO
                    {
                        foreach (DataGridViewRow gridRow in grid.Rows)
                        {
                            ReceitasDespesas receitasDespesas = new ReceitasDespesas();

                            if (Convert.ToInt32(gridRow.Cells["ClientesId_"].Value) > 0)
                                receitasDespesas.ClientesId = Convert.ToInt32(gridRow.Cells["ClientesId_"].Value);

                            receitasDespesas.Emissao = _Emissao;
                            receitasDespesas.Vencimento = Convert.ToDateTime(gridRow.Cells["Vencimento_"].Value);
                            receitasDespesas.Observacao = gridRow.Cells["Observacao_"].Value.ToString();
                            receitasDespesas.Parcela = gridRow.Cells["Parcela_"].Value.ToString();
                            _FormaPagamentoId = Convert.ToInt32(gridRow.Cells["FormaPagamentoId_"].Value);
                            receitasDespesas.Valor = Convert.ToDecimal(gridRow.Cells["Valor_"].Value);
                            receitasDespesas.FormaPagamentoId = Convert.ToInt32(gridRow.Cells["FormaPagamentoId_"].Value.ToString());
                            if (Convert.ToDecimal(gridRow.Cells["Valor_"].Value) > 0)
                                receitasDespesas.ValorExtenso = Util.NumeroParaExtenso(Convert.ToDecimal(gridRow.Cells["Valor_"].Value));
                            else
                                receitasDespesas.ValorExtenso = "VALOR NEGATIVO";
                            receitasDespesas.NumeroDocumento = _NumeroFatura;
                            receitasDespesas.ValorFatura = Convert.ToDecimal(txtValorTotal.Text);

                            if (Convert.ToInt32(gridRow.Cells["ClientesId_"].Value) > 0)
                            {
                                receitasDespesas.MultaAposVencimentoPercentualValor = 0;
                                receitasDespesas.MultaAoDiaPercentualValor = 0;
                                receitasDespesas.MultaAposVencimento = 0;
                                receitasDespesas.MultaPorDia = 0;
                            }
                            else //CLIENTE NÃO IDENTIFICADO
                            {
                                receitasDespesas.MultaAposVencimento = 0;
                                receitasDespesas.MultaPorDia = 0;
                            }

                            receitasDespesas.PagouComCartão = Convert.ToBoolean(gridRow.Cells["PagouComCartão_"].Value);

                            if (Convert.ToString(gridRow.Cells["StatusPagamento_"].Value) == "PG")
                            {
                                receitasDespesas.StatusPagamento = "PG";
                                receitasDespesas.DataPagamento = Convert.ToDateTime(gridRow.Cells["ReDeDtPg"].Value);
                                receitasDespesas.ValorPago = Convert.ToDecimal(gridRow.Cells["ReDeValo"].Value);
                                receitasDespesas.Pagando = true;
                            }

                            listaReceitaDespesas.Add(receitasDespesas);
                        }

                        _ListaReceitaDespesas = listaReceitaDespesas;
                        _GravouFormaPagamento = true;

                        if (_NumeroDocumentoVenda > 0)
                        {
                            //BUSCANDO AS DUPLICATAS QUE JA FORAM PAGAS REFERENTE A VENDA
                            DataTable dtaDuplicatas = new DataTable();
                            dtaDuplicatas = receitasDespesasNegocios.PesquisarReceitaDespesaPorCodigoCompraVendaStatus(_NumeroDocumentoVenda, string.Empty);

                            if (dtaDuplicatas.Rows.Count > 0)
                            {
                                for (int i = 0; i < dtaDuplicatas.Rows.Count; i++)
                                {
                                    //CONSULTA OS MOVIMENTOS PARA ALTERAR O SALDO DO CAIXA
                                    DataTable dtaMovimento = new DataTable();
                                    dtaMovimento = movimentacaoCaixaNegocios.PesquisarMovimento_ReceitaDespesa(Convert.ToInt32(dtaDuplicatas.Rows[i]["ReceitasDespesasId_"].ToString()));
                                    if (dtaMovimento.Rows.Count > 0)
                                    {
                                        if (dtaMovimento.Rows[0]["Tipo"].ToString() == "R") //Receita
                                        {
                                            //TIRAR DA CAIXA
                                            Caixa caixa = caixaNegocios.PesquisarSaldoCaixa(Convert.ToInt32(dtaMovimento.Rows[0]["CaixaId"].ToString()));
                                            caixa.Valor -= Convert.ToInt32(dtaMovimento.Rows[0]["Valor"].ToString());
                                            caixaNegocios.AlterarSaldo(caixa);
                                        }
                                        else
                                        {
                                            //ACRESCENTAR NA CAIXA
                                            Caixa caixa = caixaNegocios.PesquisarSaldoCaixa(Convert.ToInt32(dtaMovimento.Rows[0]["CaixaId"].ToString()));
                                            caixa.Valor += Convert.ToInt32(dtaMovimento.Rows[0]["Valor"].ToString());
                                            caixaNegocios.AlterarSaldo(caixa);
                                        }

                                        //CAIXA NOVO
                                        movimentacaoCaixaNegocios.Excluir(Convert.ToInt32(dtaMovimento.Rows[0]["MovimentacaoCaixaId"].ToString()));

                                        //LancamentoCaixaDoPedidosInfo objLancamentoCaixaInfo = new LancamentoCaixaDoPedidosInfo();
                                        //objLancamentoCaixaInfo.MovimentoContaID = Convert.ToInt32(dtaMovimento.Rows[0]["MoviCodi"].ToString());
                                        //_objLancamentoCaixaControl.Excluir(objLancamentoCaixaInfo);

                                        //EXCLUINDO A MOVIMENTAÇAO QUE FOI PAGA
                                        ObjetoTransferencia.MovimentacaoCaixa movimentacaoCaixa = new ObjetoTransferencia.MovimentacaoCaixa();
                                        movimentacaoCaixa.ReceitasDespesasId = Convert.ToInt32(dtaDuplicatas.Rows[i]["ReceitasDespesasId"].ToString());
                                        movimentacaoCaixaNegocios.Excluir(movimentacaoCaixa);
                                    }

                                    ExcluirBaixa(Convert.ToInt32(dtaDuplicatas.Rows[i]["ReceitasDespesasId"].ToString()));
                                    //ExcluirBoleto(Convert.ToInt32(dtaDuplicatas.Rows[i]["ReceitasDespesasId"].ToString()));
                                }
                            }

                            //EXCLUINDO AS DUPLICATAS
                            //foreach (DataRow rv in dtaDuplicatas.Rows)
                            //{
                            //    LancamentoCaixaDoPedidosInfo objLancamentoCaixaInfo = new LancamentoCaixaDoPedidosInfo();
                            //    objLancamentoCaixaInfo.ReceitaID = Convert.ToInt32(rv["ReDeCodi"]);
                            //    _objLancamentoCaixaControl.ExcluirReceita(objLancamentoCaixaInfo);
                            //}

                            ReceitasDespesas receitasDespesas = new ReceitasDespesas();

                            receitasDespesas.ReceitasDespesasId = _NumeroDocumentoVenda;
                            receitasDespesasNegocios.ExcluirReceitaDespesaCompraVenda(receitasDespesas);
                        }

                        _Troco = Convert.ToDecimal(txtTroco.Text);
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, informe uma Forma de pagamento.", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbFormaPagamento.Select();
                    cbbFormaPagamento.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar a venda.\nPor favor, entre em contato com o suporte técnico.\n\nDetalhe técnico:" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPercentualDesconto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == e.KeyCode)
            {
                txtPagando.SelectAll();
                txtPagando.Focus();
            }
        }

        private void txtPagando_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == e.KeyCode)
            {
                btnAdicionar.Select();
                btnAdicionar.Focus();
            }
        }
    }
}
