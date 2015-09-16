using System;
using System.Collections.Specialized;
using WebSocketSharp.Net;

namespace WebSocketSharp
{
    public interface IWebSocket
    {
        /// Gets the WebSocket extensions selected by the server.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that represents the extensions if any.
        /// The default value is <see cref="String.Empty"/>.
        /// </value>
        string Extensions { get; }

        /// <summary>
        /// Gets a value indicating whether the WebSocket connection is alive.
        /// </summary>
        /// <value>
        /// <c>true</c> if the connection is alive; otherwise, <c>false</c>.
        /// </value>
        bool IsAlive { get; }

        /// <summary>
        /// Gets a value indicating whether the WebSocket connection is secure.
        /// </summary>
        /// <value>
        /// <c>true</c> if the connection is secure; otherwise, <c>false</c>.
        /// </value>
        bool IsSecure { get; }

        /// <summary>
        /// Gets or sets the value of the HTTP Origin header to send with the WebSocket connection
        /// request to the server.
        /// </summary>
        /// <remarks>
        /// The <see cref="WebSocket"/> sends the Origin header if this property has any.
        /// </remarks>
        /// <value>
        ///   <para>
        ///   A <see cref="string"/> that represents the value of
        ///   the <see href="http://tools.ietf.org/html/rfc6454#section-7">Origin</see> header to send.
        ///   The default value is <see langword="null"/>.
        ///   </para>
        ///   <para>
        ///   The Origin header has the following syntax:
        ///   <c>&lt;scheme&gt;://&lt;host&gt;[:&lt;port&gt;]</c>
        ///   </para>
        /// </value>
        string Origin { get; set; }

        /// <summary>
        /// Gets the WebSocket subprotocol selected by the server.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> that represents the subprotocol if any.
        /// The default value is <see cref="String.Empty"/>.
        /// </value>
        string Protocol { get; }

        /// <summary>
        /// Gets the state of the WebSocket connection.
        /// </summary>
        /// <value>
        /// One of the <see cref="WebSocketState"/> enum values, indicates the state of the WebSocket
        /// connection. The default value is <see cref="WebSocketState.Connecting"/>.
        /// </value>
        WebSocketState ReadyState { get; }

        /// <summary>
        /// Gets or sets the SSL configuration used to authenticate the server and
        /// optionally the client for secure connection.
        /// </summary>
        /// <value>
        /// A <see cref="ClientSslConfiguration"/> that represents the configuration used
        /// to authenticate the server and optionally the client for secure connection,
        /// or <see langword="null"/> if the <see cref="WebSocket"/> is used as server.
        /// </value>
        ClientSslConfiguration SslConfiguration { get; set; }

        /// <summary>
        /// Gets the WebSocket URL to connect.
        /// </summary>
        /// <value>
        /// A <see cref="Uri"/> that represents the WebSocket URL to connect.
        /// </value>
        Uri Url { get; }

        /// <summary>
        /// Gets or sets the wait time for the response to the Ping or Close.
        /// </summary>
        /// <value>
        /// A <see cref="TimeSpan"/> that represents the wait time. The default value is
        /// the same as 5 seconds, or 1 second if the <see cref="WebSocket"/> is used by
        /// a server.
        /// </value>
        TimeSpan WaitTime { get; set; }

        /// <summary>
        /// Get or set headers sent on the initial connect to the server
        /// </summary>
        /// <value>A <see cref="NameValueCollection"> of header values that will be added
        /// on connection. These will be overridden by anything used by the Websocket protocol
        ///</value>
        NameValueCollection ExtraClientHeaders { get; set; }

        /// <summary>
        /// Occurs when the WebSocket connection has been closed.
        /// </summary>
        event EventHandler<CloseEventArgs> OnClose;

        /// <summary>
        /// Occurs when the <see cref="WebSocket"/> gets an error.
        /// </summary>
        event EventHandler<ErrorEventArgs> OnError;

        /// <summary>
        /// Occurs when the <see cref="WebSocket"/> receives a message.
        /// </summary>
        event EventHandler<MessageEventArgs> OnMessage;

        /// <summary>
        /// Occurs when the WebSocket connection has been established.
        /// </summary>
        event EventHandler OnOpen;

        /// <summary>
        /// Closes the WebSocket connection with the specified <see cref="CloseStatusCode"/>
        /// and <see cref="string"/>, and releases all associated resources.
        /// </summary>
        /// <remarks>
        /// This method emits a <see cref="OnError"/> event if the size of <paramref name="reason"/>
        /// is greater than 123 bytes.
        /// </remarks>
        /// <param name="code">
        /// One of the <see cref="CloseStatusCode"/> enum values, represents the status code
        /// indicating the reason for the close.
        /// </param>
        /// <param name="reason">
        /// A <see cref="string"/> that represents the reason for the close.
        /// </param>
        void Close (CloseStatusCode code, string reason);

        /// <summary>
        /// Establishes a WebSocket connection asynchronously.
        /// </summary>
        /// <remarks>
        /// This method doesn't wait for the connect to be complete.
        /// </remarks>
        void ConnectAsync ();

        /// <summary>
        /// Sends a text <paramref name="data"/> asynchronously using the WebSocket connection.
        /// </summary>
        /// <remarks>
        /// This method doesn't wait for the send to be complete.
        /// </remarks>
        /// <param name="data">
        /// A <see cref="string"/> that represents the text data to send.
        /// </param>
        /// <param name="completed">
        /// An <c>Action&lt;bool&gt;</c> delegate that references the method(s) called when
        /// the send is complete. A <see cref="bool"/> passed to this delegate is <c>true</c>
        /// if the send is complete successfully.
        /// </param>
        void SendAsync (string data, Action<bool> completed);

    }
}