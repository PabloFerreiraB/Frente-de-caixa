using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmGrupoProdutos : Form
    {
        public FrmGrupoProdutos()
        {
            InitializeComponent();
        }

        #region Instâncias

        GrupoProdutosNegocios grupoProdutosNegocios = new GrupoProdutosNegocios();

        #endregion

        #region Propriedades

        public string _Descricao { get; set; }
        public bool _Ativo { get; set; }

        #endregion

        #region Variáveis

        DataTable dtGrid = new DataTable();
        int grupoProdutosId = 0;

        #endregion

        #region Métodos

        private void CarregarGrid()
        {
            try
            {
                dtGrid = grupoProdutosNegocios.CarregarGrid();
                grid.DataSource = dtGrid;

                grupoProdutosId = 0;
                lblQuantidade.Text = grid.Rows.Count + " Registros encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os grupos cadastrados.\n\n" + ex, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HabilitaCampos(bool ativa)
        {
            txtPesquisar.Enabled = ativa;
            chkAtivo.Enabled = ativa;
            txtPesquisar.Focus();
        }

        private void Limpar()
        {
            txtPesquisar.Clear();
            chkAtivo.Checked = true;
            btnPesquisar.Enabled = true;
        }

        #endregion

        private void FrmGrupoProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnNovo_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
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

        private void FrmGrupoProdutos_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(grupoProdutosId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Descricao like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
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

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    grupoProdutosId = (int)(grid.Rows[grid.CurrentRow.Index].Cells["grupoProdutosId_"].Value);
                    txtPesquisar.Text = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString();
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
            else if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.F8)
            {
                if (grid.SelectedRows.Count > 0)
                {
                    btnExcluir.Enabled = true;
                    btnExcluir_Click(sender, e);
                }
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
                btnExcluir.Enabled = false;
                btnPesquisar.Enabled = true;
            }
            grupoProdutosId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPesquisar.Text == "")
                {
                    MessageBox.Show("Nenhuma grupo informado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtPesquisar.Focus();
                    return;
                }


                GrupoProdutos grupoProdutos = new GrupoProdutos();
                grupoProdutos.Descricao = txtPesquisar.Text.Trim();
                grupoProdutos.Ativo = chkAtivo.Checked;

                if (grupoProdutosId <= 0)
                {
                    grupoProdutosNegocios.Inserir(grupoProdutos);
                    MessageBox.Show("Grupo cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    HabilitaCampos(false);
                    btnSalvar.Text = "Salvar [ F5 ]";
                    btnSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnNovo.Text = "Novo [ F2 ]";
                    CarregarGrid();
                }
                else
                {
                    grupoProdutos.GrupoProdutosId = grupoProdutosId;

                    grupoProdutosNegocios.Alterar(grupoProdutos);
                    MessageBox.Show("Grupo alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    Limpar();
                    HabilitaCampos(false);
                    btnSalvar.Text = "Salvar [ F5 ]";
                    btnSalvar.Enabled = false;
                    btnExcluir.Enabled = false;
                    btnNovo.Text = "Novo [ F2 ]";
                    CarregarGrid();
                }

                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                grupoProdutosId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o grupo!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    GrupoProdutos grupoProdutos = new GrupoProdutos();
                    grupoProdutos.GrupoProdutosId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["GrupoProdutosId_"].Value);

                    if (MessageBox.Show("Deseja realmente excluir o grupo selecionado?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        grupoProdutosNegocios.Excluir(grupoProdutos);
                        MessageBox.Show("Grupo excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitaCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGrid();
                        grupoProdutosId = 0;
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
                MessageBox.Show("O grupo não pode ser excluído pois existe ligações com outras tabelas e operações do sistema!\n\nPor favor inative o grupo escolhido, ou entre em contato com o suporte do sistema, obrigado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            txtPesquisar.Clear();
            txtPesquisar.Focus();
        }

        #endregion

    
    }
}
