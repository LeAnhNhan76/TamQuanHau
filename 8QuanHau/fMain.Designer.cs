namespace _8QuanHau
{
    partial class fMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.btn_NguoiVSMay = new System.Windows.Forms.Button();
            this.btn_MayVSMay = new System.Windows.Forms.Button();
            this.btn_NguoiVSNguoi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lab_ = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_NguoiVSMay
            // 
            this.btn_NguoiVSMay.BackColor = System.Drawing.Color.Orchid;
            this.btn_NguoiVSMay.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NguoiVSMay.Location = new System.Drawing.Point(281, 103);
            this.btn_NguoiVSMay.Name = "btn_NguoiVSMay";
            this.btn_NguoiVSMay.Size = new System.Drawing.Size(167, 56);
            this.btn_NguoiVSMay.TabIndex = 16;
            this.btn_NguoiVSMay.Text = "Người VS Máy";
            this.btn_NguoiVSMay.UseVisualStyleBackColor = false;
            this.btn_NguoiVSMay.Click += new System.EventHandler(this.btn_NguoiVSMay_Click);
            // 
            // btn_MayVSMay
            // 
            this.btn_MayVSMay.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_MayVSMay.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_MayVSMay.Location = new System.Drawing.Point(490, 103);
            this.btn_MayVSMay.Name = "btn_MayVSMay";
            this.btn_MayVSMay.Size = new System.Drawing.Size(167, 56);
            this.btn_MayVSMay.TabIndex = 15;
            this.btn_MayVSMay.Text = "Máy VS Máy";
            this.btn_MayVSMay.UseVisualStyleBackColor = false;
            this.btn_MayVSMay.Click += new System.EventHandler(this.btn_MayVSMay_Click);
            // 
            // btn_NguoiVSNguoi
            // 
            this.btn_NguoiVSNguoi.BackColor = System.Drawing.Color.Orange;
            this.btn_NguoiVSNguoi.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NguoiVSNguoi.Location = new System.Drawing.Point(68, 105);
            this.btn_NguoiVSNguoi.Name = "btn_NguoiVSNguoi";
            this.btn_NguoiVSNguoi.Size = new System.Drawing.Size(167, 56);
            this.btn_NguoiVSNguoi.TabIndex = 14;
            this.btn_NguoiVSNguoi.Text = "Người VS Người";
            this.btn_NguoiVSNguoi.UseVisualStyleBackColor = false;
            this.btn_NguoiVSNguoi.Click += new System.EventHandler(this.btn_NguoiVSNguoi_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(209, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(284, 41);
            this.label1.TabIndex = 13;
            this.label1.Text = "Mời Chọn Chế Độ Chơi";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lab_
            // 
            this.lab_.Font = new System.Drawing.Font("Times New Roman", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_.ForeColor = System.Drawing.Color.DarkBlue;
            this.lab_.Location = new System.Drawing.Point(197, 12);
            this.lab_.Name = "lab_";
            this.lab_.Size = new System.Drawing.Size(328, 41);
            this.lab_.TabIndex = 12;
            this.lab_.Text = "GAME TÁM QUÂN HẬU";
            this.lab_.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::_8QuanHau.Properties.Resources.banco2;
            this.pictureBox2.ErrorImage = null;
            this.pictureBox2.InitialImage = null;
            this.pictureBox2.Location = new System.Drawing.Point(97, 175);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(525, 266);
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.ClientSize = new System.Drawing.Size(730, 463);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btn_NguoiVSMay);
            this.Controls.Add(this.btn_MayVSMay);
            this.Controls.Add(this.btn_NguoiVSNguoi);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lab_);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "fMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Tám Quân Hậu";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_NguoiVSMay;
        private System.Windows.Forms.Button btn_MayVSMay;
        private System.Windows.Forms.Button btn_NguoiVSNguoi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

