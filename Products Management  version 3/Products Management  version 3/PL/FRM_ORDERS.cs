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
using System.Globalization;

namespace Products_Management__version_3.PL
{
    public partial class FRM_ORDERS : Form
    {
        BL.CLS_ORDERS order = new BL.CLS_ORDERS();
        DataTable dt = new DataTable();
        void CalculateAmount()
        {
            if (txtPrice.Text != string.Empty && txtQty.Text != string.Empty)
                txtAmount.Text = (Convert.ToDouble(txtPrice.Text) * Convert.ToInt32(txtQty.Text)).ToString();
        }

        void CalculateTotalAmount()
        {
            if (txtDiscount.Text != string.Empty && txtAmount.Text != string.Empty)
            {
                double Discount = Convert.ToDouble(txtDiscount.Text);
                double Amount = Convert.ToDouble(txtAmount.Text);
                double TotalAmount = Amount - (Amount * (Discount / 100));
                txtTotalAmount.Text = TotalAmount.ToString();
            }

        }


        void CreateDataTable()
        {
            dt.Columns.Add("رقم المنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("سعر الحبة");
            dt.Columns.Add("الكمية");
            dt.Columns.Add("الإجمالي");
            dt.Columns.Add(" نسبة الخصم(%)");
            dt.Columns.Add("صافي المبلغ");

            dgProducts.DataSource = dt;


        }

        void ResizeDGV()
        {
            this.dgProducts.RowHeadersWidth = 77;
            //this.dgProducts.Columns[0].Width = 87;
            //this.dgProducts.Columns[1].Width = 181;
            //this.dgProducts.Columns[2].Width = 104;
            //this.dgProducts.Columns[3].Width = 98;
            //this.dgProducts.Columns[4].Width = 123;
            //this.dgProducts.Columns[5].Width = 90;
            //this.dgProducts.Columns[6].Width = 113;
        }

        void ClearBoxes()
        {
            txtIDproduct.Clear();
            txtNameProduct.Clear();
            txtPrice.Clear();
            txtQty.Clear();
            txtAmount.Clear();
            txtDiscount.Clear();

        }

        void ClearAllDate()
        {
            txtOrderID.Clear();
            txtDesOrder.Clear();
            txtSalesMan.Clear();
            dtOrder.ResetText();
            txtCustomerID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            ClearBoxes();
            dt.Clear();
            dgProducts.DataSource = null;
            txtSalesMan.Clear();
            pbox.Image = null;
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnPrint.Enabled = true;

        }


        public FRM_ORDERS()
        {
            InitializeComponent();
            CreateDataTable();
            ResizeDGV();
            txtSalesMan.Text = Program.SalesMan;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            this.txtOrderID.Text = order.GET_LAST_ORDER_ID().Rows[0][0].ToString();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;

        }

        private void btnShowCust_Click(object sender, EventArgs e)
        {

            FRM_CUSTOMERS_LIST frm = new FRM_CUSTOMERS_LIST();
            frm.ShowDialog();
            if (frm.dgCustomers.CurrentRow.Cells[5].Value is DBNull)
            {
                MessageBox.Show("!هذا العميل لا يملك صورة");
                this.txtCustomerID.Text = frm.dgCustomers.CurrentRow.Cells[0].Value.ToString();
                this.txtFirstName.Text = frm.dgCustomers.CurrentRow.Cells[1].Value.ToString();
                this.txtLastName.Text = frm.dgCustomers.CurrentRow.Cells[2].Value.ToString();
                this.txtTel.Text = frm.dgCustomers.CurrentRow.Cells[3].Value.ToString();
                this.txtEmail.Text = frm.dgCustomers.CurrentRow.Cells[4].Value.ToString();
                pbox.Image = null;
                return;
            }
            this.txtCustomerID.Text = frm.dgCustomers.CurrentRow.Cells[0].Value.ToString();
            this.txtFirstName.Text = frm.dgCustomers.CurrentRow.Cells[1].Value.ToString();
            this.txtLastName.Text = frm.dgCustomers.CurrentRow.Cells[2].Value.ToString();
            this.txtTel.Text = frm.dgCustomers.CurrentRow.Cells[3].Value.ToString();
            this.txtEmail.Text = frm.dgCustomers.CurrentRow.Cells[4].Value.ToString();

            byte[] custPicture = (byte[])frm.dgCustomers.CurrentRow.Cells[5].Value;
            MemoryStream ms = new MemoryStream(custPicture);
            pbox.Image = Image.FromStream(ms);


        }

        private void btnShowProd_Click(object sender, EventArgs e)
        {
            ClearBoxes();
            FRM_PRODUCTS_LIST frm = new FRM_PRODUCTS_LIST();
            frm.ShowDialog();
            txtIDproduct.Text = frm.dgvProducts.CurrentRow.Cells[0].Value.ToString();
            txtNameProduct.Text = frm.dgvProducts.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = frm.dgvProducts.CurrentRow.Cells[3].Value.ToString();
            txtQty.Focus();
            txtDiscount.Text = 0.ToString();

        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }

        }

