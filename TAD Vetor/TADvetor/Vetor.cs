namespace TADvetor
{
    public class Vetor
    {
        private int tamanho;
        public int Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }

        private int minimo;
        public int Minimo
        {
            get { return minimo; }
            set { minimo = value; }
        }

        private int maximo;
        public int Maximo
        {
            get { return maximo; }
            set { maximo = value; }
        }

        private int vaga;
        public int Vaga
        {
            get { return vaga; }
            set { vaga = value; }
        }

        private int repete;
        public int Repete
        {
            get { return repete; }
            set { repete = value; }
        }

        private int[] dados;


        public Vetor(int tamanho, int minimo, int maximo, int vaga, int repete)
        {
            Tamanho = tamanho;
            Minimo = minimo;
            Maximo = maximo;
            Vaga = vaga;
            Repete = repete;

            dados = new int[Tamanho];
            if (Vaga != 0)
            {
                for (int i = 0; i < Tamanho; i++)
                {
                    dados[i] = Vaga;
                }
            }

        }

        /// <summary>
        /// ================================================================
        /// ARMAZENA UM NOVO VALOR EM DETERMINADA POSICAO
        /// ================================================================
        /// Retorna os seguintes códigos:
        /// 0 - armazenamento bem-sucedido
        /// 1 - valor fora da faixa válida
        /// 2 - posição não existente no vetor
        /// 3 - posição ocupada (para armazenar é necessário estar vaga)
        /// 4 - caso não permita repetição e já existe o valor
        /// </summary>
        /// <param name="valor">Valor a ser armazenado</param>
        /// <param name="posicao">Posição no vetor</param>
        /// <returns>Código de status da operação</returns>

        public int Armazenar(int valor, int posicao)
        {
            if (!ValorValido(valor))
            {
                return 1;
            }
            else if (!PosicaoValidad(posicao))
            {
                return 2;
            }
            else if (dados[posicao] != Vaga)
            {
                return 3;
            }
            else if (!PodeRepetir())
            {
                int[] existe = Localizar(valor, 0);
                if (existe[0] > 0)
                {
                    return 4;
                }
            }

            dados[posicao] = valor;

            return 0;
            
        }

        public int Alterar(int valor, int posicao)
        {
            if (!ValorValido(valor))
            {
                return 1;
            }
            else if (!PosicaoValidad(posicao))
            {
                return 2;
            }
            else if (dados[posicao] == Vaga)
            {
                return 3;
            }
            else if (!PodeRepetir())
            {
                int[] existe = Localizar(valor, 0);
                if (existe[0] > 0)
                {
                    return 4;
                }
            }

            dados[posicao] = valor;

            return 0;
        }


        public int Excluir(int posicao)
        {
            if (!PosicaoValidad(posicao))
            {
                return 1;
            }

            if (dados[posicao] == Vaga)
            {
                return 3;
            }

            dados[posicao] = Vaga;
            
            return 0;
        }

        public int Ler(int posicao)
        {
            if (!PosicaoValidad(posicao))
            {
                return 2;
            }

            return dados[posicao];
        }

        public int Armazenar1Vaga(int valor)
        {
            if (!ValorValido(valor))
            {
                return 1;
            }

            for (int i = 0; i < Tamanho; i++)
            {
                if (dados[i] == Vaga)
                {
                    int res = Armazenar(valor, i);
                    return res;
                }
            }

            return -1;
        }

        public int RemoverUltima()
        {
            for (int i = Tamanho - 1; i >= 0; i--)
            {
                if (dados[i] != Vaga)
                {
                    return Excluir(i);
                }
            }

            return -1;
        }


        

        public int[] Localizar(int valor, int nPrimeiros)
        {
            int[] res = new int[Tamanho];

            if (!ValorValido(valor))
            {
                return res;
            }

            if (Repete == 0)
            {
                nPrimeiros = 1;
            }

            for (int i = 0; i < Tamanho; i++)
            {
                if (dados[i] == valor)
                {
                    res[0]++;
                    res[res[0]] = i;
                    if (res[0] == nPrimeiros)
                    {
                        break;
                    }
                }
            }

            return res;
        }


        private bool ValorValido(int valor)
        {
            return valor >= Minimo && valor <= Maximo;
        }

        private bool PosicaoValidad(int posicao)
        {
            return posicao >= 0 && posicao < Tamanho;
        }

        private bool PodeRepetir()
        {
            return Repete == 1;
        }

        public void LimparVetor()
        {
            for (int i = 0; i < Tamanho; i++)
            {
                dados[i] = Vaga;
            }
        }
    }
}