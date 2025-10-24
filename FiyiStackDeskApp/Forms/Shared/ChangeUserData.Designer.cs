namespace FiyiStackDeskApp.Forms.Shared
{
    partial class ChangeUserData
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
            txtNewPassword = new TextBox();
            labelChangePassword = new Label();
            btnEditUserData = new PictureBox();
            label3 = new Label();
            label1 = new Label();
            txtCurrentPassword = new TextBox();
            label2 = new Label();
            txtNewPasswordRepeated = new TextBox();
            ((System.ComponentModel.ISupportInitialize)btnEditUserData).BeginInit();
            SuspendLayout();
            // 
            // txtNewPassword
            // 
            txtNewPassword.BackColor = Color.FromArgb(32, 38, 43);
            txtNewPassword.BorderStyle = BorderStyle.None;
            txtNewPassword.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPassword.ForeColor = Color.FromArgb(57, 210, 221);
            txtNewPassword.Location = new Point(34, 217);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.MaxLength = 100;
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(332, 26);
            txtNewPassword.TabIndex = 6;
            // 
            // labelChangePassword
            // 
            labelChangePassword.AutoSize = true;
            labelChangePassword.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelChangePassword.ForeColor = Color.White;
            labelChangePassword.Location = new Point(34, 185);
            labelChangePassword.Margin = new Padding(4, 0, 4, 0);
            labelChangePassword.Name = "labelChangePassword";
            labelChangePassword.Size = new Size(183, 27);
            labelChangePassword.TabIndex = 7;
            labelChangePassword.Text = "Nueva contraseña";
            // 
            // btnEditUserData
            // 
            btnEditUserData.Cursor = Cursors.Hand;
            btnEditUserData.Image = Properties.Resources.btnEditSpanish;
            btnEditUserData.Location = new Point(498, 369);
            btnEditUserData.Margin = new Padding(4, 5, 4, 5);
            btnEditUserData.Name = "btnEditUserData";
            btnEditUserData.Size = new Size(112, 40);
            btnEditUserData.TabIndex = 8;
            btnEditUserData.TabStop = false;
            btnEditUserData.Click += btnEditUserData_Click;
            btnEditUserData.Paint += btnEditPassword_Paint;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft YaHei UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(25, 31);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(585, 52);
            label3.TabIndex = 13;
            label3.Text = "Actualizar datos del usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(34, 108);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(181, 27);
            label1.TabIndex = 14;
            label1.Text = "Contraseña actual";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.BackColor = Color.FromArgb(32, 38, 43);
            txtCurrentPassword.BorderStyle = BorderStyle.None;
            txtCurrentPassword.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCurrentPassword.ForeColor = Color.FromArgb(57, 210, 221);
            txtCurrentPassword.Location = new Point(34, 140);
            txtCurrentPassword.Margin = new Padding(4, 5, 4, 5);
            txtCurrentPassword.MaxLength = 100;
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(332, 26);
            txtCurrentPassword.TabIndex = 15;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(34, 272);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(245, 27);
            label2.TabIndex = 17;
            label2.Text = "Repita contraseña nueva";
            // 
            // txtNewPasswordRepeated
            // 
            txtNewPasswordRepeated.BackColor = Color.FromArgb(32, 38, 43);
            txtNewPasswordRepeated.BorderStyle = BorderStyle.None;
            txtNewPasswordRepeated.Font = new Font("Microsoft YaHei UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNewPasswordRepeated.ForeColor = Color.FromArgb(57, 210, 221);
            txtNewPasswordRepeated.Location = new Point(34, 304);
            txtNewPasswordRepeated.Margin = new Padding(4, 5, 4, 5);
            txtNewPasswordRepeated.MaxLength = 100;
            txtNewPasswordRepeated.Name = "txtNewPasswordRepeated";
            txtNewPasswordRepeated.Size = new Size(332, 26);
            txtNewPasswordRepeated.TabIndex = 16;
            // 
            // ChangeUserData
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(41, 48, 57);
            ClientSize = new Size(648, 439);
            Controls.Add(label2);
            Controls.Add(txtNewPasswordRepeated);
            Controls.Add(txtCurrentPassword);
            Controls.Add(label1);
            Controls.Add(label3);
            Controls.Add(btnEditUserData);
            Controls.Add(labelChangePassword);
            Controls.Add(txtNewPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChangeUserData";
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FiyiStack | Actualizar datos del usuario";
            ((System.ComponentModel.ISupportInitialize)btnEditUserData).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox txtNewPassword;
        private Label labelChangePassword;
        private PictureBox btnEditUserData;
        private Label label3;
        private Label label1;
        private TextBox txtCurrentPassword;
        private Label label2;
        private TextBox txtNewPasswordRepeated;
    }
}