using MQTTnet;
using MQTTnet.Client.Receiving;
using MQTTnet.Server;

namespace WinFormsMq.core
{
    public class MqServer
    {
        public static MqttServer mqttServer = null;
        public static async void StartMqttServer()
        {
            if (mqttServer == null)
            {
                try
                {
                    var optionsBuilder = new MqttServerOptionsBuilder().WithDefaultEndpoint().WithDefaultEndpointPort(1733)
                        .WithConnectionValidator(
                        c =>
                        {
                            var currentUser = "root";
                            var currentPwd = "root";
                            if (currentUser == null || currentPwd == null)
                            {
                                c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
                                return;
                            }
                            if (c.Username != currentUser)
                            {
                                c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
                                return;
                            }
                            if (c.Password != currentPwd)
                            {
                                c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.BadUserNameOrPassword;
                                return;
                            }
                            c.ReasonCode = MQTTnet.Protocol.MqttConnectReasonCode.Success;
                        }).WithSubscriptionInterceptor(c =>
                        {
                            c.AcceptSubscription = true;
                        }).WithApplicationMessageInterceptor(c =>
                        {
                            c.AcceptPublish = true;
                        });

                    mqttServer = new MqttFactory().CreateMqttServer() as MqttServer;
                    mqttServer.StartedHandler = new MqttServerStartedHandlerDelegate(OnMqttServerStarted);
                    mqttServer.StoppedHandler = new MqttServerStoppedHandlerDelegate(OnMqttServerStopped);

                    mqttServer.ClientConnectedHandler=new MqttServerClientConnectedHandlerDelegate(OnMqttServerClientConnected);
                    mqttServer.ClientDisconnectedHandler=new MqttServerClientDisconnectedHandlerDelegate(OnMqttServerClientDisconnected);
                    mqttServer.ClientSubscribedTopicHandler=new MqttServerClientSubscribedTopicHandlerDelegate(OnMqttServerClientSubscribedTopic);
                    mqttServer.ClientUnsubscribedTopicHandler = new MqttServerClientUnsubscribedTopicHandlerDelegate(OnMqttServerClientUnsubscribedTopic);
                    mqttServer.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandlerDelegate(OnMqttServer_ApplicationMessageReceived);

                    await mqttServer.StartAsync(optionsBuilder.Build());
                } catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        /// <summary>
        /// 关闭服务器
        /// </summary>
        public static async void StopMqttServer()
        {
            if (mqttServer == null) return;
            try
            {
                await mqttServer?.StopAsync();
                mqttServer=null;    

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
        /// <summary>
        /// 发布消息
        /// </summary>
      /*  public static async void PublishMqttTopic(string topic, string payload)
        {
            var message = new MqttApplicationMessage()
            {
                Topic = topic,
                Payload = Encoding.UTF8.GetBytes(payload)
            };
            await mqttServer.PublishAsync(message);
        }*/
        public static void OnMqttServerStarted(EventArgs e)
        {
            Console.WriteLine("MQTT服务启动完成！");
        }
        public static void OnMqttServerStopped(EventArgs e)
        {
            Console.WriteLine("MQTT服务停止完成！");
        }
        public static void OnMqttServerClientConnected(MqttServerClientConnectedEventArgs e)
        {
            Console.WriteLine($"客户端[{e.ClientId}]已连接");
        }

        public static void OnMqttServerClientDisconnected(MqttServerClientDisconnectedEventArgs e)
        {
            //Console.WriteLine($"客户端[{e.ClientId}]已断开连接！");
        }

        public static void OnMqttServerClientSubscribedTopic(MqttServerClientSubscribedTopicEventArgs e)
        {
            //Console.WriteLine($"客户端[{e.ClientId}]已成功订阅主题[{e.TopicFilter}]！");
        }
        public static void OnMqttServerClientUnsubscribedTopic(MqttServerClientUnsubscribedTopicEventArgs e)
        {
            //Console.WriteLine($"客户端[{e.ClientId}]已成功取消订阅主题[{e.TopicFilter}]！");
        }

        public static void OnMqttServer_ApplicationMessageReceived(MqttApplicationMessageReceivedEventArgs e)
        {
            //Console.WriteLine($"客户端[{e.ClientId}]>> 主题：{e.ApplicationMessage.Topic} 负荷：{Encoding.UTF8.GetString(e.ApplicationMessage.Payload)} Qos：{e.ApplicationMessage.QualityOfServiceLevel} 保留：{e.ApplicationMessage.Retain}");
        }
    }
}
