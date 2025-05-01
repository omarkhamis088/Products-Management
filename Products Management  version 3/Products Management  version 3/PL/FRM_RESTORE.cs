using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Products_Management__version_3.PL
{
    public partial class FRM_RESTORE : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I2ECNM1\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
        SqlCommand cmd;

        public FRM_RESTORE()
        {
            InitializeComponent();
        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string strQuery = "ALTER Database Product_DB SET OFFLINE WITH ROLLBACK IMMEDIATE; Restore Database Product_DB from Disk='" + txtFileName.Text + "'";
            cmd = new SqlCommand(strQuery, con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم إستعادة نسخة إحتياطية بنجاح", "إستعادة نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
