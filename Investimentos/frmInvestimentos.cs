using GridAndChartStyleLibrary;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataLayer;

namespace Investimentos {
    public partial class frmInvestimentos : Form {
        public frmInvestimentos() {
            InitializeComponent();
        }

        private void frmInvestimentos_Load(object sender, EventArgs e) {
            // Remove extra columns that "magically" appears in dgvVendas
            while (dgvVendas.ColumnCount > 14) {
                dgvVendas.Columns.RemoveAt(dgvVendas.ColumnCount - 1);
            }

            dgvOperacoes.Columns[0].Visible = false;
            dgvVendas.Columns[0].Visible = false;
            GridStyles.FormatGrid(dgvAtivos);
            GridStyles.FormatColumn(dgvAtivos.Columns[1], GridStyles.StyleInteger, 70);
            GridStyles.FormatColumns(dgvAtivos, 2, 0, GridStyles.StyleCurrency, 70);

            GridStyles.FormatGrid(dgvOperacoes);
            dgvOperacoes.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvOperacoes, 3, 4, GridStyles.StyleInteger, 70);
            GridStyles.FormatColumns(dgvOperacoes, 5, 6, GridStyles.StyleCurrency, 70);

            GridStyles.FormatGrid(dgvVendas);
            dgvVendas.Columns[1].DefaultCellStyle = GridStyles.StyleDateTime;
            GridStyles.FormatColumns(dgvVendas, new[] {2, 3, 4, 6, 7}, GridStyles.StyleInteger, 69);
            GridStyles.FormatColumns(dgvVendas, new[] {5, 8, 9, 10, 11, 12}, GridStyles.StyleCurrency, 69);

            // 50 = vertical scroll bar width
            var w0 = 50 + dgvAtivos.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w1 = 50 + dgvOperacoes.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);
            var w2 = 50 + dgvVendas.Columns.GetColumnsWidth(DataGridViewElementStates.Visible);

            tableLayoutPanel1.ColumnStyles[0].Width = w0;
            tableLayoutPanel1.ColumnStyles[1].Width = w1;
            Width = 10 + Math.Max(w0 + w1, w2);

            tableLayoutPanel1.RowStyles[0].Height = 8 +
                                                    dgvAtivos.ColumnHeadersHeight +
                                                    11 * dgvAtivos.RowTemplate.Height;

            //----------------
            ContaComboPopulate();
            using (var ctx = new InvestimentosEntities()) {
                if (!ctx.Contas.ToList().Any())
                    OpenFrmConta(0);
            }
        }

        private void ContaComboPopulate() {
            var cbx = toolStripComboBoxConta.ComboBox;
            var currentIndex = cbx.SelectedIndex;
            cbx.DataSource = entityDataSource1.EntitySets["Contas"];
            cbx.DisplayMember = "Nome";
            cbx.ValueMember = "ContaId";
            cbx.SelectedIndex = currentIndex == -1 ? 0 : currentIndex;
        }


        private void toolStripComboBoxConta_SelectedIndexChanged(object sender, EventArgs e) {
            var conta = ((Conta)toolStripComboBoxConta.SelectedItem).ContaId;

            var row = (dgvContas.Rows
                .Cast<DataGridViewRow>()
                .First(r => (int)r.Cells[0].Value == conta)).Index;

            dgvContas.CurrentCell = dgvContas.Rows[row].Cells[0];
        }

        private void dataGridViewVendas_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var frm = new frmAssociarCompraComVenda { VendaId = (int)dgvVendas.SelectedRows[0].Cells[0].Value };
            frm.ShowDialog();
            entityDataSource1.Refresh();
            dgvVendas.Refresh();
        }

        private void dataGridViewOperacoes_CellButtonClick(DataGridView sender, DataGridViewCellEventArgs e) {
            var frm = new frmEditarOperacao { OperacaoId = (int)dgvOperacoes.SelectedRows[0].Cells[0].Value };
            frm.ShowDialog();
            entityDataSource1.SaveChanges();
            entityDataSource1.Refresh();
            dgvOperacoes.Refresh();
        }

        private void dataGridViewOperacoes_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e) {
            var dgv = (DataGridView)sender;
            var col = Convert.ToInt32(dgv.Tag); // coluna com valor que controla a cor
            var row = dgv.Rows[e.RowIndex];
            row.DefaultCellStyle.ForeColor =
                (Convert.ToDecimal(row.Cells[col].Value) < 0) ? Color.Red :
                (e.RowIndex % 2 == 0 ? dgv.DefaultCellStyle.ForeColor :
                dgv.AlternatingRowsDefaultCellStyle.ForeColor);

        }

        private void toolStripButtonNovaOperacao_Click(object sender, EventArgs e) {
            var frm = new frmEditarOperacao {
                OperacaoId = 0,
                Conta = (int)toolStripComboBoxConta.ComboBox.SelectedValue
            };
            frm.ShowDialog();
            entityDataSource1.SaveChanges();
            entityDataSource1.Refresh();
            dgvOperacoes.Refresh();
        }

        private void toolStripButtonResumoVendas_Click(object sender, EventArgs e) {
            var frm = new frmVendas();
            frm.ShowDialog();
        }

        private void toolStripButtonConta_Click(object sender, EventArgs e) {
            var btn = sender as ToolStripButton;
            OpenFrmConta(btn.Name == "toolStripButtonNovaConta"
                ? 0 : (int) toolStripComboBoxConta.ComboBox.SelectedValue);
        }

        private void OpenFrmConta(int id) {
            var frm = new frmConta {
                ContaId = id
            };
            frm.ShowDialog();
            ContaComboPopulate();
        }
    }
}
