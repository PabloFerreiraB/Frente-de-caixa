using PDV.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros.Clientes
{
    public partial class FrmBuscaClientes : Form
    {
        public FrmBuscaClientes()
        {
            InitializeComponent();
        }

        #region Instancias

        readonly ClientesNegocios clientesNegocios = new ClientesNegocios();

        #endregion

        #region Propriedades

        public int _ClienteId { get; set; }
        public string _Nome { get; set; }

        #endregion

        #region Variaveis

        int clientesId = 0;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Metodos

        private void CarregarGrid()
        {
            try
            {
                dtGrid = clientesNegocios.CarregarGrid();
                grid.DataSource = dtGrid;

                clientesId = 0;
                lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os clientes cadastrados.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmBuscaClientes_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void txtCampoPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void txtCampoPesquisa_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);
            dv.RowFilter = "((CONVERT(ClientesId, 'System.String') = '" + txtCampoPesquisa.Text.Replace("'", "") + "') OR (Nome like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%') OR (ApelidoFantasia like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%') OR (CpfCnpj like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%') OR (Telefone like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%') OR (Celular like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%') OR (Cidade like '%" + txtCampoPesquisa.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                try
                {
                    _ClienteId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["ClientesId_"].Value);
                    _Nome = grid.Rows[grid.CurrentRow.Index].Cells["Nome"].Value.ToString();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar carregar o cliente selecionado!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmBuscaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
    }
}
