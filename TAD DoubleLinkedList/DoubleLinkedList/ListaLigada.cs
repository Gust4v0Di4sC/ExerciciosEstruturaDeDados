namespace DoublLinkedList
{
    public class ListaLigada
    {
        private Elemento? inicio;

        private Elemento? ultimo;
        private int qtd;


        private void PrintElem(Elemento? elementoImpresso)
        {
            if (elementoImpresso != null)
            {
                Console.WriteLine(elementoImpresso.GetSetNumero + "|" + elementoImpresso.GetSetNome);
            }
        }

        private void InsereEmVazio(Elemento? elementoInserido)
        {
            ultimo = elementoInserido;
            inicio = elementoInserido;
        }

        private Elemento? RemoveUnico()
        {
            Elemento? elementoRemovido = inicio;
            inicio = null;
            ultimo = null;
            qtd = 0;
            return elementoRemovido;
        }

        public void InsereInicio(Elemento? elementoInsInicio)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInsInicio);
            }
            else
            {
                if (elementoInsInicio != null)
                {
                    elementoInsInicio.GetSetProximo = inicio;
                    if (inicio != null)
                    {
                        inicio.GetSetAnterior = elementoInsInicio;
                    }
                    inicio = elementoInsInicio;
                }
            }
            qtd++;
        }

        public void InsereUltimo(Elemento elementoInsUltimo)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInsUltimo);
            }
            else
            {
                if (ultimo != null)
                {
                    ultimo.GetSetProximo = elementoInsUltimo;
                    elementoInsUltimo.GetSetAnterior = ultimo;
                }
                ultimo = elementoInsUltimo;
            }
            qtd++;
        }

        public Elemento? RemoveInicio()
        {
            if (IsEmpty())
            {
                return null;
            }

            if (qtd == 1)
            {
                return RemoveUnico();
            }
            Elemento? elementoRemovido = inicio;

            if (inicio != null)
            {
                inicio = inicio.GetSetProximo;
            }

            if (inicio != null)
            {
                inicio.GetSetAnterior = null;
            }

            if (elementoRemovido != null)
            {
                elementoRemovido.GetSetProximo = null;
            }


            qtd--;
            return elementoRemovido;
        }

        public Elemento? RemoveUltimo()
        {
            if (IsEmpty())
            {
                return null;
            }
            if (qtd == 1)
            {
                return RemoveUnico();
            }


            Elemento? elementoRemovido = ultimo;

            if (ultimo != null)
            {
                ultimo = ultimo.GetSetAnterior;
            }


            if (ultimo != null)
            {
                ultimo.GetSetProximo = null;
            }

            if (elementoRemovido != null)
            {
                elementoRemovido.GetSetAnterior = null;
            }

            qtd--;
            return elementoRemovido;
        }

        public void ImprimeParaFim()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
            }
            else
            {
                Elemento? elementoImpresso = inicio;
                while (elementoImpresso != null)
                {
                    PrintElem(elementoImpresso);
                    elementoImpresso = elementoImpresso.GetSetProximo;
                }
            }
        }

        public void ImprimeParaInicio()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
            }
            else
            {
                Elemento? elementoImpresso = ultimo;
                while (elementoImpresso != null)
                {
                    PrintElem(elementoImpresso);
                    elementoImpresso = elementoImpresso.GetSetAnterior;
                }
            }


        }

        public Elemento? GetPosDoInicio(int pos)
        {
            if (pos > qtd || pos <= 0)
            {
                return null;
            }
            int posicaoAtual = 1;
            Elemento? elementoAtual = inicio;
            while (posicaoAtual < pos)
            {
                if (elementoAtual != null)
                {
                    elementoAtual = elementoAtual.GetSetProximo;
                }
                posicaoAtual++;
            }
            return elementoAtual;
        }


        public Elemento? GetPosDoFim(int pos)
        {
            if (pos > qtd || pos <= 0)
            {
                return null;
            }
            int posicaoAtual = 1;
            Elemento? elementoAtual = ultimo;
            while (posicaoAtual < pos)
            {
                if (elementoAtual == null)
                {
                    return null;
                }
                elementoAtual = elementoAtual.GetSetAnterior;
                posicaoAtual++;
            }
            return elementoAtual;
        }

        public Elemento? GetElemDoInicio(int num)
        {
            if (IsEmpty())
            {
                return null;
            }

            Elemento? elementoBuscado = inicio;
            while (elementoBuscado != null && elementoBuscado.GetSetNumero != num)
            {
                elementoBuscado = elementoBuscado.GetSetProximo;
            }
            return elementoBuscado;
        }

        public Elemento? GetElemDoFim(int num)
        {
            if (IsEmpty())
            {
                return null;
            }

            Elemento? elementoBuscado = ultimo;
            while (elementoBuscado != null && elementoBuscado.GetSetNumero != num)
            {
                elementoBuscado = elementoBuscado.GetSetAnterior;
            }
            return elementoBuscado;
        }

        public string InserePosParaFim(int posInserida, Elemento elementoInserido)
        {
            if (posInserida > qtd + 1 || posInserida <= 0 || elementoInserido == null)
            {
                return "ERRO: um ou mais parametros com problemas!!";
            }
            if (posInserida == 1)
            {
                InsereInicio(elementoInserido);
            }
            else
            {
                if (posInserida == qtd + 1)
                {
                    InsereUltimo(elementoInserido);
                }
                else
                {
                    Elemento? cursor = GetPosDoInicio(posInserida - 1);
                    if (cursor == null)
                    {
                        return "ERRO: posição inválida!";
                    }
                    elementoInserido.GetSetProximo = cursor.GetSetProximo;
                    elementoInserido.GetSetAnterior = cursor;
                    if (cursor.GetSetProximo != null)
                    {
                        cursor.GetSetProximo.GetSetAnterior = elementoInserido;
                    }
                    cursor.GetSetProximo = elementoInserido;
                    qtd++;
                }
            }
            return "";
        }

        public string InserePosParaInicio(int posInserida, Elemento elementoInserido)
        {
            if (posInserida > qtd + 1 || posInserida <= 0 || elementoInserido == null)
            {
                return "ERRO: um ou mais parametros com problemas!!";
            }
            if (posInserida == 1)
            {
                InsereInicio(elementoInserido);
            }
            else
            {
                if (posInserida == qtd + 1)
                {
                    InsereUltimo(elementoInserido);
                }
                else
                {
                    Elemento? cursor = GetPosDoFim(posInserida - 1);
                    if (cursor == null)
                    {
                        return "ERRO: posição inválida!";
                    }
                    elementoInserido.GetSetAnterior = cursor.GetSetAnterior;
                    elementoInserido.GetSetProximo = cursor;
                    if (cursor.GetSetAnterior != null)
                    {
                        cursor.GetSetAnterior.GetSetProximo = elementoInserido;
                    }
                    cursor.GetSetAnterior = elementoInserido;
                    qtd++;
                }
            }
            return "";
        }

        public Elemento? RemovePosParaInicio(int posRemovida)
        {
            if (IsEmpty() || posRemovida > qtd + 1 || posRemovida <= 0)
            {
                return null;
            }

            if (posRemovida == 1)
            {
                return RemoveUltimo();
            }
            else if (posRemovida == qtd)
            {
                return RemoveInicio();
            }

            Elemento? cursor = GetPosDoFim(posRemovida);
            if (cursor == null)
            {
                return null;
            }

            Elemento? anterior = cursor.GetSetAnterior;
            Elemento? proximo = cursor.GetSetProximo;

            if (anterior != null)
            {
                anterior.GetSetProximo = proximo;
            }

            if (proximo != null)
            {
                proximo.GetSetAnterior = anterior;
            }

            cursor.GetSetAnterior = null;
            cursor.GetSetProximo = null;
            qtd--;
            return cursor;
        }

        public Elemento? RemovePosParaFim(int posRemovida)
        {
            if (IsEmpty() || posRemovida > qtd + 1 || posRemovida <= 0)
            {
                return null;
            }

            if (posRemovida == 1)
            {
                return RemoveInicio();
            }
            else if (posRemovida == qtd)
            {
                return RemoveUltimo();
            }

            Elemento? cursor = GetPosDoInicio(posRemovida);
            if (cursor == null)
            {
                return null;
            }

            Elemento? anterior = cursor.GetSetAnterior;
            Elemento? proximo = cursor.GetSetProximo;

            if (anterior != null)
            {
                anterior.GetSetProximo = proximo;
            }

            if (proximo != null)
            {
                proximo.GetSetAnterior = anterior;
            }

            cursor.GetSetAnterior = null;
            cursor.GetSetProximo = null;


            qtd--;
            return cursor;
        }

        public Elemento? GetInicio()
        {
            return inicio;
        }

        public Elemento? GetUltimo()
        {
            return ultimo;
        }

        public int GetQtd()
        {
            return qtd;
        }

        public bool IsEmpty()
        {
            return inicio == null;
        }

        public void Destruir()
        {
            inicio = null;
            ultimo = null;
            qtd = 0;
        }
    }
}