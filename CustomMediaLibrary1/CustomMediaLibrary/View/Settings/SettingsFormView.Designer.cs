namespace CustomMediaLibrary
{
    partial class SettingsFormView
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveSupportedFileType = new System.Windows.Forms.Button();
            this.btnAddSupportedFileType = new System.Windows.Forms.Button();
            this.listSupportedFileTypes = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textFileType = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericUpdateInterval = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemoveFolder = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.listMediaLibraryLocations = new System.Windows.Forms.ListBox();
            this.btnSettingsCancel = new System.Windows.Forms.Button();
            this.btnSettingsApply = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdateInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveSupportedFileType);
            this.groupBox1.Controls.Add(this.btnAddSupportedFileType);
            this.groupBox1.Controls.Add(this.listSupportedFileTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textFileType);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 299);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supported File Types";
            // 
            // btnRemoveSupportedFileType
            // 
            this.btnRemoveSupportedFileType.Location = new System.Drawing.Point(176, 270);
            this.btnRemoveSupportedFileType.Name = "btnRemoveSupportedFileType";
            this.btnRemoveSupportedFileType.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveSupportedFileType.TabIndex = 4;
            this.btnRemoveSupportedFileType.Text = "Remove";
            this.btnRemoveSupportedFileType.UseVisualStyleBackColor = true;
            this.btnRemoveSupportedFileType.Click += new System.EventHandler(this.btnRemoveSupportedFileType_Click);
            // 
            // btnAddSupportedFileType
            // 
            this.btnAddSupportedFileType.Location = new System.Drawing.Point(10, 270);
            this.btnAddSupportedFileType.Name = "btnAddSupportedFileType";
            this.btnAddSupportedFileType.Size = new System.Drawing.Size(75, 23);
            this.btnAddSupportedFileType.TabIndex = 3;
            this.btnAddSupportedFileType.Text = "Add";
            this.btnAddSupportedFileType.UseVisualStyleBackColor = true;
            this.btnAddSupportedFileType.Click += new System.EventHandler(this.btnAddSupportedFileType_Click);
            // 
            // listSupportedFileTypes
            // 
            this.listSupportedFileTypes.FormattingEnabled = true;
            this.listSupportedFileTypes.Location = new System.Drawing.Point(6, 76);
            this.listSupportedFileTypes.Name = "listSupportedFileTypes";
            this.listSupportedFileTypes.Size = new System.Drawing.Size(245, 186);
            this.listSupportedFileTypes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Type";
            // 
            // textFileType
            // 
            this.textFileType.Location = new System.Drawing.Point(6, 50);
            this.textFileType.Name = "textFileType";
            this.textFileType.Size = new System.Drawing.Size(245, 20);
            this.textFileType.TabIndex = 0;
            this.textFileType.TextChanged += new System.EventHandler(this.textFileType_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericUpdateInterval);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.btnRemoveFolder);
            this.groupBox2.Controls.Add(this.btnAddFolder);
            this.groupBox2.Controls.Add(this.listMediaLibraryLocations);
            this.groupBox2.Location = new System.Drawing.Point(277, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 328);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Media Library locations";
            // 
            // numericUpdateInterval
            // 
            this.numericUpdateInterval.Location = new System.Drawing.Point(194, 299);
            this.numericUpdateInterval.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpdateInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpdateInterval.Name = "numericUpdateInterval";
            this.numericUpdateInterval.Size = new System.Drawing.Size(69, 20);
            this.numericUpdateInterval.TabIndex = 4;
            this.numericUpdateInterval.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 299);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Media Library update interval (min)";
            // 
            // btnRemoveFolder
            // 
            this.btnRemoveFolder.Location = new System.Drawing.Point(88, 255);
            this.btnRemoveFolder.Name = "btnRemoveFolder";
            this.btnRemoveFolder.Size = new System.Drawing.Size(87, 23);
            this.btnRemoveFolder.TabIndex = 2;
            this.btnRemoveFolder.Text = "Remove Folder";
            this.btnRemoveFolder.UseVisualStyleBackColor = true;
            this.btnRemoveFolder.Click += new System.EventHandler(this.btnRemoveFolder_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Location = new System.Drawing.Point(7, 255);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(75, 23);
            this.btnAddFolder.TabIndex = 1;
            this.btnAddFolder.Text = "Add Folder";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // listMediaLibraryLocations
            // 
            this.listMediaLibraryLocations.FormattingEnabled = true;
            this.listMediaLibraryLocations.Location = new System.Drawing.Point(7, 24);
            this.listMediaLibraryLocations.Name = "listMediaLibraryLocations";
            this.listMediaLibraryLocations.Size = new System.Drawing.Size(331, 225);
            this.listMediaLibraryLocations.TabIndex = 0;
            // 
            // btnSettingsCancel
            // 
            this.btnSettingsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSettingsCancel.Location = new System.Drawing.Point(546, 359);
            this.btnSettingsCancel.Name = "btnSettingsCancel";
            this.btnSettingsCancel.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsCancel.TabIndex = 2;
            this.btnSettingsCancel.Text = "Cancel";
            this.btnSettingsCancel.UseVisualStyleBackColor = true;
            // 
            // btnSettingsApply
            // 
            this.btnSettingsApply.Location = new System.Drawing.Point(449, 359);
            this.btnSettingsApply.Name = "btnSettingsApply";
            this.btnSettingsApply.Size = new System.Drawing.Size(75, 23);
            this.btnSettingsApply.TabIndex = 3;
            this.btnSettingsApply.Text = "Apply";
            this.btnSettingsApply.UseVisualStyleBackColor = true;
            this.btnSettingsApply.Click += new System.EventHandler(this.btnSettingsApply_Click);
            // 
            // SettingsFormView
            // 
            this.AcceptButton = this.btnSettingsApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnSettingsCancel;
            this.ClientSize = new System.Drawing.Size(633, 394);
            this.Controls.Add(this.btnSettingsApply);
            this.Controls.Add(this.btnSettingsCancel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsFormView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Settings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpdateInterval)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSettingsCancel;
        private System.Windows.Forms.Button btnSettingsApply;
        private System.Windows.Forms.Button btnRemoveSupportedFileType;
        private System.Windows.Forms.Button btnAddSupportedFileType;
        private System.Windows.Forms.ListBox listSupportedFileTypes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFileType;
        private System.Windows.Forms.NumericUpDown numericUpdateInterval;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemoveFolder;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.ListBox listMediaLibraryLocations;
    }
}