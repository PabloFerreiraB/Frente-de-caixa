using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static PDV.Apresentacao.Emails.EnviarEmail;

namespace PDV.Apresentacao.Emails
{
    public partial class FrmEnviarEmail : Form
    {
        public FrmEnviarEmail()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Um array lista contento todos os anexos
        /// </summary>
        ArrayList aAnexosEmail;
        public string _Email { get; set; }




        private void FrmEnviarEmail_Load(object sender, EventArgs e)
        {
            txtEnviarPara.Select();
            txtEnviarPara.Focus();

            if (!string.IsNullOrEmpty(_Email))
            {
                txtEnviarPara.Text = _Email;
            }
        }

        private void FrmEnviarEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F9)
            {
                btnAnexar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnEnviar_Click(sender, e);
            }
        }

        private void btnAnexar_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] arr = openFileDialog.FileNames;
                    aAnexosEmail = new ArrayList();
                    txtAnexo.Text = string.Empty;
                    aAnexosEmail.AddRange(arr);

                    foreach (string s in aAnexosEmail)
                    {
                        txtAnexo.Text += s + "; ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            pictureBox.Visible = true;
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtEnviarPara.Text))
                {
                    MessageBox.Show("Endereço de e-mail do destinatário inválido!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtEnviadoPor.Text))
                {
                    MessageBox.Show("Endereço de e-mail  do remetente inválido!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtAssunto.Text))
                {
                    MessageBox.Show("Definição do assunto inválida!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (string.IsNullOrEmpty(txtMensagem.Text))
                {
                    MessageBox.Show("Mensagem inválida!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //separa os anexos em um array de string
                string[] arr = txtAnexo.Text.Split(';');
                //cria um novo arraylist
                aAnexosEmail = new ArrayList();
                //percorre o array de string e inclui os anexos
                for (int i = 0; i < arr.Length; i++)
                {
                    if (!string.IsNullOrEmpty(arr[i].ToString().Trim()))
                    {
                        aAnexosEmail.Add(arr[i].ToString().Trim());
                    }
                }

                // Se existirem anexos , envia a mensagem com 
                // a chamada a EnviaMensagemComAnexos senão
                // usa o método enviaMensagemEmail
                if (aAnexosEmail.Count > 0)
                {
                    string resultado = EnviaEmail.EnviaMensagemComAnexos(txtEnviarPara.Text,
                        txtEnviadoPor.Text, txtAssunto.Text, txtMensagem.Text,
                        aAnexosEmail);

                    MessageBox.Show("E-mail enviado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string resultado = EnviaEmail.EnviaMensagemEmail(txtEnviarPara.Text,
                        txtEnviadoPor.Text, txtAssunto.Text, txtMensagem.Text);

                    MessageBox.Show("E-mail enviado com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar enviar o e-mail!\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pictureBox.Visible = false;
        }
    }
}
