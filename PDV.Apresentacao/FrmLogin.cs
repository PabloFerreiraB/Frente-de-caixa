using PDV.AcessoBancoDados;
using PDV.Apresentacao.Cadastros;
using PDV.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PDV.Apresentacao
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        } 

        #region Instancias

        Cryptografia cryptografia = new Cryptografia();
        UsuariosNegocios usuariosNegocios = new UsuariosNegocios();
        Conexao conexao = new Conexao();

        #endregion

        #region Propriedades

        public bool _Bloqueio { get; set; }

        #endregion

        #region Variáveis

        public static string nome = string.Empty;
        public static string nomeLogin = string.Empty;
        public static string senha = string.Empty;
        public static int usuarioId = 0;

        bool usuarioInativo = false;
        bool logou = false;

        #endregion

        #region MÉTODOS

        private Boolean Login()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = usuariosNegocios.PesquisarPorUsuario(txtUsuario.Text);
                if (dt.Rows.Count > 0)
                {
                    usuarioInativo = false;
                    if (dt.Rows[0]["Ativo"].Equals("Inativo"))
                    {
                        usuarioInativo = true;
                        MessageBox.Show("Usuário inativo, por favor verifique com o administrador!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    if (dt.Rows[0]["Senha"].ToString().Equals(cryptografia.Crypto(txtSenha.Text, true)))
                    {
                        nome = dt.Rows[0]["Nome"].ToString();
                        nomeLogin = dt.Rows[0]["NomeLogin"].ToString();
                        senha = txtSenha.Text;
                        usuarioId = Convert.ToInt32(dt.Rows[0]["UsuarioId"]);

                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    txtSenha.Clear();
                    txtUsuario.Focus();
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }


        private Boolean ExisteUsuario()
        {
            DataTable dtUsuario = new DataTable();
            dtUsuario = usuariosNegocios.PesquisarUsuarioAtivos();

            if (dtUsuario.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                FrmUsuarios frmUsuarios = new FrmUsuarios();
                frmUsuarios.ShowInTaskbar = false;
                frmUsuarios.ShowDialog();

                if (frmUsuarios._UsuarioId > 0)
                {
                    try
                    {
                        // PABLO -- FrmLogin -- / Insert GrupoUsuariosPermissoes
                        //Conexao conexao = new Conexao();
                        //conexao.Executar("INSERT INTO GrupoUsuarioPermissoes (FormularioId, GrupoUsuarioId, Inserir, Alterar, Excluir, Visualizar) VALUES ('3', '1', 'True', 'True', 'True', 'True'); ");
                        //conexao.Executar("INSERT INTO GrupoUsuarioPermissoes (FormularioId, GrupoUsuarioId, Inserir, Alterar, Excluir, Visualizar) VALUES ('9', '1', 'True', 'True', 'True', 'True'); ");
                    }
                    catch
                    { }

                    return true;
                }
                else
                    return false;
            }
        }

        #endregion


        #region Eventos FrmLogin

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            if (!ExisteUsuario())
            {
                MessageBox.Show("É necessário criar seu Usuário de login.\n\nO sistema será fechado para sua segurança, tente novamente!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }

            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\PDV";

            if (File.Exists(path + "\\credenciais.xml") && !_Bloqueio)
            {
                chkLembreMe.Visible = false;
                try
                {
                    XElement root = XElement.Load(path + "\\credenciais.xml");

                    string idMode = (string)root.Element("idmode");

                    if (Cryptografia.MD5(Environment.MachineName.ToString()) != idMode)
                    {
                        MessageBox.Show("Você está tentando acessar com credenciais de outra pessoa, será gravado em log seu usuário e a conta de quem você está tentando acessar!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }

                    txtUsuario.Text = (string)root.Element("user");

                    Cryptografia objCrypto = new Cryptografia();
                    txtSenha.Text = objCrypto.Crypto((string)root.Element("pass"), false);

                    btnAcessar_Click(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocorreu um erro ao tentar carregar as credenciais do usuário!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape || e.Alt && e.KeyCode == Keys.F4)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
        }

        private void FrmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!logou)
                Application.Exit();
        }

        #endregion

        #region Eventos KeyDown (txtUsuario, txtSenha)

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                Util.Tabfunction(e);
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                e.SuppressKeyPress = true;
                this.Close();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnAcessar_Click(sender, e);
            }
        }

        #endregion

        private void btnAcessar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Login())
                {
                    if (chkLembreMe.Checked)
                    {
                        string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                        if (!Directory.Exists(path + "\\PDV"))
                        {
                            Directory.CreateDirectory(path + "\\PDV");
                        }

                        StreamWriter objEscreve = new StreamWriter(path + "\\PDV" + "\\credenciais.xml");

                        objEscreve.WriteLine("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
                        objEscreve.WriteLine("<useroptions>");
                        objEscreve.WriteLine("<user>{0}</user>", txtUsuario.Text);
                        objEscreve.WriteLine("<idmode>{0}</idmode>", Cryptografia.MD5(Environment.MachineName.ToString()));

                        Cryptografia cryptografia = new Cryptografia();
                        objEscreve.WriteLine(string.Format("<pass>{0}</pass>", cryptografia.Crypto(txtSenha.Text, true)));

                        objEscreve.WriteLine("</useroptions>");
                        objEscreve.Flush();
                        objEscreve.Close();
                    }

                    txtUsuario.Clear();
                    txtSenha.Clear();
                    txtUsuario.Focus();
                    logou = true;
                    this.Close();
                }
                else
                {
                    if (usuarioInativo.Equals(false))
                    {
                        MessageBox.Show("Usuário ou senha inválidos!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsuario.SelectAll();
                        txtUsuario.Focus();
                        txtSenha.Clear();
                    }
                    else
                        txtUsuario.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao tentar gravar as credenciais do usuário : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        
    }
}
