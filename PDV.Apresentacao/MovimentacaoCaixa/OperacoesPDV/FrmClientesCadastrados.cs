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

namespace PDV.Apresentacao.MovimentacaoCaixa
{
    public partial class FrmClientesCadastrados : Form
    {
        public FrmClientesCadastrados()
        {
            InitializeComponent();
        }

        #region Instâncias

        ClientesNegocios clientesNegocios = new ClientesNegocios();

        #endregion

        #region Propriedades

        public int _ClientesId { get; set; }
        public string _Cliente { get; set; }
        public string _CpfCnpj { get; set; }

        #endregion

        #region Variáveis

        DataTable dtGrid = new DataTable();
        bool clienteNaoIdentificado = false;
        public bool _PDV = false;

        #endregion

        #region Métodos

        private void CarregarGrid()
        {
            try
            {
                dtGrid = clientesNegocios.CarregarGridPDV();
                grid.DataSource = dtGrid;

                lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os clientes cadastrados.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmClientesCadastrados_Load(object sender, EventArgs e)
        {
            CarregarGrid();

            txtPesquisar.Select();
            txtPesquisar.Focus();

            toolTip.SetToolTip(this.btnAdicionarCliente, "Adicionar novo Cliente!");
            toolTip.SetToolTip(this.btnClienteNaoIdentificado, "Iniciar venda sem cliente cadastrado!");
        }

        private void FrmClientesCadastrados_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnClienteNaoIdentificado_Click(sender, e);
            }
        }

        #region Eventos txtPesquisar

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

            dv.RowFilter = "((CONVERT(ClientesId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Nome like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (CpfCnpj like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Cidade like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        #endregion

        #region Eventos Grid

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
                    if (!clienteNaoIdentificado)
                    {
                        if (!_PDV)
                        {
                            this.Hide();
                            FrmPDV frmPDV = new FrmPDV();
                            frmPDV._ClientesId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["ClientesId_"].Value);
                            frmPDV._Cliente = grid.Rows[grid.CurrentRow.Index].Cells["Nome"].Value.ToString();
                            frmPDV._CpfCnpj = grid.Rows[grid.CurrentRow.Index].Cells["CpfCnpj"].Value.ToString();

                            frmPDV.Closed += (s, args) => this.Close();
                            frmPDV.ShowDialog();
                        }
                        else
                            this.Close();

                    }
                    else
                    {
                        if (!_PDV)
                        {
                            this.Hide();
                            FrmPDV frmPDV = new FrmPDV();
                            frmPDV._ClientesId = 0;
                            frmPDV._Cliente = _Cliente = "CLIENTE NÃO IDENTIFICADO";
                            frmPDV._CpfCnpj = "000.000.000-00";
                           
                            frmPDV.Closed += (s, args) => this.Close();
                            frmPDV.ShowDialog();
                        }
                        else
                            this.Close();
                    }

                    clienteNaoIdentificado = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar carregar o cliente selecionado!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void btnClienteNaoIdentificado_Click(object sender, EventArgs e)
        {
            clienteNaoIdentificado = true;
            grid_DoubleClick(sender, e);
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmCliente)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmCliente frmCliente = new FrmCliente();
                frmCliente.ShowDialog();
                CarregarGrid();
            }
        }
    }
}
