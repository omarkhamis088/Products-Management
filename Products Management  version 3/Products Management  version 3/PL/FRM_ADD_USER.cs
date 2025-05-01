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
    public partial class FRM_ADD_USER : Form
    {
        BL.CLS_LOGIN user = new BL.CLS_LOGIN() ;

       
        public FRM_ADD_USER()
        {
            InitializeComponent();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (txtID.Text == string.Empty || txtFullName.Text == string.Empty
                || txtPWD.Text == string.Empty || txtPWDConfirm.Text == string.Empty)
            {
                MessageBox.Show("الرجاء ادخال جميع البيانات", "إضافة مستخدم جديد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("كلمة المرور غير متطابقة", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPWD.Focus();
                return;
                
            }

            if (btnAddUser.Text == "إضافة المستخدم")
            {
                
                user.ADD_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تمت الإضافة بنجاح", "إضافة مستخدم جديد", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
              
                txtID.Clear();
                txtFullName.Clear();
                txtPWD.Clear();
                txtPWDConfirm.Clear();
                txtID.Focus();
            }
            else if (btnAddUser.Text == "تعديل المستخدم")
            {

                user.EDIT_USER(txtID.Text, txtFullName.Text, txtPWD.Text, cmbType.Text);
                MessageBox.Show("تمت التعديل بنجاح", "تعديل مستخدم جديد", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            
           
        }

        private void txtPWDConfirm_Validated(object sender, EventArgs e)
        {
            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                MessageBox.Show("كلمة المرور غير متطابقة","خطأ",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtPWD.Focus();
                return;
                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
