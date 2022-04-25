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
        ///���ӷ�����
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
                    var tcpServer = txtIPAddr.Text;//mqtt��������ַ
                    var tcpPort = int.Parse(txtPort.Text.Trim());
                    var mqttUser = txtUserName.Text.Trim();
                    var mqttPassword = txtPWD.Text.Trim();
                    //Guid.NewGuid().ToString()�ͻ������к�
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
                            listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"MQTT�ͻ�������ʧ�ܣ������������ӣ�" + Environment.NewLine))); 
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
                                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"MQTT�ͻ�������ʧ�ܣ�{{0}}" + Environment.NewLine, ex.Message)));
                            }));
                            
                        }
                    });
                   
                         await mqttClient.ConnectAsync(options);
                    //�ͻ��˳�������
                          IsConnected = true;
                    }
            }
            catch(Exception ex)
                {
                //�ͻ��˳������ӳ���
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Error, String.Format($"MQTT������ʧ�ܣ�" +ex.Message)));
                }));
            }
           
        }
        public void OnMqttClientConnected(MqttClientConnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format("�����ӵ�MQTT��������" + Environment.NewLine)));
            }));
        }
        public void OnMqttClientDisConnected(MqttClientDisconnectedEventArgs e)
        {
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format("�ͻ����ѶϿ���" + Environment.NewLine)));
            }));


        }
        /// <summary>
        /// �յ����Է���˵���Ϣ
        /// </summary>
        /// <param name="e"></param>
        public  void OnSubscriberMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            // �յ�����Ϣ����
            string topic = e.ApplicationMessage.Topic;
            // �յ��ĵ���Ϣ����
            string payload = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
            // �յ��ķ��ͼ���(Qos)
            var qos = e.ApplicationMessage.QualityOfServiceLevel;
            // �յ�����Ϣ������ʽ
            bool retain = e.ApplicationMessage.Retain;
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"�յ�����������: [{topic}] ����: [{payload}] Qos: [{qos}] Retain:[{retain}]")));
            }));
        }
        ///<summary>
        ///�ͻ����Ͽ�
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
                        listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"�ͻ��˶Ͽ���{Environment.NewLine}")));
                    }));
                }
                else
                {
                    return;
                }
            }catch (Exception ex)
            {
                //�ͻ��˳��ԶϿ�server����
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Warn, String.Format($"�ͻ��˶Ͽ�����{Environment.NewLine}")));
                }));
            }
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        public async void ClientPublishMqttTopic(string topic,string payload)
        {
            try
            {
                if (mqttClient == null)
                {
                    MessageBox.Show("MQTT�ͻ�����δ����");
                    return;
                }
                else if (!mqttClient.IsConnected)
                {
                    MessageBox.Show("MQTT�ͻ�����δ����");
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
                //�ͻ��˷��ͳɹ� mqttClient.Options.ClientId topic
                //�ͻ��˷����쳣
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"�ͻ��˷�������Ϊ{{0}}����Ϊ{{1}}�ɹ���{Environment.NewLine}",topic,payload)));
                }));
            }
            catch(Exception ex)
            {
                //�ͻ��˷����쳣
                this.Invoke(new Action(() =>
                {
                    listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"�ͻ��˷�����Ϣʧ��{{0}}��{Environment.NewLine}", ex.Message)));
                }));
            }
        }
        /// <summary>
        /// ������Ϣ���� ������Ϣ
        /// </summary>
        /// <param name="topic"></param>
        public async void ClientSubscribeTopic(string topic,int qua)
        {
            await  mqttClient.SubscribeAsync(new MqttTopicFilterBuilder().WithTopic(topic).WithQualityOfServiceLevel((MqttQualityOfServiceLevel)qua).Build());
            //���ĳɹ�
            this.Invoke(new Action(() =>
            {
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info,String.Format($"�ͻ���{{0}}��������{{1}}�ɹ���{Environment.NewLine}", mqttClient.Options.ClientId,topic)));
            }));
        }
        public async void ClientUnsubscribeTopic(string topic)
        {
            await mqttClient.UnsubscribeAsync(topic);
            //ȡ������
            //���ĳɹ�
            this.Invoke(new Action(() =>
            { 
                listBox1.Items.Add(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"�ͻ���{{0}}ȡ����������{{1}}�ɹ���{Environment.NewLine}", mqttClient.Options.ClientId, topic)));
               // txtReceiveMessage.AppendText(Logger.TraceLog(Logger.LogLevel.Info, String.Format($"�ͻ���{{0}}ȡ����������{{1}}�ɹ���{Environment.NewLine}", mqttClient.Options.ClientId, topic)));
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
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSubscribe_Click(object sender, EventArgs e)
        {
            string topic=txtSubTopic.Text.Trim();
            if (string.IsNullOrEmpty(topic))
            {
                MessageBox.Show("�������ⲻ��Ϊ��!");
                return;
            }
            else if (mqttClient==null)
            {
                MessageBox.Show("MQTT�ͻ�����δ����");
                return;
            }
            else if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT�ͻ�����δ����");
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
                MessageBox.Show("�������ⲻ��Ϊ�գ�");
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
                MessageBox.Show("ȡ���������ⲻ��Ϊ��!");
                return;
            }
            if(mqttClient==null)
            {
                MessageBox.Show("MQTT�ͻ�����δ����");
                return;
            }
            if (!mqttClient.IsConnected)
            {
                MessageBox.Show("MQTT�ͻ�����δ����");
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
        /// �Ҽ�������ѡ����
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