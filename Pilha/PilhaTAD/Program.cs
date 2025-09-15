using System;

namespace PilhaTAD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("PROGRAMA PARA ESTUDO DO TAD PILHA - VERSÃO 1");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");
            Console.Write("Tamanho maximo da pilha: ");
            int qtd = Convert.ToInt32(Console.ReadLine());

            Pilha pilha = new Pilha(qtd);

            while (true)
            {
                Console.WriteLine("\n\n--------------------------------------------");
                Console.WriteLine("PROGRAMA PARA ESTUDO DO TAD PILHA - VERSÃO 1");
                Console.WriteLine("      Conteudo: numeros inteiros");
                Console.WriteLine("      Capacidade:" + qtd + " elementos");
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("0 - Encerrar");
                Console.WriteLine("1 - Inserir um elemento");
                Console.WriteLine("2 - Extrair um elemento");
                Console.WriteLine("3 - Imprimir a pilha");
                Console.WriteLine("4 - Informar Quantidade de elementos");
                Console.WriteLine("5 - Posição no topo");
                Console.WriteLine("6 - Localizar um elemento");
                Console.WriteLine("");

                Console.Write("Opcao: ");
                int optionInput = Convert.ToInt32(Console.ReadLine());

                if (optionInput == 0)
                {
                    break;
                }
                else if (optionInput == 1)
                {

                    Console.Write("Valor do elemento a inserir: ");
                    int option1 = Convert.ToInt32(Console.ReadLine());

                    if (pilha.Push(option1))
                    {
                        Console.WriteLine("Insercao bem sucedida.");
                    }
                    else
                    {
                        Console.WriteLine("Insercao falhou!!");
                    }

                }
                else if (optionInput == 2)
                {
                    if (pilha.Pop())
                    {
                        Console.WriteLine("Extracao bem sucedida. Valor do elemento = " + pilha.GetRetorno());
                    }
                    else
                    {
                        Console.WriteLine("Extracao falhou.");
                    }
                }
                else if (optionInput == 3)
                {
                    Console.WriteLine(pilha.Print());
                }
                else if (optionInput == 4)
                {
                    Console.WriteLine("A pilha contém: " + pilha.QtdElementos());
                }
                else if (optionInput == 5)
                {
                    Console.WriteLine("O topo está na posição: " + pilha.PositionTop());
                }
                else if (optionInput == 6)
                {
                    if (pilha.Empty())
                    {
                        Console.WriteLine("A pilha está vazia");
                        break;
                    }
                    Console.WriteLine("Digite um elemento a ser buscado na pilha: ");
                    int buscaInput = Convert.ToInt32(Console.ReadLine());
                    int[] localizados = pilha.SearchElement(buscaInput, 0);

                    if (localizados[0] == 0)
                    {
                        Console.WriteLine("Numero não localizado.");
                    }
                    else
                    {
                        Console.Write($"Localizados {localizados[0]} elementos");
                        for (int i = 1; i <= localizados[0]; i++) {
                            Console.Write(localizados[i] + " ");
                        }
                    }

                    
                }
        

        }
        }
    }
}