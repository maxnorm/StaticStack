
namespace StackLib;

// Par Maxime Normandin
public interface IStack<T> : IReadOnlyCollection<T>
{
    bool IsEmpty { get; }

    void Push(T item);

    T Pop();

    T Peek();
}
