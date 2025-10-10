namespace doublelinkedcircleexercise
{
    public class ListaDuplamenteLigadaCirc
    {
        private Elemento Inicio;
        private int Qtd;

        public void ImprimeElemento(Elemento elementoImpresso)
        {
            Console.WriteLine(elementoImpresso.GetSetId);
        }

        private void AutoConex(Elemento elementoConectado)
        {
            elementoConectado.GetSetProximo = elementoConectado;
            elementoConectado.GetSetAnterior = elementoConectado;
        }

        private bool InsereEmVazio(Elemento elementoInserido)
        {
            if (Qtd > 0)
            {
                return false;
            }
            Inicio = elementoInserido;
            return true;
        }

        private Elemento RemoveUnico()
        {
            if (IsEmpty() || Qtd > 1)
            {
                return null;
            }
            Elemento elementoRemovido = Inicio;
            Inicio = null;
            Qtd = 0;
            return elementoRemovido;
        }

        public void InsereInicio(Elemento elementoInserido)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInserido);
            }
            else
            {
                elementoInserido.GetSetProximo = Inicio;
                elementoInserido.GetSetAnterior = Inicio.GetSetAnterior;
                Inicio.GetSetAnterior = elementoInserido;
                Elemento proximoElem = elementoInserido.GetSetProximo = elementoInserido;
                elementoInserido.GetSetAnterior = proximoElem;
                Inicio = elementoInserido;
            }
            Qtd++;
        }

        public void InsereUltimo(Elemento elementoInserido)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInserido);
            }
            else
            {
                elementoInserido.GetSetProximo = Inicio;
                elementoInserido.GetSetAnterior = Inicio.GetSetAnterior;
                Elemento proximoElem = elementoInserido.GetSetProximo = elementoInserido;
                Inicio.GetSetAnterior = proximoElem;
                Inicio.GetSetAnterior = elementoInserido;
            }
            Qtd++;
        }

        public Elemento RemoveInicio()
        {
            if (IsEmpty())
            {
                return null;
            }
            if (Qtd == 1)
            {
                return RemoveUnico();
            }
            Elemento elementoRemovido = Inicio;
            Elemento anteriorElem = Inicio.GetSetAnterior;
            anteriorElem = Inicio.GetSetProximo = Inicio.GetSetProximo;
            Elemento proxElem = Inicio.GetSetProximo;
            proxElem = Inicio.GetSetAnterior = Inicio.GetSetAnterior;
            Inicio = Inicio.GetSetProximo;
            elementoRemovido.GetSetProximo = elementoRemovido;
            elementoRemovido.GetSetAnterior = elementoRemovido;
            Qtd--;
            return elementoRemovido;
        }

        public Elemento RemoveFim()
        {
            if (IsEmpty())
            {
                return null;
            }
            if (Qtd == 1)
            {
                return RemoveUnico();
            }
            Elemento elementoRemovido = Inicio.GetSetAnterior;
            Inicio.GetSetAnterior = elementoRemovido.GetSetAnterior;
            elementoRemovido.GetSetAnterior = elementoRemovido.GetSetProximo = Inicio;
            elementoRemovido.GetSetProximo = elementoRemovido;
            elementoRemovido.GetSetAnterior = elementoRemovido;
            Qtd--;
            return elementoRemovido;
        }

        public Elemento GetPosHorario(Elemento elementoBuscado, int posicaoBuscada)
        {
            if (posicaoBuscada > Qtd || posicaoBuscada <= 0)
            {
                return null;
            }
            int posAtual = 1;
            Elemento elementoAuxiliar = elementoBuscado;
            while (posAtual < posicaoBuscada)
            {
                elementoAuxiliar = elementoAuxiliar.GetSetProximo;
                posAtual++;
            }
            return elementoAuxiliar;
        }

        public Elemento GetPosAntiHorario(Elemento elementoBuscado, int posicaoBuscada)
        {
            if (posicaoBuscada > Qtd || posicaoBuscada <= 0)
            {
                return null;
            }
            int posAtual = 1;
            Elemento elementoAuxiliar = elementoBuscado;
            while (posAtual < posicaoBuscada)
            {
                elementoAuxiliar = elementoAuxiliar.GetSetAnterior;
                posAtual++;
            }
            return elementoAuxiliar;
        }

        public bool RemoveElemento(Elemento elementoRemovido)
        {
            if (IsEmpty() & elementoRemovido == null)
            {
                return false;
            }
            if (Qtd == 1)
            {
                RemoveUnico();
            }
            else
            {
                if (elementoRemovido == Inicio)
                {
                    Inicio = elementoRemovido.GetSetProximo;
                }

                Elemento antElem = elementoRemovido.GetSetAnterior;
                antElem.GetSetProximo = elementoRemovido.GetSetProximo;

                Elemento proxElem = elementoRemovido.GetSetProximo;
                proxElem.GetSetAnterior = elementoRemovido.GetSetAnterior;

                AutoConex(elementoRemovido);

                Qtd--;
            }
            return true;
        }

        public bool InsereHorario(Elemento elementoNovo, Elemento elementoAtual)
        {
            if (elementoNovo == null)
            {
                return false;
            }
            if (Qtd <= 1 || elementoAtual == Inicio)
            {
                InsereInicio(elementoNovo);
            }
            else if (elementoAtual == Inicio.GetSetAnterior)
            {
                InsereUltimo(elementoNovo);
            }
            else
            {
                elementoNovo.GetSetProximo = elementoAtual;
                elementoNovo.GetSetAnterior = elementoAtual.GetSetAnterior;
                Elemento proxElem = elementoAtual.GetSetAnterior;
                proxElem.GetSetProximo = elementoNovo;
                elementoAtual.GetSetAnterior = elementoNovo;
                Qtd++;
            }
            return true;
        }

        public bool InsereAntiHorario(Elemento elementoNovo, Elemento elementoAtual)
        {
            if (elementoNovo == null)
            {
                return false;
            }
            if (IsEmpty())
            {
                InsereInicio(elementoNovo);
            }
            else
            {
                elementoNovo.GetSetProximo = elementoAtual.GetSetProximo;
                elementoNovo.GetSetAnterior = elementoAtual;
                Elemento antElem = elementoAtual.GetSetProximo;
                antElem.GetSetAnterior = elementoNovo;
                elementoAtual.GetSetProximo = elementoNovo;
                if (elementoAtual == Inicio)
                {
                    Inicio = elementoNovo;
                }
                Qtd++;
            }
            return true;
        }
    }
}