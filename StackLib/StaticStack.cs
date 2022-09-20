using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLib;

public class StaticStack<T> : IStaticStack<T>
{
    private T[] array;

    public int Capacity { get; init; }

    public StaticStack(int capacity)
    {
        this.Capacity = capacity;
        this.array = new T[capacity];
    }

    public bool IsFull => throw new NotImplementedException();

    public bool IsEmpty => throw new NotImplementedException();

    public int Count => throw new NotImplementedException();

    public IEnumerator<T> GetEnumerator()
    {
        throw new NotImplementedException();
    }

    public T Peek()
    {
        throw new NotImplementedException();
    }

    public T Pop()
    {
        throw new NotImplementedException();
    }

    public void Push(T item)
    {
        throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        throw new NotImplementedException();
    }
}
