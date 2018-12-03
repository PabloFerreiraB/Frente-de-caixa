namespace PDV.Apresentacao.MovimentacaoCaixa
{
    partial class FrmAbriCaixa
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
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValorCaixa = new PDV.Componentes.DecimalTextbox2Novo();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.White;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnConfirmar.Location = new System.Drawing.Point(82, 137);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(155, 35);
            this.btnConfirmar.TabIndex = 1;
            this.btnConfirmar.Text = " &Confirmar [ F5 ]";
            this.btnConfirmar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfirmar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "Saldo Inicial";
            // 
            // txtValorCaixa
            // 
            this.txtValorCaixa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorCaixa.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorCaixa.Location = new System.Drawing.Point(12, 28);
            this.txtValorCaixa.Name = "txtValorCaixa";
            this.txtValorCaixa.Size = new System.Drawing.Size(294, 50);
            this.txtValorCaixa.TabIndex = 0;
            this.txtValorCaixa.Text = "0,00";
            this.txtValorCaixa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtValorCaixa.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // FrmAbriCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 184);
            this.Controls.Add(this.txtValorCaixa);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirmar);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmAbriCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Abrindo o Caixa";
            this.Load += new System.EventHandler(this.FrmAbriCaixa_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmAbriCaixa_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Label label1;
        private Componentes.DecimalTextbox2Novo txtValorCaixa;
    }
}