using System.Collections;

namespace StackLib
{
    // Maxime Normandin
    public class LinkedListStack<T> : IStack<T>
    {
        private Noeud<T>? _racine = null;

        private int _compteur = 0;

        public LinkedListStack() {

        }

        public bool IsEmpty => _compteur == 0;

        public int Count => _compteur;

        public T Peek()
        {
            if(IsEmpty)
            {
                throw new InvalidOperationException("Pile vide");
            }

            return _racine!.Item;
        }

        public T Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Pile vide");
            }

            var noeud = _racine;
            _racine = _racine!.Suivant;
            _compteur--;
            return noeud!.Item;
        }

        public void Push(T item)
        {
            _racine = new Noeud<T>(item, _racine);
            _compteur++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            var copie = _racine;
            while (copie != null)
            {
                T valeur = copie.Item;
                copie = copie.Suivant;
                yield return valeur;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var copie = _racine;
            while (copie != null)
            {
                T valeur = copie.Item;
                copie = copie.Suivant;
                yield return valeur;
            }
        }
    }

    // Maxime Normandin
    class Noeud<T>
    {
        public T Item;
        public Noeud<T>? Suivant;

        public Noeud(T item, Noeud<T>? suivant = null)
        {
            Item = item;
            Suivant = suivant;
        }
    }
}
