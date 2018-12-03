namespace PDV.Apresentacao.Cadastros
{
    partial class FrmGerenciamentoTributario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbTipo = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.TributacaoFiscalId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegimeTributario_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Icms_Issqn_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cfop_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MovimentaEstoque_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GerarFinanceiro_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CalcularIBPT_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsCst_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origem_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPercentualBC_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IcmsPercentual_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiCst_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiPercentualBC_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IpiPercentual_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisCst_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PisPercentualBC_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PercentualPis_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsCst_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsPercentualBC_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CofinsPercentual_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNovoSaida = new System.Windows.Forms.Button();
            this.btnNovoEntrada = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lblQuantidade = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDescricao
            // 
            this.txtDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricao.Location = new System.Drawing.Point(173, 28);
            this.txtDescricao.MaxLength = 75;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(751, 23);
            this.txtDescricao.TabIndex = 4;
            this.txtDescricao.TextChanged += new System.EventHandler(this.txtDescricao_TextChanged);
            this.txtDescricao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescricao_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Descrição";
            // 
            // cbbTipo
            // 
            this.cbbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipo.FormattingEnabled = true;
            this.cbbTipo.Items.AddRange(new object[] {
            "TODOS",
            "ENTRADA",
            "SAÍDA"});
            this.cbbTipo.Location = new System.Drawing.Point(8, 27);
            this.cbbTipo.Name = "cbbTipo";
            this.cbbTipo.Size = new System.Drawing.Size(159, 24);
            this.cbbTipo.TabIndex = 215;
            this.cbbTipo.SelectedIndexChanged += new System.EventHandler(this.cbbTipo_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 16);
            this.label2.TabIndex = 214;
            this.label2.Text = "Tipo";
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
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TributacaoFiscalId_,
            this.Descricao_,
            this.RegimeTributario_,
            this.Tipo_,
            this.Icms_Issqn_,
            this.Cfop_,
            this.MovimentaEstoque_,
            this.GerarFinanceiro_,
            this.CalcularIBPT_,
            this.IcmsCst_,
            this.Origem_,
            this.IcmsPercentualBC_,
            this.IcmsPercentual_,
            this.IpiCst_,
            this.IpiPercentualBC_,
            this.IpiPercentual_,
            this.PisCst_,
            this.PisPercentualBC_,
            this.PercentualPis_,
            this.CofinsCst_,
            this.CofinsPercentualBC_,
            this.CofinsPercentual_});
            this.grid.Location = new System.Drawing.Point(8, 57);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 10;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(916, 373);
            this.grid.TabIndex = 341;
            this.grid.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.grid_RowsAdded);
            this.grid.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.grid_RowsRemoved);
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // TributacaoFiscalId_
            // 
            this.TributacaoFiscalId_.DataPropertyName = "TributacaoFiscalId";
            this.TributacaoFiscalId_.HeaderText = "TributacaoFiscalId";
            this.TributacaoFiscalId_.Name = "TributacaoFiscalId_";
            this.TributacaoFiscalId_.ReadOnly = true;
            this.TributacaoFiscalId_.Visible = false;
            // 
            // Descricao_
            // 
            this.Descricao_.DataPropertyName = "Descricao";
            this.Descricao_.HeaderText = "Descrição";
            this.Descricao_.Name = "Descricao_";
            this.Descricao_.ReadOnly = true;
            this.Descricao_.Width = 400;
            // 
            // RegimeTributario_
            // 
            this.RegimeTributario_.DataPropertyName = "RegimeTributario";
            this.RegimeTributario_.HeaderText = "Reg. Tributário";
            this.RegimeTributario_.Name = "RegimeTributario_";
            this.RegimeTributario_.ReadOnly = true;
            this.RegimeTributario_.Visible = false;
            // 
            // Tipo_
            // 
            this.Tipo_.DataPropertyName = "Tipo";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Tipo_.DefaultCellStyle = dataGridViewCellStyle2;
            this.Tipo_.HeaderText = "Tipo";
            this.Tipo_.Name = "Tipo_";
            this.Tipo_.ReadOnly = true;
            // 
            // Icms_Issqn_
            // 
            this.Icms_Issqn_.DataPropertyName = "Icms_Issqn";
            this.Icms_Issqn_.HeaderText = "Icms Issqn";
            this.Icms_Issqn_.Name = "Icms_Issqn_";
            this.Icms_Issqn_.ReadOnly = true;
            this.Icms_Issqn_.Visible = false;
            // 
            // Cfop_
            // 
            this.Cfop_.DataPropertyName = "Cfop";
            this.Cfop_.HeaderText = "Cfop";
            this.Cfop_.Name = "Cfop_";
            this.Cfop_.ReadOnly = true;
            this.Cfop_.Width = 450;
            // 
            // MovimentaEstoque_
            // 
            this.MovimentaEstoque_.DataPropertyName = "MovimentaEstoque";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.MovimentaEstoque_.DefaultCellStyle = dataGridViewCellStyle3;
            this.MovimentaEstoque_.HeaderText = "Mov. Est.";
            this.MovimentaEstoque_.Name = "MovimentaEstoque_";
            this.MovimentaEstoque_.ReadOnly = true;
            this.MovimentaEstoque_.Width = 70;
            // 
            // GerarFinanceiro_
            // 
            this.GerarFinanceiro_.DataPropertyName = "GerarFinanceiro";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GerarFinanceiro_.DefaultCellStyle = dataGridViewCellStyle4;
            this.GerarFinanceiro_.HeaderText = "Gerar Financ.";
            this.GerarFinanceiro_.Name = "GerarFinanceiro_";
            this.GerarFinanceiro_.ReadOnly = true;
            // 
            // CalcularIBPT_
            // 
            this.CalcularIBPT_.DataPropertyName = "CalcularIBPT";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.CalcularIBPT_.DefaultCellStyle = dataGridViewCellStyle5;
            this.CalcularIBPT_.HeaderText = "Calc. Ibpt";
            this.CalcularIBPT_.Name = "CalcularIBPT_";
            this.CalcularIBPT_.ReadOnly = true;
            this.CalcularIBPT_.Width = 70;
            // 
            // IcmsCst_
            // 
            this.IcmsCst_.DataPropertyName = "IcmsCst";
            this.IcmsCst_.HeaderText = "Icms Cst";
            this.IcmsCst_.Name = "IcmsCst_";
            this.IcmsCst_.ReadOnly = true;
            this.IcmsCst_.Width = 500;
            // 
            // Origem_
            // 
            this.Origem_.DataPropertyName = "Origem";
            this.Origem_.HeaderText = "Origem Icms";
            this.Origem_.Name = "Origem_";
            this.Origem_.ReadOnly = true;
            this.Origem_.Width = 500;
            // 
            // IcmsPercentualBC_
            // 
            this.IcmsPercentualBC_.DataPropertyName = "IcmsPercentualBC";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IcmsPercentualBC_.DefaultCellStyle = dataGridViewCellStyle6;
            this.IcmsPercentualBC_.HeaderText = "% BC Icms";
            this.IcmsPercentualBC_.Name = "IcmsPercentualBC_";
            this.IcmsPercentualBC_.ReadOnly = true;
            this.IcmsPercentualBC_.Width = 80;
            // 
            // IcmsPercentual_
            // 
            this.IcmsPercentual_.DataPropertyName = "IcmsPercentual";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IcmsPercentual_.DefaultCellStyle = dataGridViewCellStyle7;
            this.IcmsPercentual_.HeaderText = "% Icms";
            this.IcmsPercentual_.Name = "IcmsPercentual_";
            this.IcmsPercentual_.ReadOnly = true;
            this.IcmsPercentual_.Width = 80;
            // 
            // IpiCst_
            // 
            this.IpiCst_.DataPropertyName = "IpiCst";
            this.IpiCst_.HeaderText = "Ipi Cst";
            this.IpiCst_.Name = "IpiCst_";
            this.IpiCst_.ReadOnly = true;
            this.IpiCst_.Width = 500;
            // 
            // IpiPercentualBC_
            // 
            this.IpiPercentualBC_.DataPropertyName = "IpiPercentualBC";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IpiPercentualBC_.DefaultCellStyle = dataGridViewCellStyle8;
            this.IpiPercentualBC_.HeaderText = "% BC Ipi";
            this.IpiPercentualBC_.Name = "IpiPercentualBC_";
            this.IpiPercentualBC_.ReadOnly = true;
            this.IpiPercentualBC_.Width = 80;
            // 
            // IpiPercentual_
            // 
            this.IpiPercentual_.DataPropertyName = "IpiPercentual";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.IpiPercentual_.DefaultCellStyle = dataGridViewCellStyle9;
            this.IpiPercentual_.HeaderText = "% Ipi";
            this.IpiPercentual_.Name = "IpiPercentual_";
            this.IpiPercentual_.ReadOnly = true;
            this.IpiPercentual_.Width = 80;
            // 
            // PisCst_
            // 
            this.PisCst_.DataPropertyName = "PisCst";
            this.PisCst_.HeaderText = "Pis Cst";
            this.PisCst_.Name = "PisCst_";
            this.PisCst_.ReadOnly = true;
            this.PisCst_.Width = 500;
            // 
            // PisPercentualBC_
            // 
            this.PisPercentualBC_.DataPropertyName = "PisPercentualBC";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PisPercentualBC_.DefaultCellStyle = dataGridViewCellStyle10;
            this.PisPercentualBC_.HeaderText = "% BC Pis";
            this.PisPercentualBC_.Name = "PisPercentualBC_";
            this.PisPercentualBC_.ReadOnly = true;
            this.PisPercentualBC_.Width = 80;
            // 
            // PercentualPis_
            // 
            this.PercentualPis_.DataPropertyName = "PercentualPis";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.PercentualPis_.DefaultCellStyle = dataGridViewCellStyle11;
            this.PercentualPis_.HeaderText = "% Pis";
            this.PercentualPis_.Name = "PercentualPis_";
            this.PercentualPis_.ReadOnly = true;
            this.PercentualPis_.Width = 80;
            // 
            // CofinsCst_
            // 
            this.CofinsCst_.DataPropertyName = "CofinsCst";
            this.CofinsCst_.HeaderText = "Cofins Cst";
            this.CofinsCst_.Name = "CofinsCst_";
            this.CofinsCst_.ReadOnly = true;
            this.CofinsCst_.Width = 500;
            // 
            // CofinsPercentualBC_
            // 
            this.CofinsPercentualBC_.DataPropertyName = "CofinsPercentualBC";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CofinsPercentualBC_.DefaultCellStyle = dataGridViewCellStyle12;
            this.CofinsPercentualBC_.HeaderText = "% BC Cofins";
            this.CofinsPercentualBC_.Name = "CofinsPercentualBC_";
            this.CofinsPercentualBC_.ReadOnly = true;
            // 
            // CofinsPercentual_
            // 
            this.CofinsPercentual_.DataPropertyName = "CofinsPercentual";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.CofinsPercentual_.DefaultCellStyle = dataGridViewCellStyle13;
            this.CofinsPercentual_.HeaderText = "% Cofins";
            this.CofinsPercentual_.Name = "CofinsPercentual_";
            this.CofinsPercentual_.ReadOnly = true;
            this.CofinsPercentual_.Width = 80;
            // 
            // btnNovoSaida
            // 
            this.btnNovoSaida.BackColor = System.Drawing.Color.White;
            this.btnNovoSaida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoSaida.Image = global::PDV.Apresentacao.Properties.Resources.novo25;
            this.btnNovoSaida.Location = new System.Drawing.Point(760, 457);
            this.btnNovoSaida.Name = "btnNovoSaida";
            this.btnNovoSaida.Size = new System.Drawing.Size(164, 35);
            this.btnNovoSaida.TabIndex = 345;
            this.btnNovoSaida.TabStop = false;
            this.btnNovoSaida.Text = "Novo / Saída [ F3 ]";
            this.btnNovoSaida.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoSaida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoSaida.UseVisualStyleBackColor = false;
            this.btnNovoSaida.Click += new System.EventHandler(this.btnNovoSaida_Click);
            // 
            // btnNovoEntrada
            // 
            this.btnNovoEntrada.BackColor = System.Drawing.Color.White;
            this.btnNovoEntrada.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNovoEntrada.Image = global::PDV.Apresentacao.Properties.Resources.novo25;
            this.btnNovoEntrada.Location = new System.Drawing.Point(590, 457);
            this.btnNovoEntrada.Name = "btnNovoEntrada";
            this.btnNovoEntrada.Size = new System.Drawing.Size(164, 35);
            this.btnNovoEntrada.TabIndex = 344;
            this.btnNovoEntrada.TabStop = false;
            this.btnNovoEntrada.Text = "Novo / Entrada [ F2 ]";
            this.btnNovoEntrada.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNovoEntrada.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnNovoEntrada.UseVisualStyleBackColor = false;
            this.btnNovoEntrada.Click += new System.EventHandler(this.btnNovoEntrada_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::PDV.Apresentacao.Properties.Resources.trash__1_;
            this.btnExcluir.Location = new System.Drawing.Point(173, 457);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(159, 35);
            this.btnExcluir.TabIndex = 343;
            this.btnExcluir.TabStop = false;
            this.btnExcluir.Text = "Excluir [ F8 ]";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.White;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnAlterar.Location = new System.Drawing.Point(8, 457);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(159, 35);
            this.btnAlterar.TabIndex = 342;
            this.btnAlterar.TabStop = false;
            this.btnAlterar.Text = "Alterar [ F5 ]";
            this.btnAlterar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAlterar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(8, 429);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(916, 21);
            this.lblQuantidade.TabIndex = 346;
            this.lblQuantidade.Text = "Resultados encontrados";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FrmGerenciamentoTributario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 504);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.btnNovoSaida);
            this.Controls.Add(this.btnNovoEntrada);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.cbbTipo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmGerenciamentoTributario";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grupos de Imposto cadastrados";
            this.Load += new System.EventHandler(this.FrmGerenciamentoTributario_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmGerenciamentoTributario_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbbTipo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Button btnNovoSaida;
        private System.Windows.Forms.Button btnNovoEntrada;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnAlterar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn TributacaoFiscalId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao_;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegimeTributario_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Icms_Issqn_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cfop_;
        private System.Windows.Forms.DataGridViewTextBoxColumn MovimentaEstoque_;
        private System.Windows.Forms.DataGridViewTextBoxColumn GerarFinanceiro_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CalcularIBPT_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsCst_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Origem_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentualBC_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IcmsPercentual_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiCst_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiPercentualBC_;
        private System.Windows.Forms.DataGridViewTextBoxColumn IpiPercentual_;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisCst_;
        private System.Windows.Forms.DataGridViewTextBoxColumn PisPercentualBC_;
        private System.Windows.Forms.DataGridViewTextBoxColumn PercentualPis_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsCst_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsPercentualBC_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CofinsPercentual_;
    }
}