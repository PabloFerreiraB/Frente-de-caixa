namespace PDV.Apresentacao.Utils
{
    partial class FrmTabelaIBPT
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.gridRegistros = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblDescricao = new System.Windows.Forms.Label();
            this.chkMostrarDescricao = new System.Windows.Forms.CheckBox();
            this.TabelaIBPTId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Federal_Nacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Federal_Importado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Estadual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Municipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VigenciaInicio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VigenciaFim = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Versao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPesquisar.Location = new System.Drawing.Point(8, 27);
            this.txtPesquisar.MaxLength = 75;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(515, 23);
            this.txtPesquisar.TabIndex = 12;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
            // 
            // gridRegistros
            // 
            this.gridRegistros.AllowUserToAddRows = false;
            this.gridRegistros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightBlue;
            this.gridRegistros.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegistros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gridRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TabelaIBPTId,
            this.NCM,
            this.Ex,
            this.Tipo,
            this.Descricao,
            this.Aliq_Federal_Nacional,
            this.Aliq_Federal_Importado,
            this.Aliq_Estadual,
            this.Aliq_Municipal,
            this.VigenciaInicio,
            this.VigenciaFim,
            this.Versao});
            this.gridRegistros.Location = new System.Drawing.Point(8, 56);
            this.gridRegistros.Name = "gridRegistros";
            this.gridRegistros.ReadOnly = true;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gridRegistros.RowHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.gridRegistros.RowHeadersWidth = 24;
            this.gridRegistros.RowTemplate.Height = 20;
            this.gridRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridRegistros.Size = new System.Drawing.Size(726, 336);
            this.gridRegistros.TabIndex = 13;
            this.gridRegistros.SelectionChanged += new System.EventHandler(this.gridRegistros_SelectionChanged);
            this.gridRegistros.DoubleClick += new System.EventHandler(this.gridRegistros_DoubleClick);
            this.gridRegistros.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gridRegistros_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 16);
            this.label2.TabIndex = 14;
            this.label2.Text = "NCM";
            // 
            // lblDescricao
            // 
            this.lblDescricao.BackColor = System.Drawing.SystemColors.Control;
            this.lblDescricao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescricao.Location = new System.Drawing.Point(8, 395);
            this.lblDescricao.Name = "lblDescricao";
            this.lblDescricao.Size = new System.Drawing.Size(726, 25);
            this.lblDescricao.TabIndex = 15;
            this.lblDescricao.Visible = false;
            // 
            // chkMostrarDescricao
            // 
            this.chkMostrarDescricao.AutoSize = true;
            this.chkMostrarDescricao.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMostrarDescricao.Location = new System.Drawing.Point(612, 28);
            this.chkMostrarDescricao.Name = "chkMostrarDescricao";
            this.chkMostrarDescricao.Size = new System.Drawing.Size(129, 20);
            this.chkMostrarDescricao.TabIndex = 16;
            this.chkMostrarDescricao.Text = "Mostrar descrição";
            this.chkMostrarDescricao.UseVisualStyleBackColor = true;
            this.chkMostrarDescricao.CheckedChanged += new System.EventHandler(this.chkMostrarDescricao_CheckedChanged);
            // 
            // TabelaIBPTId
            // 
            this.TabelaIBPTId.DataPropertyName = "TabelaIBPTId";
            this.TabelaIBPTId.HeaderText = "TabelaIBPTId";
            this.TabelaIBPTId.Name = "TabelaIBPTId";
            this.TabelaIBPTId.ReadOnly = true;
            this.TabelaIBPTId.Visible = false;
            // 
            // NCM
            // 
            this.NCM.DataPropertyName = "NCM";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NCM.DefaultCellStyle = dataGridViewCellStyle3;
            this.NCM.HeaderText = "NCM";
            this.NCM.Name = "NCM";
            this.NCM.ReadOnly = true;
            this.NCM.Width = 130;
            // 
            // Ex
            // 
            this.Ex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ex.DataPropertyName = "Ex";
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Ex.DefaultCellStyle = dataGridViewCellStyle4;
            this.Ex.HeaderText = "Ex";
            this.Ex.Name = "Ex";
            this.Ex.ReadOnly = true;
            this.Ex.Visible = false;
            // 
            // Tipo
            // 
            this.Tipo.DataPropertyName = "Tipo";
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            this.Tipo.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.DataPropertyName = "Descricao";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Descricao.DefaultCellStyle = dataGridViewCellStyle5;
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            this.Descricao.Visible = false;
            this.Descricao.Width = 620;
            // 
            // Aliq_Federal_Nacional
            // 
            this.Aliq_Federal_Nacional.DataPropertyName = "Aliq_Federal_Nacional";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Aliq_Federal_Nacional.DefaultCellStyle = dataGridViewCellStyle6;
            this.Aliq_Federal_Nacional.HeaderText = "% Nacional Federal";
            this.Aliq_Federal_Nacional.Name = "Aliq_Federal_Nacional";
            this.Aliq_Federal_Nacional.ReadOnly = true;
            this.Aliq_Federal_Nacional.Width = 155;
            // 
            // Aliq_Federal_Importado
            // 
            this.Aliq_Federal_Importado.DataPropertyName = "Aliq_Federal_Importado";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Aliq_Federal_Importado.DefaultCellStyle = dataGridViewCellStyle7;
            this.Aliq_Federal_Importado.HeaderText = "% Importado Federal";
            this.Aliq_Federal_Importado.Name = "Aliq_Federal_Importado";
            this.Aliq_Federal_Importado.ReadOnly = true;
            this.Aliq_Federal_Importado.Width = 155;
            // 
            // Aliq_Estadual
            // 
            this.Aliq_Estadual.DataPropertyName = "Aliq_Estadual";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Aliq_Estadual.DefaultCellStyle = dataGridViewCellStyle8;
            this.Aliq_Estadual.HeaderText = "% Estadual";
            this.Aliq_Estadual.Name = "Aliq_Estadual";
            this.Aliq_Estadual.ReadOnly = true;
            this.Aliq_Estadual.Width = 130;
            // 
            // Aliq_Municipal
            // 
            this.Aliq_Municipal.DataPropertyName = "Aliq_Municipal";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.Aliq_Municipal.DefaultCellStyle = dataGridViewCellStyle9;
            this.Aliq_Municipal.HeaderText = "% Municipal";
            this.Aliq_Municipal.Name = "Aliq_Municipal";
            this.Aliq_Municipal.ReadOnly = true;
            this.Aliq_Municipal.Width = 130;
            // 
            // VigenciaInicio
            // 
            this.VigenciaInicio.DataPropertyName = "VigenciaInicio";
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.VigenciaInicio.DefaultCellStyle = dataGridViewCellStyle10;
            this.VigenciaInicio.HeaderText = "VigenciaInicio";
            this.VigenciaInicio.Name = "VigenciaInicio";
            this.VigenciaInicio.ReadOnly = true;
            this.VigenciaInicio.Visible = false;
            // 
            // VigenciaFim
            // 
            this.VigenciaFim.DataPropertyName = "VigenciaFim";
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.VigenciaFim.DefaultCellStyle = dataGridViewCellStyle11;
            this.VigenciaFim.HeaderText = "VigenciaFim";
            this.VigenciaFim.Name = "VigenciaFim";
            this.VigenciaFim.ReadOnly = true;
            this.VigenciaFim.Visible = false;
            // 
            // Versao
            // 
            this.Versao.DataPropertyName = "Versao";
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Versao.DefaultCellStyle = dataGridViewCellStyle12;
            this.Versao.HeaderText = "Versao";
            this.Versao.Name = "Versao";
            this.Versao.ReadOnly = true;
            this.Versao.Visible = false;
            // 
            // FrmTabelaIBPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 401);
            this.Controls.Add(this.chkMostrarDescricao);
            this.Controls.Add(this.lblDescricao);
            this.Controls.Add(this.txtPesquisar);
            this.Controls.Add(this.gridRegistros);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmTabelaIBPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tabela IBPT";
            this.Load += new System.EventHandler(this.FrmTabelaIBPT_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmTabelaIBPT_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.gridRegistros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.DataGridView gridRegistros;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblDescricao;
        private System.Windows.Forms.CheckBox chkMostrarDescricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TabelaIBPTId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Federal_Nacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Federal_Importado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Estadual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Municipal;
        private System.Windows.Forms.DataGridViewTextBoxColumn VigenciaInicio;
        private System.Windows.Forms.DataGridViewTextBoxColumn VigenciaFim;
        private System.Windows.Forms.DataGridViewTextBoxColumn Versao;
    }
}