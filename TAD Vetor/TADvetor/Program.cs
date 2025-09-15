using System;

namespace TADvetor
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int tamanho, minimo, maximo, vaga, repete;

            while (true)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("CONFIGURACOES INICIAIS DO VETOR");
                Console.WriteLine("==========================================");


                Console.WriteLine("\n Tamanho do vetor: ");
                tamanho = Convert.ToInt32(Console.ReadLine());
                if (tamanho <= 0)
                {
                    Console.WriteLine("ERRO: Vetor deve ter tamanho maior que zero!!");
                    continue;
                }

                Console.WriteLine("\n Valor Minimo no vetor: ");
                minimo = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\n Valor Maximo do vetor: ");
                maximo = Convert.ToInt32(Console.ReadLine());
                if (minimo > maximo)
                {
                    Console.WriteLine("ERRO: Valor maximo deve ser maior que o valor minimo");
                    continue;
                }

                Console.WriteLine("\n Valor indicativo de posicao vaga: "); vaga = Convert.ToInt32(Console.ReadLine());
                if (vaga >= minimo && vaga <= maximo)
                {
                    Console.WriteLine("ERRO: Valor indicativo de posicao vaga nao pode estar no intervalo de valores valido!!");
                    continue;
                }

                Console.WriteLine("\n Pode haver repeticao de valores (1) ou nao (2)?");
                repete = Convert.ToInt32(Console.ReadLine());
                if (repete < 1 || repete > 2)
                {
                    Console.WriteLine("ERRO: Valor invalido. Informe 1 ou 2.");
                    continue;
                }

                break;
            }


            Vetor vetor = new Vetor(tamanho, minimo, maximo, vaga, repete);

            while (true)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine(" Estudo do TAD Vetor");
                Console.WriteLine("==========================================");
                Console.WriteLine("0 - Encerrar");
                Console.WriteLine("1 - Atribuir um valor a determinada posição.");
                Console.WriteLine("2 - Alterar o valor de determinada posição.");
                Console.WriteLine("3 - Remover o valor de determinada posição (atribui o valor indicativo de posição vaga).");
                Console.WriteLine("4 - Ler o conteúdo de uma posicao.");
                Console.WriteLine("5 - Localizar um valor e retornar sua posição (se permitir repetição tem que retornar todos).");
                Console.WriteLine("6 - Inserir na primeira posição vaga (busca no sentido 0 → N).");
                Console.WriteLine("7 - Remover da última posição ocupada (busca no sentido 0 → N).");
                Console.WriteLine("8 - Imprimir o conteúdo do vetor.");

                Console.WriteLine("\nSua opcao: ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 0)
                {
                    break;
                }
                else if (option == 1)
                {
                    Console.WriteLine("===   A T R I B U I C A O   ===");
                    Console.WriteLine("Valor: ");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Posicao: ");
                    int posicao = Convert.ToInt32(Console.ReadLine());
                    Utils.PrintRet(vetor.Armazenar(valor, posicao));
                }
                else if (option == 2)
                {
                    Console.WriteLine("===    A L T E R A C A O   ===");
                    Console.WriteLine("Valor: ");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Posicao: ");
                    int posicao = Convert.ToInt32(Console.ReadLine());
                    Utils.PrintRet(vetor.Alterar(valor, posicao));
                }
                else if (option == 3)
                {
                    Console.WriteLine("===    R E M O C A O   ===");
                    Console.WriteLine("Posicao a ser removida: ");
                    int posicao = Convert.ToInt32(Console.ReadLine());
                    Utils.PrintRet(vetor.Excluir(posicao));
                }
                else if (option == 4)
                {
                    Console.WriteLine("===    C O N T E U D O   ===");
                    Console.WriteLine("Posicao a ser removida: ");
                    int posicao = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Posicao " + posicao + "contem " + vetor.Ler(posicao));
                }
                else if (option == 5)
                {
                    Console.WriteLine("===    L O C A L I Z A N D O   U M   V A L O R   ===");
                    Console.WriteLine("Valor a localizar: ");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    int[] valores = vetor.Localizar(valor, 0);
                    if (valores[0] == 0)
                    {
                        Console.WriteLine("\n\nVALOR NAO LOCALIZADO.\n\n");
                    }
                    else
                    {
                        Console.WriteLine("\n\n===  VALORES ENCONTRADOS NOS INDICES ABAIXO   ===");
                        for (int i = 1; i < valores.Length; i++)
                        {
                            if (valores[i] == 0)
                            {
                                break;
                            }
                            Console.WriteLine(valores[i] + " ");
                        }
                        Console.WriteLine("\n" + valores[0] + " valor(es) encontrado(s).");
                    }
                }
                else if (option == 6)
                {
                    Console.WriteLine("===   INSERINDO NA PRIMEIRA POSICAO VAGA   ===");
                    Console.WriteLine("Valor a inserir: ");
                    int valor = Convert.ToInt32(Console.ReadLine());
                    Utils.PrintRet(vetor.Armazenar1Vaga(valor));
                }
                else if (option == 7)
                {
                    Console.WriteLine("===   REMOVENDO DA ULTIMA POSICAO OCUPADA   ===");
                    Utils.PrintRet(vetor.RemoverUltima());
                }
                else if (option == 8)
                {
                    Console.WriteLine("===   IMPRIMIR O CONTEUDO DO VETOR   ===");
                    for (int i = 0; i < tamanho; i++)
                    {
                        Console.WriteLine(i + " = " + vetor.Ler(i));
                    }

                }
                else if (option == 99)
                {
                    vetor.LimparVetor();
                    Random seed = new();
                    for (int i = 0; i < tamanho; i++)
                    {
                        vetor.Armazenar(minimo + seed.Next(maximo + 1 - minimo), i);
                    }
                }
            }
            Console.WriteLine("\n\n---   F I M   ---");
            Console.WriteLine("Obrigado e ate' a proxima.\n\n");
        }

        
    }
    
}