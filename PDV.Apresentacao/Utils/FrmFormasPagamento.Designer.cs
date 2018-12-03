namespace PDV.Apresentacao.Utils
{
    partial class FrmFormasPagamento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblPercentualDesconto = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRestantePagar = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTroco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.grid = new System.Windows.Forms.DataGridView();
            this.Emissao_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Vencimento_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClientesId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamentoId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FormaPagamento_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parcela_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StatusPagamento_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorPago_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataPagamento_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PagouComCartão_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbFormaPagamento = new System.Windows.Forms.ComboBox();
            this.numVencimentoTodoDia = new System.Windows.Forms.NumericUpDown();
            this.numPrimeiroMes = new System.Windows.Forms.NumericUpDown();
            this.txtPercentualDesconto = new PDV.Componentes.Numero();
            this.txtPagando = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtValorTotal = new PDV.Componentes.DecimalTextbox2Novo();
            this.bntExcluirParcelas = new System.Windows.Forms.Button();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVencimentoTodoDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrimeiroMes)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(94, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 16);
            this.label9.TabIndex = 104;
            this.label9.Text = "1° Mês";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 131);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 16);
            this.label8.TabIndex = 103;
            this.label8.Text = "Venc. dia";
            // 
            // lblPercentualDesconto
            // 
            this.lblPercentualDesconto.AutoSize = true;
            this.lblPercentualDesconto.BackColor = System.Drawing.Color.Transparent;
            this.lblPercentualDesconto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentualDesconto.Location = new System.Drawing.Point(162, 70);
            this.lblPercentualDesconto.Name = "lblPercentualDesconto";
            this.lblPercentualDesconto.Size = new System.Drawing.Size(86, 16);
            this.lblPercentualDesconto.TabIndex = 102;
            this.lblPercentualDesconto.Text = "Desconto (%)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(315, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 16);
            this.label7.TabIndex = 97;
            this.label7.Text = "Restante";
            // 
            // txtRestantePagar
            // 
            this.txtRestantePagar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRestantePagar.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRestantePagar.Location = new System.Drawing.Point(318, 89);
            this.txtRestantePagar.MaxLength = 40;
            this.txtRestantePagar.Name = "txtRestantePagar";
            this.txtRestantePagar.ReadOnly = true;
            this.txtRestantePagar.Size = new System.Drawing.Size(124, 33);
            this.txtRestantePagar.TabIndex = 93;
            this.txtRestantePagar.Text = "0,00";
            this.txtRestantePagar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(448, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 16);
            this.label6.TabIndex = 95;
            this.label6.Text = "Troco";
            // 
            // txtTroco
            // 
            this.txtTroco.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTroco.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroco.Location = new System.Drawing.Point(448, 28);
            this.txtTroco.MaxLength = 40;
            this.txtTroco.Name = "txtTroco";
            this.txtTroco.ReadOnly = true;
            this.txtTroco.Size = new System.Drawing.Size(144, 33);
            this.txtTroco.TabIndex = 94;
            this.txtTroco.Text = "0,00";
            this.txtTroco.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(445, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 96;
            this.label4.Text = "Pagando";
            // 
            // grid
            // 
            this.grid.AllowUserToAddRows = false;
            this.grid.AllowUserToDeleteRows = false;
            this.grid.AllowUserToResizeColumns = false;
            this.grid.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.grid.ColumnHeadersHeight = 22;
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Emissao_,
            this.Vencimento_,
            this.ClientesId_,
            this.FormaPagamentoId_,
            this.FormaPagamento_,
            this.Valor_,
            this.Parcela_,
            this.Observacao_,
            this.StatusPagamento_,
            this.ValorPago_,
            this.DataPagamento_,
            this.PagouComCartão_});
            this.grid.Location = new System.Drawing.Point(12, 179);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersWidth = 30;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.RowTemplate.Height = 20;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(580, 193);
            this.grid.TabIndex = 101;
            // 
            // Emissao_
            // 
            this.Emissao_.HeaderText = "Emissao";
            this.Emissao_.Name = "Emissao_";
            this.Emissao_.ReadOnly = true;
            this.Emissao_.Visible = false;
            // 
            // Vencimento_
            // 
            this.Vencimento_.HeaderText = "Vecimento";
            this.Vencimento_.Name = "Vencimento_";
            this.Vencimento_.ReadOnly = true;
            // 
            // ClientesId_
            // 
            this.ClientesId_.HeaderText = "ClientesId";
            this.ClientesId_.Name = "ClientesId_";
            this.ClientesId_.ReadOnly = true;
            this.ClientesId_.Visible = false;
            // 
            // FormaPagamentoId_
            // 
            this.FormaPagamentoId_.HeaderText = "FormularioId";
            this.FormaPagamentoId_.Name = "FormaPagamentoId_";
            this.FormaPagamentoId_.ReadOnly = true;
            this.FormaPagamentoId_.Visible = false;
            // 
            // FormaPagamento_
            // 
            this.FormaPagamento_.HeaderText = "Forma de Pagamento";
            this.FormaPagamento_.Name = "FormaPagamento_";
            this.FormaPagamento_.ReadOnly = true;
            this.FormaPagamento_.Width = 200;
            // 
            // Valor_
            // 
            this.Valor_.HeaderText = "Valor";
            this.Valor_.Name = "Valor_";
            this.Valor_.ReadOnly = true;
            this.Valor_.Width = 90;
            // 
            // Parcela_
            // 
            this.Parcela_.HeaderText = "Parcela";
            this.Parcela_.Name = "Parcela_";
            this.Parcela_.ReadOnly = true;
            this.Parcela_.Width = 80;
            // 
            // Observacao_
            // 
            this.Observacao_.HeaderText = "Observacao";
            this.Observacao_.Name = "Observacao_";
            this.Observacao_.ReadOnly = true;
            this.Observacao_.Visible = false;
            // 
            // StatusPagamento_
            // 
            this.StatusPagamento_.HeaderText = "Status";
            this.StatusPagamento_.Name = "StatusPagamento_";
            this.StatusPagamento_.ReadOnly = true;
            // 
            // ValorPago_
            // 
            this.ValorPago_.HeaderText = "ValorPago";
            this.ValorPago_.Name = "ValorPago_";
            this.ValorPago_.ReadOnly = true;
            this.ValorPago_.Visible = false;
            // 
            // DataPagamento_
            // 
            this.DataPagamento_.HeaderText = "DataPagamento";
            this.DataPagamento_.Name = "DataPagamento_";
            this.DataPagamento_.ReadOnly = true;
            this.DataPagamento_.Visible = false;
            // 
            // PagouComCartão_
            // 
            this.PagouComCartão_.HeaderText = "PagouComCartão";
            this.PagouComCartão_.Name = "PagouComCartão_";
            this.PagouComCartão_.ReadOnly = true;
            this.PagouComCartão_.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 16);
            this.label5.TabIndex = 98;
            this.label5.Text = "Valor Total";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 16);
            this.label3.TabIndex = 99;
            this.label3.Text = "Forma de Pagamento";
            // 
            // cbbFormaPagamento
            // 
            this.cbbFormaPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbFormaPagamento.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbFormaPagamento.FormattingEnabled = true;
            this.cbbFormaPagamento.Location = new System.Drawing.Point(12, 28);
            this.cbbFormaPagamento.Name = "cbbFormaPagamento";
            this.cbbFormaPagamento.Size = new System.Drawing.Size(430, 33);
            this.cbbFormaPagamento.TabIndex = 0;
            this.cbbFormaPagamento.SelectedIndexChanged += new System.EventHandler(this.cbbFormaPagamento_SelectedIndexChanged);
            this.cbbFormaPagamento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbbFormaPagamento_KeyDown);
            this.cbbFormaPagamento.Leave += new System.EventHandler(this.cbbFormaPagamento_Leave);
            // 
            // numVencimentoTodoDia
            // 
            this.numVencimentoTodoDia.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numVencimentoTodoDia.Location = new System.Drawing.Point(12, 150);
            this.numVencimentoTodoDia.Name = "numVencimentoTodoDia";
            this.numVencimentoTodoDia.Size = new System.Drawing.Size(79, 23);
            this.numVencimentoTodoDia.TabIndex = 106;
            this.numVencimentoTodoDia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numVencimentoTodoDia.ValueChanged += new System.EventHandler(this.numVencimentoTodoDia_ValueChanged);
            // 
            // numPrimeiroMes
            // 
            this.numPrimeiroMes.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPrimeiroMes.Location = new System.Drawing.Point(97, 150);
            this.numPrimeiroMes.Name = "numPrimeiroMes";
            this.numPrimeiroMes.Size = new System.Drawing.Size(79, 23);
            this.numPrimeiroMes.TabIndex = 107;
            this.numPrimeiroMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numPrimeiroMes.ValueChanged += new System.EventHandler(this.numPrimeiroMes_ValueChanged);
            // 
            // txtPercentualDesconto
            // 
            this.txtPercentualDesconto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPercentualDesconto.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercentualDesconto.Location = new System.Drawing.Point(165, 89);
            this.txtPercentualDesconto.Name = "txtPercentualDesconto";
            this.txtPercentualDesconto.Size = new System.Drawing.Size(147, 33);
            this.txtPercentualDesconto.TabIndex = 1;
            this.txtPercentualDesconto.Text = "0";
            this.txtPercentualDesconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPercentualDesconto.ValorInteiro = 0;
            this.txtPercentualDesconto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPercentualDesconto_KeyDown);
            this.txtPercentualDesconto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPercentualDesconto_KeyPress);
            this.txtPercentualDesconto.Leave += new System.EventHandler(this.txtPercentualDesconto_Leave);
            // 
            // txtPagando
            // 
            this.txtPagando.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPagando.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPagando.Location = new System.Drawing.Point(448, 89);
            this.txtPagando.Name = "txtPagando";
            this.txtPagando.Size = new System.Drawing.Size(144, 33);
            this.txtPagando.TabIndex = 2;
            this.txtPagando.Text = "0,00";
            this.txtPagando.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPagando.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtPagando.Enter += new System.EventHandler(this.txtPagando_Enter);
            this.txtPagando.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPagando_KeyDown);
            this.txtPagando.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPagando_KeyPress);
            this.txtPagando.Leave += new System.EventHandler(this.txtPagando_Leave);
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.SystemColors.Control;
            this.txtValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTotal.Enabled = false;
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.Location = new System.Drawing.Point(12, 89);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(147, 33);
            this.txtValorTotal.TabIndex = 110;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorTotal.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorTotal.Enter += new System.EventHandler(this.txtValorTotal_Enter);
            // 
            // bntExcluirParcelas
            // 
            this.bntExcluirParcelas.BackColor = System.Drawing.Color.White;
            this.bntExcluirParcelas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bntExcluirParcelas.Image = global::PDV.Apresentacao.Properties.Resources.trash__1_;
            this.bntExcluirParcelas.Location = new System.Drawing.Point(12, 378);
            this.bntExcluirParcelas.Name = "bntExcluirParcelas";
            this.bntExcluirParcelas.Size = new System.Drawing.Size(191, 38);
            this.bntExcluirParcelas.TabIndex = 5;
            this.bntExcluirParcelas.TabStop = false;
            this.bntExcluirParcelas.Text = " Excluir parcelas [ F8 ]";
            this.bntExcluirParcelas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntExcluirParcelas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntExcluirParcelas.UseVisualStyleBackColor = false;
            this.bntExcluirParcelas.Click += new System.EventHandler(this.bntExcluirParcelas_Click);
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnConfirmar.Location = new System.Drawing.Point(438, 378);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(154, 38);
            this.btnConfirmar.TabIndex = 4;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.Text = " Confirmar [ F5 ]";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.White;
            this.btnAdicionar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionar.Image = global::PDV.Apresentacao.Properties.Resources.confirma25;
            this.btnAdicionar.Location = new System.Drawing.Point(451, 138);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(141, 35);
            this.btnAdicionar.TabIndex = 3;
            this.btnAdicionar.TabStop = false;
            this.btnAdicionar.Text = "   Adicionar";
            this.btnAdicionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdicionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAdicionar.UseVisualStyleBackColor = false;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // FrmFormasPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 428);
            this.Controls.Add(this.bntExcluirParcelas);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.txtValorTotal);
            this.Controls.Add(this.txtPagando);
            this.Controls.Add(this.txtPercentualDesconto);
            this.Controls.Add(this.numPrimeiroMes);
            this.Controls.Add(this.numVencimentoTodoDia);
            this.Controls.Add(this.cbbFormaPagamento);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lblPercentualDesconto);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtRestantePagar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtTroco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmFormasPagamento";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Forma de Pagamento";
            this.Load += new System.EventHandler(this.FrmFormasPagamento_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmFormasPagamento_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numVencimentoTodoDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numPrimeiroMes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblPercentualDesconto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtRestantePagar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTroco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbFormaPagamento;
        private System.Windows.Forms.NumericUpDown numVencimentoTodoDia;
        private System.Windows.Forms.NumericUpDown numPrimeiroMes;
        private Componentes.Numero txtPercentualDesconto;
        private Componentes.DecimalTextbox2Novo txtPagando;
        private Componentes.DecimalTextbox2Novo txtValorTotal;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button bntExcluirParcelas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Emissao_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Vencimento_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClientesId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamentoId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn FormaPagamento_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parcela_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao_;
        private System.Windows.Forms.DataGridViewTextBoxColumn StatusPagamento_;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorPago_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataPagamento_;
        private System.Windows.Forms.DataGridViewTextBoxColumn PagouComCartão_;
    }
}