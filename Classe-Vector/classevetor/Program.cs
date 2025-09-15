using System;
using System.Numerics;

namespace classeVetor
{
    public class Program()
    {
        public static List<Quadrado> vetor = new List<Quadrado>();


        public static void Main(String[] args)
        {
            Console.Write("Capacidade inicial do vetor: ");
            int capacidadeInicial = Convert.ToInt32(Console.ReadLine());
            if (capacidadeInicial <= 0)
            {
                Console.WriteLine($"Erro capacidade digitada inválida: {capacidadeInicial}");
                return;
            }

            vetor = new List<Quadrado>(capacidadeInicial);

            while (true)
            {
                Console.WriteLine("\n\n========================================================");
                Console.WriteLine("                   ESTUDO DA CLASSE LIST<T>");
                Console.WriteLine("========================================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - capacidade do vetor");
                Console.WriteLine("2 - numero de elementos no vetor");
                Console.WriteLine("3 - inserir novo elemento no final do vetor");
                Console.WriteLine("4 - inserir novo elemento em um indice especifico do vetor (desloca os que estao acima)");
                Console.WriteLine("5 - atribuir novo elemento a uma posicao especifica (sobrescreve o que estiver na posicao)");
                Console.WriteLine("6 - localizar um elemento");
                Console.WriteLine("7 - remover um elemento dado o indice");
                Console.WriteLine("8 - remover um elemento dado um elemento igual");

                Console.WriteLine("55 - Imprimir os elementos do vetor");
                Console.WriteLine("========================================================");

                Console.Write("Digite uma opção: ");
                int optInput = Convert.ToInt32(Console.ReadLine());

                switch (optInput)
                {
                    case 0:
                        {
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        Console.WriteLine($"A Capacidade do vetor é {vetor.Capacity}");
                        break;
                    case 2:
                        Console.WriteLine($"A Quantidade de elementos no vetor: {vetor.Count()}");
                        break;
                    case 3:
                        {
                            Quadrado? squareInput = GeraQuadrado();
                            if (squareInput != null)
                            {
                                vetor.Add(squareInput);
                            }
                        }
                        break;
                    case 4:
                        {
                            Quadrado? squareInput = GeraQuadrado();
                            if (squareInput != null)
                            {
                                int indiceInput = DefineQuadrado();
                                vetor.Insert(indiceInput, squareInput);
                            }
                        }
                        break;
                    case 5:
                        {
                            Quadrado? squareInput = GeraQuadrado();
                            if (squareInput != null)
                            {
                                int indiceInput = DefineQuadrado();
                                try
                                {
                                    vetor[indiceInput] = squareInput;
                                    Console.WriteLine($"Quadrado atualizado no indice {indiceInput}");
                                }
                                catch (System.ArgumentOutOfRangeException)
                                {
                                    Console.WriteLine("ERRO: Índice fora dos limites da lista.");
                                }
                            }
                        }
                        break;
                    case 6:
                        {
                            Quadrado? squareInput = GeraQuadrado();
                            if (squareInput != null) // verifico se o indice é nulo antes de consulta-lo
                            {
                                int indiceInput = vetor.IndexOf(squareInput);

                                if (indiceInput >= 0)
                                {
                                    Console.WriteLine($"Localizado no indice: {indiceInput}");
                                }
                                else
                                {
                                    Console.WriteLine("Não localizado");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Não foi possivel localizar o indice");
                            }
                            
                        }
                        break;
                    case 7:
                        {
                            int indiceInput = DefineQuadrado();
                            try
                            {

                                Quadrado obterElemento = vetor[indiceInput];

                                vetor.RemoveAt(indiceInput);
                                Console.WriteLine($"Quadrado removido de lado = {obterElemento.Lado}");

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Ocorreu um erro inesperado: {ex.Message}");
                            }

                        }
                        break;
                    case 8:
                        {
                            Quadrado? squareInput = GeraQuadrado();
                            if (squareInput != null)
                            {
                                bool squareRemoved = vetor.Remove(squareInput);
                                if (squareRemoved)
                                {
                                    Console.WriteLine("Quadrado removido com sucesso");
                                }
                                else
                                {
                                    Console.WriteLine("Quadrado inexiste no vetor");
                                }
                            }
                            
                        }
                        break;
                    case 55:
                        {
                            Console.WriteLine("Elementos do vetor (impressao somente do lado): ");
                            Console.WriteLine($"total de {vetor.Count()} elementos");
                            for (int i = 0; i < vetor.Count(); i++)
                            {
                                Console.WriteLine(vetor.ElementAt(i).Lado + " ");
                            }
                    }
                        break;
                    default:
                        break;
                }
            }

        }

        private static Quadrado? GeraQuadrado()
        {
            Console.Write("Lado -> ");
            float lado = Convert.ToSingle(Console.ReadLine());
            if (lado <= 0)
            {
                Console.WriteLine("Erro quadrado inválido.");
                return null;
            }

            return new Quadrado(lado);
        }

        private static int DefineQuadrado()
        {
            Console.WriteLine("Indice do vetor -> ");
            int indiceInput = Convert.ToInt32(Console.ReadLine());
            return indiceInput;
        }
    }
}