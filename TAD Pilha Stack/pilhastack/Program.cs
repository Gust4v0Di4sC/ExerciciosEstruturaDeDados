using System;
using System.Collections;
using System.Numerics;

namespace pilhastack
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack1 = new Stack<int>();
            Stack<Triangulo> stack2 = new Stack<Triangulo>();
            

            while (true)
            {
                Console.WriteLine("\n\n\n==============================================");
                Console.WriteLine("PILHA 1 - contem numeros inteiros");
                Console.WriteLine("PILHA 2 - contem objetos da classe Triangulo");
                Console.WriteLine("==============================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("----- opcoes da PILHA 1 -----");
                Console.WriteLine("1 - inserir elemento");
                Console.WriteLine("2 - extrair elemento");
                Console.WriteLine("3 - localizar elemento");
                Console.WriteLine("4 - imprimir a pilha");
                Console.WriteLine("----- opcoes da PILHA 2 -----");
                Console.WriteLine("5 - inserir elemento");
                Console.WriteLine("6 - extrair elemento");
                Console.WriteLine("7 - localizar elemento");
                Console.WriteLine("8 - imprimir a pilha");
                Console.WriteLine("==============================================");
                Console.WriteLine("");
                Console.Write("Opcao: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        {
                            Console.WriteLine("Encerrando o programa...");
                            System.Environment.Exit(0);
                        }
                        break;
                    case 1:
                        {
                            Console.Write("Valor do elemento (numero int.) -> ");
                            int valor1 = Convert.ToInt32(Console.ReadLine());
                            stack1.Push(valor1);
                            int x = stack1.Peek();
                            Console.Write("x = " + x);
                        }
                        break;
                    case 2:
                        {
                            if (stack1.Count() == 0)
                            {
                                Console.WriteLine("A Pilha está vazia!");
                            }
                            else
                            {
                                Console.WriteLine($"Valor extraido: {stack1.Pop()}");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("Digite um valor a ser localizado:");
                            int inputSearch = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Valor Encontrado nas seguintes posicoes:");
                            for (int i = 0; i < stack1.Count(); i++)
                            {
                                if (stack1.ElementAt(i) == inputSearch)
                                {
                                    Console.WriteLine($"Posicao: {i}");
                                }
                            }

                            Console.Write("");
                            int foundItem = 0;
                            for (int i = 0; i < stack1.Count(); i++)
                            {
                                if (stack1.Equals(inputSearch))
                                {
                                    foundItem = i;
                                }
                            }
                            Console.WriteLine($"posicao pelo metodo search: {foundItem}");

                            Console.WriteLine("\n--- Agora pelo meu método equivalente ao 'search' plus:");
                            for (int i = stack1.Count() - 1; i >= 0; i--)
                            {
                                if (stack1.ElementAt(i) == inputSearch)
                                {
                                    Console.Write(stack1.Count() - i + " ");
                                }
                            }
                        }
                        break;
                    case 4:
                        int qtd = stack1.Count();
                        Console.WriteLine($"Tem {qtd} elementos na pilha");
                        for (int i = 0; i < qtd; i++)
                        {
                            Console.Write(stack1.ElementAt(i) + " ");
                        }
                        break;

                    case 5:
                        {
                            float[] triangleStructure = DefineTriangulo();
                            Triangulo triangle = new Triangulo(triangleStructure[0], triangleStructure[1], triangleStructure[2]);
                            if (!triangle.TrianguloValido())
                            {
                                Console.WriteLine("ERRO : Triangulo Invalido");
                                continue;
                            }
                            stack2.Push(triangle);
                        }
                        break;
                    case 6:
                        {
                            if (stack2.Count() == 0)
                            {
                                Console.WriteLine("A Pilha está vazia!");
                            }
                            else
                            {
                                Console.WriteLine($"Valor extraido: {PrintTriangulo(stack2.Pop())}");
                            }
                        }
                        break;
                    case 7:
                        {
                            float[] triangleStructure = DefineTriangulo();
                            Triangulo triangle = new Triangulo(triangleStructure[0], triangleStructure[1], triangleStructure[2]);

                            var foundElement = stack2.ToList().IndexOf(triangle);
                            Console.WriteLine($"Triangulo na posicao -> {foundElement}");
                        }
                        break;
                    case 8:
                        {
                            int qtd2 = stack2.Count();
                            Console.WriteLine($"Tamanho da pilha -> {qtd2}");
                            for (int i = 0; i < qtd2; i++)
                            {
                                Console.Write(PrintTriangulo(stack2.ElementAt(i)));
                            }

                        }
                        break;
                    default: Console.WriteLine("Opção invalida!"); break;
                }
            }
        }


        private static float[] DefineTriangulo()
        {
            float[] tri = new float[3];

            Console.Write("Lado 1 -> ");
            tri[0] = Convert.ToSingle(Console.ReadLine());

            Console.Write("Lado 2 -> ");
            tri[1] = Convert.ToSingle(Console.ReadLine());

            Console.Write("Lado 3 -> ");
            tri[2] = Convert.ToSingle(Console.ReadLine());

            return tri;
        }

        private static String PrintTriangulo(Triangulo t)
        {
            return "|" + t.Lado1 + "|" + t.Lado2 + "|" + t.Lado3 + "|";
        }
    }
}