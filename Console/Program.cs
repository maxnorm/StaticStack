
using StackLib;
using System.Text;
using static System.Console;

var pileStatic = new StaticStack<string>(3);

while (true)
{
    StringBuilder stringBPile = new StringBuilder();
    stringBPile.Append("Pile ")
               .Append(pileStatic.Count)
               .Append("/")
               .Append(pileStatic.Capacity)
               .Append(":");

    foreach (var elem in pileStatic)
        stringBPile.Append(" " + elem);

    
    WriteLine(stringBPile.ToString());

    string entre = "";
    while(entre == "")
    {
        Write("MN> ");
        entre = Console.ReadLine();
    }

    if (entre == "exit")
        break;
}
WriteLine("Au revoir");