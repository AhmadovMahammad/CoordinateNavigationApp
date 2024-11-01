using CoordinateNavigation.Events.Common;

namespace CoordinateNavigation.Services.Interfaces
{
    public interface IEventAggregator
    {
        void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent;
        void Subscribe<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent;
        void Unsubscribe<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent;
    }
}
