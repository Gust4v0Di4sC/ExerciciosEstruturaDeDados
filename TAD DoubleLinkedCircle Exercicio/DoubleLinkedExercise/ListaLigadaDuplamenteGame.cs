namespace doublelinkedcircleexercise
{
    public class ListaDoubleLinkGame
    {
        static int QtdCasas = 10;
        static int QtdJogadores = 2;

        static Jogador? Jogador1 = null;
        static Jogador? Jogador2 = null;
        static Jogador? Jogador3 = null;
        static Jogador? Jogador4 = null;


        static int JogadorDaVez = 0;
        static int Jogada = 0;
        static bool encerrar = false;

        static ListaDoubleLinkCircGame? game;

        public static void Main(String[] args)
        {
            if (QtdCasas < 10 || QtdCasas > 99)
            {
                Console.WriteLine($"Erro quantidade de casas do tabuleiro invalida ({QtdCasas})");
                return;
            }

            if (QtdJogadores > 4 || QtdJogadores < 2)
            {
                Console.WriteLine($"Erro quantidade de jogadores invalida ({QtdJogadores})");
                return;
            }

            game = new ListaDoubleLinkCircGame();

            for (int i = QtdCasas; i >= 1; i--)
            {
                Elemento elementoTabuleiro = new Elemento();
                elementoTabuleiro.GetSetPosicao = i;
                game.InsereInicio(elementoTabuleiro);
            }

            for (int i = 1; i <= QtdJogadores; i++)
            {
                Console.WriteLine("Nome do jogador " + i + " -> ");
                string? nome = Console.ReadLine();
                Jogador jogadorNovo = new Jogador(i, nome);
                switch (i)
                {
                    case 1:
                        Jogador1 = jogadorNovo;
                        break;
                    case 2:
                        Jogador2 = jogadorNovo;
                        break;
                    case 3:
                        Jogador3 = jogadorNovo;
                        break;
                    case 4:
                        Jogador4 = jogadorNovo;
                        break;
                    default:
                        break;
                }
            }

            while (true)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("     JOGO DE TABULEIRO COM " + QtdCasas + " CASAS INICIAIS");
                Console.WriteLine("            CASAS ATUAIS = " + game.GetQtd());
                Console.WriteLine("================================================");


                for (int i = 0; i < QtdJogadores; i++)
                {
                    Console.Write($"Jogador {i} ->");
                    Jogador numeroJogador = NumeroJogador();
                    Console.WriteLine(numeroJogador.GetSetNome);
                }

                Console.WriteLine("================================================");
                game.ImprimeHorario(Jogador1, Jogador2, Jogador3, Jogador4);
                Jogador proxJogador = ProxAjogar();

                if (proxJogador.GetSetNumero == 1)
                {
                    Jogada++;
                }
                Console.WriteLine($"Jogada -> {Jogada}");

                Console.WriteLine("Proximo a jogar -> " + proxJogador.GetSetNome);
                Console.WriteLine("================================================");

                Console.WriteLine("OPCOES DO JOGO:");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - jogar");

                while (true)
                {
                    Console.Write("Opcao -> ");
                    int optionInput = Convert.ToInt32(Console.ReadLine());
                    if (optionInput < 0 || optionInput > 1)
                    {
                        Console.WriteLine("ERRO: opcao Invalida.");
                        continue;
                    }


                    switch (optionInput)
                    {
                        case 0:
                            {
                                Console.Write("Encerrar o jogo?? (1 = NAO / 0 = SIM)");
                                int optionEnd = Convert.ToInt32(Console.ReadLine());
                                if (optionEnd == 0)
                                {
                                    encerrar = true;
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                        case 1:
                            {
                                if (proxJogador.GetSetPerdeAvez > 0)
                                {
                                    Console.WriteLine("Você perde esta vez");
                                    proxJogador.GetSetPerdeAvez = proxJogador.GetSetPerdeAvez - 1;
                                    // continue Loop1
                                }

                                int dado = Dado();
                                Console.WriteLine($"Saiu numero -> {dado}");
                                while (true)
                                {
                                    Console.Write("Escolha a direcao (horario=1; antihorario=2) -> ");
                                    int direcao = Convert.ToInt32(Console.ReadLine());
                                    if (direcao < 1 || direcao > 2)
                                    {
                                        
                                    }
                                }
                            }
                        default:
                            break;
                    }
                    
                    
                }
            }
        }
    }
}