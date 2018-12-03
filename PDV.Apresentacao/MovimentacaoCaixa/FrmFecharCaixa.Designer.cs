namespace PDV.Apresentacao.MovimentacaoCaixa
{
    partial class FrmFecharCaixa
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAbertura = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblFechamento = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDiferenca = new PDV.Componentes.DecimalTextbox2();
            this.label35 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.txtSomatorio = new PDV.Componentes.DecimalTextbox2();
            this.label31 = new System.Windows.Forms.Label();
            this.txtOutros = new PDV.Componentes.DecimalTextbox2();
            this.txtCheques = new PDV.Componentes.DecimalTextbox2();
            this.txtCartao = new PDV.Componentes.DecimalTextbox2();
            this.txtMoedas = new PDV.Componentes.DecimalTextbox2();
            this.txtDinheiro = new PDV.Componentes.DecimalTextbox2();
            this.label34 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblValorAbertura = new System.Windows.Forms.Label();
            this.lblSuprimento = new System.Windows.Forms.Label();
            this.lblSangria = new System.Windows.Forms.Label();
            this.lblEntradas = new System.Windows.Forms.Label();
            this.lblSaidas = new System.Windows.Forms.Label();
            this.lblTotalEntradas = new System.Windows.Forms.Label();
            this.lblTotalSaidas = new System.Windows.Forms.Label();
            this.lblSaldo = new System.Windows.Forms.Label();
            this.cbbImpressoes = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnFecharCaixa = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor Abertura ( $ )";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(145, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 23;
            this.label2.Text = "Data/Hora abertura";
            // 
            // lblAbertura
            // 
            this.lblAbertura.BackColor = System.Drawing.SystemColors.Window;
            this.lblAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAbertura.Location = new System.Drawing.Point(148, 28);
            this.lblAbertura.Name = "lblAbertura";
            this.lblAbertura.Size = new System.Drawing.Size(138, 23);
            this.lblAbertura.TabIndex = 24;
            this.lblAbertura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(292, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "à";
            // 
            // lblFechamento
            // 
            this.lblFechamento.BackColor = System.Drawing.SystemColors.Window;
            this.lblFechamento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFechamento.Location = new System.Drawing.Point(313, 28);
            this.lblFechamento.Name = "lblFechamento";
            this.lblFechamento.Size = new System.Drawing.Size(138, 23);
            this.lblFechamento.TabIndex = 27;
            this.lblFechamento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(310, 8);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 16);
            this.label6.TabIndex = 26;
            this.label6.Text = "Data/Hora fechamento";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDiferenca);
            this.groupBox1.Controls.Add(this.label35);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Controls.Add(this.txtSomatorio);
            this.groupBox1.Controls.Add(this.label31);
            this.groupBox1.Controls.Add(this.txtOutros);
            this.groupBox1.Controls.Add(this.txtCheques);
            this.groupBox1.Controls.Add(this.txtCartao);
            this.groupBox1.Controls.Add(this.txtMoedas);
            this.groupBox1.Controls.Add(this.txtDinheiro);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label30);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label29);
            this.groupBox1.Controls.Add(this.label28);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label27);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 208);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(773, 71);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Apuração Final (Contagem do Caixa)";
            // 
            // txtDiferenca
            // 
            this.txtDiferenca.BackColor = System.Drawing.Color.White;
            this.txtDiferenca.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiferenca.ForeColor = System.Drawing.Color.Red;
            this.txtDiferenca.Location = new System.Drawing.Point(678, 39);
            this.txtDiferenca.Name = "txtDiferenca";
            this.txtDiferenca.ReadOnly = true;
            this.txtDiferenca.Size = new System.Drawing.Size(87, 21);
            this.txtDiferenca.TabIndex = 243;
            this.txtDiferenca.Text = "0,00";
            this.txtDiferenca.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiferenca.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.Color.Black;
            this.label35.Location = new System.Drawing.Point(447, 41);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(16, 16);
            this.label35.TabIndex = 242;
            this.label35.Text = "+";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Black;
            this.label32.Location = new System.Drawing.Point(332, 41);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(16, 16);
            this.label32.TabIndex = 241;
            this.label32.Text = "+";
            // 
            // txtSomatorio
            // 
            this.txtSomatorio.BackColor = System.Drawing.Color.White;
            this.txtSomatorio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSomatorio.Location = new System.Drawing.Point(585, 39);
            this.txtSomatorio.Name = "txtSomatorio";
            this.txtSomatorio.ReadOnly = true;
            this.txtSomatorio.Size = new System.Drawing.Size(87, 21);
            this.txtSomatorio.TabIndex = 240;
            this.txtSomatorio.Text = "0,00";
            this.txtSomatorio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSomatorio.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.BackColor = System.Drawing.Color.Transparent;
            this.label31.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(217, 41);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(16, 16);
            this.label31.TabIndex = 240;
            this.label31.Text = "+";
            // 
            // txtOutros
            // 
            this.txtOutros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOutros.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutros.Location = new System.Drawing.Point(469, 39);
            this.txtOutros.Name = "txtOutros";
            this.txtOutros.Size = new System.Drawing.Size(87, 21);
            this.txtOutros.TabIndex = 239;
            this.txtOutros.Text = "0,00";
            this.txtOutros.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtOutros.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCheques
            // 
            this.txtCheques.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheques.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCheques.Location = new System.Drawing.Point(354, 39);
            this.txtCheques.Name = "txtCheques";
            this.txtCheques.Size = new System.Drawing.Size(87, 21);
            this.txtCheques.TabIndex = 238;
            this.txtCheques.Text = "0,00";
            this.txtCheques.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCheques.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtCartao
            // 
            this.txtCartao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCartao.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCartao.Location = new System.Drawing.Point(239, 39);
            this.txtCartao.Name = "txtCartao";
            this.txtCartao.Size = new System.Drawing.Size(87, 21);
            this.txtCartao.TabIndex = 237;
            this.txtCartao.Text = "0,00";
            this.txtCartao.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCartao.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtMoedas
            // 
            this.txtMoedas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMoedas.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoedas.Location = new System.Drawing.Point(124, 39);
            this.txtMoedas.Name = "txtMoedas";
            this.txtMoedas.Size = new System.Drawing.Size(87, 21);
            this.txtMoedas.TabIndex = 236;
            this.txtMoedas.Text = "0,00";
            this.txtMoedas.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMoedas.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // txtDinheiro
            // 
            this.txtDinheiro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDinheiro.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDinheiro.Location = new System.Drawing.Point(9, 39);
            this.txtDinheiro.Name = "txtDinheiro";
            this.txtDinheiro.Size = new System.Drawing.Size(87, 21);
            this.txtDinheiro.TabIndex = 235;
            this.txtDinheiro.Text = "0,00";
            this.txtDinheiro.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDinheiro.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.Color.Black;
            this.label34.Location = new System.Drawing.Point(466, 20);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(46, 16);
            this.label34.TabIndex = 196;
            this.label34.Text = "Outros";
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.ForeColor = System.Drawing.Color.Black;
            this.label33.Location = new System.Drawing.Point(562, 41);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(17, 16);
            this.label33.TabIndex = 190;
            this.label33.Text = "=";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(102, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(16, 16);
            this.label30.TabIndex = 187;
            this.label30.Text = "+";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(675, 20);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(62, 16);
            this.label17.TabIndex = 178;
            this.label17.Text = "Diferença";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(351, 20);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(57, 16);
            this.label29.TabIndex = 185;
            this.label29.Text = "Cheques";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(236, 20);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 16);
            this.label28.TabIndex = 183;
            this.label28.Text = "Cartão";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(582, 20);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 16);
            this.label15.TabIndex = 176;
            this.label15.Text = "Somatório";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(121, 20);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(52, 16);
            this.label27.TabIndex = 181;
            this.label27.Text = "Moedas";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(6, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 16);
            this.label13.TabIndex = 171;
            this.label13.Text = "Dinheiro";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(12, 282);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(773, 24);
            this.label8.TabIndex = 220;
            this.label8.Text = "Se apuração final for maior que zero é porque sobrou dinheiro no caixa, caso seja" +
    " menor que zero é porque faltou dinheiro no caixa.";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(469, 149);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(17, 16);
            this.label16.TabIndex = 219;
            this.label16.Text = "=";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(489, 123);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 217;
            this.label14.Text = "Saldo";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(405, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 16);
            this.label10.TabIndex = 216;
            this.label10.Text = "-";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(306, 175);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(17, 16);
            this.label12.TabIndex = 214;
            this.label12.Text = "=";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(148, 175);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(16, 16);
            this.label11.TabIndex = 213;
            this.label11.Text = "+";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(306, 123);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(17, 16);
            this.label9.TabIndex = 211;
            this.label9.Text = "=";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(148, 123);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(16, 16);
            this.label18.TabIndex = 210;
            this.label18.Text = "+";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.Black;
            this.label19.Location = new System.Drawing.Point(9, 153);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(52, 16);
            this.label19.TabIndex = 205;
            this.label19.Text = "Sangria";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(9, 101);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(74, 16);
            this.label20.TabIndex = 204;
            this.label20.Text = "Suprimento";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Black;
            this.label21.Location = new System.Drawing.Point(167, 153);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(46, 16);
            this.label21.TabIndex = 203;
            this.label21.Text = "Saidas";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(167, 101);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(58, 16);
            this.label22.TabIndex = 202;
            this.label22.Text = "Entradas";
            // 
            // lblValorAbertura
            // 
            this.lblValorAbertura.BackColor = System.Drawing.SystemColors.Window;
            this.lblValorAbertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblValorAbertura.Location = new System.Drawing.Point(12, 28);
            this.lblValorAbertura.Name = "lblValorAbertura";
            this.lblValorAbertura.Size = new System.Drawing.Size(130, 23);
            this.lblValorAbertura.TabIndex = 224;
            this.lblValorAbertura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSuprimento
            // 
            this.lblSuprimento.BackColor = System.Drawing.SystemColors.Window;
            this.lblSuprimento.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSuprimento.Location = new System.Drawing.Point(12, 120);
            this.lblSuprimento.Name = "lblSuprimento";
            this.lblSuprimento.Size = new System.Drawing.Size(130, 23);
            this.lblSuprimento.TabIndex = 225;
            this.lblSuprimento.Text = "0,00";
            this.lblSuprimento.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSangria
            // 
            this.lblSangria.BackColor = System.Drawing.SystemColors.Window;
            this.lblSangria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSangria.Location = new System.Drawing.Point(12, 172);
            this.lblSangria.Name = "lblSangria";
            this.lblSangria.Size = new System.Drawing.Size(130, 23);
            this.lblSangria.TabIndex = 227;
            this.lblSangria.Text = "0,00";
            this.lblSangria.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEntradas
            // 
            this.lblEntradas.BackColor = System.Drawing.SystemColors.Window;
            this.lblEntradas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblEntradas.Location = new System.Drawing.Point(170, 120);
            this.lblEntradas.Name = "lblEntradas";
            this.lblEntradas.Size = new System.Drawing.Size(130, 23);
            this.lblEntradas.TabIndex = 229;
            this.lblEntradas.Text = "0,00";
            this.lblEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaidas
            // 
            this.lblSaidas.BackColor = System.Drawing.SystemColors.Window;
            this.lblSaidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaidas.Location = new System.Drawing.Point(170, 172);
            this.lblSaidas.Name = "lblSaidas";
            this.lblSaidas.Size = new System.Drawing.Size(130, 23);
            this.lblSaidas.TabIndex = 230;
            this.lblSaidas.Text = "0,00";
            this.lblSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalEntradas
            // 
            this.lblTotalEntradas.BackColor = System.Drawing.SystemColors.Window;
            this.lblTotalEntradas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalEntradas.Location = new System.Drawing.Point(329, 120);
            this.lblTotalEntradas.Name = "lblTotalEntradas";
            this.lblTotalEntradas.Size = new System.Drawing.Size(130, 23);
            this.lblTotalEntradas.TabIndex = 231;
            this.lblTotalEntradas.Text = "0,00";
            this.lblTotalEntradas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSaidas
            // 
            this.lblTotalSaidas.BackColor = System.Drawing.SystemColors.Window;
            this.lblTotalSaidas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTotalSaidas.Location = new System.Drawing.Point(329, 172);
            this.lblTotalSaidas.Name = "lblTotalSaidas";
            this.lblTotalSaidas.Size = new System.Drawing.Size(130, 23);
            this.lblTotalSaidas.TabIndex = 232;
            this.lblTotalSaidas.Text = "0,00";
            this.lblTotalSaidas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSaldo
            // 
            this.lblSaldo.BackColor = System.Drawing.SystemColors.Window;
            this.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSaldo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSaldo.Location = new System.Drawing.Point(492, 143);
            this.lblSaldo.Name = "lblSaldo";
            this.lblSaldo.Size = new System.Drawing.Size(130, 27);
            this.lblSaldo.TabIndex = 234;
            this.lblSaldo.Text = "0,00";
            this.lblSaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbbImpressoes
            // 
            this.cbbImpressoes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbImpressoes.FormattingEnabled = true;
            this.cbbImpressoes.Location = new System.Drawing.Point(443, 356);
            this.cbbImpressoes.Name = "cbbImpressoes";
            this.cbbImpressoes.Size = new System.Drawing.Size(181, 24);
            this.cbbImpressoes.TabIndex = 235;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(440, 337);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 236;
            this.label7.Text = "Impressões";
            // 
            // btnFecharCaixa
            // 
            this.btnFecharCaixa.BackColor = System.Drawing.Color.White;
            this.btnFecharCaixa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFecharCaixa.Image = global::PDV.Apresentacao.Properties.Resources.salvar25;
            this.btnFecharCaixa.Location = new System.Drawing.Point(630, 345);
            this.btnFecharCaixa.Name = "btnFecharCaixa";
            this.btnFecharCaixa.Size = new System.Drawing.Size(155, 35);
            this.btnFecharCaixa.TabIndex = 237;
            this.btnFecharCaixa.TabStop = false;
            this.btnFecharCaixa.Text = " &Fechar caixa [ F5 ]";
            this.btnFecharCaixa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnFecharCaixa.UseVisualStyleBackColor = false;
            // 
            // FrmFecharCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 392);
            this.Controls.Add(this.btnFecharCaixa);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbbImpressoes);
            this.Controls.Add(this.lblSaldo);
            this.Controls.Add(this.lblTotalSaidas);
            this.Controls.Add(this.lblTotalEntradas);
            this.Controls.Add(this.lblSaidas);
            this.Controls.Add(this.lblEntradas);
            this.Controls.Add(this.lblSangria);
            this.Controls.Add(this.lblSuprimento);
            this.Controls.Add(this.lblValorAbertura);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lblFechamento);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblAbertura);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmFecharCaixa";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fechar caixa / Fluxo de caixa";
            this.Load += new System.EventHandler(this.FrmFecharCaixa_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAbertura;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFechamento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblValorAbertura;
        private System.Windows.Forms.Label lblSuprimento;
        private System.Windows.Forms.Label lblSangria;
        private System.Windows.Forms.Label lblEntradas;
        private System.Windows.Forms.Label lblSaidas;
        private System.Windows.Forms.Label lblTotalEntradas;
        private System.Windows.Forms.Label lblTotalSaidas;
        private System.Windows.Forms.Label lblSaldo;
        private Componentes.DecimalTextbox2 txtDinheiro;
        private Componentes.DecimalTextbox2 txtMoedas;
        private Componentes.DecimalTextbox2 txtOutros;
        private Componentes.DecimalTextbox2 txtCheques;
        private Componentes.DecimalTextbox2 txtCartao;
        private Componentes.DecimalTextbox2 txtSomatorio;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label35;
        private Componentes.DecimalTextbox2 txtDiferenca;
        private System.Windows.Forms.ComboBox cbbImpressoes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnFecharCaixa;
    }
}