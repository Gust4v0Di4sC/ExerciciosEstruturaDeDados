using System.Security.Cryptography;

namespace LinkList
{
    public class ListaLigada
    {
        private Elemento? inicio;

        public bool Enqueue(Elemento? e)
        {
            try
            {
                if (IsEmpty())
                {
                    inicio = e;
                }
                else
                {
                    Elemento? fim = GetFim();
                    if (fim != null)
                    {
                        fim.Proximo = e;
                    }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public bool EnqueueOnPosition(Elemento? novoElemento, int pos)
        {
            if (pos < 0)
            {
                return false;
            }

            try
            {
                if (IsEmpty())
                {
                    inicio = novoElemento;
                    return true;
                }

                if (pos == 1)
                {
                    novoElemento.Proximo = inicio;
                    inicio = novoElemento;
                    return true;
                }

                Elemento? current = inicio;
                int counter = 1;
                while (current != null && counter < pos - 1)
                {
                    current = current.Proximo;
                    counter++;
                }

                if (current == null)
                {
                    return false;
                }

                novoElemento.Proximo = current.Proximo;
                current.Proximo = novoElemento;

                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
            
            
        }

        public Elemento? Dequeue()
        {
            if (inicio == null)
            {
                return null;
            }

            Elemento? e = inicio;
            inicio = e.Proximo;
            e.Proximo = null;
            return e;
        }

        public Elemento? DequeueOnPosition(int position)
        {
            Elemento? current = inicio;

            if (position < 0)
            {
                return null;
            }

            if (inicio == null)
            {
                return null;
            }

            try
            {
                if (IsEmpty())
                {
                    return null;
                }

                
                int counter = 1;

                while (current != null && counter < position - 1)
                {
                    current = current.Proximo;
                    counter++;
                }

                if (position == 1)
                {
                    inicio = current.Proximo;
                    current.Proximo = null;
                    return current;
                }

                if (current == null)
                {
                    return null;
                }
            }
            catch (System.Exception)
            {

                throw;
            }

            current.Proximo = inicio;
            current.Proximo = null;
            return current;
        }

        public bool SearchElement(int numero)
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
                return false;
            }
            else
            {
                Elemento? current = inicio;


                while (current.Proximo != null)
                {
                    current = current.Proximo;
                    if (current.Numero == numero)
                    {
                        Console.WriteLine($"Elemento encontrado!!");
                        Console.WriteLine($"Nome: {current.Nome}");
                        Console.WriteLine($"Numero: {current.Numero}");
                    }
                    else
                    {
                        Console.WriteLine("Elemento não encontrado");
                    }
                }

                return true;
            }
        }

        public Elemento? GetInicio()
        {
            return inicio;
        }

        public Elemento? GetFim()
        {
            if (IsEmpty())
            {
                return inicio;
            }
            Elemento? e = inicio;
            while (e.Proximo != null)
            {
                e = e.Proximo;
            }
            return e;
        }

        public bool IsEmpty()
        {
            return inicio == null;
        }
    }
    
}