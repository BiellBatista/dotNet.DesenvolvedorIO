﻿namespace NerdStore.Core.Messages;

public abstract class Message
{
    public string MessageType { get; protected set; }
    public Guid AggredateId { get; protected set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}