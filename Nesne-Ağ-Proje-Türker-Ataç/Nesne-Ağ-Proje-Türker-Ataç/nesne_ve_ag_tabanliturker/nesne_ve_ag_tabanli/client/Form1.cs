using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace client
{
    public partial class Form1 : Form
    {
        private int sentMessageCount = 0;
        private bool isSubscribe = false;


        private bool terminating = false;

        private bool connected = false;
        private bool disconnectPressed = false;
        private string clientUsername = "";

        private Socket clientSocket;


        public DateTime nowTime;

        public string GetTime() // anlık zamanı alır.
        {
            nowTime = DateTime.Now;
            return nowTime.ToString("HH:mm");
        }

        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Form1_Closing);
            this.InitializeComponent();
            
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bt_connect_Click(object sender, EventArgs e)
        {
            this.clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            string text1 = this.txIP.Text;
            int result;
            if (int.TryParse(this.txPort.Text, out result))
            {
                string text2 = this.txUsername.Text;
                if (text2 == "")
                    this.clientLog.AppendText("Lütfen kullanıcı adı girin.\n");
                else if (text1 == "")
                {
                    this.clientLog.AppendText("Lütfen bir IP adresi girin.\n");
                }
                else
                {
                    try
                    {
                        this.clientSocket.Connect(text1, result);
                        try
                        {
                            this.clientSocket.Send(Encoding.Default.GetBytes(text2));
                            try
                            {
                                byte[] numArray = new byte[64];
                                this.clientSocket.Receive(numArray);
                                switch (Encoding.Default.GetString(numArray).Trim(new char[1]))
                                {
                                    case "NOT_FOUND":
                                        this.clientLog.AppendText("Lütfen geçerli bir kullanıcı adı girin.\n");
                                        break;
                                    case "Already_Connected":
                                        this.clientLog.AppendText("Bu kullanıcı sunucuya bağlı durumda.\n");
                                        break;
                                    case "SUCCESS":
                                        this.bt_connect.Enabled = false;
                                        this.Bt_SendPost.Enabled = true;
                                        this.bt_disconnect.Enabled = true;
                                        this.Bt_All_Posts.Enabled = true;
                                        this.tx_post.Enabled = true;
                                        this.disconnectPressed = false;
                                        this.connected = true;
                                        this.clientUsername = text2;
                                        this.clientLog.AppendText(text2 + " olarak sunucuya bağlandınız. \n");
                                        new Thread(new ThreadStart(this.Receive)).Start();
                                        break;
                                }
                            }
                            catch
                            {
                                this.clientLog.AppendText("There was a problem receiving response.\n");
                            }
                        }
                        catch
                        {
                            this.clientLog.AppendText("Problem occured while username is sent.\n");
                        }
                    }
                    catch
                    {
                        this.clientLog.AppendText("Could not connect to the server.\n");
                    }
                }
            }
            else
                this.clientLog.AppendText("Port numarasını kontrol edin.\n");
        }

        private static char ShiftChar(char c, int shift) // şifreleme algoritması.
        {
            const int alphabetSize = 26;
            char shiftedChar = (char)(c + shift);
            if (shiftedChar > 'z')
            {
                shiftedChar = (char)(shiftedChar - alphabetSize);
            }
            else if (shiftedChar < 'a')
            {
                shiftedChar = (char)(shiftedChar + alphabetSize);
            }
            return shiftedChar;
        }
        public string Encrypt(string plainText, string keyword) // dosyaya yazılan metni şifreleme.
        {
            plainText = plainText.ToLower();
            keyword = keyword.ToLower();
            string encryptedText = "";
            int keywordIndex = 0;

            foreach (char c in plainText)
            {
                if (char.IsLetter(c))
                {
                    int shift = keyword[keywordIndex] - 'a';
                    encryptedText += ShiftChar(c, shift);
                    keywordIndex = (keywordIndex + 1) % keyword.Length;
                }
                else
                {
                    encryptedText += c;
                }
            }

            return encryptedText;
        }

        public string Decrypt(string encryptedText, string keyword) // okunan metnin şifresini çözme.
        {
            encryptedText = encryptedText.ToLower();
            keyword = keyword.ToLower();
            string decryptedText = "";
            int keywordIndex = 0;

            foreach (char c in encryptedText)
            {
                if (char.IsLetter(c))
                {
                    int shift = keyword[keywordIndex] - 'a';
                    decryptedText += ShiftChar(c, -shift);
                    keywordIndex = (keywordIndex + 1) % keyword.Length;
                }
                else
                {
                    decryptedText += c;
                }
            }

            return decryptedText;
        }

        private void Bt_SendPost_Click(object sender, EventArgs e)
        {
            if (isSubscribe == true)
            {
                string text = Encrypt(tx_post.Text, "sifreleme");
                string s = "SEND_POSTS" + text;
                this.tx_post.Text = "";
                if (!(s != "") || s.Length > 64)
                    return;
                byte[] bytes = Encoding.Default.GetBytes(s);
                try
                {
                    this.clientSocket.Send(bytes);
                }
                catch
                {
                    this.clientLog.AppendText("There was a problem sending the post to the server.\n");
                }
            }
            else if (sentMessageCount < 3)
            {
                string text = Encrypt(tx_post.Text, "sifreleme");
                string s = "SEND_POSTS" + text;
                this.tx_post.Text = "";
                if (!(s != "") || s.Length > 64)
                    return;
                byte[] bytes = Encoding.Default.GetBytes(s);
                try
                {
                    this.clientSocket.Send(bytes);
                    sentMessageCount++;
                    label1.Text = $"Kalan Mesaj Hakkınız : {3 - sentMessageCount}";
                }
                catch
                {
                    this.clientLog.AppendText("There was a problem sending the post to the server.\n");
                }
            }
            else
            {
                Bt_SendPost.Enabled = false;
                addSubscribe.Visible = true;
                addSubscribe.Enabled = true;
            }

        }
        private void Bt_All_Posts_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("SHOW_POSTS");
            try
            {
                this.clientLog.AppendText("\nBütün istemci mesajları : \n");
                this.clientSocket.Send(bytes);
            }
            catch
            {
                this.clientLog.AppendText("There was a problem in the request of reaching posts page to server.\n");
            }

        }
        private void Receive()
        {
            while (this.connected)
            {
                try
                {
                    byte[] numArray = new byte[5000000];
                    this.clientSocket.Receive(numArray);
                    this.clientSocket.Send(Encoding.Default.GetBytes("receivedinfo"));
                    string str1 = Encoding.Default.GetString(numArray);
                    string str2 = str1.Substring(0, str1.IndexOf("\0"));

                    if (str2.Substring(0, 10) == "SHOW_POSTS")
                    {
                        clientLog.AppendText(str2.Substring(10) + "\n");
                    }
                    else if (str2.Substring(0, 0) == "")
                    {
                        clientLog.AppendText(Decrypt(str2, "sifreleme") + "\n");
                    }
                }
                catch
                {
                    if (!this.terminating && !this.disconnectPressed)
                    {
                        this.clientLog.AppendText("Server bağlantısı kesildi.\n");
                        this.bt_connect.Enabled = true;
                        this.tx_post.Enabled = false;
                        this.Bt_SendPost.Enabled = false;
                        this.bt_disconnect.Enabled = false;
                        this.Bt_All_Posts.Enabled = false;
                    }
                    this.clientSocket.Close();
                    this.connected = false;
                }
            }
        }


        private void bt_disconnect_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("DISCONNECT");
            try
            {
                this.clientSocket.Send(bytes);
                this.disconnectPressed = true;
                this.bt_connect.Enabled = true;
                this.tx_post.Enabled = false;
                this.Bt_SendPost.Enabled = false;
                this.bt_disconnect.Enabled = false;
                this.Bt_All_Posts.Enabled = false;
                this.clientSocket.Close();
                this.connected = false;
                this.clientLog.AppendText("Sunucu ile bağlantıyı kestiniz.\n");
            }
            catch
            {
                this.clientLog.AppendText("There was a problem sending disconnect request to server.\n");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
                this.components.Dispose();
            base.Dispose(disposing);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private bool selector = true;
        private void change_theme_Click(object sender, EventArgs e)
        {
            if (selector == true)
            {
                showOnlineUsers.BackColor = Color.DarkSlateGray;
                onlineUsersBox.BackColor = Color.DarkSlateGray;
                change_theme.BackColor = Color.DarkSlateGray;
                Bt_SendPost.BackColor = Color.DarkSlateGray;
                addNewUser.BackColor = Color.DarkSlateGray;
                Bt_All_Posts.BackColor = Color.DarkSlateGray;
                this.BackgroundImage = Image.FromFile("../../../Client/koyu_tema.jpg");
                addSubscribe.BackColor = Color.DarkSlateGray;
                panel1.BackColor = Color.DarkSlateGray;
                panel2.BackColor = Color.FromArgb(57, 99, 99);
                clientLog.BackColor = Color.Gray;
                tx_post.BackColor = Color.Gray;
                //this.BackColor = Color.DimGray;
                selector = false;
            }
            else
            {
                onlineUsersBox.BackColor = Color.LightSteelBlue;
                showOnlineUsers.BackColor = Color.LightSteelBlue;
                addSubscribe.BackColor = Color.LightSteelBlue;
                this.BackgroundImage = Image.FromFile("../../../Client/acik_tema.jpg");
                change_theme.BackColor = Color.LightSteelBlue;
                Bt_SendPost.BackColor = Color.LightSteelBlue;
                addNewUser.BackColor = Color.LightSteelBlue;
                Bt_All_Posts.BackColor = Color.LightSteelBlue;
                panel1.BackColor = Color.DarkSlateBlue;
                panel2.BackColor = Color.LightSteelBlue;
                clientLog.BackColor = Color.Gainsboro;
                tx_post.BackColor = Color.Gainsboro;
                //this.BackColor = Color.WhiteSmoke;
                selector = true;
            }

        }

        private void register_Click(object sender, EventArgs e)
        {
            string addUsername = txUsername.Text;

            string filePath = "../../../Server/user-db.txt";

            try
            {
                // Kullanıcı adını dosyaya ekleyin
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine(addUsername);
                    MessageBox.Show("New user added successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the user: " + ex.Message);
            }
        }

        private void addSubscribe_Click_1(object sender, EventArgs e)
        {
            Bt_SendPost.Enabled = true;
            label1.Visible = false;
            addSubscribe.Visible = false;
            isSubscribe = true;
            this.clientLog.AppendText(clientUsername + " abonelik satın aldı. \n\n");
        }

        private void Form1_Closing(object sender, FormClosingEventArgs e)
        {
            this.connected = false;
            this.terminating = true;
            Environment.Exit(0);
        }

        private void showOnlineUsers_Click(object sender, EventArgs e)
        {
            byte[] bytes = Encoding.Default.GetBytes("SHOW_ACTIVE_USERS");
            try
            {
                this.clientSocket.Send(bytes);
            }
            catch
            {
                this.clientLog.AppendText("There was a problem in the request for active users to the server.\n");
            }
        }

        private void addNewUser_Click(object sender, EventArgs e)
        {
            Form1 form2 = new Form1();
            form2.Show();
        }
    }
}