namespace BachelorGUI
{
    partial class SiteForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SiteForm));
            this.SiteCB = new System.Windows.Forms.ComboBox();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.CreateBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SiteCB
            // 
            this.SiteCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SiteCB.FormattingEnabled = true;
            this.SiteCB.Location = new System.Drawing.Point(12, 25);
            this.SiteCB.Name = "SiteCB";
            this.SiteCB.Size = new System.Drawing.Size(121, 21);
            this.SiteCB.TabIndex = 0;
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(139, 26);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(147, 20);
            this.NameTB.TabIndex = 1;
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(12, 52);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(121, 38);
            this.DeleteBTN.TabIndex = 2;
            this.DeleteBTN.Text = "Delete selected Site";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // CreateBTN
            // 
            this.CreateBTN.Location = new System.Drawing.Point(140, 52);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(146, 38);
            this.CreateBTN.TabIndex = 3;
            this.CreateBTN.Text = "Create new Site";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select site:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Site Name:";
            // 
            // SiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(298, 101);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateBTN);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.SiteCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(314, 140);
            this.MinimumSize = new System.Drawing.Size(314, 140);
            this.Name = "SiteForm";
            this.Text = "Site Options";
            this.Load += new System.EventHandler(this.SiteForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SiteCB;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Button CreateBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}