using PDV.AcessoBancoDados;
using PDV.Apresentacao.Cadastros;
using PDV.Apresentacao.Cadastros.Clientes;
using PDV.Apresentacao.MovimentacaoCaixa;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PDV.Apresentacao
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            frmLogin.ShowDialog();
        }

        #region Instancias

        readonly FrmLogin frmLogin = new FrmLogin();
        readonly EmpresaNegocios empresaNegocios = new EmpresaNegocios();
        public static Empresa dadosEmpresa;

        #endregion

        #region Variáveis para cadas menu

        bool cadastros, caixa, vendas, orcamento, financeiro, estoque, utilitario, ajuda = false;
        bool fecharCaixa = false;

        DataTable dtEmpresa;

        #endregion

        #region Métodos

        private void RetornarRegimeTributarioEmpresa()
        {
            dtEmpresa = new DataTable();
            dtEmpresa = empresaNegocios.PesquisarEmpresa();
        }

        private void AvisarCaixaAberto()
        {
            try
            {
                CaixaNegocios caixaNegocios = new CaixaNegocios();

                int caixaAberto = caixaNegocios.VerificarSeCaixaEstaAberto();
                DataTable ultimaAbertura = caixaNegocios.PesquisarPorCodigo(caixaAberto);

                if (ultimaAbertura.Rows.Count > 0)
                {
                    DateTime dataAbertura = Convert.ToDateTime(ultimaAbertura.Rows[0]["Abertura"]);
                    DateTime diaPosterior = Convert.ToDateTime(dataAbertura.AddDays(1).ToString("dd/MM/yyyy", CultureInfo.InvariantCulture));

                    DataTable dtDadosUltimaFechamento = caixaNegocios.PesquisarPorCodigo(caixaAberto);
                    int Caixa = (int)dtDadosUltimaFechamento.Rows[0]["CaixaId"];

                    if (DateTime.Now >= diaPosterior)
                    {
                        fecharCaixa = true;
                        MessageBox.Show("O caixa do dia: " + (dataAbertura.ToShortDateString()) + " está aberto.\nPor favor, feche o caixa antes para usar o sistema!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        FrmFecharCaixa frmFecharCaixa = new FrmFecharCaixa();
                        frmFecharCaixa.ShowDialog();

                        int caixaFechado = caixaNegocios.VerificarSeCaixaEstaAberto();
                        if (caixaFechado > 0)
                        {
                            MessageBox.Show("O caixa do dia: " + (dataAbertura.ToShortDateString()) + " ainda continua aberto.\n\nO sistema será fechado para sua segurança.\n\nLembrando que ao abrir novamente o sistema é necessário fechar o caixa antes, para usar o sistema!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Application.Exit();
                        }

                    }
                }
            }
            catch { }
        }

        #endregion


        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            AvisarCaixaAberto();
            RetornarRegimeTributarioEmpresa();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!fecharCaixa)
            {
                if (MessageBox.Show("Deseja realmente encerrar o sistema?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
            else
                Application.Exit();
        }

        #region Clicks Menu / Chama as barras de cada menu

        //1
        private void menuCadastros_Click(object sender, EventArgs e)
        {
            cadastros = true;

            if (cadastros)
            {
                barraCaixa.Visible = false;

                barraCadastros.Visible = true;
                cadastros = false;
            }
        }
        //2
        private void menuCaixa_Click(object sender, EventArgs e)
        {
            caixa = true;

            if (caixa)
            {
                barraCadastros.Visible = false;

                barraCaixa.Visible = true;
                caixa = false;
            }

        }

        #endregion

        #region Chamar os Formulários / Cadastros

        private void menuClientes_Click_1(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmCliente)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmCliente frmCliente = new FrmCliente();
                frmCliente.MdiParent = this;
                frmCliente.Show();
            }
        }

        private void menuIncluirSaldoCliente_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmAdicionarSaldoCliente)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmAdicionarSaldoCliente frmAdicionarSaldoCliente = new FrmAdicionarSaldoCliente();
                frmAdicionarSaldoCliente.MdiParent = this;
                frmAdicionarSaldoCliente.Show();
            }
        }

        private void menuTranferirSaldo_Click(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            string file = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PDV\\credenciais.xml";

            if (File.Exists(file))
            {
                File.Delete(file);
                MessageBox.Show("Credenciais removidas com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void menuProdutos_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmProdutos)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmProdutos frmProdutos = new FrmProdutos();
                frmProdutos.MdiParent = this;
                frmProdutos.Show();
            }
        }

        private void menuUsuarios_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmUsuarios)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmUsuarios frmUsuarios = new FrmUsuarios();
                frmUsuarios.MdiParent = this;
                frmUsuarios.Show();
            }
        }

        private void menuFuncionarios_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmFuncionarios)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmFuncionarios frmFuncionarios = new FrmFuncionarios();
                frmFuncionarios.MdiParent = this;
                frmFuncionarios.Show();
            }
        }

        private void menuFormaPagamento_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmCadastrarFormasPagamento)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmCadastrarFormasPagamento frmCadastrarFormasPagamento = new FrmCadastrarFormasPagamento();
                frmCadastrarFormasPagamento.MdiParent = this;
                frmCadastrarFormasPagamento.Show();
            }
        }

        private void menuGruposDeProdutos_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmGrupoProdutos)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmGrupoProdutos frmCategoria = new FrmGrupoProdutos();
                frmCategoria.MdiParent = this;
                frmCategoria.Show();
            }
        }

        private void menuSubgrupoProdutos_Click_1(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmSubgrupoProdutos)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmSubgrupoProdutos FrmSubgrupoProdutos = new FrmSubgrupoProdutos();
                FrmSubgrupoProdutos.MdiParent = this;
                FrmSubgrupoProdutos.Show();
            }
        }

        private void menuEmpresa_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmEmpresa)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmEmpresa frmEmpresa = new FrmEmpresa();
                frmEmpresa.MdiParent = this;
                frmEmpresa.Show();
            }
        }


        #region Tributação

        private void menuGrupoImpostoCadastrados_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmGerenciamentoTributario)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmGerenciamentoTributario frmGerenciamentoTributario = new FrmGerenciamentoTributario(Convert.ToInt32(dtEmpresa.Rows[0]["RegimeTributario"]));
                frmGerenciamentoTributario.MdiParent = this;
                frmGerenciamentoTributario.Show();
            }
        }

        #endregion




        #endregion

        #region Chamar os Formulários / Caixa

        private void menuAbrirCaixa_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmAbriCaixa)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmAbriCaixa frmAbriCaixa = new FrmAbriCaixa();
                frmAbriCaixa.MdiParent = this;
                frmAbriCaixa.Show();
            }
        }

        private void menuPDV_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmClientesCadastrados)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmClientesCadastrados frmClientesCadastrados = new FrmClientesCadastrados();
                frmClientesCadastrados.MdiParent = this;
                frmClientesCadastrados.Show();
            }
        }

        private void menuSangria_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmSangria)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmSangria frmSangria = new FrmSangria();
                frmSangria.MdiParent = this;
                frmSangria.tipoOperacao = enumSangriaOuSuprimento.Sangria;
                frmSangria.Show();
            }
        }

        private void menuSuprimento_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmSangria)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmSangria frmSangria = new FrmSangria();
                frmSangria.MdiParent = this;
                frmSangria.tipoOperacao = enumSangriaOuSuprimento.Suprimento;
                frmSangria.Show();
            }
        }

        private void menuFecharCaixa_Click(object sender, EventArgs e)
        {
            bool found = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmFecharCaixa)
                {
                    form.Focus();
                    found = true;
                }
            }

            if (!found)
            {
                FrmFecharCaixa frmFecharCaixa = new FrmFecharCaixa();
                frmFecharCaixa.MdiParent = this;
                frmFecharCaixa.Show();
            }
        }

        #endregion


    }
}
