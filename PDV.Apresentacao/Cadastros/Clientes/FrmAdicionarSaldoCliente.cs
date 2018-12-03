using PDV.AcessoBancoDados;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros.Clientes
{
    public partial class FrmAdicionarSaldoCliente : Form
    {
        public FrmAdicionarSaldoCliente()
        {
            InitializeComponent();
        }

        #region Instancias

        readonly FuncionariosNegocios funcionariosNegocios = new FuncionariosNegocios();
        readonly CaixaNegocios caixaNegocios = new CaixaNegocios();
        readonly SaldoClientesNegocios saldoClientesNegocios = new SaldoClientesNegocios();
        readonly Conexao conexao = new Conexao();
        readonly MovimentacaoVendasNegocios movimentacaoVendasNegocios = new MovimentacaoVendasNegocios();
        readonly MovimentacaoCaixaNegocios movimentacaoCaixaNegocios = new MovimentacaoCaixaNegocios();
        readonly Cryptografia cryptografia = new Cryptografia();

        #endregion

        #region Variaveis

        int clienteId = 0;
        int funcionarioId = 0;
        DataRow drUltimaAbertura;

        #endregion

        #region Metodos

        private void LimpaCampos()
        {
            clienteId = funcionarioId = 0; cbbOperacao.SelectedIndex = -1;
            txtCliente.Clear(); txtObservacao.Clear(); txtSenhaFuncionario.Clear(); txtValor.Text = "0,00";
            lblNomeFuncionario.Text = string.Empty;
        }

        #endregion

        private void FrmAdicionarSaldoCliente_Load(object sender, EventArgs e)
        {
            lblNomeFuncionario.Text = string.Empty;
            cbbOperacao.SelectedIndex = 0;
        }

        private void FrmAdicionarSaldoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            else if (e.KeyCode == Keys.F5)
                btnConfirmar_Click(sender, e);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (clienteId.Equals(0))
            {
                MessageBox.Show("Por favor, informe o cliente!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnPesquisaCliente.Focus();
                return;
            }

            if (Convert.ToDecimal(txtValor.Text) <= 0)
            {
                MessageBox.Show("Por favor, informe o valor!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtValor.Focus();
                return;
            }

            if (txtSenhaFuncionario.Visible)
            {
                if (string.IsNullOrEmpty(lblNomeFuncionario.Text))
                {
                    MessageBox.Show("Por favor, informe a senha do funcionário!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSenhaFuncionario.Focus();
                    return;
                }
            }


            //Acho que aqui só uma linha serve
            int ultimaAbertura = caixaNegocios.VerificarSeCaixaEstaAberto();
            if (ultimaAbertura.Equals(0))
            {
                MessageBox.Show("Por favor, Efetue a abertura do caixa!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }

            //if (objPermissaoInfo.PermSalv)
            //{
            decimal saldoAtual = saldoClientesNegocios.PesquisarSaldoCliente(clienteId);

            decimal SaldoAposOperacao = 0;
            if (cbbOperacao.Text.Equals("Somar"))
            {
                SaldoAposOperacao = saldoAtual + Convert.ToDecimal(txtValor.Text);
            }
            else
                SaldoAposOperacao = saldoAtual - Convert.ToDecimal(txtValor.Text);

            if (SaldoAposOperacao < 0)
            {
                MessageBox.Show("Não é possivel efetuar a operação, saldo após a operação será negativo!\n\nSaldo Atual: " + saldoAtual.ToString("N2") + "\nValor da operação: " + txtValor.Text + "\nApós operação: " + SaldoAposOperacao.ToString("N2"), "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("Saldo atual: " + saldoAtual.ToString("N2") + "\n\nValor da operação: " + txtValor.Text + "\n\nApós operação: " + SaldoAposOperacao.ToString("N2") + "\n\n\nConfirma a operação?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaldoClientes saldoClientes = new SaldoClientes();

                    saldoClientes.ClientesId = clienteId;
                    saldoClientes.FuncionarioId = funcionarioId;
                    if (!string.IsNullOrEmpty(txtObservacao.Text.TrimEnd().TrimStart()))
                        saldoClientes.Observacao = "Saldo lançado manualmente - " + txtObservacao.Text;
                    else
                        saldoClientes.Observacao = "Saldo lançado manualmente";
                    saldoClientes.Operacao = cbbOperacao.Text.Equals("Somar") ? 1 : 2;  // 1 = Somar    2 = Subtrair
                    saldoClientes.Valor = cbbOperacao.Text.Equals("Somar") ? Convert.ToDecimal(txtValor.Text) : Convert.ToDecimal(txtValor.Text) * (-1);
                    saldoClientes.DataHora = DateTime.Now;
                    saldoClientes.CaixaId = caixaNegocios.VerificarSeCaixaEstaAberto();

                    // Aqui grava o saldo do cliente
                    if (saldoClientes.Operacao == 1)
                        saldoClientesNegocios.Inserir(saldoClientes);
                    else
                        saldoClientesNegocios.DescontarSaldoCliente(saldoClientes);


                    // Aqui grava a movimentação de vendas
                    int ultimoLancamentoSaldoID = conexao.RetornarUltimoId("SaldoClientes", "SaldoClientesId");
                    MovimentacaoVendas movimentacaoVendas = new MovimentacaoVendas();

                    movimentacaoVendas.MovimentacaoVendasId = ultimoLancamentoSaldoID;
                    movimentacaoVendas.DataHora = DateTime.Now;

                    if (cbbOperacao.Text.Equals("Somar"))
                    {
                        movimentacaoVendas.Tipo = "R";
                        movimentacaoVendas.Observacao = "Saldo lançado para o cliente " + txtCliente.Text;
                    }
                    else
                    {
                        movimentacaoVendas.Tipo = "D";
                        movimentacaoVendas.Observacao = "Saldo lançado para o cliente " + txtCliente.Text;
                    }
                    movimentacaoVendas.StatusMovimentacao = "N";
                    movimentacaoVendas.Valor = Convert.ToDecimal(txtValor.Text);
                    movimentacaoVendas.ReceitasDespesasId = 0;
                    movimentacaoVendas.MovimentacaoVendasId = caixaNegocios.VerificarSeCaixaEstaAberto();

                    movimentacaoVendasNegocios.InserirNovo(movimentacaoVendas);


                    // Aqui grava a movimentação do caixa
                    int ultimoId = conexao.RetornarUltimoId("MovimentacaoVendas", "MovimentacaoVendasId");
                    movimentacaoCaixaNegocios.MovimentoCaixa(ultimoId, cbbOperacao.Text.Equals("Somar") ? movimentacaoVendas.Valor : movimentacaoVendas.Valor * -1);

                    MessageBox.Show("Operação efetuada com sucesso!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    // PABLO - Imprimir comprovante saldo do cliente
                    //if (chkImprimirComprovante.Checked)
                    //ImpressaoComprovante(ultimoLancamentoSaldoID);


                    LimpaCampos();
                    btnPesquisaCliente.Focus();
                }
            }
            //}
            //else
            //{
            //    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void btnPesquisaCliente_Click(object sender, EventArgs e)
        {
            FrmBuscaClientes frmBuscaClientes = new FrmBuscaClientes();
            frmBuscaClientes.ShowInTaskbar = false;
            frmBuscaClientes.ShowDialog();

            if (frmBuscaClientes._ClienteId > 0)
            {
                clienteId = frmBuscaClientes._ClienteId;
                txtCliente.Text = frmBuscaClientes._Nome;

                cbbOperacao.Focus();
            }
            else
            {
                clienteId = 0;
                txtCliente.Text = "SELECIONE O CLIENTE";
            }
        }

        private void txtSenhaFuncionario_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenhaFuncionario.Text))
            {
                DataTable dta = new DataTable();
                dta = funcionariosNegocios.PesquisarFuncionariosPorSenhaVendedor(cryptografia.Crypto(txtSenhaFuncionario.Text, true));

                if (dta.Rows.Count > 0 && dta != null)
                {
                    funcionarioId = Convert.ToInt32(dta.Rows[0]["FuncionarioId"].ToString());
                    lblNomeFuncionario.Visible = true;
                    lblNomeFuncionario.Text = dta.Rows[0]["Nome"].ToString();
                }
                else
                {
                    funcionarioId = 0;
                    txtSenhaFuncionario.Clear();
                    lblNomeFuncionario.Text = string.Empty;
                }
            }
        }
    }
}
