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
using CrystalDecisions.Shared;
//using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.CrystalReports;
//using CrystalDecisions.Shared;


namespace Products_Management__version_3.PL
{
    public partial class FRM_CATEGRIES : Form
    {
        SqlConnection sqlcon = new SqlConnection(@"Data Source=.\SQLEXPRESS; Database=Product_DB; Integrated Security=true");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder cmdb;

        public FRM_CATEGRIES()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select id_cat as 'المعرف',DESCRIPTION_CAT as 'الصنف' from categories", sqlcon);  //1
            da.Fill(dt);   //2
            dgList.DataSource = dt;   //3

            txtID.DataBindings.Add("text", dt, "المعرف");
            txtDesc.DataBindings.Add("text", dt, "الصنف");
            bmb = this.BindingContext[dt];
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void benLast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            txtID.Text = id.ToString();
            txtDesc.Focus();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("add secssefuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Delete secssefuly", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            cmdb = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("Edit secssefuly", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);

            lblPosition.Text = (bmb.Position + 1) + "  /  " + bmb.Count;

        }

        private void btnPrintAll_Click(object sender, EventArgs e)
        {
             RPT.rpt_all_categirues rpt = new RPT.rpt_all_categirues();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
            rpt.Refresh();
             frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();

        }

        private void btnPrintCurrent_Click(object sender, EventArgs e)
        {
            RPT.rpt_single_category rpt = new RPT.rpt_single_category();
            RPT.FRM_RPT_PRODUCT frm = new RPT.FRM_RPT_PRODUCT();
             rpt.SetParameterValue("@id" , Convert.ToInt32(txtID.Text));
             frm.crystalReportViewer1.ReportSource = rpt;
            frm.ShowDialog();

        }

        private void btnExportToPDFAll_Click(object sender, EventArgs e)
        {
            RPT.rpt_all_categirues myReport = new RPT.rpt_all_categirues();

            //create Export Options 
            ExportOptions export = new ExportOptions();

            //Create Object For destination 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            PdfFormatOptions pdfformat = new PdfFormatOptions();

            //Set the path of destination 
            dfoptions.DiskFileName = @"E:\categries.pdf";

            //create Report oprions to crystal export options 
            export = myReport.ExportOptions;

            //set destination type 
            export.ExportDestinationType = ExportDestinationType.DiskFile;

            //set the excel document
            export.ExportFormatType = ExportFormatType.PortableDocFormat;

            //format the excel document
            export.ExportFormatOptions = pdfformat;

            //set Destination option
            export.ExportDestinationOptions = dfoptions;

            //
            myReport.Refresh();

            //Export the report
            myReport.Export();

            MessageBox.Show("Export secssfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportToPDFCurrent_Click(object sender, EventArgs e)
        {
            RPT.rpt_single_category myReport = new RPT.rpt_single_category();

            //create Export Options 
            ExportOptions export = new ExportOptions();

            //Create Object For destination 
            DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();

            PdfFormatOptions pdfformat = new PdfFormatOptions();

            //Set the path of destination 
            dfoptions.DiskFileName = @"E:\categry.pdf";

            //create Report oprions to crystal export options 
             export = myReport.ExportOptions;

            //set destination type 
            export.ExportDestinationType = ExportDestinationType.DiskFile;

            //set the excel document
            export.ExportFormatType = ExportFormatType.PortableDocFormat;

            //format the excel document
            export.ExportFormatOptions = pdfformat;

            //set Destination option
            export.ExportDestinationOptions = dfoptions;

            //
            myReport.SetParameterValue("@id" , Convert.ToInt32(txtID.Text));


            //Export the report
            myReport.Export();

            MessageBox.Show("Export secssfully", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void dgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
