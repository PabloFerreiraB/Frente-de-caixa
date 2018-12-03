namespace PDV.Apresentacao.Cadastros
{
    partial class FrmSubgrupoProdutos
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
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.SubgrupoProdutosId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoProdutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSubgrupoProdutos = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbbGrupoProdutos = new System.Windows.Forms.ComboBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.btnNovo);
            this.menuPanel.Controls.Add(this.btnSalvar);
            this.menuPanel.Controls.Add(this.btnExcluir);
            this.menuPanel.Controls.Add(this.btnPesquisar);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(557, 50);
            this.menuPanel.TabIndex = 200;
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
            // btnExcluir
            // 
            this.btnExcluir.BackColor = System.Drawing.Color.White;
            this.btnExcluir.Enabled = false;
            this.btnExcluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcluir.Image = global::PDV.Apresentacao.Properties.Resources.trash__1_;
            this.btnExcluir.Location = new System.Drawing.Point(278, 7);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(130, 35);
            this.btnExcluir.TabIndex = 102;
            this.btnExcluir.Text = " &Excluir [ F8 ]";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcluir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExcluir.UseVisualStyleBackColor = false;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.BackColor = System.Drawing.Color.White;
            this.btnPesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisar.Image = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnPesquisar.Location = new System.Drawing.Point(414, 7);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(137, 35);
            this.btnPesquisar.TabIndex = 101;
            this.btnPesquisar.Text = " &Pesquisar [ F9 ]";
            this.btnPesquisar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPesquisar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPesquisar.UseVisualStyleBackColor = false;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Enabled = false;
            this.chkAtivo.Location = new System.Drawing.Point(245, 78);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(61, 20);
            this.chkAtivo.TabIndex = 205;
            this.chkAtivo.Text = "Ativo?";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(6, 308);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(545, 21);
            this.lblQuantidade.TabIndex = 204;
            this.lblQuantidade.Text = "Resultados encontrados";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SubgrupoProdutosId_,
            this.Descricao,
            this.GrupoProdutos,
            this.Ativo});
            this.grid.Location = new System.Drawing.Point(6, 105);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(545, 204);
            this.grid.TabIndex = 203;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // SubgrupoProdutosId_
            // 
            this.SubgrupoProdutosId_.DataPropertyName = "SubgrupoProdutosId";
            this.SubgrupoProdutosId_.HeaderText = "Código";
            this.SubgrupoProdutosId_.Name = "SubgrupoProdutosId_";
            this.SubgrupoProdutosId_.ReadOnly = true;
            this.SubgrupoProdutosId_.Width = 70;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descricao";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // GrupoProdutos
            // 
            this.GrupoProdutos.DataPropertyName = "GrupoProdutos";
            this.GrupoProdutos.HeaderText = "Grupo";
            this.GrupoProdutos.Name = "GrupoProdutos";
            this.GrupoProdutos.ReadOnly = true;
            this.GrupoProdutos.Width = 130;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo?";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Width = 80;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(3, 57);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(69, 16);
            this.label20.TabIndex = 202;
            this.label20.Text = "Subgrupos";
            // 
            // txtSubgrupoProdutos
            // 
            this.txtSubgrupoProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubgrupoProdutos.Enabled = false;
            this.txtSubgrupoProdutos.Location = new System.Drawing.Point(6, 76);
            this.txtSubgrupoProdutos.MaxLength = 100;
            this.txtSubgrupoProdutos.Name = "txtSubgrupoProdutos";
            this.txtSubgrupoProdutos.Size = new System.Drawing.Size(233, 23);
            this.txtSubgrupoProdutos.TabIndex = 0;
            this.txtSubgrupoProdutos.TextChanged += new System.EventHandler(this.txtSubgrupoProdutos_TextChanged);
            this.txtSubgrupoProdutos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSubgrupoProdutos_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(316, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 16);
            this.label1.TabIndex = 207;
            this.label1.Text = "Grupo de Produtos";
            // 
            // cbbGrupoProdutos
            // 
            this.cbbGrupoProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGrupoProdutos.Enabled = false;
            this.cbbGrupoProdutos.FormattingEnabled = true;
            this.cbbGrupoProdutos.Location = new System.Drawing.Point(319, 75);
            this.cbbGrupoProdutos.Name = "cbbGrupoProdutos";
            this.cbbGrupoProdutos.Size = new System.Drawing.Size(232, 24);
            this.cbbGrupoProdutos.TabIndex = 1;
            // 
            // FrmSubgrupoProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 335);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbbGrupoProdutos);
            this.Controls.Add(this.chkAtivo);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.txtSubgrupoProdutos);
            this.Controls.Add(this.menuPanel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmSubgrupoProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Subgrupos de Produtos";
            this.Load += new System.EventHandler(this.FrmSubgrupoProdutos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSubgrupoProdutos_KeyDown);
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSubgrupoProdutos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbbGrupoProdutos;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubgrupoProdutosId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
    }
}