namespace TADFila
{
    public class Program()
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Informe o tamanho da fila-> : ");
            int tamanho = Convert.ToInt32(Console.ReadLine());

            if (tamanho <= 0)
            {
                Console.WriteLine($"Tamanho invalido: {tamanho}");
                return;
            }

            TadFilaEx1 fila = new TadFilaEx1(tamanho);

            while (true)
            {
                Console.WriteLine("\n\n===========================================================");
                Console.WriteLine("                  EXERCICIO DE TAD FILA");
                Console.WriteLine("                   prof. Marcio Feitosa");
                Console.WriteLine("===========================================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - inserir um elemento na fila");
                Console.WriteLine("2 - remover um elemento da fila");
                Console.WriteLine("3 - imprimir a fila");
                Console.WriteLine("4 - informacoes gerais sobre a fila");
                Console.WriteLine("5 - buscar um elemento");

                Console.WriteLine("-----------------------------------------------------------");
                Console.Write("Opcao -> ");
                int optionInput = Convert.ToInt32(Console.ReadLine());

                switch (optionInput)
                {
                    case 0:
                        System.Environment.Exit(0);
                        break;
                    case 1:
                        {
                            Console.WriteLine("Digite um elemento a ser inserido na fila: ");
                            int inputFila = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(fila.Enqueue(inputFila));
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Removendo o ultimo elemnto da fila");

                            if (fila.IsEmpty())
                            {
                                Console.WriteLine("A fila está vazia ");
                            }
                            else
                            {
                                int elem = fila.Dequeue();
                                Console.WriteLine($"Retornando elemento -> {elem}");
                            }
                        }
                        break;
                    case 3:
                        {
                            Console.Write("Imprimindo a fila ");
                            Console.WriteLine(fila.Print());
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("       informacoes gerais sobre a fila");
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("Capacidade maxima -> " + fila.capacity);
                            Console.WriteLine("Tamanho (size) ----> " + fila.Size());
                            Console.WriteLine("Primeiro elemento -> " + fila.Peek());
                            Console.WriteLine("Ponteiro INI ------> " + fila.initial);
                            Console.WriteLine("Ponteiro FIM ------> " + fila.final);
                            Console.WriteLine("Ultima operacao ---> " + fila.ope);
                        }
                        break;

                    case 5:
                        {
                            Console.WriteLine("Digite um elemento para ser localizado na fila");
                            int inputElem = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine(fila.Search(inputElem));
                        }
                        break;
                    default:
                        Console.WriteLine("opção invalida");
                        break;
                }
            }
        }
    }
    
}