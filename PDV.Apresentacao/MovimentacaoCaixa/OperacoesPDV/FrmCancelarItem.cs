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
    public partial class FrmCancelarItem : Form
    {
        public FrmCancelarItem()
        {
            InitializeComponent();
        }

        public int _Item { get; set; }

        private void FrmCancelarItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirmar.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                _Item = Convert.ToInt32(txtCodigo.Text);
            }

            this.Close();
        }

        private void FrmCancelarItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                _Item = Convert.ToInt32(txtCodigo.Text);
            }
        }
    }
}
