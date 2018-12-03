namespace PDV.Apresentacao.Cadastros.Tributacao
{
    partial class FrmCFOP
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
            this.label2 = new System.Windows.Forms.Label();
            this.lblAplicase = new System.Windows.Forms.Label();
            this.gridCFOP = new System.Windows.Forms.DataGridView();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.cbbAplicacao = new System.Windows.Forms.ComboBox();
            this.cbbTipoCFOP = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.CFOPId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aplica_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridCFOP)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 535);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 388;
            this.label2.Text = "Aplica-se";
            // 
            // lblAplicase
            // 
            this.lblAplicase.BackColor = System.Drawing.Color.White;
            this.lblAplicase.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAplicase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAplicase.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblAplicase.Location = new System.Drawing.Point(8, 554);
            this.lblAplicase.Name = "lblAplicase";
            this.lblAplicase.Size = new System.Drawing.Size(931, 67);
            this.lblAplicase.TabIndex = 387;
            // 
            // gridCFOP
            // 
            this.gridCFOP.AllowUserToAddRows = false;
            this.gridCFOP.AllowUserToDeleteRows = false;
            this.gridCFOP.AllowUserToResizeColumns = false;
            this.gridCFOP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.gridCFOP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.gridCFOP.ColumnHeadersHeight = 21;
            this.gridCFOP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gridCFOP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CFOPId_,
            this.Codigo,
            this.Grupo,
            this.Descricao,
            this.Aplica_});
            this.gridCFOP.Location = new System.Drawing.Point(8, 57);
            this.gridCFOP.Name = "gridCFOP";
            this.gridCFOP.ReadOnly = true;
            this.gridCFOP.RowHeadersWidth = 20;
            this.gridCFOP.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.gridCFOP.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridCFOP.Size = new System.Drawing.Size(931, 453);
            this.gridCFOP.TabIndex = 386;
            this.gridCFOP.SelectionChanged += new System.EventHandler(this.gridCFOP_SelectionChanged);
            this.gridCFOP.DoubleClick += new System.EventHandler(this.gridCFOP_DoubleClick);
            this.gridCFOP.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridCFOP_KeyDown);
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPesquisar.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPesquisar.Location = new System.Drawing.Point(278, 28);
            this.txtPesquisar.MaxLength = 75;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(661, 23);
            this.txtPesquisar.TabIndex = 385;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
            // 
            // cbbAplicacao
            // 
            this.cbbAplicacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbAplicacao.FormattingEnabled = true;
            this.cbbAplicacao.Items.AddRange(new object[] {
            "Todas",
            "Estadual",
            "Inter-Estadual",
            "Internacional"});
            this.cbbAplicacao.Location = new System.Drawing.Point(143, 27);
            this.cbbAplicacao.Name = "cbbAplicacao";
            this.cbbAplicacao.Size = new System.Drawing.Size(129, 24);
            this.cbbAplicacao.TabIndex = 384;
            this.cbbAplicacao.SelectedIndexChanged += new System.EventHandler(this.cbbAplicacao_SelectedIndexChanged);
            // 
            // cbbTipoCFOP
            // 
            this.cbbTipoCFOP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbTipoCFOP.FormattingEnabled = true;
            this.cbbTipoCFOP.Items.AddRange(new object[] {
            "Ambos",
            "Entrada",
            "Saida"});
            this.cbbTipoCFOP.Location = new System.Drawing.Point(8, 27);
            this.cbbTipoCFOP.Name = "cbbTipoCFOP";
            this.cbbTipoCFOP.Size = new System.Drawing.Size(129, 24);
            this.cbbTipoCFOP.TabIndex = 383;
            this.cbbTipoCFOP.SelectedIndexChanged += new System.EventHandler(this.cbbTipoCFOP_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 382;
            this.label4.Text = "Aplicação";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 381;
            this.label3.Text = "Tipo CFOP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(275, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 380;
            this.label1.Text = "Pesquisar";
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(8, 509);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(931, 21);
            this.lblQuantidade.TabIndex = 390;
            this.lblQuantidade.Text = "Resultados encontrados";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CFOPId_
            // 
            this.CFOPId_.DataPropertyName = "CfopId";
            this.CFOPId_.HeaderText = "CFOPId";
            this.CFOPId_.Name = "CFOPId_";
            this.CFOPId_.ReadOnly = true;
            this.CFOPId_.Visible = false;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "CFOP";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 80;
            // 
            // Grupo
            // 
            this.Grupo.DataPropertyName = "Grupo";
            this.Grupo.HeaderText = "Grupo";
            this.Grupo.Name = "Grupo";
            this.Grupo.ReadOnly = true;
            this.Grupo.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Width = 2000;
            // 
            // Aplica_
            // 
            this.Aplica_.DataPropertyName = "Aplica";
            this.Aplica_.HeaderText = "Aplica-se";
            this.Aplica_.Name = "Aplica_";
            this.Aplica_.ReadOnly = true;
            this.Aplica_.Visible = false;
            // 
            // FrmCFOP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 630);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAplicase);
            this.Controls.Add(this.gridCFOP);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.cbbAplicacao);
            this.Controls.Add(this.cbbTipoCFOP);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmCFOP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CFOP\'s / Operações Fiscais";
            this.Load += new System.EventHandler(this.FrmCFOP_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCFOP_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridCFOP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAplicase;
        private System.Windows.Forms.DataGridView gridCFOP;
        private System.Windows.Forms.TextBox txtPesquisar;
        public System.Windows.Forms.ComboBox cbbAplicacao;
        public System.Windows.Forms.ComboBox cbbTipoCFOP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn CFOPId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aplica_;
    }
}