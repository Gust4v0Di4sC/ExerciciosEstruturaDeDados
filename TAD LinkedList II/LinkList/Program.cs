using System;

namespace LinkList
{
    class Program
    {
        static void Main(string[] args)
        {
            ListaLigada ll = new ListaLigada();
            int countElements = 0;

            while (true)
            {
                Console.WriteLine("\n\n================================================");
                Console.WriteLine("             LISTA LIGADA TIPO II");
                Console.WriteLine("          (operacao em modo TAD Fila)");
                Console.WriteLine("================================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - inserir elemento (no final)");
                Console.WriteLine("2 - extrair elemento (do inicio)");
                Console.WriteLine("3 - imprimir elementos da lista (sentido inicio -> fim)");
                Console.WriteLine("4 - Detalhes da lista");
                Console.WriteLine("5 - Localizar um elemento");
                Console.WriteLine("6 - inserir elemento em posicao especifica");
                Console.WriteLine("7 - Remover elemento de qualquer posição");
                Console.WriteLine("");
                Console.Write("Opcao -> ");
                int optInput = Convert.ToInt32(Console.ReadLine());

                switch (optInput)
                {
                    case 0:
                        {
                            Console.WriteLine("Saindo...");
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        {
                            Console.WriteLine("Nome do elemento");
                            string? nmElemento = Console.ReadLine();
                            Console.WriteLine("Numero do elemento");
                            int nrElemento = Convert.ToInt32(Console.ReadLine());
                            Elemento e = new Elemento(nmElemento, nrElemento);
                            if (ll.Enqueue(e))
                            {
                                Console.WriteLine("Elemento inserido com sucesso!!");
                                countElements += 1;
                            }
                            else
                            {
                                Console.WriteLine("Falha na inserção do elemento");
                            }
                        }
                        break;
                    case 2:
                        {
                            Elemento? e = ll.Dequeue();
                            if (e == null)
                            {
                                Console.WriteLine("A lista esta vazia!!");
                            }
                            else
                            {
                                Console.WriteLine("O elemento foi removido da fila com sucesso.");
                                Console.WriteLine($"\n Nome --> {e.Nome}");
                                Console.WriteLine($"\n Numero --> {e.Numero}");
                            }

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Elementos da fila:");
                            Console.WriteLine("------------------");
                            if (ll.IsEmpty())
                            {
                                Console.WriteLine("A fila está vazia.");
                            }
                            else
                            {
                                Elemento? e = ll.GetInicio();
                                while (e != null)
                                {
                                    Console.WriteLine(e.Numero + "|" + e.Nome);
                                    e = e.Proximo;
                                    
                                }
                            }
                        }
                        break;
                    case 4:
                        {
                            if (ll.IsEmpty())
                            {
                                Console.WriteLine("A lista está vazia");
                            }
                            else
                            {
                                Elemento? e = ll.GetFim();

                                Console.WriteLine("Ultimo elemento da lista:  " + e.Nome + "|" + e.Numero);
                                Console.WriteLine($"Numero total de elementos na lista: {countElements}");
                            }
                            
                        }
                        break;
                    case 5:
                        {
                            if (ll.IsEmpty())
                            {
                                Console.WriteLine("A lista está vazia");
                            }
                            else
                            {
                                Console.WriteLine("Digite o numero de um elemento a ser localizado");
                                int inputNumber = Convert.ToInt32(Console.ReadLine());

                                ll.SearchElement(inputNumber);
                            }
                        }
                        break;
                    case 6:
                        {
                            Console.WriteLine("Nome do elemento");
                            string? nmElemento = Console.ReadLine();
                            Console.WriteLine("Numero do elemento");
                            int nrElemento = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Digite a posição que deseja inserir o elemento");
                            int position = Convert.ToInt32(Console.ReadLine());

                            Elemento e = new Elemento(nmElemento, nrElemento);
                            
                            if (ll.EnqueueOnPosition(e, position))
                            {
                                Console.WriteLine("Elemento inserido com sucesso!!");
                                countElements += 1;
                            }
                            else
                            {
                                Console.WriteLine("Falha na inserção do elemento");
                            }
                        }
                        break;
                    case 7:
                        {
                            Console.WriteLine("Digite a posição que deseja remover o elemento da lista: ");
                            int inputPosition = Convert.ToInt32(Console.ReadLine());

                            Elemento? e = ll.DequeueOnPosition(inputPosition);

                            if (e == null)
                            {
                                Console.WriteLine("A lista esta vazia!!");
                            }
                            else
                            {
                                Console.WriteLine("O elemento foi removido da fila com sucesso.");
                                Console.WriteLine($"\n Nome --> {e.Nome}");
                                Console.WriteLine($"\n Numero --> {e.Numero}");
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }

}