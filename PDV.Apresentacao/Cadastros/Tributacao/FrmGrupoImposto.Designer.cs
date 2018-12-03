namespace PDV.Apresentacao.Cadastros.Tributacao
{
    partial class FrmGrupoImposto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rbIcms = new System.Windows.Forms.RadioButton();
            this.rbIssqn = new System.Windows.Forms.RadioButton();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cbbRegimeTributario = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.txtDescricaoCfop = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btnCfop = new System.Windows.Forms.Button();
            this.chkCalcularIBPT = new System.Windows.Forms.CheckBox();
            this.chkGerarFinanceiro = new System.Windows.Forms.CheckBox();
            this.chkMovimentarEstoque = new System.Windows.Forms.CheckBox();
            this.chkCalcularIcmsST = new System.Windows.Forms.CheckBox();
            this.label55 = new System.Windows.Forms.Label();
            this.lblCstOrCsosn = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbbOrigem = new System.Windows.Forms.ComboBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.txtPercentualBCIcms = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualIcms = new PDV.Componentes.DecimalTextbox2Novo();
            this.lblIpi = new System.Windows.Forms.Label();
            this.lblCstSTIpi = new System.Windows.Forms.Label();
            this.cbbIpiCst = new System.Windows.Forms.ComboBox();
            this.lblPercentualIpi = new System.Windows.Forms.Label();
            this.lblPercentualBCIpi = new System.Windows.Forms.Label();
            this.lblCodigoEnqIpi = new System.Windows.Forms.Label();
            this.txtCodigoEnquadramentoIpi = new PDV.Componentes.Numero();
            this.txtPercentualBCIpi = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualIpi = new PDV.Componentes.DecimalTextbox2Novo();
            this.label4 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.cbbPis = new System.Windows.Forms.ComboBox();
            this.chkGerarPisST = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txtPercentualBCPis = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualPis = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualBCPisST = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualPisST = new PDV.Componentes.DecimalTextbox2Novo();
            this.label6 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.cbbCofins = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.chkGerarCofinsST = new System.Windows.Forms.CheckBox();
            this.txtPercentualBCCofins = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualCofins = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualCofinsST = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtPercentualBCCofinsST = new PDV.Componentes.DecimalTextbox2Novo();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gridEstados = new System.Windows.Forms.DataGridView();
            this.EstadoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NomeEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UF = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCodigoCfop = new PDV.Componentes.Numero();
            this.cbbIcms = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEstados)).BeginInit();
            this.SuspendLayout();
            // 
            // rbIcms
            // 
            this.rbIcms.AutoSize = true;
            this.rbIcms.Checked = true;
            this.rbIcms.Location = new System.Drawing.Point(705, 28);
            this.rbIcms.Name = "rbIcms";
            this.rbIcms.Size = new System.Drawing.Size(53, 20);
            this.rbIcms.TabIndex = 219;
            this.rbIcms.TabStop = true;
            this.rbIcms.Text = "Icms";
            this.rbIcms.UseVisualStyleBackColor = true;
            // 
            // rbIssqn
            // 
            this.rbIssqn.AutoSize = true;
            this.rbIssqn.Enabled = false;
            this.rbIssqn.Location = new System.Drawing.Point(764, 28);
            this.rbIssqn.Name = "rbIssqn";
            this.rbIssqn.Size = new System.Drawing.Size(56, 20);
            this.rbIssqn.TabIndex = 220;
            this.rbIssqn.Text = "Issqn";
            this.rbIssqn.UseVisualStyleBackColor = true;
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricao.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtDescricao.Location = new System.Drawing.Point(198, 27);
            this.txtDescricao.MaxLength = 75;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(501, 23);
            this.txtDescricao.TabIndex = 217;
            // 
            // cbbRegimeTributario
            // 
            this.cbbRegimeTributario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbRegimeTributario.FormattingEnabled = true;
            this.cbbRegimeTributario.Items.AddRange(new object[] {
            "0 - Simples nacional",
            "1 - Tributação normal"});
            this.cbbRegimeTributario.Location = new System.Drawing.Point(8, 27);
            this.cbbRegimeTributario.Name = "cbbRegimeTributario";
            this.cbbRegimeTributario.Size = new System.Drawing.Size(184, 24);
            this.cbbRegimeTributario.TabIndex = 218;
            this.cbbRegimeTributario.SelectedIndexChanged += new System.EventHandler(this.cbbRegimeTributario_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 16);
            this.label2.TabIndex = 222;
            this.label2.Text = "Regime Tributário";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(195, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 221;
            this.label1.Text = "Descrição";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(85, 60);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(63, 16);
            this.label36.TabIndex = 377;
            this.label36.Text = "Descrição";
            // 
            // txtDescricaoCfop
            // 
            this.txtDescricaoCfop.BackColor = System.Drawing.SystemColors.Window;
            this.txtDescricaoCfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricaoCfop.Location = new System.Drawing.Point(88, 79);
            this.txtDescricaoCfop.MaxLength = 500;
            this.txtDescricaoCfop.Name = "txtDescricaoCfop";
            this.txtDescricaoCfop.ReadOnly = true;
            this.txtDescricaoCfop.Size = new System.Drawing.Size(699, 23);
            this.txtDescricaoCfop.TabIndex = 376;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(5, 60);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(39, 16);
            this.label37.TabIndex = 375;
            this.label37.Text = "CFOP";
            // 
            // btnCfop
            // 
            this.btnCfop.BackColor = System.Drawing.Color.Transparent;
            this.btnCfop.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnCfop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnCfop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnCfop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCfop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCfop.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCfop.Location = new System.Drawing.Point(789, 74);
            this.btnCfop.Name = "btnCfop";
            this.btnCfop.Size = new System.Drawing.Size(31, 28);
            this.btnCfop.TabIndex = 378;
            this.btnCfop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCfop.UseVisualStyleBackColor = false;
            this.btnCfop.Click += new System.EventHandler(this.btnCfop_Click);
            // 
            // chkCalcularIBPT
            // 
            this.chkCalcularIBPT.AutoSize = true;
            this.chkCalcularIBPT.Checked = true;
            this.chkCalcularIBPT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCalcularIBPT.Location = new System.Drawing.Point(294, 114);
            this.chkCalcularIBPT.Name = "chkCalcularIBPT";
            this.chkCalcularIBPT.Size = new System.Drawing.Size(271, 20);
            this.chkCalcularIBPT.TabIndex = 381;
            this.chkCalcularIBPT.Text = "Calcular valor aproximado do tributos IBPT";
            this.chkCalcularIBPT.UseVisualStyleBackColor = true;
            // 
            // chkGerarFinanceiro
            // 
            this.chkGerarFinanceiro.AutoSize = true;
            this.chkGerarFinanceiro.Checked = true;
            this.chkGerarFinanceiro.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGerarFinanceiro.Location = new System.Drawing.Point(163, 114);
            this.chkGerarFinanceiro.Name = "chkGerarFinanceiro";
            this.chkGerarFinanceiro.Size = new System.Drawing.Size(125, 20);
            this.chkGerarFinanceiro.TabIndex = 380;
            this.chkGerarFinanceiro.Text = "Gerar financeiro?";
            this.chkGerarFinanceiro.UseVisualStyleBackColor = true;
            // 
            // chkMovimentarEstoque
            // 
            this.chkMovimentarEstoque.AutoSize = true;
            this.chkMovimentarEstoque.Checked = true;
            this.chkMovimentarEstoque.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMovimentarEstoque.Location = new System.Drawing.Point(8, 114);
            this.chkMovimentarEstoque.Name = "chkMovimentarEstoque";
            this.chkMovimentarEstoque.Size = new System.Drawing.Size(149, 20);
            this.chkMovimentarEstoque.TabIndex = 379;
            this.chkMovimentarEstoque.Text = "Movimentar estoque?";
            this.chkMovimentarEstoque.UseVisualStyleBackColor = true;
            // 
            // chkCalcularIcmsST
            // 
            this.chkCalcularIcmsST.AutoSize = true;
            this.chkCalcularIcmsST.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCalcularIcmsST.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCalcularIcmsST.Location = new System.Drawing.Point(8, 169);
            this.chkCalcularIcmsST.Name = "chkCalcularIcmsST";
            this.chkCalcularIcmsST.Size = new System.Drawing.Size(124, 20);
            this.chkCalcularIcmsST.TabIndex = 0;
            this.chkCalcularIcmsST.Text = "Calcular Icms ST";
            this.chkCalcularIcmsST.UseVisualStyleBackColor = true;
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Black;
            this.label55.Location = new System.Drawing.Point(696, 244);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(69, 16);
            this.label55.TabIndex = 393;
            this.label55.Text = "% do Icms";
            // 
            // lblCstOrCsosn
            // 
            this.lblCstOrCsosn.AutoSize = true;
            this.lblCstOrCsosn.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCstOrCsosn.ForeColor = System.Drawing.Color.Black;
            this.lblCstOrCsosn.Location = new System.Drawing.Point(5, 192);
            this.lblCstOrCsosn.Name = "lblCstOrCsosn";
            this.lblCstOrCsosn.Size = new System.Drawing.Size(111, 16);
            this.lblCstOrCsosn.TabIndex = 386;
            this.lblCstOrCsosn.Text = "ST do Icms Csosn";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Black;
            this.label53.Location = new System.Drawing.Point(569, 244);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(88, 16);
            this.label53.TabIndex = 392;
            this.label53.Text = "% BC do Icms";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(5, 244);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 16);
            this.label5.TabIndex = 389;
            this.label5.Text = "Origem";
            // 
            // cbbOrigem
            // 
            this.cbbOrigem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOrigem.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbOrigem.FormattingEnabled = true;
            this.cbbOrigem.Location = new System.Drawing.Point(8, 263);
            this.cbbOrigem.Name = "cbbOrigem";
            this.cbbOrigem.Size = new System.Drawing.Size(558, 24);
            this.cbbOrigem.TabIndex = 1;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.BackColor = System.Drawing.Color.Salmon;
            this.lblQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.ForeColor = System.Drawing.Color.Black;
            this.lblQuantidade.Location = new System.Drawing.Point(8, 143);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(812, 21);
            this.lblQuantidade.TabIndex = 396;
            this.lblQuantidade.Text = "ICMS";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPercentualBCIcms
            // 
            this.txtPercentualBCIcms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCIcms.Location = new System.Drawing.Point(572, 264);
            this.txtPercentualBCIcms.Name = "txtPercentualBCIcms";
            this.txtPercentualBCIcms.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCIcms.TabIndex = 397;
            this.txtPercentualBCIcms.Text = "0,00";
            this.txtPercentualBCIcms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCIcms.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualIcms
            // 
            this.txtPercentualIcms.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualIcms.Location = new System.Drawing.Point(699, 264);
            this.txtPercentualIcms.Name = "txtPercentualIcms";
            this.txtPercentualIcms.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualIcms.TabIndex = 398;
            this.txtPercentualIcms.Text = "0,00";
            this.txtPercentualIcms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualIcms.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // lblIpi
            // 
            this.lblIpi.BackColor = System.Drawing.Color.Salmon;
            this.lblIpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblIpi.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpi.ForeColor = System.Drawing.Color.Black;
            this.lblIpi.Location = new System.Drawing.Point(8, 296);
            this.lblIpi.Name = "lblIpi";
            this.lblIpi.Size = new System.Drawing.Size(812, 21);
            this.lblIpi.TabIndex = 399;
            this.lblIpi.Text = "IPI";
            this.lblIpi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCstSTIpi
            // 
            this.lblCstSTIpi.AutoSize = true;
            this.lblCstSTIpi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCstSTIpi.ForeColor = System.Drawing.Color.Black;
            this.lblCstSTIpi.Location = new System.Drawing.Point(5, 322);
            this.lblCstSTIpi.Name = "lblCstSTIpi";
            this.lblCstSTIpi.Size = new System.Drawing.Size(82, 16);
            this.lblCstSTIpi.TabIndex = 422;
            this.lblCstSTIpi.Text = "ST do Ipi Cst";
            // 
            // cbbIpiCst
            // 
            this.cbbIpiCst.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIpiCst.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbIpiCst.FormattingEnabled = true;
            this.cbbIpiCst.Location = new System.Drawing.Point(8, 341);
            this.cbbIpiCst.Name = "cbbIpiCst";
            this.cbbIpiCst.Size = new System.Drawing.Size(452, 24);
            this.cbbIpiCst.TabIndex = 421;
            // 
            // lblPercentualIpi
            // 
            this.lblPercentualIpi.AutoSize = true;
            this.lblPercentualIpi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualIpi.ForeColor = System.Drawing.Color.Black;
            this.lblPercentualIpi.Location = new System.Drawing.Point(696, 322);
            this.lblPercentualIpi.Name = "lblPercentualIpi";
            this.lblPercentualIpi.Size = new System.Drawing.Size(56, 16);
            this.lblPercentualIpi.TabIndex = 424;
            this.lblPercentualIpi.Text = "% do Ipi";
            // 
            // lblPercentualBCIpi
            // 
            this.lblPercentualBCIpi.AutoSize = true;
            this.lblPercentualBCIpi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualBCIpi.ForeColor = System.Drawing.Color.Black;
            this.lblPercentualBCIpi.Location = new System.Drawing.Point(569, 323);
            this.lblPercentualBCIpi.Name = "lblPercentualBCIpi";
            this.lblPercentualBCIpi.Size = new System.Drawing.Size(75, 16);
            this.lblPercentualBCIpi.TabIndex = 423;
            this.lblPercentualBCIpi.Text = "% BC do Ipi";
            // 
            // lblCodigoEnqIpi
            // 
            this.lblCodigoEnqIpi.AutoSize = true;
            this.lblCodigoEnqIpi.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodigoEnqIpi.ForeColor = System.Drawing.Color.Black;
            this.lblCodigoEnqIpi.Location = new System.Drawing.Point(463, 322);
            this.lblCodigoEnqIpi.Name = "lblCodigoEnqIpi";
            this.lblCodigoEnqIpi.Size = new System.Drawing.Size(81, 16);
            this.lblCodigoEnqIpi.TabIndex = 425;
            this.lblCodigoEnqIpi.Text = "Cód. Enq. Ipi";
            // 
            // txtCodigoEnquadramentoIpi
            // 
            this.txtCodigoEnquadramentoIpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoEnquadramentoIpi.Location = new System.Drawing.Point(466, 342);
            this.txtCodigoEnquadramentoIpi.MaxLength = 3;
            this.txtCodigoEnquadramentoIpi.Name = "txtCodigoEnquadramentoIpi";
            this.txtCodigoEnquadramentoIpi.Size = new System.Drawing.Size(100, 23);
            this.txtCodigoEnquadramentoIpi.TabIndex = 426;
            this.txtCodigoEnquadramentoIpi.Text = "0";
            this.txtCodigoEnquadramentoIpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoEnquadramentoIpi.ValorInteiro = 0;
            // 
            // txtPercentualBCIpi
            // 
            this.txtPercentualBCIpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCIpi.Location = new System.Drawing.Point(572, 342);
            this.txtPercentualBCIpi.Name = "txtPercentualBCIpi";
            this.txtPercentualBCIpi.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCIpi.TabIndex = 427;
            this.txtPercentualBCIpi.Text = "0,00";
            this.txtPercentualBCIpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCIpi.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualIpi
            // 
            this.txtPercentualIpi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualIpi.Location = new System.Drawing.Point(699, 342);
            this.txtPercentualIpi.Name = "txtPercentualIpi";
            this.txtPercentualIpi.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualIpi.TabIndex = 428;
            this.txtPercentualIpi.Text = "0,00";
            this.txtPercentualIpi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualIpi.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Salmon;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(8, 374);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(812, 21);
            this.label4.TabIndex = 429;
            this.label4.Text = "PIS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(5, 400);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(55, 16);
            this.label19.TabIndex = 432;
            this.label19.Text = "PIS CST";
            // 
            // cbbPis
            // 
            this.cbbPis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbPis.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbPis.FormattingEnabled = true;
            this.cbbPis.Location = new System.Drawing.Point(8, 419);
            this.cbbPis.Name = "cbbPis";
            this.cbbPis.Size = new System.Drawing.Size(812, 24);
            this.cbbPis.TabIndex = 430;
            this.cbbPis.SelectedIndexChanged += new System.EventHandler(this.cbbPis_SelectedIndexChanged);
            // 
            // chkGerarPisST
            // 
            this.chkGerarPisST.AutoSize = true;
            this.chkGerarPisST.Enabled = false;
            this.chkGerarPisST.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGerarPisST.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkGerarPisST.Location = new System.Drawing.Point(467, 472);
            this.chkGerarPisST.Name = "chkGerarPisST";
            this.chkGerarPisST.Size = new System.Drawing.Size(99, 20);
            this.chkGerarPisST.TabIndex = 431;
            this.chkGerarPisST.Text = "Gerar Pis ST";
            this.chkGerarPisST.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(696, 452);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 16);
            this.label15.TabIndex = 436;
            this.label15.Text = "% Pis ST";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(569, 452);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 16);
            this.label16.TabIndex = 435;
            this.label16.Text = "% BC do Pis ST";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(132, 452);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(43, 16);
            this.label17.TabIndex = 434;
            this.label17.Text = "% PIS";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(5, 452);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 16);
            this.label18.TabIndex = 433;
            this.label18.Text = "% BC do PIS";
            // 
            // txtPercentualBCPis
            // 
            this.txtPercentualBCPis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCPis.Location = new System.Drawing.Point(8, 471);
            this.txtPercentualBCPis.Name = "txtPercentualBCPis";
            this.txtPercentualBCPis.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCPis.TabIndex = 437;
            this.txtPercentualBCPis.Text = "0,00";
            this.txtPercentualBCPis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCPis.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualPis
            // 
            this.txtPercentualPis.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualPis.Location = new System.Drawing.Point(135, 471);
            this.txtPercentualPis.Name = "txtPercentualPis";
            this.txtPercentualPis.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualPis.TabIndex = 438;
            this.txtPercentualPis.Text = "0,00";
            this.txtPercentualPis.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualPis.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualBCPisST
            // 
            this.txtPercentualBCPisST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCPisST.Location = new System.Drawing.Point(572, 471);
            this.txtPercentualBCPisST.Name = "txtPercentualBCPisST";
            this.txtPercentualBCPisST.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCPisST.TabIndex = 439;
            this.txtPercentualBCPisST.Text = "0,00";
            this.txtPercentualBCPisST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCPisST.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualPisST
            // 
            this.txtPercentualPisST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualPisST.Location = new System.Drawing.Point(699, 471);
            this.txtPercentualPisST.Name = "txtPercentualPisST";
            this.txtPercentualPisST.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualPisST.TabIndex = 440;
            this.txtPercentualPisST.Text = "0,00";
            this.txtPercentualPisST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualPisST.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Salmon;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 502);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(812, 21);
            this.label6.TabIndex = 441;
            this.label6.Text = "COFINS";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(5, 528);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(71, 16);
            this.label25.TabIndex = 444;
            this.label25.Text = "Cofins CST";
            // 
            // cbbCofins
            // 
            this.cbbCofins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbCofins.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbCofins.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbbCofins.FormattingEnabled = true;
            this.cbbCofins.Location = new System.Drawing.Point(8, 547);
            this.cbbCofins.Name = "cbbCofins";
            this.cbbCofins.Size = new System.Drawing.Size(812, 24);
            this.cbbCofins.TabIndex = 442;
            this.cbbCofins.SelectedIndexChanged += new System.EventHandler(this.cbbCofins_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(5, 580);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(96, 16);
            this.label23.TabIndex = 445;
            this.label23.Text = "% BC do Cofins";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(132, 580);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(77, 16);
            this.label22.TabIndex = 446;
            this.label22.Text = "% do Cofins";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(569, 580);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 16);
            this.label21.TabIndex = 447;
            this.label21.Text = "% BC Cofins ST";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(696, 580);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(79, 16);
            this.label20.TabIndex = 448;
            this.label20.Text = "% Cofins ST";
            // 
            // chkGerarCofinsST
            // 
            this.chkGerarCofinsST.AutoSize = true;
            this.chkGerarCofinsST.Enabled = false;
            this.chkGerarCofinsST.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGerarCofinsST.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkGerarCofinsST.Location = new System.Drawing.Point(448, 600);
            this.chkGerarCofinsST.Name = "chkGerarCofinsST";
            this.chkGerarCofinsST.Size = new System.Drawing.Size(118, 20);
            this.chkGerarCofinsST.TabIndex = 443;
            this.chkGerarCofinsST.Text = "Gerar Cofins ST";
            this.chkGerarCofinsST.UseVisualStyleBackColor = true;
            // 
            // txtPercentualBCCofins
            // 
            this.txtPercentualBCCofins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCCofins.Location = new System.Drawing.Point(8, 599);
            this.txtPercentualBCCofins.Name = "txtPercentualBCCofins";
            this.txtPercentualBCCofins.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCCofins.TabIndex = 449;
            this.txtPercentualBCCofins.Text = "0,00";
            this.txtPercentualBCCofins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCCofins.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualCofins
            // 
            this.txtPercentualCofins.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualCofins.Location = new System.Drawing.Point(135, 599);
            this.txtPercentualCofins.Name = "txtPercentualCofins";
            this.txtPercentualCofins.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualCofins.TabIndex = 450;
            this.txtPercentualCofins.Text = "0,00";
            this.txtPercentualCofins.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualCofins.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualCofinsST
            // 
            this.txtPercentualCofinsST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualCofinsST.Location = new System.Drawing.Point(699, 599);
            this.txtPercentualCofinsST.Name = "txtPercentualCofinsST";
            this.txtPercentualCofinsST.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualCofinsST.TabIndex = 451;
            this.txtPercentualCofinsST.Text = "0,00";
            this.txtPercentualCofinsST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualCofinsST.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtPercentualBCCofinsST
            // 
            this.txtPercentualBCCofinsST.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualBCCofinsST.Location = new System.Drawing.Point(572, 599);
            this.txtPercentualBCCofinsST.Name = "txtPercentualBCCofinsST";
            this.txtPercentualBCCofinsST.Size = new System.Drawing.Size(121, 23);
            this.txtPercentualBCCofinsST.TabIndex = 452;
            this.txtPercentualBCCofinsST.Text = "0,00";
            this.txtPercentualBCCofinsST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPercentualBCCofinsST.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.btnSalvar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 632);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(828, 53);
            this.panel1.TabIndex = 453;
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnSalvar.Location = new System.Drawing.Point(686, 6);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(130, 35);
            this.btnSalvar.TabIndex = 454;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = " &Salvar [ F5 ]";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // gridEstados
            // 
            this.gridEstados.AllowUserToAddRows = false;
            this.gridEstados.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightBlue;
            this.gridEstados.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gridEstados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEstados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EstadoId,
            this.Check,
            this.NomeEstado,
            this.UF});
            this.gridEstados.Location = new System.Drawing.Point(840, 74);
            this.gridEstados.Name = "gridEstados";
            this.gridEstados.ReadOnly = true;
            this.gridEstados.RowHeadersWidth = 5;
            this.gridEstados.RowTemplate.Height = 20;
            this.gridEstados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEstados.Size = new System.Drawing.Size(144, 197);
            this.gridEstados.TabIndex = 454;
            // 
            // EstadoId
            // 
            this.EstadoId.HeaderText = "EstadoId";
            this.EstadoId.Name = "EstadoId";
            this.EstadoId.ReadOnly = true;
            this.EstadoId.Visible = false;
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.ReadOnly = true;
            this.Check.Width = 30;
            // 
            // NomeEstado
            // 
            this.NomeEstado.HeaderText = "Estado";
            this.NomeEstado.Name = "NomeEstado";
            this.NomeEstado.ReadOnly = true;
            this.NomeEstado.Width = 550;
            // 
            // UF
            // 
            this.UF.HeaderText = "UF";
            this.UF.Name = "UF";
            this.UF.ReadOnly = true;
            this.UF.Width = 150;
            // 
            // txtCodigoCfop
            // 
            this.txtCodigoCfop.BackColor = System.Drawing.SystemColors.Window;
            this.txtCodigoCfop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoCfop.Location = new System.Drawing.Point(8, 79);
            this.txtCodigoCfop.MaxLength = 4;
            this.txtCodigoCfop.Name = "txtCodigoCfop";
            this.txtCodigoCfop.ReadOnly = true;
            this.txtCodigoCfop.Size = new System.Drawing.Size(74, 23);
            this.txtCodigoCfop.TabIndex = 455;
            this.txtCodigoCfop.Text = "0";
            this.txtCodigoCfop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodigoCfop.ValorInteiro = 0;
            // 
            // cbbIcms
            // 
            this.cbbIcms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbIcms.FormattingEnabled = true;
            this.cbbIcms.Location = new System.Drawing.Point(8, 211);
            this.cbbIcms.Name = "cbbIcms";
            this.cbbIcms.Size = new System.Drawing.Size(812, 24);
            this.cbbIcms.TabIndex = 456;
            this.cbbIcms.SelectedIndexChanged += new System.EventHandler(this.cbbIcms_SelectedIndexChanged);
            // 
            // FrmGrupoImposto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 685);
            this.Controls.Add(this.cbbIcms);
            this.Controls.Add(this.txtCodigoCfop);
            this.Controls.Add(this.gridEstados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtPercentualBCCofinsST);
            this.Controls.Add(this.txtPercentualCofinsST);
            this.Controls.Add(this.txtPercentualCofins);
            this.Controls.Add(this.txtPercentualBCCofins);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.cbbCofins);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.chkGerarCofinsST);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPercentualPisST);
            this.Controls.Add(this.txtPercentualBCPisST);
            this.Controls.Add(this.txtPercentualPis);
            this.Controls.Add(this.txtPercentualBCPis);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cbbPis);
            this.Controls.Add(this.chkGerarPisST);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPercentualIpi);
            this.Controls.Add(this.txtPercentualBCIpi);
            this.Controls.Add(this.txtCodigoEnquadramentoIpi);
            this.Controls.Add(this.lblCstSTIpi);
            this.Controls.Add(this.cbbIpiCst);
            this.Controls.Add(this.lblPercentualIpi);
            this.Controls.Add(this.lblPercentualBCIpi);
            this.Controls.Add(this.lblCodigoEnqIpi);
            this.Controls.Add(this.lblIpi);
            this.Controls.Add(this.txtPercentualIcms);
            this.Controls.Add(this.txtPercentualBCIcms);
            this.Controls.Add(this.chkCalcularIcmsST);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.lblCstOrCsosn);
            this.Controls.Add(this.chkCalcularIBPT);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.chkGerarFinanceiro);
            this.Controls.Add(this.chkMovimentarEstoque);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCfop);
            this.Controls.Add(this.cbbOrigem);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.txtDescricaoCfop);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.rbIcms);
            this.Controls.Add(this.rbIssqn);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.cbbRegimeTributario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmGrupoImposto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Grupo de Imposto                                                        " +
    "                                         BC = Base de Cálculo       ST = Situaçã" +
    "o Tributária";
            this.Load += new System.EventHandler(this.FrmGrupoImposto_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGrupoImposto_KeyDown);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEstados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton rbIcms;
        public System.Windows.Forms.RadioButton rbIssqn;
        private System.Windows.Forms.TextBox txtDescricao;
        public System.Windows.Forms.ComboBox cbbRegimeTributario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.TextBox txtDescricaoCfop;
        private System.Windows.Forms.Label label37;
        public System.Windows.Forms.Button btnCfop;
        private System.Windows.Forms.CheckBox chkCalcularIBPT;
        private System.Windows.Forms.CheckBox chkGerarFinanceiro;
        private System.Windows.Forms.CheckBox chkMovimentarEstoque;
        private System.Windows.Forms.CheckBox chkCalcularIcmsST;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label lblCstOrCsosn;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.ComboBox cbbOrigem;
        private System.Windows.Forms.Label lblQuantidade;
        private Componentes.DecimalTextbox2Novo txtPercentualBCIcms;
        private Componentes.DecimalTextbox2Novo txtPercentualIcms;
        private System.Windows.Forms.Label lblIpi;
        private System.Windows.Forms.Label lblCstSTIpi;
        public System.Windows.Forms.ComboBox cbbIpiCst;
        private System.Windows.Forms.Label lblPercentualIpi;
        private System.Windows.Forms.Label lblPercentualBCIpi;
        private System.Windows.Forms.Label lblCodigoEnqIpi;
        private Componentes.Numero txtCodigoEnquadramentoIpi;
        private Componentes.DecimalTextbox2Novo txtPercentualBCIpi;
        private Componentes.DecimalTextbox2Novo txtPercentualIpi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label19;
        public System.Windows.Forms.ComboBox cbbPis;
        private System.Windows.Forms.CheckBox chkGerarPisST;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private Componentes.DecimalTextbox2Novo txtPercentualBCPis;
        private Componentes.DecimalTextbox2Novo txtPercentualPis;
        private Componentes.DecimalTextbox2Novo txtPercentualBCPisST;
        private Componentes.DecimalTextbox2Novo txtPercentualPisST;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label25;
        public System.Windows.Forms.ComboBox cbbCofins;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.CheckBox chkGerarCofinsST;
        private Componentes.DecimalTextbox2Novo txtPercentualBCCofins;
        private Componentes.DecimalTextbox2Novo txtPercentualCofins;
        private Componentes.DecimalTextbox2Novo txtPercentualCofinsST;
        private Componentes.DecimalTextbox2Novo txtPercentualBCCofinsST;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView gridEstados;
        private Componentes.Numero txtCodigoCfop;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstadoId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn NomeEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn UF;
        private System.Windows.Forms.ComboBox cbbIcms;
    }
}