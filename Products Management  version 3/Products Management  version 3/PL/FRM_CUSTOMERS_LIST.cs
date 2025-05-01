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
    public partial class FRM_CUSTOMERS_LIST : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        public FRM_CUSTOMERS_LIST()
        {
            InitializeComponent();
            this.dgCustomers.DataSource = cust.GET_ALL_CUSTOMER();
            dgCustomers.Columns[0].Visible = false;
            dgCustomers.Columns[5].Visible = false;
        }

        private void dgCustomers_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
