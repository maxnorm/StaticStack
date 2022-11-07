using StackLib;
using System.Text;
using static System.Console;

var linkedListStack = new LinkedListStack<string>();

while (true)
{
    StringBuilder stringBPile = new StringBuilder();
    stringBPile.Append("Pile LL ")
               .Append(linkedListStack.Count)
               .Append(":");

    int compteur = 0;
    foreach (var elem in linkedListStack)
    {
        stringBPile.Append((compteur > 0 ? ", " : " ") + elem);
        compteur++;
    }


    WriteLine(stringBPile.ToString());

    string entree = "";
    while (entree == "")
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
                    linkedListStack.Push(item);
            }
            catch (InvalidOperationException ex)
            {
                WriteLine("    " + ex.GetType().Name + ": " + ex.Message);
            }
            break;

        case "pop":
            try
            {
                WriteLine("   " + linkedListStack.Pop());
            }
            catch (InvalidOperationException ex)
            {
                WriteLine("    " + ex.GetType().Name + ": " + ex.Message);
            }
            break;

        case "peek":
            try
            {
                WriteLine("   " +linkedListStack.Peek());
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
