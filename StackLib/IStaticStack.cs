using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLib;

public interface IStaticStack<T> : IStack<T>
{
    int Capacity { get; init; }

    bool IsFull { get; }
}

