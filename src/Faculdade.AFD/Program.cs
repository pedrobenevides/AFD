using System;
using System.Threading;
using Faculdade.AFD.Interfaces;
using Faculdade.AFD.Leitores;

namespace Faculdade.AFD
{
    class Program
    {
        static void Main(string[] args)
        {
            ILeitor leitorDeArquivo = new LeitorTxt();
            var estados = leitorDeArquivo.Ler("teste.txt"); //"0a1;1b2;2b0;0c3";

            if (string.IsNullOrEmpty(estados))
            {
                Console.ReadKey();
                return;
            }

            var automato = new AutomatoGenerico(estados);
            var count = 0;
            bool naoDeuCerto = false;

            for (int i = 0; i < 5; i++)
            {
                naoDeuCerto = automato.MudarEstado2(LerToken());
            }

            if(!naoDeuCerto)
                Console.WriteLine("Palavra rejeitada!");

            Console.ReadKey();
        }

        private static char LerToken()
        {
            Console.WriteLine("Informe o token");
            var result = Console.ReadLine();

            if(string.IsNullOrEmpty(result))
                throw new Exception("Não foi informado um token válido.");

            return result[0];
        }
    }
}
