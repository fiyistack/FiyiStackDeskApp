
namespace FiyiStackDeskApp.Forms.GeneratorForms
{
    partial class G2ConfigurationForm
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
            StatusStrip = new StatusStrip();
            ToolStatusLabel = new ToolStripStatusLabel();
            StatusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // StatusStrip
            // 
            StatusStrip.BackColor = Color.FromArgb(32, 38, 45);
            StatusStrip.ImageScalingSize = new Size(20, 20);
            StatusStrip.Items.AddRange(new ToolStripItem[] { ToolStatusLabel });
            StatusStrip.Location = new Point(0, 502);
            StatusStrip.Name = "StatusStrip";
            StatusStrip.Size = new Size(1117, 22);
            StatusStrip.SizingGrip = false;
            StatusStrip.TabIndex = 94;
            StatusStrip.Click += StatusStrip_Click;
            // 
            // ToolStatusLabel
            // 
            ToolStatusLabel.Name = "ToolStatusLabel";
            ToolStatusLabel.Size = new Size(0, 16);
            // 
            // G2ConfigurationForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 48, 57);
            ClientSize = new Size(1117, 524);
            Controls.Add(StatusStrip);
            Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold);
            ForeColor = Color.FromArgb(57, 210, 221);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(9, 8, 9, 8);
            MaximizeBox = false;
            Name = "G2ConfigurationForm";
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FiyiStack | Configuración del generador G2";
            StatusStrip.ResumeLayout(false);
            StatusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel ToolStatusLabel;
    }
}