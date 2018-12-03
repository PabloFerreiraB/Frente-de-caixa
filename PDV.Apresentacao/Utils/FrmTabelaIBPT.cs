using PDV.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Utils
{
    public partial class FrmTabelaIBPT : Form
    {
        public FrmTabelaIBPT()
        {
            InitializeComponent();
        }

        #region Instâncias

        TabelaIBPTNegocios tabelaIBPTNegocios = new TabelaIBPTNegocios();

        #endregion

        #region Propriedades

        public int _TabelaIBPTId { get; set; }
        public string _NCM { get; set; }

        #endregion

        #region Variáveis

        DataTable dtRegistros;
        BindingSource bs = new BindingSource();

        #endregion

        #region Métodos

        private void CarregarRegistros()
        {
            try
            {
                dtRegistros = new DataTable();
                dtRegistros = tabelaIBPTNegocios.PesquisarPorCodigo();

                bs.DataSource = dtRegistros;
                gridRegistros.DataSource = dtRegistros;
            }
            catch
            { }
        }

        #endregion


        private void FrmTabelaIBPT_Load(object sender, EventArgs e)
        {
            CarregarRegistros();
        }

        private void FrmTabelaIBPT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = "(NCM like '" + txtPesquisar.Text.Replace("'", "") + "%')";
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && gridRegistros.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                gridRegistros.Focus();
            }
        }

        private void gridRegistros_DoubleClick(object sender, EventArgs e)
        {
            if (gridRegistros.Rows.Count > 0)
            {
                _TabelaIBPTId = Convert.ToInt32(gridRegistros.Rows[gridRegistros.CurrentRow.Index].Cells["TabelaIBPTId"].Value);
                _NCM = gridRegistros.Rows[gridRegistros.CurrentRow.Index].Cells["NCM"].Value.ToString();

                this.Close();
            }
        }

        private void gridRegistros_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridRegistros_DoubleClick(sender, e);
            else if (e.KeyCode == Keys.Up && gridRegistros.CurrentRow.Index == 0)
                txtPesquisar.Focus();
        }

        private void gridRegistros_SelectionChanged(object sender, EventArgs e)
        {
            lblDescricao.Text = gridRegistros.Rows[gridRegistros.CurrentRow.Index].Cells["Descricao"].Value.ToString();
        }

        private void chkMostrarDescricao_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMostrarDescricao.Checked)
            {
                lblDescricao.Visible = true;
                this.Width = 758; 
                this.Height = 511;
            }
            else
            {
                lblDescricao.Visible = false;
                this.Width = 758;
                this.Height = 440;
            }
        }
    }
}
