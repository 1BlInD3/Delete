namespace PaintCheck
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.deleteBtn = new System.Windows.Forms.Button();
            this.successList = new System.Windows.Forms.ListBox();
            this.failList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.allLabel = new System.Windows.Forms.Label();
            this.successLabel = new System.Windows.Forms.Label();
            this.failLabel = new System.Windows.Forms.Label();
            this.noFolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // deleteBtn
            // 
            this.deleteBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteBtn.Location = new System.Drawing.Point(38, 103);
            this.deleteBtn.Name = "deleteBtn";
            this.deleteBtn.Size = new System.Drawing.Size(222, 134);
            this.deleteBtn.TabIndex = 0;
            this.deleteBtn.Text = "TÖRLÉS";
            this.deleteBtn.UseVisualStyleBackColor = true;
            this.deleteBtn.Click += new System.EventHandler(this.deleteBtn_Click);
            // 
            // successList
            // 
            this.successList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.successList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.successList.FormattingEnabled = true;
            this.successList.ItemHeight = 16;
            this.successList.Location = new System.Drawing.Point(291, 43);
            this.successList.Name = "successList";
            this.successList.Size = new System.Drawing.Size(308, 228);
            this.successList.TabIndex = 1;
            this.successList.SelectedIndexChanged += new System.EventHandler(this.successList_SelectedIndexChanged);
            // 
            // failList
            // 
            this.failList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.failList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.failList.FormattingEnabled = true;
            this.failList.ItemHeight = 16;
            this.failList.Location = new System.Drawing.Point(633, 43);
            this.failList.Name = "failList";
            this.failList.Size = new System.Drawing.Size(186, 228);
            this.failList.TabIndex = 2;
            this.failList.SelectedIndexChanged += new System.EventHandler(this.failList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(288, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Sikeres törlések";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(630, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sikertelen törlések";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(288, 312);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sikeres törlések : ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(630, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Sikertelen törlések : ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(630, 312);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nem létező mappák : ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(291, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Összes mappa : ";
            // 
            // allLabel
            // 
            this.allLabel.AutoSize = true;
            this.allLabel.Location = new System.Drawing.Point(408, 286);
            this.allLabel.Name = "allLabel";
            this.allLabel.Size = new System.Drawing.Size(28, 13);
            this.allLabel.TabIndex = 9;
            this.allLabel.Text = "0 db";
            // 
            // successLabel
            // 
            this.successLabel.AutoSize = true;
            this.successLabel.Location = new System.Drawing.Point(408, 312);
            this.successLabel.Name = "successLabel";
            this.successLabel.Size = new System.Drawing.Size(28, 13);
            this.successLabel.TabIndex = 10;
            this.successLabel.Text = "0 db";
            // 
            // failLabel
            // 
            this.failLabel.AutoSize = true;
            this.failLabel.Location = new System.Drawing.Point(791, 286);
            this.failLabel.Name = "failLabel";
            this.failLabel.Size = new System.Drawing.Size(28, 13);
            this.failLabel.TabIndex = 11;
            this.failLabel.Text = "0 db";
            // 
            // noFolderLabel
            // 
            this.noFolderLabel.AutoSize = true;
            this.noFolderLabel.Location = new System.Drawing.Point(791, 312);
            this.noFolderLabel.Name = "noFolderLabel";
            this.noFolderLabel.Size = new System.Drawing.Size(28, 13);
            this.noFolderLabel.TabIndex = 12;
            this.noFolderLabel.Text = "0 db";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 344);
            this.Controls.Add(this.noFolderLabel);
            this.Controls.Add(this.failLabel);
            this.Controls.Add(this.successLabel);
            this.Controls.Add(this.allLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.failList);
            this.Controls.Add(this.successList);
            this.Controls.Add(this.deleteBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "mainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PaintCheckDelete";
            this.TopMost = true;
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label allLabel;
        private System.Windows.Forms.Label successLabel;
        private System.Windows.Forms.Label failLabel;
        private System.Windows.Forms.Label noFolderLabel;
    }
}

