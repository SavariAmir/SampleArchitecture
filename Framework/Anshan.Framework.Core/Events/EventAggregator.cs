﻿using System.Collections.Generic;
using System.Linq;

namespace Anshan.Framework.Core.Events
{
    public class EventAggregator : IEventPublisher, IEventListener
    {
        private readonly List<object> _handlers = new List<object>();

        public void Publish<T>(T @event) where T : IEvent
        {
            var handlers = this._handlers.OfType<IEventHandler<T>>().ToList();
            handlers.ForEach(p => p.Handle(@event));
        }

        public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            _handlers.Add(handler);
        }
    }
}