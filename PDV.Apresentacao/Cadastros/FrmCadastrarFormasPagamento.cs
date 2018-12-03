using PDV.AcessoBancoDados;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmCadastrarFormasPagamento : Form
    {
        public FrmCadastrarFormasPagamento()
        {
            InitializeComponent();
        }

        #region Propriedades

        readonly FormaPagamentoNegocios formaPagamentoNegocios = new FormaPagamentoNegocios();
        readonly FormaPagamentoPrazosNegocios formaPagamentoPrazosNegocios = new FormaPagamentoPrazosNegocios();
        readonly Conexao conexao = new Conexao();

        #endregion

        #region Variáveis

        int formaPagamentoId = 0;
        DataTable dtGrid = new DataTable();
        string valorCelula = string.Empty;

        #endregion

        #region Métodos

        private void Carregar(int _formaPagamentoId)
        {
            try
            {
                DataTable dtForma = formaPagamentoNegocios.PesquisarPorCodigo(_formaPagamentoId);
                formaPagamentoId = Convert.ToInt32(dtForma.Rows[0]["FormaPagamentoId"].ToString());

                txtDescricao.Text = dtForma.Rows[0]["Descricao"].ToString();
                chkAtivo.Checked = Convert.ToBoolean(dtForma.Rows[0]["Ativo"].ToString());

                numPrimeiroVencimento.Value = 0;
                if (!string.IsNullOrEmpty(dtForma.Rows[0]["FormaPrimeiroVencimento"].ToString()))
                    numPrimeiroVencimento.Value = Convert.ToInt32(dtForma.Rows[0]["FormaPrimeiroVencimento"].ToString());

                numIntervaloEmDias.Value = 1;
                if (!string.IsNullOrEmpty(dtForma.Rows[0]["FormaIntervaloEmDias"].ToString()))
                    numIntervaloEmDias.Value = Convert.ToInt32(dtForma.Rows[0]["FormaIntervaloEmDias"].ToString());

                numQuantidadeParcelas.Value = 1;
                if (!string.IsNullOrEmpty(dtForma.Rows[0]["FormaParcelas"].ToString()))
                    numQuantidadeParcelas.Value = Convert.ToInt32(dtForma.Rows[0]["FormaParcelas"].ToString());

                if (Convert.ToInt32(dtForma.Rows[0]["FormaCartao"].ToString()) == 1)
                {
                    chkCredito.Checked = false; chkDebito.Checked = false;
                }
                else if (Convert.ToInt32(dtForma.Rows[0]["FormaCartao"].ToString()) == 2)
                {
                    chkDebito.Checked = true; chkCredito.Checked = false;
                }
                else
                {
                    chkDebito.Checked = false; chkCredito.Checked = true;
                }

                txtPercentual.Text = Convert.ToDecimal(dtForma.Rows[0]["FormaPercentualTaxa"].ToString()).ToString("N2"); // Percentual taxa de cartão

                //Carregar os prazos
                gridParcelas.Rows.Clear();
                DataTable dtPrazos = new DataTable();
                dtPrazos = formaPagamentoPrazosNegocios.PesquisarPorCodigo(formaPagamentoId);

                for (int i = 0; i < dtPrazos.Rows.Count; i++)
                {
                    gridParcelas.Rows.Add(dtPrazos.Rows[i]["Parcela"].ToString(),
                                          dtPrazos.Rows[i]["Valor"].ToString(),
                                          dtPrazos.Rows[i]["ValorCoeficiente"].ToString());
                }

                HabilitarCampos(true);

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                btnNovo.Text = "Cancelar [ F2 ]";
                btnSalvar.Text = "Alterar [ F5 ]";

                toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar o Forma de pagamento selecionada!\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AdicionarPrazos(int primeiroVencimento, int intervalorEmDias, int quantidadeVezes)
        {
            gridParcelas.Rows.Clear();
            int controle = 0;

            for (int i = 0; i < (int)numQuantidadeParcelas.Value; i++)
            {
                controle = gridParcelas.Rows.Count.Equals(0) ? primeiroVencimento : (controle + intervalorEmDias);
                gridParcelas.Rows.Add(i + 1, gridParcelas.Rows.Count.Equals(0) ? primeiroVencimento : controle, 100);
            }

            RateioCoeficiente();
        }

        private void RateioCoeficiente()
        {
            decimal Total = Convert.ToDecimal((100 / Convert.ToDecimal(gridParcelas.Rows.Count)).ToString("N2")); decimal TotalInserido = 0;

            for (int i = 0; i < gridParcelas.Rows.Count; i++)
            {
                gridParcelas.Rows[i].Cells["ValorCoeficiente"].Value = Total.ToString("N2");
                TotalInserido += Total;
            }

            if (TotalInserido < 100)
            {
                gridParcelas.Rows[0].Cells["ValorCoeficiente"].Value = (Convert.ToDecimal(gridParcelas.Rows[0].Cells["ValorCoeficiente"].Value) +
                                                                       (100 - TotalInserido)).ToString("N2");
            }
            else if (TotalInserido > 100)
            {
                gridParcelas.Rows[gridParcelas.Rows.Count - 1].Cells["ValorCoeficiente"].Value = (Convert.ToDecimal(gridParcelas.Rows[gridParcelas.Rows.Count - 1].Cells["ValorCoeficiente"].Value) -
                                                                                                 (TotalInserido - 100)).ToString("N2");
            }
        }

        private void CarregarGridFormasPagamento()
        {
            try
            {
                dtGrid = formaPagamentoNegocios.CarregarGridFormas();
                gridFormasPagamento.DataSource = dtGrid;

                formaPagamentoId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar as formas de pagamento cadastrados.\n\n" + ex, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InserirFormaPagamentoPrazos(int formaPagamentoPrazosId)
        {
            try
            {
                for (int i = 0; i < gridParcelas.Rows.Count; i++)
                {
                    FormaPagamentoPrazos formaPagamentoPrazos = new FormaPagamentoPrazos();

                    formaPagamentoPrazos.FormaPagamentoId = formaPagamentoPrazosId;
                    formaPagamentoPrazos.Parcela = Convert.ToInt32(gridParcelas.Rows[i].Cells["Parcela"].Value);
                    formaPagamentoPrazos.Valor = Convert.ToInt32(gridParcelas.Rows[i].Cells["Valor"].Value);
                    formaPagamentoPrazos.ValorCoeficiente = Convert.ToDecimal(gridParcelas.Rows[i].Cells["ValorCoeficiente"].Value);

                    formaPagamentoPrazosNegocios.Inserir(formaPagamentoPrazos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar inserir a Formas de pagamento prazos" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidaCampos()
        {
            string erro = string.Empty;

            if (txtDescricao.Text.Trim().Length <= 2)
            {
                erro = "Descrição inválida!";
            }
            if (gridParcelas.Rows.Count.Equals(0))
            {
                erro = erro + "\n" + "Informe os Prazos!";
            }
            if (chkCredito.Checked || chkDebito.Checked)
            {
                if (Convert.ToDecimal(txtPercentual.Text).Equals(0))
                {
                    erro = erro + "\n" + "Informe o Percentual da operadora do cartão!";
                }
            }
            if (erro != "")
            {
                MessageBox.Show("Os seguintes campos não foram informados : \n\n" + erro, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }

        private void HabilitarCampos(bool ativo)
        {
            foreach (Control obj in Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Enabled = ativo;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).Enabled = ativo;
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Enabled = ativo;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Enabled = ativo;
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Enabled = ativo;
                }
                if (obj is Button)
                {
                    ((Button)obj).Enabled = ativo;
                }
                if (obj is NumericUpDown)
                {
                    ((NumericUpDown)obj).Enabled = ativo;
                }
            }

            txtDescricao.Focus();
            chkDebito.Enabled = ativo;
            chkCredito.Enabled = ativo;
            txtPercentual.Enabled = ativo;
        }

        private void Limpar()
        {
            foreach (Control obj in Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Clear();
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Value = DateTime.Now;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).SelectedIndex = 0;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Clear();
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Checked = true;
                }
            }

            numPrimeiroVencimento.Value = 0;
            numIntervaloEmDias.Value = 1;
            numQuantidadeParcelas.Value = 1;

            gridParcelas.Rows.Clear();
            gridParcelas.Refresh();
        }

        #endregion

        private void FrmCadastrarFormasPagamento_Load(object sender, EventArgs e)
        {
            txtDescricao.Select();
            txtDescricao.Focus();
            CarregarGridFormasPagamento();
        }

        private void FrmCadastrarFormasPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.Alt && e.KeyCode == Keys.F4)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnNovo_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && btnSalvar.Enabled)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8 && btnExcluir.Enabled)
            {
                btnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        #region Botões menu

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled == false)
            {
                HabilitarCampos(true);
                Limpar();
                btnNovo.Text = "Cancelar [ F2 ]";
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                btnSalvar.Enabled = true;
            }
            else
            {
                HabilitarCampos(false);
                btnNovo.Text = "Novo [ F2 ]";
                btnSalvar.Text = "Salvar [ F5 ]";
                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Funcionário [ F2 ]");
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
            }

            formaPagamentoId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    FormaPagamento formaPagamento = new FormaPagamento();

                    formaPagamento.Descricao = txtDescricao.Text.Trim();
                    formaPagamento.Ativo = chkAtivo.Checked;
                    formaPagamento.FormaPrimeiroVencimento = Convert.ToInt32(numPrimeiroVencimento.Value);
                    formaPagamento.FormaIntervaloEmDias = Convert.ToInt32(numIntervaloEmDias.Value);
                    formaPagamento.FormaParcelas = Convert.ToInt32(numQuantidadeParcelas.Value);

                    if (chkDebito.Checked)
                    {
                        formaPagamento.FormaCartao = 2;
                        formaPagamento.FormaPercentualTaxa = Convert.ToDecimal(txtPercentual.Text);
                    }
                    else if (chkCredito.Checked)
                    {
                        formaPagamento.FormaCartao = 3;
                        formaPagamento.FormaPercentualTaxa = Convert.ToDecimal(txtPercentual.Text);
                    }
                    else
                        formaPagamento.FormaCartao = 1;

                    formaPagamento.Tipo = "R"; // Receita


                    //INSERIR
                    if (formaPagamentoId <= 0)
                    {
                        try
                        {
                            if (formaPagamentoNegocios.Inserir(formaPagamento))
                            {
                                //INSERINDO A FORMA DE PAGAMENTO PRAZOS
                                int ultimoId = conexao.RetornarUltimoId("FormaPagamento", "FormaPagamentoId");
                                InserirFormaPagamentoPrazos(ultimoId);

                                MessageBox.Show("Funcionário cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpar();
                                HabilitarCampos(false);

                                btnSalvar.Text = "Salvar [ F5 ]";
                                btnSalvar.Enabled = false;
                                btnExcluir.Enabled = false;
                                btnNovo.Text = "Novo [ F2 ]";

                                CarregarGridFormasPagamento();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao tentar cadastrar a forma de pagamento!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar cadastrar a forma de pagamento!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else //ALTERAR
                    {
                        try
                        {
                            formaPagamento.FormaPagamentoId = formaPagamentoId;

                            if (formaPagamentoNegocios.Alterar(formaPagamento))
                            {
                                //Excluindo a forma de pagamento prazos para incluir novamente
                                FormaPagamentoPrazos formaPagamentoPrazos = new FormaPagamentoPrazos();
                                formaPagamentoPrazos.FormaPagamentoId = formaPagamentoId;

                                if (formaPagamentoPrazosNegocios.Excluir(formaPagamentoPrazos))
                                {
                                    InserirFormaPagamentoPrazos(formaPagamentoId);

                                    MessageBox.Show("Forma de pagamento alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Limpar();
                                    HabilitarCampos(false);

                                    btnSalvar.Text = "Salvar [ F5 ]";
                                    btnSalvar.Enabled = false;
                                    btnExcluir.Enabled = false;
                                    btnNovo.Text = "Novo [ F2 ]";

                                    CarregarGridFormasPagamento();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Erro ao tentar atualizar a forma selecionada!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao executar operação solicitada!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                    formaPagamentoId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar a forma de pagamento!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                FormaPagamento formaPagamento = new FormaPagamento();
                formaPagamento.FormaPagamentoId = formaPagamentoId;

                if (MessageBox.Show("Deseja realmente excluir essa forma de pagamento?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Excluindo a forma de pagamento prazos para incluir novamente
                    FormaPagamentoPrazos formaPagamentoPrazos = new FormaPagamentoPrazos();
                    formaPagamentoPrazos.FormaPagamentoId = formaPagamentoId;
                    formaPagamentoPrazosNegocios.Excluir(formaPagamentoPrazos);

                    formaPagamentoNegocios.Excluir(formaPagamento);
                    MessageBox.Show("Forma de pagamento excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    HabilitarCampos(false);

                    btnSalvar.Text = "Salvar [ F5 ]";
                    btnSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnNovo.Text = "Novo [ F2 ]";

                    CarregarGridFormasPagamento();
                    formaPagamentoId = 0;
                }
                else
                {
                    Limpar();
                    HabilitarCampos(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir a Forma de pagamento!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            txtDescricao.Clear();
            Limpar();
        }

        #endregion

        #region NumericUpDown

        private void numPrimeiroVencimento_Leave(object sender, EventArgs e)
        {
            AdicionarPrazos(Convert.ToInt32(numPrimeiroVencimento.Value), Convert.ToInt32(numIntervaloEmDias.Value), Convert.ToInt32(numQuantidadeParcelas.Value));
        }

        private void numPrimeiroVencimento_ValueChanged(object sender, EventArgs e)
        {
            AdicionarPrazos(Convert.ToInt32(numPrimeiroVencimento.Value), Convert.ToInt32(numIntervaloEmDias.Value), Convert.ToInt32(numQuantidadeParcelas.Value));
        }

        private void numIntervaloEmDias_ValueChanged(object sender, EventArgs e)
        {
            AdicionarPrazos(Convert.ToInt32(numPrimeiroVencimento.Value), Convert.ToInt32(numIntervaloEmDias.Value), Convert.ToInt32(numQuantidadeParcelas.Value));
        }

        private void numQuantidadeParcelas_ValueChanged(object sender, EventArgs e)
        {
            AdicionarPrazos(Convert.ToInt32(numPrimeiroVencimento.Value), Convert.ToInt32(numIntervaloEmDias.Value), Convert.ToInt32(numQuantidadeParcelas.Value));
        }

        #endregion

        #region GridParcelas

        private void gridParcelas_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            valorCelula = gridParcelas.Rows[gridParcelas.CurrentRow.Index].Cells["Descricao"].Value.ToString();
        }

        private void gridParcelas_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridParcelas.Rows.Count > 0)
            {
                if (e.ColumnIndex == gridParcelas.Columns["Valor"].Index)
                {
                    try
                    {
                        gridParcelas.Rows[gridParcelas.CurrentRow.Index].Cells["Valor"].Value =
                        Convert.ToInt32(gridParcelas.Rows[gridParcelas.CurrentRow.Index].Cells["Valor"].Value);
                    }
                    catch
                    {
                        gridParcelas.Rows[gridParcelas.CurrentRow.Index].Cells["Valor"].Value = valorCelula;
                    }
                }
            }
        }

        #endregion

        #region Grid Formas de pagamento

        private void gridFormasPagamento_DoubleClick(object sender, EventArgs e)
        {
            if (gridFormasPagamento.Rows.Count > 0)
            {
                try
                {
                    Carregar(Convert.ToInt32(gridFormasPagamento.Rows[gridFormasPagamento.CurrentRow.Index].Cells["FormaPagamentoId_"].Value));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a forma de pagamento selecionada!\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

    }
}
