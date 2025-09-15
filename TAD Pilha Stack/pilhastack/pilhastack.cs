namespace pilhastack
{
    public class Triangulo
    {
        public Triangulo() { }
        public Triangulo(float lado1, float lado2, float lado3)
        {
            this.lado1 = lado1;
            this.lado2 = lado2;
            this.lado3 = lado3;
        }

        private float lado1 { get; set; }
        private float lado2 { get; set; }
        private float lado3 { get; set; }

        public float Lado1
        {
            get { return lado1; }
            set { lado1 = value; }
        }

        public float Lado2
        {
            get { return lado2; }
            set { lado2 = value; }
        }

        public float Lado3
        {
            get { return lado3; }
            set { lado3 = value; }
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = hash * 23 + lado1.GetHashCode();
            hash = hash * 23 + lado2.GetHashCode();
            hash = hash * 23 + lado3.GetHashCode();

            return hash;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (this.GetType() != obj.GetType())
            {
                return false;
            }

            Triangulo other = (Triangulo)obj;
            if (this.lado1 != other.lado1)
            {
                return false;
            }
            if (this.lado2 != other.lado2)
            {
                return false;
            }
            if (this.lado3 != other.lado3)
            {
                return false;
            }
            return true;
        }

        public bool TrianguloValido()
        {
            if (lado1 <= 0 || lado2 <= 0 || lado3 <= 0)
            {
                return false;
            }
            else if (lado1 < lado2 + lado3 && lado2 < lado1 + lado3 && lado3 < lado1 + lado2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public float Perimetro()
        {
            if (!TrianguloValido())
            {
                return 0f;
            }
            return lado1 + lado2 + lado3;
        }


        public float Area()
        {
            if (!TrianguloValido())
            {
                return 0f;
            }

            float semiPerimetro = Perimetro() / 2;
            return (float)Math.Sqrt(semiPerimetro * (semiPerimetro - lado1) * (semiPerimetro - lado2) * (semiPerimetro - lado3));
        }


        


    }
}