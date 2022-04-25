using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Connecting;
using MQTTnet.Client.Disconnecting;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using MQTTnet.Protocol;
using System.Text;
using WinFormsMq.core;
namespace WinFormsMq
{
    public partial class Form1 : Form
    {
        private MqttClient mqttClient = null;
        private bool IsConnected=false;
        public Form1()
        {
            InitializeComponent();
        }

        public void Init()
        {
            cmbQos.SelectedIndex = 0;
            cmbtopicQus.SelectedIndex = 0;
            cmbRetain.SelectedIndex = 0;
            //MqServer.StartMqttServer();
        }
        ///<summary>
        ///连接服务器
        /// </summary>
        /// 
        private async Task ConnectMqttServerAsync()
        {
            try
            {
                if (!IsConnected)
                {
                    var mqttFactory = new MqttFactory();
                     mqttClient = mqttFactory.CreateMqttClient() as MqttClient;
                     mqttClient.ConnectedHandler = new MqttClientConnectedHandlerDelegate(OnMqttClientConnected);
                    // mqttClient.DisconnectedHandler = new MqttClientDisconnectedHandlerDelegate(OnMqttClientDisConnected);
                     mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnSubscriberMessageReceived);

                    /*mqttClient.UseConnectedHandler(async e =>
                    {
                        Console.WriteLine("### CONNECTED WITH SERVER ###");

                        // Subscribe to a topic
                        await mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic("my/topic").WithQualityOfServiceLevel(0).Build());

                        Console.WriteLine("### SUBSCRIBED ###");
                    });*/
                    var tcpServer = txtIPAddr.Text;//mqtt服务器地址
                    var tcpPort = int.Parse(txtPort.Text.Trim());
                    var mqttUser = txtUserName.Text.Trim();
                    var mqttPassword = txtPWD.Text.Trim();
                    //Guid.NewGuid().ToString()客户端序列号
                    var options = new MqttClientOptions
                    {
                        ClientId = txtClientID.Text.Trim(),
                        ProtocolVersion = MQTTnet.Formatter.MqttProtocolVersion.V311,
                        ChannelOptions = new MqttClientTcpOptions
                        {
                            Server = tcpServer,
                            Port = tcpPort,
                        },
                        WillDelayInterval = 100,
                        WillMessage = new MqttApplicationMessage()
                        {
                            Topic = $"LastWill/{txtClientID.Text.Trim()}",
                            Payload = Encoding.UTF8.GetBytes("I lost the connection!"),
                            QualityOfServiceLevel = MQTTnet.Protocol.MqttQualityOfServiceLevel.ExactlyOnce
                        }
                    };
                    if (options.ChannelOptions == null)
                    {
                        throw new InvalidOperationException();
                    }
                    if (!string.IsNullOrEmpty(mqttUser))
                    {
                        options.Credentials = new MqttClientCredentials
                        {
                            Username = mqttUser,
                            Password = Encoding.UTF8.GetBytes(mqttPassword)
                        };
                    }
                    options.CleanSession = false;
                    options.KeepAlivePeriod = TimeSpan.FromSeconds(500);

                    mqttClient.UseDisconnectedHandler(async e =>
                    {
                        this.Invoke(new Action(() =>
                        {
                            listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"MQTT客户端连接失败，尝试重新连接！" + Environment.NewLine))); 
                        }));
                        
                        await Task.Delay(TimeSpan.FromSeconds(5));
                        try
                        {                           
                            await mqttClient.ConnectAsync(options); // Since 3.0.5 with CancellationToken
                            IsConnected = mqttClient.IsConnected;
                          /*  this.Invoke(new Action(() =>
                            {
                                listBox1.Items.Add(mqttClient.IsConnected);
                            }));*/
                        }
                        catch (Exception ex)
                        {
                            this.Invoke(new Action(() =>
                            {
                                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"MQTT客户端连接失败！{{0}}" + Environment.NewLine, ex.Message)));
                            }));
                            
                        }
                    });
                   
                         await mqttClient.ConnectAsync(options);
                    //客户端尝试连接
                          IsConnected = true;
                    }
            }
            catch(Exception ex)
                {
                //客户端尝试连接出错
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Error, String.Format($"MQTT服务器失败！" +ex.Message)));
                }));
            }
           
        }
        public void OnMqttClientConnected(MqttClientConnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format("已连接到MQTT服务器！" + Environment.NewLine)));
            }));
        }
        public void OnMqttClientDisConnected(MqttClientDisconnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format("客户机已断开！" + Environment.NewLine)));
            }));


        }
        /// <summary>
        /// 收到来自服务端的消息
        /// </summary>
        /// <param name="e"></param>
        public  void OnSubscriberMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            // 收到的消息主题
            string topic = e.ApplicationMessage.Topic;
            // 收到的的消息内容
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            // 收到的发送级别(Qos)
            var qos = e.ApplicationMessage.QualityOfServiceLevel;
            // 收到的消息保持形式
            bool retain = e.ApplicationMessage.Retain;
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"收到服务器主题: [{topic}] 内容: [{payload}] Qos: [{qos}] Retain:[{retain}]")));
            }));
        }
        ///<summary>
        ///客户机断开
        /// </summary>
        private async Task ClientStop()
        {
            try
            {
                if(mqttClient.IsConnected)
                {
                    await mqttClient.DisconnectAsync();
                   // mqttClient = null;
                    this.Invoke(new Action(() =>
                    {
                        listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"客户端断开！{Environment.NewLine}")));
                    }));
                }
                else
                {
                    return;
                }
            }catch (Exception ex)
            {
                //客户端尝试断开server出错
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"客户端断开错误！{Environment.NewLine}")));
                }));
            }
        }
        /// <summary>
        /// 发布消息
        /// </summary>
        public async void ClientPublishMqttTopic(string topic,string payload)
        {
            try
            {
                if (mqttClient == null)
                {
                    MessageBox.Show("MQTT客户端尚未连接");
                    return;
                }
                else if (!mqttClient.IsConnected)
                {
                    MessageBox.Show("MQTT客户端尚未连接");
                    return;
                }
                var message = new MqttApplicationMessage()
                {
                    Topic = topic,
                    Payload = Encoding.UTF8.GetBytes(payload),
                    QualityOfServiceLevel = (MqttQualityOfServiceLevel)cmbQos.SelectedIndex,
                    Retain = bool.Parse(cmbRetain.SelectedItem.ToString()),
                };
                /* var message = new MqttApplicationMessageBuilder()
                            .WithTopic("MyTopic")
                            .WithPayload("Hello World")
                            .WithExactlyOnceQoS()
                            .WithRetainFlag()
                            .Build();*/
                await mqttClient.PublishAsync(message);
                //客户端发送成工 mqttClient.Options.ClientId topic
                //客户端发送异常
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"客户端发布主题为{{0}}内容为{{1}}成功！{Environment.NewLine}",topic,payload)));
                }));
            }
            catch(Exception ex)
            {
                //客户端发送异常
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"客户端发布消息失败{{0}}！{Environment.NewLine}", ex.Message)));
                }));
            }
        }
        /// <summary>
        /// 传入消息主题 订阅消息
        /// </summary>
        /// <param name="topic"></param>
        public async void ClientSubscribeTopic(string topic,int qua)
        {
            await  mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qua).Build());
            //订阅成功
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info,String.Format($"客户端{{0}}订阅主题{{1}}成功！{Environment.NewLine}", mqttClient.Options.ClientId,topic)));
            }));
        }
        public async void ClientUnsubscribeTopic(string topic)
        {
            await mqttClient.UnsubscribeAsync(topic);
            //取消订阅
            //订阅成功
            this.Invoke(new Action(() =>
            { 
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"客户端{{0}}取消订阅主题{{1}}成功！{Environment.NewLine}", mqttClient.Options.ClientId, topic)));
               // txtReceiveMessage.AppendText(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"客户端{{0}}取消订阅主题{{1}}成功！{Environment.NewLine}", mqttClient.Options.ClientId, topic)));
            }));
        }

        private void butCon_Click(object sender, EventArgs e)
        {
            Task.Run(async () => { await ConnectMqttServerAsync(); });
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        /// <summary>
        /// 订阅
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubscribe_Click(object sender, EventArgs e)
        {
            string topic=txtSubTopic.Text.Trim();
            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("订阅主题不能为空!");
                return;
            }
            else if (mqttClient==null)
            {
                MessageBox.Show("MQTT客户端尚未连接");
                return;
            }
            else if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT客户端尚未连接");
                return;
            }
            else
            {
              int qua= cmbtopicQus.SelectedIndex;
              ClientSubscribeTopic(topic,qua);
            }
        }

        private void BtnPublish_Click(object sender, EventArgs e)
        {
            string pubtopic=txtPubTopic.Text.Trim();
            if(string.IsNullOrEmpty(pubtopic))
            {
                MessageBox.Show("发布主题不能为空！");
                return;
            }
            string inputString = txtSendMessage.Text.Trim();
            ClientPublishMqttTopic(pubtopic, inputString);
        }

        private void BtnUnSub_Click(object sender, EventArgs e)
        {
            string topic = txtSubTopic.Text.Trim();
            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("取消订阅主题不能为空!");
                return;
            }
            if(mqttClient==null)
            {
                MessageBox.Show("MQTT客户端尚未连接");
                return;
            }
            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT客户端尚未连接");
                return;
            }
            ClientUnsubscribeTopic(topic);
        }

        private void butUnCon_Click(object sender, EventArgs e)
        {
            IsConnected = false;
            ClientStop();
        }

        private void butStartServer_Click(object sender, EventArgs e)
        {
            MqServer.StartMqttServer();
        }

        private void butstopserver_Click(object sender, EventArgs e)
        {
            MqServer.StopMqttServer();
        }
        /// <summary>
        /// 右键复制所选内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String data = "";
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                data += listBox1.SelectedItems[i].ToString();
            }
            Clipboard.SetDataObject(data);

            //MessageBox.Show(listBox1.SelectedItem.ToString());
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the currently selected item in the ListBox.
            textBox1.Clear();
            //List<string> list = new List<string>();
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                //list.Add(listBox1.SelectedItems[i].ToString());
                textBox1.AppendText(listBox1.SelectedItems[i].ToString());
            }
        }
    }
}