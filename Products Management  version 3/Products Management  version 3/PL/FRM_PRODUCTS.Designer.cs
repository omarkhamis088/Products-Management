namespace Products_Management__version_3.PL
{
    partial class FRM_PRODUCTS
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Rep = new System.Windows.Forms.Button();
            this.btn_Image = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_all_rep = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btn_exal = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefrash = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "بحث : ";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(151, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(439, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(844, 247);
            this.dataGridView1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(856, 272);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "قائمة المنتجات ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Rep);
            this.groupBox2.Controls.Add(this.btn_Image);
            this.groupBox2.Controls.Add(this.btn_exit);
            this.groupBox2.Controls.Add(this.btn_all_rep);
            this.groupBox2.Controls.Add(this.btnEdit);
            this.groupBox2.Controls.Add(this.btn_exal);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 344);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 105);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "العمليات ";
            // 
            // btn_Rep
            // 
            this.btn_Rep.Image = global::Products_Management__version_3.Properties.Resources.print_icon;
            this.btn_Rep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Rep.Location = new System.Drawing.Point(174, 19);
            this.btn_Rep.Name = "btn_Rep";
            this.btn_Rep.Size = new System.Drawing.Size(146, 30);
            this.btn_Rep.TabIndex = 6;
            this.btn_Rep.Text = "طباعة المنتج المحدد";
            this.btn_Rep.UseVisualStyleBackColor = true;
            this.btn_Rep.Click += new System.EventHandler(this.btn_Rep_Click);
            // 
            // btn_Image
            // 
            this.btn_Image.Image = global::Products_Management__version_3.Properties.Resources._2_Pictures_icon;
            this.btn_Image.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Image.Location = new System.Drawing.Point(543, 62);
            this.btn_Image.Name = "btn_Image";
            this.btn_Image.Size = new System.Drawing.Size(122, 30);
            this.btn_Image.TabIndex = 5;
            this.btn_Image.Text = "صورة المنتج";
            this.btn_Image.UseVisualStyleBackColor = true;
            this.btn_Image.Click += new System.EventHandler(this.btn_Image_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_exit.Image = global::Products_Management__version_3.Properties.Resources.Close_2_icon;
            this.btn_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exit.Location = new System.Drawing.Point(193, 62);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(113, 30);
            this.btn_exit.TabIndex = 9;
            this.btn_exit.Text = "خروج";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_all_rep
            // 
            this.btn_all_rep.Image = global::Products_Management__version_3.Properties.Resources.printer_icon;
            this.btn_all_rep.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_all_rep.Location = new System.Drawing.Point(6, 19);
            this.btn_all_rep.Name = "btn_all_rep";
            this.btn_all_rep.Size = new System.Drawing.Size(134, 30);
            this.btn_all_rep.TabIndex = 7;
            this.btn_all_rep.Text = "طباعة كل المنتجات";
            this.btn_all_rep.UseVisualStyleBackColor = true;
            this.btn_all_rep.Click += new System.EventHandler(this.btn_all_rep_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::Products_Management__version_3.Properties.Resources.Edit_validated_icon;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(354, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(144, 30);
            this.btnEdit.TabIndex = 4;
            this.btnEdit.Text = "تعديل بيانات المنتج";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btn_exal
            // 
            this.btn_exal.Image = global::Products_Management__version_3.Properties.Resources.Excel_icon;
            this.btn_exal.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_exal.Location = new System.Drawing.Point(336, 62);
            this.btn_exal.Name = "btn_exal";
            this.btn_exal.Size = new System.Drawing.Size(177, 30);
            this.btn_exal.TabIndex = 8;
            this.btn_exal.Text = "حفظ القائمة في ملف إكسل";
            this.btn_exal.UseVisualStyleBackColor = true;
            this.btn_exal.Click += new System.EventHandler(this.btn_exal_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Products_Management__version_3.Properties.Resources.File_Delete_icon;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(532, 19);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(144, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "حذف المنتج المحدد";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::Products_Management__version_3.Properties.Resources.New_file_icon;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.Location = new System.Drawing.Point(710, 19);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 30);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "إضافة منتج جديد";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefrash
            // 
            this.btnRefrash.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefrash.Location = new System.Drawing.Point(742, 26);
            this.btnRefrash.Name = "btnRefrash";
            this.btnRefrash.Size = new System.Drawing.Size(95, 31);
            this.btnRefrash.TabIndex = 5;
            this.btnRefrash.Text = "تحديث ";
            this.btnRefrash.UseVisualStyleBackColor = true;
            this.btnRefrash.Click += new System.EventHandler(this.btnRefrash_Click);
            // 
            // FRM_PRODUCTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_exit;
            this.ClientSize = new System.Drawing.Size(880, 461);
            this.Controls.Add(this.btnRefrash);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "FRM_PRODUCTS";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " إدارة المنتجات";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Rep;
        private System.Windows.Forms.Button btn_Image;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_all_rep;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btn_exal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefrash;
    }
}