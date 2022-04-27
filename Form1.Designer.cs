namespace png_to_asci
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_pic = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_path = new System.Windows.Forms.TextBox();
            this.btn_convert = new System.Windows.Forms.Button();
            this.pbx_preview = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.tab_pic.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_preview)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_pic);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1361, 607);
            this.tabControl1.TabIndex = 0;
            // 
            // tab_pic
            // 
            this.tab_pic.Controls.Add(this.pbx_preview);
            this.tab_pic.Controls.Add(this.btn_convert);
            this.tab_pic.Controls.Add(this.txt_path);
            this.tab_pic.Controls.Add(this.button1);
            this.tab_pic.Location = new System.Drawing.Point(4, 22);
            this.tab_pic.Name = "tab_pic";
            this.tab_pic.Padding = new System.Windows.Forms.Padding(3);
            this.tab_pic.Size = new System.Drawing.Size(1353, 581);
            this.tab_pic.TabIndex = 0;
            this.tab_pic.Text = "png_to_ascii";
            this.tab_pic.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(192, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(122, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "browse image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_path
            // 
            this.txt_path.Location = new System.Drawing.Point(122, 164);
            this.txt_path.Name = "txt_path";
            this.txt_path.Size = new System.Drawing.Size(311, 20);
            this.txt_path.TabIndex = 1;
            this.txt_path.Visible = false;
            // 
            // btn_convert
            // 
            this.btn_convert.Location = new System.Drawing.Point(1065, 94);
            this.btn_convert.Name = "btn_convert";
            this.btn_convert.Size = new System.Drawing.Size(131, 64);
            this.btn_convert.TabIndex = 2;
            this.btn_convert.Text = "convert";
            this.btn_convert.UseVisualStyleBackColor = true;
            this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
            // 
            // pbx_preview
            // 
            this.pbx_preview.Location = new System.Drawing.Point(439, 25);
            this.pbx_preview.Name = "pbx_preview";
            this.pbx_preview.Size = new System.Drawing.Size(606, 526);
            this.pbx_preview.TabIndex = 3;
            this.pbx_preview.TabStop = false;
            this.pbx_preview.Click += new System.EventHandler(this.pbx_preview_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1364, 608);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tab_pic.ResumeLayout(false);
            this.tab_pic.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_preview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_pic;
        private System.Windows.Forms.Button btn_convert;
        private System.Windows.Forms.TextBox txt_path;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.PictureBox pbx_preview;
    }
}