        private void txtPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPrice.Text != string.Empty)
                txtQty.Focus();

        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter && txtPrice.Text != string.Empty)
                txtDiscount.Focus();
        }

        private void txtPrice_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();

        }

        private void txtQty_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateAmount();
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            char DecimalSeparator = Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != DecimalSeparator)
            {
                e.Handled = true;
            }
        }

        private void txtDiscount_KeyUp(object sender, KeyEventArgs e)
        {
            CalculateTotalAmount();
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtDiscount.Text == string.Empty)
            {
                txtDiscount.Text = 0.ToString();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (order.VerifyQty(txtIDproduct.Text, Convert.ToInt32(txtQty.Text)).Rows.Count < 1)
                {
                    MessageBox.Show(" الكمبية المدخلة لهذا المنتج غير متوفرة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                for (int i = 0; i < dgProducts.Rows.Count - 1; i++)
                {
                    if (dgProducts.Rows[i].Cells[0].Value.ToString() == txtIDproduct.Text)
                    {
                        MessageBox.Show(" ! هذا المنتج موجود ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }


                }

                DataRow r = dt.NewRow();
                r[0] = txtIDproduct.Text;
                r[1] = txtNameProduct.Text;
                r[2] = txtPrice.Text;
                r[3] = txtQty.Text;
                r[4] = txtAmount.Text;
                r[5] = txtDiscount.Text;
                r[6] = txtTotalAmount.Text;

                dt.Rows.Add(r);
                dgProducts.DataSource = dt;
                ClearBoxes();
                btnShowProd.Focus();
                txtSumTotals.Text =
                    (from DataGridViewRow row in dgProducts.Rows
                     where row.Cells[6].FormattedValue.ToString() != string.Empty
                     select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();

            }
        }

        private void dgProducts_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                txtIDproduct.Text = this.dgProducts.CurrentRow.Cells[0].Value.ToString();
                txtNameProduct.Text = this.dgProducts.CurrentRow.Cells[1].Value.ToString();
                txtPrice.Text = this.dgProducts.CurrentRow.Cells[2].Value.ToString();
                txtQty.Text = this.dgProducts.CurrentRow.Cells[3].Value.ToString();
                txtAmount.Text = this.dgProducts.CurrentRow.Cells[4].Value.ToString();
                txtDiscount.Text = this.dgProducts.CurrentRow.Cells[5].Value.ToString();
                txtTotalAmount.Text = this.dgProducts.CurrentRow.Cells[6].Value.ToString();

                dgProducts.Rows.RemoveAt(dgProducts.CurrentRow.Index);

                txtQty.Focus();

            }
            catch
            {
                return;
            }
        }

        private void dgProducts_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            txtSumTotals.Text =
                   (from DataGridViewRow row in dgProducts.Rows
                    where row.Cells[6].FormattedValue.ToString() != string.Empty
                    select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
        }

        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dgProducts_DoubleClick(sender, e);
        }

        private void حذفالسطرالحاليToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                dgProducts.Rows.RemoveAt(dgProducts.CurrentRow.Index);

            }
            catch
            {
                return;
            }
        }

        private void حذفالكلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //for (int i = 0; i < dgProducts.Rows.Count - 1; i++)
                //{
                //    dgProducts.Rows.RemoveAt(dgProducts.Rows[i].Index);

                //}
                dt.Clear();
                dgProducts.Refresh();

            }
            catch
            {
                return;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Check Values 

            if (txtOrderID.Text == string.Empty || txtCustomerID.Text == string.Empty || dgProducts.Rows.Count < 1 || txtDesOrder.Text == string.Empty)
            {
                MessageBox.Show(" ينبغي تسجيل المعلومات كاملة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }


            //اضافة معلومات الفاتورة 
            order.ADD_ORDER(Convert.ToInt32(txtOrderID.Text), dtOrder.Value, Convert.ToInt32(txtCustomerID.Text), txtDesOrder.Text, txtSalesMan.Text);




            // اضافة المنتجات المدخلة
            try
            {
                for (int i = 0; i < dgProducts.Rows.Count - 1; i++)
                {
                    order.ADD_ORDER_DETAILS(dgProducts.Rows[i].Cells[0].Value.ToString()
                                            , Convert.ToInt32(txtOrderID.Text)
                                            , Convert.ToInt32(dgProducts.Rows[i].Cells[3].Value.ToString())
                                            , dgProducts.Rows[i].Cells[2].Value.ToString()
                                            , Convert.ToInt32(dgProducts.Rows[i].Cells[5].Value.ToString())
                                            , dgProducts.Rows[i].Cells[4].Value.ToString()
                                            , dgProducts.Rows[i].Cells[6].Value.ToString());


                }

                MessageBox.Show(" تمت عملية الحفظ بنجاح ", " عملية الحفظ ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                ClearAllDate();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            // get the last order 
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int order_ID = Convert.ToInt32(order.GET_LAST_ORDER_FOR_PRINT().Rows[0][0]);
                RPT.rpt_orders report = new RPT.rpt_orders();
                RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();

                report.SetDataSource(order.GetOrderDetails(order_ID));
                frm.crystalReportViewer1.ReportSource = report;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            } 
            this.Cursor = Cursors.Default;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
