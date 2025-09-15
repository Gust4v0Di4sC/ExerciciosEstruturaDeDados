namespace TorreHanoi
{
    public class PilhaHanoi
    {
        private int tamanho { get; set; }

        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        private int repete { get; set; }
        public int Repete
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


        public PilhaHanoi(int tam)
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

        public bool MetadeNumerosMenores()
        {
            int[] menores = new int[Stack.Length];
            int menor = 999;
            int retorno = 0;
            int somaMenores = 0;
            int somaPilha = 0;

            for (int i = 0; i < Stack.Length; i++)
            {
                if (Stack[i] < menor)
                {
                    menor = Stack[i];
                    menores.Append(menor);
                }

            }

            foreach (var itemMenor in menores)
            {
                somaMenores += itemMenor;
                retorno = somaMenores / 2;
            }

            foreach (var itemPilha in Stack)
            {
                somaPilha += itemPilha;
            }

            if (somaPilha == retorno)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool MetadeNumerosMaiores()
        {
            int[] maiores = new int[Stack.Length];
            int maior = 0;
            int retorno = 0;
            int somaMaiores = 0;
            int somaPilha = 0;

            for (int i = 0; i < Stack.Length; i++)
            {
                if (Stack[i] > maior)
                {
                    maior = Stack[i];
                    maiores.Append(maior);
                }

            }

            foreach (var itemMaior in maiores)
            {
                somaMaiores += itemMaior;
                retorno = somaMaiores / 2;
            }

            foreach (var itemPilha in Stack)
            {
                somaPilha += itemPilha;
            }

            if (somaPilha == retorno)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Push(int valor)
        {
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


        public int Pop()
        {
            if (Empty())
            {
                return 0;
            }
            Retorno = Stack[Topo];
            Topo--;
            return Retorno;
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



        public int SearchElement(int element)
        {

            int searchEl = 0;

            for (int index = 0; index < Stack.Length; index++)
            {
                if (Stack[index] == element)
                {
                    searchEl = index;
                }
            }

            return searchEl;

        }


        //Le uma posição da pilha
        public int Read(int indice)
        {
            if (indice > topo)
            {
                return -1;
            }
            return pilha[indice];
        }

    }
}