using PDV.AcessoBancoDados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.Apresentacao.MovimentacaoCaixa.OperacoesPDV
{
    public partial class FrmInformeCpfCnpj : Form
    {
        public FrmInformeCpfCnpj()
        {
            InitializeComponent();
        }

        public string _Tipo { get; set; }

        public string _CpfCnpj = string.Empty;


        private void FrmInformeCpfCnpj_Load(object sender, EventArgs e)
        {
            txtDados.Select();
            txtDados.Focus();
        }

        private void FrmInformeCpfCnpj_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(this.ActiveControl, !e.Shift, true, true, true);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5 && !string.IsNullOrEmpty(txtDados.Text))
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void bnt0_Click(object sender, EventArgs e)
        {
            txtDados.Text += "0";
        }

        private void bnt1_Click(object sender, EventArgs e)
        {
            txtDados.Text += "1";
        }

        private void bnt2_Click(object sender, EventArgs e)
        {
            txtDados.Text += "2";
        }

        private void bnt3_Click(object sender, EventArgs e)
        {
            txtDados.Text += "3";
        }

        private void bnt4_Click(object sender, EventArgs e)
        {
            txtDados.Text += "4";
        }

        private void bnt5_Click(object sender, EventArgs e)
        {
            txtDados.Text += "5";
        }

        private void bnt6_Click(object sender, EventArgs e)
        {
            txtDados.Text += "6";
        }

        private void bnt7_Click(object sender, EventArgs e)
        {
            txtDados.Text += "7";
        }

        private void bnt8_Click(object sender, EventArgs e)
        {
            txtDados.Text += "8";
        }

        private void bnt9_Click(object sender, EventArgs e)
        {
            txtDados.Text += "9";
        }

        private void bntLimpar_Click(object sender, EventArgs e)
        {
            txtDados.Clear();
            txtDados.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDados.Text.Trim() != "")
                {
                    if (txtDados.Text.Length.Equals(11))
                    {
                        if (Util.ValidaCNPJ(txtDados.Text))
                        {
                            string cpftemp = txtDados.Text;

                            txtDados.Clear();
                            txtDados.Text = cpftemp.Substring(0, 3);
                            txtDados.Text += "." + cpftemp.Substring(3, 3);
                            txtDados.Text += "." + cpftemp.Substring(6, 3);
                            txtDados.Text += "-" + cpftemp.Substring(9, 2);

                            _CpfCnpj = txtDados.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CPF Inválido!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDados.Clear();
                            txtDados.Focus();
                        }
                    }
                    else if (txtDados.Text.Length.Equals(14)) //VALIDANDO O CNPJ
                    {
                        if (Util.ValidaCNPJ(txtDados.Text))
                        {
                            string cnpjtemp = txtDados.Text;

                            txtDados.Clear();
                            txtDados.Text = cnpjtemp.Substring(0, 2);
                            txtDados.Text += "." + cnpjtemp.Substring(2, 3);
                            txtDados.Text += "." + cnpjtemp.Substring(5, 3);
                            txtDados.Text += "/" + cnpjtemp.Substring(8, 4);
                            txtDados.Text += "-" + cnpjtemp.Substring(12, 2);

                            _CpfCnpj = txtDados.Text;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("CNPJ Inválido!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtDados.Clear();
                            txtDados.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Quantidade de caracteres inválido, para CPF informe 11 digitos e para CNPJ informe 14!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDados.Focus();
                    }
                }
            }
            catch
            { }
        }
    }
}
