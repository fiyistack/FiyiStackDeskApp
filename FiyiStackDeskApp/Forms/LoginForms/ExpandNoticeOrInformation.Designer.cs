namespace FiyiStackDeskApp.Forms.LoginForms
{
    partial class ExpandNoticeOrInformation
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
            txtNews = new TextBox();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnClose = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).BeginInit();
            SuspendLayout();
            // 
            // txtNews
            // 
            txtNews.BackColor = Color.FromArgb(32, 38, 43);
            txtNews.BorderStyle = BorderStyle.None;
            txtNews.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNews.ForeColor = Color.FromArgb(224, 224, 224);
            txtNews.Location = new Point(34, 128);
            txtNews.Margin = new Padding(4, 5, 4, 5);
            txtNews.MaxLength = 100;
            txtNews.Multiline = true;
            txtNews.Name = "txtNews";
            txtNews.ReadOnly = true;
            txtNews.ScrollBars = ScrollBars.Vertical;
            txtNews.Size = new Size(592, 541);
            txtNews.TabIndex = 9;
            txtNews.Text = "[txtNews]";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 31);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(616, 52);
            label3.TabIndex = 13;
            label3.Text = "Canal de noticias de FiyiStack";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.FiyiStackImageOnlyBlack1;
            pictureBox1.Location = new Point(648, 128);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(120, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 14;
            pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            btnClose.Cursor = Cursors.Hand;
            btnClose.Image = Properties.Resources.btnCloseSpanish;
            btnClose.Location = new Point(648, 691);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(120, 41);
            btnClose.SizeMode = PictureBoxSizeMode.Zoom;
            btnClose.TabIndex = 8;
            btnClose.TabStop = false;
            btnClose.Click += btnClose_Click;
            btnClose.Paint += btnClose_Paint;
            // 
            // ExpandNoticeOrInformation
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 48, 57);
            ClientSize = new Size(803, 768);
            Controls.Add(pictureBox1);
            Controls.Add(label3);
            Controls.Add(txtNews);
            Controls.Add(btnClose);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExpandNoticeOrInformation";
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FiyiStack | Canal de noticias de FiyiStack";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnClose).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private PictureBox btnClose;
        private TextBox txtNews;
        private Label label3;
        private PictureBox pictureBox1;
    }
}