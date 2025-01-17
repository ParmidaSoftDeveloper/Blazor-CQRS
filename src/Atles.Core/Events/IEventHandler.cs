﻿using System.Threading.Tasks;

namespace Atles.Core.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}
