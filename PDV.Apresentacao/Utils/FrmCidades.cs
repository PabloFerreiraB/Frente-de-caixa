using PDV.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Utils
{
    public partial class FrmCidades : Form
    {
        public FrmCidades()
        {
            InitializeComponent();
        }

        #region Instâncias

        CidadesNegocios cidadesNegocios = new CidadesNegocios();

        #endregion

        #region Propriedades

        public int _CidadeId { get; set; }

        public string _Cidade { get; set; }

        public string _UF { get; set; }

        #endregion

        #region Variáveis

        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private void CarregarMunicipios()
        {
            dtGrid = cidadesNegocios.PesquisarDataSource();
            grid.DataSource = dtGrid;

            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        #endregion

        private void FrmCidades_Load(object sender, EventArgs e)
        {
            CarregarMunicipios();
        }

        private void FrmCidades_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((Nome like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;

            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    _CidadeId = (int)(grid.Rows[grid.CurrentRow.Index].Cells["CidadeId"].Value);
                    _Cidade = grid.Rows[grid.CurrentRow.Index].Cells["Nome"].Value.ToString();
                    _UF = grid.Rows[grid.CurrentRow.Index].Cells["UF"].Value.ToString();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada!\nErro:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                grid_DoubleClick(sender, e);
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Clear();
            txtPesquisar.Focus();
        }
    }
}
