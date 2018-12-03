using PDV.AcessoBancoDados;
using PDV.Apresentacao.Emails;
using PDV.Apresentacao.Utils;
using PDV.Componentes;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmCliente : Form
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        #region Instâncias

        Conexao conexao = new Conexao();
        ClientesNegocios clientesNegocios = new ClientesNegocios();
        CidadesNegocios cidadesNegocios = new CidadesNegocios();
        Permissoes permissoes = new Permissoes();

        #endregion

        #region Propriedades

        #endregion

        #region Variáveis

        int clientesId = 0;
        int cidadeId = 0;
        DataTable dtGrid = new DataTable();
        private Image imagemCliente;

        #endregion

        #region Métodos

        private void CarregarCliente(int parametroClienteId)
        {
            DataTable dtCliente = clientesNegocios.PesquisarPorCodigo(parametroClienteId);

            clientesId = Convert.ToInt32(dtCliente.Rows[0]["ClientesId"].ToString());
            txtNome.Text = dtCliente.Rows[0]["Nome"].ToString();
            chkAtivo.Checked = Convert.ToBoolean(dtCliente.Rows[0]["Ativo"].ToString());

            if (Convert.ToInt32(dtCliente.Rows[0]["Sexo"]) == 0)
                cbbSexo.Text = "Masculino";
            else
                cbbSexo.Text = "Feminino";

            cbbEstadoCivil.Text = ((enumEstadoCivil)Enum.Parse(typeof(enumEstadoCivil), dtCliente.Rows[0]["EstadoCivil"].ToString())).ToString().Replace("_", " ");
            txtApelido.Text = dtCliente.Rows[0]["ApelidoFantasia"].ToString();
            txtNacionalidade.Text = dtCliente.Rows[0]["Nacionalidade"].ToString();
            txtNaturalidade.Text = dtCliente.Rows[0]["Naturalidade"].ToString();

            if (dtCliente.Rows[0]["Tipo"].ToString() == "F")
                cbbTipoPessoa.Text = "Física";
            else
                cbbTipoPessoa.Text = "Jurídica";

            if (!string.IsNullOrEmpty(dtCliente.Rows[0]["CpfCnpj"].ToString()))
            {
                if (dtCliente.Rows[0]["CpfCnpj"].ToString().Length == 14)
                    cbbTipoPessoa.Text = "Física";
                else
                    cbbTipoPessoa.Text = "Jurídica";
            }

            txtCpfCnpj.Text = dtCliente.Rows[0]["CpfCnpj"].ToString();
            txtRgIE.Text = dtCliente.Rows[0]["RgIE"].ToString();
            dtpNascimento.Text = !string.IsNullOrEmpty(dtCliente.Rows[0]["Nascimento"].ToString()) ? Convert.ToDateTime(dtCliente.Rows[0]["Nascimento"].ToString()).ToString("dd/MM/yyyy") : string.Empty;
            dtpDataCadastro.Text = dtCliente.Rows[0]["DataCadastro"].ToString();
            txtCep.Text = dtCliente.Rows[0]["CEP"].ToString();
            txtEndereco.Text = dtCliente.Rows[0]["Endereco"].ToString();
            txtNumero.Text = dtCliente.Rows[0]["Numero"].ToString();
            txtComplemento.Text = dtCliente.Rows[0]["Complemento"].ToString();

            if (!string.IsNullOrEmpty(dtCliente.Rows[0]["CidadeId"].ToString()))
            {
                cidadeId = (int)(dtCliente.Rows[0]["CidadeId"]);

                DataTable dtaCidade = new DataTable();
                dtaCidade = cidadesNegocios.PesquisarPorCodigo(cidadeId);

                if (dtaCidade.Rows.Count > 0)
                    txtCidade.Text = dtaCidade.Rows[0]["Nome"].ToString() + "-" + dtaCidade.Rows[0]["UF"].ToString();
                else
                    txtCidade.Clear();
            }
            else
            {
                cidadeId = 0;
                txtCidade.Clear();
            }

            txtBairro.Text = dtCliente.Rows[0]["Bairro"].ToString();

            txtTelefone.Clear(); txtTelefone.Refresh();
            txtTelefone.Mask = "99999999999";
            txtTelefone.Text = dtCliente.Rows[0]["Telefone"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
            MascararTelefone(txtTelefone);

            txtCelular.Clear(); txtCelular.Refresh();
            txtCelular.Mask = "99999999999";
            txtCelular.Text = dtCliente.Rows[0]["Celular"].ToString().Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Trim();
            MascararTelefone(txtCelular);

            txtEmail.Text = dtCliente.Rows[0]["Email"].ToString();
            txtLimiteCredito.Text = Convert.ToDecimal(dtCliente.Rows[0]["LimiteCredito"]).ToString("N2");
            txtObservacao.Text = dtCliente.Rows[0]["Observacao"].ToString();

            if (clientesId > 0)
            {
                if (!string.IsNullOrEmpty(dtCliente.Rows[0]["imagemCliente"].ToString()))
                {
                    try
                    {
                        byte[] data = (Byte[])dtCliente.Rows[0]["imagemCliente"];
                        MemoryStream ms = new MemoryStream(data);
                        pcImagemCliente.Image = Bitmap.FromStream(ms);
                    }
                    catch { }
                }
                else
                    pcImagemCliente.Image = null;
            }


            HabilitarCampos(true);
            btnSalvar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Text = "Cancelar [ F2 ]";
            btnSalvar.Text = "Alterar [ F5 ]";
            toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
            toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
            tabControl.SelectedIndex = 0;
            txtNome.Focus();
        }

        #region Eventos - Telefones

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

        private void GravarImagemCliente(int clientesId)
        {
            if (pcImagemCliente.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pcImagemCliente.Image.Save(ms, ImageFormat.Jpeg);
                byte[] dados = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(dados, 0, dados.Length);
                SqlConnection connection = conexao.conn;
                string query = "UPDATE Clientes SET ImagemCliente = @MyImagem WHERE ClientesId = " + clientesId.ToString();
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("@MyImagem", (object)dados));
                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            else
            {
                conexao.Executar("UPDATE Clientes SET ImagemCliente = NULL WHERE ClientesId = " + clientesId.ToString());
            }
        }

        private void Limpar()
        {
            foreach (Control obj in from TabPage tab in this.tabControl.TabPages from Control obj in tab.Controls select obj)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Clear();
                }
                if (obj is DecimalTextbox2)
                {
                    ((DecimalTextbox2)obj).Clear();
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

            clientesId = 0;

            txtCidade.Text = "SELECIONE A CIDADE";
            chkAtivo.Checked = true;
            dtpDataCadastro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtLimiteCredito.Text = "0,00";

            cbbSexo.SelectedIndex = cbbEstadoCivil.SelectedIndex = -1;
            pcImagemCliente.Image = null;
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
                if (obj is DecimalTextbox2)
                {
                    ((DecimalTextbox2)obj).Enabled = ativo;
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

            dtpDataCadastro.Enabled = false;
            btnPesquisarCidade.Enabled = btnPesquisarImgProduto.Enabled = btnRemoverImgProduto.Enabled = btnExportarImgProduto.Enabled = ativo;
            txtNome.Focus();
        }


        private void PermissoesSistema()
        {
            try
            {
                //permissoesSistema = permissoesSistemaNegocios.PesquisarPorGrupoUsuario_e_Formulario(FrmLogin.GrupoUsuariosId, 7);
                //permissoesSistemaBloquearCliente = permissoesSistemaNegocios.PesquisarPorGrupoUsuario_e_Formulario(FrmLogin.GrupoUsuariosId, 16);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar as permissões do Usuário.\n\n" + ex.ToString(), "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarEstadoCivil()
        {
            foreach (string item in Enum.GetNames(typeof(enumEstadoCivil)))
            {
                cbbEstadoCivil.Items.Add(item.ToString().Replace('_', ' '));
            }

            cbbEstadoCivil.SelectedIndex = -1;
        }

        private void CarregarGrid()
        {
            try
            {
                dtGrid = clientesNegocios.CarregarGrid();
                grid.DataSource = dtGrid;

                clientesId = 0;
                lblQuantidadeClientes.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os clientes cadastrados.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            PermissoesSistema();
            CarregarEstadoCivil();
            CarregarGrid();

            tabControl.SelectedIndex = 1;
            txtPesquisar.Select();
            txtPesquisar.Focus();
        }

        private void FrmCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
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
            else if (e.KeyCode == Keys.F12)
            {
                btnEmail_Click(sender, e);
            }
        }

        #region Botões - Menu

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
                toolTip.SetToolTip(this.btnNovo, "Novo Cliente [ F2 ]");
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Verificações

                if (!string.IsNullOrEmpty(txtCpfCnpj.Text))
                {
                    if (clientesId.Equals(0))
                    {
                        if (clientesNegocios.PesquisarCPFouCNPJCadastrado(txtCpfCnpj.Text))
                        {
                            MessageBox.Show(string.Format("Já existe um cadastro para este {0}!", cbbTipoPessoa.Text.Equals("Física") ? "CPF" : "CNPJ"), "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        if (clientesNegocios.VerificaCPFouCNPJ(clientesId) != txtCpfCnpj.Text)
                        {
                            if (clientesNegocios.PesquisarCPFouCNPJCadastrado(txtCpfCnpj.Text))
                            {
                                MessageBox.Show(string.Format("Já existe um cadastro para este {0}!", cbbTipoPessoa.Text.Equals("Física") ? "CPF" : "CNPJ"), "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                }

                if (cbbTipoPessoa.Text.Equals("Física"))
                {
                    if (txtCpfCnpj.Text.Length != 14)
                    {
                        MessageBox.Show("Cliente sem CPF, não é possivel efetuar o cadastro!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Focus();
                        return;
                    }

                }
                else
                {
                    if (txtCpfCnpj.Text.Length != 18)
                    {
                        MessageBox.Show("Cliente sem CNPJ, não é possivel efetuar o cadastro!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Focus();
                        return;
                    }
                }

                if (dtpNascimento.Text.TrimStart().TrimEnd().Replace(" ", "").Length != 2 && dtpNascimento.Text.TrimStart().TrimEnd().Replace(" ", "").Length != 10)
                {
                    MessageBox.Show("Data de nascimento inválida!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpNascimento.Focus();
                    return;
                }

                if (dtpNascimento.Text.TrimStart().TrimEnd().Replace(" ", "").Length == 10)
                {
                    try
                    {
                        Convert.ToDateTime(dtpNascimento.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Data de nascimento inválida!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dtpNascimento.Focus();
                        return;
                    }
                }

                #endregion

                ObjetoTransferencia.Clientes clientes = new ObjetoTransferencia.Clientes();

                clientes.Nome = txtNome.Text.Trim();
                clientes.Ativo = chkAtivo.Checked;
                if (Convert.ToInt32(cbbSexo.SelectedValue) > 0)
                    clientes.Sexo = Convert.ToInt32(cbbSexo.SelectedValue);
                clientes.EstadoCivil = Convert.ToInt32((enumEstadoCivil)Enum.Parse(typeof(enumEstadoCivil), cbbEstadoCivil.Text.Replace(" ", "_")));
                clientes.ApelidoFantasia = txtApelido.Text.Trim();
                clientes.Nacionalidade = txtNacionalidade.Text.Trim();
                clientes.Naturalidade = txtNaturalidade.Text.Trim();
                if (cbbTipoPessoa.Text == "Física")
                    clientes.Tipo = "F";
                else
                    clientes.Tipo = "J";
                clientes.CpfCnpj = txtCpfCnpj.Text.Trim();
                clientes.RgIE = txtRgIE.Text.Trim();
                if (dtpNascimento.Text.Length == 10)
                    clientes.Nascimento = Convert.ToDateTime(dtpNascimento.Text);
                else
                {
                    conexao.Executar(string.Format("UPDATE Clientes SET Nascimento = NULL WHERE ClientesId = {0}", clientesId.ToString()));
                    clientes.Nascimento = Convert.ToDateTime(null);
                }
                clientes.DataCadastro = Convert.ToDateTime(dtpDataCadastro.Value.ToString("dd/MM/yyyy"));
                clientes.Cep = txtCep.Text.Trim();
                clientes.Endereco = txtEndereco.Text.Trim();
                clientes.Numero = txtNumero.Text.Trim();
                clientes.Complemento = txtComplemento.Text.Trim();
                if (cidadeId > 0)
                    clientes.CidadeId = cidadeId;
                clientes.Bairro = txtBairro.Text.Trim();
                clientes.Telefone = txtTelefone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                clientes.Celular = txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", " ");
                clientes.Email = txtEmail.Text.Trim();
                clientes.LimiteCredito = !string.IsNullOrEmpty(txtLimiteCredito.Text) ? Convert.ToDecimal(txtLimiteCredito.Text) : 0;
                clientes.Observacao = txtObservacao.Text.Trim();

                //INSERIR
                if (clientesId <= 0)
                {
                    try
                    {
                        if (clientesNegocios.Inserir(clientes))
                        {
                            GravarImagemCliente(clientesId);

                            MessageBox.Show("Cliente cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            HabilitarCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            tabControl.SelectedIndex = 0;
                            CarregarGrid();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao tentar cadastrar o cliente!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar cadastrar o cliente!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else //ALTERAR
                {
                    try
                    {
                        clientes.ClientesId = clientesId;

                        if (clientesNegocios.Alterar(clientes))
                        {
                            GravarImagemCliente(clientesId);

                            MessageBox.Show("Cliente alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Limpar();
                            HabilitarCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            tabControl.SelectedIndex = 0;
                            CarregarGrid();
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao tentar alterar o cliente!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Cadastro [ F2 ]");

                clientesId = 0;
                tabControl.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o cliente!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                ObjetoTransferencia.Clientes clientes = new ObjetoTransferencia.Clientes();
                clientes.ClientesId = clientesId;

                if (MessageBox.Show("Deseja realmente excluir esse cliente?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (clientesNegocios.Excluir(clientes))
                    {
                        //InserirLogs("Cliente excluido: " + txtNome.Text, 0, 3);
                        MessageBox.Show("Cliente excluído com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpar();
                        HabilitarCampos(false);
                        btnSalvar.Text = "Salvar [ F5 ]";
                        btnSalvar.Enabled = false;
                        btnExcluir.Enabled = false;
                        btnNovo.Text = "Novo [ F2 ]";
                        CarregarGrid();
                        clientesId = 0;
                        tabControl.SelectedIndex = 1;
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
                MessageBox.Show("Erro ao tentar excluir o cliente!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 1)
            {
                tabControl.SelectedIndex = 1;
                txtPesquisar.Clear();
                txtPesquisar.Focus();
            }
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            bool aberto = false;

            foreach (Form form in Application.OpenForms)
            {
                if (form is FrmEnviarEmail)
                {
                    form.Focus();
                    aberto = true;
                }
            }

            if (!aberto)
            {
                FrmEnviarEmail frmEnviarEmail = new FrmEnviarEmail();
                frmEnviarEmail.ShowInTaskbar = false;
                frmEnviarEmail._Email = txtEmail.Text;
                frmEnviarEmail.ShowDialog();
            }
        }

        #endregion

        private void cbbTipoPessoa_SelectedValueChanged(object sender, EventArgs e)
        {
            txtCpfCnpj.Clear();

            if (cbbTipoPessoa.Text == "Física")
                lblDescTipoPessoa.Text = "CPF";
            else
                lblDescTipoPessoa.Text = "CNPJ";
        }

        #region Eventos - Cpf / Cnpj

        private void txtCpfCnpj_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtCpfCnpj.Text.Length == 14)
                {
                    string cpftemp = txtCpfCnpj.Text;

                    txtCpfCnpj.Clear();

                    txtCpfCnpj.Text = cpftemp.Substring(0, 3);
                    txtCpfCnpj.Text += cpftemp.Substring(4, 3);
                    txtCpfCnpj.Text += cpftemp.Substring(8, 3);
                    txtCpfCnpj.Text += cpftemp.Substring(12, 2);
                }
                else
                {
                    if (txtCpfCnpj.Text.Length == 18)
                    {
                        string cnpjtemp = txtCpfCnpj.Text;

                        txtCpfCnpj.Clear();

                        txtCpfCnpj.Text = cnpjtemp.Substring(0, 2);
                        txtCpfCnpj.Text += cnpjtemp.Substring(3, 3);
                        txtCpfCnpj.Text += cnpjtemp.Substring(7, 3);
                        txtCpfCnpj.Text += cnpjtemp.Substring(11, 4);
                        txtCpfCnpj.Text += cnpjtemp.Substring(16, 2);
                    }
                }
            }
            catch
            { }
        }

        private void txtCpfCnpj_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtCpfCnpj_Leave(object sender, EventArgs e)
        {
            try
            {
                if (txtCpfCnpj.Text.Length == 11)
                {
                    if (Util.ValidaCPF(txtCpfCnpj.Text))
                    {
                        string cpftemp = txtCpfCnpj.Text;
                        txtCpfCnpj.Clear();

                        txtCpfCnpj.Text = cpftemp.Substring(0, 3);
                        txtCpfCnpj.Text += "." + cpftemp.Substring(3, 3);
                        txtCpfCnpj.Text += "." + cpftemp.Substring(6, 3);
                        txtCpfCnpj.Text += "-" + cpftemp.Substring(9, 2);
                    }
                    else
                    {
                        MessageBox.Show("CPF Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfCnpj.Clear();
                        txtCpfCnpj.Focus();
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCpfCnpj.Text))
                    {
                        if (Util.ValidaCNPJ(txtCpfCnpj.Text))
                        {
                            string cnpjtemp = txtCpfCnpj.Text;
                            txtCpfCnpj.Clear();

                            txtCpfCnpj.Text = cnpjtemp.Substring(0, 2);
                            txtCpfCnpj.Text += "." + cnpjtemp.Substring(2, 3);
                            txtCpfCnpj.Text += "." + cnpjtemp.Substring(5, 3);
                            txtCpfCnpj.Text += "/" + cnpjtemp.Substring(8, 4);
                            txtCpfCnpj.Text += "-" + cnpjtemp.Substring(12, 2);
                        }
                        else
                        {
                            MessageBox.Show("CNPJ Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtCpfCnpj.Clear();
                            txtCpfCnpj.Focus();
                        }
                    }
                }
            }
            catch
            { }
        }

        #endregion

        #region Eventos - Telefones

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

        #region Eventos - Tab Grid

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(ClientesId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Nome like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (ApelidoFantasia like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (CpfCnpj like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Telefone like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Celular like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Cidade like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;
            lblQuantidadeClientes.Text = grid.Rows.Count + " Resultados encontrado(s)";
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && grid.Rows.Count > 0)
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
                    CarregarCliente(Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["ClientesId_"].Value));
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar carregar o cliente selecionado!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
            }
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        #endregion

        #region Imagem do Cliente

        private void btnPesquisarImgProduto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "C:";
            openFileDialog.Title = "Procurando imagem";
            openFileDialog.Filter = "Imagens (*.jpg)|*.jpg|Imagens (*.jpeg)|*.jpeg";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                pcImagemCliente.Image = Image.FromFile(openFileDialog.FileName);
                pcImagemCliente.SizeMode = PictureBoxSizeMode.Zoom;
                imagemCliente = pcImagemCliente.Image.Clone() as Image;
            }
        }

        private void btnRemoverImgProduto_Click(object sender, EventArgs e)
        {
            pcImagemCliente.Image = null;
        }

        private void btnExportarImgProduto_Click(object sender, EventArgs e)
        {
            if (pcImagemCliente.Image != null)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.InitialDirectory = "Desktop";
                saveFileDialog.DefaultExt = ".jpg";
                saveFileDialog.Title = "Salvar imagem";
                saveFileDialog.Filter = "Imagem|*.jpg";
                saveFileDialog.ShowDialog();

                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                {
                    pcImagemCliente.Image.Save(saveFileDialog.FileName, ImageFormat.Jpeg);

                    if (MessageBox.Show("Imagem exportada com sucesso!\n\nDeseja visualizar a imagem que foi exportada agora?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        Process.Start(saveFileDialog.FileName);
                    }
                }
            }
        }

        #endregion

        private void btnPesquisarCidade_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCidades frmCidades = new FrmCidades();
                frmCidades.ShowDialog();

                if (frmCidades._CidadeId > 0)
                {
                    cidadeId = frmCidades._CidadeId;
                    txtCidade.Text = frmCidades._Cidade;
                }
                else
                {
                    cidadeId = 0;
                    txtCidade.Text = "SELECIONE A CIDADE";
                }

                txtBairro.Focus();
            }
            catch
            { }
        }

        #region Eventos = TextBox Limite de Crédito

        private void txtLimiteCredito_Enter(object sender, EventArgs e)
        {
            if (txtLimiteCredito.Text.Trim() == "0,00")
                txtLimiteCredito.Clear();
            else
            {
                txtLimiteCredito.SelectAll();
                txtLimiteCredito.Focus();
            }
        }

        private void txtLimiteCredito_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtLimiteCredito.Text.Trim() == "0,00")
                txtLimiteCredito.Clear();
            else
            {
                txtLimiteCredito.SelectAll();
                txtLimiteCredito.Focus();
            }
        }

        private void txtLimiteCredito_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        #endregion

    }
}
