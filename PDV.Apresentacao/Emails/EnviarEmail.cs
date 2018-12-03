using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PDV.Apresentacao.Emails
{
    public class EnviarEmail
    {
        public class EnviaEmail
        {
            /// <summary>
            /// Transmite uma mensagem de email sem anexos
            /// </summary>
            /// <param name="Destinatario">Destinatario (Recipient)</param>
            /// <param name="Remetente">Remetente (Sender)</param>
            /// <param name="Assunto">Assunto da mensagem (Subject)</param>
            /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
            /// <returns>Status da mensagem</returns>
            public static string EnviaMensagemEmail(string Destinatario, string Remetente,
                string Assunto, string enviaMensagem)
            {
                try
                {
                    // valida o email
                    bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                    // Se o email não é validao retorna uma mensagem
                    if (bValidaEmail == false)
                        return "Email do destinatário inválido: " + Destinatario;

                    // cria uma mensagem
                    MailMessage mensagemEmail = new MailMessage(Remetente, Destinatario, Assunto, enviaMensagem);

                    //----------------------------------------------------------------------------------------------------------------------------------
                    //obtem os valores smtp do arquivo de configuração . Não vou usar estes valores estou apenas mostrando como obtê-los
                    //Configuration configurationFile = WebConfigurationManager.OpenWebConfiguration(null);
                    //MailSettingsSectionGroup mailSettings = configurationFile.GetSectionGroup("system.net/mailSettings") as MailSettingsSectionGroup;
                    //if (mailSettings != null)
                    //{
                    //     string host = mailSettings.Smtp.Network.Host;
                    //     string password = mailSettings.Smtp.Network.Password;
                    //     string username = mailSettings.Smtp.Network.UserName;
                    //     int port = mailSettings.Smtp.Network.Port;
                    //}
                    //----------------------------------------------------------------------------------------------------------------------------------

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    client.UseDefaultCredentials = false;
                    NetworkCredential cred = new NetworkCredential("pablofb1014@gmail.com", "D3u$em4is");
                    client.Credentials = cred;

                    // inclui as credenciais
                    //client.UseDefaultCredentials = true;

                    // envia a mensagem
                    client.Send(mensagemEmail);

                    return "Mensagem enviada para  " + Destinatario + " às " + DateTime.Now.ToString() + ".";
                }
                catch (Exception ex)
                {
                    return ex.Message.ToString();
                }
            }
            /// <summary>
            /// Transmite uma mensagem de email com um anexo
            /// </summary>
            /// <param name="Destinatario">Destinatario (Recipient)</param>
            /// <param name="Remetente">Remetente (Sender)</param>
            /// <param name="Assunto">Assunto da mensagem (Subject)</param>
            /// <param name="enviaMensagem">Corpo da mensagem(Body)</param>
            /// <param name="anexos">Um array de strings apontando para a localização de cada anexo</param>
            /// <returns>Status da mensagem</returns>
            public static string EnviaMensagemComAnexos(string Destinatario, string Remetente,
                string Assunto, string enviaMensagem, ArrayList anexos)
            {
                try
                {
                    // valida o email
                    bool bValidaEmail = ValidaEnderecoEmail(Destinatario);

                    if (bValidaEmail == false)
                        return "Email do destinatário inválido:" + Destinatario;

                    // Cria uma mensagem
                    MailMessage mensagemEmail = new MailMessage(
                       Remetente,
                       Destinatario,
                       Assunto,
                       enviaMensagem);

                    // The anexos arraylist should point to a file location where
                    // the attachment resides - add the anexos to the message
                    foreach (string anexo in anexos)
                    {
                        Attachment anexado = new Attachment(anexo, MediaTypeNames.Application.Octet);
                        mensagemEmail.Attachments.Add(anexado);
                    }

                    SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                    client.EnableSsl = true;
                    NetworkCredential cred = new NetworkCredential("pablofb1014@gmail.com", "D3u$em4is");
                    client.Credentials = cred;

                    // Inclui as credenciais
                    //client.UseDefaultCredentials = true;

                    // envia a mensagem
                    client.Send(mensagemEmail);

                    return "Mensagem enviada para " + Destinatario + " às " + DateTime.Now.ToString() + ".";
                }
                catch (Exception ex)
                {
                    string erro = ex.InnerException.ToString();
                    return ex.Message.ToString() + erro;
                }
            }
            /// <summary>
            /// Confirma a validade de um email
            /// </summary>
            /// <param name="enderecoEmail">Email a ser validado</param>
            /// <returns>Retorna True se o email for valido</returns>
            public static bool ValidaEnderecoEmail(string enderecoEmail)
            {
                try
                {
                    //define a expressão regulara para validar o email
                    string texto_Validar = enderecoEmail;
                    Regex expressaoRegex = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}");

                    // testa o email com a expressão
                    if (expressaoRegex.IsMatch(texto_Validar))
                    {
                        // o email é valido
                        return true;
                    }
                    else
                    {
                        // o email é inválido
                        return false;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
