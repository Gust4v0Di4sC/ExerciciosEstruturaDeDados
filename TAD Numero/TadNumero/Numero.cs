public class Numero
{
    private float valor { get; set; }
    public float Valor {
        get { return valor; }
        set { valor = value; }
    }

    public Numero()
    {
        Valor = 0;
    }


    public float getValor()
    {
        return Valor;
    }

    public void setValor(float valor)
    {
        if (valor < 0)
            {
                valor = 0;
                msg("valor menor que zero -> corrigido para zero");
                
            }
            else if (valor > 40 && valor < 60)
            {
                if (valor < 50)
                {
                    valor = 40;
                    msg("valor no intervalo não suportado -> corrigido para 40");
                    
                }
                else
                {
                    valor = 60;
                    msg("valor no intervalo não suportado -> corrigido para 60");
                    
                }
            }
            else if (valor > 100)
            {
                valor = 100;
                msg("valor maior que 100 -> corrigido para 100");
                
            }

            Valor = valor;
            Console.WriteLine("Novo valor atribuído");
            
            
    }


    private void msg(string texto)
    {
        Console.WriteLine("\n\n!!! ATENÇÃO: " + texto + " !!!\n\n");
    }
}