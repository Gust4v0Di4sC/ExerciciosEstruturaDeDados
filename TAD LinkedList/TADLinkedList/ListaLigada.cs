namespace TADLinkedList
{
    public class ListaLigada
    {
        private Elemento? inicio;

        public bool Push(Elemento e)
        {
            try
            {
                e.Proximo = inicio;
                inicio = e;
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool IsEmpty()
        {
            return inicio == null;
        }

        public Elemento? GetInicio()
        {
            return inicio;
        }

        public Elemento? Pop()
        {
            if (inicio == null)
            {
                return null;
            }

            Elemento e = inicio;
            inicio = e.Proximo;
            e.Proximo = null;
            return e;

        }
    }
}