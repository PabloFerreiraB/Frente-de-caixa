namespace PDV.Apresentacao.Cadastros.Clientes
{
    partial class FrmAdicionarSaldoCliente
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
            this.chkImprimirComprovante = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblNomeFuncionario = new System.Windows.Forms.Label();
            this.lblVendedor = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTipoPessoa = new System.Windows.Forms.Label();
            this.cbbOperacao = new System.Windows.Forms.ComboBox();
            this.txtValor = new PDV.Componentes.DecimalTextbox2Novo();
            this.txtSenhaFuncionario = new System.Windows.Forms.TextBox();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnPesquisaCliente = new System.Windows.Forms.Button();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // chkImprimirComprovante
            // 
            this.chkImprimirComprovante.AutoSize = true;
            this.chkImprimirComprovante.Checked = true;
            this.chkImprimirComprovante.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImprimirComprovante.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkImprimirComprovante.Location = new System.Drawing.Point(166, 198);
            this.chkImprimirComprovante.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.chkImprimirComprovante.Name = "chkImprimirComprovante";
            this.chkImprimirComprovante.Size = new System.Drawing.Size(154, 20);
            this.chkImprimirComprovante.TabIndex = 170;
            this.chkImprimirComprovante.Text = "Imprimir comprovante";
            this.chkImprimirComprovante.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 16);
            this.label3.TabIndex = 168;
            this.label3.Text = "Observação";
            // 
            // lblNomeFuncionario
            // 
            this.lblNomeFuncionario.BackColor = System.Drawing.Color.Transparent;
            this.lblNomeFuncionario.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeFuncionario.ForeColor = System.Drawing.Color.Black;
            this.lblNomeFuncionario.Location = new System.Drawing.Point(332, 81);
            this.lblNomeFuncionario.Name = "lblNomeFuncionario";
            this.lblNomeFuncionario.Size = new System.Drawing.Size(138, 24);
            this.lblNomeFuncionario.TabIndex = 167;
            this.lblNomeFuncionario.Text = "nome Funcionário";
            this.lblNomeFuncionario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNomeFuncionario.Visible = false;
            // 
            // lblVendedor
            // 
            this.lblVendedor.AutoSize = true;
            this.lblVendedor.BackColor = System.Drawing.Color.Transparent;
            this.lblVendedor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVendedor.ForeColor = System.Drawing.Color.Black;
            this.lblVendedor.Location = new System.Drawing.Point(244, 61);
            this.lblVendedor.Name = "lblVendedor";
            this.lblVendedor.Size = new System.Drawing.Size(74, 16);
            this.lblVendedor.TabIndex = 166;
            this.lblVendedor.Text = "Funcionário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(138, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 16);
            this.label2.TabIndex = 165;
            this.label2.Text = "Valor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 164;
            this.label1.Text = "Operação";
            // 
            // lblTipoPessoa
            // 
            this.lblTipoPessoa.AutoSize = true;
            this.lblTipoPessoa.BackColor = System.Drawing.Color.Transparent;
            this.lblTipoPessoa.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTipoPessoa.Location = new System.Drawing.Point(5, 8);
            this.lblTipoPessoa.Name = "lblTipoPessoa";
            this.lblTipoPessoa.Size = new System.Drawing.Size(47, 16);
            this.lblTipoPessoa.TabIndex = 163;
            this.lblTipoPessoa.Text = "Cliente";
            // 
            // cbbOperacao
            // 
            this.cbbOperacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbOperacao.FormattingEnabled = true;
            this.cbbOperacao.Items.AddRange(new object[] {
            "Somar",
            "Subtrair"});
            this.cbbOperacao.Location = new System.Drawing.Point(8, 80);
            this.cbbOperacao.Name = "cbbOperacao";
            this.cbbOperacao.Size = new System.Drawing.Size(127, 24);
            this.cbbOperacao.TabIndex = 1;
            // 
            // txtValor
            // 
            this.txtValor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValor.Location = new System.Drawing.Point(141, 81);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(100, 23);
            this.txtValor.TabIndex = 2;
            this.txtValor.Text = "0,00";
            this.txtValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValor.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtSenhaFuncionario
            // 
            this.txtSenhaFuncionario.Location = new System.Drawing.Point(247, 81);
            this.txtSenhaFuncionario.Name = "txtSenhaFuncionario";
            this.txtSenhaFuncionario.PasswordChar = '•';
            this.txtSenhaFuncionario.Size = new System.Drawing.Size(83, 23);
            this.txtSenhaFuncionario.TabIndex = 3;
            this.txtSenhaFuncionario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSenhaFuncionario.Leave += new System.EventHandler(this.txtSenhaFuncionario_Leave);
            // 
            // txtObservacao
            // 
            this.txtObservacao.Location = new System.Drawing.Point(8, 132);
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(462, 45);
            this.txtObservacao.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnConfirmar.Location = new System.Drawing.Point(326, 183);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(144, 35);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.Text = " &Confirmar [ F5 ]";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnPesquisaCliente
            // 
            this.btnPesquisaCliente.BackColor = System.Drawing.Color.Transparent;
            this.btnPesquisaCliente.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnPesquisaCliente.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPesquisaCliente.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnPesquisaCliente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPesquisaCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPesquisaCliente.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisaCliente.Location = new System.Drawing.Point(439, 22);
            this.btnPesquisaCliente.Name = "btnPesquisaCliente";
            this.btnPesquisaCliente.Size = new System.Drawing.Size(31, 28);
            this.btnPesquisaCliente.TabIndex = 0;
            this.btnPesquisaCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPesquisaCliente.UseVisualStyleBackColor = false;
            this.btnPesquisaCliente.Click += new System.EventHandler(this.btnPesquisaCliente_Click);
            // 
            // txtCliente
            // 
            this.txtCliente.BackColor = System.Drawing.SystemColors.Control;
            this.txtCliente.ForeColor = System.Drawing.Color.DimGray;
            this.txtCliente.Location = new System.Drawing.Point(8, 27);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(429, 23);
            this.txtCliente.TabIndex = 916;
            this.txtCliente.Text = "SELECIONE O CLIENTE";
            // 
            // FrmAdicionarSaldoCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 227);
            this.Controls.Add(this.txtCliente);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.txtObservacao);
            this.Controls.Add(this.txtSenhaFuncionario);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.cbbOperacao);
            this.Controls.Add(this.btnPesquisaCliente);
            this.Controls.Add(this.chkImprimirComprovante);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblNomeFuncionario);
            this.Controls.Add(this.lblVendedor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTipoPessoa);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmAdicionarSaldoCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lançar saldo para cliente(s)";
            this.Load += new System.EventHandler(this.FrmAdicionarSaldoCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAdicionarSaldoCliente_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkImprimirComprovante;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblNomeFuncionario;
        private System.Windows.Forms.Label lblVendedor;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label lblTipoPessoa;
        public System.Windows.Forms.Button btnPesquisaCliente;
        private System.Windows.Forms.ComboBox cbbOperacao;
        private Componentes.DecimalTextbox2Novo txtValor;
        private System.Windows.Forms.TextBox txtSenhaFuncionario;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.TextBox txtCliente;
    }
}