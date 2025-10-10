namespace doublelinkedcircleexercise
{
    public class Elemento
    {
        public Elemento()
        {
            Id = 0;
            Jogador = 0;
            Posicao = 0;
            Status = 0;
            Penalidade = 0;
            Proximo = this;
            Anterior = this;
        }

        private int Id;
        private int Jogador;  //* marcador ou proprietario da casa
        private int Posicao;  //* posicao que a casa esta' no tabuleiro (sentido horario)
        private int Status;  //* 0=livre, 1=marcada, 2=proprietaria
        private int Penalidade;  //* N = nao joga N vezes (0, 1 ou 2)

        private Elemento? Proximo;
        private Elemento? Anterior;


        public int GetSetId
        {
            get { return Id; }
            set { Id = value; }
        }

        public int GetSetJogador
        {
            get { return Jogador; }
            set { Jogador = value; }
        }

        public int GetSetPosicao
        {
            get { return Posicao; }
            set { Posicao = value; }
        }

        public int GetSetStatus
        {
            get { return Status; }
            set { Status = value; }
        }

        public int GetSetPenalidade
        {
            get { return Penalidade; }
            set { Penalidade = value; }
        }

        public Elemento? GetSetProximo
        {
            get { return Proximo; }
            set { Proximo = value; }
        }
        
        public Elemento? GetSetAnterior
        {
            get { return Anterior; }
            set { Anterior = value; }
        }
    }
}