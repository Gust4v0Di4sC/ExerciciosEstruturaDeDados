namespace TADFila
{
    public class Fila
    {
        public Fila(int tam)
        {
            this.initial = 0;
            this.final = 0;
            this.ope = 0;
            this.capacity = tam;
            fila = new int[tam];
        }

        public int initial;
        public int final;
        public int ope;
        public int capacity;
        public int[] fila;

        public bool IsEmpty()
        {
            return initial == final && ope <= 0;
        }

        public bool IsFull()
        {
            return initial == final && ope == 1;
        }

        public int Peek()
        {
            if (this.IsEmpty())
            {
                return 0;
            }
            return fila[initial];
        }

        public string Enqueue(int elem)
        {
            if (this.IsFull())
            {
                return "ERRO : A Fila está cheia";
            }

            fila[final] = elem;
            final = (final + 1) % capacity;  
            ope = 1;
            return "Elemento inserido com sucesso";
        }

        public int Dequeue()
        {
            if (this.IsEmpty())
            {
                return 0;
            }

            int elem = Peek();
            initial = (initial + 1) % capacity;
            ope = -1;
            return elem;
        }

        public int Size()
        {
            int s = 0;
            if (initial < final)
            {
                s = final - initial;
            }
            else if (initial == final)
            {
                if (IsEmpty())
                {
                    s = 0;
                }
                else
                {
                    s = capacity;
                }
            }
            else if (initial > final)
            {
                s = capacity - initial + final;
            }

            return s;
        }

        public int SearchElement(int elem)
        {

            if (IsEmpty())
            {
                return -1;
            }

            int current = initial;
            int count = 0;

            while (count < final)
            {
                if (fila[current] == elem)
                {
                    return current;
                }

                current = (current + 1) % capacity;
                count++;
            }

            return -1;
        }

        public string Print()
        {
            string ret = "";

            if (IsEmpty())
            {
                ret = "A Fila está vazia";
            }
            else if (initial < final)
            {
                for (int i = initial; i < final; i++)
                {
                    ret += fila[i] + " ";
                }
            }
            else if (IsFull() || initial > final)
            {
                for (int i = initial; i < capacity; i++)
                {
                    ret += fila[i] + " ";
                }
                if (initial > 0)
                {
                    for (int i = 0; i < final; i++)
                    {
                        ret += fila[i] + " ";
                    }
                }
            }

            return ret;
        }

    }
}