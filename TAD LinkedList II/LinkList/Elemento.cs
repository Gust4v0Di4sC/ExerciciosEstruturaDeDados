namespace LinkList
{
    public class Elemento
    {
        public Elemento(string? nome, int numero)
        {
            Nome = nome;
            Numero = numero;
            proximo = null;
        }

        private string? nome { get; set; }

        public string? Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        private int numero { get; set; }

        public int Numero
        {
            get { return numero; }
            set { numero = value; }
        }
        private Elemento? proximo { get; set; }
        public Elemento? Proximo
        {
            get { return proximo; }
            set { proximo = value; }
        }
        
    }
}