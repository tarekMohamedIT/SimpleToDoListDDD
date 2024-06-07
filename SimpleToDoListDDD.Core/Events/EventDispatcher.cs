using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Core.Events
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly Dictionary<Type, List<object>> _handlers = [];

        public void RegisterHandler<TEvent>(IEventHandler<TEvent> handler)
        {
            var eventType = typeof(TEvent);
            if (!_handlers.TryGetValue(eventType, out List<object>? value))
            {
                value = [];
                _handlers[eventType] = value;
            }

            value.Add(handler);
        }

        public Result Dispatch<TEvent>(TEvent eventToDispatch)
        {
            var eventType = typeof(TEvent);
            if (!_handlers.TryGetValue(eventType, out List<object>? value))
            {
                return Result.Failure($"No handlers registered for event type {eventType.Name}");
            }

            foreach (var handler in value.Cast<IEventHandler<TEvent>>())
            {
                var result = handler.Handle(eventToDispatch);

                if (!result.IsSuccess) return result;
            }

            return Result.Success();
        }
    }
}
