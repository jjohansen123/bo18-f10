﻿namespace BachelorGUI
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
            this.createBtn = new System.Windows.Forms.Button();
            this.deleteBtn = new System.Windows.Forms.Button();
            this.baseBtn = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.changeBTN = new System.Windows.Forms.Button();
            this.descTB = new System.Windows.Forms.TextBox();
            this.descLBL = new System.Windows.Forms.Label();
            this.conULBL = new System.Windows.Forms.Label();
            this.conUTB = new System.Windows.Forms.TextBox();
            this.schoolCB = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.outputLBL = new System.Windows.Forms.Label();
            this.idLBL = new System.Windows.Forms.Label();
            this.idTB = new System.Windows.Forms.TextBox();
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
            this.baseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.baseBtn.Checked = true;
            this.baseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.baseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
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
            this.descTB.Location = new System.Drawing.Point(4, 149);
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(200, 20);
            this.descTB.TabIndex = 5;
            // 
            // descLBL
            // 
            this.descLBL.AutoSize = true;
            this.descLBL.Location = new System.Drawing.Point(1, 133);
            this.descLBL.Name = "descLBL";
            this.descLBL.Size = new System.Drawing.Size(63, 13);
            this.descLBL.TabIndex = 6;
            this.descLBL.Text = "Description:";
            // 
            // conULBL
            // 
            this.conULBL.AutoSize = true;
            this.conULBL.Location = new System.Drawing.Point(1, 173);
            this.conULBL.Name = "conULBL";
            this.conULBL.Size = new System.Drawing.Size(92, 13);
            this.conULBL.TabIndex = 8;
            this.conULBL.Text = "Connected Users:";
            // 
            // conUTB
            // 
            this.conUTB.Location = new System.Drawing.Point(4, 189);
            this.conUTB.Name = "conUTB";
            this.conUTB.Size = new System.Drawing.Size(200, 20);
            this.conUTB.TabIndex = 7;
            // 
            // schoolCB
            // 
            this.schoolCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schoolCB.FormattingEnabled = true;
            this.schoolCB.Location = new System.Drawing.Point(4, 8);
            this.schoolCB.Name = "schoolCB";
            this.schoolCB.Size = new System.Drawing.Size(201, 21);
            this.schoolCB.TabIndex = 9;
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
            this.richTextBox1.Text = "";
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
            this.idLBL.Location = new System.Drawing.Point(1, 94);
            this.idLBL.Name = "idLBL";
            this.idLBL.Size = new System.Drawing.Size(21, 13);
            this.idLBL.TabIndex = 13;
            this.idLBL.Text = "ID:";
            // 
            // idTB
            // 
            this.idTB.Cursor = System.Windows.Forms.Cursors.Default;
            this.idTB.Location = new System.Drawing.Point(4, 110);
            this.idTB.Name = "idTB";
            this.idTB.ReadOnly = true;
            this.idTB.Size = new System.Drawing.Size(200, 20);
            this.idTB.TabIndex = 12;
            // 
            // MainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1052, 549);
            this.Controls.Add(this.idLBL);
            this.Controls.Add(this.idTB);
            this.Controls.Add(this.outputLBL);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.schoolCB);
            this.Controls.Add(this.conULBL);
            this.Controls.Add(this.conUTB);
            this.Controls.Add(this.descLBL);
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.changeBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Network Test";
            this.Load += new System.EventHandler(this.MainForm1_Load);
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
        private System.Windows.Forms.ComboBox schoolCB;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label outputLBL;
        private System.Windows.Forms.Label idLBL;
        public System.Windows.Forms.TextBox idTB;
    }
}

