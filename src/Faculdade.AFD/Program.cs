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

            foreach (var estado in estados.ArrayDeEstados())
            {
                var token = automato.ObterToken(estado);
                Thread.Sleep(TimeSpan.FromSeconds(1));
                automato.MudarEstado(token);
            }

            Console.WriteLine("Autômato finalizado com sucesso!");
            Console.ReadKey();
        }
    }
}
