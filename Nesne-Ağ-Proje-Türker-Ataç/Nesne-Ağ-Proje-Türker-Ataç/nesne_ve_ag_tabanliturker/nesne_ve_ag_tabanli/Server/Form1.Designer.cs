namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing && (components != null))
        //    {
        //        components.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_port = new System.Windows.Forms.Label();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.rct_serverLog = new System.Windows.Forms.RichTextBox();
            this.Btn_List = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lb_port.Location = new System.Drawing.Point(11, 20);
            this.lb_port.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(46, 20);
            this.lb_port.TabIndex = 0;
            this.lb_port.Text = "Port :";
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(61, 22);
            this.txt_port.Margin = new System.Windows.Forms.Padding(2);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(76, 20);
            this.txt_port.TabIndex = 1;
            // 
            // rct_serverLog
            // 
            this.rct_serverLog.Location = new System.Drawing.Point(11, 52);
            this.rct_serverLog.Margin = new System.Windows.Forms.Padding(2);
            this.rct_serverLog.Name = "rct_serverLog";
            this.rct_serverLog.Size = new System.Drawing.Size(200, 292);
            this.rct_serverLog.TabIndex = 2;
            this.rct_serverLog.Text = "";
            // 
            // Btn_List
            // 
            this.Btn_List.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_List.Location = new System.Drawing.Point(157, 20);
            this.Btn_List.Margin = new System.Windows.Forms.Padding(2);
            this.Btn_List.Name = "Btn_List";
            this.Btn_List.Size = new System.Drawing.Size(54, 24);
            this.Btn_List.TabIndex = 3;
            this.Btn_List.Text = "Dinle";
            this.Btn_List.UseVisualStyleBackColor = true;
            this.Btn_List.Click += new System.EventHandler(this.Btn_List_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(222, 352);
            this.Controls.Add(this.Btn_List);
            this.Controls.Add(this.rct_serverLog);
            this.Controls.Add(this.txt_port);
            this.Controls.Add(this.lb_port);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Server";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.RichTextBox rct_serverLog;
        private System.Windows.Forms.Button Btn_List;
    }
}

