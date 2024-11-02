using CoordinateNavigation.Events.Common;
using CoordinateNavigation.Services.Interfaces;

namespace CoordinateNavigation.Services.Implementations
{
    public class EventAggregator : IEventAggregator
    {
        private readonly Dictionary<Type, List<object>> _eventQueue = [];

        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);

            foreach (var eventHandler in _eventQueue[eventType].OfType<Action<TEvent>>())
            {
                eventHandler(eventToPublish);
            };
        }

        public void Subscribe<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);

            if (!_eventQueue.TryGetValue(eventType, out List<object>? value))
            {
                value ??= [];
                _eventQueue[eventType] = value;
            }

            _eventQueue[eventType].Add(eventHandler);
        }

        public void Unsubscribe<TEvent>(Action<TEvent> eventHandler) where TEvent : IEvent
        {
            Type eventType = typeof(TEvent);

            if (_eventQueue.TryGetValue(eventType, out List<object>? value) && value.Count != 0)
            {
                value.Remove(eventHandler);
            }
        }
    }
}
