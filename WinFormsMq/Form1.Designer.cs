namespace WinFormsMq
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSubscribe = new System.Windows.Forms.Button();
            this.BtnPublish = new System.Windows.Forms.Button();
            this.txtSubTopic = new System.Windows.Forms.TextBox();
            this.txtPubTopic = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIPAddr = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPWD = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtClientID = new System.Windows.Forms.TextBox();
            this.butCon = new System.Windows.Forms.Button();
            this.cmbQos = new System.Windows.Forms.ComboBox();
            this.cmbRetain = new System.Windows.Forms.ComboBox();
            this.txtSendMessage = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnUnSub = new System.Windows.Forms.Button();
            this.butUnCon = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbtopicQus = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.listboxMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.listboxMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(351, 138);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "订阅主题：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(354, 177);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "发布主题:";
            // 
            // BtnSubscribe
            // 
            this.BtnSubscribe.Location = new System.Drawing.Point(915, 129);
            this.BtnSubscribe.Name = "BtnSubscribe";
            this.BtnSubscribe.Size = new System.Drawing.Size(59, 30);
            this.BtnSubscribe.TabIndex = 2;
            this.BtnSubscribe.Text = "订阅";
            this.BtnSubscribe.UseVisualStyleBackColor = true;
            this.BtnSubscribe.Click += new System.EventHandler(this.BtnSubscribe_Click);
            // 
            // BtnPublish
            // 
            this.BtnPublish.Location = new System.Drawing.Point(915, 177);
            this.BtnPublish.Name = "BtnPublish";
            this.BtnPublish.Size = new System.Drawing.Size(94, 49);
            this.BtnPublish.TabIndex = 3;
            this.BtnPublish.Text = "发布";
            this.BtnPublish.UseVisualStyleBackColor = true;
            this.BtnPublish.Click += new System.EventHandler(this.BtnPublish_Click);
            // 
            // txtSubTopic
            // 
            this.txtSubTopic.Location = new System.Drawing.Point(436, 131);
            this.txtSubTopic.Name = "txtSubTopic";
            this.txtSubTopic.Size = new System.Drawing.Size(173, 27);
            this.txtSubTopic.TabIndex = 4;
            // 
            // txtPubTopic
            // 
            this.txtPubTopic.Location = new System.Drawing.Point(436, 174);
            this.txtPubTopic.Name = "txtPubTopic";
            this.txtPubTopic.Size = new System.Drawing.Size(173, 27);
            this.txtPubTopic.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Port:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(650, 210);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Retain:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(382, 210);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Qos:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "ClientID:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(632, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Password:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(354, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Username:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(632, 21);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 20);
            this.label10.TabIndex = 15;
            this.label10.Text = ":";
            // 
            // txtIPAddr
            // 
            this.txtIPAddr.Location = new System.Drawing.Point(446, 18);
            this.txtIPAddr.Name = "txtIPAddr";
            this.txtIPAddr.Size = new System.Drawing.Size(173, 27);
            this.txtIPAddr.TabIndex = 16;
            this.txtIPAddr.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(720, 16);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(173, 27);
            this.txtPort.TabIndex = 17;
            this.txtPort.Text = "1883";
            // 
            // txtPWD
            // 
            this.txtPWD.Location = new System.Drawing.Point(720, 51);
            this.txtPWD.Name = "txtPWD";
            this.txtPWD.Size = new System.Drawing.Size(173, 27);
            this.txtPWD.TabIndex = 18;
            this.txtPWD.Text = "root";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(446, 55);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(173, 27);
            this.txtUserName.TabIndex = 19;
            this.txtUserName.Text = "root";
            // 
            // txtClientID
            // 
            this.txtClientID.Location = new System.Drawing.Point(441, 94);
            this.txtClientID.Name = "txtClientID";
            this.txtClientID.Size = new System.Drawing.Size(447, 27);
            this.txtClientID.TabIndex = 20;
            this.txtClientID.Text = "cclient";
            // 
            // butCon
            // 
            this.butCon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butCon.Location = new System.Drawing.Point(925, 21);
            this.butCon.Name = "butCon";
            this.butCon.Size = new System.Drawing.Size(67, 40);
            this.butCon.TabIndex = 21;
            this.butCon.Text = "连接";
            this.butCon.UseVisualStyleBackColor = true;
            this.butCon.Click += new System.EventHandler(this.butCon_Click);
            // 
            // cmbQos
            // 
            this.cmbQos.FormattingEnabled = true;
            this.cmbQos.Items.AddRange(new object[] {
            "AtmostOnce",
            "AtLeastonce",
            "ExactlyOnce"});
            this.cmbQos.Location = new System.Drawing.Point(436, 206);
            this.cmbQos.Name = "cmbQos";
            this.cmbQos.Size = new System.Drawing.Size(173, 28);
            this.cmbQos.TabIndex = 22;
            // 
            // cmbRetain
            // 
            this.cmbRetain.FormattingEnabled = true;
            this.cmbRetain.Items.AddRange(new object[] {
            "False",
            "True"});
            this.cmbRetain.Location = new System.Drawing.Point(715, 206);
            this.cmbRetain.Name = "cmbRetain";
            this.cmbRetain.Size = new System.Drawing.Size(173, 28);
            this.cmbRetain.TabIndex = 23;
            // 
            // txtSendMessage
            // 
            this.txtSendMessage.Location = new System.Drawing.Point(715, 173);
            this.txtSendMessage.Name = "txtSendMessage";
            this.txtSendMessage.Size = new System.Drawing.Size(173, 27);
            this.txtSendMessage.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(641, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "发布内容:";
            // 
            // BtnUnSub
            // 
            this.BtnUnSub.Location = new System.Drawing.Point(984, 131);
            this.BtnUnSub.Name = "BtnUnSub";
            this.BtnUnSub.Size = new System.Drawing.Size(59, 31);
            this.BtnUnSub.TabIndex = 26;
            this.BtnUnSub.Text = "取消";
            this.BtnUnSub.UseVisualStyleBackColor = true;
            this.BtnUnSub.Click += new System.EventHandler(this.BtnUnSub_Click);
            // 
            // butUnCon
            // 
            this.butUnCon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.butUnCon.Location = new System.Drawing.Point(925, 81);
            this.butUnCon.Name = "butUnCon";
            this.butUnCon.Size = new System.Drawing.Size(67, 40);
            this.butUnCon.TabIndex = 27;
            this.butUnCon.Text = "断开";
            this.butUnCon.UseVisualStyleBackColor = true;
            this.butUnCon.Click += new System.EventHandler(this.butUnCon_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1442, 817);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbtopicQus);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.listBox1);
            this.tabPage1.Controls.Add(this.butUnCon);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.BtnUnSub);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.BtnSubscribe);
            this.tabPage1.Controls.Add(this.txtSendMessage);
            this.tabPage1.Controls.Add(this.BtnPublish);
            this.tabPage1.Controls.Add(this.cmbRetain);
            this.tabPage1.Controls.Add(this.txtSubTopic);
            this.tabPage1.Controls.Add(this.cmbQos);
            this.tabPage1.Controls.Add(this.txtPubTopic);
            this.tabPage1.Controls.Add(this.butCon);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtClientID);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtUserName);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtPWD);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtPort);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtIPAddr);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1434, 784);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "客户端";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbtopicQus
            // 
            this.cmbtopicQus.FormattingEnabled = true;
            this.cmbtopicQus.Items.AddRange(new object[] {
            "AtmostOnce",
            "AtLeastonce",
            "ExactlyOnce"});
            this.cmbtopicQus.Location = new System.Drawing.Point(715, 135);
            this.cmbtopicQus.Name = "cmbtopicQus";
            this.cmbtopicQus.Size = new System.Drawing.Size(173, 28);
            this.cmbtopicQus.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(636, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "服务质量:";
            // 
            // listBox1
            // 
            this.listBox1.ContextMenuStrip = this.listboxMenu;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(32, 248);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBox1.Size = new System.Drawing.Size(1380, 524);
            this.listBox1.TabIndex = 28;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // listboxMenu
            // 
            this.listboxMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.listboxMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem});
            this.listboxMenu.Name = "listboxMenu";
            this.listboxMenu.Size = new System.Drawing.Size(117, 28);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1434, 784);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 6);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1291, 754);
            this.textBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1444, 818);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "MQTT客户端";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.listboxMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Button BtnSubscribe;
        private Button BtnPublish;
        private TextBox txtSubTopic;
        private TextBox txtPubTopic;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        private TextBox txtIPAddr;
        private TextBox txtPort;
        private TextBox txtPWD;
        private TextBox txtUserName;
        private TextBox txtClientID;
        private Button butCon;
        private ComboBox cmbQos;
        private ComboBox cmbRetain;
        private TextBox txtSendMessage;
        private Label label4;
        private Button BtnUnSub;
        private Button butUnCon;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ListBox listBox1;
        private ComboBox cmbtopicQus;
        private Label label11;
        private ContextMenuStrip listboxMenu;
        private ToolStripMenuItem copyToolStripMenuItem;
        private TextBox textBox1;
    }
}