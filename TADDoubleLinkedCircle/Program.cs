using System;

namespace taddoublelinkedlistcirc
{
    public class Program()
    {
        static ListaLigadaCircular? L2lc;
        public static void Main(string[] args)
        {
            L2lc = new ListaLigadaCircular();

            string msg_or = "OPERACAO REALIZADA COM SUCESSO.";
            string msg_of = "*** OPERACAO FALHOU!!! ***";
            string msg_er = "Elemento removido -> ";

            while (true)
            {
                Console.WriteLine("\n\n======================================================");
                Console.WriteLine("          TAD LISTA DUPLAMENTE LIGADA CIRCULAR");
                Console.WriteLine("             Quantidade de elementos -> " + L2lc.GetQtd());
                Console.WriteLine("======================================================");
                Console.WriteLine(" 0 - encerrar");
                Console.WriteLine(" 1 - inserir um elemento no inicio");
                Console.WriteLine(" 2 - inserir um elemento no final");
                Console.WriteLine(" 3 - inserir um elemento em uma posicao generica no sentido horario");
                Console.WriteLine(" 4 - inserir um elemento em uma posicao generica no sentido anti-horario");
                Console.WriteLine(" 5 - remover um elemento do inicio");
                Console.WriteLine(" 6 - remover um elemento do final");
                Console.WriteLine(" 7 - remover um elemento de uma posicao generica no sentido horario");
                Console.WriteLine(" 8 - remover um elemento de uma posicao generica no sentido anti-horario");
                Console.WriteLine(" 9 - imprimir no sentido horário");
                Console.WriteLine("10 - imprimir no sentido anti-horario");
                Console.WriteLine("99 - imprimir 15 elementos.");
                Console.Write("\nSua opcao -> ");

                try
                {
                    int optionInput = Convert.ToInt32(Console.ReadLine());
                    switch (optionInput)
                    {
                        case 0:
                            System.Environment.Exit(0);
                            break;
                        case 1:
                            {
                                Elemento elementoCriado = CriaElemento();
                                L2lc.InsereInicio(elementoCriado);
                                Console.WriteLine(msg_or);
                            }
                            break;
                        case 2:
                            {
                                Elemento elementoCriado = CriaElemento();
                                L2lc.InsereUltimo(elementoCriado);
                                Console.WriteLine(msg_or);
                            }
                            break;
                        case 3:
                            {
                                int posicaoInserida = Posicao();
                                Elemento? elementoCriado = CriaElemento();
                                Elemento? elementoAtual = L2lc.GetPosHorario(L2lc.GetInicio(), posicaoInserida);
                                if (L2lc.InsereHorario(elementoCriado, elementoAtual))
                                {
                                    Console.WriteLine(msg_or);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }

                            }
                            break;
                        case 4:
                            {
                                int posicaoInserida = Posicao();
                                Elemento? elementoCriado = CriaElemento();
                                Elemento? elementoAtual = L2lc.GetPosAntiHorario(L2lc.GetInicio(), posicaoInserida);
                                if (L2lc.InsereAntiHorario(elementoCriado, elementoAtual))
                                {
                                    Console.WriteLine(msg_or);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }

                            }
                            break;
                        case 5:
                            {
                                Elemento? elementoRemovido = null;
                                elementoRemovido = L2lc.RemoveInicio();
                                if (elementoRemovido != null)
                                {
                                    Console.WriteLine(msg_er);
                                    Console.Write(msg_er);
                                    L2lc.ImprimeElemento(elementoRemovido);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }
                            }
                            break;
                        case 6:
                            {
                                Elemento? elementoRemovido = null;
                                elementoRemovido = L2lc.RemoveFim();
                                if (elementoRemovido != null)
                                {
                                    Console.WriteLine(msg_er);
                                    Console.Write(msg_er);
                                    L2lc.ImprimeElemento(elementoRemovido);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }

                            }
                            break;
                        case 7:
                            {
                                int posicaoInserida = Posicao();
                                Elemento? elementoRemovido = null;
                                elementoRemovido = L2lc.GetPosHorario(L2lc.GetInicio(), posicaoInserida);
                                L2lc.RemoveElemento(elementoRemovido);
                                if (elementoRemovido != null)
                                {
                                    Console.WriteLine(msg_er);
                                    Console.Write(msg_er);
                                    L2lc.ImprimeElemento(elementoRemovido);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }

                            }
                            break;
                        case 8:
                            {
                                int posicaoInserida = Posicao();
                                Elemento? elementoRemovido = null;
                                elementoRemovido = L2lc.GetPosAntiHorario(L2lc.GetInicio(), posicaoInserida);
                                L2lc.RemoveElemento(elementoRemovido);
                                if (elementoRemovido != null)
                                {
                                    Console.WriteLine(msg_er);
                                    Console.Write(msg_er);
                                    L2lc.ImprimeElemento(elementoRemovido);
                                }
                                else
                                {
                                    Console.WriteLine(msg_of);
                                }

                            }
                            break;
                        case 9:
                            {
                                L2lc.ImprimeHorario();
                            }
                            break;
                        case 10:
                            {
                                L2lc.ImprimeAntiHorario();
                            }
                            break;
                        case 99:
                            {
                                Elemento? elementoImpresso = L2lc.GetInicio();
                                for (int i = 1; i <= 15; i++)
                                {
                                    L2lc.ImprimeElemento(elementoImpresso);
                                    elementoImpresso = elementoImpresso.GetSetProximo;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
                catch (System.Exception exception)
                {
                    Console.WriteLine(msg_of + "\n (mensagem do sistema >> " + exception.GetType() + " )");
                    throw;
                }
            }

        }

        private static Elemento CriaElemento()
        {
            Console.WriteLine("Informe o Id do Elemento->  ");
            int inputId = Convert.ToInt32(Console.ReadLine());
            Elemento? elementoCriado = new Elemento();
            elementoCriado.GetSetId = inputId;
            return elementoCriado;
        }

        private static int Posicao()
        {
            Console.WriteLine("AVISO: a posicao nao pode ser maior que a quantidade de elementos.");
            Console.WriteLine("Informe a posição desejada: ");
            int inputPos = Convert.ToInt32(Console.ReadLine());
            return inputPos;
        }
    }
}