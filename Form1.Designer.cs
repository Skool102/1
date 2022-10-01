
namespace Buoi02
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
            this.btnCham = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtThreads = new System.Windows.Forms.TextBox();
            this.btnNhanh = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbKetqua = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCham
            // 
            this.btnCham.Location = new System.Drawing.Point(251, 5);
            this.btnCham.Name = "btnCham";
            this.btnCham.Size = new System.Drawing.Size(110, 26);
            this.btnCham.TabIndex = 0;
            this.btnCham.Text = "Ưu tiên thấp";
            this.btnCham.UseVisualStyleBackColor = true;
            this.btnCham.Click += new System.EventHandler(this.btnCham_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập số thread cần chạy";
            // 
            // txtThreads
            // 
            this.txtThreads.Location = new System.Drawing.Point(145, 9);
            this.txtThreads.Name = "txtThreads";
            this.txtThreads.Size = new System.Drawing.Size(100, 20);
            this.txtThreads.TabIndex = 2;
            // 
            // btnNhanh
            // 
            this.btnNhanh.Location = new System.Drawing.Point(367, 5);
            this.btnNhanh.Name = "btnNhanh";
            this.btnNhanh.Size = new System.Drawing.Size(74, 26);
            this.btnNhanh.TabIndex = 3;
            this.btnNhanh.Text = "Ưu tiên cao";
            this.btnNhanh.UseVisualStyleBackColor = true;
            this.btnNhanh.Click += new System.EventHandler(this.btnNhanh_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(447, 5);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(109, 26);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Tính tích 2 ma trận";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbKetqua
            // 
            this.lbKetqua.FormattingEnabled = true;
            this.lbKetqua.Location = new System.Drawing.Point(12, 35);
            this.lbKetqua.Name = "lbKetqua";
            this.lbKetqua.Size = new System.Drawing.Size(544, 420);
            this.lbKetqua.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 450);
            this.Controls.Add(this.lbKetqua);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnNhanh);
            this.Controls.Add(this.txtThreads);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCham);
            this.Name = "Form1";
            this.Text = "Form1";
            
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCham;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThreads;
        private System.Windows.Forms.Button btnNhanh;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ListBox lbKetqua;
    }
}

