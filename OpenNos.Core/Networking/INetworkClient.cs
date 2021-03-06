﻿using OpenNos.Core.Networking.Communication.Scs.Communication.Messages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenNos.Core
{
    public interface INetworkClient
    {
        #region Events

        event EventHandler<MessageEventArgs> MessageReceived;

        #endregion

        #region Properties

        long ClientId { get; set; }

        string IpAddress { get; }

        bool IsConnected { get; }

        bool IsDisposing { get; set; }

        #endregion

        #region Methods

        void Disconnect();

        void Initialize(EncryptionBase encryptor);

        void SendPacket(string packet, byte priority = 10);

        void SendPacketFormat(string packet, params object[] param);

        void SendPackets(IEnumerable<string> packets, byte priority = 10);

        Task ClearLowpriorityQueue();

        void SetClientSession(object clientSession);

        #endregion
    }
}