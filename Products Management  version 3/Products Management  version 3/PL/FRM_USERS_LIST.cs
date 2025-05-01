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
    public partial class FRM_USERS_LIST : Form
    {
        BL.CLS_LOGIN login = new BL.CLS_LOGIN();
        public FRM_USERS_LIST()
        {
            InitializeComponent();
            this.dgvUsers.DataSource = login.SreachUsers("");
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            frm.btnAddUser.Text = "إضافة المستخدم";
            frm.ShowDialog();
            this.dgvUsers.DataSource = login.SreachUsers("");
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            FRM_ADD_USER frm = new FRM_ADD_USER();
            
            frm.txtID.Text = dgvUsers.CurrentRow.Cells[0].Value.ToString();
            frm.txtFullName.Text = dgvUsers.CurrentRow.Cells[1].Value.ToString();
            frm.txtPWD.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.txtPWDConfirm.Text = dgvUsers.CurrentRow.Cells[2].Value.ToString();
            frm.cmbType.Text = dgvUsers.CurrentRow.Cells[3].Value.ToString();
            frm.btnAddUser.Text = "تعديل المستخدم";
            frm.txtID.Enabled = false;
            frm.ShowDialog();
            

            this.dgvUsers.DataSource = login.SreachUsers("");

        }
        
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            this.dgvUsers.DataSource = login.SreachUsers(txtSearch.Text);
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل تريد تأكيد حذف المستخدم","حذف مستخدم",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                login.DELETE_USER(dgvUsers.CurrentRow.Cells[0].Value.ToString());
                MessageBox.Show("تمت عملية الحذف بنجاح","حذف مستخدم",MessageBoxButtons.OK,MessageBoxIcon.Information);
                this.dgvUsers.DataSource = login.SreachUsers("");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
