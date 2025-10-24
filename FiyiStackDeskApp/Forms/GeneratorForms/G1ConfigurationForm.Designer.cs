
namespace FiyiStackDeskApp.Forms.GeneratorForms
{
    partial class G1ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(G1ConfigurationForm));
            chbDeleteTable = new CheckBox();
            chbDeleteField = new CheckBox();
            label14 = new Label();
            label26 = new Label();
            ListViewFrontEndFilesGenerators = new ListView();
            columnHeader1 = new ColumnHeader();
            ListViewBackEndFilesGenerators = new ListView();
            columnHeader2 = new ColumnHeader();
            chbDeleteFiles = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            btnSave = new PictureBox();
            label1 = new Label();
            chbWantCSharp = new CheckBox();
            chbWantMSSQLServer = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)btnSave).BeginInit();
            SuspendLayout();
            // 
            // chbDeleteTable
            // 
            chbDeleteTable.AutoSize = true;
            chbDeleteTable.Font = new Font("Microsoft YaHei UI", 11.25F);
            chbDeleteTable.ForeColor = Color.WhiteSmoke;
            chbDeleteTable.Location = new Point(53, 519);
            chbDeleteTable.Margin = new Padding(3, 4, 3, 4);
            chbDeleteTable.Name = "chbDeleteTable";
            chbDeleteTable.Size = new Size(168, 29);
            chbDeleteTable.TabIndex = 115;
            chbDeleteTable.Text = "Eliminar tablas";
            chbDeleteTable.UseVisualStyleBackColor = true;
            // 
            // chbDeleteField
            // 
            chbDeleteField.AutoSize = true;
            chbDeleteField.Font = new Font("Microsoft YaHei UI", 11.25F);
            chbDeleteField.ForeColor = Color.WhiteSmoke;
            chbDeleteField.Location = new Point(53, 556);
            chbDeleteField.Margin = new Padding(3, 4, 3, 4);
            chbDeleteField.Name = "chbDeleteField";
            chbDeleteField.Size = new Size(202, 29);
            chbDeleteField.TabIndex = 114;
            chbDeleteField.Text = "Eliminar columnas";
            chbDeleteField.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Cursor = Cursors.Hand;
            label14.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(255, 255, 255);
            label14.Location = new Point(27, 489);
            label14.Name = "label14";
            label14.Size = new Size(406, 26);
            label14.TabIndex = 109;
            label14.Text = "Durante los reemplazos en base de datos";
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Cursor = Cursors.Hand;
            label26.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold);
            label26.ForeColor = Color.FromArgb(255, 255, 255);
            label26.Location = new Point(23, 26);
            label26.Name = "label26";
            label26.Size = new Size(217, 26);
            label26.TabIndex = 177;
            label26.Text = "Archivos del backend";
            // 
            // ListViewFrontEndFilesGenerators
            // 
            ListViewFrontEndFilesGenerators.Activation = ItemActivation.OneClick;
            ListViewFrontEndFilesGenerators.BackColor = Color.FromArgb(32, 38, 44);
            ListViewFrontEndFilesGenerators.BorderStyle = BorderStyle.None;
            ListViewFrontEndFilesGenerators.CheckBoxes = true;
            ListViewFrontEndFilesGenerators.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            ListViewFrontEndFilesGenerators.Cursor = Cursors.Hand;
            ListViewFrontEndFilesGenerators.Font = new Font("Microsoft YaHei", 12F);
            ListViewFrontEndFilesGenerators.ForeColor = Color.FromArgb(57, 210, 221);
            ListViewFrontEndFilesGenerators.FullRowSelect = true;
            ListViewFrontEndFilesGenerators.HeaderStyle = ColumnHeaderStyle.None;
            ListViewFrontEndFilesGenerators.Location = new Point(626, 56);
            ListViewFrontEndFilesGenerators.Margin = new Padding(4);
            ListViewFrontEndFilesGenerators.MultiSelect = false;
            ListViewFrontEndFilesGenerators.Name = "ListViewFrontEndFilesGenerators";
            ListViewFrontEndFilesGenerators.ShowGroups = false;
            ListViewFrontEndFilesGenerators.ShowItemToolTips = true;
            ListViewFrontEndFilesGenerators.Size = new Size(565, 138);
            ListViewFrontEndFilesGenerators.TabIndex = 160;
            ListViewFrontEndFilesGenerators.TileSize = new Size(50, 50);
            ListViewFrontEndFilesGenerators.UseCompatibleStateImageBehavior = false;
            ListViewFrontEndFilesGenerators.View = View.SmallIcon;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Name";
            columnHeader1.Width = 200;
            // 
            // ListViewBackEndFilesGenerators
            // 
            ListViewBackEndFilesGenerators.Activation = ItemActivation.OneClick;
            ListViewBackEndFilesGenerators.BackColor = Color.FromArgb(32, 38, 44);
            ListViewBackEndFilesGenerators.BorderStyle = BorderStyle.None;
            ListViewBackEndFilesGenerators.CheckBoxes = true;
            ListViewBackEndFilesGenerators.Columns.AddRange(new ColumnHeader[] { columnHeader2 });
            ListViewBackEndFilesGenerators.Cursor = Cursors.Hand;
            ListViewBackEndFilesGenerators.Font = new Font("Microsoft YaHei", 12F);
            ListViewBackEndFilesGenerators.ForeColor = Color.FromArgb(57, 210, 221);
            ListViewBackEndFilesGenerators.FullRowSelect = true;
            ListViewBackEndFilesGenerators.HeaderStyle = ColumnHeaderStyle.None;
            ListViewBackEndFilesGenerators.Location = new Point(28, 56);
            ListViewBackEndFilesGenerators.Margin = new Padding(4);
            ListViewBackEndFilesGenerators.MultiSelect = false;
            ListViewBackEndFilesGenerators.Name = "ListViewBackEndFilesGenerators";
            ListViewBackEndFilesGenerators.ShowGroups = false;
            ListViewBackEndFilesGenerators.ShowItemToolTips = true;
            ListViewBackEndFilesGenerators.Size = new Size(565, 138);
            ListViewBackEndFilesGenerators.TabIndex = 159;
            ListViewBackEndFilesGenerators.TileSize = new Size(50, 50);
            ListViewBackEndFilesGenerators.UseCompatibleStateImageBehavior = false;
            ListViewBackEndFilesGenerators.View = View.SmallIcon;
            ListViewBackEndFilesGenerators.BackColorChanged += ListViewGenerators_BackColorChanged;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Name";
            columnHeader2.Width = 200;
            // 
            // chbDeleteFiles
            // 
            chbDeleteFiles.AutoSize = true;
            chbDeleteFiles.Font = new Font("Microsoft YaHei UI", 11.25F);
            chbDeleteFiles.ForeColor = Color.WhiteSmoke;
            chbDeleteFiles.Location = new Point(53, 416);
            chbDeleteFiles.Margin = new Padding(3, 4, 3, 4);
            chbDeleteFiles.Name = "chbDeleteFiles";
            chbDeleteFiles.Size = new Size(189, 29);
            chbDeleteFiles.TabIndex = 190;
            chbDeleteFiles.Text = "Eliminar archivos";
            chbDeleteFiles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Cursor = Cursors.Hand;
            label4.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(255, 255, 255);
            label4.Location = new Point(28, 386);
            label4.Name = "label4";
            label4.Size = new Size(495, 26);
            label4.TabIndex = 189;
            label4.Text = "Durante los reemplazos en la carpeta del proyecto";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Cursor = Cursors.Hand;
            label3.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(255, 255, 255);
            label3.Location = new Point(621, 26);
            label3.Name = "label3";
            label3.Size = new Size(220, 26);
            label3.TabIndex = 188;
            label3.Text = "Archivos del frontend";
            // 
            // btnSave
            // 
            btnSave.Cursor = Cursors.Hand;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(1071, 592);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 40);
            btnSave.SizeMode = PictureBoxSizeMode.Zoom;
            btnSave.TabIndex = 161;
            btnSave.TabStop = false;
            btnSave.Click += btnSave_Click;
            btnSave.Paint += btnSave_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Cursor = Cursors.Hand;
            label1.Font = new Font("Microsoft YaHei UI", 11.25F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(255, 255, 255);
            label1.Location = new Point(28, 213);
            label1.Name = "label1";
            label1.Size = new Size(132, 26);
            label1.TabIndex = 191;
            label1.Text = "Trabajar con";
            // 
            // chbWantCSharp
            // 
            chbWantCSharp.AutoSize = true;
            chbWantCSharp.Font = new Font("Microsoft YaHei UI", 11.25F);
            chbWantCSharp.ForeColor = Color.WhiteSmoke;
            chbWantCSharp.Location = new Point(53, 254);
            chbWantCSharp.Margin = new Padding(3, 4, 3, 4);
            chbWantCSharp.Name = "chbWantCSharp";
            chbWantCSharp.Size = new Size(59, 29);
            chbWantCSharp.TabIndex = 192;
            chbWantCSharp.Text = "C#";
            chbWantCSharp.UseVisualStyleBackColor = true;
            // 
            // chbWantMSSQLServer
            // 
            chbWantMSSQLServer.AutoSize = true;
            chbWantMSSQLServer.Font = new Font("Microsoft YaHei UI", 11.25F);
            chbWantMSSQLServer.ForeColor = Color.WhiteSmoke;
            chbWantMSSQLServer.Location = new Point(53, 291);
            chbWantMSSQLServer.Margin = new Padding(3, 4, 3, 4);
            chbWantMSSQLServer.Name = "chbWantMSSQLServer";
            chbWantMSSQLServer.Size = new Size(169, 29);
            chbWantMSSQLServer.TabIndex = 193;
            chbWantMSSQLServer.Text = "MS SQL Server";
            chbWantMSSQLServer.UseVisualStyleBackColor = true;
            // 
            // G1ConfigurationForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(41, 48, 57);
            ClientSize = new Size(1220, 665);
            Controls.Add(chbWantMSSQLServer);
            Controls.Add(chbWantCSharp);
            Controls.Add(label1);
            Controls.Add(chbDeleteTable);
            Controls.Add(ListViewFrontEndFilesGenerators);
            Controls.Add(chbDeleteField);
            Controls.Add(ListViewBackEndFilesGenerators);
            Controls.Add(label14);
            Controls.Add(chbDeleteFiles);
            Controls.Add(label4);
            Controls.Add(btnSave);
            Controls.Add(label3);
            Controls.Add(label26);
            Font = new Font("Microsoft YaHei UI", 20.25F, FontStyle.Bold);
            ForeColor = Color.FromArgb(57, 210, 221);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(9, 8, 9, 8);
            MaximizeBox = false;
            Name = "G1ConfigurationForm";
            Opacity = 0.98D;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FiyiStack | Configuración del generador G1";
            ((System.ComponentModel.ISupportInitialize)btnSave).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.CheckBox chbDeleteTable;
        private System.Windows.Forms.CheckBox chbDeleteField;
        private System.Windows.Forms.PictureBox btnSave;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chbDeleteFiles;
        private System.Windows.Forms.Label label4;
        private ListView ListViewBackEndFilesGenerators;
        private ColumnHeader columnHeader2;
        private ListView ListViewFrontEndFilesGenerators;
        private ColumnHeader columnHeader1;
        private Label label1;
        private CheckBox chbWantCSharp;
        private CheckBox chbWantMSSQLServer;
    }
}