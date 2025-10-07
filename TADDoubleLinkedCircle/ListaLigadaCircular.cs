namespace taddoublelinkedlistcirc
{
    public class ListaLigadaCircular
    {
        private Elemento? Inicio;
        private int Qtd;

        public void ImprimeElemento(Elemento? elementoImpresso)
        {
            if (elementoImpresso != null)
            {
                Console.WriteLine(elementoImpresso.GetSetId);
            }
        }

        private void AutoConex(Elemento? elementoAutoConectado)
        {
            if (elementoAutoConectado != null)
            {
                elementoAutoConectado.GetSetProximo = elementoAutoConectado; elementoAutoConectado.GetSetAnterior = elementoAutoConectado;
            }

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
                // Quando insere o primeiro elemento, ele aponta para si mesmo
                if (Inicio != null)
                {
                    Inicio.GetSetProximo = Inicio;
                    Inicio.GetSetAnterior = Inicio;
                }
            }
            else
            {
                if (elementoInserido != null && Inicio != null)
                {
                    Elemento? ultimo = Inicio.GetSetAnterior; // Pega o último elemento

                    elementoInserido.GetSetProximo = Inicio;
                    elementoInserido.GetSetAnterior = ultimo;

                    Inicio.GetSetAnterior = elementoInserido;
                    if (ultimo != null)
                    {
                        ultimo.GetSetProximo = elementoInserido;
                    }
                    Inicio = elementoInserido; // O novo elemento é o início
                }
            }
            Qtd++;
        }

        public void InsereUltimo(Elemento? elementoInserido)
        {
            if (IsEmpty())
            {
                InsereEmVazio(elementoInserido);
                // Quando insere o primeiro elemento, ele aponta para si mesmo
                if (Inicio != null)
                {
                    Inicio.GetSetProximo = Inicio;
                    Inicio.GetSetAnterior = Inicio;
                }
            }
            else
            {
                if (elementoInserido != null && Inicio != null)
                {
                    Elemento? ultimo = Inicio.GetSetAnterior; // Pega o último elemento atual

                    elementoInserido.GetSetProximo = Inicio;
                    elementoInserido.GetSetAnterior = ultimo;

                    if (ultimo != null)
                    {
                        ultimo.GetSetProximo = elementoInserido;
                    }
                    Inicio.GetSetAnterior = elementoInserido; // O novo elemento é o anterior do início (o novo último)
                }
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
    
    if (elementoRemovido != null && Inicio != null)
    {
        // Precisamos do anterior (o último) e do próximo do Início atual
        Elemento? proximoDoInicio = Inicio.GetSetProximo;
        Elemento? anteriorDoInicio = Inicio.GetSetAnterior;

        // O anterior do Início (o último elemento) agora aponta para o próximo do Início como seu próximo
        if (anteriorDoInicio != null)
        {
            anteriorDoInicio.GetSetProximo = proximoDoInicio;
        }
        
        // O próximo do Início (o segundo elemento) agora aponta para o anterior do Início como seu anterior
        if (proximoDoInicio != null)
        {
            proximoDoInicio.GetSetAnterior = anteriorDoInicio;
        }

        Inicio = proximoDoInicio; // O segundo elemento se torna o novo Início

        // Desconecta o elemento removido
        if (elementoRemovido != null)
        {
            elementoRemovido.GetSetProximo = elementoRemovido; // Opcional: isolar
            elementoRemovido.GetSetAnterior = elementoRemovido; // Opcional: isolar
        }
    }
    
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

    if (Inicio != null)
    {
        Elemento? elementoRemovido = Inicio.GetSetAnterior; // O último elemento
        
        if (elementoRemovido != null)
        {
            Elemento? novoUltimo = elementoRemovido.GetSetAnterior; // O elemento antes do removido

            // O novo último (elemento antes do removido) agora aponta para o Início como seu próximo
            if (novoUltimo != null)
            {
                novoUltimo.GetSetProximo = Inicio;
            }
            
            // O Início agora aponta para o novo último como seu anterior
            Inicio.GetSetAnterior = novoUltimo;

            // Desconecta o elemento removido
            elementoRemovido.GetSetProximo = elementoRemovido; // Opcional: isolar
            elementoRemovido.GetSetAnterior = elementoRemovido; // Opcional: isolar
        }

        Qtd--;
        return elementoRemovido;
    }

    return null; // Nunca deveria acontecer se Qtd > 1 e Inicio != null
}

        public Elemento? GetPosHorario(Elemento? elementoBuscado, int posicao)
        {
            if (posicao > Qtd || posicao <= 0)
            {
                return null;
            }
            int posicaoAtual = 1;
            Elemento? elementoDeslocado = elementoBuscado;
            while (posicaoAtual < posicao)
            {
                if (elementoDeslocado != null)
                {
                    elementoDeslocado = elementoDeslocado.GetSetProximo;
                }
                posicaoAtual++;
            }
            return elementoDeslocado;
        }

        public Elemento? GetPosAntiHorario(Elemento? elementoBuscado, int posicao)
        {
            if (posicao > Qtd || posicao <= 0)
            {
                return null;
            }
            int posicaoAtual = 1;
            Elemento? elementoDeslocado = elementoBuscado;
            while (posicaoAtual < posicao)
            {
                if (elementoDeslocado != null)
                {
                    elementoDeslocado = elementoDeslocado.GetSetAnterior;
                }
                posicaoAtual++;
            }
            return elementoDeslocado;
        }

        public bool RemoveElemento(Elemento? elementoRemovido)
{
    if (IsEmpty() || elementoRemovido == null)
    {
        return false;
    }

    if (Qtd == 1)
    {
        RemoveUnico();
        return true;
    }

    // Caso o elemento a ser removido seja o início
    if (elementoRemovido == Inicio)
    {
        RemoveInicio(); // Já trata as religações e decrementa Qtd
        return true;
    }

    // Caso o elemento a ser removido seja o último
    if (elementoRemovido == Inicio.GetSetAnterior)
    {
        RemoveFim(); // Já trata as religações e decrementa Qtd
        return true;
    }

    // Percorrer a lista para encontrar o elemento
    Elemento? atual = Inicio?.GetSetProximo; // Começa do segundo elemento
    while (atual != null && atual != Inicio) // Percorre até voltar ao início
    {
        if (atual == elementoRemovido)
        {
            // Encontrou o elemento a ser removido
            Elemento? anterior = atual.GetSetAnterior;
            Elemento? proximo = atual.GetSetProximo;

            // Religa os vizinhos
            if (anterior != null)
            {
                anterior.GetSetProximo = proximo;
            }
            if (proximo != null)
            {
                proximo.GetSetAnterior = anterior;
            }

            // Isola o elemento removido
            atual.GetSetProximo = atual;
            atual.GetSetAnterior = atual;

            Qtd--;
            return true;
        }
        atual = atual.GetSetProximo;
    }

    // Se chegou aqui, o elemento não foi encontrado na lista (ou a lista está vazia, o que já foi tratado)
    return false;
}


        public bool InsereHorario(Elemento elementoNovo, Elemento elementoAtual)
        {
            if (elementoNovo == null)
            {
                return false;
            }

            if (Inicio != null)
            {
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
                    if (elementoNovo != null && elementoAtual != null)
                    {

                        elementoNovo.GetSetProximo = elementoAtual;
                        elementoNovo.GetSetAnterior = elementoAtual.GetSetAnterior;

                        if (elementoAtual.GetSetProximo != null)
                        {
                            elementoAtual.GetSetProximo.GetSetAnterior = elementoNovo;
                        }
                        elementoAtual.GetSetAnterior = elementoNovo;
                    }

                    Qtd++;
                }
                return true;
            }

            return false;
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
                if (elementoNovo != null && elementoAtual != null)
                {
                    elementoNovo.GetSetProximo = elementoAtual.GetSetProximo;
                    elementoNovo.GetSetAnterior = elementoAtual;
                    if (elementoAtual.GetSetProximo != null)
                    {
                        elementoAtual.GetSetProximo.GetSetAnterior = elementoNovo;
                    }

                    elementoAtual.GetSetProximo = elementoNovo;
                }

                if (elementoAtual == Inicio)
                {
                    Inicio = elementoNovo;
                }
                Qtd++;
            }
            return true;
        }

        public void ImprimeHorario()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia");
            }
            else
            {
                Elemento? elementoImpresso = GetInicio();
                int posicaoAtual = 1;
                while (posicaoAtual <= GetQtd())
                {
                    ImprimeElemento(elementoImpresso);
                    if (elementoImpresso != null)
                    {
                        elementoImpresso = elementoImpresso.GetSetProximo; posicaoAtual++;
                    }

                }
            }
        }

        public void ImprimeAntiHorario()
        {
            if (IsEmpty())
            {
                Console.WriteLine("A lista está vazia ");
            }
            else
            {
                Elemento? elementoImpresso = GetInicio();
                int posicaoAtual = 1;
                while (posicaoAtual <= GetQtd())
                {
                    ImprimeElemento(elementoImpresso);
                    if (elementoImpresso != null)
                    {
                        elementoImpresso = elementoImpresso.GetSetAnterior; posicaoAtual++;
                    }

                }
            }
        }

        public Elemento? GetUltimo()
        {
            if (IsEmpty())
            {
                return null;
            }

            if (Inicio != null)
            {
                return Inicio.GetSetAnterior;
            }

            return null;
        }

        public bool IsEmpty()
        {
            return Inicio == null;
        }

        public Elemento? GetInicio()
        {
            return Inicio;
        }

        public int GetQtd()
        {
            return Qtd;
        }

        public void Destroi()
        {
            Inicio = null;
            Qtd = 0;
        }
    }
}