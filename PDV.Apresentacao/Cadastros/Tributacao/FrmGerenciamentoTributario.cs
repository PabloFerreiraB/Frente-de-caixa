using PDV.Apresentacao.Cadastros.Tributacao;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmGerenciamentoTributario : Form
    {
        public FrmGerenciamentoTributario(int regimeTributarioEmpresa)
        {
            InitializeComponent();


            //Pega o Regime Tributário no cadastro da Empresa
            regimeTributario = regimeTributarioEmpresa;
            if (regimeTributario.Equals(1))
                regimeTributario = 0;
            else
                regimeTributario = 1;
        }

        #region Instâncias

        readonly TributacaoFiscalNegocios tributacaoFiscalNegocios = new TributacaoFiscalNegocios();
        readonly TributacaoFiscalEstadosNegocios tributacaoFiscalEstadosNegocios = new TributacaoFiscalEstadosNegocios();

        #endregion

        #region Propriedades

        public int _TributacaoFiscalId { get; set; }
        public string _Descricao { get; set; }

        #endregion

        #region Métodos

        private void CarregarTributacoesFiscais()
        {
            tipo = -1;
            if (cbbTipo.SelectedIndex.Equals(1))
                tipo = 0;
            else if (cbbTipo.SelectedIndex.Equals(2))
                tipo = 1;


            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        #endregion

        #region Variáveis

        DataTable dtOperacoes;
        BindingSource bs = new BindingSource();

        int tipo = -1;
        int regimeTributario = 0;
        public bool pesquisaExterna = false;

        #endregion

        private void FrmGerenciamentoTributario_Load(object sender, EventArgs e)
        {
            CarregarTributacoesFiscais();
            if (pesquisaExterna)
                cbbTipo.SelectedIndex = 2;
            else
                cbbTipo.SelectedIndex = 0;

            txtDescricao.Focus();
        }

        private void FrmGerenciamentoTributario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
            else if (e.KeyCode == Keys.F5 && btnAlterar.Enabled && !pesquisaExterna)
            {
                btnAlterar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F8 && btnExcluir.Enabled && !pesquisaExterna)
            {
                btnExcluir_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2 && !pesquisaExterna)
            {
                btnNovoEntrada_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3 && !pesquisaExterna)
            {
                btnNovoSaida_Click(sender, e);
            }
        }


        #region Carregar Tributações cadastradas

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            dtOperacoes = new DataTable();
            dtOperacoes = tributacaoFiscalNegocios.PesquisarTributacoesFiscaisDataSource(tipo, regimeTributario);
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            bs.DataSource = dtOperacoes;
            grid.DataSource = bs;
            lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";

            if (grid.Rows.Count > 0)
                btnAlterar.Enabled = true;
            else
                btnAlterar.Enabled = false;

            if (grid.Rows.Count > 0)
                btnExcluir.Enabled = true;
            else
                btnExcluir.Enabled = false;
        }

        #endregion

        #region Eventos - Grid

        private void grid_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                btnExcluir.Enabled = btnAlterar.Enabled = true;
            }
        }

        private void grid_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                btnExcluir.Enabled = btnAlterar.Enabled = true;
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (pesquisaExterna && e.KeyCode == Keys.Enter)
            {
                grid_DoubleClick(sender, e);
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            if (grid.Rows.Count > 0)
            {
                if (pesquisaExterna)
                {
                    _TributacaoFiscalId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value);
                    _Descricao = grid.Rows[grid.CurrentRow.Index].Cells["Descricao_"].Value.ToString();

                    this.Close();
                }
                else
                    btnAlterar_Click(sender, e);
            }
        }

        #endregion

        #region Botões

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGrupoImposto frmGrupoImposto = new FrmGrupoImposto(Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["RegimeTributario_"].Value));
                frmGrupoImposto.ShowInTaskbar = false;
                frmGrupoImposto.tipo = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["Tipo_"].Value.ToString().Substring(0, 1));
                frmGrupoImposto._TributacaoFiscalId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value.ToString());
                frmGrupoImposto.ShowDialog();

                if (frmGrupoImposto._executouOperacao)
                    CarregarTributacoesFiscais();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar realizar a operação!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Yes == MessageBox.Show("Confirma a exclusão do grupo de imposto selecionado?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    TributacaoFiscalEstados tributacaoFiscalEstados = new TributacaoFiscalEstados();
                    tributacaoFiscalEstados.TributacaoFiscalEstadosId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value);
                    tributacaoFiscalEstadosNegocios.Excluir(tributacaoFiscalEstados);

                    TributacaoFiscal tributacaoFiscal = new TributacaoFiscal();
                    tributacaoFiscal.TributacaoFiscalId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value);
                    tributacaoFiscalNegocios.Excluir(tributacaoFiscal);

                    MessageBox.Show("Grupo de imposto excluído com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CarregarTributacoesFiscais();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar realizar a operação!\n\nDetalhe técnico:" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNovoEntrada_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGrupoImposto frmGrupoImposto = new FrmGrupoImposto(regimeTributario);
                frmGrupoImposto.ShowInTaskbar = false;
                frmGrupoImposto.tipo = 0; // Grupo Imposto Entrada
                frmGrupoImposto.ShowDialog();

                if (frmGrupoImposto._executouOperacao)
                {
                    cbbTipo.SelectedIndex = 0;
                    CarregarTributacoesFiscais();
                }
            }
            catch
            { }
        }

        private void btnNovoSaida_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGrupoImposto frmGrupoImposto = new FrmGrupoImposto(regimeTributario);
                frmGrupoImposto.ShowInTaskbar = false;
                frmGrupoImposto.tipo = 1; // Grupo Imposto Saída
                frmGrupoImposto.ShowDialog();

                if (frmGrupoImposto._executouOperacao)
                {
                    cbbTipo.SelectedIndex = 0;
                    CarregarTributacoesFiscais();
                }
            }
            catch
            { }
        }

        #endregion

        private void cbbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarTributacoesFiscais();
            txtDescricao.Focus();
        }

        #region Eventos - txtDescricao

        private void txtDescricao_TextChanged(object sender, EventArgs e)
        {
            try
            {
                bs.Filter = "(Descricao like '%" + txtDescricao.Text.Replace("'", "") + "%')";
                lblQuantidade.Text = grid.Rows.Count + " Resultados encontrado(s)";
            }
            catch
            { }
        }

        private void txtDescricao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }




        #endregion

    }
}
