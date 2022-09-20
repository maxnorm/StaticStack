
namespace StackLib;

// Par Maxime Normandin
public interface IStaticStack<T> : IStack<T>
{
    int Capacity { get; }

    bool IsFull { get; }
}

