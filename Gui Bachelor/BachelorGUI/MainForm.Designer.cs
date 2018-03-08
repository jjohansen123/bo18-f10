namespace WindowsFormsApp1
{
    partial class mainForm1
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
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // createBtn
            // 
            this.createBtn.Location = new System.Drawing.Point(6, 682);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(302, 46);
            this.createBtn.TabIndex = 1;
            this.createBtn.Text = "Create";
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(6, 786);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(302, 46);
            this.deleteBtn.TabIndex = 2;
            this.deleteBtn.Text = "Delete";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // baseBtn
            // 
            this.baseBtn.Appearance = System.Windows.Forms.Appearance.Button;
            this.baseBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.baseBtn.Checked = true;
            this.baseBtn.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.baseBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.baseBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.baseBtn.Location = new System.Drawing.Point(20, 375);
            this.baseBtn.Name = "baseBtn";
            this.baseBtn.Size = new System.Drawing.Size(120, 80);
            this.baseBtn.TabIndex = 0;
            this.baseBtn.TabStop = true;
            this.baseBtn.Tag = "temp1";
            this.baseBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.baseBtn);
            this.panel1.Location = new System.Drawing.Point(314, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1252, 820);
            this.panel1.TabIndex = 3;
            // 
            // changeBTN
            // 
            this.changeBTN.Location = new System.Drawing.Point(6, 734);
            this.changeBTN.Name = "changeBTN";
            this.changeBTN.Size = new System.Drawing.Size(302, 46);
            this.changeBTN.TabIndex = 4;
            this.changeBTN.Text = "Change";
            this.changeBTN.UseVisualStyleBackColor = true;
            // 
            // mainForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1578, 844);
            this.Controls.Add(this.changeBTN);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.deleteBtn);
            this.Controls.Add(this.createBtn);
            this.Name = "mainForm1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Test123";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.RadioButton baseBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button changeBTN;
    }
}

