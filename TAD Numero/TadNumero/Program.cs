using System;

namespace TadNumero
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Numero numero = new Numero();

            while (true)
            {
                Console.WriteLine("==========================================");
                Console.WriteLine("Estudo do TAD Numero");
                Console.WriteLine("==========================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - ler valor");
                Console.WriteLine("2 - atribuir valor");

                Console.WriteLine("Qual sua opção? ");

                int option = Convert.ToInt32(Console.ReadLine());

                Console.Clear();

                switch (option)
                {
                    case 0: Environment.Exit(0); break;
                    case 1: Console.WriteLine($"Valor: {numero.getValor()}"); break;
                    case 2: InserirValor(numero); break;
                    default: Menu(); break;
                }
            }
        }

        static void InserirValor(Numero num)
        {
    
            Console.WriteLine("Insira o novo valor: ");
            float valorInput = Convert .ToSingle(Console.ReadLine());

            num.setValor(valorInput);
            
        }
    }
}

