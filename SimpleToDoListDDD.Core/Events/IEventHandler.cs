using SimpleToDoListDDD.Core.Results;

namespace SimpleToDoListDDD.Core.Events
{
    public interface IEventHandler<TEvent>
    {
        Result Handle(TEvent eventData);
    }
}