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
    public partial class FRM_ADD_PRODUCT : Form
    {
        public string state = "add";

        BL.CLS_PRODUCT prd = new BL.CLS_PRODUCT();
        public FRM_ADD_PRODUCT()
        {

            InitializeComponent();

            cmbCat.DataSource = prd.GET_ALL_CATEGORIES();

            cmbCat.DisplayMember = "DESCRIPTION_CAT";
            cmbCat.ValueMember = "ID_CAT";

        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_addImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ملفات الصور  |*.PNG; *.JPG; *.GIF;*.BMP ";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pbox.Image = Image.FromFile(ofd.FileName);
            }
        }
        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////
        /// //////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (state == "add")
            {
                
                try
                {
                    MemoryStream ms = new MemoryStream();
                    pbox.Image.Save(ms, pbox.Image.RawFormat);
                    byte[] byteImage = ms.ToArray();

                    prd.ADD_PRODUCT(Convert.ToInt32(cmbCat.SelectedValue), txtDes.Text,
                                 txtRef.Text, Convert.ToInt32(txtQte.Text), txtprice.Text, byteImage);

                    MessageBox.Show(" تمت الإضافة بنجاح ", "عملية إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDes.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;



                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            else
            {
                MemoryStream ms = new MemoryStream();
                pbox.Image.Save(ms, pbox.Image.RawFormat);
                byte[] byteImage = ms.ToArray();

                try
                {
                    prd.UPDATE_PRODUCT(Convert.ToInt32(cmbCat.SelectedValue), txtDes.Text,
                                 txtRef.Text, Convert.ToInt32(txtQte.Text), txtprice.Text, byteImage);

                    MessageBox.Show(" تمت التعديل بنجاح ", "عملية إضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtRef.Focus();
                    txtRef.SelectionStart = 0;
                    txtRef.SelectionLength = txtRef.TextLength;


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }


            }
            //FRM_PRODUCTS.getMainForm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();


        }
        /// <summary>
        /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// ////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtRef_Validated(object sender, EventArgs e)
        {


            if (state == "add")
            {
                DataTable Dt = new DataTable();
                Dt = prd.VerifyProductID(txtRef.Text);

                if (Dt.Rows.Count > 0)
                {

                    if (MessageBox.Show("هذا المعرف موجود مسبقا يجب تغيير أسم المنتج ", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        txtDes.Focus();
                        txtRef.SelectionStart = 0;
                        txtRef.SelectionLength = txtRef.TextLength;

                    }
                    else
                    {
                        this.Close();
                        //FRM_PRODUCTS frm = new FRM_PRODUCTS();
                        //frm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
             this.Close();
             //FRM_PRODUCTS frm = new FRM_PRODUCTS();
             //frm.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
            

        }

        private void cmbCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pbox_Click(object sender, EventArgs e)
        {

        }
    }
}
