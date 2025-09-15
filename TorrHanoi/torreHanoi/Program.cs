using System;

namespace TorreHanoi
{
    public class Program
    {
        static PilhaHanoi? pilha, pilha2, pilha3;
        static int tam, qtd;

        public static void Main(string[] args)
        {
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("TORRE DE HANOI - JOGO");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Informe o tamanho das pilhas (min 5 e max. 100): ");
                tam = Convert.ToInt32(Console.ReadLine());

                if (tam < 5 || tam > 100)
                {
                    Console.WriteLine("ERRO: tamanho invalido.");
                    continue;
                }

                Console.WriteLine("Informe a quantidade inicial de números nas pilhas 1 e 2 (min 3. e max. " + tam + "): ");
                qtd = Convert.ToInt32(Console.ReadLine());

                if (qtd < 3 || qtd > tam)
                {
                    Console.WriteLine("ERRO: quantidade de numeros nao pode ser menor que 3 nem maior que o tamanho da pilha.");
                    continue;
                }
                break;
            }


            pilha = new PilhaHanoi(tam);
            pilha2 = new PilhaHanoi(tam);
            pilha3 = new PilhaHanoi(tam);


            Random seed = new();
            while (!pilha.Full() && !pilha2.Full())
            {
                pilha.Push(seed.Next(5*qtd));
                pilha2.Push(seed.Next(5*qtd));
            }

            while (true)
            {
                Console.WriteLine("\n\n--------------------------------------------");
                Console.WriteLine("TORRES DE HANOI");
                    ImprimirPilhas();
                Console.WriteLine("--------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("0 - Encerrar");
                Console.WriteLine("1 - Movimentar pinos");
                Console.WriteLine("");

                Console.Write("Opcao: ");
                int optionInput = Convert.ToInt32(Console.ReadLine());


                switch (optionInput)
                {
                    case 0:
                        {
                            Console.WriteLine("Deseja encerrar? 1-sim 2-nao");
                            int opt = Convert.ToInt32(Console.ReadLine());
                            if (opt == 1)
                            {
                                System.Environment.Exit(0);
                            }
                            else
                            {
                                continue;
                            }
                    }
                        ;
                        break;
                    case 1:
                        {
                            Console.Write("Pop na pilha... ");
                            int pop = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Push na pilha... ");
                            int push = Convert.ToInt32(Console.ReadLine());

                            //==============================================================
                            // Estabelecer ponteiros para as pilhas de pop e de push
                            //
                            PilhaHanoi? pilhaPop = null;
                            PilhaHanoi? pilhaPush = null;

                            switch (pop)
                            {
                                case 1:
                                    pilhaPop = pilha;
                                    break;
                                case 2:
                                    pilhaPop = pilha2;
                                    break;
                                case 3:
                                    pilhaPop = pilha3;
                                    break;
                            }

                            switch (push)
                            {
                                case 1:
                                    pilhaPush = pilha;
                                    break;
                                case 2:
                                    pilhaPush = pilha2;
                                    break;
                                case 3:
                                    pilhaPush = pilha3;
                                    break;
                            }

                            if (pilhaPop == null || pilhaPush == null)
                            {
                                Console.Write("ERRO FATAL! Pelo menos uma das pilhas nao foi inicializada.");
                                break;
                            }
                            //--------------------------------------------------------------

                            //==============================================================
                            // verificacao de pilha vazia para pop e pilha cheia para push
                            //
                            if (pilhaPop.Empty())
                            {
                                Console.Write("ERRO: nao e' possivel fazer o pop na PILHA" + pop + ". Pilha vazia.");
                                continue;
                            }
                            if (pilhaPush.Full())
                            {
                                Console.WriteLine("ERRO: nao e' possivel fazer o push na PILHA" + push + ". Pilha cheia");
                                continue;
                            }
                            //--------------------------------------------------------------

                            // EXECUTAR pop e push
                            pilhaPop.Pop();
                            pilhaPush.Push(pilhaPop.GetRetorno());

                            if (FimDeJogo())
                            {
                                Console.WriteLine("\n\nPARABENS!!! Jogo concluido.\n\n");
                                break;
                            }

                        }
                        break;

                    default:
                        break;
                }

               

            }



        }

        private static string FormataNumero(int numero)
        {
            return numero.ToString().PadLeft(4,' ');
        }

        private static void ImprimirPilhas()
        {

            // imprimir pilha1 =================================================
            Console.Write("\nPILHA 1 - ");
            for (int i = 0; i < pilha?.Qtd(); i++)
            {
                Console.Write(FormataNumero(pilha.Read(i)) + " ");
            }
            Console.Write(" | (" + (tam - pilha?.Qtd()) + " vagas)");
            //------------------------------------------------------------------

            // imprimir pilha2 =================================================
            Console.Write("\n\nPILHA 2 - ");
            for (int i = 0; i < pilha2?.Qtd(); i++)
            {
                Console.Write(FormataNumero(pilha2.Read(i)) + " ");
            }
            Console.Write(" | (" + (tam - pilha2?.Qtd()) + " vagas)");
            //------------------------------------------------------------------

            // imprimir pilha3 =================================================
            Console.Write("\n\nPILHA 3 - ");
            for (int i = 0; i < pilha3?.Qtd(); i++)
            {
                Console.Write(FormataNumero(pilha3.Read(i)) + " ");
            }
            Console.Write(" | (" + (tam - pilha3?.Qtd()) + " vagas)");
            //------------------------------------------------------------------

        }


        private static Boolean FimDeJogo()
        {

            // PILHA1 e PILHA2 tem que ter 'qtd' elementos; PILHA3 tem que estar vazia
            if (pilha?.Qtd() != qtd || pilha2?.Qtd() != qtd || pilha3?.Qtd() > 0)
            {
                return false;
            }

            // verificar se PILHA1 esta' ordenado do fundo para o topo
            for (int i = 0; i < pilha.Qtd() - 1; i++)
            {
                if (pilha.Read(i) > pilha.Read(i + 1))
                {
                    return false;
                }
            }
            // verificar se a PILHA2 esta' ordenada do topo para o fundo
            for (int i = pilha2.Qtd() - 1; i > 0; i--)
            {
                if (pilha2.Read(i) > pilha2.Read(i - 1))
                {
                    return false;
                }
            }

            return true;
        }
    }
    
    
}