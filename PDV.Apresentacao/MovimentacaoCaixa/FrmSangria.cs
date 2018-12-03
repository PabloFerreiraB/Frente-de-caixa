using PDV.AcessoBancoDados;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.MovimentacaoCaixa
{
    public partial class FrmSangria : Form
    {
        public FrmSangria()
        {
            InitializeComponent();
        }

        #region Instâncias

        SangriaNegocios sangriaNegocios = new SangriaNegocios();
        CaixaNegocios caixaNegocios = new CaixaNegocios();

        #endregion

        #region Propriedades

        public enumSangriaOuSuprimento tipoOperacao { get; set; }

        #endregion

        #region Variáveis

        DataRow drUltimaAbertura;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Método

        private void CarregarGrid()
        {
            try
            {
                dtGrid = sangriaNegocios.CarregarGrid(DateTime.Now.AddYears(-1), DateTime.Now);
                grid.DataSource = dtGrid;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar as sangrias realizadas!\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PesquisarSaldoEmCaixa()
        {
            int ultimaAbertura = caixaNegocios.VerificarSeCaixaEstaAberto();

            if (ultimaAbertura > 0)
            {
                drUltimaAbertura = caixaNegocios.PesquisarPorCodigo(ultimaAbertura).Rows[0];
                if (drUltimaAbertura != null)
                {
                    txtSaldoAtual.Text = drUltimaAbertura["Valor"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Caixa fechado!\n\nPor favor efetue a abertura do caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSaldoAtual.Enabled = false;
                txtValorSangria.Enabled = false;
                txtSaldoApos.Enabled = false;
                txtObservacao.Enabled = false;
                btnSalvar.Enabled = false;
            }
        }


        #endregion

        private void FrmSangria_Load(object sender, EventArgs e)
        {
            try
            {
                PesquisarSaldoEmCaixa();
                CarregarGrid();

                txtValorSangria.Focus();
                if (tipoOperacao == enumSangriaOuSuprimento.Sangria)
                {
                    lblValor.Text = "Valor da sangria"; 
                    lblSaldoApos.Text = "Saldo após sangria";
                    this.Text = "Retirar dinheiro do Caixa";
                }
                else
                {
                    lblValor.Text = "Valor de suprimento";
                    lblSaldoApos.Text = "Saldo após suprimento";
                    this.Text = "Entrar com dinheiro no Caixa";
                }
            }
            catch
            { }
        }

        private void txtSaldoAtual_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtValorSangria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtSaldoApos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (tipoOperacao == enumSangriaOuSuprimento.Sangria)
            {
                if (Convert.ToDecimal(txtSaldoAtual.Text) >= Convert.ToDecimal(txtValorSangria.Text))
                {
                    if (MessageBox.Show("Confirma a sangria(retirada) em dinheiro do caixa no valor de R$ " + txtValorSangria.Text + ".", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Sangria sangria = new Sangria();
                        sangria.CaixaId = Convert.ToInt32(drUltimaAbertura["CaixaId"]);
                        sangria.UsuarioId = FrmLogin.usuarioId;
                        sangria.ValorCaixa = Convert.ToDecimal(txtSaldoAtual.Text);
                        sangria.ValorSangria = Convert.ToDecimal(txtValorSangria.Text);
                        sangria.ValorAposSangria = Convert.ToDecimal(txtSaldoApos.Text);
                        sangria.DataHora = DateTime.Now;
                        sangria.Tipo = 1;//Sangria
                        if (txtObservacao.Text.Trim().Length > 0)
                            sangria.Observacao = "Sangria - " + txtObservacao.Text;
                        else
                            sangria.Observacao = "Sangria";


                        sangriaNegocios.Inserir(sangria);

                        //Alterando o saldo do caixa
                        ObjetoTransferencia.Caixa caixa = new ObjetoTransferencia.Caixa();
                        caixa.CaixaId = Convert.ToInt32(drUltimaAbertura["CaixaId"]);
                        caixa.Valor = Convert.ToDecimal(txtSaldoApos.Text);
                        caixaNegocios.AlterarSaldo(caixa);

                        MessageBox.Show("Operação realizada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtSaldoAtual.Clear();
                        txtValorSangria.Clear();
                        txtSaldoApos.Clear();

                        PesquisarSaldoEmCaixa();
                        CarregarGrid();

                        txtValorSangria.Select();
                        txtValorSangria.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Não é possível fazer uma sangria(retirada) maior do que o valor do caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValorSangria.SelectAll();
                    txtValorSangria.Focus();
                }
            }
            else
            {
                if (txtValorSangria.Text != "0,00")
                {
                    if (MessageBox.Show("Confirma o suprimento em dinheiro no caixa no valor de R$ " + txtValorSangria.Text + "!", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Sangria sangria = new Sangria();
                        sangria.CaixaId = Convert.ToInt32(drUltimaAbertura["CaixaId"]);
                        sangria.UsuarioId = FrmLogin.usuarioId;
                        sangria.ValorCaixa = Convert.ToDecimal(txtSaldoAtual.Text);
                        sangria.ValorSangria = Convert.ToDecimal(txtValorSangria.Text);
                        sangria.ValorAposSangria = Convert.ToDecimal(txtSaldoApos.Text);
                        sangria.DataHora = DateTime.Now;
                        sangria.Tipo = 2; //Suprimento
                        if (txtObservacao.Text.Trim().Length > 0)
                            sangria.Observacao = "Suprimento - " + txtObservacao.Text;
                        else
                            sangria.Observacao = "Suprimento";

                        sangriaNegocios.Inserir(sangria);

                        //Alterando o saldo do caixa
                        ObjetoTransferencia.Caixa caixa = new ObjetoTransferencia.Caixa();
                        caixa.CaixaId = Convert.ToInt32(drUltimaAbertura["CaixaId"]);
                        caixa.Valor = Convert.ToDecimal(txtSaldoApos.Text);
                        caixaNegocios.AlterarSaldo(caixa);

                        MessageBox.Show("Operação realizada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtSaldoAtual.Clear();
                        txtValorSangria.Clear();
                        txtSaldoApos.Clear();

                        PesquisarSaldoEmCaixa();
                        CarregarGrid();

                        txtValorSangria.Select();
                        txtValorSangria.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("Informe um valor para o suprimento(entrada) do caixa!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtValorSangria.Focus();
                }
            }
        }

        private void txtValorSangria_Leave(object sender, EventArgs e)
        {
            try
            {
                if (tipoOperacao == enumSangriaOuSuprimento.Sangria)
                {
                    if (txtValorSangria.Text != "0,00")
                        txtSaldoApos.Text = (Convert.ToDecimal(txtSaldoAtual.Text) - Convert.ToDecimal(txtValorSangria.Text)).ToString("N2");
                    else
                        txtValorSangria.Text = "0,00";
                }
                else
                {
                    if (txtValorSangria.Text != "0,00")
                        txtSaldoApos.Text = (Convert.ToDecimal(txtSaldoAtual.Text) + Convert.ToDecimal(txtValorSangria.Text)).ToString("N2");
                    else
                        txtValorSangria.Text = "0,00";
                }
            }
            catch
            { }
        }

        private void FrmSangria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5 && btnSalvar.Enabled)
            {
                btnSalvar_Click(sender, e);
            }
        }

        private void txtObservacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSalvar.Focus();
            }
        }
    }
}
