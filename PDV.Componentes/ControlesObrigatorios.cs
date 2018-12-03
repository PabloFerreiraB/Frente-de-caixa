using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PDV.Componentes
{
    [ProvideProperty("FraseErro", typeof(Control))]
    [ProvideProperty("Obrigatorio", typeof(Control))]
    [ProvideProperty("IndiceCombo", typeof(Control))]
    public partial class ControlesObrigatorios : ErrorProvider, IExtenderProvider
    {
        #region Propriedades

        protected Hashtable _obrigatorio;
        protected Hashtable _fraseerro;
        protected Hashtable _indicecombo;

        #endregion

        #region Construtores 

        public ControlesObrigatorios()
        {
            _obrigatorio = new Hashtable();
            _fraseerro = new Hashtable();
            _indicecombo = new Hashtable();

            InitializeComponent();
        }

        public ControlesObrigatorios(IContainer container)
        {
            _obrigatorio = new Hashtable();
            _fraseerro = new Hashtable();
            _indicecombo = new Hashtable();

            container.Add(this);

            InitializeComponent();
        }

        #endregion

        #region Classes

        private partial class ReturnObrigatorio
        {
            public bool Obrigatorio;

            public ReturnObrigatorio()
            {
                Obrigatorio = false;
            }
        }

        private partial class ReturnFrase
        {
            public string FraseErro;

            public ReturnFrase()
            {
                FraseErro = "";
            }
        }

        private partial class ReturnIndice
        {
            public int IndiceCombo;

            public ReturnIndice()
            {
                IndiceCombo = -1;
            }
        }

        #endregion

        #region Métodos de Verificação

        private ReturnObrigatorio ObrigatorioExiste(object key)
        {
            ReturnObrigatorio p = (ReturnObrigatorio)_obrigatorio[key];

            if (p == null)
            {
                p = new ReturnObrigatorio();
                _obrigatorio[key] = p;
            }

            return p;
        }

        private ReturnFrase FraseErroExiste(object key)
        {
            ReturnFrase e = (ReturnFrase)_fraseerro[key];

            if (e == null)
            {
                e = new ReturnFrase();
                _fraseerro[key] = e;
            }

            return e;
        }

        private ReturnIndice IndiceComboExiste(object key)
        {
            ReturnIndice e = (ReturnIndice)_indicecombo[key];

            if (e == null)
            {
                e = new ReturnIndice();
                _indicecombo[key] = e;
            }

            return e;
        }

        #endregion

        #region Métodos GET e SET

        public void SetObrigatorio(Control lControl, bool bValue)
        {
            ObrigatorioExiste(lControl).Obrigatorio = bValue;
        }

        public bool GetObrigatorio(Control lControl)
        {
            return ObrigatorioExiste(lControl).Obrigatorio;
        }

        public void SetFraseErro(Control lControl, string sValue)
        {
            FraseErroExiste(lControl).FraseErro = sValue;
        }

        public string GetFraseErro(Control lControl)
        {
            return FraseErroExiste(lControl).FraseErro;
        }

        public void SetIndiceCombo(Control lControl, int iValue)
        {
            IndiceComboExiste(lControl).IndiceCombo = iValue;
        }

        public int GetIndiceCombo(Control lControl)
        {
            return IndiceComboExiste(lControl).IndiceCombo;
        }

        #endregion

        #region Método validar

        public bool Validar()
        {
            bool bVer = true;
            //foreach (Control lControl in frmCliente.Controls.OfType<TabControl>())
            foreach (Control lControl in this.ContainerControl.Controls)
            {
                if (ObrigatorioExiste(lControl).Obrigatorio)
                {
                    if (lControl is TextBox)
                    {
                        if (lControl.Text == string.Empty)
                        {
                            this.SetError(lControl, FraseErroExiste(lControl).FraseErro); bVer = false;
                        }
                    }
                    else if (lControl is ComboBox)
                    {
                        ComboBox ctl = (ComboBox)lControl;

                        if (ctl.SelectedIndex == -1)
                        {
                            this.SetError(lControl, FraseErroExiste(lControl).FraseErro); bVer = false;
                        }
                    }
                    else if (lControl is MaskedTextBox)
                    {
                        MaskedTextBox ctl = (MaskedTextBox)lControl;

                        if (!ctl.MaskCompleted)
                        {
                            this.SetError(lControl, FraseErroExiste(lControl).FraseErro); bVer = false;
                        }
                    }
                }
            }

            return bVer;
        }

        #endregion


        bool IExtenderProvider.CanExtend(object lControl)
        {
            if ((lControl is TextBox) || (lControl is ComboBox) || (lControl is MaskedTextBox))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
