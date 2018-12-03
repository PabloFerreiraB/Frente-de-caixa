using PDV.Apresentacao.Cadastros;
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

namespace PDV.Apresentacao.MovimentacaoCaixa.OperacoesPDV
{
    public partial class FrmPesquisarProdutos : Form
    {
        public FrmPesquisarProdutos()
        {
            InitializeComponent();
        }

        #region Instâncias

        ProdutosNegocios produtosNegocios = new ProdutosNegocios();

        #endregion

        #region Propriedades

        public int _ProdutosId { get; set; }

        public string _CodigoBarras { get; set; }

        public string _Descricao { get; set; }

        public decimal _ValorUnitario { get; set; }

        public int _Estoque { get; set; }

        #endregion

        #region Variáveis

        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private void CarregarGrid()
        {
            try
            {
                dtGrid = produtosNegocios.CarregarListaProdutosGrid();
                grid.DataSource = dtGrid;

                lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar produto selecionado.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion


        private void FrmPesquisarProdutos_Load(object sender, EventArgs e)
        {
            CarregarGrid();

            txtPesquisar.Select();
            txtPesquisar.Focus();
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(ProdutosId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (CodigoBarras like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Descricao like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
            }
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                try
                {
                    _ProdutosId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["ProdutosId"].Value);
                    _CodigoBarras = grid.Rows[grid.CurrentRow.Index].Cells["CodigoBarras"].Value.ToString();
                    _Descricao = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString();
                    _ValorUnitario = Convert.ToDecimal(grid.Rows[grid.CurrentRow.Index].Cells["ValorUnitario"].Value);
                    _Estoque = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["EstoqueAtual"].Value);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar carregar o produto selecionado!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FrmPesquisarProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmProdutos)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmProdutos frmProdutos = new FrmProdutos();
                frmProdutos.ShowDialog();
            }
        }
    }
}
