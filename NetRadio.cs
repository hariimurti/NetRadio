using System;
using System.Text;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using Un4seen.Bass;
using Un4seen.Bass.AddOn.Wma;
using Un4seen.Bass.AddOn.Tags;

namespace Simple_NetRadio
{
    // NOTE: Needs 'bass.dll' - copy it to your output directory first!
    //       needs 'basswma.dll' - copy it to your output directory first!


    public class NetRadio : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusBar statusBar1;
        private System.Windows.Forms.ComboBox comboBoxURL;
        private GroupBox groupBox1;
        private TextBox textBoxArtist;
        private GroupBox groupBox2;
        private TextBox textBoxTitle;
        private ComboBox comboBoxPlaylist;
        private Label label1;
        private Label label2;
        private NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private IContainer components;

        public NetRadio()
        {
            InitializeComponent();

            _myUserAgentPtr = Marshal.StringToHGlobalAnsi(_myUserAgent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Marshal.FreeHGlobal(_myUserAgentPtr);
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code
        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NetRadio));
            this.button1 = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusBar();
            this.comboBoxURL = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxArtist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlaylist = new System.Windows.Forms.ComboBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(227, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Connect";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 137);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(334, 22);
            this.statusBar1.TabIndex = 9;
            this.statusBar1.Text = "Ready...";
            this.statusBar1.TextChanged += new System.EventHandler(this.statusBar1_TextChanged);
            // 
            // comboBoxURL
            // 
            this.comboBoxURL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxURL.Items.AddRange(new object[] {
            "http://www.sky.fm/aacplus/tophits.pls",
            "http://www.sky.fm/aacplus/dancehits.pls",
            "http://www.sky.fm/aacplus/smoothjazz.pls"});
            this.comboBoxURL.Location = new System.Drawing.Point(10, 15);
            this.comboBoxURL.Name = "comboBoxURL";
            this.comboBoxURL.Size = new System.Drawing.Size(215, 21);
            this.comboBoxURL.TabIndex = 10;
            this.comboBoxURL.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textBoxTitle);
            this.groupBox1.Controls.Add(this.textBoxArtist);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 64);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 62);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Now Playing";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxTitle.Location = new System.Drawing.Point(43, 38);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = true;
            this.textBoxTitle.Size = new System.Drawing.Size(265, 13);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.Text = "-";
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxArtist_TextChanged);
            // 
            // textBoxArtist
            // 
            this.textBoxArtist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArtist.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxArtist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxArtist.Location = new System.Drawing.Point(43, 19);
            this.textBoxArtist.Name = "textBoxArtist";
            this.textBoxArtist.ReadOnly = true;
            this.textBoxArtist.Size = new System.Drawing.Size(265, 13);
            this.textBoxArtist.TabIndex = 0;
            this.textBoxArtist.Text = "-";
            this.textBoxArtist.TextChanged += new System.EventHandler(this.textBoxArtist_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Artist :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Title  :";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.comboBoxPlaylist);
            this.groupBox2.Controls.Add(this.comboBoxURL);
            this.groupBox2.Location = new System.Drawing.Point(10, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(314, 46);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Radio Channel";
            // 
            // comboBoxPlaylist
            // 
            this.comboBoxPlaylist.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxPlaylist.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxPlaylist.FormattingEnabled = true;
            this.comboBoxPlaylist.Location = new System.Drawing.Point(6, 19);
            this.comboBoxPlaylist.Name = "comboBoxPlaylist";
            this.comboBoxPlaylist.Size = new System.Drawing.Size(215, 21);
            this.comboBoxPlaylist.TabIndex = 2;
            this.comboBoxPlaylist.SelectedIndexChanged += new System.EventHandler(this.comboBoxPlaylist_SelectedIndexChanged);
            this.comboBoxPlaylist.TextChanged += new System.EventHandler(this.comboBoxPlaylist_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(36, 4);
            // 
            // NetRadio
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(334, 159);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(500, 198);
            this.MinimumSize = new System.Drawing.Size(350, 198);
            this.Name = "NetRadio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NetRadio v1.2";
            this.Activated += new System.EventHandler(this.textBoxArtist_TextChanged);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.NetRadio_Closing);
            this.Load += new System.EventHandler(this.NetRadio_Load);
            this.Resize += new System.EventHandler(this.NetRadio_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new NetRadio());
        }

        private string _myUserAgent = "BASS/2.4";
        [FixedAddressValueType()]
        public IntPtr _myUserAgentPtr;

        private int _Stream = 0,
            playIndex = 0;
        private string _url = String.Empty,
            playlist = String.Empty;
        private DOWNLOADPROC myStreamCreateURL;
        private TAG_INFO _tagInfo;
        private SYNCPROC mySync,
            mySyncEnd;
        private RECORDPROC myRecProc;
        private int _wmaPlugIn = 0,
            rechandle = 0;

        private void NetRadio_Load(object sender, System.EventArgs e)
        {
            //BassNet.Registration("your email", "your regkey");
            BassNet.Registration("buddyknox@usa.org", "2X11841782815");

            if (Utils.HighWord(Bass.BASS_GetVersion()) != Bass.BASSVERSION)
            {
                MessageBox.Show(this, "Wrong Bass Version!");
            }

            Bass.BASS_SetConfigPtr(BASSConfig.BASS_CONFIG_NET_AGENT, _myUserAgentPtr);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_PREBUF, 0);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_PLAYLIST, 1);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_TIMEOUT, 10000);
            Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_NET_BUFFER, 5000);

            if (Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, this.Handle))
            {
                _wmaPlugIn = Bass.BASS_PluginLoad("basswma.dll");
                if (Bass.BASS_SetConfig(BASSConfig.BASS_CONFIG_WMA_PREBUF, 0) == false)
                {
                    Console.WriteLine("ERROR: " + Enum.GetName(typeof(BASSError), Bass.BASS_ErrorGetCode()));
                }
                myStreamCreateURL = new DOWNLOADPROC(MyDownloadProc);
            }
            else
                MessageBox.Show(this, "Bass_Init error!");

            // load playlist
            if (File.Exists(Environment.CurrentDirectory + "\\Playlist.xml"))
            {
                this.comboBoxURL.Items.Clear();
                this.comboBoxPlaylist.Items.Clear();
                XmlReader reader = XmlReader.Create(Environment.CurrentDirectory + "\\Playlist.xml");
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        if (reader.Name == "channel")
                        {
                            string attribute = reader["name"];
                            if (attribute != null)
                            {
                                this.comboBoxPlaylist.Items.Add(attribute);
                                if (reader.Read())
                                {
                                    this.comboBoxURL.Items.Add(reader.Value.Trim());
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (MessageBox.Show("Playlist.xml tidak ditemukan!\r\nSilahkan download ulang di http://blog.harimurti.net", "Simple NetRadio", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                {
                    Process.Start("http://blog.harimurti.net");
                    Environment.Exit(0);
                }
                this.comboBoxPlaylist.Items.Add("Sky.fm - Top Hits");
                this.comboBoxURL.Items.Add("http://www.sky.fm/aacplus/tophits.pls");
                this.comboBoxPlaylist.Items.Add("Sky.fm - Dance Hits");
                this.comboBoxURL.Items.Add("http://www.sky.fm/aacplus/dancehits.pls");
                this.comboBoxPlaylist.Items.Add("Sky.fm - Smooth Jazz");
                this.comboBoxURL.Items.Add("http://www.sky.fm/aacplus/smoothjazz.pls");
            }
            comboBoxPlaylist.SelectedIndex = 0;
            this.contextMenuStrip1.Items.Clear();
            this.contextMenuStrip1.Items.Add("Show Player", null, notifyIcon1_DoubleClick);
            this.contextMenuStrip1.Items.Add("-", null);
            this.contextMenuStrip1.Items.Add("About Me", null, notifyIcon1_About);
            this.contextMenuStrip1.Items.Add("Exit", null, notifyIcon1_Exit);
        }

        private void NetRadio_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bass.BASS_PluginFree(_wmaPlugIn);
            Bass.BASS_Stop();
            Bass.BASS_Free();
            Bass.BASS_PluginFree(_wmaPlugIn);
        }

        public void NetRadio_Play()
        {
            this.button1.Text = "Disconnect";
            Bass.BASS_StreamFree(_Stream);
            Bass.BASS_ChannelStop(_Stream);
            Bass.BASS_ChannelStop(rechandle);

            bool isWMA = false;
            if (_url != String.Empty)
            {
                _Stream = Bass.BASS_StreamCreateURL(_url, 0, BASSFlag.BASS_STREAM_STATUS, myStreamCreateURL, IntPtr.Zero);
                if (_Stream == 0)
                {
                    _Stream = BassWma.BASS_WMA_StreamCreateFile(_url, 0, 0, BASSFlag.BASS_DEFAULT);
                    if (_Stream != 0)
                        isWMA = true;
                    else
                    {
                        if (statusBar1.Text != "Reconnecting...")
                            this.statusBar1.Text = "ERROR...";
                        else
                            SyncEnd(_Stream, 0, 0, IntPtr.Zero);
                        return;
                    }
                }
                _tagInfo = new TAG_INFO(_url);
                BASS_CHANNELINFO info = Bass.BASS_ChannelGetInfo(_Stream);
                if (info.ctype == BASSChannelType.BASS_CTYPE_STREAM_WMA)
                    isWMA = true;
                this.statusBar1.Text = "Buffering...";
                if (!isWMA)
                {
                    while (true)
                    {
                        long len = Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_END);
                        if (len == -1)
                            break; // typical for WMA streams
                        float progress = (
                            Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_DOWNLOAD) -
                            Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_CURRENT)
                            ) * 100f / len;

                        if (progress > 75f)
                        {
                            break; // over 75% full, enough
                        }

                        this.statusBar1.Text = String.Format("Buffering... {0}%", progress);
                    }
                }
                else
                {
                    while (true)
                    {
                        long len = Bass.BASS_StreamGetFilePosition(_Stream, BASSStreamFilePosition.BASS_FILEPOS_WMA_BUFFER);
                        if (len == -1L)
                            break;
                        if (len > 75L)
                        {
                            break; // over 75% full, enough
                        }

                        this.statusBar1.Text = String.Format("Buffering... {0}%", len);
                    }
                }
                
                if (BassTags.BASS_TAG_GetFromURL(_Stream, _tagInfo))
                {
                    // and display what we get
                    string title = _tagInfo.title;
                    if (title.ToLower().Contains("sky.fm"))
                    {
                        _tagInfo.artist = "SKY.FM";
                        _tagInfo.title = "Advertising";
                    }

                    this.textBoxTitle.Text = _tagInfo.title;
                    if (_tagInfo.artist != "")
                        this.textBoxArtist.Text = _tagInfo.artist;
                    else
                        this.textBoxArtist.Text = "-";
                }

                mySync = new SYNCPROC(MetaSync);
                mySyncEnd = new SYNCPROC(SyncEnd);
                Bass.BASS_ChannelSetSync(_Stream, BASSSync.BASS_SYNC_META, 0, mySync, IntPtr.Zero);
                Bass.BASS_ChannelSetSync(_Stream, BASSSync.BASS_SYNC_WMA_CHANGE, 0, mySync, IntPtr.Zero);
                Bass.BASS_ChannelSetSync(_Stream, BASSSync.BASS_SYNC_END, 0, mySyncEnd, IntPtr.Zero);

                rechandle = 0;
                if (Bass.BASS_RecordInit(-1))
                {
                    _byteswritten = 0;
                    myRecProc = new RECORDPROC(MyRecoring);
                    rechandle = Bass.BASS_RecordStart(44100, 2, BASSFlag.BASS_RECORD_PAUSE, myRecProc, IntPtr.Zero);
                }
                this.statusBar1.Text = "Playing...";
                Bass.BASS_ChannelPlay(_Stream, false);
                Bass.BASS_ChannelPlay(rechandle, false);
            }
        }

        public void NetRadio_Stop()
        {
            statusBar1.Text = "Stopped...";
            this.textBoxArtist.Text = "-";
            this.textBoxTitle.Text = "-";
            Bass.BASS_StreamFree(_Stream);
            Bass.BASS_ChannelStop(_Stream);
            Bass.BASS_ChannelStop(rechandle);
        }

        private int _byteswritten = 0;
        private byte[] _recbuffer = new byte[1048510]; // 1MB buffer
        private bool MyRecoring(int handle, IntPtr buffer, int length, IntPtr user)
        {
            if (length > 0 && buffer != IntPtr.Zero)
            {
                Marshal.Copy(buffer, _recbuffer, 0, length);
                _byteswritten += length;
                Console.WriteLine("Bytes written = {0}", _byteswritten);
                if (_byteswritten < 800000)
                    return true;
                else
                    return false;
            }
            return true;
        }

        private void MyDownloadProc(IntPtr buffer, int length, IntPtr user)
        {
            if (buffer != IntPtr.Zero && length == 0)
            {
                string txt = Marshal.PtrToStringAnsi(buffer);
            }
        }

        private void MetaSync(int handle, int channel, int data, IntPtr user)
        {
            if (_tagInfo.UpdateFromMETA(Bass.BASS_ChannelGetTags(channel, BASSTag.BASS_TAG_META), false, true))
            {
                this.Invoke(new UpdateTagDelegate(UpdateTagDisplay));
            }
        }

        public delegate void UpdateTagDelegate();
        private void UpdateTagDisplay()
        {
            string title = _tagInfo.title;
            if (title.ToLower().Contains("sky.fm"))
            {
                _tagInfo.artist = "SKY.FM";
                _tagInfo.title = "Advertising";
            }

            this.textBoxTitle.Text = _tagInfo.title;
            if (_tagInfo.artist != "")
                this.textBoxArtist.Text = _tagInfo.artist;
            else
                this.textBoxArtist.Text = "-";

            if ((this.notifyIcon1.Visible) && (_tagInfo.artist != "SKY.FM"))
            {
                this.notifyIcon1.BalloonTipText = "Next : " + _tagInfo.artist + " - " + _tagInfo.title;
                this.notifyIcon1.ShowBalloonTip(500);
            }
        }

        public delegate void UpdateStatusDelegate(string txt);
        private void UpdateStatusDisplay(string txt)
        {
            this.statusBar1.Text = txt;
        }

        public delegate void UpdateDelegate();
        private void SyncEnd(int handle, int channel, int data, IntPtr user)
        {
            Action set0 = () => this.button1.Text = "Disconnect";
            this.button1.Invoke(set0);
            Action set1 = () => this.comboBoxPlaylist.SelectedIndex = playIndex;
            this.comboBoxPlaylist.Invoke(set1);
            Action set2 = () => this.statusBar1.Text = "Wait 5s before reconnecting...";
            this.statusBar1.Invoke(set2);
            Thread.Sleep(5000);
            if (button1.Text != "Connect")
            {
                Action set3 = () => this.statusBar1.Text = "Reconnecting...";
                this.statusBar1.Invoke(set3);
                this.Invoke(new UpdateDelegate(NetRadio_Play));
            }
            else
                this.Invoke(new UpdateDelegate(NetRadio_Stop));
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            if (button1.Text == "Connect")
            {
                if (comboBoxURL.Text != "")
                {
                    statusBar1.Text = "Initializing...";
                    playlist = this.comboBoxPlaylist.Text;
                    _url = this.comboBoxURL.Text;
                    playIndex = this.comboBoxPlaylist.SelectedIndex;
                    NetRadio_Play();
                }
                else
                    MessageBox.Show("Please select Channel first!", "Critical Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.button1.Text = "Connect";
                NetRadio_Stop();
            }
        }

        private void statusBar1_TextChanged(object sender, EventArgs e)
        {
            if ((this.statusBar1.Text == "Initializing...") || (statusBar1.Text == "Reconnecting..."))
                this.button1.Enabled = false;
            else
                this.button1.Enabled = true;

            if ((this.statusBar1.Text == "ERROR...") || (statusBar1.Text == "Wait 5s before reconnecting..."))
            {
                this.textBoxArtist.Text = "-";
                this.textBoxTitle.Text = "-";
            }
        }

        private void comboBoxPlaylist_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.comboBoxURL.SelectedIndex = this.comboBoxPlaylist.SelectedIndex;
        }

        private void comboBoxPlaylist_TextChanged(object sender, EventArgs e)
        {
            if (playlist != this.comboBoxPlaylist.Text)
                this.button1.Text = "Connect";
            else
                this.button1.Text = "Disconnect";
        }

        private void textBoxArtist_TextChanged(object sender, EventArgs e)
        {
            this.button1.Focus();
        }

        private void NetRadio_Resize(object sender, EventArgs e)
        {
            if ((FormWindowState.Minimized == this.WindowState) && (this.statusBar1.Text == "Playing..."))
            {
                this.notifyIcon1.Text = "NetRadio : " + this.comboBoxPlaylist.Text;
                this.notifyIcon1.BalloonTipTitle = this.comboBoxPlaylist.Text;
                this.notifyIcon1.BalloonTipText = "Now Playing : " + _tagInfo.artist + " - " + _tagInfo.title;
                this.ShowInTaskbar = false;
                this.notifyIcon1.Visible = true;
                this.notifyIcon1.ShowBalloonTip(500);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.notifyIcon1.Visible = false;
            this.WindowState = FormWindowState.Normal;
        }

        private void notifyIcon1_About(object sender, EventArgs e)
        {
            Process.Start("http://blog.harimurti.net");
        }

        private void notifyIcon1_Exit(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}