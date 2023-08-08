namespace DocumentGenerator
{
    partial class DocumentGeneratorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentGeneratorForm));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSelectSections = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOutput = new System.Windows.Forms.TextBox();
            this.tbInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.sectionsView = new System.Windows.Forms.TreeView();
            this.btnGenerateFile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.tbTemplate = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonNewTemplate = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.radioButtonExistingTemplate = new System.Windows.Forms.RadioButton();
            this.btnNextFirstPanel = new System.Windows.Forms.Button();
            this.btnOpenTemplate = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonInsertSections = new System.Windows.Forms.RadioButton();
            this.radioButtonFilter = new System.Windows.Forms.RadioButton();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnOpenInput = new System.Windows.Forms.Button();
            this.btnOpenOutput = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnSaveTemplate = new System.Windows.Forms.Button();
            this.checkBoxSaveTemplate = new System.Windows.Forms.CheckBox();
            this.buttonNextSecondPanel = new System.Windows.Forms.Button();
            this.tbSaveTemplate = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.buttonRestorePlaceholders = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.placeHolderKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeHolderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnBack1 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.YellowGreen;
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.progressBar.Location = new System.Drawing.Point(8, 359);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(659, 18);
            this.progressBar.Step = 5;
            this.progressBar.TabIndex = 4;
            // 
            // btnSelectSections
            // 
            this.btnSelectSections.Enabled = false;
            this.btnSelectSections.Location = new System.Drawing.Point(585, 42);
            this.btnSelectSections.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSelectSections.Name = "btnSelectSections";
            this.btnSelectSections.Size = new System.Drawing.Size(82, 55);
            this.btnSelectSections.TabIndex = 11;
            this.btnSelectSections.Text = "Select Sections";
            this.btnSelectSections.UseVisualStyleBackColor = true;
            this.btnSelectSections.Click += new System.EventHandler(this.btnSelectSections_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(108, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(267, 31);
            this.label5.TabIndex = 23;
            this.label5.Text = "Document Generator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Output Path:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Input Path:";
            // 
            // tbOutput
            // 
            this.tbOutput.Location = new System.Drawing.Point(85, 76);
            this.tbOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbOutput.Name = "tbOutput";
            this.tbOutput.Size = new System.Drawing.Size(482, 19);
            this.tbOutput.TabIndex = 6;
            // 
            // tbInput
            // 
            this.tbInput.Enabled = false;
            this.tbInput.Location = new System.Drawing.Point(85, 42);
            this.tbInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbInput.Name = "tbInput";
            this.tbInput.Size = new System.Drawing.Size(482, 19);
            this.tbInput.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AllowDrop = true;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(644, 503);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "v1.0 | ";
            // 
            // sectionsView
            // 
            this.sectionsView.CheckBoxes = true;
            this.sectionsView.Location = new System.Drawing.Point(8, 118);
            this.sectionsView.Name = "sectionsView";
            this.sectionsView.Size = new System.Drawing.Size(659, 228);
            this.sectionsView.TabIndex = 26;
            this.sectionsView.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.sectionsView_AfterCheck);
            // 
            // btnGenerateFile
            // 
            this.btnGenerateFile.Enabled = false;
            this.btnGenerateFile.Location = new System.Drawing.Point(585, 388);
            this.btnGenerateFile.Name = "btnGenerateFile";
            this.btnGenerateFile.Size = new System.Drawing.Size(82, 23);
            this.btnGenerateFile.TabIndex = 27;
            this.btnGenerateFile.Text = "Generate";
            this.btnGenerateFile.UseVisualStyleBackColor = true;
            this.btnGenerateFile.Click += new System.EventHandler(this.btnGenerateFile_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Template File:";
            // 
            // tbTemplate
            // 
            this.tbTemplate.Location = new System.Drawing.Point(101, 126);
            this.tbTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbTemplate.Name = "tbTemplate";
            this.tbTemplate.Size = new System.Drawing.Size(482, 19);
            this.tbTemplate.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonNewTemplate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.radioButtonExistingTemplate);
            this.panel1.Controls.Add(this.btnNextFirstPanel);
            this.panel1.Controls.Add(this.btnOpenTemplate);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.tbTemplate);
            this.panel1.Location = new System.Drawing.Point(24, 79);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 417);
            this.panel1.TabIndex = 31;
            // 
            // radioButtonNewTemplate
            // 
            this.radioButtonNewTemplate.AutoSize = true;
            this.radioButtonNewTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonNewTemplate.Location = new System.Drawing.Point(17, 21);
            this.radioButtonNewTemplate.Name = "radioButtonNewTemplate";
            this.radioButtonNewTemplate.Size = new System.Drawing.Size(158, 20);
            this.radioButtonNewTemplate.TabIndex = 39;
            this.radioButtonNewTemplate.Text = "Create a new template";
            this.radioButtonNewTemplate.UseVisualStyleBackColor = true;
            this.radioButtonNewTemplate.CheckedChanged += new System.EventHandler(this.radioButtonNewTemplate_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(42, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 38;
            this.label3.Text = "or";
            // 
            // radioButtonExistingTemplate
            // 
            this.radioButtonExistingTemplate.AutoSize = true;
            this.radioButtonExistingTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749998F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonExistingTemplate.Location = new System.Drawing.Point(17, 98);
            this.radioButtonExistingTemplate.Name = "radioButtonExistingTemplate";
            this.radioButtonExistingTemplate.Size = new System.Drawing.Size(349, 20);
            this.radioButtonExistingTemplate.TabIndex = 37;
            this.radioButtonExistingTemplate.Text = "Upload your custom Word Document Template (.docx)";
            this.radioButtonExistingTemplate.UseVisualStyleBackColor = true;
            this.radioButtonExistingTemplate.CheckedChanged += new System.EventHandler(this.radioButtonExistingTemplate_CheckedChanged);
            // 
            // btnNextFirstPanel
            // 
            this.btnNextFirstPanel.Enabled = false;
            this.btnNextFirstPanel.Location = new System.Drawing.Point(582, 363);
            this.btnNextFirstPanel.Name = "btnNextFirstPanel";
            this.btnNextFirstPanel.Size = new System.Drawing.Size(75, 23);
            this.btnNextFirstPanel.TabIndex = 36;
            this.btnNextFirstPanel.Text = "Next";
            this.btnNextFirstPanel.UseVisualStyleBackColor = true;
            this.btnNextFirstPanel.Click += new System.EventHandler(this.btnNextFirstPanel_Click);
            // 
            // btnOpenTemplate
            // 
            this.btnOpenTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenTemplate.BackgroundImage = global::DocumentGenerator.Properties.Resources.source;
            this.btnOpenTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenTemplate.Location = new System.Drawing.Point(563, 126);
            this.btnOpenTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenTemplate.Name = "btnOpenTemplate";
            this.btnOpenTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnOpenTemplate.TabIndex = 28;
            this.btnOpenTemplate.UseVisualStyleBackColor = false;
            this.btnOpenTemplate.Click += new System.EventHandler(this.btnOpenTemplate_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.radioButtonInsertSections);
            this.panel2.Controls.Add(this.radioButtonFilter);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnGenerateFile);
            this.panel2.Controls.Add(this.sectionsView);
            this.panel2.Controls.Add(this.progressBar);
            this.panel2.Controls.Add(this.btnSelectSections);
            this.panel2.Controls.Add(this.btnOpenInput);
            this.panel2.Controls.Add(this.btnOpenOutput);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tbInput);
            this.panel2.Controls.Add(this.tbOutput);
            this.panel2.Location = new System.Drawing.Point(24, 78);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 417);
            this.panel2.TabIndex = 32;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(298, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(16, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "or";
            // 
            // radioButtonInsertSections
            // 
            this.radioButtonInsertSections.AutoSize = true;
            this.radioButtonInsertSections.Location = new System.Drawing.Point(346, 3);
            this.radioButtonInsertSections.Name = "radioButtonInsertSections";
            this.radioButtonInsertSections.Size = new System.Drawing.Size(198, 17);
            this.radioButtonInsertSections.TabIndex = 30;
            this.radioButtonInsertSections.TabStop = true;
            this.radioButtonInsertSections.Text = "Insert sections from other documents";
            this.radioButtonInsertSections.UseVisualStyleBackColor = true;
            this.radioButtonInsertSections.CheckedChanged += new System.EventHandler(this.radioButtonInsertSections_CheckedChanged);
            // 
            // radioButtonFilter
            // 
            this.radioButtonFilter.AutoSize = true;
            this.radioButtonFilter.Location = new System.Drawing.Point(36, 3);
            this.radioButtonFilter.Name = "radioButtonFilter";
            this.radioButtonFilter.Size = new System.Drawing.Size(198, 17);
            this.radioButtonFilter.TabIndex = 29;
            this.radioButtonFilter.TabStop = true;
            this.radioButtonFilter.Text = "Filter sections from current document";
            this.radioButtonFilter.UseVisualStyleBackColor = true;
            this.radioButtonFilter.CheckedChanged += new System.EventHandler(this.radioButtonFilter_CheckedChanged);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(8, 388);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 23);
            this.btnBack.TabIndex = 28;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBackThirdPanel_Click);
            // 
            // btnOpenInput
            // 
            this.btnOpenInput.BackColor = System.Drawing.Color.Transparent;
            this.btnOpenInput.BackgroundImage = global::DocumentGenerator.Properties.Resources.source;
            this.btnOpenInput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenInput.Enabled = false;
            this.btnOpenInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenInput.Location = new System.Drawing.Point(547, 42);
            this.btnOpenInput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenInput.Name = "btnOpenInput";
            this.btnOpenInput.Size = new System.Drawing.Size(22, 22);
            this.btnOpenInput.TabIndex = 0;
            this.btnOpenInput.UseVisualStyleBackColor = false;
            this.btnOpenInput.Click += new System.EventHandler(this.btnOpenInput_Click);
            // 
            // btnOpenOutput
            // 
            this.btnOpenOutput.BackgroundImage = global::DocumentGenerator.Properties.Resources.source;
            this.btnOpenOutput.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOpenOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenOutput.Location = new System.Drawing.Point(547, 76);
            this.btnOpenOutput.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOpenOutput.Name = "btnOpenOutput";
            this.btnOpenOutput.Size = new System.Drawing.Size(22, 22);
            this.btnOpenOutput.TabIndex = 7;
            this.btnOpenOutput.Text = "...";
            this.btnOpenOutput.UseVisualStyleBackColor = true;
            this.btnOpenOutput.Click += new System.EventHandler(this.btnOpenOutput_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnSaveTemplate);
            this.panel3.Controls.Add(this.checkBoxSaveTemplate);
            this.panel3.Controls.Add(this.buttonNextSecondPanel);
            this.panel3.Controls.Add(this.tbSaveTemplate);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.btnBack1);
            this.panel3.Location = new System.Drawing.Point(24, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(673, 417);
            this.panel3.TabIndex = 40;
            // 
            // btnSaveTemplate
            // 
            this.btnSaveTemplate.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveTemplate.BackgroundImage = global::DocumentGenerator.Properties.Resources.source;
            this.btnSaveTemplate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveTemplate.Enabled = false;
            this.btnSaveTemplate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveTemplate.Location = new System.Drawing.Point(620, 340);
            this.btnSaveTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSaveTemplate.Name = "btnSaveTemplate";
            this.btnSaveTemplate.Size = new System.Drawing.Size(22, 22);
            this.btnSaveTemplate.TabIndex = 41;
            this.btnSaveTemplate.UseVisualStyleBackColor = false;
            this.btnSaveTemplate.Click += new System.EventHandler(this.btnSaveTemplate_Click);
            // 
            // checkBoxSaveTemplate
            // 
            this.checkBoxSaveTemplate.AutoSize = true;
            this.checkBoxSaveTemplate.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxSaveTemplate.Location = new System.Drawing.Point(25, 341);
            this.checkBoxSaveTemplate.Name = "checkBoxSaveTemplate";
            this.checkBoxSaveTemplate.Size = new System.Drawing.Size(113, 17);
            this.checkBoxSaveTemplate.TabIndex = 6;
            this.checkBoxSaveTemplate.Text = "Save this template";
            this.checkBoxSaveTemplate.UseVisualStyleBackColor = false;
            this.checkBoxSaveTemplate.CheckedChanged += new System.EventHandler(this.checkBoxSaveTemplate_CheckedChanged);
            // 
            // buttonNextSecondPanel
            // 
            this.buttonNextSecondPanel.Location = new System.Drawing.Point(585, 385);
            this.buttonNextSecondPanel.Name = "buttonNextSecondPanel";
            this.buttonNextSecondPanel.Size = new System.Drawing.Size(75, 23);
            this.buttonNextSecondPanel.TabIndex = 5;
            this.buttonNextSecondPanel.Text = "Next";
            this.buttonNextSecondPanel.UseVisualStyleBackColor = true;
            this.buttonNextSecondPanel.Click += new System.EventHandler(this.buttonNextSecondPanel_Click);
            // 
            // tbSaveTemplate
            // 
            this.tbSaveTemplate.Enabled = false;
            this.tbSaveTemplate.Location = new System.Drawing.Point(167, 340);
            this.tbSaveTemplate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbSaveTemplate.Name = "tbSaveTemplate";
            this.tbSaveTemplate.Size = new System.Drawing.Size(473, 19);
            this.tbSaveTemplate.TabIndex = 42;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.buttonRestorePlaceholders);
            this.panel4.Controls.Add(this.dataGridView1);
            this.panel4.Location = new System.Drawing.Point(17, 11);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(1);
            this.panel4.Size = new System.Drawing.Size(640, 323);
            this.panel4.TabIndex = 3;
            // 
            // buttonRestorePlaceholders
            // 
            this.buttonRestorePlaceholders.Location = new System.Drawing.Point(547, 0);
            this.buttonRestorePlaceholders.Name = "buttonRestorePlaceholders";
            this.buttonRestorePlaceholders.Size = new System.Drawing.Size(75, 23);
            this.buttonRestorePlaceholders.TabIndex = 41;
            this.buttonRestorePlaceholders.TabStop = false;
            this.buttonRestorePlaceholders.Text = "Restore";
            this.buttonRestorePlaceholders.UseVisualStyleBackColor = true;
            this.buttonRestorePlaceholders.Click += new System.EventHandler(this.buttonRestorePlaceholders_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.placeHolderKey,
            this.placeHolderValue});
            this.dataGridView1.GridColor = System.Drawing.Color.Gray;
            this.dataGridView1.Location = new System.Drawing.Point(-51, -1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(718, 326);
            this.dataGridView1.TabIndex = 2;
            // 
            // placeHolderKey
            // 
            this.placeHolderKey.HeaderText = "Key";
            this.placeHolderKey.MinimumWidth = 6;
            this.placeHolderKey.Name = "placeHolderKey";
            this.placeHolderKey.ReadOnly = true;
            this.placeHolderKey.Width = 150;
            // 
            // placeHolderValue
            // 
            this.placeHolderValue.HeaderText = "Value";
            this.placeHolderValue.MinimumWidth = 6;
            this.placeHolderValue.Name = "placeHolderValue";
            this.placeHolderValue.Width = 470;
            // 
            // btnBack1
            // 
            this.btnBack1.Location = new System.Drawing.Point(19, 385);
            this.btnBack1.Name = "btnBack1";
            this.btnBack1.Size = new System.Drawing.Size(75, 23);
            this.btnBack1.TabIndex = 0;
            this.btnBack1.Text = "Back";
            this.btnBack1.UseVisualStyleBackColor = true;
            this.btnBack1.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 23.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 35);
            this.label6.TabIndex = 24;
            this.label6.Text = "|";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::DocumentGenerator.Properties.Resources.github_mark;
            this.pictureBox2.Location = new System.Drawing.Point(679, 498);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 42;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::DocumentGenerator.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(34, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 41;
            this.pictureBox1.TabStop = false;
            // 
            // DocumentGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(720, 522);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.799999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "DocumentGeneratorForm";
            this.Text = "Document Generator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DocumentGeneratorForm_FormClosing);
            this.Load += new System.EventHandler(this.DocumentGeneratorForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnSelectSections;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpenOutput;
        private System.Windows.Forms.TextBox tbOutput;
        private System.Windows.Forms.Button btnOpenInput;
        private System.Windows.Forms.TextBox tbInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TreeView sectionsView;
        private System.Windows.Forms.Button btnGenerateFile;
        private System.Windows.Forms.Button btnOpenTemplate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbTemplate;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNextFirstPanel;
        private System.Windows.Forms.RadioButton radioButtonNewTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButtonExistingTemplate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnBack1;
        private System.Windows.Forms.Button buttonNextSecondPanel;
        private System.Windows.Forms.CheckBox checkBoxSaveTemplate;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeHolderKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeHolderValue;
        private System.Windows.Forms.Button btnSaveTemplate;
        private System.Windows.Forms.TextBox tbSaveTemplate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonInsertSections;
        private System.Windows.Forms.RadioButton radioButtonFilter;
        private System.Windows.Forms.Button buttonRestorePlaceholders;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}

