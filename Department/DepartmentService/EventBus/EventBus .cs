using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentService.EventBus
{
    public class EventBus : IEventBus
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<Type, List<Type>> _handlers;
        private readonly List<Type> _eventTypes;
        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _handlers = new Dictionary<Type, List<Type>>();
            _eventTypes = new List<Type>();
        }
        public void Publish<T>(T @event) where T : IntegrationEvent
        {
            var eventType = @event.GetType();

            if (_handlers.ContainsKey(eventType))
            {
                foreach (var handlerType in _handlers[eventType])
                {
                    var handler = _serviceProvider.GetService(handlerType);
                    if (handler == null) continue;
                    var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                    concreteType.GetMethod("HandleAsync")?.Invoke(handler, new object[] { @event });
                }
            }
        }
        public void Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>
        {
            var eventType = typeof(T);
            var handlerType = typeof(TH);

            if (!_eventTypes.Contains(eventType))
            {
                _eventTypes.Add(eventType);
            }

            if (!_handlers.ContainsKey(eventType))
            {
                _handlers.Add(eventType, new List<Type>());
            }

            if (_handlers[eventType].Any(x => x == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} already registered for '{eventType.Name}'", nameof(handlerType));
            }

            _handlers[eventType].Add(handlerType);
        }
        public void Unsubscribe<T, TH>()
       where TH : IIntegrationEventHandler<T>
       where T : IntegrationEvent
        {
            var eventType = typeof(T);
            var handlerType = typeof(TH);

            if (_handlers.ContainsKey(eventType))
            {
                _handlers[eventType].RemoveAll(x => x == handlerType);
            }
        }
    }
}
