using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        private int lineCount = System.IO.File.ReadLines("../../user-db.txt").Count<string>();
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> clientSockets = new List<Socket>();
        private List<string> clientusernames = new List<string>();
        private int postCount = Form1.CountPost();
        private bool terminating = false;
        private bool listening = false;
        //private IContainer components = (IContainer)null;
        private Label label_port;

        public DateTime nowTime;

        public string GetTime() // anlık zamanı hesaplar.
        {
            nowTime = DateTime.Now;
            return nowTime.ToString("HH:mm");
        }


        public Form1()
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            this.FormClosing += new FormClosingEventHandler(this.Form1_FormClosing);
            this.InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private static char ShiftChar(char c, int shift) // şifreleme algoritmasını hesaplar.
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
        public string Encrypt(string plainText, string keyword) // dosyaya yazılacak metni şifreler.
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

        public string Decrypt(string encryptedText, string keyword) // dosyadan okunacak metnin şifresini çözer.
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



        private void Btn_List_Click(object sender, EventArgs e) // server port dinleme butonu.
        {

            int result;
            if (int.TryParse(this.txt_port.Text, out result))
            {
                this.serverSocket.Bind((EndPoint)new IPEndPoint(IPAddress.Any, result));
                this.serverSocket.Listen(3);
                this.listening = true;
                this.Btn_List.Enabled = false;
                new Thread(new ThreadStart(this.Accept)).Start();
                this.rct_serverLog.AppendText((object)result + " Numaralı port dinleniyor. \n\n");
                Btn_List.BackColor = Color.Green;
            }
            else
                this.rct_serverLog.AppendText("Port numarasını kontrol edin. \n");
        }

        private void Accept()
        {
            while (this.listening)
            {
                try
                {
                    Socket newClient = this.serverSocket.Accept();
                    new Thread((ThreadStart)(() => this.usernameCheck(newClient))).Start();
                }
                catch
                {
                    if (this.terminating)
                        this.listening = false;
                    else
                        this.rct_serverLog.AppendText("Port çalışması durduruldu.\n");
                }
            }
        }
        private void usernameCheck(Socket thisClient) // kullanıcı adı kontolü.
        {
            string s = "NOT_FOUND";
            try
            {
                byte[] numArray = new byte[64];
                thisClient.Receive(numArray);
                string username = Encoding.Default.GetString(numArray);
                username = username.Substring(0, username.IndexOf("\0"));
                if (this.clientusernames.Contains(username))
                {
                    this.rct_serverLog.AppendText(username + " has tried to connect from another client!\n");
                    s = "Already_Connected";
                }
                else
                {
                    foreach (string readLine in System.IO.File.ReadLines("../../user-db.txt"))
                    {
                        if (readLine == username)
                        {
                            this.clientSockets.Add(thisClient);
                            this.clientusernames.Add(username);
                            s = "SUCCESS";
                            this.rct_serverLog.AppendText(username + " sunucuya bağlandı.\n");
                            new Thread((ThreadStart)(() => this.Receive(thisClient, username))).Start();
                        }
                    }
                }
                if (s == "NOT_FOUND")
                    this.rct_serverLog.AppendText(username + " sunucuya bağlanmayı denedi.\n");
                try
                {
                    thisClient.Send(Encoding.Default.GetBytes(s));
                }
                catch
                {
                    this.rct_serverLog.AppendText("There was a problem when sending the username response to the client.\n");
                }
            }
            catch
            {
                this.rct_serverLog.AppendText("Problem receiving username.\n");
            }
        }
        private void ShowActiveUsers() // aktif kullanıcıları sunucuda gösterir. (isteğe bağlı client de gösterilebilir. tercih bu.)
        {
            StringBuilder activeUsersText = new StringBuilder("Aktif Kullanıcılar:\n");

            for (int i = 0; i < clientusernames.Count; i++)
            {
                activeUsersText.Append($"{i + 1}. {clientusernames[i]}\n");
            }
            rct_serverLog.AppendText(activeUsersText.ToString() + "\n");
            
        }

        private void Receive(Socket thisClient, string username)
        {
            bool flag = true;
            while (flag && !this.terminating)
            {
                try
                {
                    byte[] numArray = new byte[64];
                    thisClient.Receive(numArray);
                    string str = Encoding.Default.GetString(numArray).Trim(new char[1]);
                    int minLength = Math.Min(str.Length, 17);
                    if (str.Substring(0, 10) == "DISCONNECT")
                    {
                        thisClient.Close();
                        this.clientSockets.Remove(thisClient);
                        this.clientusernames.Remove(username);
                        flag = false;
                        this.rct_serverLog.AppendText(username + " sunucu ile bağlantısı kesildi.\n");
                    }
                    else if (str.Substring(0, 10) == "SHOW_POSTS")
                        this.allposts(thisClient, username);
                    else if (str.Substring(0, 10) == "SEND_POSTS")
                    {
                        string post = str.Substring(10);
                        ++this.postCount;
                        this.postToLog(username, (object)this.postCount, post);
                    }
                    else if (str.Substring(0, minLength) == "SHOW_ACTIVE_USERS")
                    {
                        
                        this.ShowActiveUsers();
                    }
                }
                catch
                {
                    if (!this.terminating)
                        this.rct_serverLog.AppendText(username + " sunucu ile bağlantısı kesildi.\n");
                    thisClient.Close();
                    this.clientSockets.Remove(thisClient);
                    this.clientusernames.Remove(username);
                    flag = false;
                }
            }
        }

        private void postToLog(string username, object postID, string post) // yazılan metni dosyaya kaydeder.
        {

            string str = DateTime.Now.ToString("s");
            using (StreamWriter streamWriter = new StreamWriter("../../posts.log", true))
                streamWriter.WriteLine(str + " /" + username + "/" + postID.ToString() + "/" + post + "/");
            //rct_serverLog.AppendText(username + " : " + GetTime() + "\n" + post + "\n\n");
            post = Decrypt(post, "sifreleme");
            string message = "" + username + " : " + GetTime() + "\n" + post + "\n";
            string encmessage = Encrypt(message, "sifreleme");
            byte[] bytes1 = Encoding.Default.GetBytes(encmessage);
            foreach (Socket clientSocket in clientSockets)
            {
                clientSocket.Send(bytes1);
            }
        }

        private void allposts(Socket thisClient, string username) // bütün istemci mesajlarını gösterir.
        {
            string input = System.IO.File.ReadAllText("../../posts.log");
            string pattern = "\\d\\d\\d\\d[-]\\d\\d[-]\\d\\d[T]\\d\\d[:]\\d\\d[:]\\d\\d";
            string[] strArray = new Regex(pattern).Split(input);
            MatchCollection matchCollection = Regex.Matches(input, pattern);
            for (int index = 1; index < strArray.Length; ++index)
            {
                int num1 = strArray[index].IndexOf("/", 2);
                int num2 = strArray[index].IndexOf("/", num1 + 1);
                string str1 = strArray[index].Substring(2, num1 - 2);
                string str2 = strArray[index].Substring(num1 + 1, num2 - num1 - 1);
                string str3 = strArray[index].Substring(num2 + 1, strArray[index].Length - 4 - num2);
                if (username != str1)
                {
                    try
                    {
                        byte[] bytes1 = Encoding.Default.GetBytes("SHOW_POSTSUsername: " + str1);
                        try
                        {
                            thisClient.Send(bytes1);
                            byte[] numArray1 = new byte[64];
                            thisClient.Receive(numArray1);
                            Encoding.Default.GetString(numArray1);
                            byte[] bytes2 = Encoding.Default.GetBytes("SHOW_POSTSPostID: " + str2);
                            try
                            {
                                thisClient.Send(bytes2);
                                byte[] numArray2 = new byte[64];
                                thisClient.Receive(numArray1);
                                Encoding.Default.GetString(numArray1);
                                //   string decmessage = Decrypt(str3, "sifreleme");
                                byte[] bytes3 = Encoding.Default.GetBytes("SHOW_POSTSPost: " + Decrypt(str3, "sifreleme"));
                                try
                                {
                                    thisClient.Send(bytes3);
                                    byte[] numArray3 = new byte[64];
                                    thisClient.Receive(numArray1);
                                    Encoding.Default.GetString(numArray1);
                                    byte[] bytes4 = Encoding.Default.GetBytes("SHOW_POSTSTime: " + (object)matchCollection[index - 1] + "\n");
                                    try
                                    {
                                        thisClient.Send(bytes4);
                                        byte[] numArray4 = new byte[64];
                                        thisClient.Receive(numArray1);
                                        Encoding.Default.GetString(numArray1);
                                    }
                                    catch
                                    {
                                        this.rct_serverLog.AppendText("There was a problem sending the time.\n");
                                    }
                                }
                                catch
                                {
                                    this.rct_serverLog.AppendText("There was a problem sending the post.\n");
                                }
                            }
                            catch
                            {
                                this.rct_serverLog.AppendText("There was a problem sending the post ID.\n");
                            }
                        }
                        catch
                        {
                            this.rct_serverLog.AppendText("There was a problem sending the username.\n");
                        }
                    }
                    catch
                    {
                        this.rct_serverLog.AppendText("There was a problem with the GetBytes function.\n");
                    }
                }
            }
            this.rct_serverLog.AppendText(username + " bütün mesajları görmek istedi.\n\n");
        }

        private static int CountPost() // toplam mesaj sayısını hesaplar.
        {
            if (!System.IO.File.Exists("../../posts.log"))
                System.IO.File.Create("../../posts.log").Dispose();
            string input = System.IO.File.ReadAllText("../../posts.log");
            if (input == "")
                return 0;
            string[] strArray = new Regex("\\d\\d\\d\\d[-]\\d\\d[-]\\d\\d[T]\\d\\d[:]\\d\\d[:]\\d\\d").Split(input);
            int num1 = strArray[strArray.Length - 1].IndexOf("/", 2);
            int num2 = strArray[strArray.Length - 1].IndexOf("/", num1 + 1);
            return int.Parse(strArray[strArray.Length - 1].Substring(num1 + 1, num2 - num1 - 1));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) // form kapatıldığında mesajları siler.
        {
            this.listening = false;
            this.terminating = true;
            System.IO.File.Delete("../../posts.log");
            Environment.Exit(0);
        }

    }
}