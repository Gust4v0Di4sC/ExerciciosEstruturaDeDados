namespace TADFila
{
    public class Program()
    {
        public static void Main(string[] args)
        {

            Console.WriteLine("Simulação de fila de processos");

            Console.WriteLine("Informe o tamanho da fila-> : ");
            int tamanho = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o numero de processadores paralelos : ");
            int processadores = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Informe o número máximo de novas requisições por ciclo (0 a N): ");
            int maxNewRequests = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Quantidade de ciclos de simulação ----> ");
            int ciclos = Convert.ToInt32(Console.ReadLine());


            if (tamanho <= 0)
            {
                Console.WriteLine($"Tamanho invalido: {tamanho}");
                return;
            }



            // 2. Instâncias e contadores
            Fila fila = new Fila(tamanho, processadores);


            int vezesExcedeu = 0;
            int countLostRequests = 0;
            int countTotalRequests = 0;

            for (int i = 1; i <= ciclos; i++)
            {
                int requests = GenerateRandom(maxNewRequests);
                countTotalRequests += requests;
                int variation = requests - processadores;

                if (variation > 0)
                {
                    for (int j = 0; j < variation; j++)
                    {
                        if (fila.IsFull())
                        {
                            vezesExcedeu++;
                            countLostRequests += variation - j;
                            break;
                        }
                        fila.Enqueue(GenerateRandom(1000));
                    }
                }

                if (variation < 0)
                {
                    variation *= -1;
                    for (int j = 0; j < variation; j++)
                    {
                        if (fila.IsEmpty())
                        {
                            break;
                        }
                        fila.Dequeue();
                    }
                }

            }



            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Rodou " + ciclos + " ciclos.");
            Console.WriteLine("Requests gerados: " + countTotalRequests);
            Console.WriteLine($"Excedeu {vezesExcedeu} vezes ({100 * vezesExcedeu / ciclos} %) ");
            Console.WriteLine($"Requests perdidos: {countLostRequests} ({100 * countLostRequests / countTotalRequests} %)");

        }

        static int GenerateRandom(int max) {

            Random rand = new Random();

            return rand.Next(max + 1);

        }
        
      
    }
    
}