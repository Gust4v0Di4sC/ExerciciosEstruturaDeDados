namespace DoublLinkedList
{
    public class Program()
    {
        static ListaLigada? ll;
        public static void Main(string[] args)
        {

            ll = new ListaLigada();

            while (true)
            {
                Console.WriteLine("\n\n================================================");
                Console.WriteLine("             LISTA DUPLAMENTE LIGADA");
                Console.WriteLine("       Quantidade de elementos na lista -> " + ll.GetQtd());  // Ex1
                Console.WriteLine("================================================");
                Console.WriteLine(" 0 - encerrar");
                Console.WriteLine(" 1 - inserir elemento no inicio");
                Console.WriteLine(" 2 - inserir elemento no final");
                Console.WriteLine(" 3 - extrair elemento do inicio");
                Console.WriteLine(" 4 - extrair elemento do final");
                Console.WriteLine(" 5 - imprimir elementos da lista (sentido inicio -> fim)");
                Console.WriteLine(" 6 - imprimir elementos da lista (sentido fim -> inicio");
                Console.WriteLine(" 7 - retornar elemento de uma determinada posicao (sentido inicio -> fim)");
                Console.WriteLine(" 8 - retornar elemento de uma determinada posicao (sentido fim -> inicio)");
                Console.WriteLine(" 9 - localizar a primeira ocorrencia um elemento dado seu numero (sentido inicio -> fim)");
                Console.WriteLine("10 - localizar a primeira ocorrencia um elemento dado seu numero (sentido fim -> inicio)");
                Console.WriteLine("11 - inserir um elemento em determinada posicao (sentido inicio -> fim)");
                Console.WriteLine("12 - inserir um elemento em determinada posicao (sentido fim -> inicio)");
                Console.WriteLine("13 - remover um elemento de determinada posicao (sentido inicio -> fim)");
                Console.WriteLine("14 - remover um elemento de determinada posicao (sentido fim -> inicio)");

                Console.WriteLine("98 - inicializa a lista com algum elementos");
                Console.WriteLine("99 - destroi a lista");

                Console.WriteLine("");
                Console.Write("Opcao -> ");
                int optionInput = Convert.ToInt32(Console.ReadLine());


                switch (optionInput)
                {
                    case 0:
                        {
                            Console.WriteLine("Saindo...");
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        {
                            Elemento elementoCriado = CriaElem();
                            ll.InsereInicio(elementoCriado);
                            Console.WriteLine("elemento inserido no inicio com sucesso");
                        }
                        break;
                    case 2:
                        {
                            Elemento elementoCriado = CriaElem();
                            ll.InsereUltimo(elementoCriado);
                            Console.WriteLine("elemento inserido no final com sucesso");
                        }
                        break;
                    case 3:
                        {
                            if (Vazia())
                            {
                                continue;
                            }

                            Elemento? elementoRemovido = ll.RemoveInicio();
                            Console.WriteLine("Elemento removido do inicio com sucesso");

                            if (elementoRemovido != null)
                            {
                                PrintElem(elementoRemovido);
                            } 
                        }
                        break;
                    case 4:
                        {
                            if (Vazia())
                            {
                                continue;
                            }

                            Elemento? elementoRemovido = ll.RemoveUltimo();
                            Console.WriteLine("elemento removido do final com sucesso");

                            if (elementoRemovido != null)
                            {
                                PrintElem(elementoRemovido);
                            }
                        }
                        break;
                    case 5: ll.ImprimeParaFim();
                        break;
                    case 6: ll.ImprimeParaInicio();
                        break;
                    case 7:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.WriteLine("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoPosicionado;
                            elementoPosicionado = ll.GetPosDoInicio(posInput);

                            if (elementoPosicionado != null)
                            {
                               PrintElem(elementoPosicionado); 
                            }
                        }
                        break;
                    case 8:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.WriteLine("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoPosicionado;
                            elementoPosicionado = ll.GetPosDoFim(posInput);

                            if (elementoPosicionado != null)
                            {
                                PrintElem(elementoPosicionado);
                            }

                        }
                        break;
                    case 9:
                        {
                            Console.WriteLine("Primeira ocorrencia de numero digitado fim -> inicio");
                            Console.WriteLine("Informe o numero a ser encontrado: ");
                            int numeroInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoEncontrado;
                            elementoEncontrado = ll.GetElemDoInicio(numeroInput);

                            if (elementoEncontrado != null)
                            {
                                PrintElem(elementoEncontrado);
                            }
                        }
                        break;
                    case 10:
                        {
                            Console.WriteLine("Primeira ocorrencia de numero digitado inicio -> fim");
                            Console.WriteLine("Informe o numero a ser encontrado: ");
                            int numeroInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoEncontrado;
                            elementoEncontrado = ll.GetElemDoFim(numeroInput);

                            if (elementoEncontrado != null)
                            {
                                PrintElem(elementoEncontrado);
                            }

                        }
                        break;
                    case 11:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.Write("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento elementoInserido = CriaElem();
                            string resposta = "";

                            resposta = ll.InserePosParaFim(posInput, elementoInserido);

                            if (resposta.Equals(""))
                            {
                                Console.WriteLine("Elemento inserido com sucesso");
                            }
                            else
                            {
                                Console.WriteLine(resposta);
                            }

                        }
                        break;
                    case 12:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.Write("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento elementoInserido = CriaElem();
                            string resposta = "";

                            resposta = ll.InserePosParaInicio(posInput, elementoInserido);

                            if (resposta.Equals(""))
                            {
                                Console.WriteLine("Elemento inserido com sucesso");
                            }
                            else
                            {
                                Console.WriteLine(resposta);
                            }
                        }
                        break;
                    case 13:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.Write("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoRemovido = ll.RemovePosParaFim(posInput);

                            if (elementoRemovido != null)
                            {
                                Console.WriteLine("Elemento removido");
                                PrintElem(elementoRemovido);
                            }
                            else
                            {
                                Console.WriteLine("ERRO: lista vazia ou parametros incorretos");
                            }
                        }
                        break;
                    case 14:
                        {
                            Console.WriteLine("A posição desejada não pode ser maior que a quantidade de elementos.");
                            Console.Write("Informe a posição: ");
                            int posInput = Convert.ToInt32(Console.ReadLine());
                            Elemento? elementoRemovido = ll.RemovePosParaInicio(posInput);

                            if (elementoRemovido != null)
                            {
                                Console.WriteLine("Elemento removido");
                                PrintElem(elementoRemovido);
                            }
                            else
                            {
                                Console.WriteLine("ERRO: lista vazia ou parametros incorretos");
                            }

                        }
                        break;
                    case 98:
                        Inicializa();
                        Console.WriteLine("Lista inicializada com valores na ordem do inicio para o final");
                        break;
                    case 99:
                        ll.Destruir();
                        Console.WriteLine("A lista foi reinicializada");
                        break;
                    default: Console.WriteLine("opção invalida");
                        break;
                }
            }
        }


        private static void PrintElem(Elemento elementoImpresso) {
            if (elementoImpresso == null)
            {
                Console.WriteLine("ERRO: Elemento nulo");
            }
            else
            {
                Console.WriteLine(elementoImpresso.GetSetNumero + "|" + elementoImpresso.GetSetNome);
            }
        }

        private static Elemento CriaElem() {
            string? nome;
            int numero;
            while (true)
            {
                try
                {
                    Console.Write("\n\n Nome do elemento-> ");
                    nome = Console.ReadLine();
                    Console.Write("\n\n Numero do elemento-> ");
                    numero = Convert.ToInt32(Console.ReadLine());
                    break;
                }
                catch (System.Exception)
                {
                    Console.WriteLine("ERRO: entrada inválida");
                    throw;
                }
            }
            return new Elemento(nome, numero);
        }

        private static bool Vazia() {
            if (ll != null)
            {
                if (ll.IsEmpty())
                {
                    Console.WriteLine("A lista está vazia");
                    return true;
                }
            }

            
            return false;
        }

        private static void Inicializa() {
            for (int i = 100; i <= 300; i = i + 10)
            {
                Elemento elementoInserido = new Elemento("Elemento_" + Convert.ToString(i), i);
                if (ll != null)
                {
                    ll.InsereUltimo(elementoInserido);
                }
            }
        }
    }
}