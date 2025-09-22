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
              elementoAutoConectado.GetSetProximo = elementoAutoConectado;elementoAutoConectado.GetSetAnterior = elementoAutoConectado;  
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
            }
            else
            {
                if (elementoInserido != null && Inicio != null)
                {
                    elementoInserido.GetSetProximo = Inicio;elementoInserido.GetSetAnterior = Inicio.GetSetAnterior;
                    Inicio.GetSetAnterior = elementoInserido;
                    elementoInserido.GetSetAnterior = elementoInserido.GetSetProximo;
                    Inicio = elementoInserido;
                }
                
                
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
                if (elementoInserido != null && Inicio != null)
                {
                    elementoInserido.GetSetProximo = Inicio;
                    elementoInserido.GetSetAnterior = Inicio.GetSetAnterior;
                    Inicio.GetSetAnterior = elementoInserido.GetSetProximo;
                    Inicio.GetSetAnterior = elementoInserido;
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
                if (Inicio.GetSetAnterior != null && Inicio.GetSetProximo != null)
                {
                    Inicio.GetSetAnterior.GetSetProximo = Inicio.GetSetProximo;
                    Inicio.GetSetProximo.GetSetAnterior = Inicio.GetSetAnterior;
                }
                Inicio = Inicio.GetSetProximo;
                elementoRemovido.GetSetProximo = elementoRemovido;
                elementoRemovido.GetSetAnterior = elementoRemovido;
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
                Elemento? elementoRemovido = Inicio.GetSetAnterior;
                if (elementoRemovido != null)
                {
                    if (elementoRemovido.GetSetAnterior != null && Inicio != null)
                    {
                        Inicio.GetSetAnterior = elementoRemovido.GetSetAnterior;
                        elementoRemovido.GetSetAnterior.GetSetProximo = Inicio;
                        elementoRemovido.GetSetProximo = elementoRemovido;
                        elementoRemovido.GetSetAnterior = elementoRemovido;
                    }
                }


                Qtd--;
                return elementoRemovido;
            }

            return null;
            
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
            }
            else
            {
                if (elementoRemovido == Inicio)
                {
                    if (elementoRemovido != null)
                    {
                        Inicio = elementoRemovido.GetSetProximo;

                        if (elementoRemovido.GetSetAnterior != null && elementoRemovido.GetSetProximo != null)
                        {
                            elementoRemovido.GetSetAnterior.GetSetProximo = elementoRemovido.GetSetProximo;

                            elementoRemovido.GetSetProximo.GetSetAnterior = elementoRemovido.GetSetAnterior;
                        }
                    }

                    

                    

                    AutoConex(elementoRemovido);
                    Qtd--;
                }
            }
            return true;
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
                while (posicaoAtual < GetQtd())
                {
                    ImprimeElemento(elementoImpresso);
                    if (elementoImpresso != null)
                    {
                      elementoImpresso = elementoImpresso.GetSetAnterior;  
                    }
                    
                    posicaoAtual++;
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