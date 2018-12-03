using PDV.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.Apresentacao.MovimentacaoCaixa
{
    public partial class FrmAbriCaixa : Form
    {
        public FrmAbriCaixa()
        {
            InitializeComponent();
        }

        #region Instâncias

        CaixaNegocios caixaNegocios = new CaixaNegocios();

        #endregion

        #region Veriáveis

        int ultimaAbertura = 0;

        #endregion


        private void FrmAbriCaixa_Load(object sender, EventArgs e)
        {
            try
            {
                ultimaAbertura = caixaNegocios.VerificarSeCaixaEstaAberto();
                DataRow drUltimaAbertura = caixaNegocios.PesquisarPorCodigo(ultimaAbertura).Rows[0];

                if (drUltimaAbertura != null)
                {
                    txtValorCaixa.Text = drUltimaAbertura["Valor"].ToString();
                }

                txtValorCaixa.Select();
                txtValorCaixa.Focus();
            }
            catch
            { }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (txtValorCaixa.Text != "0,00")
            {
                ultimaAbertura = caixaNegocios.VerificarSeCaixaEstaAberto();
                if (ultimaAbertura > 0)
                {
                    if (MessageBox.Show("Caixa ja está aberto com o valor de R$ " + caixaNegocios.PesquisarValorDeAberturaCaixa(ultimaAbertura) + "\n\nDeseja alterar o valor da abertura para o valor informado? ", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ObjetoTransferencia.Caixa caixa = new ObjetoTransferencia.Caixa();
                        caixa.Valor = Convert.ToDecimal(txtValorCaixa.Text);
                        caixa.CaixaId = ultimaAbertura;
                        caixa.UsuarioId = FrmLogin.usuarioId;

                        caixaNegocios.AlterarValorAbertura(caixa);
                        MessageBox.Show("Operação realizada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (MessageBox.Show("Confirma a abertura do caixa com o valor de R$ " + txtValorCaixa.Text + ".", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ObjetoTransferencia.Caixa caixa = new ObjetoTransferencia.Caixa();
                    caixa.Abertura = DateTime.Now;
                    caixa.Valor = Convert.ToDecimal(txtValorCaixa.Text);
                    caixa.UsuarioId = FrmLogin.usuarioId;

                    caixaNegocios.Inserir(caixa);

                    MessageBox.Show("Operação realizada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FrmAbriCaixa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5 && txtValorCaixa.Text != "0,00")
            {
                btnConfirmar_Click(sender, e);
            }
        }

   
    }
}
