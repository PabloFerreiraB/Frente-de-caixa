using PDV.AcessoBancoDados;
using PDV.Apresentacao.Utils;
using PDV.Negocios;
using PDV.ObjetoTransferencia;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace PDV.Apresentacao.Cadastros
{
    public partial class FrmProdutos : Form
    {
        public FrmProdutos()
        {
            InitializeComponent();
        }

        #region Propriedades

        readonly Permissoes permissoes = new Permissoes();
        readonly ProdutosNegocios produtosNegocios = new ProdutosNegocios();
        readonly FornecedorNegocios fornecedorNegocios = new FornecedorNegocios();
        readonly EmpresaNegocios empresaNegocios = new EmpresaNegocios();
        readonly TabelaIBPTNegocios tabelaIBPTNegocios = new TabelaIBPTNegocios();

        #endregion

        #region Variáveis

        int produtosId = 0;
        int fornecedorId = 0;
        int tributacaoFiscalId = 0;
        int tabelaIBPTId = 0;
        string estoqueAtual = string.Empty;
        DataTable dtGrid = new DataTable();

        #endregion

        #region Métodos

        private bool ValidaCampos()
        {
            string erros = string.Empty;

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erros = "Informe: Descrição do Produto.";
            }
            if (string.IsNullOrEmpty(txtNCM.Text))
            {
                erros += "\nInforme: Classificação Fiscal (NCM).";
            }
            if (string.IsNullOrEmpty(cbbUnidadeMedida.Text))
            {
                erros += "\nInforme: Unidade de Medida.";
            }
            if (string.IsNullOrEmpty(cbbGrupoProdutos.Text))
            {
                erros += "\nInforme: Grupo de Produto.";
            }
            if (txtDescricaoGrupoImposto.Text == "SELECIONE O GRUPO DE IMPOSTO")
            {
                erros += "\nInforme: Grupo de Imposto Fiscal.";
            }
            if (!string.IsNullOrEmpty(erros))
            {
                MessageBox.Show("Os seguintes campos não foram informados!: \n\n" + erros, "Aviso do sistema!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
                return true;
        }


        public bool ValidarCodigoDeBarras(string codigoBarras)
        {
            bool existe = false;
            string mensagem = string.Empty;

            //Verifica se já existe o Código de Barras informado
            Produtos produtos = produtosNegocios.VerificaSeJaTemCodigoBarrasInformado(codigoBarras);
            existe = (produtos.ProdutosId > 0 && produtos.ProdutosId != Convert.ToInt32(produtosId));
            if (existe)
                MessageBox.Show("Já existe um produto com o Código de Barra informado!\n\nProduto cadastrado: Código:" + produtos.ProdutosId + " - Descrição: " + produtos.Descricao + "", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //Verifica se o código de barras é igual ao principal.
            if (txtCodigoBarras.Text == produtosId.ToString())
            {
                existe = true;
                MessageBox.Show("O Código de Barras informado é igual ao código do produto!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return existe;
        }

        private void CarregarGrid()
        {
            try
            {
                dtGrid = produtosNegocios.CarregarGrid();
                grid.DataSource = dtGrid;
                PintarCelulaEstoque();

                produtosId = 0;
                lblQuantidade.Text = grid.Rows.Count + " Produtos encontrado(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar carregar os Produtos cadastrados.\n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PintarCelulaEstoque()
        {
            foreach (DataGridViewRow r in grid.Rows)
            {
                if (Convert.ToInt32(r.Cells["EstoqueAtual_"].Value) > 0)
                    r.Cells["EstoqueAtual_"].Style.ForeColor = Color.Green;
                else
                    r.Cells["EstoqueAtual_"].Style.ForeColor = Color.Red;

                if (r.Cells["Ativo"].Value.ToString() == "Inativo")
                {
                    r.DefaultCellStyle.ForeColor = Color.DarkGray;
                    r.Cells["EstoqueAtual_"].Style.ForeColor = Color.DarkGray;
                }
            }
        }

        private void HabilitaCampos(bool ativa)
        {
            txtDescricao.Enabled = ativa;
            chkAtivo.Enabled = ativa;
            btnGerarCodigoBarras.Enabled = ativa;
            txtCodigoBarras.Enabled = ativa;
            cbbUnidadeMedida.Enabled = ativa;
            cbbGrupoProdutos.Enabled = ativa;
            btnGrupoProdutos.Enabled = ativa;
            cbbSubgrupoProdutos.Enabled = ativa;
            btnSubgrupoProdutos.Enabled = ativa;
            btnFornecedor.Enabled = ativa;
            btnGrupoImposto.Enabled = ativa;
            txtValorCompra.Enabled = ativa;
            txtValorVenda.Enabled = ativa;
            txtValorUnitario.Enabled = ativa;
            txtEstoqueInicial.Enabled = ativa;
            txtEstoqueMinimo.Enabled = ativa;
            txtEstoqueMaximo.Enabled = ativa;
            txtEstoqueInicial.Enabled = ativa;
            txtObservacao.Enabled = ativa;
            cbbMovimentacaoProduto.Enabled = false;
            txtNCM.Enabled = ativa;
            btnNCM.Enabled = ativa;

            txtDescricao.Focus();
        }

        private void Limpar()
        {
            txtDescricao.Clear();
            chkAtivo.Checked = true;
            txtCodigoBarras.Clear();
            cbbUnidadeMedida.SelectedIndex = -1;
            cbbGrupoProdutos.SelectedIndex = -1;
            cbbSubgrupoProdutos.SelectedIndex = -1;
            txtDescricaoGrupoImposto.Text = "SELECIONE O GRUPO DE IMPOSTO";
            txtFornecedor.Text = "SELECIONE O FORNECEDOR";
            txtValorCompra.Text = "0,00";
            txtValorVenda.Text = "0,00";
            txtValorUnitario.Text = "0,00";
            txtEstoqueInicial.Text = "0";
            txtEstoqueMinimo.Text = "0";
            txtEstoqueMaximo.Text = "0";
            txtQuantidadeCompra.Text = "0";
            txtValorTotal.Text = "0,00";
            txtEstoqueAtual.Text = "0";
            txtObservacao.Clear();
            cbbMovimentacaoProduto.SelectedIndex = -1;
            txtPesquisar.Clear();
            txtNCM.Clear();

            tabControl.SelectedIndex = 0;
        }

        private void CarregarUnidadeMedida()
        {
            try
            {
                UnidadeMedidaNegocios unidadeMedidaNegocios = new UnidadeMedidaNegocios();
                cbbUnidadeMedida.DataSource = unidadeMedidaNegocios.PesquisarPorNome(string.Empty);

                cbbUnidadeMedida.DisplayMember = "Descricao";
                cbbUnidadeMedida.ValueMember = "UnidadeMedidaId";
                cbbUnidadeMedida.SelectedIndex = 0;
            }
            catch
            { }
        }

        private void CarregarGrupos()
        {
            try
            {
                GrupoProdutosNegocios grupoProdutosNegocios = new GrupoProdutosNegocios();
                cbbGrupoProdutos.DataSource = grupoProdutosNegocios.PesquisarPorNome(string.Empty);

                cbbGrupoProdutos.DisplayMember = "Descricao";
                cbbGrupoProdutos.ValueMember = "grupoProdutosId";
                cbbGrupoProdutos.SelectedIndex = 0;
            }
            catch
            { }
        }

        private void CarregarSubgrupoProdutos()
        {
            try
            {
                SubgrupoProdutosNegocios subgrupoProdutosNegocios = new SubgrupoProdutosNegocios();
                cbbSubgrupoProdutos.DataSource = subgrupoProdutosNegocios.PesquisarPorCodigo((int)cbbGrupoProdutos.SelectedValue);

                cbbSubgrupoProdutos.DisplayMember = "Descricao";
                cbbSubgrupoProdutos.ValueMember = "SubgrupoProdutosId";
                cbbSubgrupoProdutos.SelectedIndex = 0;
            }
            catch
            { }
        }

        #endregion

        private void FrmProdutos_Load(object sender, EventArgs e)
        {
            CarregarUnidadeMedida();
            CarregarGrupos();
            CarregarGrid();
            //carregar configuracoes
            //carregar permissoes

            tabControl.SelectedIndex = 1;
            txtPesquisar.Select();
            txtPesquisar.Focus();

        }

        private void FrmProdutos_KeyDown(object sender, KeyEventArgs e)
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
        }

        #region Botões menu

        private void btnNovo_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 0)
                tabControl.SelectedIndex = 0;

            if (btnSalvar.Enabled == false)
            {
                HabilitaCampos(true);
                Limpar();
                btnNovo.Text = "Cancelar [ F2 ]";
                toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                btnSalvar.Enabled = true;
            }
            else
            {
                HabilitaCampos(false);
                btnNovo.Text = "Novo [ F2 ]";
                btnSalvar.Text = "Salvar [ F5 ]";
                toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                toolTip.SetToolTip(this.btnNovo, "Novo Produto [ F2 ]");
                btnSalvar.Enabled = false;
                btnExcluir.Enabled = false;
                btnPesquisar.Enabled = true;
                tabControl.SelectedIndex = 0;
            }

            txtQuantidadeCompra.Enabled = false;
            txtValorTotal.Enabled = false;
            txtEstoqueAtual.Enabled = false;
            produtosId = 0;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidaCampos())
                {
                    if (string.IsNullOrEmpty(txtDescricao.Text))
                    {
                        MessageBox.Show("Por favor, informe a descrição do Produto!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDescricao.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(txtNCM.Text))
                    {
                        MessageBox.Show("Por favor, informe a classificação fiscal do Produto!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnNCM.Focus();
                        return;
                    }

                    if (string.IsNullOrEmpty(cbbUnidadeMedida.Text))
                    {
                        MessageBox.Show("Por favor, informe a classificação fiscal do Produto!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnNCM.Focus();
                        return;
                    }


                    #region Verifica se o Código de Barras já não está cadastrado ou se é igual ao Código do produto

                    if (!string.IsNullOrEmpty(txtCodigoBarras.Text))
                    {
                        try
                        {
                            if (ValidarCodigoDeBarras(txtCodigoBarras.Text.Trim()))
                            {
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar verificar se o Código de Barras já existe cadastrado!" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    #endregion


                    Produtos produtos = new Produtos();

                    produtos.Descricao = txtDescricao.Text.Trim();
                    if (tabelaIBPTId > 0)
                        produtos.TabelaIBPTId = tabelaIBPTId;
                    produtos.Ativo = chkAtivo.Checked;
                    produtos.CodigoBarras = txtCodigoBarras.Text.Trim();
                    produtos.UnidadeMedidaId = Convert.ToInt32(cbbUnidadeMedida.SelectedValue);
                    produtos.GrupoProdutosId = Convert.ToInt32(cbbGrupoProdutos.SelectedValue);
                    produtos.SubgrupoProdutosId = Convert.ToInt32(cbbSubgrupoProdutos.SelectedValue);
                    if (tributacaoFiscalId > 0)
                        produtos.TributacaoFiscalId = tributacaoFiscalId;
                    if (fornecedorId > 0)
                        produtos.FornecedorId = fornecedorId;
                    produtos.ValorCompra = !string.IsNullOrEmpty(txtValorCompra.Text) ? Convert.ToDecimal(txtValorCompra.Text) : 0;
                    produtos.ValorVenda = !string.IsNullOrEmpty(txtValorVenda.Text) ? Convert.ToDecimal(txtValorVenda.Text) : 0;
                    produtos.ValorUnitario = !string.IsNullOrEmpty(txtValorUnitario.Text) ? Convert.ToDecimal(txtValorUnitario.Text) : 0;

                    produtos.EstoqueInicial = !string.IsNullOrEmpty(txtEstoqueInicial.Text) ? Convert.ToInt32(txtEstoqueInicial.Text) : 0;
                    if (produtosId <= 0)
                        produtos.EstoqueAtual = produtos.EstoqueInicial;
                    else
                    {
                        produtos.EstoqueAtual = !string.IsNullOrEmpty(txtEstoqueAtual.Text) ? Convert.ToInt32(txtEstoqueAtual.Text) : produtos.EstoqueInicial;
                        produtosNegocios.ReporEstoque(Convert.ToInt32(txtEstoqueAtual.Text), produtosId);
                    }
                    produtos.EstoqueMinimo = !string.IsNullOrEmpty(txtEstoqueMinimo.Text) ? Convert.ToInt32(txtEstoqueMinimo.Text) : 0;
                    produtos.EstoqueMaximo = !string.IsNullOrEmpty(txtEstoqueMaximo.Text) ? Convert.ToInt32(txtEstoqueMaximo.Text) : 0;
                    produtos.Observacao = txtObservacao.Text.Trim();
                    produtos.DataCadastro = Convert.ToDateTime(dtpDataCadastro.Value.ToString("dd/MM/yyyy HH:mm:ss"));
                    produtos.UltimaCompra = Convert.ToDateTime(dtpUltimaCompra.Value.ToString("dd/MM/yyyy HH:mm:ss"));

                    //INSERIR
                    if (produtosId <= 0)
                    {
                        try
                        {
                            if (produtosNegocios.Inserir(produtos))
                            {
                                MessageBox.Show("Produto cadastrado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpar();
                                HabilitaCampos(false);
                                btnSalvar.Text = "Salvar [ F5 ]";
                                btnSalvar.Enabled = false;
                                btnExcluir.Enabled = false;
                                btnNovo.Text = "Novo [ F2 ]";
                                CarregarGrid();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar cadastrar o produto!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else //ALTERAR
                    {
                        try
                        {
                            produtos.ProdutosId = produtosId;

                            if (produtosNegocios.Alterar(produtos))
                            {
                                MessageBox.Show("Produto alterado com sucesso!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Limpar();
                                HabilitaCampos(false);
                                btnSalvar.Text = "Salvar [ F5 ]";
                                btnSalvar.Enabled = false;
                                btnExcluir.Enabled = false;
                                btnNovo.Text = "Novo [ F2 ]";
                                CarregarGrid();

                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao tentar alterar o produto selecionado!\n\nDetalhe técnico: " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    produtosId = 0;
                    toolTip.SetToolTip(this.btnSalvar, "Salvar [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Novo cadastro [ F2 ]");
                    btnPesquisar_Click(sender, e);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao tentar cadastrar o produto!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (grid.SelectedRows.Count > 0)
            {
                try
                {
                    Produtos produtos = new Produtos();
                    produtos.ProdutosId = produtosId;

                    if (MessageBox.Show("Deseja realmente excluir o Produto selecionado?", "Pergunta do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (produtosNegocios.Excluir(produtos))
                        {
                            //Inserir Logs
                            MessageBox.Show("Produto excluído com sucesso!", "Aviso do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpar();
                            HabilitaCampos(false);
                            btnSalvar.Text = "Salvar [ F5 ]";
                            btnSalvar.Enabled = false;
                            btnExcluir.Enabled = false;
                            btnNovo.Text = "Novo [ F2 ]";
                            fornecedorId = 0;
                            CarregarGrid();
                            tabControl.SelectedIndex = 1;
                        }
                    }
                    else
                    {
                        Limpar();
                        HabilitaCampos(false);
                        if (grid.Rows.Count > 0)
                            btnExcluir.Enabled = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar excluir o Produto!\n\nDetalhe técnico : " + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex != 1)
            {
                Limpar();
                tabControl.SelectedIndex = 1;
                txtPesquisar.Focus();
            }
        }


        #endregion

        #region Eventos TabPag Produtos Cadastrados

        private void txtPesquisar_TextChanged(object sender, EventArgs e)
        {
            DataView dv = new DataView(dtGrid);

            dv.RowFilter = "((CONVERT(ProdutosId, 'System.String') = '" + txtPesquisar.Text.Replace("'", "") + "') OR (Descricao like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (CodigoBarras like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (UnidadeMedida like '%" + txtPesquisar.Text.Replace("'", "") + "%') OR (Fornecedor like '%" + txtPesquisar.Text.Replace("'", "") + "%'))";
            grid.DataSource = dv;

            lblQuantidade.Text = grid.Rows.Count + " Produtos encontrado(s)";

            //if (grid.Rows.Count <= 10000)
            //    ColorirCelulasEstoque();
        }

        private void txtPesquisar_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Down) && grid.Rows.Count > 0)
            {
                e.SuppressKeyPress = true;
                grid.Focus();
            }
        }

        private void grid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                grid_DoubleClick(sender, e);
            else if (e.KeyCode == Keys.Up && grid.CurrentRow.Index == 0)
            {
                txtPesquisar.Select();
                txtPesquisar.Focus();
            }
        }

        private void grid_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (grid.Rows.Count > 0)
                {
                    produtosId = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["ProdutosId_"].Value);
                    txtCodigoBarras.Text = grid.Rows[grid.CurrentRow.Index].Cells["CodigoBarras"].Value.ToString();
                    txtDescricao.Text = grid.Rows[grid.CurrentRow.Index].Cells["Descricao"].Value.ToString();

                    tabelaIBPTId = string.IsNullOrEmpty(grid.Rows[grid.CurrentRow.Index].Cells["TabelaIBPTId_"].Value.ToString()) ? 0 : Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TabelaIBPTId_"].Value);
                    if (tabelaIBPTId > 0)
                        txtNCM.Text = grid.Rows[grid.CurrentRow.Index].Cells["NCM"].Value.ToString();

                    string Ativo = grid.Rows[grid.CurrentRow.Index].Cells["Ativo"].Value.ToString();
                    if (Ativo.Equals("Ativo"))
                        chkAtivo.Checked = true;
                    else
                        chkAtivo.Checked = false;

                    cbbUnidadeMedida.SelectedValue = grid.Rows[grid.CurrentRow.Index].Cells["UnidadeMedidaId"].Value.ToString();
                    cbbGrupoProdutos.SelectedValue = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["GrupoProdutosId"].Value);
                    cbbGrupoProdutos_SelectedIndexChanged(sender, e);

                    tributacaoFiscalId = string.IsNullOrEmpty(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value.ToString()) ? 0 : Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["TributacaoFiscalId_"].Value);
                    if (tributacaoFiscalId > 0)
                        txtDescricaoGrupoImposto.Text = grid.Rows[grid.CurrentRow.Index].Cells["DescricaoTributacaoFiscal"].Value.ToString();

                    fornecedorId = string.IsNullOrEmpty(grid.Rows[grid.CurrentRow.Index].Cells["FornecedorId_"].Value.ToString()) ? 0 : Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["FornecedorId_"].Value);
                    if (fornecedorId > 0)
                        txtFornecedor.Text = grid.Rows[grid.CurrentRow.Index].Cells["Fornecedor"].Value.ToString();

                    txtValorCompra.Text = Convert.ToDecimal(grid.Rows[grid.CurrentRow.Index].Cells["ValorCompra"].Value).ToString("N2");
                    txtValorVenda.Text = Convert.ToDecimal(grid.Rows[grid.CurrentRow.Index].Cells["ValorVenda"].Value).ToString("N2");
                    txtValorUnitario.Text = Convert.ToDecimal(grid.Rows[grid.CurrentRow.Index].Cells["ValorUnitario"].Value).ToString("N2");
                    txtEstoqueInicial.Text = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["EstoqueInicial"].Value).ToString();
                    txtEstoqueMinimo.Text = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["EstoqueMinimo"].Value).ToString();
                    txtEstoqueMaximo.Text = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["EstoqueMaximo"].Value).ToString();
                    txtObservacao.Text = grid.Rows[grid.CurrentRow.Index].Cells["Observacao"].Value.ToString();
                    dtpDataCadastro.Text = grid.Rows[grid.CurrentRow.Index].Cells["DataCadastro"].Value.ToString();
                    dtpUltimaCompra.Text = grid.Rows[grid.CurrentRow.Index].Cells["UltimaCompra"].Value.ToString();
                    txtEstoqueAtual.Text = estoqueAtual = Convert.ToInt32(grid.Rows[grid.CurrentRow.Index].Cells["EstoqueAtual_"].Value).ToString();

                    HabilitaCampos(true);
                    btnSalvar.Text = "Alterar [ F5 ]";
                    btnNovo.Text = "Cancelar [ F2 ]";
                    toolTip.SetToolTip(this.btnSalvar, "Alterar Cadastro [ F5 ]");
                    toolTip.SetToolTip(this.btnNovo, "Cancelar [ F2 ]");
                    btnSalvar.Enabled = true;
                    btnExcluir.Enabled = true;

                    txtQuantidadeCompra.Enabled = cbbMovimentacaoProduto.Enabled = true;
                    txtQuantidadeCompra.Text = "0";
                    txtValorTotal.BackColor = txtEstoqueAtual.BackColor = Color.White;
                    if (txtEstoqueInicial.Text == "0")
                        txtEstoqueInicial.Enabled = true;
                    else
                        txtEstoqueInicial.Enabled = false;

                    tabControl.SelectedIndex = 0;
                    txtDescricao.Focus();

                    #region Informa se está com Estoque abaixo do minímo

                    if (Convert.ToInt32(txtEstoqueAtual.Text) < Convert.ToInt32(txtEstoqueMinimo.Text))
                    {
                        txtEstoqueAtual.ForeColor = Color.Red;
                        txtEstoqueMinimo.ForeColor = Color.Red;
                        toolTip.SetToolTip(this.txtEstoqueAtual, "Produto abaixo do estoque minímo, reponha seu estoque!");
                        MessageBox.Show("Produto abaixo do estoque minímo, reponha seu estoque!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtQuantidadeCompra.Focus();
                    }
                    else
                    {
                        txtEstoqueAtual.ForeColor = Color.Black;
                        txtEstoqueMinimo.ForeColor = Color.Black;
                        toolTip.SetToolTip(this.txtEstoqueAtual, "");
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao executar operação solicitada! \n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Eventos Quantidade de Compra

        private void txtQuantidadeCompra_Enter(object sender, EventArgs e)
        {
            if (txtQuantidadeCompra.Text.Trim() == "0")
                txtQuantidadeCompra.Clear();
            else
            {
                txtQuantidadeCompra.SelectAll();
                txtQuantidadeCompra.Focus();
            }
        }

        private void txtQuantidadeCompra_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtQuantidadeCompra.Text.Trim() == "0")
                txtQuantidadeCompra.Clear();
            else
            {
                txtQuantidadeCompra.SelectAll();
                txtQuantidadeCompra.Focus();
            }
        }

        private void txtQuantidadeCompra_Leave(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtQuantidadeCompra.Text))
                    txtQuantidadeCompra.Text = "0";

                if (!string.IsNullOrEmpty(txtQuantidadeCompra.Text.Trim()))
                {
                    txtValorTotal.Text = (Convert.ToInt32(txtQuantidadeCompra.Text) * Convert.ToDecimal(txtValorUnitario.Text)).ToString("N2");
                    txtEstoqueAtual.Text = (Convert.ToInt32(txtQuantidadeCompra.Text) + Convert.ToInt32(estoqueAtual)).ToString();

                    //ESTOQUE MÁXIMO
                    if (txtEstoqueMaximo.Text != "0")
                    {
                        if (Convert.ToInt32(txtEstoqueAtual.Text) > Convert.ToInt32(txtEstoqueMaximo.Text))
                        {
                            txtEstoqueAtual.ForeColor = Color.Blue;
                            txtEstoqueMaximo.ForeColor = Color.Blue;
                            txtEstoqueMinimo.ForeColor = Color.Black;
                            toolTip.SetToolTip(this.txtEstoqueAtual, "Produto ultrapassou o estoque máximo permitido!");
                            MessageBox.Show("Produto ultrapassou o estoque máximo permitido!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSalvar.Enabled = false;
                            return;
                        }
                        else
                        {
                            txtEstoqueAtual.ForeColor = Color.Black;
                            txtEstoqueMaximo.ForeColor = Color.Black;
                            toolTip.SetToolTip(this.txtEstoqueAtual, "");
                            btnSalvar.Enabled = true;
                        }
                    }

                    ////ESTOQUE MINÍMO
                    if (txtEstoqueMinimo.Text != "0")
                    {
                        if (Convert.ToInt32(txtEstoqueAtual.Text) < Convert.ToInt32(txtEstoqueMinimo.Text))
                        {
                            txtEstoqueAtual.ForeColor = Color.Red;
                            txtEstoqueMinimo.ForeColor = Color.Red;
                            txtEstoqueMaximo.ForeColor = Color.Black;
                            toolTip.SetToolTip(this.txtEstoqueAtual, "Produto abaixo do estoque minímo, reponha seu estoque!");
                            MessageBox.Show("Produto abaixo do estoque minímo, reponha seu estoque!", "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnSalvar.Enabled = false;
                            return;
                        }
                        else
                        {
                            txtEstoqueAtual.ForeColor = Color.Black;
                            txtEstoqueMinimo.ForeColor = Color.Black;
                            toolTip.SetToolTip(this.txtEstoqueAtual, "");
                            btnSalvar.Enabled = true;
                        }
                    }
                }
                else
                {
                    txtQuantidadeCompra.Text = "0";
                    txtValorTotal.Text = "0,00";
                    txtEstoqueAtual.Text = estoqueAtual;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao cálcular o total do produto! \n\n" + ex.Message, "Aviso do Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQuantidadeCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        #endregion

        #region Eventos KeyPress - Campos decimais

        private void txtValorCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtValorVenda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtValorUnitario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtEstoqueInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtEstoqueMinimo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        private void txtEstoqueMaximo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar.ToString() == "\b" || e.KeyChar.ToString().Equals(","))
                base.OnKeyPress(e);
            else
                e.Handled = true;
        }

        #endregion

        #region Botão Gerar Código de Barras

        private void btnGerarCodigoBarras_Click(object sender, EventArgs e)
        {
            try
            {
                txtCodigoBarras.Text = produtosNegocios.GerarCodigoBarras();
                cbbUnidadeMedida.Focus();
            }
            catch
            { }
        }

        #endregion

        #region NCM - Tabela IBPT

        #endregion
        private void btnNCM_Click(object sender, EventArgs e)
        {
            try
            {
                FrmTabelaIBPT frmTabelaIBPT = new FrmTabelaIBPT();
                frmTabelaIBPT.ShowInTaskbar = false;
                frmTabelaIBPT.ShowDialog();

                if (!string.IsNullOrEmpty(frmTabelaIBPT._NCM))
                {
                    tabelaIBPTId = frmTabelaIBPT._TabelaIBPTId;
                    txtNCM.Text = frmTabelaIBPT._NCM;
                }
                else
                {
                    tabelaIBPTId = 0;
                    txtNCM.Clear();
                }

                txtCodigoBarras.Focus();
            }
            catch
            { }
        }


        private void btnFornecedor_Click(object sender, EventArgs e)
        {
            try
            {
                FrmFornecedor frmFornecedor = new FrmFornecedor();
                frmFornecedor._Pesquisando = true;
                frmFornecedor.ShowDialog();

                if (frmFornecedor._FornecedorId > 0)
                {
                    fornecedorId = frmFornecedor._FornecedorId;
                    txtFornecedor.Text = frmFornecedor._Nome;
                }
                else
                {
                    fornecedorId = 0;
                    txtFornecedor.Text = "SELECIONE O FORNECEDOR";
                }

                txtObservacao.Focus();
            }
            catch
            { }
        }

        private void btnGrupoProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmGrupoProdutos frmGrupoProdutos = new FrmGrupoProdutos();
                frmGrupoProdutos.ShowDialog();

                CarregarGrupos();
                cbbSubgrupoProdutos.Focus();
            }
            catch
            { }
        }

        private void cbbGrupoProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarSubgrupoProdutos();
        }

        private void btnSubgrupoProdutos_Click(object sender, EventArgs e)
        {
            try
            {
                FrmSubgrupoProdutos FrmSubgrupoProdutos = new FrmSubgrupoProdutos();
                FrmSubgrupoProdutos.ShowDialog();

                CarregarSubgrupoProdutos();
                btnFornecedor.Focus();
            }
            catch
            { }
        }

        private void btnGrupoImposto_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtEmpresa = new DataTable();
                dtEmpresa = empresaNegocios.PesquisarEmpresa();

                FrmGerenciamentoTributario frmGerenciamentoTributario = new FrmGerenciamentoTributario(Convert.ToInt32(dtEmpresa.Rows[0]["RegimeTributario"]));
                frmGerenciamentoTributario.ShowInTaskbar = false;
                frmGerenciamentoTributario.pesquisaExterna = true;
                frmGerenciamentoTributario.Height = 496;
                frmGerenciamentoTributario.ShowDialog();

                if (frmGerenciamentoTributario._TributacaoFiscalId > 0)
                {
                    tributacaoFiscalId = frmGerenciamentoTributario._TributacaoFiscalId;
                    txtDescricaoGrupoImposto.Text = frmGerenciamentoTributario._Descricao;
                }
                else
                {
                    tributacaoFiscalId = 0;
                    txtDescricaoGrupoImposto.Text = "SELECIONE O GRUPO DE IMPOSTO";
                }

                txtValorCompra.Focus();
            }
            catch
            { }
        }

    }
}
