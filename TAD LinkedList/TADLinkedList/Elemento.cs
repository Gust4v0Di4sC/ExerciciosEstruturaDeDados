namespace TADLinkedList
{
    public class Elemento
    {
        public Elemento(string? nome , int numero)
        {
            Nome = nome;
            Numero = numero;
            proximo = null;
        }

        private string? nome { get; set; }
        private int numero { get; set; }
        private Elemento? proximo { get; set; }

        public string? Nome {
            get { return nome; }
            set { nome = value; }
        }
        
        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Elemento? Proximo
        {
            get { return proximo; }
            set { proximo = value; }
        }
    }
}