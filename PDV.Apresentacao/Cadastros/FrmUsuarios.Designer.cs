namespace PDV.Apresentacao.Cadastros
{
    partial class FrmUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblQuantidadeFormularios = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.FormulariosId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeFormulario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Inserir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Alterar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Excluir = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Visualizar = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSalvarPermissoes = new System.Windows.Forms.Button();
            this.cbbUsuarios = new System.Windows.Forms.ComboBox();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkSelecionarTodos = new System.Windows.Forms.CheckBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnEmail = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtNomeLogin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtConfirmarSenha = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblMensagemSenha = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbbPerfilUsuario = new System.Windows.Forms.ComboBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblQuantidadeUsuarios = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPesquisarUsuario = new System.Windows.Forms.TextBox();
            this.gridUsuarios = new System.Windows.Forms.DataGridView();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.UsuarioId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NomeLogin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Senha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Perfil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).BeginInit();
            this.SuspendLayout();
            // 
            // lblQuantidadeFormularios
            // 
            this.lblQuantidadeFormularios.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidadeFormularios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidadeFormularios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeFormularios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantidadeFormularios.Location = new System.Drawing.Point(12, 579);
            this.lblQuantidadeFormularios.Name = "lblQuantidadeFormularios";
            this.lblQuantidadeFormularios.Size = new System.Drawing.Size(689, 21);
            this.lblQuantidadeFormularios.TabIndex = 183;
            this.lblQuantidadeFormularios.Text = "Formulários e Permissões";
            this.lblQuantidadeFormularios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeight = 24;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FormulariosId,
            this.NomeFormulario,
            this.Inserir,
            this.Alterar,
            this.Excluir,
            this.Visualizar});
            this.grid.Location = new System.Drawing.Point(12, 372);
            this.grid.Name = "grid";
            this.grid.RowHeadersWidth = 20;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.Height = 18;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(689, 208);
            this.grid.TabIndex = 188;
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // FormulariosId
            // 
            this.FormulariosId.DataPropertyName = "FormulariosId";
            this.FormulariosId.HeaderText = "FormulariosId";
            this.FormulariosId.Name = "FormulariosId";
            this.FormulariosId.ReadOnly = true;
            this.FormulariosId.Visible = false;
            // 
            // NomeFormulario
            // 
            this.NomeFormulario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NomeFormulario.DataPropertyName = "Nome";
            this.NomeFormulario.HeaderText = "Formulários";
            this.NomeFormulario.Name = "NomeFormulario";
            this.NomeFormulario.ReadOnly = true;
            // 
            // Inserir
            // 
            this.Inserir.DataPropertyName = "Inserir";
            this.Inserir.HeaderText = "Inserir";
            this.Inserir.Name = "Inserir";
            this.Inserir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Inserir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Inserir.Width = 60;
            // 
            // Alterar
            // 
            this.Alterar.DataPropertyName = "Alterar";
            this.Alterar.HeaderText = "Alterar";
            this.Alterar.Name = "Alterar";
            this.Alterar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Alterar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Alterar.Width = 60;
            // 
            // Excluir
            // 
            this.Excluir.DataPropertyName = "Excluir";
            this.Excluir.HeaderText = "Excluir";
            this.Excluir.Name = "Excluir";
            this.Excluir.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Excluir.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Excluir.Width = 60;
            // 
            // Visualizar
            // 
            this.Visualizar.DataPropertyName = "Visualizar";
            this.Visualizar.HeaderText = "Visualizar";
            this.Visualizar.Name = "Visualizar";
            this.Visualizar.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Visualizar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Visualizar.Width = 70;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 324);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 187;
            this.label2.Text = "Pesquisar";
            // 
            // btnSalvarPermissoes
            // 
            this.btnSalvarPermissoes.BackColor = System.Drawing.Color.White;
            this.btnSalvarPermissoes.Enabled = false;
            this.btnSalvarPermissoes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvarPermissoes.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnSalvarPermissoes.Location = new System.Drawing.Point(566, 331);
            this.btnSalvarPermissoes.Name = "btnSalvarPermissoes";
            this.btnSalvarPermissoes.Size = new System.Drawing.Size(135, 35);
            this.btnSalvarPermissoes.TabIndex = 2;
            this.btnSalvarPermissoes.TabStop = false;
            this.btnSalvarPermissoes.Text = " Salvar [ F7 ]";
            this.btnSalvarPermissoes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvarPermissoes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvarPermissoes.UseVisualStyleBackColor = false;
            this.btnSalvarPermissoes.Click += new System.EventHandler(this.btnSalvarPermissoes_Click);
            // 
            // cbbUsuarios
            // 
            this.cbbUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUsuarios.Enabled = false;
            this.cbbUsuarios.FormattingEnabled = true;
            this.cbbUsuarios.Location = new System.Drawing.Point(12, 291);
            this.cbbUsuarios.Name = "cbbUsuarios";
            this.cbbUsuarios.Size = new System.Drawing.Size(226, 24);
            this.cbbUsuarios.TabIndex = 0;
            this.cbbUsuarios.SelectedIndexChanged += new System.EventHandler(this.cbbUsuarios_SelectedIndexChanged);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.Enabled = false;
            this.txtPesquisar.Location = new System.Drawing.Point(12, 343);
            this.txtPesquisar.MaxLength = 100;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(548, 23);
            this.txtPesquisar.TabIndex = 1;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
            this.txtPesquisar.Leave += new System.EventHandler(this.txtPesquisar_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 272);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 182;
            this.label1.Text = "Selecione o Usuário";
            // 
            // chkSelecionarTodos
            // 
            this.chkSelecionarTodos.AutoSize = true;
            this.chkSelecionarTodos.Enabled = false;
            this.chkSelecionarTodos.Location = new System.Drawing.Point(244, 294);
            this.chkSelecionarTodos.Name = "chkSelecionarTodos";
            this.chkSelecionarTodos.Size = new System.Drawing.Size(122, 20);
            this.chkSelecionarTodos.TabIndex = 7;
            this.chkSelecionarTodos.Text = "Selecionar todos";
            this.chkSelecionarTodos.UseVisualStyleBackColor = true;
            this.chkSelecionarTodos.CheckedChanged += new System.EventHandler(this.chkSelecionarTodos_CheckedChanged);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.btnEmail);
            this.menuPanel.Controls.Add(this.btnNovo);
            this.menuPanel.Controls.Add(this.btnSalvar);
            this.menuPanel.Controls.Add(this.btnPesquisar);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(713, 50);
            this.menuPanel.TabIndex = 225;
            // 
            // btnEmail
            // 
            this.btnEmail.BackColor = System.Drawing.Color.White;
            this.btnEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmail.Image = global::PDV.Apresentacao.Properties.Resources.email__1_;
            this.btnEmail.Location = new System.Drawing.Point(421, 7);
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(130, 35);
            this.btnEmail.TabIndex = 105;
            this.btnEmail.Text = " &E-mail [ F12 ]";
            this.btnEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEmail.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnEmail.UseVisualStyleBackColor = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovo.Image = global::PDV.Apresentacao.Properties.Resources.novo25;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNovo.Location = new System.Drawing.Point(6, 7);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(130, 35);
            this.btnNovo.TabIndex = 104;
            this.btnNovo.Text = " &Novo [ F2 ]";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovo.UseVisualStyleBackColor = false;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.Enabled = false;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnSalvar.Location = new System.Drawing.Point(142, 7);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(130, 35);
            this.btnSalvar.TabIndex = 0;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = " &Salvar [ F5 ]";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Image = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnPesquisar.Location = new System.Drawing.Point(278, 7);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(137, 35);
            this.btnPesquisar.TabIndex = 101;
            this.btnPesquisar.Text = " &Pesquisar [ F9 ]";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // txtNome
            // 
            this.txtNome.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNome.Enabled = false;
            this.txtNome.Location = new System.Drawing.Point(8, 28);
            this.txtNome.MaxLength = 100;
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(509, 23);
            this.txtNome.TabIndex = 0;
            this.txtNome.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNome_KeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 9);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(99, 16);
            this.label20.TabIndex = 217;
            this.label20.Text = "Nome Completo";
            // 
            // txtNomeLogin
            // 
            this.txtNomeLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNomeLogin.Enabled = false;
            this.txtNomeLogin.Location = new System.Drawing.Point(8, 79);
            this.txtNomeLogin.MaxLength = 30;
            this.txtNomeLogin.Name = "txtNomeLogin";
            this.txtNomeLogin.Size = new System.Drawing.Size(179, 23);
            this.txtNomeLogin.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 16);
            this.label5.TabIndex = 218;
            this.label5.Text = "Usuário de Login";
            // 
            // txtSenha
            // 
            this.txtSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSenha.Enabled = false;
            this.txtSenha.Location = new System.Drawing.Point(193, 79);
            this.txtSenha.MaxLength = 30;
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(159, 23);
            this.txtSenha.TabIndex = 2;
            this.txtSenha.UseSystemPasswordChar = true;
            this.txtSenha.TextChanged += new System.EventHandler(this.txtSenha_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 219;
            this.label3.Text = "Senha";
            // 
            // txtConfirmarSenha
            // 
            this.txtConfirmarSenha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmarSenha.Enabled = false;
            this.txtConfirmarSenha.Location = new System.Drawing.Point(358, 79);
            this.txtConfirmarSenha.MaxLength = 30;
            this.txtConfirmarSenha.Name = "txtConfirmarSenha";
            this.txtConfirmarSenha.Size = new System.Drawing.Size(159, 23);
            this.txtConfirmarSenha.TabIndex = 3;
            this.txtConfirmarSenha.UseSystemPasswordChar = true;
            this.txtConfirmarSenha.TextChanged += new System.EventHandler(this.txtConfirmarSenha_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(355, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 220;
            this.label4.Text = "Confirma Senha";
            // 
            // lblMensagemSenha
            // 
            this.lblMensagemSenha.AutoSize = true;
            this.lblMensagemSenha.ForeColor = System.Drawing.Color.Red;
            this.lblMensagemSenha.Location = new System.Drawing.Point(523, 82);
            this.lblMensagemSenha.Name = "lblMensagemSenha";
            this.lblMensagemSenha.Size = new System.Drawing.Size(136, 16);
            this.lblMensagemSenha.TabIndex = 221;
            this.lblMensagemSenha.Text = "Confirmação de senha";
            this.lblMensagemSenha.Visible = false;
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Enabled = false;
            this.chkAtivo.Location = new System.Drawing.Point(523, 30);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 20);
            this.chkAtivo.TabIndex = 222;
            this.chkAtivo.Text = "Ativo?";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 16);
            this.label6.TabIndex = 223;
            this.label6.Text = "Perfil do Usuário";
            // 
            // cbbPerfilUsuario
            // 
            this.cbbPerfilUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPerfilUsuario.Enabled = false;
            this.cbbPerfilUsuario.FormattingEnabled = true;
            this.cbbPerfilUsuario.Items.AddRange(new object[] {
            "Administrador",
            "Padrão",
            "Vendedor"});
            this.cbbPerfilUsuario.Location = new System.Drawing.Point(8, 130);
            this.cbbPerfilUsuario.Name = "cbbPerfilUsuario";
            this.cbbPerfilUsuario.Size = new System.Drawing.Size(226, 24);
            this.cbbPerfilUsuario.TabIndex = 4;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Location = new System.Drawing.Point(0, 56);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(713, 213);
            this.tabControl.TabIndex = 227;
            this.tabControl.MouseClick += new System.Windows.Forms.MouseEventHandler(this.tabControl_MouseClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.txtNome);
            this.tabPage1.Controls.Add(this.txtNomeLogin);
            this.tabPage1.Controls.Add(this.cbbPerfilUsuario);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtSenha);
            this.tabPage1.Controls.Add(this.chkAtivo);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.lblMensagemSenha);
            this.tabPage1.Controls.Add(this.txtConfirmarSenha);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(705, 184);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Cadastrar   ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.lblQuantidadeUsuarios);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtPesquisarUsuario);
            this.tabPage2.Controls.Add(this.gridUsuarios);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(705, 184);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Usuários cadastrados   ";
            // 
            // lblQuantidadeUsuarios
            // 
            this.lblQuantidadeUsuarios.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidadeUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidadeUsuarios.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblQuantidadeUsuarios.Location = new System.Drawing.Point(8, 155);
            this.lblQuantidadeUsuarios.Name = "lblQuantidadeUsuarios";
            this.lblQuantidadeUsuarios.Size = new System.Drawing.Size(689, 21);
            this.lblQuantidadeUsuarios.TabIndex = 184;
            this.lblQuantidadeUsuarios.Text = "Quantidade de usuários";
            this.lblQuantidadeUsuarios.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 16);
            this.label7.TabIndex = 106;
            this.label7.Text = "Pesquisar:";
            // 
            // txtPesquisarUsuario
            // 
            this.txtPesquisarUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisarUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPesquisarUsuario.Location = new System.Drawing.Point(79, 7);
            this.txtPesquisarUsuario.MaxLength = 30;
            this.txtPesquisarUsuario.Name = "txtPesquisarUsuario";
            this.txtPesquisarUsuario.Size = new System.Drawing.Size(441, 23);
            this.txtPesquisarUsuario.TabIndex = 105;
            this.txtPesquisarUsuario.TextChanged += new System.EventHandler(this.txtPesquisarUsuario_TextChanged);
            this.txtPesquisarUsuario.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisarUsuario_KeyDown);
            // 
            // gridUsuarios
            // 
            this.gridUsuarios.AllowUserToAddRows = false;
            this.gridUsuarios.AllowUserToDeleteRows = false;
            this.gridUsuarios.AllowUserToOrderColumns = true;
            this.gridUsuarios.AllowUserToResizeColumns = false;
            this.gridUsuarios.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            this.gridUsuarios.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.gridUsuarios.ColumnHeadersHeight = 24;
            this.gridUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridUsuarios.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UsuarioId_,
            this.Nome,
            this.Ativo,
            this.NomeLogin,
            this.Senha,
            this.Perfil,
            this.DataCadastro});
            this.gridUsuarios.Location = new System.Drawing.Point(8, 36);
            this.gridUsuarios.Name = "gridUsuarios";
            this.gridUsuarios.ReadOnly = true;
            this.gridUsuarios.RowHeadersWidth = 20;
            this.gridUsuarios.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridUsuarios.RowTemplate.Height = 18;
            this.gridUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridUsuarios.Size = new System.Drawing.Size(689, 140);
            this.gridUsuarios.TabIndex = 104;
            this.gridUsuarios.DoubleClick += new System.EventHandler(this.gridUsuarios_DoubleClick);
            this.gridUsuarios.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridUsuarios_KeyDown);
            // 
            // UsuarioId_
            // 
            this.UsuarioId_.DataPropertyName = "UsuarioId";
            this.UsuarioId_.HeaderText = "UsuarioId";
            this.UsuarioId_.Name = "UsuarioId_";
            this.UsuarioId_.ReadOnly = true;
            this.UsuarioId_.Visible = false;
            // 
            // Nome
            // 
            this.Nome.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nome.DataPropertyName = "Nome";
            this.Nome.HeaderText = "Nome";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo?";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 80;
            // 
            // NomeLogin
            // 
            this.NomeLogin.DataPropertyName = "NomeLogin";
            this.NomeLogin.HeaderText = "Nome de Login";
            this.NomeLogin.Name = "NomeLogin";
            this.NomeLogin.ReadOnly = true;
            this.NomeLogin.Width = 150;
            // 
            // Senha
            // 
            this.Senha.DataPropertyName = "Senha";
            this.Senha.HeaderText = "Senha";
            this.Senha.Name = "Senha";
            this.Senha.ReadOnly = true;
            this.Senha.Visible = false;
            // 
            // Perfil
            // 
            this.Perfil.DataPropertyName = "Perfil";
            this.Perfil.HeaderText = "Perfil";
            this.Perfil.Name = "Perfil";
            this.Perfil.ReadOnly = true;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            this.DataCadastro.HeaderText = "Data de cadastro";
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            this.DataCadastro.Width = 120;
            // 
            // FrmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 609);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.lblQuantidadeFormularios);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSalvarPermissoes);
            this.Controls.Add(this.cbbUsuarios);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkSelecionarTodos);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmUsuarios";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Usuários e Permissões do Sistema";
            this.Load += new System.EventHandler(this.FrmPermissoesSistema_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmPermissoesSistema_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridUsuarios)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuantidadeFormularios;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSalvarPermissoes;
        private System.Windows.Forms.ComboBox cbbUsuarios;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkSelecionarTodos;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnEmail;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtNomeLogin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtConfirmarSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblMensagemSenha;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbbPerfilUsuario;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPesquisarUsuario;
        private System.Windows.Forms.DataGridView gridUsuarios;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label lblQuantidadeUsuarios;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormulariosId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeFormulario;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Inserir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Alterar;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Excluir;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeLogin;
        private System.Windows.Forms.DataGridViewTextBoxColumn Senha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Perfil;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
    }
}