using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackLib
{
    public class LinkedListStack<T> : IStack<T>
    {
        private Noeud<T>? _racine = null;

        private int _compteur = 0;

        public LinkedListStack() {

        }

        public bool IsEmpty => _compteur == 0;

        public int Count => _compteur;

        public IEnumerator<T> GetEnumerator()
        {
            while (_racine != null)
            {
                T valeur = _racine.Item;
                _racine = _racine.Suivant;
                yield return valeur;
            }
        }

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
            _compteur++;
            return noeud!.Item;
        }

        public void Push(T item)
        {
            _racine = new Noeud<T>(item, _racine);
            _compteur++;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            while(_racine != null)
            {
                T valeur = _racine.Item;
                _racine = _racine.Suivant;
                yield return valeur;
            }
        }

        class Noeud<Y>
        {
            public Y Item;
            public Noeud<Y>? Suivant;
            
            public Noeud(Y item, Noeud<Y>? suivant = null)
            {
                Item = item;
                Suivant = suivant;
            }
        }
    }
}
