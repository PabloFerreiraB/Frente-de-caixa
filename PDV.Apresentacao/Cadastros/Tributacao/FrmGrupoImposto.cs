using PDV.AcessoBancoDados;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros.Tributacao
{
    public partial class FrmGrupoImposto : Form
    {
        public FrmGrupoImposto(int regimeTributario)
        {
            InitializeComponent();


            // 1 - SIMPLES NACIONAL
            // 2 - LUCRO PRESUMIDO
            // 3 - LUCRO REAL
            if (regimeTributario.Equals(0))
                cbbRegimeTributario.SelectedIndex = 0;
            else
                cbbRegimeTributario.SelectedIndex = 1;

            cbbRegimeTributario.Enabled = false;

            txtDescricao.Select();
            txtDescricao.Focus();
        }

        #region Instancias

        readonly TributacaoFiscalNegocios tributacaoFiscalNegocios = new TributacaoFiscalNegocios();
        readonly TributacaoFiscalEstadosNegocios tributacaoFiscalEstadosNegocios = new TributacaoFiscalEstadosNegocios();
        readonly IcmsNegocios icmsNegocios = new IcmsNegocios();
        readonly PisNegocios pisNegocios = new PisNegocios();
        readonly CofinsNegocios cofinsNegocios = new CofinsNegocios();
        readonly OrigemNegocios origemNegocios = new OrigemNegocios();
        readonly IpiNegocios ipiNegocios = new IpiNegocios();
        readonly Conexao conexao = new Conexao();
        readonly CidadesNegocios cidadesNegocios = new CidadesNegocios();

        #endregion

        #region Propriedades

        public int _TributacaoFiscalId { get; set; }
        public bool _executouOperacao { get; set; }

        #endregion

        #region Variáveis

        public int tipo = 0;

        #endregion

        #region Métodos

        private void CarregarIcms()
        {
            DataTable dtCstCsosn = new DataTable();
            dtCstCsosn = icmsNegocios.PesquisarPorTipo(cbbRegimeTributario.Text.Substring(0, 1).Equals("0") ? 2 : 1);

            cbbIcms.DataSource = dtCstCsosn;
            cbbIcms.DisplayMember = "Descricao";
            cbbIcms.ValueMember = "IcmsCst";
            cbbIcms.SelectedIndex = -1;

            if (cbbRegimeTributario.Text.Substring(0, 1).Equals("0"))
            {
                //SIMPLES NACIOMAL
                lblCstOrCsosn.Text = "ST do Icms Csosn";
            }
            else
            {
                lblCstOrCsosn.Text = "ST do Icms Cst";
            }
        }

        private void InserirTributacaoEstados(int tributacaoFiscalEstadosId)
        {
            TributacaoFiscalEstados tributacaoFiscalEstados = new TributacaoFiscalEstados();
            tributacaoFiscalEstados.TributacaoFiscalEstadosId = tributacaoFiscalEstadosId;
            tributacaoFiscalEstadosNegocios.Excluir(tributacaoFiscalEstados);

            foreach (DataGridViewRow r in gridEstados.Rows)
            {
                tributacaoFiscalEstados.OperacaoId = Convert.ToInt32(r.Cells["EstadoId"].Value);
                tributacaoFiscalEstados.OperacaoUFSelecionado = Convert.ToBoolean(r.Cells["Check"].Value);
                tributacaoFiscalEstados.TributacaoFiscalEstadosId = tributacaoFiscalEstadosId;

                tributacaoFiscalEstadosNegocios.Inserir(tributacaoFiscalEstados);
            }
        }


        private void OcultarCamposIPI()
        {
            lblIpi.Visible = lblCstSTIpi.Visible = lblCodigoEnqIpi.Visible = lblPercentualBCIpi.Visible = lblPercentualIpi.Visible = false;
            cbbIpiCst.Visible = txtCodigoEnquadramentoIpi.Visible = txtPercentualBCIpi.Visible = txtPercentualIpi.Visible = false;
        }

        private void CarregarPIS()
        {
            DataTable dtPis = new DataTable();
            dtPis = pisNegocios.PesquisarPisDataSource(tipo);

            cbbPis.DataSource = dtPis;
            cbbPis.DisplayMember = "Descricao";
            cbbPis.ValueMember = "PisCst";
            cbbPis.SelectedIndex = -1;
        }

        private void CarregarCofins()
        {
            DataTable dtCofins = new DataTable();
            dtCofins = cofinsNegocios.PesquisarCofinsDataSource(tipo);

            cbbCofins.DataSource = dtCofins;
            cbbCofins.DisplayMember = "Descricao";
            cbbCofins.ValueMember = "CofinsCst";
            cbbCofins.SelectedIndex = -1;
        }

        private void CarregarOrigem()
        {
            DataTable dtOrigem = new DataTable();
            dtOrigem = origemNegocios.PesquisarPorNome(string.Empty);

            cbbOrigem.DataSource = dtOrigem;
            cbbOrigem.DisplayMember = "Descricao";
            cbbOrigem.ValueMember = "OrigemId";
            cbbOrigem.SelectedIndex = -1;
        }

        private void CarregarIPI()
        {
            DataTable dtIpi = new DataTable();
            dtIpi = ipiNegocios.PesquisarIpi(tipo);

            cbbIpiCst.DataSource = dtIpi;
            cbbIpiCst.DisplayMember = "Descricao";
            cbbIpiCst.ValueMember = "IpiCst";
            cbbIpiCst.SelectedIndex = -1;
        }

        private void CarregarEstados()
        {
            DataTable dtOperacaoFiscalEstados = new DataTable();
            dtOperacaoFiscalEstados = tributacaoFiscalEstadosNegocios.PesquisarPorCodigo(_TributacaoFiscalId);

            if (dtOperacaoFiscalEstados.Rows.Count > 0)
            {
                foreach (DataRow rV in dtOperacaoFiscalEstados.Rows)
                {
                    gridEstados.Rows.Add(rV["OperacaoId"].ToString(),
                                         Convert.ToBoolean(rV["OperacaoUFSelecionado"]),
                                         rV["NomeEstado"].ToString(),
                                         rV["Uf"].ToString());
                }
            }
            else
            {
                DataTable dtEstados = new DataTable();
                dtEstados = cidadesNegocios.PesquisarDataSourceEstados();
                foreach (DataRow rV in dtEstados.Rows)
                {
                    gridEstados.Rows.Add(rV["EstadoId"].ToString(),
                                         true,
                                         rV["NomeEstado"].ToString(),
                                         rV["UF"].ToString());
                }
            }
        }


        private void CarregarGrupos()
        {
            //CARREGAR OPERACAO FISCAL
            DataTable dtOperacao = new DataTable();
            dtOperacao = tributacaoFiscalNegocios.PesquisarPorCodigo(_TributacaoFiscalId);

            cbbRegimeTributario.SelectedIndex = Convert.ToInt32(dtOperacao.Rows[0]["RegimeTributario"]);
            txtDescricao.Text = dtOperacao.Rows[0]["Descricao"].ToString();

            if (dtOperacao.Rows[0]["Icms_Issqn"].ToString().Equals("1"))
                rbIcms.Checked = true;
            else
                rbIssqn.Checked = true;

            txtCodigoCfop.Text = dtOperacao.Rows[0]["Cfop"].ToString();
            txtDescricaoCfop.Text = dtOperacao.Rows[0]["DescricaoCFOP"].ToString();
            chkCalcularIBPT.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["CalcularIBPT"]);
            chkGerarFinanceiro.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["GerarFinanceiro"]);
            chkMovimentarEstoque.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["MovimentaEstoque"]);

            //ICMS
            chkCalcularIcmsST.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["CalcularSTIcms"]);
            cbbIcms.SelectedValue = dtOperacao.Rows[0]["IcmsCst"].ToString(); 
            cbbOrigem.SelectedValue = dtOperacao.Rows[0]["IcmsOrigem"].ToString();
            txtPercentualBCIcms.Text = Convert.ToDecimal(dtOperacao.Rows[0]["IcmsPercentualBC"]).ToString("N2");
            txtPercentualIcms.Text = Convert.ToDecimal(dtOperacao.Rows[0]["IcmsPercentual"]).ToString("N2");

            //IPI
            cbbIpiCst.SelectedValue = dtOperacao.Rows[0]["IpiCst"].ToString();
            txtCodigoEnquadramentoIpi.Text = dtOperacao.Rows[0]["IpiCodigo"].ToString();
            txtPercentualBCIpi.Text = Convert.ToDecimal(dtOperacao.Rows[0]["IpiPercentualBC"]).ToString("N2");
            txtPercentualIpi.Text = Convert.ToDecimal(dtOperacao.Rows[0]["IpiPercentual"]).ToString("N2");

            //PIS E PIS ST
            cbbPis.SelectedValue = dtOperacao.Rows[0]["PisCst"].ToString();
            txtPercentualBCPis.Text = Convert.ToDecimal(dtOperacao.Rows[0]["PisPercentualBC"]).ToString("N2");
            txtPercentualPis.Text = Convert.ToDecimal(dtOperacao.Rows[0]["PisPercentual"]).ToString("N2");
            chkGerarPisST.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["PisGerarST"]);
            txtPercentualBCPisST.Text = Convert.ToDecimal(dtOperacao.Rows[0]["PisSTPercentualBC"]).ToString("N2");
            txtPercentualPisST.Text = Convert.ToDecimal(dtOperacao.Rows[0]["PisSTPercentual"]).ToString("N2");

            //COFINS E COFINS ST
            cbbCofins.SelectedValue = dtOperacao.Rows[0]["CofinsCst"].ToString();
            txtPercentualBCCofins.Text = Convert.ToDecimal(dtOperacao.Rows[0]["CofinsPercentualBC"]).ToString("N2");
            txtPercentualCofins.Text = Convert.ToDecimal(dtOperacao.Rows[0]["CofinsPercentual"]).ToString("N2");
            chkGerarCofinsST.Checked = Convert.ToBoolean(dtOperacao.Rows[0]["CofinsGerarST"]);
            txtPercentualBCCofinsST.Text = Convert.ToDecimal(dtOperacao.Rows[0]["CofinsSTPercentualBC"]).ToString("N2");
            txtPercentualCofinsST.Text = Convert.ToDecimal(dtOperacao.Rows[0]["CofinsSTPercentual"]).ToString("N2");
        }

        #endregion

        private void FrmGrupoImposto_Load(object sender, EventArgs e)
        {
            if (_TributacaoFiscalId.Equals(0))
                this.Text = "Novo Grupo de Imposto - " + (tipo.ToString().Equals("0") ? "Entrada" : "Saída");
            else
                this.Text = "Alterando Grupo de Imposto - " + (tipo.ToString().Equals("0") ? "Entrada" : "Saída");

            if (tipo == 1) //Ocultando os dados do IPI quando a operação for de saída
                OcultarCamposIPI();

            CarregarPIS();
            CarregarCofins();
            CarregarOrigem();
            CarregarIPI();
            CarregarEstados();

            if (_TributacaoFiscalId > 0)
            {
                CarregarGrupos();
                CarregarEstados();
            }
        }

        private void cbbRegimeTributario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarIcms();
        }

        private void btnCfop_Click(object sender, EventArgs e)
        {
            FrmCFOP frmCFOP = new FrmCFOP();
            frmCFOP.ShowInTaskbar = false;
            frmCFOP._PesquisaExterna = true;
            frmCFOP._Tipo = tipo;
            frmCFOP.ShowDialog();

            if (frmCFOP._CfopId > 0)
            {
                txtCodigoCfop.Text = frmCFOP._Codigo;
                txtDescricaoCfop.Text = frmCFOP._Descricao;
                chkMovimentarEstoque.Focus();
            }
            else
                txtCodigoCfop.Focus();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Validações

                if (string.IsNullOrEmpty(txtDescricao.Text.Trim()))
                {
                    MessageBox.Show("Por favor, informe descrição!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricao.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtDescricaoCfop.Text.Trim()))
                {
                    MessageBox.Show("Por favor, informe o CFOP!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCodigoCfop.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cbbIcms.Text))
                {
                    MessageBox.Show("Por favor, informe a " + lblCstOrCsosn.Text + " !", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbIcms.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(cbbOrigem.Text))
                {
                    MessageBox.Show("Por favor, informe a Origem!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbOrigem.Focus();
                    return;
                }

                if (tipo == 0)
                {
                    if (string.IsNullOrEmpty(cbbIpiCst.Text))
                    {
                        MessageBox.Show("Por favor, informe a Situação Tributária do IPI CST!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cbbIpiCst.Focus();
                        return;
                    }

                    if (txtCodigoEnquadramentoIpi.Visible)
                    {
                        if (txtCodigoEnquadramentoIpi.Text.Length != 3)
                        {
                            MessageBox.Show("O código de enquadramento do IPI é de 3 digítos, por favor preencha o código corretamente!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCodigoEnquadramentoIpi.Focus();
                            return;
                        }
                    }
                }

                if (string.IsNullOrEmpty(cbbPis.Text))
                {
                    MessageBox.Show("Por favor, informe o PIS!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbPis.Focus();
                    return;
                }
                if (string.IsNullOrEmpty(cbbCofins.Text))
                {
                    MessageBox.Show("Por favor, informe o COFINS!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbbCofins.Focus();
                    return;
                }

                #endregion

                TributacaoFiscal tributacaoFiscal = new TributacaoFiscal();

                tributacaoFiscal.Descricao = txtDescricao.Text;
                tributacaoFiscal.RegimeTributario = Convert.ToInt32(cbbRegimeTributario.Text.Substring(0, 1));
                tributacaoFiscal.Tipo = tipo;
                tributacaoFiscal.Icms_Issqn = rbIcms.Checked ? 1 : 2;
                tributacaoFiscal.Cfop = txtCodigoCfop.Text;
                tributacaoFiscal.MovimentaEstoque = chkMovimentarEstoque.Checked;
                tributacaoFiscal.GerarFinanceiro = chkGerarFinanceiro.Checked;
                tributacaoFiscal.CalcularIBPT = chkCalcularIBPT.Checked;

                //ICMS
                tributacaoFiscal.CalcularSTIcms = chkCalcularIcmsST.Enabled ? chkCalcularIcmsST.Checked : false;
                tributacaoFiscal.IcmsCst = cbbIcms.Text.Substring(0, 3).TrimEnd();
                tributacaoFiscal.IcmsOrigem = Convert.ToInt32(cbbOrigem.Text.Substring(0, 1));
                tributacaoFiscal.IcmsPercentualBC = Convert.ToDecimal(txtPercentualBCIcms.Text);
                tributacaoFiscal.IcmsPercentual = Convert.ToDecimal(txtPercentualIcms.Text);

                //IPI
                tributacaoFiscal.IpiCst = !string.IsNullOrEmpty(cbbIpiCst.Text) ? cbbIpiCst.Text.Substring(0, 2) : "";
                tributacaoFiscal.IpiCodigo = txtCodigoEnquadramentoIpi.Text;
                tributacaoFiscal.IpiPercentualBC = Convert.ToDecimal(txtPercentualBCIpi.Text);
                tributacaoFiscal.IpiPercentual = Convert.ToDecimal(txtPercentualIpi.Text);

                //PIS
                tributacaoFiscal.PisCst = cbbPis.Text.Substring(0, 2);
                tributacaoFiscal.PisPercentualBC = Convert.ToDecimal(txtPercentualBCPis.Text);
                tributacaoFiscal.PisPercentual = Convert.ToDecimal(txtPercentualPis.Text);

                //PIS ST
                tributacaoFiscal.PisGerarST = chkGerarPisST.Checked;
                tributacaoFiscal.PisSTPercentualBC = Convert.ToDecimal(txtPercentualBCPisST.Text);
                tributacaoFiscal.PisSTPercentual = Convert.ToDecimal(txtPercentualPisST.Text);

                //COFINS
                tributacaoFiscal.CofinsCst = cbbCofins.Text.Substring(0, 2);
                tributacaoFiscal.CofinsPercentualBC = Convert.ToDecimal(txtPercentualBCCofins.Text);
                tributacaoFiscal.CofinsPercentual = Convert.ToDecimal(txtPercentualCofins.Text);

                //COFINS ST
                tributacaoFiscal.CofinsGerarST = chkGerarCofinsST.Checked;
                tributacaoFiscal.CofinsSTPercentualBC = Convert.ToDecimal(txtPercentualBCCofinsST.Text);
                tributacaoFiscal.CofinsSTPercentual = Convert.ToDecimal(txtPercentualCofinsST.Text);


                if (_TributacaoFiscalId.Equals(0))
                {
                    tributacaoFiscalNegocios.Inserir(tributacaoFiscal);

                    int ultimoId = conexao.RetornarUltimoId("TributacaoFiscal", "TributacaoFiscalId");
                    InserirTributacaoEstados(ultimoId);

                    MessageBox.Show("Grupo de imposto cadastrado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    tributacaoFiscal.TributacaoFiscalId = _TributacaoFiscalId;
                    tributacaoFiscalNegocios.Alterar(tributacaoFiscal);

                    InserirTributacaoEstados(_TributacaoFiscalId);
                    MessageBox.Show("Grupo de imposto alterado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                _executouOperacao = true;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro:" + ex.Message, "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmGrupoImposto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnSalvar_Click(sender, e);
            }
        }

        /// <summary>
        /// ICMS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbIcms_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkCalcularIcmsST.Enabled = false;
            chkCalcularIcmsST.Checked = false;

            if (cbbIcms.SelectedValue != null)
            {
                if (cbbIcms.SelectedValue.Equals("201") || cbbIcms.SelectedValue.Equals("202") || cbbIcms.SelectedValue.Equals("203") ||
                    cbbIcms.SelectedValue.Equals("10") || cbbIcms.SelectedValue.Equals("10A") || cbbIcms.SelectedValue.Equals("70") ||
                    cbbIcms.SelectedValue.Equals("90") || cbbIcms.SelectedValue.Equals("900") || cbbIcms.SelectedValue.Equals("500"))
                {
                    chkCalcularIcmsST.Enabled = true;
                    chkCalcularIcmsST.Checked = true;
                }
            }
        }

        /// <summary>
        /// PIS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbPis_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkGerarPisST.Checked = false;

            if (!string.IsNullOrEmpty(cbbPis.Text))
            {
                if (cbbPis.Text.Substring(0, 2).Equals("05"))
                    chkGerarPisST.Checked = true;
            }
        }

        /// <summary>
        /// COFINS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbbCofins_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkGerarCofinsST.Checked = false;

            if (!string.IsNullOrEmpty(cbbCofins.Text))
            {
                if (cbbCofins.Text.Substring(0, 2).Equals("05"))
                    chkGerarCofinsST.Checked = true;
            }
        }
    }
}
