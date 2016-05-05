namespace SEND_VIA_SOCKET
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Myip = new System.Windows.Forms.TextBox();
            this.Myport = new System.Windows.Forms.TextBox();
            this.Remoteip = new System.Windows.Forms.TextBox();
            this.Remoteport = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port :";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(259, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 59);
            this.button1.TabIndex = 2;
            this.button1.Text = "My";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "My IP :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "My Port :";
            // 
            // Myip
            // 
            this.Myip.Location = new System.Drawing.Point(88, 74);
            this.Myip.Name = "Myip";
            this.Myip.Size = new System.Drawing.Size(165, 20);
            this.Myip.TabIndex = 5;
            // 
            // Myport
            // 
            this.Myport.Location = new System.Drawing.Point(88, 107);
            this.Myport.Name = "Myport";
            this.Myport.Size = new System.Drawing.Size(165, 20);
            this.Myport.TabIndex = 6;
            // 
            // Remoteip
            // 
            this.Remoteip.Location = new System.Drawing.Point(88, 12);
            this.Remoteip.Name = "Remoteip";
            this.Remoteip.Size = new System.Drawing.Size(165, 20);
            this.Remoteip.TabIndex = 7;
            // 
            // Remoteport
            // 
            this.Remoteport.Location = new System.Drawing.Point(88, 43);
            this.Remoteport.Name = "Remoteport";
            this.Remoteport.Size = new System.Drawing.Size(165, 20);
            this.Remoteport.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(13, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Notify !!!";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 181);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Remoteport);
            this.Controls.Add(this.Remoteip);
            this.Controls.Add(this.Myport);
            this.Controls.Add(this.Myip);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Myip;
        private System.Windows.Forms.TextBox Myport;
        private System.Windows.Forms.TextBox Remoteip;
        private System.Windows.Forms.TextBox Remoteport;
        private System.Windows.Forms.Button button2;
    }
}

