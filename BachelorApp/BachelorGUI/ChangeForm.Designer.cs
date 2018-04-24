namespace BachelorGUI
{
    partial class ChangeForm
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
            this.nodeCB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.descTB = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ConUTB = new System.Windows.Forms.TextBox();
            this.ChangeBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nodeCB
            // 
            this.nodeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.nodeCB.FormattingEnabled = true;
            this.nodeCB.Location = new System.Drawing.Point(12, 25);
            this.nodeCB.Name = "nodeCB";
            this.nodeCB.Size = new System.Drawing.Size(178, 21);
            this.nodeCB.TabIndex = 0;
            this.nodeCB.SelectionChangeCommitted += new System.EventHandler(this.nodeCB_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chosen Node:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // descTB
            // 
            this.descTB.Location = new System.Drawing.Point(12, 65);
            this.descTB.Name = "descTB";
            this.descTB.Size = new System.Drawing.Size(178, 20);
            this.descTB.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Connected Users:";
            // 
            // ConUTB
            // 
            this.ConUTB.Location = new System.Drawing.Point(12, 104);
            this.ConUTB.Name = "ConUTB";
            this.ConUTB.Size = new System.Drawing.Size(178, 20);
            this.ConUTB.TabIndex = 5;
            // 
            // ChangeBTN
            // 
            this.ChangeBTN.Location = new System.Drawing.Point(12, 132);
            this.ChangeBTN.Name = "ChangeBTN";
            this.ChangeBTN.Size = new System.Drawing.Size(178, 29);
            this.ChangeBTN.TabIndex = 6;
            this.ChangeBTN.Text = "Change Node";
            this.ChangeBTN.UseVisualStyleBackColor = true;
            this.ChangeBTN.Click += new System.EventHandler(this.ChangeBTN_Click);
            // 
            // ChangeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 173);
            this.Controls.Add(this.ChangeBTN);
            this.Controls.Add(this.ConUTB);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.descTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nodeCB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeForm";
            this.Text = "ChangeForm";
            this.Load += new System.EventHandler(this.ChangeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox nodeCB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox descTB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ConUTB;
        private System.Windows.Forms.Button ChangeBTN;
    }
}