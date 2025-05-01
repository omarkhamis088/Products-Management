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
    public partial class FRM_PRODUCTS_LIST : Form
    {
        BL.CLS_PRODUCT prd = new BL.CLS_PRODUCT();
        public FRM_PRODUCTS_LIST()
        {
            InitializeComponent();
            this.dgvProducts.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void dgvProducts_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
