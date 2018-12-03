namespace PDV.Apresentacao
{
    partial class FrmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.toolStripMenu = new System.Windows.Forms.ToolStrip();
            this.menuCadastros = new System.Windows.Forms.ToolStripButton();
            this.menuCaixa = new System.Windows.Forms.ToolStripButton();
            this.menuVendas = new System.Windows.Forms.ToolStripButton();
            this.menuOrcamentos = new System.Windows.Forms.ToolStripButton();
            this.menuFinanceiro = new System.Windows.Forms.ToolStripButton();
            this.menuEstoque = new System.Windows.Forms.ToolStripButton();
            this.menuUtilitarios = new System.Windows.Forms.ToolStripButton();
            this.menuBloquear = new System.Windows.Forms.ToolStripButton();
            this.menuConfiguracao = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuAjuda = new System.Windows.Forms.ToolStripButton();
            this.menuSair = new System.Windows.Forms.ToolStripButton();
            this.statusStripMenu = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.barraCadastros = new System.Windows.Forms.ToolStrip();
            this.Clientes = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuIncluirSaldoCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTranferirSaldo = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripButton();
            this.menuUsuarios = new System.Windows.Forms.ToolStripButton();
            this.menuFuncionarios = new System.Windows.Forms.ToolStripButton();
            this.menuFormaPagamento = new System.Windows.Forms.ToolStripButton();
            this.GrupoProdutos = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuGruposDeProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSubgrupoProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTributacao = new System.Windows.Forms.ToolStripDropDownButton();
            this.menuGrupoImpostoCadastrados = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTributacaoPorEstado = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.menuEmpresa = new System.Windows.Forms.ToolStripButton();
            this.barraCaixa = new System.Windows.Forms.ToolStrip();
            this.menuPDV = new System.Windows.Forms.ToolStripButton();
            this.menuAbrirCaixa = new System.Windows.Forms.ToolStripButton();
            this.menuSangria = new System.Windows.Forms.ToolStripButton();
            this.menuSuprimento = new System.Windows.Forms.ToolStripButton();
            this.menuFecharCaixa = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            this.toolStripMenu.SuspendLayout();
            this.statusStripMenu.SuspendLayout();
            this.barraCadastros.SuspendLayout();
            this.barraCaixa.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripMenu
            // 
            this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastros,
            this.menuCaixa,
            this.menuVendas,
            this.menuOrcamentos,
            this.menuFinanceiro,
            this.menuEstoque,
            this.menuUtilitarios,
            this.menuBloquear,
            this.menuConfiguracao,
            this.menuAjuda,
            this.menuSair});
            this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
            this.toolStripMenu.Name = "toolStripMenu";
            this.toolStripMenu.Size = new System.Drawing.Size(1089, 25);
            this.toolStripMenu.TabIndex = 1;
            this.toolStripMenu.Text = "toolStrip1";
            // 
            // menuCadastros
            // 
            this.menuCadastros.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuCadastros.Image = ((System.Drawing.Image)(resources.GetObject("menuCadastros.Image")));
            this.menuCadastros.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCadastros.Name = "menuCadastros";
            this.menuCadastros.Size = new System.Drawing.Size(81, 22);
            this.menuCadastros.Text = "   Cadastros   ";
            this.menuCadastros.Click += new System.EventHandler(this.menuCadastros_Click);
            // 
            // menuCaixa
            // 
            this.menuCaixa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuCaixa.Image = ((System.Drawing.Image)(resources.GetObject("menuCaixa.Image")));
            this.menuCaixa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuCaixa.Name = "menuCaixa";
            this.menuCaixa.Size = new System.Drawing.Size(57, 22);
            this.menuCaixa.Text = "   Caixa   ";
            this.menuCaixa.Click += new System.EventHandler(this.menuCaixa_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuVendas.Image = ((System.Drawing.Image)(resources.GetObject("menuVendas.Image")));
            this.menuVendas.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(66, 22);
            this.menuVendas.Text = "   Vendas   ";
            // 
            // menuOrcamentos
            // 
            this.menuOrcamentos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuOrcamentos.Image = ((System.Drawing.Image)(resources.GetObject("menuOrcamentos.Image")));
            this.menuOrcamentos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuOrcamentos.Name = "menuOrcamentos";
            this.menuOrcamentos.Size = new System.Drawing.Size(94, 22);
            this.menuOrcamentos.Text = "   Orçamentos   ";
            // 
            // menuFinanceiro
            // 
            this.menuFinanceiro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuFinanceiro.Image = ((System.Drawing.Image)(resources.GetObject("menuFinanceiro.Image")));
            this.menuFinanceiro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFinanceiro.Name = "menuFinanceiro";
            this.menuFinanceiro.Size = new System.Drawing.Size(84, 22);
            this.menuFinanceiro.Text = "   Financeiro   ";
            // 
            // menuEstoque
            // 
            this.menuEstoque.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuEstoque.Image = ((System.Drawing.Image)(resources.GetObject("menuEstoque.Image")));
            this.menuEstoque.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEstoque.Name = "menuEstoque";
            this.menuEstoque.Size = new System.Drawing.Size(77, 22);
            this.menuEstoque.Text = "   Estoque     ";
            // 
            // menuUtilitarios
            // 
            this.menuUtilitarios.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuUtilitarios.Image = ((System.Drawing.Image)(resources.GetObject("menuUtilitarios.Image")));
            this.menuUtilitarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuUtilitarios.Name = "menuUtilitarios";
            this.menuUtilitarios.Size = new System.Drawing.Size(79, 22);
            this.menuUtilitarios.Text = "   Utilitários   ";
            // 
            // menuBloquear
            // 
            this.menuBloquear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuBloquear.Image = ((System.Drawing.Image)(resources.GetObject("menuBloquear.Image")));
            this.menuBloquear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuBloquear.Name = "menuBloquear";
            this.menuBloquear.Size = new System.Drawing.Size(76, 22);
            this.menuBloquear.Text = "   Bloquear   ";
            // 
            // menuConfiguracao
            // 
            this.menuConfiguracao.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuConfiguracao.Image = ((System.Drawing.Image)(resources.GetObject("menuConfiguracao.Image")));
            this.menuConfiguracao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuConfiguracao.Name = "menuConfiguracao";
            this.menuConfiguracao.Size = new System.Drawing.Size(110, 22);
            this.menuConfiguracao.Text = "   Configuração   ";
            // 
            // menuAjuda
            // 
            this.menuAjuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuAjuda.Image = ((System.Drawing.Image)(resources.GetObject("menuAjuda.Image")));
            this.menuAjuda.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuAjuda.Name = "menuAjuda";
            this.menuAjuda.Size = new System.Drawing.Size(69, 22);
            this.menuAjuda.Text = "   Ajuda      ";
            // 
            // menuSair
            // 
            this.menuSair.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuSair.Image = ((System.Drawing.Image)(resources.GetObject("menuSair.Image")));
            this.menuSair.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(48, 22);
            this.menuSair.Text = "   Sair   ";
            // 
            // statusStripMenu
            // 
            this.statusStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel1});
            this.statusStripMenu.Location = new System.Drawing.Point(0, 432);
            this.statusStripMenu.Name = "statusStripMenu";
            this.statusStripMenu.Size = new System.Drawing.Size(1089, 22);
            this.statusStripMenu.TabIndex = 2;
            this.statusStripMenu.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(64, 17);
            this.toolStripStatusLabel2.Text = "NomePC   ";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(96, 17);
            this.toolStripStatusLabel3.Text = "UsuarioLogado   ";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabel1.Text = "DataHora   ";
            // 
            // barraCadastros
            // 
            this.barraCadastros.AutoSize = false;
            this.barraCadastros.BackColor = System.Drawing.SystemColors.Control;
            this.barraCadastros.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barraCadastros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraCadastros.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.barraCadastros.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clientes,
            this.menuProdutos,
            this.menuUsuarios,
            this.menuFuncionarios,
            this.menuFormaPagamento,
            this.GrupoProdutos,
            this.menuTributacao,
            this.toolStripButton1,
            this.menuEmpresa});
            this.barraCadastros.Location = new System.Drawing.Point(0, 25);
            this.barraCadastros.Name = "barraCadastros";
            this.barraCadastros.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.barraCadastros.Size = new System.Drawing.Size(1089, 65);
            this.barraCadastros.Stretch = true;
            this.barraCadastros.TabIndex = 17;
            this.barraCadastros.Visible = false;
            // 
            // Clientes
            // 
            this.Clientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClientes,
            this.menuIncluirSaldoCliente,
            this.menuTranferirSaldo});
            this.Clientes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Clientes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Clientes.Name = "Clientes";
            this.Clientes.Size = new System.Drawing.Size(80, 62);
            this.Clientes.Text = "   Clientes   ";
            this.Clientes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Clientes.ToolTipText = "Cadastro de Clientes";
            // 
            // menuClientes
            // 
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(220, 22);
            this.menuClientes.Text = "1. Cadastro de clientes";
            this.menuClientes.Click += new System.EventHandler(this.menuClientes_Click_1);
            // 
            // menuIncluirSaldoCliente
            // 
            this.menuIncluirSaldoCliente.Name = "menuIncluirSaldoCliente";
            this.menuIncluirSaldoCliente.Size = new System.Drawing.Size(220, 22);
            this.menuIncluirSaldoCliente.Text = "2. Incluir saldo para cliente";
            this.menuIncluirSaldoCliente.Click += new System.EventHandler(this.menuIncluirSaldoCliente_Click);
            // 
            // menuTranferirSaldo
            // 
            this.menuTranferirSaldo.Name = "menuTranferirSaldo";
            this.menuTranferirSaldo.Size = new System.Drawing.Size(220, 22);
            this.menuTranferirSaldo.Text = "3. Transferir saldo de cliente";
            this.menuTranferirSaldo.Click += new System.EventHandler(this.menuTranferirSaldo_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuProdutos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(77, 62);
            this.menuProdutos.Text = "   Produtos   ";
            this.menuProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuProdutos.ToolTipText = "Cadastro de Clientes";
            this.menuProdutos.Click += new System.EventHandler(this.menuProdutos_Click);
            // 
            // menuUsuarios
            // 
            this.menuUsuarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuUsuarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuUsuarios.Name = "menuUsuarios";
            this.menuUsuarios.Size = new System.Drawing.Size(74, 62);
            this.menuUsuarios.Text = "   Usuários   ";
            this.menuUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuUsuarios.ToolTipText = "Cadastro de Usuários";
            this.menuUsuarios.Click += new System.EventHandler(this.menuUsuarios_Click);
            // 
            // menuFuncionarios
            // 
            this.menuFuncionarios.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFuncionarios.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFuncionarios.Name = "menuFuncionarios";
            this.menuFuncionarios.Size = new System.Drawing.Size(97, 62);
            this.menuFuncionarios.Text = "   Funcionários   ";
            this.menuFuncionarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuFuncionarios.ToolTipText = "Cadastro de subgrupoProdutos";
            this.menuFuncionarios.Click += new System.EventHandler(this.menuFuncionarios_Click);
            // 
            // menuFormaPagamento
            // 
            this.menuFormaPagamento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFormaPagamento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFormaPagamento.Name = "menuFormaPagamento";
            this.menuFormaPagamento.Size = new System.Drawing.Size(148, 62);
            this.menuFormaPagamento.Text = "   Formas de Pagamento   ";
            this.menuFormaPagamento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuFormaPagamento.ToolTipText = "Cadastro de subgrupoProdutos";
            this.menuFormaPagamento.Click += new System.EventHandler(this.menuFormaPagamento_Click);
            // 
            // GrupoProdutos
            // 
            this.GrupoProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGruposDeProdutos,
            this.menuSubgrupoProdutos});
            this.GrupoProdutos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.GrupoProdutos.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.GrupoProdutos.Name = "GrupoProdutos";
            this.GrupoProdutos.Size = new System.Drawing.Size(143, 62);
            this.GrupoProdutos.Text = "   Grupos de Produtos   ";
            this.GrupoProdutos.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.GrupoProdutos.ToolTipText = "Cadastro de Categoria";
            // 
            // menuGruposDeProdutos
            // 
            this.menuGruposDeProdutos.Name = "menuGruposDeProdutos";
            this.menuGruposDeProdutos.Size = new System.Drawing.Size(205, 22);
            this.menuGruposDeProdutos.Text = "1. Grupos de Produtos";
            this.menuGruposDeProdutos.Click += new System.EventHandler(this.menuGruposDeProdutos_Click);
            // 
            // menuSubgrupoProdutos
            // 
            this.menuSubgrupoProdutos.Name = "menuSubgrupoProdutos";
            this.menuSubgrupoProdutos.Size = new System.Drawing.Size(205, 22);
            this.menuSubgrupoProdutos.Text = "2. Subgrupo de Produtos";
            this.menuSubgrupoProdutos.Click += new System.EventHandler(this.menuSubgrupoProdutos_Click_1);
            // 
            // menuTributacao
            // 
            this.menuTributacao.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuGrupoImpostoCadastrados,
            this.menuTributacaoPorEstado});
            this.menuTributacao.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuTributacao.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuTributacao.Name = "menuTributacao";
            this.menuTributacao.Size = new System.Drawing.Size(94, 62);
            this.menuTributacao.Text = "   Tributação   ";
            this.menuTributacao.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuTributacao.ToolTipText = "Cadastro de subgrupoProdutos";
            // 
            // menuGrupoImpostoCadastrados
            // 
            this.menuGrupoImpostoCadastrados.Name = "menuGrupoImpostoCadastrados";
            this.menuGrupoImpostoCadastrados.Size = new System.Drawing.Size(253, 22);
            this.menuGrupoImpostoCadastrados.Text = "1. Grupo de Impostos cadastrados";
            this.menuGrupoImpostoCadastrados.Click += new System.EventHandler(this.menuGrupoImpostoCadastrados_Click);
            // 
            // menuTributacaoPorEstado
            // 
            this.menuTributacaoPorEstado.Name = "menuTributacaoPorEstado";
            this.menuTributacaoPorEstado.Size = new System.Drawing.Size(253, 22);
            this.menuTributacaoPorEstado.Text = "2. Tributação por Estado";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.AutoSize = false;
            this.toolStripButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(250, 62);
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Cadastro de subgrupoProdutos";
            // 
            // menuEmpresa
            // 
            this.menuEmpresa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuEmpresa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuEmpresa.Name = "menuEmpresa";
            this.menuEmpresa.Size = new System.Drawing.Size(56, 62);
            this.menuEmpresa.Text = "Empresa";
            this.menuEmpresa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuEmpresa.ToolTipText = "Cadastro de subgrupoProdutos";
            this.menuEmpresa.Click += new System.EventHandler(this.menuEmpresa_Click);
            // 
            // barraCaixa
            // 
            this.barraCaixa.AutoSize = false;
            this.barraCaixa.BackColor = System.Drawing.SystemColors.Control;
            this.barraCaixa.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.barraCaixa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barraCaixa.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.barraCaixa.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuPDV,
            this.menuAbrirCaixa,
            this.menuSangria,
            this.menuSuprimento,
            this.menuFecharCaixa});
            this.barraCaixa.Location = new System.Drawing.Point(0, 25);
            this.barraCaixa.Name = "barraCaixa";
            this.barraCaixa.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.barraCaixa.Size = new System.Drawing.Size(1089, 65);
            this.barraCaixa.Stretch = true;
            this.barraCaixa.TabIndex = 18;
            this.barraCaixa.Visible = false;
            // 
            // menuPDV
            // 
            this.menuPDV.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuPDV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuPDV.Name = "menuPDV";
            this.menuPDV.Size = new System.Drawing.Size(51, 62);
            this.menuPDV.Text = "   PDV   ";
            this.menuPDV.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuPDV.ToolTipText = "Cadastro de Clientes";
            this.menuPDV.Click += new System.EventHandler(this.menuPDV_Click);
            // 
            // menuAbrirCaixa
            // 
            this.menuAbrirCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuAbrirCaixa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuAbrirCaixa.Name = "menuAbrirCaixa";
            this.menuAbrirCaixa.Size = new System.Drawing.Size(86, 62);
            this.menuAbrirCaixa.Text = "   Abrir Caixa   ";
            this.menuAbrirCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuAbrirCaixa.ToolTipText = "Cadastro de Clientes";
            this.menuAbrirCaixa.Click += new System.EventHandler(this.menuAbrirCaixa_Click);
            // 
            // menuSangria
            // 
            this.menuSangria.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuSangria.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSangria.Name = "menuSangria";
            this.menuSangria.Size = new System.Drawing.Size(68, 62);
            this.menuSangria.Text = "   Sangria   ";
            this.menuSangria.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuSangria.ToolTipText = "Cadastro de Clientes";
            this.menuSangria.Click += new System.EventHandler(this.menuSangria_Click);
            // 
            // menuSuprimento
            // 
            this.menuSuprimento.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuSuprimento.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuSuprimento.Name = "menuSuprimento";
            this.menuSuprimento.Size = new System.Drawing.Size(91, 62);
            this.menuSuprimento.Text = "   Suprimento   ";
            this.menuSuprimento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuSuprimento.ToolTipText = "Cadastro de Clientes";
            this.menuSuprimento.Click += new System.EventHandler(this.menuSuprimento_Click);
            // 
            // menuFecharCaixa
            // 
            this.menuFecharCaixa.ForeColor = System.Drawing.SystemColors.ControlText;
            this.menuFecharCaixa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.menuFecharCaixa.Name = "menuFecharCaixa";
            this.menuFecharCaixa.Size = new System.Drawing.Size(95, 62);
            this.menuFecharCaixa.Text = "   Fechar Caixa   ";
            this.menuFecharCaixa.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuFecharCaixa.ToolTipText = "Cadastro de Clientes";
            this.menuFecharCaixa.Click += new System.EventHandler(this.menuFecharCaixa_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(908, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(181, 44);
            this.button1.TabIndex = 20;
            this.button1.Text = "Excluir acesso automático";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 454);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.barraCadastros);
            this.Controls.Add(this.barraCaixa);
            this.Controls.Add(this.statusStripMenu);
            this.Controls.Add(this.toolStripMenu);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bem-Vindo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.toolStripMenu.ResumeLayout(false);
            this.toolStripMenu.PerformLayout();
            this.statusStripMenu.ResumeLayout(false);
            this.statusStripMenu.PerformLayout();
            this.barraCadastros.ResumeLayout(false);
            this.barraCadastros.PerformLayout();
            this.barraCaixa.ResumeLayout(false);
            this.barraCaixa.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton menuSair;
        private System.Windows.Forms.ToolStripButton menuCaixa;
        private System.Windows.Forms.ToolStripButton menuVendas;
        private System.Windows.Forms.ToolStripButton menuOrcamentos;
        private System.Windows.Forms.ToolStripButton menuFinanceiro;
        private System.Windows.Forms.ToolStripButton menuEstoque;
        private System.Windows.Forms.ToolStripButton menuUtilitarios;
        private System.Windows.Forms.ToolStripButton menuBloquear;
        private System.Windows.Forms.ToolStripButton menuAjuda;
        private System.Windows.Forms.StatusStrip statusStripMenu;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStrip barraCadastros;
        private System.Windows.Forms.ToolStripButton menuUsuarios;
        private System.Windows.Forms.ToolStripButton menuProdutos;
        private System.Windows.Forms.ToolStrip barraCaixa;
        private System.Windows.Forms.ToolStripButton menuPDV;
        private System.Windows.Forms.ToolStripButton menuAbrirCaixa;
        private System.Windows.Forms.ToolStripButton menuSangria;
        private System.Windows.Forms.ToolStripButton menuFecharCaixa;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripButton menuSuprimento;
        private System.Windows.Forms.ToolStripDropDownButton menuConfiguracao;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton menuEmpresa;
        private System.Windows.Forms.ToolStripButton menuCadastros;
        private System.Windows.Forms.ToolStripDropDownButton menuTributacao;
        private System.Windows.Forms.ToolStripMenuItem menuGrupoImpostoCadastrados;
        private System.Windows.Forms.ToolStripMenuItem menuTributacaoPorEstado;
        private System.Windows.Forms.ToolStripDropDownButton Clientes;
        private System.Windows.Forms.ToolStripMenuItem menuIncluirSaldoCliente;
        private System.Windows.Forms.ToolStripMenuItem menuTranferirSaldo;
        private System.Windows.Forms.ToolStripButton menuFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripButton menuFormaPagamento;
        private System.Windows.Forms.ToolStripDropDownButton GrupoProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuGruposDeProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuSubgrupoProdutos;
    }
}