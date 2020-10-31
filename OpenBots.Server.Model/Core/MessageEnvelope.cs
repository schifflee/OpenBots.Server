using System;
using System.Collections.Generic;
using System.Text;

namespace OpenBots.Server.Model.Core
{
    public class MessageEnvelope
    {
        /// <summary>
        /// Gets or sets the message UID.
        /// </summary>
        /// <value>The message UID.</value>
        public Guid MessageUID { get; set; }

        /// <summary>
        /// Gets or sets the topic.
        /// </summary>
        /// <value>The topic.</value>
        public string Topic { get; set; }

        /// <summary>
        /// Gets or sets the message sent on.
        /// </summary>
        /// <value>The message sent on.</value>
        public DateTime MessageSentOn { get; set; }

        /// <summary>
        /// Gets or sets the originator.
        /// </summary>
        /// <value>The originator.</value>
        public string Originator { get; set; }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public Guid? User { get; set; }

        /// <summary>
        /// Gets or sets the reply to.
        /// </summary>
        /// <value>The reply to.</value>
        public string ReplyTo { get; set; }

        /// <summary>
        /// Gets or sets the reply of.
        /// </summary>
        /// <value>The reply of.</value>
        public Guid? ReplyOf { get; set; }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public string MessageType { get; set; }

        ///// <summary>
        ///// Gets or sets the message string.
        ///// </summary>
        ///// <value>The message string.</value>
        //public string MessageString { get; set; }

        public string Environment { get; set; }

        public object Message { get; set; }

    }
}
