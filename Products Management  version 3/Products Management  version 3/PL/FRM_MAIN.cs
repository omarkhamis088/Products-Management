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
    public partial class FRM_MAIN : Form
    {
        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////   
        /// المحاظرة 11 start
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// 
        //single instance
        private static FRM_MAIN frm;

        internal void Close_form_form_login()
        {

            this.Close();
        }

      public  static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }

        public static FRM_MAIN getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_MAIN();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                }
                return frm;
            }

        }

        /// <summary>
        /// /////////////////////////////////////////////////////////////////////////////////   
        /// المحاظرة 11 end
        /// ////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public FRM_MAIN()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.المنتجاتToolStripMenuItem.Enabled = false;
            this.العملاءToolStripMenuItem.Enabled = false;
            this.الموظفينToolStripMenuItem.Enabled = false;

            this.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = false;
            this.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = false;

        }

        private void تسجيلالدخولToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_LOGIN frm = new FRM_LOGIN();
            frm.ShowDialog();
        }

        private void تسجيلالخروجToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void إضافةمنتجToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void إدارةالمنتجاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FRM_PRODUCTS frm = new FRM_PRODUCTS();
            frm.ShowDialog();
        }

        private void إدارةالأصنافToolStripMenuItem_Click(object sender, EventArgs e)
        {
           FRM_CATEGRIES frm = new FRM_CATEGRIES();
            frm.ShowDialog();
        }

        private void إضافةعميلToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void إدارةملفاتالعملاءToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CUSTOMERS frm = new FRM_CUSTOMERS();
            frm.ShowDialog();
        }

        private void إضافةبيعجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS frm = new FRM_ORDERS();
            frm.ShowDialog();
        }

        private void إدارةالمبيعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ORDERS_LIST frm = new FRM_ORDERS_LIST();
            frm.ShowDialog();
        }

        private void إضافةموظفجديدToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.ShowDialog();
        }

        private void إدارةملفاتالموظفينToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_USERS_LIST frm = new FRM_USERS_LIST();
            frm.ShowDialog();
        }

        private void إنشاءنسخةإحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_BACUP frm = new FRM_BACUP();
            frm.ShowDialog();
        }

        private void استعادةنسخةاحتياطيةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_RESTORE frm = new FRM_RESTORE();
            frm.ShowDialog();
        }

        private void إعداداتالإتصالبالسيرفرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FRM_CONFIG frm = new FRM_CONFIG();
            frm.ShowDialog();

        }


    }
}
