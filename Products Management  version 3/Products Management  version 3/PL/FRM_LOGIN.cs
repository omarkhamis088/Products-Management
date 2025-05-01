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
    public partial class FRM_LOGIN : Form
    {
        
        BL.CLS_LOGIN log = new BL.CLS_LOGIN();
        public FRM_LOGIN()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable Dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (Dt.Rows.Count > 0)
            {
                if (Dt.Rows[0][2].ToString() == "administrator")
                {
                    FRM_MAIN.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.الموظفينToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.الموظفينToolStripMenuItem.Visible = true;

                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();

                    this.Close();
                }
                else if (Dt.Rows[0][2].ToString() == "user") 
                {

                    FRM_MAIN.getMainForm.المنتجاتToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.العملاءToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.الموظفينToolStripMenuItem.Visible = false;
                    FRM_MAIN.getMainForm.إنشاءنسخةإحتياطيةToolStripMenuItem.Enabled = true;
                    FRM_MAIN.getMainForm.استعادةنسخةاحتياطيةToolStripMenuItem.Enabled = true;
                    Program.SalesMan = Dt.Rows[0]["FullName"].ToString();
                    this.Close();
    
               
                }


                PL.FRM_MAIN frm = new PL.FRM_MAIN();
                frm.Close_form_form_login();
    
            }
            else
            {
                MessageBox.Show("Filed Access");
            }
        }

        
    }
}
