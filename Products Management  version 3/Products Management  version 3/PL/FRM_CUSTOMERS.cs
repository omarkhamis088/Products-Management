using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Products_Management__version_3.PL
{
    public partial class FRM_CUSTOMERS : Form
    {
        BL.CLS_CUSTOMERS cust = new BL.CLS_CUSTOMERS();
        BindingManagerBase bmb;

        int ID, Position;
        public FRM_CUSTOMERS()
        {
            InitializeComponent();
            this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
            dgList.Columns[0].Visible = false;
            dgList.Columns[5].Visible = false;
            bmb = this.BindingContext[cust.GET_ALL_CUSTOMER()];
           
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
            Navigate(0);
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {

            try
            {
                byte[] Picture;
                if (pbox.Image == null)
                {
                    Picture = new byte[0];
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "whithout_image");
                    MessageBox.Show("تمت الاضافة بنجاح", "إضاقة عميل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    Picture = ms.ToArray();
                    cust.ADD_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "whith_image");
                    MessageBox.Show("تمت الاضافة بنجاح", "إضاقة عميل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
                }
            }
            catch
            {
                MessageBox.Show("لم تتم الاضافة حاول مرة أخرى", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            finally
            {
                btn_Add.Enabled = false;
                btnNew.Enabled = true;
                btnNew.Focus();
            }

        }

        private void pbox_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "ملفات الصور  |*.PNG; *.JPG; *.GIF;*.BMP ";
            if (op.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(op.FileName);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            pbox.Image = null;
            txtFirstName.Focus();
            txtFirstName.Focus();
            btn_Add.Enabled = true;
            btnNew.Enabled = false;
        }
        /// <summary>
        /// /////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLastName.Focus();
            }
        }

        //
        private void txtLastName_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTel.Focus();
            }

        }

        private void txtTel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEmail.Focus();
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btn_Add.Focus();
            }
        }




        /// <summary>
        /// ///////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        private void dgList_Click(object sender, EventArgs e)
        {
            try
            {
                pbox.Image = null;
                ID = Convert.ToInt32(dgList.CurrentRow.Cells[0].Value.ToString());
                this.txtFirstName.Text = dgList.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = dgList.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = dgList.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = dgList.CurrentRow.Cells[4].Value.ToString();
                byte[] picture = (byte[])dgList.CurrentRow.Cells[5].Value;
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }


        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //try
            //{

            if (ID == 0)
            {
                MessageBox.Show("العميل غير موجود ");
                return;
            }
            byte[] Picture;
            if (pbox.Image == null)
            {
                Picture = new byte[0];
                cust.Edit_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "whithout_image", ID);
                MessageBox.Show("تمت التعديل بنجاح", "إضاقة عميل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                Picture = ms.ToArray();
                cust.Edit_CUSTOMER(txtFirstName.Text, txtLastName.Text, txtTel.Text, txtEmail.Text, Picture, "whith_image", ID);

                MessageBox.Show("تمت التعديل بنجاح", "إضاقة عميل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
            }
            //}
            //catch
            //{
            //    MessageBox.Show("لم يتم التعديل حاول مرة أخرى", "خطأ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;

            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("العميل غير موجود ");
                return;
            }

            if (MessageBox.Show("هل انت متأكد", "خذف عميل", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cust.DELETE_CUSTOMER(ID);
                MessageBox.Show("تمت الحذف بنجاح", "حذف عميل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dgList.DataSource = cust.GET_ALL_CUSTOMER();
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgList.DataSource = cust.Search_Customer(txtSearch.Text);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(sender, e);
            }
        }

        //التنقل بين الموظفين
        void Navigate(int Index)
        {
            try
            {
                pbox.Image = null;
                DataTable Dt = cust.GET_ALL_CUSTOMER();
                ID = Convert.ToInt32(Dt.Rows[Index][0]);
                txtFirstName.Text = Dt.Rows[Index][1].ToString();
                txtLastName.Text = Dt.Rows[Index][2].ToString();
                txtTel.Text = Dt.Rows[Index][3].ToString();
                txtEmail.Text = Dt.Rows[Index][4].ToString();

                byte[] picture = (byte[])Dt.Rows[Index][5];
                MemoryStream ms = new MemoryStream(picture);
                pbox.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            Navigate(0);
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            Position = cust.GET_ALL_CUSTOMER().Rows.Count - 1;
            Navigate(Position);
            bmb.Position = bmb.Count;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void btnPreviose_Click(object sender, EventArgs e)
        {
            if (Position == 0)
            {
                MessageBox.Show("هذا أول عنصر !  ");
                return;
            }
            else
            {
                Position -= 1;
                Navigate(Position);

                bmb.Position -= 1;
                lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

            }

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (Position == cust.GET_ALL_CUSTOMER().Rows.Count - 1)
            {
                MessageBox.Show("هذا آخر عنصر! ");
                return;
            }
            else
            {
                Position += 1;
                Navigate(Position);

                bmb.Position += 1;
                lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

            }

        }


        



       

       

      

       
       
    }
}
