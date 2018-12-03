using PDV.AcessoBancoDados;
using PDV.Apresentacao.Utils;
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

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmFuncionarios : Form
    {
        public FrmFuncionarios()
        {
            InitializeComponent();
        }

        #region Instâncias

        readonly FuncionariosNegocios funcionariosNegocios = new FuncionariosNegocios();
        readonly CidadesNegocios cidadesNegocios = new CidadesNegocios();
        readonly Conexao conexao = new Conexao();
        readonly Cryptografia cryptografia = new Cryptografia();

        #endregion

        #region Variáveis

        int funcionarioId = 0;
        int cidadeId = 0;
        string salarioAtual = string.Empty;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private void CarregarMeses()
        {
            foreach (string item in Enum.GetNames(typeof(enumMeses)))
            {
                cbbFerias.Items.Add(item.ToString().Replace('_', ' '));
                cbbDecimoTerceiroSalario.Items.Add(item.ToString().Replace('_', ' '));
            }
            cbbFerias.SelectedIndex = 0;
            cbbDecimoTerceiroSalario.SelectedIndex = 0;
        }

        private void HabilitarCampos(bool ativo)
        {
            TabPage tab = this.tabControl.TabPages[0];

            foreach (Control obj in tab.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Enabled = ativo;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).Enabled = ativo;
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Enabled = ativo;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Enabled = ativo;
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Enabled = ativo;
                }
                if (obj is Button)
                {
                    ((Button)obj).Enabled = ativo;
                }
            }

            TabPage tab2 = this.tabControl.TabPages[2];

            foreach (Control obj in tab2.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Enabled = ativo;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).Enabled = ativo;
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Enabled = ativo;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Enabled = ativo;
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Enabled = ativo;
                }
                if (obj is Button)
                {
                    ((Button)obj).Enabled = ativo;
                }
            }

            btnPesquisarCidade.Enabled = ativo;
            txtNome.Focus();
        }

        private void Limpar()
        {
            TabPage tab = this.tabControl.TabPages[0];

            foreach (Control obj in tab.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Clear();
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Value = DateTime.Now;
                }
                if (obj is ComboBox)
                {
                    ((ComboBox)obj).SelectedIndex = 0;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Clear();
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Checked = true;
                }
            }

            TabPage tab2 = this.tabControl.TabPages[2];

            foreach (Control obj in tab2.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Clear();
                }
                if (obj is DateTimePicker)
                {
                    ((DateTimePicker)obj).Value = DateTime.Now;
                }
                if (obj is MaskedTextBox)
                {
                    ((MaskedTextBox)obj).Clear();
                }
                if (obj is CheckBox)
                {
                    ((CheckBox)obj).Checked = true;
                }
            }

            funcionarioId = 0;
            txtCidade.Text = "SELECIONE A CIDADE";
            chkAtivo.Checked = chkVendedor.Checked = chkRepresentada.Checked = false;
            dtpDataAdmissao.Text = dtpDataExpedicaoRG.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dtpDataDemissao.Clear();
            salarioAtual = string.Empty;
        }


        private bool ValidaCampos()
        {
            string erro = string.Empty;

            if (string.IsNullOrEmpty(txtNome.Text))
            {
                erro += "\nNome.";
            }
            if (string.IsNullOrEmpty(txtCpf.Text))
            {
                erro += "\nCPF.";
            }
            if (string.IsNullOrEmpty(txtTelefone.Text.TrimStart().TrimEnd().Replace("-", "").Replace(".", "")))
            {
                erro += "\nTelefone.";
            }
            if (txtCep.Text.Length < 9)
            {
                erro += "\nCEP.";
            }
            if (string.IsNullOrEmpty(txtEndereco.Text))
            {
                erro += "\nEndereço.";
            }
            if (string.IsNullOrEmpty(txtNumero.Text))
            {
                erro += "\nNúmero.";
            }
            if (string.IsNullOrEmpty(txtBairro.Text))
            {
                erro += "\nBairro.";
            }
            if (txtNumero.Text == "SELECIONE A CIDADE")
            {
                erro += "\nCidade.";
            }
            if (erro != "")
            {
                MessageBox.Show("Os seguintes campos não foram informados : \n\n" + erro, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }


        private void CarregarGridFuncionarios()
        {
            try
            {
                dtGrid = funcionariosNegocios.CarregarGridFuncionarios(string.Empty);
                grid.DataSource = dtGrid;

                funcionarioId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os funcionários cadastrados.\n\n" + ex, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Telefones

        private void MascararTelefone(MaskedTextBox t)
        {
            int tama = t.Text.Length;
            t.Mask = t.Text.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Length == 11 ? "(99)99999-9999" : "(99)9999-9999";
        }

        private void DesmascararTelefone(MaskedTextBox t)
        {
            t.Mask = "99999999999";
        }

        #endregion

        private void CarregarFuncionario(int _funcionarioId)
        {
            try
            {
                //if (grupoUsuarioPermissoes.Visualizar)
                //{
                DataTable dtFuncionario = funcionariosNegocios.PesquisarPorCodigo(_funcionarioId);

                funcionarioId = Convert.ToInt32(dtFuncionario.Rows[0]["FuncionarioId"].ToString());

                txtNome.Text = dtFuncionario.Rows[0]["Nome"].ToString();
                chkAtivo.Checked = Convert.ToBoolean(dtFuncionario.Rows[0]["Ativo"].ToString());
                if (Convert.ToInt32(dtFuncionario.Rows[0]["Sexo"]) == 0)
                    cbbSexo.Text = "Masculino";
                else
                    cbbSexo.Text = "Feminino";
                dtpDataAdmissao.Text = !string.IsNullOrEmpty(dtFuncionario.Rows[0]["Admissao"].ToString()) ? Convert.ToDateTime(dtFuncionario.Rows[0]["Admissao"].ToString()).ToString("dd/MM/yyyy") : string.Empty;
                txtCpf.Text = dtFuncionario.Rows[0]["Cpf"].ToString();
                txtRg.Text = dtFuncionario.Rows[0]["Rg"].ToString();
                txtCargo.Text = dtFuncionario.Rows[0]["Cargo"].ToString();

                txtTelefone.Clear(); txtTelefone.Refresh();
                txtTelefone.Mask = "99999999999";
                txtTelefone.Text = dtFuncionario.Rows[0]["Telefone"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                MascararTelefone(txtTelefone);

                txtCelular.Clear(); txtCelular.Refresh();
                txtCelular.Mask = "99999999999";
                txtCelular.Text = dtFuncionario.Rows[0]["Celular"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
                MascararTelefone(txtCelular);

                txtCep.Text = dtFuncionario.Rows[0]["Cep"].ToString();
                txtEndereco.Text = dtFuncionario.Rows[0]["Endereco"].ToString();
                txtNumero.Text = dtFuncionario.Rows[0]["Numero"].ToString();
                txtBairro.Text = dtFuncionario.Rows[0]["Bairro"].ToString();

                if (!string.IsNullOrEmpty(dtFuncionario.Rows[0]["CidadeId"].ToString()))
                {
                    cidadeId = (int)(dtFuncionario.Rows[0]["CidadeId"]);

                    DataTable dtaCidade = new DataTable();
                    dtaCidade = cidadesNegocios.PesquisarPorCodigo(cidadeId);

                    if (dtaCidade.Rows.Count > 0)
                    {
                        txtCidade.Text = dtaCidade.Rows[0]["Nome"].ToString() + "-" + dtaCidade.Rows[0]["UF"].ToString();
                    }
                    else
                        txtCidade.Clear();
                }
                else
                {
                    cidadeId = 0;
                    txtCidade.Clear();
                }

                chkVendedor.Checked = Convert.ToBoolean(dtFuncionario.Rows[0]["Vendedor"].ToString());
                chkRepresentada.Checked = Convert.ToBoolean(dtFuncionario.Rows[0]["Representante"].ToString());
                txtEmail.Text = dtFuncionario.Rows[0]["Email"].ToString();
                txtUsuarioLogin.Text = dtFuncionario.Rows[0]["Usuario"].ToString();
                txtSenhaLogin.Text = cryptografia.Crypto(dtFuncionario.Rows[0]["Senha"].ToString(), false);
                txtObservacao.Text = dtFuncionario.Rows[0]["Observacao"].ToString();
                txtSalario.Text = Convert.ToDecimal(dtFuncionario.Rows[0]["Salario"].ToString()).ToString("N2");


                txtTituloEleitoral.Text = dtFuncionario.Rows[0]["TituloEleitoral"].ToString();
                txtCTPS.Text = dtFuncionario.Rows[0]["CTPS"].ToString();
                txtPIS.Text = dtFuncionario.Rows[0]["Pis"].ToString();
                dtpDataExpedicaoRG.Text = !string.IsNullOrEmpty(dtFuncionario.Rows[0]["DataExpedicaoRg"].ToString()) ? Convert.ToDateTime(dtFuncionario.Rows[0]["DataExpedicaoRg"].ToString()).ToString("dd/MM/yyyy") : string.Empty;
                cbbFerias.SelectedValue = !string.IsNullOrEmpty(dtFuncionario.Rows[0]["Ferias"].ToString()) ? Convert.ToInt32(dtFuncionario.Rows[0]["Ferias"]) : cbbFerias.SelectedIndex = 0;
                cbbDecimoTerceiroSalario.SelectedValue = !string.IsNullOrEmpty(dtFuncionario.Rows[0]["DecimoTerceiroSalario"].ToString()) ? Convert.ToInt32(dtFuncionario.Rows[0]["DecimoTerceiroSalario"]) : cbbDecimoTerceiroSalario.SelectedIndex = 0;
                dtpDataDemissao.Text = !string.IsNullOrEmpty(dtFuncionario.Rows[0]["Demissao"].ToString()) ? Convert.ToDateTime(dtFuncionario.Rows[0]["Demissao"].ToString()).ToString("dd/MM/yyyy") : string.Empty;
                txtCBO.Text = dtFuncionario.Rows[0]["CBO"].ToString();
                txtEncarregado.Text = dtFuncionario.Rows[0]["Encarregado"].ToString();

                txtPesquisar.Clear();
                tabControl.SelectedIndex = 0;

                HabilitarCampos(true);

                btnSalvar.Enabled = true;
                btnExcluir.Enabled = true;
                btnNovo.Text = "Cancelar [ F2 ]";
                btnSalvar.Text = "Alterar [ F5 ]";

                toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                //}
                //    else
                //    {
                //    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar o Funcionário selecionado!\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        private void FrmFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarMeses();
            CarregarGridFuncionarios();
            cbbSexo.SelectedIndex = -1;
            cbbFerias.SelectedIndex = -1;
            cbbDecimoTerceiroSalario.SelectedIndex = -1;

            tabControl.SelectedIndex = 1;
            txtPesquisar.Select();
            txtPesquisar.Focus();
        }

        private void FrmFuncionarios_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.Alt && e.KeyCode == Keys.F4)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnNovo_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5 && btnSalvar.Enabled)
            {
                btnSalvar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8 && btnExcluir.Enabled)
            {
                btnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnPesquisar_Click(sender, e);
            }
        }


        #region Botoes menu

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 0)
            {
                tabControl.SelectedIndex = 0;
            }
            if (btnSalvar.Enabled == false)
            {
                HabilitarCampos(true);
                Limpar();
                btnNovo.Text = "Cancelar [ F2 ]";
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                btnSalvar.Enabled = true;
            }
            else
            {
                HabilitarCampos(false);
                btnNovo.Text = "Novo [ F2 ]";
                btnSalvar.Text = "Salvar [ F5 ]";
                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Funcionário [ F2 ]");
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
            }
            funcionarioId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    Funcionarios funcionarios = new Funcionarios();

                    funcionarios.Nome = txtNome.Text.Trim();
                    funcionarios.Admissao = Convert.ToDateTime(dtpDataAdmissao.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    funcionarios.Ativo = chkAtivo.Checked;
                    funcionarios.Cpf = txtCpf.Text.Trim();
                    funcionarios.Rg = txtRg.Text.Trim();
                    funcionarios.Cargo = txtCargo.Text.Trim();
                    funcionarios.Salario = Convert.ToDecimal(txtSalario.Text);
                    funcionarios.Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                    funcionarios.Celular = txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                    funcionarios.Email = txtEmail.Text.Trim();
                    funcionarios.DataCadastro = DateTime.Now;
                    funcionarios.Cep = txtCep.Text.Trim();
                    funcionarios.Endereco = txtEndereco.Text.Trim();
                    funcionarios.Numero = txtNumero.Text.Trim();
                    funcionarios.Bairro = txtBairro.Text.Trim();

                    if (cidadeId > 0)
                        funcionarios.CidadeId = cidadeId;

                    funcionarios.Vendedor = chkVendedor.Checked;
                    funcionarios.Representante = chkRepresentada.Checked;
                    funcionarios.Usuario = txtUsuarioLogin.Text.Trim();
                    funcionarios.Senha = cryptografia.Crypto(txtSenhaLogin.Text, true);
                    funcionarios.Observacao = txtObservacao.Text.Trim();

                    funcionarios.TituloEleitoral = txtTituloEleitoral.Text.Trim();
                    funcionarios.CTPS = txtCTPS.Text.Trim();
                    funcionarios.Pis = txtPIS.Text.Trim();

                    if (txtTituloEleitoral.Text == "" && txtCTPS.Text == "" && txtPIS.Text == "")
                        funcionarios.DataExpedicaoRg = Convert.ToDateTime(dtpDataExpedicaoRG.Value.ToString("dd/MM/yyyy"));

                    if (!string.IsNullOrEmpty(cbbFerias.Text))
                        funcionarios.Ferias = Convert.ToInt32((enumMeses)Enum.Parse(typeof(enumMeses), cbbFerias.Text.Replace(" ", "_")));
                    if (!string.IsNullOrEmpty(cbbDecimoTerceiroSalario.Text))
                        funcionarios.DecimoTerceiroSalario = Convert.ToInt32((enumMeses)Enum.Parse(typeof(enumMeses), cbbDecimoTerceiroSalario.Text.Replace(" ", "_")));

                    conexao.Executar(string.Format("UPDATE Funcionarios SET Demissao = NULL WHERE FuncionarioId = {0}", funcionarioId));
                    if (dtpDataDemissao.Text.Length != 6)
                        funcionarios.Demissao = Convert.ToDateTime(dtpDataDemissao.Text);
                    else
                        funcionarios.Demissao = Convert.ToDateTime(null);

                    funcionarios.CBO = txtCBO.Text.Trim();
                    funcionarios.Encarregado = txtEncarregado.Text.Trim();

                    //INSERIR
                    if (funcionarioId <= 0)
                    {
                        //if (grupoUsuarioPermissoes.Inserir)
                        //{
                        try
                        {
                            if (funcionariosNegocios.Inserir(funcionarios))
                            {

                                int ultimoID = conexao.RetornarUltimoId("Funcionarios", "FuncionarioId");
                                //Gravar todas as outras abas


                                MessageBox.Show("Funcionário cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpar();
                                HabilitarCampos(false);
                                btnSalvar.Text = "Salvar [ F5 ]";
                                btnSalvar.Enabled = false;
                                btnExcluir.Enabled = false;
                                btnNovo.Text = "Novo [ F2 ]";
                                CarregarGridFuncionarios();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao tentar cadastrar o Funcionário!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar cadastrar o Funcionário!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                    }
                    else //ALTERAR
                    {
                        //if (grupoUsuarioPermissoes.Alterar)
                        //{
                        try
                        {
                            funcionarios.FuncionarioId = funcionarioId;

                            if (!salarioAtual.Equals(txtSalario.Text))
                            {
                                AlterarSalarioFuncionario alterarSalarioFuncionario = new AlterarSalarioFuncionario()
                                {
                                    FuncionarioId = funcionarioId,
                                    DataHora = DateTime.Now,
                                    Valor = funcionarios.Salario
                                };

                                AlterarSalarioFuncionarioNegocios alteracaoSalariosNegocios = new AlterarSalarioFuncionarioNegocios();
                                alteracaoSalariosNegocios.Inserir(alterarSalarioFuncionario);
                            }

                            if (funcionariosNegocios.Alterar(funcionarios))
                            {
                                MessageBox.Show("Funcionário alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Limpar();
                                HabilitarCampos(false);
                                btnSalvar.Text = "Salvar [ F5 ]";
                                btnSalvar.Enabled = false;
                                btnExcluir.Enabled = false;
                                btnNovo.Text = "Novo [ F2 ]";
                                CarregarGridFuncionarios();
                            }
                            else
                            {
                                MessageBox.Show("Erro ao tentar atualizar os dados do Funcionário selecionado!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao executar operação solicitada!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        //}
                    }

                    toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");
                    funcionarioId = 0;
                    tabControl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o Funcionário!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            //if (grupoUsuarioPermissoes.Excluir)
            //{
            Funcionarios funcionarios = new Funcionarios();
            funcionarios.FuncionarioId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FuncionarioId_"].Value);

            try
            {
                if (MessageBox.Show("Deseja realmente excluir esse Funcionário?", "Pergunta do Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AlterarSalarioFuncionarioNegocios alterarSalarioFuncionarioNegocios = new AlterarSalarioFuncionarioNegocios();
                    alterarSalarioFuncionarioNegocios.Excluir(new AlterarSalarioFuncionario(funcionarioId));

                    if (funcionariosNegocios.Excluir(funcionarios))
                    {
                        MessageBox.Show("Funcionário excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitarCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGridFuncionarios();
                        funcionarioId = 0;
                    }
                }
                else
                {
                    Limpar();
                    HabilitarCampos(false);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar excluir o Funcionário!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //}
            //else
            //{
            //    MessageBox.Show("Você não tem permissão para executar esta ação, entre em contato com o administrador!", "Informação do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    btnSalvar.Enabled = false;
            //}
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 1)
            {
                tabControl.SelectedIndex = 1;
                txtPesquisar.Focus();
            }
        }


        #endregion

        #region Tratamento Cpf

        private void txtCpf_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtCpf.Text.Length == 14)
                {
                    string cpftemp = txtCpf.Text;

                    txtCpf.Clear();

                    txtCpf.Text = cpftemp.Substring(0, 3);
                    txtCpf.Text += cpftemp.Substring(4, 3);
                    txtCpf.Text += cpftemp.Substring(8, 3);
                    txtCpf.Text += cpftemp.Substring(12, 2);
                }
            }
            catch
            { }
        }

        private void txtCpf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtCpf_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCpf.Text.Length == 11)
                {
                    if (Util.ValidaCPF(txtCpf.Text))
                    {
                        string cpftemp = txtCpf.Text;
                        txtCpf.Clear();

                        txtCpf.Text = cpftemp.Substring(0, 3);
                        txtCpf.Text += "." + cpftemp.Substring(3, 3);
                        txtCpf.Text += "." + cpftemp.Substring(6, 3);
                        txtCpf.Text += "-" + cpftemp.Substring(9, 2);
                    }
                    else
                    {
                        MessageBox.Show("CPF Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpf.Clear();
                        txtCpf.Focus();
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region Tratamento Telefones

        private void txtTelefone_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtTelefone);
        }

        private void txtTelefone_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtTelefone);
        }

        private void txtCelular_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtCelular);
        }

        private void txtCelular_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtCelular);
        }


        #endregion

        #region Tab Grid

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(FuncionarioId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Nome like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Cargo like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";

            grid.DataSource = dv;
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                try
                {
                    CarregarFuncionario(Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FuncionarioId_"].Value));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar o funcionário!\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void btnPesquisarCidade_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCidades frmCidades = new FrmCidades();
                frmCidades.ShowInTaskbar = false;
                frmCidades.ShowDialog();

                if (frmCidades._CidadeId > 0)
                {
                    cidadeId = frmCidades._CidadeId;
                    txtCidade.Text = frmCidades._Cidade + " - " + frmCidades._UF; ;
                }
                else
                {
                    cidadeId = 0;
                    txtCidade.Text = "SELECIONE A CIDADE";
                }

                chkVendedor.Focus();
            }
            catch
            { }
        }


    }
}
