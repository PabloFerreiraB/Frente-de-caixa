namespace PFSoftwares.AcessoBancoDados
{
    /// <summary>
    ///    Classe SqlParametros
    /// </summary>
    public sealed class SqlParametros
    {
        private string campo;
        private object valor;

        /// <summary>
        ///    Campo
        /// </summary>
        public string Campo
        {
            get { return campo; }
            set { campo = value; }
        }

        /// <summary>
        ///    Valor
        /// </summary>
        public object Valor
        {
            get { return valor; }
            set { valor = value; }
        }

        /// <summary>
        ///    Construtor Padrão
        /// </summary>
        public SqlParametros()
        {
        }

        /// <summary>
        ///    Construtor com Sobrecarga (Preenche Campo)
        /// </summary>
        /// <param name="campo">Campo</param>
        public SqlParametros(string campo)
        {
            Campo = campo;
        }

        /// <summary>
        ///    Construtor com Sobrecarga (Preenche Campo e Valor)
        /// </summary>
        /// <param name="campo">Campo</param>
        /// <param name="valor">Valor</param>
        public SqlParametros(string campo, object valor)
        {
            Campo = campo;
            Valor = valor;
        }
    }
}
