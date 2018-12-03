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

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmUnidadeMedida : Form
    {
        public FrmUnidadeMedida()
        {
            InitializeComponent();
        }

        #region Instâncias

        UnidadeMedidaNegocios unidadeMedidaNegocios = new UnidadeMedidaNegocios();

        #endregion

        #region Variáveis

        DataTable dtGrid = new DataTable();
        int unidadeMedidadId = 0;

        #endregion

        #region Propriedades

        public int _UnidadeMedidaId { get; set; }
        public string _Descricao { get; set; }

        #endregion

        #region Método

        private void CarregarGrid()
        {
            dtGrid = unidadeMedidaNegocios.CarregarGrid();
            grid.DataSource = dtGrid;
        }

        #endregion

        private void FrmUnidadeMedida_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void FrmUnidadeMedida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(UnidadeMedidaId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Descricao like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    _UnidadeMedidaId = (int)(grid.Rows[grid.CurrentRow.Index].Cells["UnidadesMedidaId"].Value);
                    _Descricao = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada! \n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
