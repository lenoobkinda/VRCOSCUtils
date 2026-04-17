
namespace VRChatify
{
    partial class MainWindow
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.Sessions = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.fastColoredTextBox3 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox10 = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox11 = new System.Windows.Forms.CheckBox();
            this.checkBox8 = new System.Windows.Forms.CheckBox();
            this.checkBox7 = new System.Windows.Forms.CheckBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.oscMessageLabel = new System.Windows.Forms.Label();
            this.OSCToggle = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ClanTagLabel = new System.Windows.Forms.Label();
            this.ClanTag = new System.Windows.Forms.TextBox();
            this.DebugLogging = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PlaceHolder = new System.Windows.Forms.GroupBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.checkBox6 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.SessionHolder = new System.Windows.Forms.GroupBox();
            this.ForceUpdateSessions = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.presenceToggle = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox9 = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.fastColoredTextBox2 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.checkBox12 = new System.Windows.Forms.CheckBox();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox3)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.PlaceHolder.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // Sessions
            // 
            this.Sessions.FormattingEnabled = true;
            this.Sessions.Location = new System.Drawing.Point(6, 19);
            this.Sessions.Name = "Sessions";
            this.Sessions.Size = new System.Drawing.Size(187, 147);
            this.Sessions.TabIndex = 0;
            this.Sessions.SelectedIndexChanged += new System.EventHandler(this.Sessions_SelectedIndexChanged);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.fastColoredTextBox3);
            this.groupBox7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox7.Location = new System.Drawing.Point(12, 378);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(765, 167);
            this.groupBox7.TabIndex = 23;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Frames (Line number = frame)";
            this.groupBox7.Enter += new System.EventHandler(this.groupBox7_Enter);
            // 
            // fastColoredTextBox3
            // 
            this.fastColoredTextBox3.AllowDrop = false;
            this.fastColoredTextBox3.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox3.AutoScrollMinSize = new System.Drawing.Size(27, 14);
            this.fastColoredTextBox3.BackBrush = null;
            this.fastColoredTextBox3.BackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox3.CharHeight = 14;
            this.fastColoredTextBox3.CharWidth = 8;
            this.fastColoredTextBox3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox3.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox3.FoldingIndicatorColor = System.Drawing.Color.White;
            this.fastColoredTextBox3.ForeColor = System.Drawing.Color.White;
            this.fastColoredTextBox3.IndentBackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox3.IsReplaceMode = false;
            this.fastColoredTextBox3.LineNumberColor = System.Drawing.Color.White;
            this.fastColoredTextBox3.Location = new System.Drawing.Point(6, 17);
            this.fastColoredTextBox3.Name = "fastColoredTextBox3";
            this.fastColoredTextBox3.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox3.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox3.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox3.ServiceColors")));
            this.fastColoredTextBox3.ServiceLinesColor = System.Drawing.Color.White;
            this.fastColoredTextBox3.Size = new System.Drawing.Size(759, 144);
            this.fastColoredTextBox3.TabIndex = 0;
            this.fastColoredTextBox3.Zoom = 100;
            this.fastColoredTextBox3.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.S);
            this.fastColoredTextBox3.Load += new System.EventHandler(this.fastColoredTextBox3_Load);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button5.Location = new System.Drawing.Point(407, 574);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(88, 23);
            this.button5.TabIndex = 26;
            this.button5.Text = "Save Text";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(302, 574);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(78, 23);
            this.button6.TabIndex = 25;
            this.button6.Text = "Load Text";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox10
            // 
            this.checkBox10.AutoSize = true;
            this.checkBox10.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox10.Location = new System.Drawing.Point(362, 551);
            this.checkBox10.Name = "checkBox10";
            this.checkBox10.Size = new System.Drawing.Size(60, 17);
            this.checkBox10.TabIndex = 24;
            this.checkBox10.Text = "Frames";
            this.checkBox10.UseVisualStyleBackColor = true;
            this.checkBox10.CheckedChanged += new System.EventHandler(this.checkBox10_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.richTextBox1);
            this.groupBox6.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox6.Location = new System.Drawing.Point(298, 140);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 174);
            this.groupBox6.TabIndex = 15;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Custom Text";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.Black;
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(6, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(188, 148);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged_1);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox12);
            this.groupBox1.Controls.Add(this.checkBox11);
            this.groupBox1.Controls.Add(this.checkBox8);
            this.groupBox1.Controls.Add(this.checkBox7);
            this.groupBox1.Controls.Add(this.checkBox5);
            this.groupBox1.Controls.Add(this.checkBox4);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.oscMessageLabel);
            this.groupBox1.Controls.Add(this.OSCToggle);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 122);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "OSC Settings";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // checkBox11
            // 
            this.checkBox11.AutoSize = true;
            this.checkBox11.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox11.Location = new System.Drawing.Point(161, 76);
            this.checkBox11.Name = "checkBox11";
            this.checkBox11.Size = new System.Drawing.Size(92, 17);
            this.checkBox11.TabIndex = 11;
            this.checkBox11.Text = "Clear Chatbox";
            this.checkBox11.UseVisualStyleBackColor = true;
            this.checkBox11.CheckedChanged += new System.EventHandler(this.checkBox11_CheckedChanged);
            // 
            // checkBox8
            // 
            this.checkBox8.AutoSize = true;
            this.checkBox8.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox8.Location = new System.Drawing.Point(161, 55);
            this.checkBox8.Name = "checkBox8";
            this.checkBox8.Size = new System.Drawing.Size(53, 17);
            this.checkBox8.TabIndex = 10;
            this.checkBox8.Text = "Lyrics";
            this.checkBox8.UseVisualStyleBackColor = true;
            this.checkBox8.CheckedChanged += new System.EventHandler(this.checkBox8_CheckedChanged_1);
            // 
            // checkBox7
            // 
            this.checkBox7.AutoSize = true;
            this.checkBox7.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox7.Location = new System.Drawing.Point(81, 101);
            this.checkBox7.Name = "checkBox7";
            this.checkBox7.Size = new System.Drawing.Size(63, 17);
            this.checkBox7.TabIndex = 9;
            this.checkBox7.Text = "Tabbed";
            this.checkBox7.UseVisualStyleBackColor = true;
            this.checkBox7.CheckedChanged += new System.EventHandler(this.checkBox7_CheckedChanged);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox5.Location = new System.Drawing.Point(81, 78);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(78, 17);
            this.checkBox5.TabIndex = 8;
            this.checkBox5.Text = "Local Time";
            this.checkBox5.UseVisualStyleBackColor = true;
            this.checkBox5.CheckedChanged += new System.EventHandler(this.checkBox5_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox4.Location = new System.Drawing.Point(9, 99);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(62, 17);
            this.checkBox4.TabIndex = 7;
            this.checkBox4.Text = "Clantag";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox3.Location = new System.Drawing.Point(81, 55);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(46, 17);
            this.checkBox3.TabIndex = 6;
            this.checkBox3.Text = "FPS";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox2.Location = new System.Drawing.Point(8, 76);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "PC Stats";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.checkBox1.Location = new System.Drawing.Point(9, 55);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(58, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Spotify";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // oscMessageLabel
            // 
            this.oscMessageLabel.AutoSize = true;
            this.oscMessageLabel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.oscMessageLabel.Location = new System.Drawing.Point(7, 39);
            this.oscMessageLabel.Name = "oscMessageLabel";
            this.oscMessageLabel.Size = new System.Drawing.Size(70, 13);
            this.oscMessageLabel.TabIndex = 3;
            this.oscMessageLabel.Text = "OSC Toggles";
            this.oscMessageLabel.Click += new System.EventHandler(this.oscMessageLabel_Click);
            // 
            // OSCToggle
            // 
            this.OSCToggle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OSCToggle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.OSCToggle.Location = new System.Drawing.Point(81, 14);
            this.OSCToggle.Name = "OSCToggle";
            this.OSCToggle.Size = new System.Drawing.Size(133, 33);
            this.OSCToggle.TabIndex = 2;
            this.OSCToggle.Text = "Send To Osc";
            this.OSCToggle.UseVisualStyleBackColor = true;
            this.OSCToggle.CheckedChanged += new System.EventHandler(this.OSCToggle_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(403, 339);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 23);
            this.button2.TabIndex = 14;
            this.button2.Text = "Save Text";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ClanTagLabel);
            this.groupBox4.Controls.Add(this.ClanTag);
            this.groupBox4.Controls.Add(this.DebugLogging);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox4.Location = new System.Drawing.Point(12, 272);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(274, 100);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // ClanTagLabel
            // 
            this.ClanTagLabel.AutoSize = true;
            this.ClanTagLabel.Location = new System.Drawing.Point(9, 40);
            this.ClanTagLabel.Name = "ClanTagLabel";
            this.ClanTagLabel.Size = new System.Drawing.Size(50, 13);
            this.ClanTagLabel.TabIndex = 5;
            this.ClanTagLabel.Text = "Clan Tag";
            this.ClanTagLabel.Click += new System.EventHandler(this.ClanTagLabel_Click);
            // 
            // ClanTag
            // 
            this.ClanTag.Location = new System.Drawing.Point(9, 56);
            this.ClanTag.Name = "ClanTag";
            this.ClanTag.Size = new System.Drawing.Size(122, 20);
            this.ClanTag.TabIndex = 4;
            this.ClanTag.Text = "VRChatify";
            this.ClanTag.TextChanged += new System.EventHandler(this.ClanTag_TextChanged);
            // 
            // DebugLogging
            // 
            this.DebugLogging.AutoSize = true;
            this.DebugLogging.Location = new System.Drawing.Point(9, 20);
            this.DebugLogging.Name = "DebugLogging";
            this.DebugLogging.Size = new System.Drawing.Size(99, 17);
            this.DebugLogging.TabIndex = 0;
            this.DebugLogging.Text = "Debug Logging";
            this.DebugLogging.UseVisualStyleBackColor = true;
            this.DebugLogging.CheckedChanged += new System.EventHandler(this.DebugLogging_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-68, -2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 0;
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // PlaceHolder
            // 
            this.PlaceHolder.Controls.Add(this.richTextBox2);
            this.PlaceHolder.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.PlaceHolder.Location = new System.Drawing.Point(510, 12);
            this.PlaceHolder.Name = "PlaceHolder";
            this.PlaceHolder.Size = new System.Drawing.Size(257, 341);
            this.PlaceHolder.TabIndex = 9;
            this.PlaceHolder.TabStop = false;
            this.PlaceHolder.Text = "Custom Variables";
            this.PlaceHolder.Enter += new System.EventHandler(this.PlaceHolder_Enter);
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.SystemColors.ControlText;
            this.richTextBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox2.Location = new System.Drawing.Point(4, 14);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(246, 321);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "{SPOTIFY}\n\n{TIMESTAMP}\n\n{FPS}\n\n{TIME}\n\n{CLANTAG}\n\n{CPU}\n\n{GPU}\n\n{RAM}\n\n{TABBED}\n\n" +
    "{ANIMATED}\n\n{LYRICS}\n\n{CLEARBOX}\n\n{TABBEDV2}\n";
            this.richTextBox2.TextChanged += new System.EventHandler(this.richTextBox2_TextChanged);
            // 
            // checkBox6
            // 
            this.checkBox6.AutoSize = true;
            this.checkBox6.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox6.Location = new System.Drawing.Point(362, 320);
            this.checkBox6.Name = "checkBox6";
            this.checkBox6.Size = new System.Drawing.Size(61, 17);
            this.checkBox6.TabIndex = 12;
            this.checkBox6.Text = "Custom";
            this.checkBox6.UseVisualStyleBackColor = true;
            this.checkBox6.CheckedChanged += new System.EventHandler(this.checkBox6_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.SessionHolder);
            this.groupBox3.Controls.Add(this.ForceUpdateSessions);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox3.Location = new System.Drawing.Point(298, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 115);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Session List";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // SessionHolder
            // 
            this.SessionHolder.Location = new System.Drawing.Point(6, 12);
            this.SessionHolder.Name = "SessionHolder";
            this.SessionHolder.Size = new System.Drawing.Size(187, 68);
            this.SessionHolder.TabIndex = 2;
            this.SessionHolder.TabStop = false;
            this.SessionHolder.Enter += new System.EventHandler(this.SessionHolder_Enter);
            // 
            // ForceUpdateSessions
            // 
            this.ForceUpdateSessions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ForceUpdateSessions.Location = new System.Drawing.Point(6, 86);
            this.ForceUpdateSessions.Name = "ForceUpdateSessions";
            this.ForceUpdateSessions.Size = new System.Drawing.Size(187, 23);
            this.ForceUpdateSessions.TabIndex = 1;
            this.ForceUpdateSessions.Text = "Force Update Sessions";
            this.ForceUpdateSessions.UseVisualStyleBackColor = true;
            this.ForceUpdateSessions.Click += new System.EventHandler(this.ForceUpdateSessions_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.presenceToggle);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox2.Location = new System.Drawing.Point(12, 151);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 46);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Discord Presence";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // presenceToggle
            // 
            this.presenceToggle.AutoSize = true;
            this.presenceToggle.BackColor = System.Drawing.Color.Transparent;
            this.presenceToggle.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.presenceToggle.Location = new System.Drawing.Point(9, 19);
            this.presenceToggle.Name = "presenceToggle";
            this.presenceToggle.Size = new System.Drawing.Size(59, 17);
            this.presenceToggle.TabIndex = 0;
            this.presenceToggle.Text = "Enable";
            this.presenceToggle.UseVisualStyleBackColor = false;
            this.presenceToggle.CheckedChanged += new System.EventHandler(this.PresenceToggle_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(304, 339);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Load Text";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox9
            // 
            this.checkBox9.AutoSize = true;
            this.checkBox9.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox9.Location = new System.Drawing.Point(353, 348);
            this.checkBox9.Name = "checkBox9";
            this.checkBox9.Size = new System.Drawing.Size(59, 17);
            this.checkBox9.TabIndex = 15;
            this.checkBox9.Text = "Enable";
            this.checkBox9.UseVisualStyleBackColor = true;
            this.checkBox9.CheckedChanged += new System.EventHandler(this.checkBox9_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(257, 342);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 16;
            this.button4.Text = "Load Config";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button3.Location = new System.Drawing.Point(418, 342);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(88, 23);
            this.button3.TabIndex = 17;
            this.button3.Text = "Save Config";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(765, 330);
            this.groupBox5.TabIndex = 10;
            this.groupBox5.TabStop = false;
            this.groupBox5.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBox5_DragDrop);
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter_1);
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox1.CharHeight = 14;
            this.fastColoredTextBox1.CharWidth = 8;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fastColoredTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.fastColoredTextBox1.IndentBackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.LineNumberColor = System.Drawing.Color.White;
            this.fastColoredTextBox1.Location = new System.Drawing.Point(7, 20);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox1.ServiceColors")));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(749, 304);
            this.fastColoredTextBox1.TabIndex = 0;
            this.fastColoredTextBox1.Zoom = 100;
            this.fastColoredTextBox1.Load += new System.EventHandler(this.fastColoredTextBox1_Load);
            // 
            // fastColoredTextBox2
            // 
            this.fastColoredTextBox2.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox2.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.fastColoredTextBox2.BackBrush = null;
            this.fastColoredTextBox2.BackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox2.CharHeight = 14;
            this.fastColoredTextBox2.CharWidth = 8;
            this.fastColoredTextBox2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox2.ForeColor = System.Drawing.SystemColors.Window;
            this.fastColoredTextBox2.IndentBackColor = System.Drawing.Color.Black;
            this.fastColoredTextBox2.IsReplaceMode = false;
            this.fastColoredTextBox2.LineNumberColor = System.Drawing.Color.White;
            this.fastColoredTextBox2.Location = new System.Drawing.Point(2, 19);
            this.fastColoredTextBox2.Name = "fastColoredTextBox2";
            this.fastColoredTextBox2.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox2.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox2.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fastColoredTextBox2.ServiceColors")));
            this.fastColoredTextBox2.Size = new System.Drawing.Size(762, 142);
            this.fastColoredTextBox2.TabIndex = 18;
            this.fastColoredTextBox2.Zoom = 100;
            this.fastColoredTextBox2.TextChangedDelayed += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.S);
            this.fastColoredTextBox2.Load += new System.EventHandler(this.fastColoredTextBox2_Load);
            // 
            // checkBox12
            // 
            this.checkBox12.AutoSize = true;
            this.checkBox12.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBox12.Location = new System.Drawing.Point(161, 99);
            this.checkBox12.Name = "checkBox12";
            this.checkBox12.Size = new System.Drawing.Size(61, 17);
            this.checkBox12.TabIndex = 13;
            this.checkBox12.Text = "Custom";
            this.checkBox12.UseVisualStyleBackColor = true;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(780, 600);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBox10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.checkBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.PlaceHolder);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "VRChatify";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.TextChanged += new System.EventHandler(this.fastColoredTextBox1_TextChanged);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox3)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.PlaceHolder.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox oscMessage;
        private System.Windows.Forms.ListBox Sessions;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.CheckBox checkBox10;
        private System.Windows.Forms.GroupBox groupBox6;
        public System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBox7;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label oscMessageLabel;
        private System.Windows.Forms.CheckBox OSCToggle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label ClanTagLabel;
        private System.Windows.Forms.TextBox ClanTag;
        private System.Windows.Forms.CheckBox DebugLogging;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox PlaceHolder;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.CheckBox checkBox6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox SessionHolder;
        private System.Windows.Forms.Button ForceUpdateSessions;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox presenceToggle;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox checkBox9;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox5;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox2;
        public FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox3;
        private System.Windows.Forms.CheckBox checkBox8;
        private System.Windows.Forms.CheckBox checkBox11;
        private System.Windows.Forms.CheckBox checkBox12;
    }
}
