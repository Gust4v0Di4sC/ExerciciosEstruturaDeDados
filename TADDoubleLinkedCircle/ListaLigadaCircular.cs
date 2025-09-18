namespace taddoublelinkedlistcirc
{
    public class ListaLigadaCircular
    {
        private Elemento? Inicio;
        private int Qtd;

        public void ImprimeElemento(Elemento? elementoImpresso)
        {
            Console.WriteLine(elementoImpresso.GetSetId);
        }

        private void AutoConex(Elemento? elementoAutoConectado)
        {
            elementoAutoConectado.GetSetProximo = elementoAutoConectado;
            elementoAutoConectado.GetSetAnterior = elementoAutoConectado;
        }

        private bool InsereEmVazio(Elemento? elementoInserido)
        {
            if (Qtd > 0)
            {
                return false;
            }

            Inicio = elementoInserido;
            return true;
        }

        private Elemento? RemoveUnico()
        {
            if (IsEmpty() || Qtd > 1)
            {
                return null;
            }

            Elemento? elementoRemovido = Inicio;
            Inicio = null;
            Qtd = 0;
            return elementoRemovido;
        }

        public void InsereInicio(Elemento? elementoInserido)
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
                elementoInserido.GetSetAnterior = elementoInserido.GetSetProximo;
                Inicio = elementoInserido;
            }
            Qtd++;
        }

        public void InsereUltimo(Elemento? elementoInserido)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInserido);
            }
            else
            {
                elementoInserido.GetSetProximo = Inicio;
                elementoInserido.GetSetAnterior = Inicio.GetSetAnterior;
                Inicio.GetSetAnterior = elementoInserido.GetSetProximo;
                Inicio.GetSetAnterior = elementoInserido;
            }
            Qtd++;
        }

        public Elemento? RemoveInicio()
        {
            if (IsEmpty())
            {
                return null;
            }

            if (Qtd == 1)
            {
                return RemoveUnico();
            }

            Elemento? elementoRemovido = Inicio;
            Inicio.GetSetAnterior.GetSetProximo = Inicio.GetSetProximo;
            Inicio.GetSetProximo.GetSetAnterior = Inicio.GetSetAnterior;
            Inicio = Inicio.GetSetProximo;
            elementoRemovido.GetSetProximo = elementoRemovido;
            elementoRemovido.GetSetAnterior = elementoRemovido;
            Qtd--;
            return elementoRemovido;
        }

        public Elemento? RemoveFim()
        {
            if (IsEmpty())
            {
                return null;
            }

            if (Qtd == 1)
            {
                return RemoveUnico();
            }

            Elemento? elementoRemovido = Inicio.GetSetAnterior;
            Inicio.GetSetAnterior = elementoRemovido.GetSetAnterior;
            elementoRemovido.GetSetAnterior.GetSetProximo = Inicio;
            elementoRemovido.GetSetProximo = elementoRemovido;
            elementoRemovido.GetSetAnterior = elementoRemovido;
            Qtd--;
            return elementoRemovido;
        }
    }
}