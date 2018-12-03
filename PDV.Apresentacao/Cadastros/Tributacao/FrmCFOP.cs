using PDV.Negocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros.Tributacao
{
    public partial class FrmCFOP : Form
    {
        public FrmCFOP()
        {
            InitializeComponent();
        }

        #region Instâncias

        readonly CfopNegocios cfopNegocios = new CfopNegocios();

        #endregion

        #region Propriedades

        public bool _PesquisaExterna = false;
        public int _Tipo { get; set; }  //0-ENTRADA   1-SAIDA
        public int _CfopId { get; set; }
        public string _Codigo { get; set; }
        public string _Descricao { get; set; }

        #endregion

        #region Variáveis

        BindingSource bs;
        DataTable dtCfops;
        string aplica = string.Empty;
        string pesquisar = string.Empty;
        string tipo = string.Empty;

        #endregion

        #region Métodos

        private void CarregarCFOP(bool goToDB)
        {
            aplica = string.Empty;
            switch (cbbAplicacao.Text)
            {
                case "Estadual":
                    if (cbbTipoCFOP.Text.Equals("Entrada")) { aplica = "1"; } else if (cbbTipoCFOP.Text.Equals("Saida")) { aplica = "5"; } else { aplica = "15"; }
                    break;
                case "Inter-Estadual":
                    if (cbbTipoCFOP.Text.Equals("Entrada")) { aplica = "2"; } else if (cbbTipoCFOP.Text.Equals("Saida")) { aplica = "6"; } else { aplica = "26"; }
                    break;
                case "Internacional":
                    if (cbbTipoCFOP.Text.Equals("Entrada")) { aplica = "3"; } else if (cbbTipoCFOP.Text.Equals("Saida")) { aplica = "7"; } else { aplica = "37"; }
                    break;
                default:
                    break;
            }

            pesquisar = txtPesquisar.Text;
            tipo = cbbTipoCFOP.Text.Substring(0, 1);

            if (goToDB)
            {
                dtCfops = new DataTable();
                dtCfops = cfopNegocios.PesquisarCFOP(pesquisar, aplica, tipo);
            }

            bs = new BindingSource();
            bs.DataSource = dtCfops;
            gridCFOP.DataSource = bs;

            if (gridCFOP.Rows.Count > 0)
            {
                lblQuantidade.Text = gridCFOP.Rows.Count.ToString("N0") + " Resultados encontrado(s)";
                lblAplicase.Text = gridCFOP.Rows[0].Cells["Aplica"].Value.ToString();
            }
            else
            {
                lblQuantidade.Text = "Nenhum resultado encontrado!";
                lblAplicase.Text = string.Empty;
            }
        }

        #endregion

        private void FrmCFOP_Load(object sender, EventArgs e)
        {
            if (_PesquisaExterna)
            {
                cbbTipoCFOP.Text = _Tipo.Equals(0) ? "Entrada" : "Saida";
                cbbTipoCFOP.Enabled = false;
            }

            cbbTipoCFOP.SelectedIndex = cbbAplicacao.SelectedIndex = 0;

            txtPesquisar.Select();
            txtPesquisar.Focus();
        }

        private void FrmCFOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        #region Eventos - Combobox's

        private void cbbTipoCFOP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarCFOP(true);
            }
            catch
            { }
        }

        private void cbbAplicacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CarregarCFOP(true);
            }
            catch
            { }
        }


        #endregion

        #region Eventos - txtPesquisa

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            bs.Filter = "(Codigo like '%" + txtPesquisar.Text + "%')" + " OR " + "(Descricao like '%" + txtPesquisar.Text + "%')";
            lblQuantidade.Text = gridCFOP.Rows.Count.ToString("N0") + " Resultados encontrado(s)";
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down) && gridCFOP.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                gridCFOP.Focus();
            }
        }




        #endregion

        #region Eventos - Grid

        private void gridCFOP_DoubleClick(object sender, EventArgs e)
        {
            if (_PesquisaExterna && gridCFOP.Rows.Count > 0)
            {
                _CfopId = Convert.ToInt32(gridCFOP.Rows[gridCFOP.CurrentRow.Index].Cells["CFOPId_"].Value);
                _Codigo = gridCFOP.Rows[gridCFOP.CurrentRow.Index].Cells["Codigo"].Value.ToString();
                _Descricao = gridCFOP.Rows[gridCFOP.CurrentRow.Index].Cells["Descricao"].Value.ToString();

                this.Close();
            }
        }

        private void gridCFOP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                gridCFOP_DoubleClick(sender, e);
        }

        private void gridCFOP_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (gridCFOP.Rows.Count > 0)
                    lblAplicase.Text = gridCFOP.Rows[gridCFOP.CurrentRow.Index].Cells["Aplica_"].Value.ToString();
            }
            catch
            { }
        }



        #endregion

    }
}
