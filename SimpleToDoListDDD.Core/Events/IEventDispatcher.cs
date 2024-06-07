using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Core.Events
{
    public interface IEventDispatcher
    {
        void RegisterHandler<TEvent>(IEventHandler<TEvent> handler);
        Result Dispatch<TEvent>(TEvent dispatchedEvent);
    }
}
