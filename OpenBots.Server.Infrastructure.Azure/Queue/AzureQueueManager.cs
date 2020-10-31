//using System;
//using System.Text;
//using OpenBots.Server.Model.Core;
//using Microsoft.Azure.ServiceBus;
//using Microsoft.Azure.ServiceBus.Core;
//using Newtonsoft.Json;
//using System.Threading.Tasks;
//using OpenBots.Server.Model.Identity;
//using Microsoft.Extensions.Logging;
//using System.Threading;
//using OpenBots.Server.Core;

//namespace OpenBots.Server.Infrastructure.Azure
//{
//    public class AzureQueueManager : IQueuePublisher, IQueue, IQueueSubscriber, IEntityOperationEventSink
//    {

//        //private readonly string _connectionString;
//        //private readonly string _queueName = "Default";
//        private readonly IQueueClient queueClient = null;
//        private readonly UserSecurityContext _userContext = null;
//        private readonly ILogger _logger = null;
//       // private readonly bool _enableMessaging = false;
//        private readonly IMessageHandler _messageHandler = null;
//        private readonly AzureQueueSetting queueSetting;

//        #region Constructors

//        public AzureQueueManager(UserSecurityContext userContext, ILogger logger, IMessageHandler _messageHandler, AzureQueueSetting azureQueueSetting)
//        {
//            _userContext = userContext;
//            _logger = logger;
//            queueSetting = azureQueueSetting;

//            //_connectionString = connectionString;

//            //if (!string.IsNullOrEmpty(queueName))
//            //    this._queueName = queueName;

//            //_enableMessaging = enableMessaging;

//            if (queueSetting.EnableMessaging)
//                queueClient = new QueueClient(queueSetting.ConnectionString, queueSetting.QueueName);

//        }
//        #endregion Constructors


//        #region IQueueManager Members

//        public void Init()
//        {

//        }

//        public void PublishEvent<T>(T eventEntity)
//        {
//           Enqueue<T>(eventEntity).Wait();
//        }

//        #endregion IQueueManager Members

//        public async Task Enqueue<T>(T eventEntity)
//        {
//            if (queueSetting.EnableMessaging)
//            {
//                Message message = Envelope(Compose<T>(eventEntity));

//                await queueClient.SendAsync(message);
//            }
//        }

//        public async Task Dequeue(TimeSpan waitTime)
//        {
//            if (!queueSetting.EnableMessaging)
//                return;

//            var receiver = new MessageReceiver(queueSetting.ConnectionString, queueSetting.QueueName, ReceiveMode.PeekLock);
//            var message = await receiver.ReceiveAsync(waitTime);
//            CancellationTokenSource source = new CancellationTokenSource();
//            CancellationToken token = source.Token;
//            await Recieve(message, token);

//        }


//        public void Register()
//        {
//            if (!queueSetting.EnableMessaging)
//                return;

//            var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
//            {
//                MaxConcurrentCalls = 1,
//                AutoComplete = false
//            };

//            queueClient.RegisterMessageHandler(Recieve, messageHandlerOptions);
//        }

//        private async Task Recieve(Message message, CancellationToken token)
//        {
//            var myPayload = JsonConvert.DeserializeObject<MessageEnvelope>(Encoding.UTF8.GetString(message.Body));
//            try
//            {
//                Process(myPayload);
//                await queueClient.CompleteAsync(message.SystemProperties.LockToken);
//            }
//            catch (Exception ex)
//            {
//                string exceptionReason = ex.GetType().FullName + " " + ex.Message;
//                string exception = SerializeToString(ex);
//                await queueClient.DeadLetterAsync(message.SystemProperties.LockToken, exceptionReason, exception);
//            }

//        }

//        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
//        {
//            if (_logger != null)
//            {
//                _logger.LogError(exceptionReceivedEventArgs.Exception, "Message handler encountered an exception");
//                var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

//                _logger.LogDebug($"- Endpoint: {context.Endpoint}");
//                _logger.LogDebug($"- Entity Path: {context.EntityPath}");
//                _logger.LogDebug($"- Executing Action: {context.Action}");
//            }
//            return Task.CompletedTask;
//        }

//        public async Task Close()
//        {
//            await queueClient.CloseAsync();
//        }

//        private void Process(MessageEnvelope envelope)
//        {
//            if (_messageHandler != null)
//                _messageHandler.OnMessage(envelope);
//        }

//        private MessageEnvelope Compose<T>(T message)
//        {
//            MessageEnvelope envelope = new MessageEnvelope();
//            envelope.MessageSentOn = DateTime.UtcNow;
//            envelope.MessageUID = Guid.NewGuid();

//            if (_userContext != null)
//                envelope.User = _userContext.PersonId;

//            envelope.MessageType = message.GetType().Name;
//            envelope.Message = message;

//            return envelope;
//        }

//        private Message Envelope(MessageEnvelope envelope)
//        {
//            byte[] messageBytes = Serialize(envelope);
//            var message = new Message(messageBytes)
//            {

//                ContentType = "application/json",
//                Label = envelope.MessageType,
//            };

//            return message;
//        }






//        #region IDisposable Support
//        private bool disposedValue = false; // To detect redundant calls


//        protected virtual void Dispose(bool disposing)
//        {
//            if (!disposedValue)
//            {
//                if (disposing)
//                {
//                    // TODO: dispose managed state (managed objects).
//                }

//                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
//                // TODO: set large fields to null.

//                disposedValue = true;
//            }
//        }

//        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
//        // ~EventQueuePublisher()
//        // {
//        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
//        //   Dispose(false);
//        // }

//        // This code added to correctly implement the disposable pattern.
//        public void Dispose()
//        {
//            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
//            Dispose(true);
//            // TODO: uncomment the following line if the finalizer is overridden above.
//            // GC.SuppressFinalize(this);
//        }
//        #endregion

//        private byte[] Serialize(object messageObject)
//        {
//            string messageString = SerializeToString(messageObject);
//            return Encoding.UTF8.GetBytes(messageString);
//        }

//        private string SerializeToString(object messageObject)
//        {
//            return JsonConvert.SerializeObject(messageObject);

//        }

//        private Message SerializeMessage(object messageObject)
//        {
//            byte[] messageBytes = Serialize(messageObject);
//            var message = new Message(messageBytes)
//            {

//                ContentType = "application/json",
//                Label = messageObject.GetType().Name,
//            };

//            return message;
//        }


//        private async Task<object> DeserializeType(byte[] serializedMessage, string typeName)
//        {
//            return await DeserializeType(serializedMessage, Type.GetType(typeName));
//        }

//        private async Task<object> DeserializeType(byte[] serializedMessage, Type type)
//        {
//            dynamic messageObject = await Deserialize(serializedMessage);
//            return Convert.ChangeType(messageObject, type);
//        }

//        private dynamic Deserialize(byte[] serializedMessage)
//        {
//            dynamic messageObject = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(serializedMessage));
//            return messageObject;
//        }

//        public void RaiseOperationCompletedEvent(EntityChange change)
//        {
//           Enqueue(change).Wait();
//        }
//    }
//}
