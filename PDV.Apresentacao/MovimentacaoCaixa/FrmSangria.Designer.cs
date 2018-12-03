namespace PDV.Apresentacao.MovimentacaoCaixa
{
    partial class FrmSangria
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblValor = new System.Windows.Forms.Label();
            this.lblSaldoApos = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.grid = new System.Windows.Forms.DataGridView();
            this.SangriaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CaixaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Usuario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorCaixa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorSangria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorAposSangria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataHora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSaldoAtual = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtValorSangria = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtSaldoApos = new PDV.Componentes.DecimalTextbox2Novo();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo atual";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(9, 70);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(102, 16);
            this.lblValor.TabIndex = 2;
            this.lblValor.Text = "Valor da sangria";
            // 
            // lblSaldoApos
            // 
            this.lblSaldoApos.AutoSize = true;
            this.lblSaldoApos.Location = new System.Drawing.Point(9, 131);
            this.lblSaldoApos.Name = "lblSaldoApos";
            this.lblSaldoApos.Size = new System.Drawing.Size(117, 16);
            this.lblSaldoApos.TabIndex = 4;
            this.lblSaldoApos.Text = "Saldo após sangria";
            // 
            // btnSalvar
            // 
            this.btnSalvar.BackColor = System.Drawing.Color.White;
            this.btnSalvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalvar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnSalvar.Location = new System.Drawing.Point(667, 219);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(134, 35);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.TabStop = false;
            this.btnSalvar.Text = " &Salvar [ F5 ]";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSalvar.UseVisualStyleBackColor = false;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
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
            this.SangriaId,
            this.CaixaId,
            this.UsuarioId,
            this.Usuario,
            this.ValorCaixa,
            this.ValorSangria,
            this.ValorAposSangria,
            this.DataHora,
            this.Tipo,
            this.Observacao});
            this.grid.Location = new System.Drawing.Point(152, 28);
            this.grid.MultiSelect = false;
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(649, 155);
            this.grid.TabIndex = 198;
            // 
            // SangriaId
            // 
            this.SangriaId.DataPropertyName = "SangriaId";
            this.SangriaId.HeaderText = "SangriaId";
            this.SangriaId.Name = "SangriaId";
            this.SangriaId.ReadOnly = true;
            this.SangriaId.Visible = false;
            // 
            // CaixaId
            // 
            this.CaixaId.DataPropertyName = "CaixaId";
            this.CaixaId.HeaderText = "CaixaId";
            this.CaixaId.Name = "CaixaId";
            this.CaixaId.ReadOnly = true;
            this.CaixaId.Visible = false;
            // 
            // UsuarioId
            // 
            this.UsuarioId.DataPropertyName = "UsuarioId";
            this.UsuarioId.HeaderText = "UsuariosId";
            this.UsuarioId.Name = "UsuarioId";
            this.UsuarioId.ReadOnly = true;
            this.UsuarioId.Visible = false;
            // 
            // Usuario
            // 
            this.Usuario.DataPropertyName = "Usuario";
            this.Usuario.HeaderText = "Usuário";
            this.Usuario.Name = "Usuario";
            this.Usuario.ReadOnly = true;
            // 
            // ValorCaixa
            // 
            this.ValorCaixa.DataPropertyName = "ValorCaixa";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorCaixa.DefaultCellStyle = dataGridViewCellStyle2;
            this.ValorCaixa.HeaderText = "Saldo anterior";
            this.ValorCaixa.Name = "ValorCaixa";
            this.ValorCaixa.ReadOnly = true;
            this.ValorCaixa.Width = 120;
            // 
            // ValorSangria
            // 
            this.ValorSangria.DataPropertyName = "ValorSangria";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorSangria.DefaultCellStyle = dataGridViewCellStyle3;
            this.ValorSangria.HeaderText = "Sangria / Suprimento";
            this.ValorSangria.Name = "ValorSangria";
            this.ValorSangria.ReadOnly = true;
            this.ValorSangria.Width = 160;
            // 
            // ValorAposSangria
            // 
            this.ValorAposSangria.DataPropertyName = "ValorAposSangria";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.ValorAposSangria.DefaultCellStyle = dataGridViewCellStyle4;
            this.ValorAposSangria.HeaderText = "Saldo atual";
            this.ValorAposSangria.Name = "ValorAposSangria";
            this.ValorAposSangria.ReadOnly = true;
            this.ValorAposSangria.Width = 140;
            // 
            // DataHora
            // 
            this.DataHora.DataPropertyName = "DataHora";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.DataHora.DefaultCellStyle = dataGridViewCellStyle5;
            this.DataHora.HeaderText = "Data";
            this.DataHora.Name = "DataHora";
            this.DataHora.ReadOnly = true;
            this.DataHora.Width = 135;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Visible = false;
            // 
            // Observacao
            // 
            this.Observacao.DataPropertyName = "Observacao";
            this.Observacao.HeaderText = "Observacao";
            this.Observacao.Name = "Observacao";
            this.Observacao.ReadOnly = true;
            this.Observacao.Width = 300;
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(12, 231);
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(649, 23);
            this.txtObservacao.TabIndex = 1;
            this.txtObservacao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtObservacao_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 200;
            this.label2.Text = "Referente a";
            // 
            // txtSaldoAtual
            // 
            this.txtSaldoAtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoAtual.Enabled = false;
            this.txtSaldoAtual.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoAtual.Location = new System.Drawing.Point(12, 28);
            this.txtSaldoAtual.Name = "txtSaldoAtual";
            this.txtSaldoAtual.Size = new System.Drawing.Size(134, 33);
            this.txtSaldoAtual.TabIndex = 3;
            this.txtSaldoAtual.Text = "0,00";
            this.txtSaldoAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldoAtual.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoAtual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoAtual_KeyPress);
            // 
            // txtValorSangria
            // 
            this.txtValorSangria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorSangria.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorSangria.Location = new System.Drawing.Point(12, 89);
            this.txtValorSangria.Name = "txtValorSangria";
            this.txtValorSangria.Size = new System.Drawing.Size(134, 33);
            this.txtValorSangria.TabIndex = 0;
            this.txtValorSangria.Text = "0,00";
            this.txtValorSangria.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorSangria.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorSangria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorSangria_KeyPress);
            this.txtValorSangria.Leave += new System.EventHandler(this.txtValorSangria_Leave);
            // 
            // txtSaldoApos
            // 
            this.txtSaldoApos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSaldoApos.Enabled = false;
            this.txtSaldoApos.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldoApos.Location = new System.Drawing.Point(12, 150);
            this.txtSaldoApos.Name = "txtSaldoApos";
            this.txtSaldoApos.Size = new System.Drawing.Size(134, 33);
            this.txtSaldoApos.TabIndex = 4;
            this.txtSaldoApos.Text = "0,00";
            this.txtSaldoApos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtSaldoApos.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtSaldoApos.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSaldoApos_KeyPress);
            // 
            // FrmSangria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 267);
            this.Controls.Add(this.txtSaldoApos);
            this.Controls.Add(this.txtValorSangria);
            this.Controls.Add(this.txtSaldoAtual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblSaldoApos);
            this.Controls.Add(this.lblValor);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmSangria";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retirando dinheiro do Caixa";
            this.Load += new System.EventHandler(this.FrmSangria_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmSangria_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.Label lblSaldoApos;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SangriaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CaixaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Usuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorCaixa;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorSangria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAposSangria;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataHora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private Componentes.DecimalTextbox2Novo txtSaldoAtual;
        private Componentes.DecimalTextbox2Novo txtValorSangria;
        private Componentes.DecimalTextbox2Novo txtSaldoApos;
    }
}