namespace PaintCheck
{
    partial class Form1
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
            this.deleteBtn = new System.Windows.Forms.Button();
            this.successList = new System.Windows.Forms.ListBox();
            this.failList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.Location = new System.Drawing.Point(70, 87);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(196, 97);
            this.deleteBtn.TabIndex = 0;
            this.deleteBtn.Text = "TÖRLÉS";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // successList
            // 
            this.successList.FormattingEnabled = true;
            this.successList.Location = new System.Drawing.Point(388, 43);
            this.successList.Name = "successList";
            this.successList.Size = new System.Drawing.Size(192, 238);
            this.successList.TabIndex = 1;
            // 
            // failList
            // 
            this.failList.FormattingEnabled = true;
            this.failList.Location = new System.Drawing.Point(619, 43);
            this.failList.Name = "failList";
            this.failList.Size = new System.Drawing.Size(186, 238);
            this.failList.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(388, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sikeres törlések";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(619, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sikertelen törlések";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 307);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.failList);
            this.Controls.Add(this.successList);
            this.Controls.Add(this.deleteBtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button deleteBtn;
        private System.Windows.Forms.ListBox successList;
        private System.Windows.Forms.ListBox failList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

