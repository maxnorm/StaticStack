
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

    var pileArray = pileStatic.ToArray();

    for (int i = 0; i < pileStatic.Count; i++)
        stringBPile.Append((i > 0 ? ", " : " ") + pileArray[i]);

    
    WriteLine(stringBPile.ToString());

    string entree = "";
    while(entree == "")
    {
        Write("MN> ");
        entree = ReadLine();
    }

    if (entree == "exit")
        break;

    string commande = entree.Split(" ")[0];
    string item = entree.Substring(commande.Length);

    switch (commande)
    {
        case "push":
            try 
            {
                if (item == "")
                    WriteLine("    Erreur: Pousser quoi ???");
                else
                    pileStatic.Push(item); 
            }
            catch(InvalidOperationException ex) 
            { 
                WriteLine("    " + ex.GetType().Name + ": " + ex.Message); 
            }
            break;

        case "pop":
            try 
            { 
                WriteLine("   " + pileStatic.Pop()); 
            }
            catch (InvalidOperationException ex) 
            { 
                WriteLine("    " + ex.GetType().Name + ": " + ex.Message); 
            }
            break;

        case "peek":
            try {
                WriteLine("   " + pileStatic.Peek()); 
            }
            catch (InvalidOperationException ex) 
            { 
                WriteLine("    " + ex.GetType().Name + ": " + ex.Message); 
            }
            break;

        default:
            WriteLine("    Commande invalide: " + commande);
            break;
    }
    WriteLine();
}
WriteLine("Au revoir!");