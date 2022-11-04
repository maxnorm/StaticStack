using System.Collections;

namespace StackLib;

// Par Maxime Normandin
public class StaticStack<T> : IStaticStack<T>
{
    private readonly T[] _array;

    private int _top = -1;

    public int Capacity { get; init; }

    public StaticStack(int capacity)
    {
        if (capacity < 1)
            throw new ArgumentException("La capacité doit être minimalement de 1");

        Capacity = capacity;
        _array = new T[capacity];
    }

    public bool IsFull => _top == Capacity - 1;

    public bool IsEmpty => _top == -1;

    public int Count => _top + 1;

    public IEnumerator<T> GetEnumerator() => _array.AsEnumerable().GetEnumerator();

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Pile vide");

        return _array[_top];
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Pile vide");

        int ancienTop = _top;
        --_top;
        return _array[ancienTop];
    }

    public void Push(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("Pile pleine");
        ++_top;
        _array[_top] = item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
