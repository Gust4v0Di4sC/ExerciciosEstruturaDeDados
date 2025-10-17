namespace doublelinkedcircleexercise
{
    public class Jogador
    {
        public Jogador(int numero, string nome)
        {
            Numero = numero;
            Nome = nome;
            Casa = null;
            PerdeAvez = 0;
        }

        private int Numero;
        private String Nome;
        private Elemento? Casa;
        private int PerdeAvez;


        public int GetSetNumero
        {
            get { return Numero; }
            set { Numero = value; }
        }

        public string GetSetNome
        {
            get { return Nome; }
            set { Nome = value; }
        }

        public Elemento? GetSetCasa
        {
            get { return Casa; }
            set { Casa = value; }
        }

        public int GetSetPerdeAvez
        {
            get { return PerdeAvez; }
            set { PerdeAvez = value; }
        }
    }
}