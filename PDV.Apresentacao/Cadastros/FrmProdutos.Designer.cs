namespace PDV.Apresentacao.Cadastros
{
    partial class FrmProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProdutos));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCadastrar = new System.Windows.Forms.TabPage();
            this.btnNCM = new System.Windows.Forms.Button();
            this.txtNCM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbbMovimentacaoProduto = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnGrupoImposto = new System.Windows.Forms.Button();
            this.txtDescricaoGrupoImposto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtEstoqueMaximo = new PDV.Componentes.Numero();
            this.txtEstoqueMinimo = new PDV.Componentes.Numero();
            this.txtEstoqueInicial = new PDV.Componentes.Numero();
            this.btnSubgrupoProdutos = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnGrupoProdutos = new System.Windows.Forms.Button();
            this.cbbSubgrupoProdutos = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cbbGrupoProdutos = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtObservacao = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.gpReporEstoque = new System.Windows.Forms.GroupBox();
            this.txtQuantidadeCompra = new PDV.Componentes.Numero();
            this.txtEstoqueAtual = new PDV.Componentes.Numero();
            this.label11 = new System.Windows.Forms.Label();
            this.txtValorTotal = new PDV.Componentes.DecimalTextbox2();
            this.dtpUltimaCompra = new System.Windows.Forms.DateTimePicker();
            this.label21 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.dtpDataCadastro = new System.Windows.Forms.DateTimePicker();
            this.txtValorCompra = new PDV.Componentes.DecimalTextbox2();
            this.label7 = new System.Windows.Forms.Label();
            this.txtValorVenda = new PDV.Componentes.DecimalTextbox2();
            this.txtValorUnitario = new PDV.Componentes.DecimalTextbox2();
            this.lblEstoqueInicial = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGerarCodigoBarras = new System.Windows.Forms.Button();
            this.txtCodigoBarras = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.cbbUnidadeMedida = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnFornecedor = new System.Windows.Forms.Button();
            this.txtFornecedor = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAtivo = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tabClientesCadastrados = new System.Windows.Forms.TabPage();
            this.grid = new System.Windows.Forms.DataGridView();
            this.lblQuantidade = new System.Windows.Forms.Label();
            this.lblQuantidadeClientes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPesquisar = new System.Windows.Forms.TextBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.ProdutosId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoBarras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descricao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TabelaIBPTId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NCM = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ativo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedidaId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnidadeMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupoProdutosId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubgrupoProdutosId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TributacaoFiscalId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescricaoTributacaoFiscal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GrupoProdutos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FornecedorId_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fornecedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorUnitario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstoqueInicial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstoqueAtual_ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstoqueMinimo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EstoqueMaximo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observacao = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCadastro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UltimaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Federal_Nacional = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Estadual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Aliq_Municipal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabCadastrar.SuspendLayout();
            this.gpReporEstoque.SuspendLayout();
            this.tabClientesCadastrados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            this.menuPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCadastrar);
            this.tabControl.Controls.Add(this.tabClientesCadastrados);
            this.tabControl.Location = new System.Drawing.Point(0, 57);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(798, 356);
            this.tabControl.TabIndex = 106;
            // 
            // tabCadastrar
            // 
            this.tabCadastrar.BackColor = System.Drawing.SystemColors.Control;
            this.tabCadastrar.Controls.Add(this.btnNCM);
            this.tabCadastrar.Controls.Add(this.txtNCM);
            this.tabCadastrar.Controls.Add(this.label9);
            this.tabCadastrar.Controls.Add(this.cbbMovimentacaoProduto);
            this.tabCadastrar.Controls.Add(this.label12);
            this.tabCadastrar.Controls.Add(this.btnGrupoImposto);
            this.tabCadastrar.Controls.Add(this.txtDescricaoGrupoImposto);
            this.tabCadastrar.Controls.Add(this.label5);
            this.tabCadastrar.Controls.Add(this.txtEstoqueMaximo);
            this.tabCadastrar.Controls.Add(this.txtEstoqueMinimo);
            this.tabCadastrar.Controls.Add(this.txtEstoqueInicial);
            this.tabCadastrar.Controls.Add(this.btnSubgrupoProdutos);
            this.tabCadastrar.Controls.Add(this.label18);
            this.tabCadastrar.Controls.Add(this.label17);
            this.tabCadastrar.Controls.Add(this.btnGrupoProdutos);
            this.tabCadastrar.Controls.Add(this.cbbSubgrupoProdutos);
            this.tabCadastrar.Controls.Add(this.label16);
            this.tabCadastrar.Controls.Add(this.cbbGrupoProdutos);
            this.tabCadastrar.Controls.Add(this.label15);
            this.tabCadastrar.Controls.Add(this.txtObservacao);
            this.tabCadastrar.Controls.Add(this.label14);
            this.tabCadastrar.Controls.Add(this.gpReporEstoque);
            this.tabCadastrar.Controls.Add(this.txtValorCompra);
            this.tabCadastrar.Controls.Add(this.label7);
            this.tabCadastrar.Controls.Add(this.txtValorVenda);
            this.tabCadastrar.Controls.Add(this.txtValorUnitario);
            this.tabCadastrar.Controls.Add(this.lblEstoqueInicial);
            this.tabCadastrar.Controls.Add(this.label3);
            this.tabCadastrar.Controls.Add(this.label2);
            this.tabCadastrar.Controls.Add(this.btnGerarCodigoBarras);
            this.tabCadastrar.Controls.Add(this.txtCodigoBarras);
            this.tabCadastrar.Controls.Add(this.label13);
            this.tabCadastrar.Controls.Add(this.txtDescricao);
            this.tabCadastrar.Controls.Add(this.cbbUnidadeMedida);
            this.tabCadastrar.Controls.Add(this.label4);
            this.tabCadastrar.Controls.Add(this.btnFornecedor);
            this.tabCadastrar.Controls.Add(this.txtFornecedor);
            this.tabCadastrar.Controls.Add(this.label6);
            this.tabCadastrar.Controls.Add(this.chkAtivo);
            this.tabCadastrar.Controls.Add(this.label20);
            this.tabCadastrar.Location = new System.Drawing.Point(4, 25);
            this.tabCadastrar.Name = "tabCadastrar";
            this.tabCadastrar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCadastrar.Size = new System.Drawing.Size(790, 327);
            this.tabCadastrar.TabIndex = 0;
            this.tabCadastrar.Text = "Cadastrar   ";
            // 
            // btnNCM
            // 
            this.btnNCM.BackColor = System.Drawing.Color.Transparent;
            this.btnNCM.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnNCM.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnNCM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNCM.Enabled = false;
            this.btnNCM.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnNCM.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnNCM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNCM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNCM.Location = new System.Drawing.Point(524, 22);
            this.btnNCM.Name = "btnNCM";
            this.btnNCM.Size = new System.Drawing.Size(31, 28);
            this.btnNCM.TabIndex = 1;
            this.btnNCM.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnNCM.UseVisualStyleBackColor = false;
            this.btnNCM.Click += new System.EventHandler(this.btnNCM_Click);
            // 
            // txtNCM
            // 
            this.txtNCM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNCM.Enabled = false;
            this.txtNCM.Location = new System.Drawing.Point(461, 27);
            this.txtNCM.MaxLength = 8;
            this.txtNCM.Name = "txtNCM";
            this.txtNCM.Size = new System.Drawing.Size(61, 23);
            this.txtNCM.TabIndex = 912;
            this.txtNCM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(458, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(34, 16);
            this.label9.TabIndex = 913;
            this.label9.Text = "NCM";
            // 
            // cbbMovimentacaoProduto
            // 
            this.cbbMovimentacaoProduto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbMovimentacaoProduto.Enabled = false;
            this.cbbMovimentacaoProduto.FormattingEnabled = true;
            this.cbbMovimentacaoProduto.Items.AddRange(new object[] {
            "TESTE"});
            this.cbbMovimentacaoProduto.Location = new System.Drawing.Point(592, 197);
            this.cbbMovimentacaoProduto.Name = "cbbMovimentacaoProduto";
            this.cbbMovimentacaoProduto.Size = new System.Drawing.Size(190, 24);
            this.cbbMovimentacaoProduto.TabIndex = 890;
            this.cbbMovimentacaoProduto.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(589, 178);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(156, 16);
            this.label12.TabIndex = 891;
            this.label12.Text = "Movimentação do produto";
            this.label12.Visible = false;
            // 
            // btnGrupoImposto
            // 
            this.btnGrupoImposto.BackColor = System.Drawing.Color.Transparent;
            this.btnGrupoImposto.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnGrupoImposto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrupoImposto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrupoImposto.Enabled = false;
            this.btnGrupoImposto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGrupoImposto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGrupoImposto.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGrupoImposto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupoImposto.Location = new System.Drawing.Point(751, 74);
            this.btnGrupoImposto.Name = "btnGrupoImposto";
            this.btnGrupoImposto.Size = new System.Drawing.Size(31, 28);
            this.btnGrupoImposto.TabIndex = 6;
            this.btnGrupoImposto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGrupoImposto.UseVisualStyleBackColor = false;
            this.btnGrupoImposto.Click += new System.EventHandler(this.btnGrupoImposto_Click);
            // 
            // txtDescricaoGrupoImposto
            // 
            this.txtDescricaoGrupoImposto.BackColor = System.Drawing.SystemColors.Control;
            this.txtDescricaoGrupoImposto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescricaoGrupoImposto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescricaoGrupoImposto.Enabled = false;
            this.txtDescricaoGrupoImposto.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescricaoGrupoImposto.ForeColor = System.Drawing.Color.DimGray;
            this.txtDescricaoGrupoImposto.Location = new System.Drawing.Point(488, 79);
            this.txtDescricaoGrupoImposto.MaxLength = 60;
            this.txtDescricaoGrupoImposto.Name = "txtDescricaoGrupoImposto";
            this.txtDescricaoGrupoImposto.ReadOnly = true;
            this.txtDescricaoGrupoImposto.Size = new System.Drawing.Size(261, 23);
            this.txtDescricaoGrupoImposto.TabIndex = 910;
            this.txtDescricaoGrupoImposto.Text = "SELECIONE O GRUPO DE IMPOSTO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(485, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(146, 16);
            this.label5.TabIndex = 911;
            this.label5.Text = "Grupo de Imposto Fiscal";
            // 
            // txtEstoqueMaximo
            // 
            this.txtEstoqueMaximo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueMaximo.Location = new System.Drawing.Point(680, 130);
            this.txtEstoqueMaximo.Name = "txtEstoqueMaximo";
            this.txtEstoqueMaximo.Size = new System.Drawing.Size(102, 23);
            this.txtEstoqueMaximo.TabIndex = 12;
            this.txtEstoqueMaximo.Text = "0";
            this.txtEstoqueMaximo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstoqueMaximo.ValorInteiro = 0;
            this.txtEstoqueMaximo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoqueMaximo_KeyPress);
            // 
            // txtEstoqueMinimo
            // 
            this.txtEstoqueMinimo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueMinimo.Location = new System.Drawing.Point(572, 130);
            this.txtEstoqueMinimo.Name = "txtEstoqueMinimo";
            this.txtEstoqueMinimo.Size = new System.Drawing.Size(102, 23);
            this.txtEstoqueMinimo.TabIndex = 11;
            this.txtEstoqueMinimo.Text = "0";
            this.txtEstoqueMinimo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstoqueMinimo.ValorInteiro = 0;
            this.txtEstoqueMinimo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoqueMinimo_KeyPress);
            // 
            // txtEstoqueInicial
            // 
            this.txtEstoqueInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueInicial.Location = new System.Drawing.Point(464, 130);
            this.txtEstoqueInicial.Name = "txtEstoqueInicial";
            this.txtEstoqueInicial.Size = new System.Drawing.Size(102, 23);
            this.txtEstoqueInicial.TabIndex = 10;
            this.txtEstoqueInicial.Text = "0";
            this.txtEstoqueInicial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstoqueInicial.ValorInteiro = 0;
            this.txtEstoqueInicial.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEstoqueInicial_KeyPress);
            // 
            // btnSubgrupoProdutos
            // 
            this.btnSubgrupoProdutos.BackColor = System.Drawing.Color.Transparent;
            this.btnSubgrupoProdutos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSubgrupoProdutos.BackgroundImage")));
            this.btnSubgrupoProdutos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnSubgrupoProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubgrupoProdutos.Enabled = false;
            this.btnSubgrupoProdutos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSubgrupoProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSubgrupoProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubgrupoProdutos.Location = new System.Drawing.Point(456, 77);
            this.btnSubgrupoProdutos.Name = "btnSubgrupoProdutos";
            this.btnSubgrupoProdutos.Size = new System.Drawing.Size(26, 26);
            this.btnSubgrupoProdutos.TabIndex = 908;
            this.btnSubgrupoProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSubgrupoProdutos.UseVisualStyleBackColor = false;
            this.btnSubgrupoProdutos.Click += new System.EventHandler(this.btnSubgrupoProdutos_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(677, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 16);
            this.label18.TabIndex = 902;
            this.label18.Text = "Estoque máximo";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(569, 111);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(99, 16);
            this.label17.TabIndex = 900;
            this.label17.Text = "Estoque minímo";
            // 
            // btnGrupoProdutos
            // 
            this.btnGrupoProdutos.BackColor = System.Drawing.Color.Transparent;
            this.btnGrupoProdutos.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnGrupoProdutos.BackgroundImage")));
            this.btnGrupoProdutos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGrupoProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGrupoProdutos.Enabled = false;
            this.btnGrupoProdutos.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGrupoProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGrupoProdutos.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrupoProdutos.Location = new System.Drawing.Point(270, 77);
            this.btnGrupoProdutos.Name = "btnGrupoProdutos";
            this.btnGrupoProdutos.Size = new System.Drawing.Size(26, 26);
            this.btnGrupoProdutos.TabIndex = 899;
            this.btnGrupoProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGrupoProdutos.UseVisualStyleBackColor = false;
            this.btnGrupoProdutos.Click += new System.EventHandler(this.btnGrupoProdutos_Click);
            // 
            // cbbSubgrupoProdutos
            // 
            this.cbbSubgrupoProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbSubgrupoProdutos.Enabled = false;
            this.cbbSubgrupoProdutos.FormattingEnabled = true;
            this.cbbSubgrupoProdutos.Location = new System.Drawing.Point(302, 78);
            this.cbbSubgrupoProdutos.Name = "cbbSubgrupoProdutos";
            this.cbbSubgrupoProdutos.Size = new System.Drawing.Size(153, 24);
            this.cbbSubgrupoProdutos.TabIndex = 5;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(299, 60);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(63, 16);
            this.label16.TabIndex = 897;
            this.label16.Text = "Subgrupo";
            // 
            // cbbGrupoProdutos
            // 
            this.cbbGrupoProdutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbGrupoProdutos.Enabled = false;
            this.cbbGrupoProdutos.FormattingEnabled = true;
            this.cbbGrupoProdutos.Location = new System.Drawing.Point(116, 78);
            this.cbbGrupoProdutos.Name = "cbbGrupoProdutos";
            this.cbbGrupoProdutos.Size = new System.Drawing.Size(153, 24);
            this.cbbGrupoProdutos.TabIndex = 4;
            this.cbbGrupoProdutos.SelectedIndexChanged += new System.EventHandler(this.cbbGrupoProdutos_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(113, 59);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(114, 16);
            this.label15.TabIndex = 895;
            this.label15.Text = "Grupo de Produtos";
            // 
            // txtObservacao
            // 
            this.txtObservacao.Enabled = false;
            this.txtObservacao.Location = new System.Drawing.Point(310, 181);
            this.txtObservacao.MaxLength = 300;
            this.txtObservacao.Multiline = true;
            this.txtObservacao.Name = "txtObservacao";
            this.txtObservacao.Size = new System.Drawing.Size(472, 40);
            this.txtObservacao.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(307, 162);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(75, 16);
            this.label14.TabIndex = 892;
            this.label14.Text = "Observação";
            // 
            // gpReporEstoque
            // 
            this.gpReporEstoque.BackColor = System.Drawing.SystemColors.Control;
            this.gpReporEstoque.Controls.Add(this.txtQuantidadeCompra);
            this.gpReporEstoque.Controls.Add(this.txtEstoqueAtual);
            this.gpReporEstoque.Controls.Add(this.label11);
            this.gpReporEstoque.Controls.Add(this.txtValorTotal);
            this.gpReporEstoque.Controls.Add(this.dtpUltimaCompra);
            this.gpReporEstoque.Controls.Add(this.label21);
            this.gpReporEstoque.Controls.Add(this.label10);
            this.gpReporEstoque.Controls.Add(this.label8);
            this.gpReporEstoque.Controls.Add(this.label19);
            this.gpReporEstoque.Controls.Add(this.dtpDataCadastro);
            this.gpReporEstoque.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gpReporEstoque.Location = new System.Drawing.Point(8, 233);
            this.gpReporEstoque.Name = "gpReporEstoque";
            this.gpReporEstoque.Size = new System.Drawing.Size(774, 87);
            this.gpReporEstoque.TabIndex = 885;
            this.gpReporEstoque.TabStop = false;
            this.gpReporEstoque.Text = "Repor estoque";
            // 
            // txtQuantidadeCompra
            // 
            this.txtQuantidadeCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuantidadeCompra.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantidadeCompra.Location = new System.Drawing.Point(9, 48);
            this.txtQuantidadeCompra.Name = "txtQuantidadeCompra";
            this.txtQuantidadeCompra.Size = new System.Drawing.Size(145, 26);
            this.txtQuantidadeCompra.TabIndex = 0;
            this.txtQuantidadeCompra.Text = "0";
            this.txtQuantidadeCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQuantidadeCompra.ValorInteiro = 0;
            this.txtQuantidadeCompra.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtQuantidadeCompra_MouseClick);
            this.txtQuantidadeCompra.Enter += new System.EventHandler(this.txtQuantidadeCompra_Enter);
            this.txtQuantidadeCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtQuantidadeCompra_KeyPress);
            this.txtQuantidadeCompra.Leave += new System.EventHandler(this.txtQuantidadeCompra_Leave);
            // 
            // txtEstoqueAtual
            // 
            this.txtEstoqueAtual.BackColor = System.Drawing.SystemColors.Window;
            this.txtEstoqueAtual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEstoqueAtual.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstoqueAtual.Location = new System.Drawing.Point(311, 48);
            this.txtEstoqueAtual.Name = "txtEstoqueAtual";
            this.txtEstoqueAtual.Size = new System.Drawing.Size(145, 26);
            this.txtEstoqueAtual.TabIndex = 2;
            this.txtEstoqueAtual.Text = "0";
            this.txtEstoqueAtual.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtEstoqueAtual.ValorInteiro = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(308, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 16);
            this.label11.TabIndex = 886;
            this.label11.Text = "Estoque atual";
            // 
            // txtValorTotal
            // 
            this.txtValorTotal.BackColor = System.Drawing.SystemColors.Window;
            this.txtValorTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorTotal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValorTotal.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtValorTotal.Location = new System.Drawing.Point(160, 48);
            this.txtValorTotal.Name = "txtValorTotal";
            this.txtValorTotal.Size = new System.Drawing.Size(145, 26);
            this.txtValorTotal.TabIndex = 1;
            this.txtValorTotal.Text = "0,00";
            this.txtValorTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorTotal.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // dtpUltimaCompra
            // 
            this.dtpUltimaCompra.Enabled = false;
            this.dtpUltimaCompra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpUltimaCompra.Location = new System.Drawing.Point(644, 50);
            this.dtpUltimaCompra.Name = "dtpUltimaCompra";
            this.dtpUltimaCompra.Size = new System.Drawing.Size(124, 23);
            this.dtpUltimaCompra.TabIndex = 3;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(641, 31);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(91, 16);
            this.label21.TabIndex = 906;
            this.label21.Text = "Última compra";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(157, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 16);
            this.label10.TabIndex = 888;
            this.label10.Text = "Valor total";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 886;
            this.label8.Text = "Quantidade";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(511, 31);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 16);
            this.label19.TabIndex = 905;
            this.label19.Text = "Data de cadastro";
            // 
            // dtpDataCadastro
            // 
            this.dtpDataCadastro.Enabled = false;
            this.dtpDataCadastro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataCadastro.Location = new System.Drawing.Point(514, 50);
            this.dtpDataCadastro.Name = "dtpDataCadastro";
            this.dtpDataCadastro.Size = new System.Drawing.Size(124, 23);
            this.dtpDataCadastro.TabIndex = 2;
            // 
            // txtValorCompra
            // 
            this.txtValorCompra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorCompra.Enabled = false;
            this.txtValorCompra.Location = new System.Drawing.Point(8, 130);
            this.txtValorCompra.Name = "txtValorCompra";
            this.txtValorCompra.Size = new System.Drawing.Size(145, 23);
            this.txtValorCompra.TabIndex = 7;
            this.txtValorCompra.Text = "0,00";
            this.txtValorCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorCompra.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorCompra_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 111);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 16);
            this.label7.TabIndex = 883;
            this.label7.Text = "Preço de compra";
            // 
            // txtValorVenda
            // 
            this.txtValorVenda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorVenda.Enabled = false;
            this.txtValorVenda.Location = new System.Drawing.Point(159, 130);
            this.txtValorVenda.Name = "txtValorVenda";
            this.txtValorVenda.Size = new System.Drawing.Size(145, 23);
            this.txtValorVenda.TabIndex = 8;
            this.txtValorVenda.Text = "0,00";
            this.txtValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorVenda.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorVenda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorVenda_KeyPress);
            // 
            // txtValorUnitario
            // 
            this.txtValorUnitario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtValorUnitario.Enabled = false;
            this.txtValorUnitario.Location = new System.Drawing.Point(310, 130);
            this.txtValorUnitario.Name = "txtValorUnitario";
            this.txtValorUnitario.Size = new System.Drawing.Size(145, 23);
            this.txtValorUnitario.TabIndex = 9;
            this.txtValorUnitario.Text = "0,00";
            this.txtValorUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtValorUnitario.ValorDecimal = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtValorUnitario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorUnitario_KeyPress);
            // 
            // lblEstoqueInicial
            // 
            this.lblEstoqueInicial.AutoSize = true;
            this.lblEstoqueInicial.Location = new System.Drawing.Point(461, 111);
            this.lblEstoqueInicial.Name = "lblEstoqueInicial";
            this.lblEstoqueInicial.Size = new System.Drawing.Size(89, 16);
            this.lblEstoqueInicial.TabIndex = 879;
            this.lblEstoqueInicial.Text = "Estoque inicial";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.label3.TabIndex = 878;
            this.label3.Text = "Preço de venda";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(307, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 877;
            this.label2.Text = "Valor Unitário";
            // 
            // btnGerarCodigoBarras
            // 
            this.btnGerarCodigoBarras.BackColor = System.Drawing.Color.Transparent;
            this.btnGerarCodigoBarras.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.gerar25;
            this.btnGerarCodigoBarras.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnGerarCodigoBarras.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGerarCodigoBarras.Enabled = false;
            this.btnGerarCodigoBarras.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGerarCodigoBarras.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnGerarCodigoBarras.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGerarCodigoBarras.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarCodigoBarras.Location = new System.Drawing.Point(751, 22);
            this.btnGerarCodigoBarras.Name = "btnGerarCodigoBarras";
            this.btnGerarCodigoBarras.Size = new System.Drawing.Size(31, 28);
            this.btnGerarCodigoBarras.TabIndex = 2;
            this.btnGerarCodigoBarras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGerarCodigoBarras.UseVisualStyleBackColor = false;
            this.btnGerarCodigoBarras.Click += new System.EventHandler(this.btnGerarCodigoBarras_Click);
            // 
            // txtCodigoBarras
            // 
            this.txtCodigoBarras.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCodigoBarras.Enabled = false;
            this.txtCodigoBarras.Location = new System.Drawing.Point(627, 27);
            this.txtCodigoBarras.MaxLength = 25;
            this.txtCodigoBarras.Name = "txtCodigoBarras";
            this.txtCodigoBarras.Size = new System.Drawing.Size(122, 23);
            this.txtCodigoBarras.TabIndex = 875;
            this.txtCodigoBarras.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(624, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(106, 16);
            this.label13.TabIndex = 876;
            this.label13.Text = "Código de barras";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Enabled = false;
            this.txtDescricao.Location = new System.Drawing.Point(8, 27);
            this.txtDescricao.MaxLength = 255;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(447, 23);
            this.txtDescricao.TabIndex = 0;
            // 
            // cbbUnidadeMedida
            // 
            this.cbbUnidadeMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbbUnidadeMedida.Enabled = false;
            this.cbbUnidadeMedida.FormattingEnabled = true;
            this.cbbUnidadeMedida.Location = new System.Drawing.Point(8, 78);
            this.cbbUnidadeMedida.Name = "cbbUnidadeMedida";
            this.cbbUnidadeMedida.Size = new System.Drawing.Size(102, 24);
            this.cbbUnidadeMedida.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 823;
            this.label4.Text = "Unid. de Medida";
            // 
            // btnFornecedor
            // 
            this.btnFornecedor.BackColor = System.Drawing.Color.Transparent;
            this.btnFornecedor.BackgroundImage = global::PDV.Apresentacao.Properties.Resources.research;
            this.btnFornecedor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnFornecedor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFornecedor.Enabled = false;
            this.btnFornecedor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnFornecedor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.WhiteSmoke;
            this.btnFornecedor.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFornecedor.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFornecedor.Location = new System.Drawing.Point(273, 193);
            this.btnFornecedor.Name = "btnFornecedor";
            this.btnFornecedor.Size = new System.Drawing.Size(31, 28);
            this.btnFornecedor.TabIndex = 13;
            this.btnFornecedor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnFornecedor.UseVisualStyleBackColor = false;
            this.btnFornecedor.Click += new System.EventHandler(this.btnFornecedor_Click);
            // 
            // txtFornecedor
            // 
            this.txtFornecedor.BackColor = System.Drawing.SystemColors.Control;
            this.txtFornecedor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFornecedor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFornecedor.Enabled = false;
            this.txtFornecedor.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFornecedor.ForeColor = System.Drawing.Color.DimGray;
            this.txtFornecedor.Location = new System.Drawing.Point(10, 198);
            this.txtFornecedor.MaxLength = 60;
            this.txtFornecedor.Name = "txtFornecedor";
            this.txtFornecedor.ReadOnly = true;
            this.txtFornecedor.Size = new System.Drawing.Size(261, 23);
            this.txtFornecedor.TabIndex = 816;
            this.txtFornecedor.Text = "SELECIONE O FORNECEDOR";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 817;
            this.label6.Text = "Fornecedor";
            // 
            // chkAtivo
            // 
            this.chkAtivo.AutoSize = true;
            this.chkAtivo.Checked = true;
            this.chkAtivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAtivo.Enabled = false;
            this.chkAtivo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAtivo.Location = new System.Drawing.Point(567, 31);
            this.chkAtivo.Name = "chkAtivo";
            this.chkAtivo.Size = new System.Drawing.Size(59, 17);
            this.chkAtivo.TabIndex = 7;
            this.chkAtivo.Text = "Ativo ?";
            this.chkAtivo.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(5, 8);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(63, 16);
            this.label20.TabIndex = 103;
            this.label20.Text = "Descrição";
            // 
            // tabClientesCadastrados
            // 
            this.tabClientesCadastrados.BackColor = System.Drawing.SystemColors.Control;
            this.tabClientesCadastrados.Controls.Add(this.grid);
            this.tabClientesCadastrados.Controls.Add(this.lblQuantidade);
            this.tabClientesCadastrados.Controls.Add(this.lblQuantidadeClientes);
            this.tabClientesCadastrados.Controls.Add(this.label1);
            this.tabClientesCadastrados.Controls.Add(this.txtPesquisar);
            this.tabClientesCadastrados.Location = new System.Drawing.Point(4, 25);
            this.tabClientesCadastrados.Name = "tabClientesCadastrados";
            this.tabClientesCadastrados.Padding = new System.Windows.Forms.Padding(3);
            this.tabClientesCadastrados.Size = new System.Drawing.Size(790, 327);
            this.tabClientesCadastrados.TabIndex = 1;
            this.tabClientesCadastrados.Text = "Produtos cadastrados   ";
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
            this.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdutosId_,
            this.CodigoBarras,
            this.Descricao,
            this.TabelaIBPTId_,
            this.NCM,
            this.Ativo,
            this.UnidadeMedidaId,
            this.UnidadeMedida,
            this.grupoProdutosId,
            this.SubgrupoProdutosId,
            this.TributacaoFiscalId_,
            this.DescricaoTributacaoFiscal,
            this.GrupoProdutos,
            this.FornecedorId_,
            this.Fornecedor,
            this.ValorCompra,
            this.ValorVenda,
            this.ValorUnitario,
            this.EstoqueInicial,
            this.EstoqueAtual_,
            this.EstoqueMinimo,
            this.EstoqueMaximo,
            this.Observacao,
            this.DataCadastro,
            this.UltimaCompra,
            this.Aliq_Federal_Nacional,
            this.Aliq_Estadual,
            this.Aliq_Municipal});
            this.grid.Location = new System.Drawing.Point(8, 39);
            this.grid.Name = "grid";
            this.grid.ReadOnly = true;
            this.grid.RowHeadersVisible = false;
            this.grid.RowHeadersWidth = 24;
            this.grid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grid.Size = new System.Drawing.Size(774, 261);
            this.grid.TabIndex = 178;
            this.grid.DoubleClick += new System.EventHandler(this.grid_DoubleClick);
            this.grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.grid_KeyDown);
            // 
            // lblQuantidade
            // 
            this.lblQuantidade.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblQuantidade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidade.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidade.Location = new System.Drawing.Point(8, 299);
            this.lblQuantidade.Name = "lblQuantidade";
            this.lblQuantidade.Size = new System.Drawing.Size(774, 21);
            this.lblQuantidade.TabIndex = 177;
            this.lblQuantidade.Text = "Resultados encontrados";
            this.lblQuantidade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblQuantidadeClientes
            // 
            this.lblQuantidadeClientes.BackColor = System.Drawing.Color.LightBlue;
            this.lblQuantidadeClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblQuantidadeClientes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantidadeClientes.Location = new System.Drawing.Point(6, 462);
            this.lblQuantidadeClientes.Name = "lblQuantidadeClientes";
            this.lblQuantidadeClientes.Size = new System.Drawing.Size(764, 22);
            this.lblQuantidadeClientes.TabIndex = 176;
            this.lblQuantidadeClientes.Text = "RESULTADOS ENCONTRADOS";
            this.lblQuantidadeClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 106;
            this.label1.Text = "Pesquisar:";
            // 
            // txtPesquisar
            // 
            this.txtPesquisar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPesquisar.CharacterCasing = System.Windows.Forms.CharacterCasing.Lower;
            this.txtPesquisar.Location = new System.Drawing.Point(77, 10);
            this.txtPesquisar.MaxLength = 75;
            this.txtPesquisar.Name = "txtPesquisar";
            this.txtPesquisar.Size = new System.Drawing.Size(705, 23);
            this.txtPesquisar.TabIndex = 105;
            this.txtPesquisar.TextChanged += new System.EventHandler(this.txtPesquisar_TextChanged);
            this.txtPesquisar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPesquisar_KeyDown);
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
            this.menuPanel.Size = new System.Drawing.Size(798, 50);
            this.menuPanel.TabIndex = 105;
            // 
            // btnNovo
            // 
            this.btnNovo.BackColor = System.Drawing.Color.White;
            this.btnNovo.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnSalvar.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnExcluir.Cursor = System.Windows.Forms.Cursors.Hand;
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
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
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
            // ProdutosId_
            // 
            this.ProdutosId_.DataPropertyName = "ProdutosId";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ProdutosId_.DefaultCellStyle = dataGridViewCellStyle2;
            this.ProdutosId_.HeaderText = "Código";
            this.ProdutosId_.Name = "ProdutosId_";
            this.ProdutosId_.ReadOnly = true;
            this.ProdutosId_.Width = 80;
            // 
            // CodigoBarras
            // 
            this.CodigoBarras.DataPropertyName = "CodigoBarras";
            this.CodigoBarras.HeaderText = "CodigoBarras";
            this.CodigoBarras.Name = "CodigoBarras";
            this.CodigoBarras.ReadOnly = true;
            this.CodigoBarras.Visible = false;
            // 
            // Descricao
            // 
            this.Descricao.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descricao.DataPropertyName = "Descricao";
            this.Descricao.HeaderText = "Descrição";
            this.Descricao.Name = "Descricao";
            this.Descricao.ReadOnly = true;
            // 
            // TabelaIBPTId_
            // 
            this.TabelaIBPTId_.DataPropertyName = "TabelaIBPTId";
            this.TabelaIBPTId_.HeaderText = "TabelaIBPTId";
            this.TabelaIBPTId_.Name = "TabelaIBPTId_";
            this.TabelaIBPTId_.ReadOnly = true;
            this.TabelaIBPTId_.Visible = false;
            // 
            // NCM
            // 
            this.NCM.DataPropertyName = "NCM";
            this.NCM.HeaderText = "NCM";
            this.NCM.Name = "NCM";
            this.NCM.ReadOnly = true;
            this.NCM.Visible = false;
            // 
            // Ativo
            // 
            this.Ativo.DataPropertyName = "Ativo";
            this.Ativo.HeaderText = "Ativo";
            this.Ativo.Name = "Ativo";
            this.Ativo.ReadOnly = true;
            this.Ativo.Visible = false;
            // 
            // UnidadeMedidaId
            // 
            this.UnidadeMedidaId.DataPropertyName = "UnidadeMedidaId";
            this.UnidadeMedidaId.HeaderText = "UnidadeMedidaId";
            this.UnidadeMedidaId.Name = "UnidadeMedidaId";
            this.UnidadeMedidaId.ReadOnly = true;
            this.UnidadeMedidaId.Visible = false;
            // 
            // UnidadeMedida
            // 
            this.UnidadeMedida.DataPropertyName = "UnidadeMedida";
            this.UnidadeMedida.HeaderText = "Unid. de Medida";
            this.UnidadeMedida.Name = "UnidadeMedida";
            this.UnidadeMedida.ReadOnly = true;
            this.UnidadeMedida.Width = 110;
            // 
            // grupoProdutosId
            // 
            this.grupoProdutosId.DataPropertyName = "grupoProdutosId";
            this.grupoProdutosId.HeaderText = "grupoProdutosId";
            this.grupoProdutosId.Name = "grupoProdutosId";
            this.grupoProdutosId.ReadOnly = true;
            this.grupoProdutosId.Visible = false;
            // 
            // SubgrupoProdutosId
            // 
            this.SubgrupoProdutosId.DataPropertyName = "SubgrupoProdutosId";
            this.SubgrupoProdutosId.HeaderText = "SubgrupoProdutosId";
            this.SubgrupoProdutosId.Name = "SubgrupoProdutosId";
            this.SubgrupoProdutosId.ReadOnly = true;
            this.SubgrupoProdutosId.Visible = false;
            // 
            // TributacaoFiscalId_
            // 
            this.TributacaoFiscalId_.DataPropertyName = "TributacaoFiscalId";
            this.TributacaoFiscalId_.HeaderText = "TributacaoFiscalId";
            this.TributacaoFiscalId_.Name = "TributacaoFiscalId_";
            this.TributacaoFiscalId_.ReadOnly = true;
            this.TributacaoFiscalId_.Visible = false;
            // 
            // DescricaoTributacaoFiscal
            // 
            this.DescricaoTributacaoFiscal.DataPropertyName = "DescricaoTributacaoFiscal";
            this.DescricaoTributacaoFiscal.HeaderText = "DescricaoTributacaoFiscal";
            this.DescricaoTributacaoFiscal.Name = "DescricaoTributacaoFiscal";
            this.DescricaoTributacaoFiscal.ReadOnly = true;
            this.DescricaoTributacaoFiscal.Visible = false;
            // 
            // GrupoProdutos
            // 
            this.GrupoProdutos.DataPropertyName = "GrupoProdutos";
            this.GrupoProdutos.HeaderText = "GrupoProdutos";
            this.GrupoProdutos.Name = "GrupoProdutos";
            this.GrupoProdutos.ReadOnly = true;
            this.GrupoProdutos.Visible = false;
            // 
            // FornecedorId_
            // 
            this.FornecedorId_.DataPropertyName = "FornecedorId";
            this.FornecedorId_.HeaderText = "FornecedorId";
            this.FornecedorId_.Name = "FornecedorId_";
            this.FornecedorId_.ReadOnly = true;
            this.FornecedorId_.Visible = false;
            // 
            // Fornecedor
            // 
            this.Fornecedor.DataPropertyName = "Fornecedor";
            this.Fornecedor.HeaderText = "Fornecedor";
            this.Fornecedor.Name = "Fornecedor";
            this.Fornecedor.ReadOnly = true;
            this.Fornecedor.Visible = false;
            // 
            // ValorCompra
            // 
            this.ValorCompra.DataPropertyName = "ValorCompra";
            this.ValorCompra.HeaderText = "ValorCompra";
            this.ValorCompra.Name = "ValorCompra";
            this.ValorCompra.ReadOnly = true;
            this.ValorCompra.Visible = false;
            // 
            // ValorVenda
            // 
            this.ValorVenda.DataPropertyName = "ValorVenda";
            this.ValorVenda.HeaderText = "ValorVenda";
            this.ValorVenda.Name = "ValorVenda";
            this.ValorVenda.ReadOnly = true;
            this.ValorVenda.Visible = false;
            // 
            // ValorUnitario
            // 
            this.ValorUnitario.DataPropertyName = "ValorUnitario";
            this.ValorUnitario.HeaderText = "ValorUnitario";
            this.ValorUnitario.Name = "ValorUnitario";
            this.ValorUnitario.ReadOnly = true;
            this.ValorUnitario.Visible = false;
            // 
            // EstoqueInicial
            // 
            this.EstoqueInicial.DataPropertyName = "EstoqueInicial";
            this.EstoqueInicial.HeaderText = "EstoqueInicial";
            this.EstoqueInicial.Name = "EstoqueInicial";
            this.EstoqueInicial.ReadOnly = true;
            this.EstoqueInicial.Visible = false;
            // 
            // EstoqueAtual_
            // 
            this.EstoqueAtual_.DataPropertyName = "EstoqueAtual";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.EstoqueAtual_.DefaultCellStyle = dataGridViewCellStyle3;
            this.EstoqueAtual_.HeaderText = "Estoque";
            this.EstoqueAtual_.Name = "EstoqueAtual_";
            this.EstoqueAtual_.ReadOnly = true;
            // 
            // EstoqueMinimo
            // 
            this.EstoqueMinimo.DataPropertyName = "EstoqueMinimo";
            this.EstoqueMinimo.HeaderText = "EstoqueMinimo";
            this.EstoqueMinimo.Name = "EstoqueMinimo";
            this.EstoqueMinimo.ReadOnly = true;
            this.EstoqueMinimo.Visible = false;
            // 
            // EstoqueMaximo
            // 
            this.EstoqueMaximo.DataPropertyName = "EstoqueMaximo";
            this.EstoqueMaximo.HeaderText = "EstoqueMaximo";
            this.EstoqueMaximo.Name = "EstoqueMaximo";
            this.EstoqueMaximo.ReadOnly = true;
            this.EstoqueMaximo.Visible = false;
            // 
            // Observacao
            // 
            this.Observacao.DataPropertyName = "Observacao";
            this.Observacao.HeaderText = "Observacao";
            this.Observacao.Name = "Observacao";
            this.Observacao.ReadOnly = true;
            this.Observacao.Visible = false;
            // 
            // DataCadastro
            // 
            this.DataCadastro.DataPropertyName = "DataCadastro";
            this.DataCadastro.HeaderText = "DataCadastro";
            this.DataCadastro.Name = "DataCadastro";
            this.DataCadastro.ReadOnly = true;
            this.DataCadastro.Visible = false;
            // 
            // UltimaCompra
            // 
            this.UltimaCompra.DataPropertyName = "UltimaCompra";
            this.UltimaCompra.HeaderText = "UltimaCompra";
            this.UltimaCompra.Name = "UltimaCompra";
            this.UltimaCompra.ReadOnly = true;
            this.UltimaCompra.Visible = false;
            // 
            // Aliq_Federal_Nacional
            // 
            this.Aliq_Federal_Nacional.DataPropertyName = "Aliq_Federal_Nacional";
            this.Aliq_Federal_Nacional.HeaderText = "Aliq_Federal_Nacional";
            this.Aliq_Federal_Nacional.Name = "Aliq_Federal_Nacional";
            this.Aliq_Federal_Nacional.ReadOnly = true;
            this.Aliq_Federal_Nacional.Visible = false;
            // 
            // Aliq_Estadual
            // 
            this.Aliq_Estadual.DataPropertyName = "Aliq_Estadual";
            this.Aliq_Estadual.HeaderText = "Aliq_Estadual";
            this.Aliq_Estadual.Name = "Aliq_Estadual";
            this.Aliq_Estadual.ReadOnly = true;
            this.Aliq_Estadual.Visible = false;
            // 
            // Aliq_Municipal
            // 
            this.Aliq_Municipal.DataPropertyName = "Aliq_Municipal";
            this.Aliq_Municipal.HeaderText = "Aliq_Municipal";
            this.Aliq_Municipal.Name = "Aliq_Municipal";
            this.Aliq_Municipal.ReadOnly = true;
            this.Aliq_Municipal.Visible = false;
            // 
            // FrmProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(798, 414);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.menuPanel);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "FrmProdutos";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro de Produtos";
            this.Load += new System.EventHandler(this.FrmProdutos_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmProdutos_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabCadastrar.ResumeLayout(false);
            this.tabCadastrar.PerformLayout();
            this.gpReporEstoque.ResumeLayout(false);
            this.gpReporEstoque.PerformLayout();
            this.tabClientesCadastrados.ResumeLayout(false);
            this.tabClientesCadastrados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCadastrar;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.ComboBox cbbUnidadeMedida;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button btnFornecedor;
        private System.Windows.Forms.TextBox txtFornecedor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAtivo;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TabPage tabClientesCadastrados;
        private System.Windows.Forms.Label lblQuantidade;
        private System.Windows.Forms.Label lblQuantidadeClientes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPesquisar;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnPesquisar;
        public System.Windows.Forms.Button btnGerarCodigoBarras;
        private System.Windows.Forms.TextBox txtCodigoBarras;
        private System.Windows.Forms.Label label13;
        private Componentes.DecimalTextbox2 txtValorVenda;
        private Componentes.DecimalTextbox2 txtValorUnitario;
        private System.Windows.Forms.Label lblEstoqueInicial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private Componentes.DecimalTextbox2 txtValorCompra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox gpReporEstoque;
        private System.Windows.Forms.Label label11;
        private Componentes.DecimalTextbox2 txtValorTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtObservacao;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cbbMovimentacaoProduto;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbbSubgrupoProdutos;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbbGrupoProdutos;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ToolTip toolTip;
        public System.Windows.Forms.Button btnGrupoProdutos;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.DateTimePicker dtpUltimaCompra;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpDataCadastro;
        public System.Windows.Forms.Button btnSubgrupoProdutos;
        private Componentes.Numero txtEstoqueInicial;
        private Componentes.Numero txtEstoqueMinimo;
        private Componentes.Numero txtEstoqueMaximo;
        private Componentes.Numero txtEstoqueAtual;
        private Componentes.Numero txtQuantidadeCompra;
        private System.Windows.Forms.DataGridView grid;
        public System.Windows.Forms.Button btnGrupoImposto;
        private System.Windows.Forms.TextBox txtDescricaoGrupoImposto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNCM;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.Button btnNCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdutosId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoBarras;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descricao;
        private System.Windows.Forms.DataGridViewTextBoxColumn TabelaIBPTId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn NCM;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ativo;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedidaId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnidadeMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn grupoProdutosId;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubgrupoProdutosId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TributacaoFiscalId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescricaoTributacaoFiscal;
        private System.Windows.Forms.DataGridViewTextBoxColumn GrupoProdutos;
        private System.Windows.Forms.DataGridViewTextBoxColumn FornecedorId_;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fornecedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorUnitario;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueInicial;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueAtual_;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueMinimo;
        private System.Windows.Forms.DataGridViewTextBoxColumn EstoqueMaximo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observacao;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCadastro;
        private System.Windows.Forms.DataGridViewTextBoxColumn UltimaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Federal_Nacional;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Estadual;
        private System.Windows.Forms.DataGridViewTextBoxColumn Aliq_Municipal;
    }
}