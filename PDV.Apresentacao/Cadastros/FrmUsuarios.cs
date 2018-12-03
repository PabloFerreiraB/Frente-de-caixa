using PDV.AcessoBancoDados;
using PDV.Apresentacao.Emails;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        #region Instâncias

        UsuariosNegocios usuariosNegocios = new UsuariosNegocios();
        PermissoesNegociso permissoesNegociso = new PermissoesNegociso();
        FormulariosNegocios formulariosNegocios = new FormulariosNegocios();
        Cryptografia cryptografia = new Cryptografia();

        #endregion

        #region Propriedades

        public string _Email { get; set; }
        public int _UsuarioId = 0;
        bool pesquisouUsuario = false;

        #endregion

        #region Variáveis

        DataTable dtForms = new DataTable();
        DataTable dtGrid = new DataTable();
        int usuarioId = 0;

        #endregion

        #region Métodos

        private void HabilitaCampos(bool ativa)
        {
            txtNome.Enabled = txtNomeLogin.Enabled = txtSenha.Enabled = txtConfirmarSenha.Enabled = chkAtivo.Enabled = ativa;
            cbbPerfilUsuario.Enabled = ativa;
            cbbUsuarios.Enabled = btnSalvarPermissoes.Enabled = chkSelecionarTodos.Enabled = txtPesquisar.Enabled = ativa;
            txtNome.Focus();
        }

        private void HabilitaCamposPermissoes(bool ativa)
        {
            cbbUsuarios.Enabled = chkSelecionarTodos.Enabled = txtPesquisar.Enabled = btnSalvarPermissoes.Enabled = grid.Enabled = btnSalvar.Enabled = ativa;
            txtPesquisarUsuario.Clear();
            txtPesquisarUsuario.Focus();
        }

        private void Limpar()
        {
            txtNome.Text = txtNomeLogin.Text = txtSenha.Text = txtConfirmarSenha.Text = txtPesquisar.Text = string.Empty;
            chkAtivo.Checked = true;
            tabControl.SelectedIndex = 0;
            cbbPerfilUsuario.SelectedIndex = -1;
            if (!pesquisouUsuario)
                cbbUsuarios.SelectedIndex = -1;
            btnPesquisar.Enabled = true;
            lblMensagemSenha.Visible = false;
        }

        private Boolean ValidaCampos()
        {
            string erro = "";

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                erro = "Nome!";
            }
            if (string.IsNullOrEmpty(txtNomeLogin.Text))
            {
                erro += "\nUsuário!";
            }
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                erro += "\nSenha!";
            }
            if (string.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                erro += "\nConfirmar senha!";
            }
            if (string.IsNullOrEmpty(cbbPerfilUsuario.Text))
            {
                erro += "\nPerfil do usuário!";
            }

            if (erro != "")
            {
                MessageBox.Show("Os seguintes campos não foram informados : \n\n" + erro, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }


        private void CarregaComboboxUsuarios()
        {
            cbbUsuarios.DataSource = usuariosNegocios.PesquisarPorNome(string.Empty);
            cbbUsuarios.DisplayMember = "NomeLogin";
            cbbUsuarios.ValueMember = "UsuarioId";
            cbbUsuarios.SelectedIndex = -1;
        }

        private void CarregarGridUsuariosCadastrados()
        {
            try
            {
                dtGrid = usuariosNegocios.CarregarGridUsuario();
                gridUsuarios.DataSource = dtGrid;

                _UsuarioId = gridUsuarios.Rows.Count;
                lblQuantidadeUsuarios.Text = gridUsuarios.Rows.Count + " Usuário(s)";
                usuarioId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os Usuários cadastrados.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarGridFormularios()
        {
            grid.Rows.Clear();

            DataTable dtForms = new DataTable();
            dtForms = formulariosNegocios.PesquisarPorDescricao(string.Empty);

            if (dtForms.Rows.Count > 0 && dtForms != null)
            {
                for (int i = 0; i < dtForms.Rows.Count; i++)
                {
                    grid.Rows.Add(dtForms.Rows[i]["FormulariosId"].ToString(), dtForms.Rows[i]["Nome"].ToString(), false, false, false, false);
                }
            }

            lblQuantidadeFormularios.Text = grid.Rows.Count + " Formulários";
        }

        private void HabilitaRows()
        {
            foreach (DataGridViewRow gridRows in grid.Rows)
            {
                gridRows.Visible = true;
            }
        }

        private void SelecionarTodos(bool ativo)
        {
            foreach (DataGridViewRow r in grid.Rows)
            {
                r.Cells["Inserir"].Value = ativo;
                r.Cells["Alterar"].Value = ativo;
                r.Cells["Excluir"].Value = ativo;
                r.Cells["Visualizar"].Value = ativo;
            }
        }

        #endregion


        private void FrmPermissoesSistema_Load(object sender, EventArgs e)
        {
            CarregaComboboxUsuarios();
            CarregarGridFormularios();
            CarregarGridUsuariosCadastrados();
        }

        private void FrmPermissoesSistema_KeyDown(object sender, KeyEventArgs e)
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
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F12)
            {
                btnEmail_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F7 && btnSalvarPermissoes.Enabled)
            {
                btnSalvarPermissoes_Click(sender, e);
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
                tabControl.SelectedIndex = 0;
            }

            usuarioId = 0;
            pesquisouUsuario = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    Usuarios usuarios = new Usuarios();

                    usuarios.Nome = txtNome.Text;
                    usuarios.Ativo = chkAtivo.Checked;
                    usuarios.NomeLogin = txtNomeLogin.Text;
                    usuarios.Senha = cryptografia.Crypto(txtSenha.Text, true);
                    usuarios.Perfil = cbbPerfilUsuario.Text;
                    usuarios.DataCadastro = DateTime.Now;

                    if (usuarioId <= 0)
                    {
                        usuariosNegocios.Inserir(usuarios);
                        MessageBox.Show("Usuário cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitaCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGridUsuariosCadastrados();
                        CarregarGridFormularios();
                        CarregaComboboxUsuarios();
                        btnPesquisar_Click(sender, e);
                    }
                    else
                    {
                        usuarios.UsuarioId = usuarioId;

                        usuariosNegocios.Alterar(usuarios);
                        MessageBox.Show("Usuário alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitaCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGridUsuariosCadastrados();
                        CarregarGridFormularios();
                        CarregaComboboxUsuarios();
                        btnPesquisar_Click(sender, e);
                    }

                    toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                    usuarioId = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o usuário!\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 1)
            {
                HabilitaCamposPermissoes(false);
                tabControl.SelectedIndex = 1;
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
                frmEnviarEmail._Email = _Email;
                frmEnviarEmail.ShowDialog();
            }
        }

        #endregion

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSenha.Text))
            {
                lblMensagemSenha.Visible = false;
                txtConfirmarSenha.Clear();
            }
            else
            {
                if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
                {
                    lblMensagemSenha.Visible = true;
                    lblMensagemSenha.Text = "Senhas idênticas!";
                }
                else
                {
                    lblMensagemSenha.Visible = true;
                    lblMensagemSenha.Text = "Senhas precisam ser idênticas!";
                }
            }
        }

        private void txtConfirmarSenha_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSenha.Text))
            {
                if (txtSenha.Text.Equals(txtConfirmarSenha.Text))
                {
                    lblMensagemSenha.Visible = true;
                    lblMensagemSenha.Text = "Senhas idênticas!";
                }
                else
                {
                    lblMensagemSenha.Visible = true;
                    lblMensagemSenha.Text = "Senhas precisam ser idênticas!";
                }
            }
        }


        #region Parte de Permissões

        private void chkSelecionarTodos_CheckedChanged(object sender, EventArgs e)
        {
            SelecionarTodos(chkSelecionarTodos.Checked);
        }

        private void cbbUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (pesquisouUsuario)
                {
                    Limpar();
                }

                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    Permissoes permissoes = new Permissoes();
                    permissoes = permissoesNegociso.PesquisarPorFormulario(Convert.ToInt32(cbbUsuarios.SelectedValue), Convert.ToInt32(grid.Rows[i].Cells["FormulariosId"].Value));

                    grid.Rows[i].Cells["Inserir"].Value = permissoes.Inserir;
                    grid.Rows[i].Cells["Alterar"].Value = permissoes.Alterar;
                    grid.Rows[i].Cells["Excluir"].Value = permissoes.Excluir;
                    grid.Rows[i].Cells["Visualizar"].Value = permissoes.Visualizar;
                }

                chkSelecionarTodos.Checked = false;
            }
            catch
            { }
        }

        private void txtPesquisar_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPesquisar.Text.Trim()))
            {
                HabilitaRows();

                if (!string.IsNullOrEmpty(txtPesquisar.Text.TrimStart().TrimEnd()))
                {
                    foreach (DataGridViewRow gridRows in grid.Rows)
                    {
                        if (!gridRows.Cells["NomeFormulario"].Value.ToString().ToUpper().Contains(txtPesquisar.Text.ToUpper()))
                        {
                            gridRows.Visible = false;
                        }
                    }
                }
            }
        }

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPesquisar.Text))
                CarregarGridFormularios();
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                txtPesquisar_Leave(sender, e);
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        private void btnSalvarPermissoes_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cbbUsuarios.Text))
            {
                bool erro = false;
                usuarioId = Convert.ToInt32(cbbUsuarios.SelectedValue);

                try
                {
                    Permissoes permissoes = new Permissoes();
                    permissoes.UsuarioId = usuarioId;

                    permissoesNegociso.Excluir(permissoes);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                foreach (DataGridViewRow r in grid.Rows)
                {
                    Permissoes permissoes = new Permissoes();

                    permissoes.UsuarioId = usuarioId;
                    permissoes.FormulariosId = Convert.ToInt32(r.Cells["FormulariosId"].Value);
                    permissoes.Inserir = Convert.ToBoolean(r.Cells["Inserir"].Value);
                    permissoes.Alterar = Convert.ToBoolean(r.Cells["Alterar"].Value);
                    permissoes.Excluir = Convert.ToBoolean(r.Cells["Excluir"].Value);
                    permissoes.Visualizar = Convert.ToBoolean((r.Cells["Visualizar"].Value));

                    if (!permissoesNegociso.Inserir(permissoes))
                        erro = !false;
                }

                if (!erro)
                {
                    MessageBox.Show(string.Format("Permissões para o usuário: {0} cadastrado com sucesso!", cbbUsuarios.Text), "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //InserirLog();
                    txtPesquisar.Clear();

                    CarregarGridFormularios();
                    cbbUsuarios_SelectedIndexChanged(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Selecione um usuário antes para prosseguir!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region TabPage - Usuários Cadastrados

        private void txtPesquisarUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && gridUsuarios.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                gridUsuarios.Focus();
            }
        }

        private void txtPesquisarUsuario_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(UsuarioId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (NomeLogin like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Perfil like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            gridUsuarios.DataSource = dv;

            lblQuantidadeUsuarios.Text = gridUsuarios.Rows.Count + " Usuário(s)";
        }

        private void gridUsuarios_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridUsuarios.Rows.Count > 0)
                {
                    usuarioId = Convert.ToInt32(gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["UsuarioId_"].Value);
                    txtNome.Text = gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["Nome"].Value.ToString();

                    string Ativo = gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["Ativo"].Value.ToString();
                    if (Ativo.Equals("Ativo"))
                        chkAtivo.Checked = true;
                    else
                        chkAtivo.Checked = false;

                    txtNomeLogin.Text = gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["NomeLogin"].Value.ToString();
                    txtSenha.Text = txtConfirmarSenha.Text = cryptografia.Crypto(gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["Senha"].Value.ToString(), false);
                    cbbPerfilUsuario.Text = gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["Perfil"].Value.ToString();
                    cbbUsuarios.SelectedValue = Convert.ToInt32(gridUsuarios.Rows[gridUsuarios.CurrentRow.Index].Cells["UsuarioId_"].Value);

                    HabilitaCampos(true);
                    HabilitaCamposPermissoes(true);
                    btnSalvar.Text = "Alterar [ F5 ]";
                    btnNovo.Text = "Cancelar [ F2 ]";
                    toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                    btnSalvar.Enabled = true;
                    pesquisouUsuario = true;

                    tabControl.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador do sistema!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada! \n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && string.IsNullOrEmpty(txtNome.Text))
            {
                txtPesquisar.Focus();
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                    Util.Tabfunction(e);
            }
        }

        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            HabilitaCamposPermissoes(false);
        }

        private void gridUsuarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridUsuarios_DoubleClick(sender, e);
            else if (e.KeyCode == Keys.Up && gridUsuarios.CurrentRow.Index == 0)
            {
                txtPesquisarUsuario.Select();
                txtPesquisarUsuario.Focus();
            }
        }


    }
}
