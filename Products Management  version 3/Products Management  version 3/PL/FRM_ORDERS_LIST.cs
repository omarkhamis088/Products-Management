using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Products_Management__version_3.PL
{
    public partial class FRM_ORDERS_LIST : Form
    {
        BL.CLS_ORDERS orders = new BL.CLS_ORDERS();
        public FRM_ORDERS_LIST()
        {
            InitializeComponent();
            this.dgvOrders.DataSource = orders.SearchOrders("");
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvOrders.DataSource = orders.SearchOrders(txtSearch.Text);
            }
            catch
            {
                return;
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // get the last order 
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int order_ID = Convert.ToInt32(dgvOrders.CurrentRow.Cells[0].Value);
                RPT.rpt_orders report = new RPT.rpt_orders();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();

                report.SetDataSource(orders.GetOrderDetailsForPrint());
                frm.crystalReportViewer1.ReportSource = report;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
                this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FRM_ORDERS_LIST_Load(object sender, EventArgs e)
        {

        }
    }
}
