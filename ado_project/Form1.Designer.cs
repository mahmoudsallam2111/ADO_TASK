namespace ado_project
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_course = new System.Windows.Forms.DataGridView();
            this.update = new System.Windows.Forms.DataGridViewButtonColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txt_coursename = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nu_courseDuration = new System.Windows.Forms.NumericUpDown();
            this.com_topic = new System.Windows.Forms.ComboBox();
            this.topic = new System.Windows.Forms.Label();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_course)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_courseDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(560, 107);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(94, 29);
            this.btn_add.TabIndex = 0;
            this.btn_add.Text = "add course";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgv_course
            // 
            this.dgv_course.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_course.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.update,
            this.delete});
            this.dgv_course.Location = new System.Drawing.Point(1, 185);
            this.dgv_course.Name = "dgv_course";
            this.dgv_course.RowHeadersWidth = 51;
            this.dgv_course.RowTemplate.Height = 29;
            this.dgv_course.Size = new System.Drawing.Size(797, 266);
            this.dgv_course.TabIndex = 1;
            this.dgv_course.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_course_CellContentClick);
            this.dgv_course.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_course_RowHeaderMouseDoubleClick);
            // 
            // update
            // 
            this.update.HeaderText = "update";
            this.update.MinimumWidth = 6;
            this.update.Name = "update";
            this.update.Text = "update";
            this.update.UseColumnTextForButtonValue = true;
            this.update.Width = 125;
            // 
            // delete
            // 
            this.delete.HeaderText = "delete";
            this.delete.MinimumWidth = 6;
            this.delete.Name = "delete";
            this.delete.Text = "delete";
            this.delete.UseColumnTextForButtonValue = true;
            this.delete.Width = 125;
            // 
            // txt_coursename
            // 
            this.txt_coursename.Location = new System.Drawing.Point(103, 33);
            this.txt_coursename.Name = "txt_coursename";
            this.txt_coursename.Size = new System.Drawing.Size(125, 27);
            this.txt_coursename.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "course Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(234, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "course Duration";
            // 
            // nu_courseDuration
            // 
            this.nu_courseDuration.Location = new System.Drawing.Point(354, 36);
            this.nu_courseDuration.Name = "nu_courseDuration";
            this.nu_courseDuration.Size = new System.Drawing.Size(150, 27);
            this.nu_courseDuration.TabIndex = 6;
            // 
            // com_topic
            // 
            this.com_topic.FormattingEnabled = true;
            this.com_topic.Location = new System.Drawing.Point(597, 36);
            this.com_topic.Name = "com_topic";
            this.com_topic.Size = new System.Drawing.Size(151, 28);
            this.com_topic.TabIndex = 7;
            // 
            // topic
            // 
            this.topic.AutoSize = true;
            this.topic.Location = new System.Drawing.Point(519, 38);
            this.topic.Name = "topic";
            this.topic.Size = new System.Drawing.Size(43, 20);
            this.topic.TabIndex = 8;
            this.topic.Text = "topic";
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(410, 107);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(94, 29);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "update course";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(243, 107);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(94, 29);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "delete course";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.btn_update);
            this.Controls.Add(this.topic);
            this.Controls.Add(this.com_topic);
            this.Controls.Add(this.nu_courseDuration);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_coursename);
            this.Controls.Add(this.dgv_course);
            this.Controls.Add(this.btn_add);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_course)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nu_courseDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btn_add;
        private DataGridView dgv_course;
        private TextBox txt_coursename;
        private Label label1;
        private Label label2;
        private NumericUpDown nu_courseDuration;
        private ComboBox com_topic;
        private Label topic;
        private Button btn_update;
        private Button btn_delete;
        private DataGridViewButtonColumn update;
        private DataGridViewButtonColumn delete;
    }
}