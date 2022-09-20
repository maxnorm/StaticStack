using System.Collections;

namespace StackLib;

// Par Maxime Normandin
public class StaticStack<T> : IStaticStack<T>
{
    private T[] array;

    private int top = -1;

    public int Capacity { get; init; }

    public StaticStack(int capacity)
    {
        if (capacity < 1)
            throw new ArgumentException("La capacité doit être minimalement de 1");

        Capacity = capacity;
        array = new T[capacity];
    }

    public bool IsFull => top == Capacity - 1;

    public bool IsEmpty => top == -1;

    public int Count => top + 1;

    public IEnumerator<T> GetEnumerator() => array.AsEnumerable().GetEnumerator();

    public T Peek()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Pile vide");

        return array[top];
    }

    public T Pop()
    {
        if (IsEmpty)
            throw new InvalidOperationException("Pile vide");

        int ancienTop = top;
        --top;
        return array[ancienTop];
    }

    public void Push(T item)
    {
        if (IsFull)
            throw new InvalidOperationException("Pile pleine");
        ++top;
        array[top] = item;
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
