using PDV.AcessoBancoDados;
using PDV.Apresentacao.Emails;
using PDV.Apresentacao.Utils;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmFornecedor : Form
    {
        public FrmFornecedor()
        {
            InitializeComponent();
        }

        #region Instâncias

        FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();

        #endregion

        #region Propriedades

        public int _FornecedorId { get; set; }
        public string _Nome { get; set; }
        public bool _Pesquisando { get; set; }

        #endregion

        #region Variáveis

        int fornecedorId = 0;
        int cidadeId = 0;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private void CarregarFornecedor(int fornecedorId_)
        {
            try
            {
                DataRow rFornecedor = fornecedorNegocios.PesquisarPorCodigo(fornecedorId_).Rows[0];

                fornecedorId = Convert.ToInt32(rFornecedor["FornecedorId"].ToString());

                txtNome.Text = rFornecedor["Nome"].ToString();
                chkAtivo.Checked = Convert.ToBoolean(rFornecedor["Ativo"].ToString());
                txtNomeFantasia.Text = rFornecedor["NomeFantasia"].ToString();

                if (rFornecedor["TipoPessoa"].ToString() == "F")
                    cbbTipoPessoa.Text = "Física";
                else
                    cbbTipoPessoa.Text = "Jurídica";

                txtCPF_CNPJ.Text = rFornecedor["CpfCnpj"].ToString();
                txtRG_IE.Text = rFornecedor["RgIE"].ToString();

                txtTelefone.Clear(); txtTelefone.Refresh();
                txtTelefone.Mask = "99999999999";
                txtTelefone.Text = rFornecedor["Telefone"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                MascararTelefone(txtTelefone);

                txtCelular.Clear(); txtCelular.Refresh();
                txtCelular.Mask = "99999999999";
                txtCelular.Text = rFornecedor["Celular"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                MascararTelefone(txtCelular);

                txtCep.Text = rFornecedor["Cep"].ToString();
                txtEndereco.Text = rFornecedor["Endereco"].ToString();
                txtNumero.Text = rFornecedor["Numero"].ToString();
                txtBairro.Text = rFornecedor["Bairro"].ToString();

                if (!string.IsNullOrEmpty(rFornecedor["CidadeId"].ToString()))
                {
                    cidadeId = (int)(rFornecedor["CidadeId"]);

                    DataTable dtaCidade = new DataTable();
                    CidadesNegocios cidadesNegocios = new CidadesNegocios();
                    dtaCidade = cidadesNegocios.PesquisarPorCodigo(cidadeId);

                    if (dtaCidade.Rows.Count > 0)
                    {
                        txtCidade.Text = dtaCidade.Rows[0]["Nome"].ToString() + "-" + dtaCidade.Rows[0]["UF"].ToString();
                    }
                    else
                        txtCidade.Text = "SELECIONE A CIDADE";
                }
                else
                {
                    cidadeId = 0;
                    txtCidade.Text = "SELECIONE A CIDADE";
                }

                txtContato.Text = rFornecedor["Contato"].ToString();
                txtEmail.Text = rFornecedor["Email"].ToString();
                txtSite.Text = rFornecedor["SiteFornecedor"].ToString();
                txtObservacao.Text = rFornecedor["Observacao"].ToString();
                dtpDataCadastro.Text = rFornecedor["DataCadastro"].ToString();

                txtPesquisar.Clear();
                tabControl.SelectedIndex = 0;

                HabilitaCampos(true);

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                btnNovo.Text = "Cancelar [ F2 ]";
                btnSalvar.Text = "Alterar [ F5 ]";

                toolTip.SetToolTip(this.btnSalvar, "Alterar cadastro [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar o Fornecedor selecionado!\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void CarregarGrid()
        {
            try
            {
                dtGrid = fornecedorNegocios.CarregarGrid();
                grid.DataSource = dtGrid;

                fornecedorId = 0;
                lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os Fornecedor cadastrados.\n\n" + ex, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Telefones

        private void MascararTelefone(MaskedTextBox t)
        {
            int tama = t.Text.Length;
            t.Mask = t.Text.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Length == 11 ? "(99)99999-9999" : "(99)9999-9999";
        }

        private void DesmascararTelefone(MaskedTextBox t)
        {
            t.Mask = "99999999999";
        }

        #endregion

        private void HabilitaCampos(bool ativo)
        {
            TabPage tab = this.tabControl.TabPages[0];

            foreach (Control obj in tab.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Enabled = ativo;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).Enabled = ativo;
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Enabled = ativo;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Enabled = ativo;
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Enabled = ativo;
                }
                if (obj is Button)
                {
                    ((Button)obj).Enabled = ativo;
                }
            }

            dtpDataCadastro.Enabled = false;
            btnPesquisarCidade.Enabled = ativo;
            txtNome.Focus();
        }

        private void Limpar()
        {
            TabPage tab = this.tabControl.TabPages[0];

            foreach (Control obj in tab.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Clear();
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Value = DateTime.Now;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).SelectedIndex = 0;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Clear();
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Checked = true;
                }
            }

            fornecedorId = 0;
            txtCidade.Text = "SELECIONE A CIDADE";
            chkAtivo.Checked = true;
        }

        #endregion

        private void FrmFornecedor_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F8 || e.KeyCode == Keys.Delete && btnExcluir.Enabled)
            {
                btnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnEmail_Click(sender, e);
            }
        }

        private void FrmFornecedor_Load(object sender, EventArgs e)
        {
            CarregarGrid();

            tabControl.SelectedIndex = 1;
            txtPesquisar.Select();
            txtPesquisar.Focus();
        }

        #region Botões Menu

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 0)
            {
                tabControl.SelectedIndex = 0;
            }

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
                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo cadastro [ F2 ]");
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            fornecedorId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cidadeId <= 0)
                {
                    MessageBox.Show("A Cidade é obrigatória para o cadastro!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnPesquisarCidade_Click(sender, e);
                    return;
                }

                if (!string.IsNullOrEmpty(txtCPF_CNPJ.Text) && fornecedorId <= 0)
                {
                    if (fornecedorNegocios.PesquisarCpfCnpjCadastrado(txtCPF_CNPJ.Text))
                    {
                        MessageBox.Show(string.Format("Já existe um cadastro para este {0}!", txtCPF_CNPJ.Text.Length == 14 ? "CPF" : "CNPJ"), "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCPF_CNPJ.SelectAll();
                        txtCPF_CNPJ.Focus();
                        return;
                    }
                }

                Fornecedor fornecedor = new Fornecedor();

                fornecedor.Nome = txtNome.Text.Trim();
                fornecedor.Ativo = chkAtivo.Checked;
                fornecedor.NomeFantasia = txtNomeFantasia.Text.Trim();

                if (cbbTipoPessoa.Text == "Física")
                    fornecedor.TipoPessoa = "F";
                else
                    fornecedor.TipoPessoa = "J";

                fornecedor.CpfCnpj = txtCPF_CNPJ.Text.Trim();
                fornecedor.RgIE = txtRG_IE.Text.Trim();
                fornecedor.Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                fornecedor.Celular = txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                fornecedor.Cep = txtCep.Text.Trim();
                fornecedor.Endereco = txtEndereco.Text.Trim();
                fornecedor.Numero = txtNumero.Text.Trim();
                fornecedor.Bairro = txtBairro.Text.Trim();

                if (cidadeId > 0)
                    fornecedor.CidadeId = cidadeId;

                fornecedor.Contato = txtContato.Text.Trim();
                fornecedor.Email = txtEmail.Text.Trim();
                fornecedor.SiteFornecedor = txtSite.Text.Trim();
                fornecedor.Observacao = txtObservacao.Text.Trim();
                fornecedor.DataCadastro = Convert.ToDateTime(dtpDataCadastro.Value.ToString("dd/MM/yyyy"));

                //INSERIR
                if (fornecedorId <= 0)
                {
                    try
                    {
                        if (fornecedorNegocios.Inserir(fornecedor))
                        {
                            MessageBox.Show("Fornecedor cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            HabilitaCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            CarregarGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar cadastrar o Fornecedor!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //ALTERAR
                {
                    try
                    {
                        fornecedor.FornecedorId = fornecedorId;

                        if (fornecedorNegocios.Alterar(fornecedor))
                        {
                            MessageBox.Show("Fornecedor alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();
                            HabilitaCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            CarregarGrid();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar alterar o Fornecedor!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo cadastro [ F2 ]");
                fornecedorId = 0;
                tabControl.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o Fornecedor!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                try
                {
                    Fornecedor fornecedor = new Fornecedor();
                    fornecedor.FornecedorId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FornecedorId_"].Value);

                    if (MessageBox.Show("Deseja realmente excluir esse Fornecedor?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (fornecedorNegocios.Excluir(fornecedor))
                        {
                            MessageBox.Show("Fornecedor excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            HabilitaCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            fornecedorId = 0;
                            CarregarGrid();
                        }
                    }
                    else
                    {
                        Limpar();
                        HabilitaCampos(false);
                        if (grid.Rows.Count > 0)
                            btnExcluir.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar excluir o Fornecedor!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 1)
            {
                tabControl.SelectedIndex = 1;
                txtPesquisar.Focus();

                btnExcluir.Enabled = true;
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            bool aberto = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmEnviarEmail)
                {
                    form.Focus();
                    aberto = true;
                }
            }

            if (!aberto)
            {
                FrmEnviarEmail frmEnviarEmail = new FrmEnviarEmail();
                frmEnviarEmail.ShowInTaskbar = false;
                frmEnviarEmail._Email = txtEmail.Text;
                frmEnviarEmail.ShowDialog();
            }
        }

        #endregion

        #region Eventos referente ao CPF/CNPJ

        private void cbbTipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCPF_CNPJ.Clear();

            if (cbbTipoPessoa.Text == "Física")
            {
                lblDescTipoPessoa.Text = "CPF";
            }
            else
            {
                lblDescTipoPessoa.Text = "CNPJ";
            }
        }

        private void txtCPF_CNPJ_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtCPF_CNPJ.Text.Length == 14)
                {
                    string cpftemp = txtCPF_CNPJ.Text;

                    txtCPF_CNPJ.Clear();

                    txtCPF_CNPJ.Text = cpftemp.Substring(0, 3);
                    txtCPF_CNPJ.Text += cpftemp.Substring(4, 3);
                    txtCPF_CNPJ.Text += cpftemp.Substring(8, 3);
                    txtCPF_CNPJ.Text += cpftemp.Substring(12, 2);
                }
                else
                {
                    if (txtCPF_CNPJ.Text.Length == 18)
                    {
                        string cnpjtemp = txtCPF_CNPJ.Text;

                        txtCPF_CNPJ.Clear();

                        txtCPF_CNPJ.Text = cnpjtemp.Substring(0, 2);
                        txtCPF_CNPJ.Text += cnpjtemp.Substring(3, 3);
                        txtCPF_CNPJ.Text += cnpjtemp.Substring(7, 3);
                        txtCPF_CNPJ.Text += cnpjtemp.Substring(11, 4);
                        txtCPF_CNPJ.Text += cnpjtemp.Substring(16, 2);
                    }
                }
            }
            catch { }
        }

        private void txtCPF_CNPJ_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtCPF_CNPJ_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCPF_CNPJ.Text.Length == 11)
                {
                    if (Util.ValidaCPF(txtCPF_CNPJ.Text))
                    {
                        string cpftemp = txtCPF_CNPJ.Text;
                        txtCPF_CNPJ.Clear();

                        txtCPF_CNPJ.Text = cpftemp.Substring(0, 3);
                        txtCPF_CNPJ.Text += "." + cpftemp.Substring(3, 3);
                        txtCPF_CNPJ.Text += "." + cpftemp.Substring(6, 3);
                        txtCPF_CNPJ.Text += "-" + cpftemp.Substring(9, 2);
                    }
                    else
                    {
                        MessageBox.Show("CPF Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCPF_CNPJ.Clear();
                        txtCPF_CNPJ.Focus();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCPF_CNPJ.Text))
                    {
                        if (Util.ValidaCNPJ(txtCPF_CNPJ.Text))
                        {
                            string cnpjtemp = txtCPF_CNPJ.Text;
                            txtCPF_CNPJ.Clear();

                            txtCPF_CNPJ.Text = cnpjtemp.Substring(0, 2);
                            txtCPF_CNPJ.Text += "." + cnpjtemp.Substring(2, 3);
                            txtCPF_CNPJ.Text += "." + cnpjtemp.Substring(5, 3);
                            txtCPF_CNPJ.Text += "/" + cnpjtemp.Substring(8, 4);
                            txtCPF_CNPJ.Text += "-" + cnpjtemp.Substring(12, 2);
                        }
                        else
                        {
                            MessageBox.Show("CNPJ Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCPF_CNPJ.Clear();
                            txtCPF_CNPJ.Focus();
                        }
                    }
                }
            }
            catch { }
        }

        #endregion

        #region Eventos Telefones

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtTelefone);
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtTelefone);
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtCelular);
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtCelular);
        }



        #endregion

        private void btnPesquisarCidade_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCidades frmCidades = new FrmCidades();
                frmCidades.ShowDialog();

                if (frmCidades._CidadeId > 0)
                {
                    cidadeId = frmCidades._CidadeId;
                    txtCidade.Text = frmCidades._Cidade + " - " + frmCidades._UF; ;
                }
                else
                {
                    cidadeId = 0;
                    txtCidade.Text = "SELECIONE A CIDADE";
                }

                txtSite.Focus();
            }
            catch { }
        }

        #region Eventos TabGrid

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(FornecedorId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (NomeFantasia like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (CpfCnpj like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";

            grid.DataSource = dv;

            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
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
            if (grid.Rows.Count > 0)
            {
                try
                {
                    if (_Pesquisando)
                    {
                        _FornecedorId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FornecedorId_"].Value);
                        _Nome = grid.Rows[grid.CurrentRow.Index].Cells["Nome"].Value.ToString();

                        this.Close();
                    }
                    else
                    {
                        CarregarFornecedor(Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FornecedorId_"].Value));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar carregar o Fornecedor selecionado!\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
            }
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Focus();
            }
        }

        #endregion

    }
}
