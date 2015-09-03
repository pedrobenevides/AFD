using System;
using System.Linq;

namespace Faculdade.AFD
{
    public class Automato
    {
        private int count;
        public char[] Palavra { get; set; }

        public void Iniciar()
        {
            count = 0;
            Q0();
        }

        public void Q0()
        {
            if (count >= Palavra.Length)
            {
                Err();
                return;
            }

            switch (Palavra[count])
            {
                case 'a':
                    count++;
                    Q1();
                    return;
                case 'c':
                    QFinal();
                    return;
                default:
                    Err();
                    return;
            }
        }

        public void Q1()
        {
            if (count >= Palavra.Length)
            {
                Err();
                return;
            }

            switch (Palavra[count])
            {
                case 'b':
                    count++;
                    Q2();
                    return;
                default:
                    Err();
                    return;
            }

        }

        public void Q2()
        {
            if (count >= Palavra.Length)
                return;

            switch (Palavra[count])
            {
                case 'b':
                    count++;
                    Q0();
                    return;
                default:
                    Err();
                    return;
            }
        }

        public void QFinal()
        {
            Console.WriteLine("Autômato finalizado com sucesso.");
        }

        public void Err()
        {
            Console.WriteLine("Palavra rejeitada.");
            
        }

        
    }
}