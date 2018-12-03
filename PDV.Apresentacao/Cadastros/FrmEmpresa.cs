using PDV.AcessoBancoDados;
using PDV.Apresentacao.Utils;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmEmpresa : Form
    {
        public FrmEmpresa()
        {
            InitializeComponent();
        }

        #region Instâncias

        EmpresaNegocios empresaNegocios = new EmpresaNegocios();
        CidadesNegocios cidadesNegocios = new CidadesNegocios();

        #endregion

        #region Variáveis

        int empresaId = 0;
        int cidadeId = 0;
        int cidadeCId = 0;
        private X509Certificate2 certificado = null;
        DataTable dtCidade = new DataTable();

        #endregion

        #region Métodos

        private void MascararTelefone(MaskedTextBox t)
        {
            int tama = t.Text.Length;
            t.Mask = t.Text.Replace("-", "").Replace(".", "").Replace("(", "").Replace(")", "").Replace(" ", "").Length == 11 ? "(99)99999-9999" : "(99)9999-9999";
        }

        private void DesmascararTelefone(MaskedTextBox t)
        {
            t.Mask = "99999999999";
        }


        private void Limpar()
        {
            foreach (TabPage tab in this.tabControl.TabPages)
            {
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
                        ((ComboBox)obj).SelectedIndex = -1;
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
            }
        }


        private void CarregarEmpresa()
        {
            try
            {
                DataTable dtEmpresa = new DataTable();
                dtEmpresa = empresaNegocios.PesquisarEmpresa();

                if (dtEmpresa.Rows.Count > 0)
                {
                    empresaId = Convert.ToInt32(dtEmpresa.Rows[0]["EmpresaId"].ToString());

                    txtRazaoSocial.Text = dtEmpresa.Rows[0]["RazaoSocial"].ToString();
                    txtNomeFantasia.Text = dtEmpresa.Rows[0]["NomeFantasia"].ToString();
                    txtTelefone.Text = dtEmpresa.Rows[0]["Telefone"].ToString();
                    txtCelular.Text = dtEmpresa.Rows[0]["Celular"].ToString();
                    txtCep.Text = dtEmpresa.Rows[0]["Cep"].ToString();
                    txtEndereco.Text = dtEmpresa.Rows[0]["Endereco"].ToString();
                    txtNumero.Text = dtEmpresa.Rows[0]["Numero"].ToString();
                    txtBairro.Text = dtEmpresa.Rows[0]["Bairro"].ToString();

                    if (dtEmpresa.Rows[0]["CidadeId"].ToString() != null)
                    {
                        dtCidade = cidadesNegocios.PesquisarPorCodigo(Convert.ToInt32(dtEmpresa.Rows[0]["CidadeId"]));
                        txtCidade.Text = dtCidade.Rows[0]["Nome"].ToString();
                    }

                    txtCpfCnpj.Text = dtEmpresa.Rows[0]["Cnpj"].ToString();
                    txtIE.Text = dtEmpresa.Rows[0]["IE"].ToString();
                    txtIM.Text = dtEmpresa.Rows[0]["IM"].ToString();
                    txtSite.Text = dtEmpresa.Rows[0]["SiteEmpresa"].ToString();
                    txtEmail.Text = dtEmpresa.Rows[0]["Email"].ToString();


                    if (dtEmpresa.Rows[0]["RegimeTributario"].ToString() == "1")
                        cbbRegimeTributario.Text = "1 - Simples Nacional";
                    else if (dtEmpresa.Rows[0]["RegimeTributario"].ToString() == "2")
                        cbbRegimeTributario.Text = "2 - Simples Nacional - Excesso de sublimite de receita bruta";
                    else
                        cbbRegimeTributario.Text = "3 - Regime Normal";


                    if (dtEmpresa.Rows[0]["Csosn"].ToString() == "101")
                        cbbCSOSN.Text = "101 – Tributada pelo Simples Nacional com permissão de crédito";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "102")
                        cbbCSOSN.Text = "102 – Tributada pelo Simples Nacional sem permissão de crédito";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "103")
                        cbbCSOSN.Text = "103 – Isenção do ICMS no Simples Nacional para faixa de receita bruta";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "201")
                        cbbCSOSN.Text = "201 – Tributada pelo Simples Nacional com permissão de crédito e com cobrança do ICMS por substituição tributária";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "202")
                        cbbCSOSN.Text = "202 – Tributada pelo Simples Nacional sem permissão de crédito e com cobrança do ICMS por substituição tributária";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "203")
                        cbbCSOSN.Text = "203 – Isenção do ICMS no Simples Nacional para faixa de receita bruta e com cobrança do ICMS por substituição tributária";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "300")
                        cbbCSOSN.Text = "300 – Imune";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "400")
                        cbbCSOSN.Text = "400 – Não tributada pelo Simples Nacional";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "500")
                        cbbCSOSN.Text = "500 – ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação";
                    else if (dtEmpresa.Rows[0]["Csosn"].ToString() == "900")
                        cbbCSOSN.Text = "900 – Outros";

                    #region Contador

                    txtNomeC.Text = dtEmpresa.Rows[0]["NomeC"].ToString();
                    txtCpfC.Text = dtEmpresa.Rows[0]["CpfC"].ToString();
                    txtCRCC.Text = dtEmpresa.Rows[0]["CRCC"].ToString();
                    txtTelefoneC.Text = dtEmpresa.Rows[0]["TelefoneC"].ToString();
                    txtCelularC.Text = dtEmpresa.Rows[0]["CelularC"].ToString();
                    txtEmailC.Text = dtEmpresa.Rows[0]["EmailC"].ToString();
                    if (dtEmpresa.Rows[0]["CidadeCId"].ToString() != null)
                    {
                        dtCidade = cidadesNegocios.PesquisarPorCodigo(Convert.ToInt32(dtEmpresa.Rows[0]["CidadeCId"]));
                        txtCidadeC.Text = dtCidade.Rows[0]["Nome"].ToString();
                    }

                    #endregion

                    #region Logotipo 

                    if (!string.IsNullOrEmpty(dtEmpresa.Rows[0]["Logotipo"].ToString()))
                    {
                        try
                        {
                            byte[] foto_array = (Byte[])dtEmpresa.Rows[0]["Logotipo"];
                            MemoryStream memoria = new MemoryStream(foto_array);
                            pcbImagem.Image = Image.FromStream(memoria);
                        }
                        catch
                        { }
                    }

                    #endregion

                    #region CERFICADO DIGITAL

                    //if (!string.IsNullOrEmpty(dtEmpresa.Rows[0]["CertificadoDigital"].ToString()))
                    //{
                    //    try
                    //    {
                    //        txtDadosCertificado.Text = dtEmpresa.Rows[0]["CertificadoDigital"].ToString();

                    //        X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
                    //        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                    //        X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                    //        X509Certificate2Collection collection1 = null;

                    //        if (!string.IsNullOrEmpty(txtDadosCertificado.Text))
                    //            collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindBySubjectDistinguishedName, txtDadosCertificado.Text, false);

                    //        for (int i = 0; i < collection1.Count; i++)
                    //        {
                    //            //Verificar a validade do certificado
                    //            if (DateTime.Compare(DateTime.Now, collection1[i].NotAfter) == -1)
                    //            {
                    //                certificado = collection1[i];
                    //                break;
                    //            }
                    //        }

                    //        //Se não encontrou nenhum certificado com validade correta, vou pegar o primeiro certificado, porem vai travar na hora de tentar enviar a nota fiscal, por conta da validade. Wandrey 06/04/2011
                    //        if (certificado == null && collection1.Count > 0)
                    //            certificado = collection1[0];

                    //        if (certificado != null)
                    //            DemonstraDadosCertificado();
                    //    }
                    //    catch { MessageBox.Show("Erro ao carregar o certificado digital", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    //}

                    #endregion


                }
                else
                {
                    Limpar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO:\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion


        private void FrmEmpresa_Load(object sender, EventArgs e)
        {
            CarregarEmpresa();
            cbbCSOSN.SelectedIndex = 0;
            txtRazaoSocial.Select();
            txtRazaoSocial.Focus();
        }

        #region Formatação dos Telefones

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

        private void btnCidade_Click(object sender, EventArgs e)
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
                    txtCidade.Clear();
                }

                txtCpfCnpj.Focus();
            }
            catch
            { }
        }

        #region Formatação do CNPJ

        private void txtCpfCnpj_Enter(object sender, EventArgs e)
        {
            try
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
            catch
            { }
        }

        private void txtCpfCnpj_Leave(object sender, EventArgs e)
        {
            try
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



        #endregion


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                #region Verificações para cadastrar

                if (string.IsNullOrEmpty(txtRazaoSocial.Text))
                {
                    MessageBox.Show("Informe a Razão Social da empresa.", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRazaoSocial.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtTelefone.Text.TrimStart().TrimEnd().Replace("-", "").Replace(".", "")) && string.IsNullOrEmpty(txtCelular.Text.TrimStart().TrimEnd().Replace("-", "").Replace(".", "")))
                {
                    MessageBox.Show("Informe um Telefone Fixo ou Celular com DDD.", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTelefone.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtCep.Text))
                {
                    MessageBox.Show("Informe o CEP.", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCep.Focus();
                    return;
                }

                if (string.IsNullOrEmpty(txtCpfCnpj.Text))
                {
                    MessageBox.Show("Informe o CNPJ!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCpfCnpj.Focus();
                    return;
                }

                #endregion

                Empresa empresa = new Empresa();

                empresa.RazaoSocial = txtRazaoSocial.Text.Trim();
                empresa.NomeFantasia = txtNomeFantasia.Text.Trim();
                empresa.Telefone = txtTelefone.Text.Trim();
                empresa.Celular = txtCelular.Text.Trim();
                empresa.Cep = txtCep.Text.Trim();
                empresa.Endereco = txtEndereco.Text.Trim();
                empresa.Numero = txtNumero.Text.Trim();
                empresa.Bairro = txtBairro.Text.Trim();
                if (cidadeId > 0)
                    empresa.CidadeId = cidadeId;
                empresa.Cnpj = txtCpfCnpj.Text.Trim();
                empresa.IE = txtIE.Text.Trim();
                empresa.IM = txtIM.Text.Trim();
                empresa.SiteEmpresa = txtSite.Text.Trim();
                empresa.Email = txtEmail.Text.Trim();
                if (!string.IsNullOrEmpty(cbbRegimeTributario.Text))
                {
                    if (cbbRegimeTributario.Text.Substring(0, 1).Equals("1"))
                        empresa.RegimeTributario = 1;
                    else if (cbbRegimeTributario.Text.Substring(0, 1).Equals("2"))
                        empresa.RegimeTributario = 2;
                    else
                        empresa.RegimeTributario = 3;
                }
                if (!string.IsNullOrEmpty(cbbCSOSN.Text))
                {
                    empresa.Csosn = Convert.ToInt32(cbbCSOSN.Text.Substring(0, 3));
                }


                empresa.NomeC = txtNomeC.Text.Trim();
                empresa.CpfC = txtCpfC.Text.Trim();
                empresa.CRCC = txtCRCC.Text.Trim();
                empresa.TelefoneC = txtTelefoneC.Text.Trim();
                empresa.CelularC = txtCelularC.Text.Trim();
                empresa.EmailC = txtEmailC.Text.Trim();
                if (cidadeCId > 0)
                    empresa.CidadeCId = cidadeCId;

                empresa.Logotipo = null;


                if (empresaId <= 0)
                {
                    empresaNegocios.Inserir(empresa);

                    MessageBox.Show("Empresa cadastrada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    empresa.EmpresaId = empresaId;
                    empresaNegocios.Alterar(empresa);

                    MessageBox.Show("Empresa alterada com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (pcbImagem.Image != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        pcbImagem.Image.Save(ms, ImageFormat.Jpeg);
                        byte[] photo_aray = new byte[ms.Length];
                        ms.Position = 0;
                        ms.Read(photo_aray, 0, photo_aray.Length);

                        Conexao conexao = new Conexao();
                        SqlConnection con = conexao.conn;
                        string query = "UPDATE Empresa SET Logotipo = @MyImagem WHERE EmpresaId = " + empresaId;
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.Add(new SqlParameter("@MyImagem", (object)photo_aray));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }

                    tabControl.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar empresa!" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmEmpresa_KeyDown(object sender, KeyEventArgs e)
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

        private void btnCidadeC_Click(object sender, EventArgs e)
        {
            try
            {
                FrmCidades frmCidades = new FrmCidades();
                frmCidades.ShowDialog();

                if (frmCidades._CidadeId > 0)
                {
                    cidadeCId = frmCidades._CidadeId;
                    txtCidadeC.Text = frmCidades._Cidade;
                }
                else
                {
                    cidadeCId = 0;
                    txtCidadeC.Clear();
                }

                btnSalvar.Focus();
            }
            catch
            { }
        }

        #region Formatação CPF Contador

        private void txtCpfC_Enter(object sender, EventArgs e)
        {
            try
            {
                if (txtCpfC.Text.Length == 14)
                {
                    string cpftemp = txtCpfC.Text;
                    txtCpfC.Clear();

                    txtCpfC.Text = cpftemp.Substring(0, 3);
                    txtCpfC.Text += cpftemp.Substring(4, 3);
                    txtCpfC.Text += cpftemp.Substring(8, 3);
                    txtCpfC.Text += cpftemp.Substring(12, 2);
                }
            }
            catch
            { }
        }

        private void txtCpfC_Leave(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtCpfC.Text))
                {
                    if (Util.ValidaCPF(txtCpfC.Text))
                    {
                        string cpftemp = txtCpfC.Text;
                        txtCpfC.Clear();

                        txtCpfC.Text = cpftemp.Substring(0, 3);
                        txtCpfC.Text += "." + cpftemp.Substring(3, 3);
                        txtCpfC.Text += "." + cpftemp.Substring(6, 3);
                        txtCpfC.Text += "-" + cpftemp.Substring(9, 2);
                    }
                    else
                    {
                        MessageBox.Show("CPF do Contador Inválido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCpfC.Clear();
                        txtCpfC.Focus();
                    }
                }
            }
            catch
            { }
        }

        private void txtCpfC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b")
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }



        #endregion

        #region Formatação - Telefones Contador

        private void txtTelefoneC_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtTelefoneC);
        }

        private void txtTelefoneC_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtTelefoneC);
        }

        private void txtCelularC_Enter(object sender, EventArgs e)
        {
            DesmascararTelefone(txtCelularC);
        }

        private void txtCelularC_Leave(object sender, EventArgs e)
        {
            MascararTelefone(txtCelularC);
        }




        #endregion

        #region Logotipo da Empresa

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Imagem (*.jpg)|*.jpg|Imagem (*.png)|*.png";
            openFileDialog.InitialDirectory = "C:";
            openFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                txtImagem.Text = openFileDialog.FileName;
                pcbImagem.ImageLocation = openFileDialog.FileName;
            }
            else
            {
                txtImagem.Text = string.Empty;
                pcbImagem.Image = null;
            }
        }

        #endregion
    }
}
