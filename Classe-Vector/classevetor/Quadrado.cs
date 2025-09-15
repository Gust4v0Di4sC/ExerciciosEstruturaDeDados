namespace classeVetor
{
    public class Quadrado
    {
        public Quadrado(float lado)
        {
            this.lado = lado;
        }

        private float lado { get; set; }

        public float Lado
        {
            get { return lado; }
            set { lado = value; }
        }

        public double Perimetro()
        {
            return 2 * this.lado;
        }

        public double Area()
        {
            return Math.Pow(this.lado, 2);
        }

        public double Diagonal()
        {
            return Math.Sqrt(2 * Math.Pow(this.lado, 2));
        }

        // SOBRESCREVA ESTES DOIS MÉTODOS PARA COMPARAÇÃO POR VALOR!
        public override bool Equals(object? obj)
        {
            // 1. Verifica se o objeto é nulo ou de um tipo diferente
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            // 2. Converte para o tipo Quadrado
            Quadrado outro = (Quadrado)obj;

            // 3. Compara os atributos que definem a igualdade (neste caso, o lado)
            return Lado == outro.Lado;
        }

        public override int GetHashCode()
        {
            // Ao sobrescrever Equals, você DEVE sobrescrever GetHashCode.
            // O hash code deve ser consistente com Equals. Se Equals retorna true para dois objetos,
            // GetHashCode deve retornar o mesmo valor para ambos.
            return Lado.GetHashCode(); // Usa o hash code do 'Lado'
        }
    }
}