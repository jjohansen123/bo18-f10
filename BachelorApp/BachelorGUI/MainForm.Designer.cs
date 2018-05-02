using System.Windows.Forms;

namespace BachelorGUI
{
    partial class MainForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm1));
            this.createBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.baseBtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeBTN = new System.Windows.Forms.Button();
            this.descTB = new System.Windows.Forms.TextBox();
            this.descLBL = new System.Windows.Forms.Label();
            this.conULBL = new System.Windows.Forms.Label();
            this.conUTB = new System.Windows.Forms.TextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.outputLBL = new System.Windows.Forms.Label();
            this.idLBL = new System.Windows.Forms.Label();
            this.idTB = new System.Windows.Forms.TextBox();
            this.SchoolBtn = new System.Windows.Forms.Button();
            this.siteCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TConUTB = new System.Windows.Forms.TextBox();
            this.DeviceBTN = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.createBtn.Location = new System.Drawing.Point(4, 443);
            this.createBtn.Margin = new System.Windows.Forms.Padding(2);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(201, 30);
            this.createBtn.TabIndex = 1;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.deleteBtn.Location = new System.Drawing.Point(4, 511);
            this.deleteBtn.Margin = new System.Windows.Forms.Padding(2);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(201, 30);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // baseBtn
            // 
            this.baseBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.baseBtn.BackColor = System.Drawing.Color.Blue;
            this.baseBtn.Checked = true;
            this.baseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkBlue;
            this.baseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkBlue;
            this.baseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseBtn.Location = new System.Drawing.Point(13, 244);
            this.baseBtn.Margin = new System.Windows.Forms.Padding(2);
            this.baseBtn.Name = "baseBtn";
            this.baseBtn.Size = new System.Drawing.Size(80, 52);
            this.baseBtn.TabIndex = 0;
            this.baseBtn.TabStop = true;
            this.baseBtn.Tag = "temp1";
            this.baseBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.baseBtn.UseVisualStyleBackColor = false;
            this.baseBtn.CheckedChanged += new System.EventHandler(this.baseBtn_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.baseBtn);
            this.panel1.Location = new System.Drawing.Point(209, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(835, 534);
            this.panel1.TabIndex = 3;
            this.panel1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.panel1_ControlAdded);
            // 
            // changeBTN
            // 
            this.changeBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.changeBTN.Location = new System.Drawing.Point(4, 477);
            this.changeBTN.Margin = new System.Windows.Forms.Padding(2);
            this.changeBTN.Name = "changeBTN";
            this.changeBTN.Size = new System.Drawing.Size(201, 30);
            this.changeBTN.TabIndex = 4;
            this.changeBTN.Text = "Change";
            this.changeBTN.UseVisualStyleBackColor = true;
            this.changeBTN.Click += new System.EventHandler(this.changeBTN_Click);
            // 
            // descTB
            // 
            this.descTB.Location = new System.Drawing.Point(4, 131);
            this.descTB.Name = "descTB";
            this.descTB.ReadOnly = true;
            this.descTB.Size = new System.Drawing.Size(200, 20);
            this.descTB.TabIndex = 5;
            // 
            // descLBL
            // 
            this.descLBL.AutoSize = true;
            this.descLBL.Location = new System.Drawing.Point(1, 115);
            this.descLBL.Name = "descLBL";
            this.descLBL.Size = new System.Drawing.Size(63, 13);
            this.descLBL.TabIndex = 6;
            this.descLBL.Text = "Description:";
            // 
            // conULBL
            // 
            this.conULBL.AutoSize = true;
            this.conULBL.Location = new System.Drawing.Point(1, 155);
            this.conULBL.Name = "conULBL";
            this.conULBL.Size = new System.Drawing.Size(92, 13);
            this.conULBL.TabIndex = 8;
            this.conULBL.Text = "Connected Users:";
            // 
            // conUTB
            // 
            this.conUTB.Location = new System.Drawing.Point(4, 171);
            this.conUTB.Name = "conUTB";
            this.conUTB.ReadOnly = true;
            this.conUTB.Size = new System.Drawing.Size(200, 20);
            this.conUTB.TabIndex = 7;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.richTextBox1.Location = new System.Drawing.Point(4, 253);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(200, 185);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // outputLBL
            // 
            this.outputLBL.AutoSize = true;
            this.outputLBL.Location = new System.Drawing.Point(4, 234);
            this.outputLBL.Name = "outputLBL";
            this.outputLBL.Size = new System.Drawing.Size(42, 13);
            this.outputLBL.TabIndex = 11;
            this.outputLBL.Text = "Output:";
            // 
            // idLBL
            // 
            this.idLBL.AutoSize = true;
            this.idLBL.Location = new System.Drawing.Point(1, 76);
            this.idLBL.Name = "idLBL";
            this.idLBL.Size = new System.Drawing.Size(21, 13);
            this.idLBL.TabIndex = 13;
            this.idLBL.Text = "ID:";
            // 
            // idTB
            // 
            this.idTB.Cursor = System.Windows.Forms.Cursors.Default;
            this.idTB.Location = new System.Drawing.Point(4, 92);
            this.idTB.Name = "idTB";
            this.idTB.ReadOnly = true;
            this.idTB.Size = new System.Drawing.Size(200, 20);
            this.idTB.TabIndex = 12;
            // 
            // SchoolBtn
            // 
            this.SchoolBtn.Location = new System.Drawing.Point(179, 7);
            this.SchoolBtn.Name = "SchoolBtn";
            this.SchoolBtn.Size = new System.Drawing.Size(25, 22);
            this.SchoolBtn.TabIndex = 14;
            this.SchoolBtn.Text = "+";
            this.SchoolBtn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SchoolBtn.UseVisualStyleBackColor = true;
            this.SchoolBtn.Click += new System.EventHandler(this.SchoolBtn_Click);
            // 
            // siteCB
            // 
            this.siteCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.siteCB.FormattingEnabled = true;
            this.siteCB.Location = new System.Drawing.Point(4, 8);
            this.siteCB.Name = "siteCB";
            this.siteCB.Size = new System.Drawing.Size(170, 21);
            this.siteCB.TabIndex = 15;
            this.siteCB.SelectionChangeCommitted += new System.EventHandler(this.siteCB_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1, 195);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Total Connected Users:";
            // 
            // TConUTB
            // 
            this.TConUTB.Location = new System.Drawing.Point(4, 211);
            this.TConUTB.Name = "TConUTB";
            this.TConUTB.ReadOnly = true;
            this.TConUTB.Size = new System.Drawing.Size(200, 20);
            this.TConUTB.TabIndex = 16;
            // 
            // DeviceBTN
            // 
            this.DeviceBTN.Location = new System.Drawing.Point(4, 35);
            this.DeviceBTN.Name = "DeviceBTN";
            this.DeviceBTN.Size = new System.Drawing.Size(200, 23);
            this.DeviceBTN.TabIndex = 18;
            this.DeviceBTN.Text = "Device Options";
            this.DeviceBTN.UseVisualStyleBackColor = true;
            this.DeviceBTN.Click += new System.EventHandler(this.DeviceBTN_Click);
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 549);
            this.Controls.Add(this.DeviceBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TConUTB);
            this.Controls.Add(this.siteCB);
            this.Controls.Add(this.SchoolBtn);
            this.Controls.Add(this.idLBL);
            this.Controls.Add(this.idTB);
            this.Controls.Add(this.outputLBL);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.conULBL);
            this.Controls.Add(this.conUTB);
            this.Controls.Add(this.descLBL);
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.changeBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1068, 588);
            this.Name = "MainForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Test";
            this.Activated += new System.EventHandler(this.MainForm1_Activated);
            this.Load += new System.EventHandler(this.MainForm1_Load);
            this.Shown += new System.EventHandler(this.MainForm1_Shown);
            this.SizeChanged += new System.EventHandler(this.MainForm1_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.RadioButton baseBtn;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button changeBTN;
        public System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Label descLBL;
        private System.Windows.Forms.Label conULBL;
        public System.Windows.Forms.TextBox conUTB;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label outputLBL;
        private System.Windows.Forms.Label idLBL;
        public System.Windows.Forms.TextBox idTB;
        private System.Windows.Forms.Button SchoolBtn;
        private ComboBox siteCB;
        private Label label1;
        public TextBox TConUTB;
        private Button DeviceBTN;
    }
}

