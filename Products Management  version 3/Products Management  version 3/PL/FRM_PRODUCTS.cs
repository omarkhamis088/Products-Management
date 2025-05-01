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
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;

namespace Products_Management__version_3.PL
{
    public partial class FRM_PRODUCTS : Form
    {
        //single instance
        private static FRM_PRODUCTS frm;

        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static FRM_PRODUCTS getMainForm
        {
            get
            {
                if (frm == null)
                {
                    frm = new FRM_PRODUCTS();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);

                }
                return frm;
            }

        }
        BL.CLS_PRODUCT prd = new BL.CLS_PRODUCT();
        public FRM_PRODUCTS()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DataTable Dt = new DataTable();
            Dt = prd.SearchProduct(txtSearch.Text);
            this.dataGridView1.DataSource = Dt;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string id = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                if (MessageBox.Show("  هل تريد حذف المنتج " + " \n     " + id, "حذف المنتج", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    prd.DeleteProduct(this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    MessageBox.Show("تمت عملية الحذف بنجاح", "حذف منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();
                }
                else
                {
                    MessageBox.Show("تم إلفاء عملية الحذف", "حذف منتج", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        private void btnEdit_Click(object sender, EventArgs e)
        {
            FRM_ADD_PRODUCT frm = new FRM_ADD_PRODUCT();
            frm.txtRef.Text = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
            frm.txtDes.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.txtQte.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
            frm.txtprice.Text = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
            frm.cmbCat.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
            frm.Text = "تعديل بيانات المنتج  " + this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            frm.btnAdd.Name = "btnEdit";
            frm.btnAdd.Text = "تعديل";
            frm.state = "update";
            frm.txtRef.ReadOnly = true;
            byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
            MemoryStream ms = new MemoryStream(image);
            frm.pbox.Image = Image.FromStream(ms);

            frm.ShowDialog();
        }

        private void btn_Image_Click(object sender, EventArgs e)
        {
            try
            {
                FRM_PREVIEW frm = new FRM_PREVIEW();
                byte[] image = (byte[])prd.GET_IMAGE_PRODUCT(this.dataGridView1.CurrentRow.Cells[0].Value.ToString()).Rows[0][0];
                MemoryStream ms = new MemoryStream(image);
                frm.pictureBox1.Image = Image.FromStream(ms);
                frm.Show();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_Rep_Click(object sender, EventArgs e)
        {
            try
            {
                RPT.rpt_pro_single myReport = new RPT.rpt_pro_single();
                myReport.SetParameterValue("@ID", this.dataGridView1.CurrentRow.Cells[0].Value.ToString());
                RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();
                myForm.crystalReportViewer1.ReportSource = myReport;

                myForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_all_rep_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();
            RPT.FRM_RPT_PRODUCT myForm = new RPT.FRM_RPT_PRODUCT();
            myForm.crystalReportViewer1.ReportSource = myReport;
            myForm.ShowDialog();
        }



        private void btn_exal_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_products myReport = new RPT.rpt_all_products();

            //create Export Options 
            ExportOptions export = new ExportOptions();

            //Create Object For destination 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            ExcelFormatOptions excelformat = new ExcelFormatOptions();

            //Set the path of destination 
            dfoptions.DiskFileName = @"E:\prod.xls";

            export = myReport.ExportOptions;

            export.ExportDestinationType = ExportDestinationType.DiskFile;

            export.ExportFormatType = ExportFormatType.Excel;

            export.ExportFormatOptions = excelformat;

            export.ExportDestinationOptions = dfoptions;

            //Export the report
            myReport.Export();

            MessageBox.Show("Export secssfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefrash_Click(object sender, EventArgs e)
        {
           
            this.dataGridView1.DataSource = prd.GET_ALL_PRODUCTS();

        } 

    }
}
