﻿namespace Anshan.Framework.Core.Events
{
    public interface IEventListener
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}