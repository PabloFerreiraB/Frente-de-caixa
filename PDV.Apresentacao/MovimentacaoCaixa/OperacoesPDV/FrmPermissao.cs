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
    public partial class FrmPermissao : Form
    {
        public FrmPermissao()
        {
            InitializeComponent();
        }

        public string _Senha { get; set; }
        public string _Motivo { get; set; }

        private void FrmPermissao_KeyDown(object sender, KeyEventArgs e)
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

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenha.Text))
            {
                _Senha = txtSenha.Text;
                _Motivo = txtMotivo.Text;
            }

            this.Close();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                txtMotivo.Focus();
        }

        private void txtMotivo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnConfirmar.Focus();
        }

        private void FrmPermissao_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenha.Text))
            {
                _Senha = txtSenha.Text;
                _Motivo = txtMotivo.Text;
            }
        }

        private void FrmPermissao_Load(object sender, EventArgs e)
        {
            txtSenha.Focus();
        }
    }
}
