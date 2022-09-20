using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLib;

public interface IStack<T> : IReadOnlyCollection<T>
{
    bool IsEmpty { get; }

    void Push(T item);

    T Pop();

    T Peek();
}
