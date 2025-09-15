namespace TADFila
{
    public class TadFilaEx1 : Fila
    {
        public TadFilaEx1(int tam) : base(tam)
        {

        }

        public string Search(int numero)
        {
            //pegar a posicao
            int pos = 0;
            //indica se o local foi encontrado
            bool loc = false;

            if (IsEmpty())
            {
                return "A fila esta vazia";
            }

            //Caso em que o inicio vem antes do fim

            else if (initial < final)
            {
                for (int i = initial; i < final; i++)
                {
                    pos++;
                    if (fila[i] == numero)
                    {
                        loc = true;
                        break;
                    }
                }
            }


            //Caso em que a fila esta cheia ou inicio vem depois do fim
            else if (IsFull() || initial > final)
            {
                for (int i = initial; i < capacity; i++)
                {
                    pos++;
                    if (fila[i] == numero)
                    {
                        loc = true;
                        break;
                    }
                }
                if (!loc && initial > 0)
                {
                    for (int i = 0; i < final; i++)
                    {
                        pos++;
                        if (fila[i] == numero)
                        {
                            loc = true;
                            break;
                        }
                    }

                }

            }


            if (loc)
            {
                return $"O elemento {numero} esta na posicao {pos} da fila";
            }
            else
            {
                return $"O elemento {numero} nao se encontra na fila.";
            }
        }
    }
}