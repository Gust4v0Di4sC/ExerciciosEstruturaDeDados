namespace TADLinkedList
{

    public class Program()
    {
        public static void Main(string[] args)
        {
            ListaLigada linkList = new ListaLigada();

            while (true)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("     LISTA LIGADA TIPO I");
                Console.WriteLine("================================================");
                Console.WriteLine("0 - encerrar");
                Console.WriteLine("1 - inserir elemento");
                Console.WriteLine("2 - extrair elemento");
                Console.WriteLine("3 - listar elementos");
                Console.WriteLine("");
                Console.Write("Opcao -> ");
                int inputOption = Convert.ToInt32(Console.ReadLine());

                switch (inputOption)
                {
                    case 0:
                        {
                            System.Environment.Exit(0);
                            Console.WriteLine("Saindo....");
                        }
                        break;
                    case 1:
                        {
                            Console.WriteLine("Insira um elemento: ");
                            Console.Write("Digite o nome: ");
                            string? nome = Console.ReadLine();
                            Console.Write("Digite um numero: ");
                            int numero = Convert.ToInt32(Console.ReadLine());

                            Elemento elementInput = new Elemento(nome, numero);

                            if (linkList.Push(elementInput))
                            {
                                Console.WriteLine("Elemento inserido com sucesso!!");
                            }
                            else
                            {
                                Console.WriteLine("*** Falha na insercao do elemento!! ***");
                            }
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Removendo elemento");
                            Elemento? elementoOut = linkList.Pop();
                            if (elementoOut == null)
                            {
                                Console.WriteLine("A lista está vazia");
                            }
                            else
                            {
                                Console.WriteLine("O elemento foi removido com sucesso.");
                               Console.Write("\nNome ---> " + elementoOut.Nome);
                               Console.WriteLine("\nNumero -> " + elementoOut.Numero);
                            }
                        }
                        break;

                    case 3:
                        {
                            Console.WriteLine("Listando Elementos");
                            if (linkList.IsEmpty())
                            {
                                Console.WriteLine("A Lista está vazia");
                            }
                            else
                            {
                                Elemento? e = linkList.GetInicio();
                                while (e != null)
                                {
                                    Console.WriteLine($"\n Nome: {e.Nome} | Numero: {e.Numero}");
                                    e = e.Proximo;
                                }
                            }
                            
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
    
}