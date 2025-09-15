namespace DoublLinkedList
{
    public class Elemento
    {
        public Elemento(string? nome, int numero)
        {
            GetSetNome = nome;
            GetSetNumero = numero;
            GetSetProximo = null;
            GetSetAnterior = null;
        }

        private string? Nome { get; set; }
        private int Numero { get; set; }
        private Elemento? Proximo { get; set; }
        private Elemento? Anterior { get; set; }

        public string? GetSetNome
        {
            get { return Nome; }
            set { Nome = value; }
        }

        public int GetSetNumero
        {
            get { return Numero; }
            set { Numero = value; }
        }

        public Elemento? GetSetProximo
        {
            get { return Proximo; }
            set { Proximo = value; }
        }

        public Elemento? GetSetAnterior
        {
            get { return Anterior; }
            set { Anterior = value; }
        }

    }
}