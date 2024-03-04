namespace client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tx_post = new System.Windows.Forms.TextBox();
            this.bt_disconnect = new System.Windows.Forms.Button();
            this.Bt_SendPost = new System.Windows.Forms.Button();
            this.Bt_All_Posts = new System.Windows.Forms.Button();
            this.clientLog = new System.Windows.Forms.RichTextBox();
            this.lb_IP = new System.Windows.Forms.Label();
            this.lb_port = new System.Windows.Forms.Label();
            this.lb_usernm = new System.Windows.Forms.Label();
            this.txIP = new System.Windows.Forms.TextBox();
            this.txPort = new System.Windows.Forms.TextBox();
            this.txUsername = new System.Windows.Forms.TextBox();
            this.bt_connect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.change_theme = new System.Windows.Forms.Button();
            this.register = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addSubscribe = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.endToEnd = new System.Windows.Forms.Label();
            this.showOnlineUsers = new System.Windows.Forms.Button();
            this.onlineUsersBox = new System.Windows.Forms.RichTextBox();
            this.onlineUsers = new System.Windows.Forms.Label();
            this.addNewUser = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tx_post
            // 
            this.tx_post.BackColor = System.Drawing.Color.Gainsboro;
            this.tx_post.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.tx_post.Location = new System.Drawing.Point(619, 594);
            this.tx_post.Margin = new System.Windows.Forms.Padding(0);
            this.tx_post.Multiline = true;
            this.tx_post.Name = "tx_post";
            this.tx_post.Size = new System.Drawing.Size(409, 39);
            this.tx_post.TabIndex = 6;
            // 
            // bt_disconnect
            // 
            this.bt_disconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bt_disconnect.Location = new System.Drawing.Point(214, 35);
            this.bt_disconnect.Margin = new System.Windows.Forms.Padding(0);
            this.bt_disconnect.Name = "bt_disconnect";
            this.bt_disconnect.Size = new System.Drawing.Size(72, 26);
            this.bt_disconnect.TabIndex = 9;
            this.bt_disconnect.Text = "Disconnect";
            this.bt_disconnect.UseVisualStyleBackColor = true;
            this.bt_disconnect.Click += new System.EventHandler(this.bt_disconnect_Click);
            // 
            // Bt_SendPost
            // 
            this.Bt_SendPost.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bt_SendPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bt_SendPost.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_SendPost.Location = new System.Drawing.Point(1031, 594);
            this.Bt_SendPost.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_SendPost.Name = "Bt_SendPost";
            this.Bt_SendPost.Size = new System.Drawing.Size(108, 39);
            this.Bt_SendPost.TabIndex = 10;
            this.Bt_SendPost.Text = "Gönder";
            this.Bt_SendPost.UseVisualStyleBackColor = false;
            this.Bt_SendPost.Click += new System.EventHandler(this.Bt_SendPost_Click);
            // 
            // Bt_All_Posts
            // 
            this.Bt_All_Posts.BackColor = System.Drawing.Color.LightSteelBlue;
            this.Bt_All_Posts.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Bt_All_Posts.ForeColor = System.Drawing.SystemColors.Control;
            this.Bt_All_Posts.Location = new System.Drawing.Point(494, 594);
            this.Bt_All_Posts.Margin = new System.Windows.Forms.Padding(0);
            this.Bt_All_Posts.Name = "Bt_All_Posts";
            this.Bt_All_Posts.Size = new System.Drawing.Size(120, 39);
            this.Bt_All_Posts.TabIndex = 11;
            this.Bt_All_Posts.Text = "Tüm Mesajlar";
            this.Bt_All_Posts.UseVisualStyleBackColor = false;
            this.Bt_All_Posts.Click += new System.EventHandler(this.Bt_All_Posts_Click);
            // 
            // clientLog
            // 
            this.clientLog.BackColor = System.Drawing.Color.Gainsboro;
            this.clientLog.Location = new System.Drawing.Point(619, 90);
            this.clientLog.Margin = new System.Windows.Forms.Padding(0);
            this.clientLog.Name = "clientLog";
            this.clientLog.Size = new System.Drawing.Size(531, 495);
            this.clientLog.TabIndex = 12;
            this.clientLog.Text = "";
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(10, 18);
            this.lb_IP.Margin = new System.Windows.Forms.Padding(0);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(23, 13);
            this.lb_IP.TabIndex = 0;
            this.lb_IP.Text = "IP :";
            // 
            // lb_port
            // 
            this.lb_port.AutoSize = true;
            this.lb_port.Location = new System.Drawing.Point(10, 37);
            this.lb_port.Margin = new System.Windows.Forms.Padding(0);
            this.lb_port.Name = "lb_port";
            this.lb_port.Size = new System.Drawing.Size(29, 13);
            this.lb_port.TabIndex = 1;
            this.lb_port.Text = "Port:";
            // 
            // lb_usernm
            // 
            this.lb_usernm.AutoSize = true;
            this.lb_usernm.Location = new System.Drawing.Point(10, 63);
            this.lb_usernm.Margin = new System.Windows.Forms.Padding(0);
            this.lb_usernm.Name = "lb_usernm";
            this.lb_usernm.Size = new System.Drawing.Size(61, 13);
            this.lb_usernm.TabIndex = 2;
            this.lb_usernm.Text = "Username :";
            // 
            // txIP
            // 
            this.txIP.Location = new System.Drawing.Point(82, 11);
            this.txIP.Margin = new System.Windows.Forms.Padding(0);
            this.txIP.Name = "txIP";
            this.txIP.Size = new System.Drawing.Size(118, 20);
            this.txIP.TabIndex = 3;
            this.txIP.Text = "127.0.0.1";
            // 
            // txPort
            // 
            this.txPort.Location = new System.Drawing.Point(82, 37);
            this.txPort.Margin = new System.Windows.Forms.Padding(0);
            this.txPort.Name = "txPort";
            this.txPort.Size = new System.Drawing.Size(118, 20);
            this.txPort.TabIndex = 4;
            this.txPort.Text = "80";
            // 
            // txUsername
            // 
            this.txUsername.Location = new System.Drawing.Point(82, 63);
            this.txUsername.Margin = new System.Windows.Forms.Padding(0);
            this.txUsername.Name = "txUsername";
            this.txUsername.Size = new System.Drawing.Size(118, 20);
            this.txUsername.TabIndex = 5;
            // 
            // bt_connect
            // 
            this.bt_connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.bt_connect.Location = new System.Drawing.Point(214, 9);
            this.bt_connect.Margin = new System.Windows.Forms.Padding(0);
            this.bt_connect.Name = "bt_connect";
            this.bt_connect.Size = new System.Drawing.Size(72, 24);
            this.bt_connect.TabIndex = 8;
            this.bt_connect.Text = "Connect";
            this.bt_connect.UseVisualStyleBackColor = true;
            this.bt_connect.Click += new System.EventHandler(this.bt_connect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(617, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 17);
            this.label1.TabIndex = 14;
            this.label1.Text = "Demo Sürümündesiniz. Kalan Mesaj Hakkınız : 3";
            // 
            // change_theme
            // 
            this.change_theme.BackColor = System.Drawing.Color.LightSteelBlue;
            this.change_theme.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.change_theme.ForeColor = System.Drawing.SystemColors.Control;
            this.change_theme.Location = new System.Drawing.Point(292, 594);
            this.change_theme.Name = "change_theme";
            this.change_theme.Size = new System.Drawing.Size(118, 39);
            this.change_theme.TabIndex = 16;
            this.change_theme.Text = "Tema Değiştir";
            this.change_theme.UseVisualStyleBackColor = false;
            this.change_theme.Click += new System.EventHandler(this.change_theme_Click);
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(214, 63);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(72, 23);
            this.register.TabIndex = 17;
            this.register.Text = "Kayıt Ol";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.panel1.Controls.Add(this.addSubscribe);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.register);
            this.panel1.Controls.Add(this.txUsername);
            this.panel1.Controls.Add(this.lb_IP);
            this.panel1.Controls.Add(this.lb_port);
            this.panel1.Controls.Add(this.lb_usernm);
            this.panel1.Controls.Add(this.txIP);
            this.panel1.Controls.Add(this.txPort);
            this.panel1.Controls.Add(this.bt_disconnect);
            this.panel1.Controls.Add(this.bt_connect);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1151, 92);
            this.panel1.TabIndex = 19;
            // 
            // addSubscribe
            // 
            this.addSubscribe.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addSubscribe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addSubscribe.ForeColor = System.Drawing.SystemColors.Control;
            this.addSubscribe.Location = new System.Drawing.Point(989, 61);
            this.addSubscribe.Margin = new System.Windows.Forms.Padding(0);
            this.addSubscribe.Name = "addSubscribe";
            this.addSubscribe.Size = new System.Drawing.Size(135, 23);
            this.addSubscribe.TabIndex = 21;
            this.addSubscribe.Text = "Abone Ol - 10$";
            this.addSubscribe.UseVisualStyleBackColor = false;
            this.addSubscribe.Visible = false;
            this.addSubscribe.Click += new System.EventHandler(this.addSubscribe_Click_1);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.endToEnd);
            this.panel2.Controls.Add(this.showOnlineUsers);
            this.panel2.Controls.Add(this.onlineUsersBox);
            this.panel2.Controls.Add(this.onlineUsers);
            this.panel2.Location = new System.Drawing.Point(0, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(286, 561);
            this.panel2.TabIndex = 20;
            // 
            // endToEnd
            // 
            this.endToEnd.AutoSize = true;
            this.endToEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.endToEnd.Location = new System.Drawing.Point(14, 530);
            this.endToEnd.Name = "endToEnd";
            this.endToEnd.Size = new System.Drawing.Size(243, 13);
            this.endToEnd.TabIndex = 21;
            this.endToEnd.Text = "Bu sohbetteki mesajlar uçtan uca şifrelenmektedir.";
            // 
            // showOnlineUsers
            // 
            this.showOnlineUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.showOnlineUsers.Location = new System.Drawing.Point(223, 6);
            this.showOnlineUsers.Name = "showOnlineUsers";
            this.showOnlineUsers.Size = new System.Drawing.Size(50, 50);
            this.showOnlineUsers.TabIndex = 22;
            this.showOnlineUsers.Text = "O";
            this.showOnlineUsers.Click += new System.EventHandler(this.showOnlineUsers_Click);
            // 
            // onlineUsersBox
            // 
            this.onlineUsersBox.BackColor = System.Drawing.Color.LightSteelBlue;
            this.onlineUsersBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onlineUsersBox.Location = new System.Drawing.Point(17, 59);
            this.onlineUsersBox.Name = "onlineUsersBox";
            this.onlineUsersBox.Size = new System.Drawing.Size(256, 423);
            this.onlineUsersBox.TabIndex = 22;
            this.onlineUsersBox.Text = "Çevrimiçi kullanıcılar Server ekranında görünmektedir.";
            // 
            // onlineUsers
            // 
            this.onlineUsers.AutoSize = true;
            this.onlineUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.onlineUsers.Location = new System.Drawing.Point(12, 16);
            this.onlineUsers.Name = "onlineUsers";
            this.onlineUsers.Size = new System.Drawing.Size(213, 25);
            this.onlineUsers.TabIndex = 0;
            this.onlineUsers.Text = "Çevrimiçi Kullanıcılar";
            // 
            // addNewUser
            // 
            this.addNewUser.BackColor = System.Drawing.Color.LightSteelBlue;
            this.addNewUser.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewUser.Location = new System.Drawing.Point(416, 594);
            this.addNewUser.Name = "addNewUser";
            this.addNewUser.Size = new System.Drawing.Size(75, 39);
            this.addNewUser.TabIndex = 21;
            this.addNewUser.Text = "Yeni Ekle";
            this.addNewUser.UseVisualStyleBackColor = false;
            this.addNewUser.Click += new System.EventHandler(this.addNewUser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1145, 642);
            this.Controls.Add(this.addNewUser);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.change_theme);
            this.Controls.Add(this.clientLog);
            this.Controls.Add(this.Bt_All_Posts);
            this.Controls.Add(this.Bt_SendPost);
            this.Controls.Add(this.tx_post);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Client";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tx_post;
        private System.Windows.Forms.Button bt_disconnect;
        private System.Windows.Forms.Button Bt_SendPost;
        private System.Windows.Forms.Button Bt_All_Posts;
        private System.Windows.Forms.RichTextBox clientLog;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.Label lb_port;
        private System.Windows.Forms.Label lb_usernm;
        private System.Windows.Forms.TextBox txIP;
        private System.Windows.Forms.TextBox txPort;
        private System.Windows.Forms.TextBox txUsername;
        private System.Windows.Forms.Button bt_connect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button change_theme;
        private System.Windows.Forms.Button register;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addSubscribe;
        private System.Windows.Forms.Label onlineUsers;
        private System.Windows.Forms.RichTextBox onlineUsersBox;
        private System.Windows.Forms.Button showOnlineUsers;
        private System.Windows.Forms.Label endToEnd;
        private System.Windows.Forms.Button addNewUser;
    }
}

