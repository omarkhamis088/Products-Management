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
    public partial class FRM_BACUP : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-I2ECNM1\SQLEXPRESS;Initial Catalog=Product_DB;Integrated Security=True");
        SqlCommand cmd;
        public FRM_BACUP()
        {
            InitializeComponent();
        }

        private void FRM_BACUP_Load(object sender, EventArgs e)
        {

        }

        private void btnBrows_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txtFileName.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            string fileName = txtFileName.Text + @"\Product_DB" +"  "+ DateTime.Now.ToShortDateString().Replace('/','-')
                                                                +"  "+ DateTime.Now.ToShortTimeString().Replace(':','-');
            string strQuery = "Backup Database Product_DB to Disk='" + fileName + ".bak'";
            cmd = new SqlCommand(strQuery,con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("تم إنشاء نسخة إحتياطية بنجاح", "إنشاء نسخة إحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
