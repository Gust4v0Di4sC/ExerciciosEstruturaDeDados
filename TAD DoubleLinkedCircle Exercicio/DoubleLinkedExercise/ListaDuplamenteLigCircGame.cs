namespace doublelinkedcircleexercise
{
    public class ListaDoubleLinkCircGame : ListaDuplamenteLigadaCirc
    {
        public void ImprimeElemento(Elemento elementoImpresso)
        {
            int pos = elementoImpresso.GetSetPosicao;
            string stuff = "";
            if (pos < 10)
            {
                stuff = " ";
            }
            Console.Write($"{stuff} : {elementoImpresso.GetSetPosicao} | ");
            int status = elementoImpresso.GetSetStatus;
            switch (status)
            {
                case 0:
                    Console.WriteLine("---");
                    break;
                case 1:
                    Console.WriteLine("* " + elementoImpresso.GetSetJogador);
                    break;
                case 2:
                    Console.WriteLine("**" + elementoImpresso.GetSetJogador);
                    break;
                default:
                    break;
            }
        }

        private void Renumera()
        {
            if (IsEmpty())
            {
                return;
            }
            Elemento elementoRenumerado = GetInicio();
            for (int pos = 0; pos < GetQtd(); pos++)
            {
                elementoRenumerado.GetSetPosicao = pos;
                elementoRenumerado = elementoRenumerado.GetSetProximo;
            }
        }

        public override void InsereInicio(Elemento? elementoInserido)
        {
            base.InsereInicio(elementoInserido);
            Renumera();
        }

        public override void InsereUltimo(Elemento? elementoInserido)
        {
            base.InsereUltimo(elementoInserido);
            elementoInserido.GetSetPosicao = GetQtd();
        }

        public override bool InsereHorario(Elemento elementoNovo, Elemento elementoAtual)
        {
            base.InsereHorario(elementoNovo, elementoAtual);
            Renumera();
            return true;
        }

        public override Elemento RemoveInicio()
        {
            Elemento elementoRemovido = base.RemoveInicio();
            Renumera();
            return elementoRemovido;
        }

        public override bool RemoveElemento(Elemento elementoRemovido)
        {
            if (base.RemoveElemento(elementoRemovido))
            {
                Renumera();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ImprimeHorario(Jogador j1, Jogador j2, Jogador j3, Jogador j4)
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
            }
            else
            {
                Elemento elementoImpresso = GetInicio();
                int posAtual = 1;
                while (posAtual <= GetQtd())
                {
                    ImprimeElemento(elementoImpresso);
                    Console.WriteLine(" |");
                    if (j1.GetSetCasa == elementoImpresso)
                    {
                        Console.WriteLine(" 1");
                    }
                    if (j2.GetSetCasa == elementoImpresso)
                    {
                        Console.WriteLine(" 2");
                    }
                    if (j3 != null && j3.GetSetCasa == elementoImpresso)
                    {
                        Console.WriteLine(" 3");
                    }
                    if (j4 != null && j4.GetSetCasa == elementoImpresso)
                    {
                        Console.WriteLine(" 4");
                    }

                    Console.WriteLine("");
                    elementoImpresso = elementoImpresso.GetSetProximo;
                    posAtual++;
                }
            }
        }
        
        public  override void ImprimeAntiHorario()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
            }
            else
            {
                Elemento elementoImpresso = GetInicio();
                int posAtual = 1;
                while (posAtual <= GetQtd())
                {
                    ImprimeElemento(elementoImpresso);
                    elementoImpresso = elementoImpresso.GetSetAnterior;
                    posAtual++;
                }
            }
        }
    }
}