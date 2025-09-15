namespace TADvetor
{
    public class Utils
    {
        private static string cab = "\n\nOperacao NAO executada.";
        private static string rab = "\n\n";

        public static void PrintRet(int codigo)
        {
             if (codigo == -1) {
            Console.WriteLine(cab + " Elemento inexistente." + rab);
        } else if (codigo == 0) {
            Console.WriteLine("Operacao BEM sucedida" + rab);
        } else if (codigo == 1) {
            Console.WriteLine(cab + " Valor fora da faixa prevista." + rab);
        } else if (codigo == 2) {
            Console.WriteLine(cab + " Posicao fora das fronteiras do vetor." + rab);
        } else if (codigo == 3) {
            Console.WriteLine(cab + " A posicao ja' contem o previsto pela operacao"
                    + "('ocupada' em caso de inclusao ou 'vaga' em caso de remocao)." + rab);
        } else if (codigo == 4) {
            Console.WriteLine(cab + " Valor ja' existente (repeticao nao permitida)." + rab);
        }
        }
    }
}