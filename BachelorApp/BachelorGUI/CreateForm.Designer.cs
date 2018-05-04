namespace BachelorGUI
{
    partial class CreateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateForm));
            this.CreateBTN = new System.Windows.Forms.Button();
            this.ConUTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.descTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nodeCB = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DeviceCB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.commentRTB = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CreateBTN
            // 
            this.CreateBTN.Location = new System.Drawing.Point(12, 285);
            this.CreateBTN.Name = "CreateBTN";
            this.CreateBTN.Size = new System.Drawing.Size(183, 29);
            this.CreateBTN.TabIndex = 13;
            this.CreateBTN.Text = "Create Node";
            this.CreateBTN.UseVisualStyleBackColor = true;
            this.CreateBTN.Click += new System.EventHandler(this.CreateBTN_Click);
            // 
            // ConUTB
            // 
            this.ConUTB.Location = new System.Drawing.Point(12, 144);
            this.ConUTB.Name = "ConUTB";
            this.ConUTB.Size = new System.Drawing.Size(183, 20);
            this.ConUTB.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Connected Users:";
            // 
            // descTB
            // 
            this.descTB.Location = new System.Drawing.Point(12, 105);
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(183, 20);
            this.descTB.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Parent Node:";
            // 
            // nodeCB
            // 
            this.nodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeCB.FormattingEnabled = true;
            this.nodeCB.Location = new System.Drawing.Point(12, 25);
            this.nodeCB.Name = "nodeCB";
            this.nodeCB.Size = new System.Drawing.Size(183, 21);
            this.nodeCB.TabIndex = 7;
            this.nodeCB.SelectionChangeCommitted += new System.EventHandler(this.nodeCB_SelectionChangeCommitted);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Device Type:";
            // 
            // DeviceCB
            // 
            this.DeviceCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DeviceCB.FormattingEnabled = true;
            this.DeviceCB.Location = new System.Drawing.Point(12, 65);
            this.DeviceCB.Name = "DeviceCB";
            this.DeviceCB.Size = new System.Drawing.Size(183, 21);
            this.DeviceCB.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Comment:";
            // 
            // commentRTB
            // 
            this.commentRTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.commentRTB.Location = new System.Drawing.Point(12, 183);
            this.commentRTB.Name = "commentRTB";
            this.commentRTB.Size = new System.Drawing.Size(182, 96);
            this.commentRTB.TabIndex = 16;
            this.commentRTB.Text = "";
            // 
            // CreateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 322);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.commentRTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.DeviceCB);
            this.Controls.Add(this.CreateBTN);
            this.Controls.Add(this.ConUTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nodeCB);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(222, 361);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(222, 361);
            this.Name = "CreateForm";
            this.Text = "Create a new Node";
            this.Load += new System.EventHandler(this.CreateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateBTN;
        private System.Windows.Forms.TextBox ConUTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox nodeCB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox DeviceCB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox commentRTB;
    }
}