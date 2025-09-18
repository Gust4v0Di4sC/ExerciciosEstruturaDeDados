namespace taddoublelinkedlistcirc
{
    public class Elemento
    {
        public Elemento()
        {
            GetSetId = 0;
            GetSetPosicao = -1;
            GetSetStatus = -1;
            GetSetProximo = Proximo;
            GetSetAnterior = Anterior;
        }

        private int Id { get; set; }
        private int Posicao { get; set; }
        private int Status { get; set; }

        private Elemento? Proximo { get; set; }
        private Elemento? Anterior { get; set; }

        public int GetSetId
        {
            get { return Id; }
            set { Id = value; }
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