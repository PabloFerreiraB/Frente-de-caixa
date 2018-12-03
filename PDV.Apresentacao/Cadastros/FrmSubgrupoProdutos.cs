using PDV.Negocios;
using PDV.ObjetoTransferencia;
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
    public partial class FrmSubgrupoProdutos : Form
    {
        public FrmSubgrupoProdutos()
        {
            InitializeComponent();
        }

        #region Instâncias

        SubgrupoProdutosNegocios subgrupoProdutosNegocios = new SubgrupoProdutosNegocios();

        #endregion

        #region Propriedades

        #endregion

        #region Variáveis

        int subgrupoProdutosId = 0;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private void HabilitaCampos(bool ativa)
        {
            txtSubgrupoProdutos.Enabled = ativa;
            chkAtivo.Enabled = ativa;
            cbbGrupoProdutos.Enabled = ativa;
            txtSubgrupoProdutos.Focus();
        }

        private void Limpar()
        {
            txtSubgrupoProdutos.Clear();
            chkAtivo.Checked = true;
            cbbGrupoProdutos.SelectedIndex = -1;
            btnPesquisar.Enabled = true;
        }

        private void CarregarGrid()
        {
            try
            {
                dtGrid = subgrupoProdutosNegocios.CarregarGrid();
                grid.DataSource = dtGrid;

                subgrupoProdutosId = 0;
                lblQuantidade.Text = grid.Rows.Count + " Registros encontrado(s)!";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar as Subgrupo cadastrados.\n\n" + ex, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGrupos()
        {
            try 
            {
                GrupoProdutosNegocios grupoProdutosNegocios = new GrupoProdutosNegocios();
                cbbGrupoProdutos.DataSource = grupoProdutosNegocios.PesquisarPorNome(string.Empty);

                cbbGrupoProdutos.DisplayMember = "Descricao";
                cbbGrupoProdutos.ValueMember = "GrupoProdutosId";
                cbbGrupoProdutos.SelectedIndex = -1;
            }
            catch
            { }
        }

        #endregion

        private void FrmSubgrupoProdutos_Load(object sender, EventArgs e)
        {
            CarregarGrid();
            CarregarGrupos();

            cbbGrupoProdutos.SelectedIndex = -1;
        }

        private void FrmSubgrupoProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnNovo_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && btnSalvar.Enabled)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8 && btnExcluir.Enabled)
            {
                btnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
        }

        #region Botões Menu

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (btnSalvar.Enabled == false)
            {
                HabilitaCampos(true);
                Limpar();
                btnNovo.Text = "Cancelar [ F2 ]";
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                btnSalvar.Enabled = true;
            }
            else
            {
                HabilitaCampos(false);
                btnNovo.Text = "Novo [ F2 ]";
                btnSalvar.Text = "Salvar [ F5 ]";
                toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                btnSalvar.Enabled = false;
                btnPesquisar.Enabled = true;
            }
            subgrupoProdutosId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSubgrupoProdutos.Text))
                {
                    MessageBox.Show("Não informado o Subgrupo para cadastro!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSubgrupoProdutos.Focus();
                    return;
                }

                if (cbbGrupoProdutos.SelectedIndex == -1)
                {
                    MessageBox.Show("É necessário informar o Grupo à qual o SubGrupo irá pertencer!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbGrupoProdutos.Focus();
                    return;
                }

                SubgrupoProdutos subgrupoProdutos = new SubgrupoProdutos();
                subgrupoProdutos.Descricao = txtSubgrupoProdutos.Text.Trim();
                subgrupoProdutos.Ativo = chkAtivo.Checked;
                subgrupoProdutos.GrupoProdutosId = Convert.ToInt32(cbbGrupoProdutos.SelectedValue);

                if (subgrupoProdutosId <= 0)
                {
                    subgrupoProdutosNegocios.Inserir(subgrupoProdutos);
                    MessageBox.Show("Subgrupo cadastrada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    HabilitaCampos(false);
                    btnSalvar.Text = "Salvar [ F5 ]";
                    btnSalvar.Enabled = false;
                    btnNovo.Text = "Novo [ F2 ]";
                    CarregarGrid();
                }
                else
                {
                    subgrupoProdutos.SubgrupoProdutosId = subgrupoProdutosId;

                    subgrupoProdutosNegocios.Alterar(subgrupoProdutos);
                    MessageBox.Show("Subgrupo alterada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    HabilitaCampos(false);
                    btnSalvar.Text = "Salvar [ F5 ]";
                    btnSalvar.Enabled = false;
                    btnNovo.Text = "Novo [ F2 ]";
                    CarregarGrid();
                }

                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                subgrupoProdutosId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o Subgrupo!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    SubgrupoProdutos subgrupoProdutos = new SubgrupoProdutos();
                    subgrupoProdutos.SubgrupoProdutosId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["SubgrupoProdutosId_"].Value);

                    if (MessageBox.Show("Deseja realmente excluir o subgrupo selecionado?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        subgrupoProdutosNegocios.Excluir(subgrupoProdutos);
                        MessageBox.Show("Subgrupo excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitaCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGrid();
                        subgrupoProdutosId = 0;
                    }
                    else
                    {
                        Limpar();
                        HabilitaCampos(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada! \n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            HabilitaCampos(true);
            txtSubgrupoProdutos.Clear();
            txtSubgrupoProdutos.Focus();
        }

        #endregion

        private void txtSubgrupoProdutos_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(SubgrupoProdutosId, 'System.String') = '" + txtSubgrupoProdutos.Text.Replace("'", "") + "') OR (Descricao like '%" + txtSubgrupoProdutos.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
        }

        private void txtSubgrupoProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtSubgrupoProdutos.Select();
                txtSubgrupoProdutos.Focus();
            }
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.F8)
            {
                if (grid.SelectedRows.Count > 0)
                {
                    btnExcluir.Enabled = true;
                    btnExcluir_Click(sender, e);
                }
            }
            else if (e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
                e.SuppressKeyPress = true;
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    subgrupoProdutosId = (int)(grid.Rows[grid.CurrentRow.Index].Cells["SubgrupoProdutosId_"].Value);
                    txtSubgrupoProdutos.Text = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString();
                    cbbGrupoProdutos.Text = grid.Rows[grid.CurrentRow.Index].Cells["GrupoProdutos"].Value.ToString();
                    string ativo = grid.Rows[grid.CurrentRow.Index].Cells["Ativo"].Value.ToString();

                    if (ativo.Equals("Ativo"))
                        chkAtivo.Checked = true;
                    else
                        chkAtivo.Checked = false;

                    HabilitaCampos(true);
                    btnSalvar.Text = "Alterar [ F5 ]";
                    btnNovo.Text = "Cancelar [ F2 ]";
                    toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                    btnSalvar.Enabled = true;
                    btnExcluir.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada! \n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
