namespace PilhaTAD
{
    public class Pilha
    {
        private int tamanho { get; set; }

        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        private bool repete { get; set; }
        public bool Repete
        {
            get { return repete; }
            set { repete = value; }
        }

        private int topo { get; set; }
        public int Topo
        {
            get { return topo; }
            set { topo = value; }
        }


        private int retorno { get; set; }

        public int Retorno
        {
            get { return retorno; }
            set { retorno = value; }
        }


        private int[] pilha { get; set; }

        public int[] Stack
        {
            get { return pilha; }
            set { pilha = value; }
        }


        public Pilha(int tam)
        {
            tamanho = tam;
            topo = -1;
            pilha = new int[tam];
        }

        public int GetRetorno()
        {
            return retorno;
        }

        public bool Full()
        {
            return Topo == Tamanho - 1;
        }

        public int Qtd()
        {
            return Topo + 1;
        }

        public bool Empty()
        {
            return Qtd() == 0;
        }

        public bool Push(int valor)
        {
            Console.WriteLine("Permitir repetição?? 1-sim 2-nao");
            int respostaInput = Convert.ToInt32(Console.ReadLine());

            if (respostaInput == 1)
            {
                repete = true;

                if (!Full())
                {
                    Topo += 1;
                    Stack[Topo] = valor;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                repete = false;
                
                int elemento = 0;
                for (int i = 0; i < Stack.Length; i++)
                {
                    if (valor == Stack[i])
                    {
                        elemento = Stack[i];
                    }
                }

                if (elemento == valor)
                {
                    Console.WriteLine("Falha valor inserido já existe");
                    return false;
                }
                else
                {
                    Console.WriteLine("Valor ainda não inserido, sucesso!");
                    return true;
                }
                
                
            }
            
        }


        public bool Pop()
        {
            if (Empty())
            {
                return false;
            }
            Retorno = Stack[Topo];
            Topo--;
            return true;
        }


        public string Print()
        {
            string ret;
            if (Empty())
            {
                return "A pilha está vazia";
            }

            ret = "A pilha tem " + Qtd() + " elementos. \n";
            for (int i = 0; i <= Topo; i++)
            {
                ret += Stack[i] + " ";
            }

            return ret;
        }

        public string QtdElementos()
        {
            string ret;
            if (!Empty())
            {
                ret = "A pilha tem " + Qtd() + " elementos.";
                return ret;
            }
            else
            {
                return "A pilha está vazia";
            }
        }

        public int PositionTop()
        {
            int posTop = 0;
            for (int i = 0; i <= Stack.Length; i++)
            {
                if (i == Stack.Length - 1)
                {
                    posTop = i;
                }
            }

            return posTop;
        }

       

        public int[] SearchElement(int element, int nPrimeiros)
        {
            int[] res = new int[tamanho];
            if (this.Empty())
            {
                res[0] = 0;
            }
            else
            {
                if (!Repete)
                {
                    nPrimeiros = 1;
                }

                for (int i = 0; i <= topo; i++) {  // basta procurar ate' o topo
                if (pilha[i] == element) {
                    res[0]++;
                    res[res[0]] = i;
                    if (res[0] == nPrimeiros) {
                        break;
                    }
                }
            }
            }
            return res;

        }

    }
}