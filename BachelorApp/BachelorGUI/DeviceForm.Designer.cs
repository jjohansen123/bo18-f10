namespace BachelorGUI
{
    partial class DeviceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeviceForm));
            this.SaveBTN = new System.Windows.Forms.Button();
            this.RouterCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NameTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Range1TB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Range2TB = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteBTN = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(12, 112);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(121, 23);
            this.SaveBTN.TabIndex = 0;
            this.SaveBTN.Text = "Save Changes";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveBTN_Click);
            // 
            // RouterCB
            // 
            this.RouterCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RouterCB.FormattingEnabled = true;
            this.RouterCB.Location = new System.Drawing.Point(139, 7);
            this.RouterCB.Name = "RouterCB";
            this.RouterCB.Size = new System.Drawing.Size(121, 21);
            this.RouterCB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Switch/Router to change:";
            // 
            // NameTB
            // 
            this.NameTB.Location = new System.Drawing.Point(139, 34);
            this.NameTB.Name = "NameTB";
            this.NameTB.Size = new System.Drawing.Size(121, 20);
            this.NameTB.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(82, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Range 1:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Range 2:";
            // 
            // Range1TB
            // 
            this.Range1TB.Location = new System.Drawing.Point(139, 60);
            this.Range1TB.Name = "Range1TB";
            this.Range1TB.Size = new System.Drawing.Size(121, 20);
            this.Range1TB.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Switch/Router name:";
            // 
            // Range2TB
            // 
            this.Range2TB.Location = new System.Drawing.Point(139, 86);
            this.Range2TB.Name = "Range2TB";
            this.Range2TB.Size = new System.Drawing.Size(121, 20);
            this.Range2TB.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Create New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DeleteBTN
            // 
            this.DeleteBTN.Location = new System.Drawing.Point(266, 112);
            this.DeleteBTN.Name = "DeleteBTN";
            this.DeleteBTN.Size = new System.Drawing.Size(121, 23);
            this.DeleteBTN.TabIndex = 12;
            this.DeleteBTN.Text = "Delete Selected";
            this.DeleteBTN.UseVisualStyleBackColor = true;
            this.DeleteBTN.Click += new System.EventHandler(this.DeleteBTN_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(285, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Blank = no changes";
            // 
            // DeviceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 144);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DeleteBTN);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Range2TB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Range1TB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RouterCB);
            this.Controls.Add(this.SaveBTN);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeviceForm";
            this.Text = "Device Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.ComboBox RouterCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Range1TB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Range2TB;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DeleteBTN;
        private System.Windows.Forms.Label label5;
    }
}