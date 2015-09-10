using System;

namespace Faculdade.AFD
{
    class Program
    {
        static void Main(string[] args)
        {
            const string estados = "0a1;1b2;2b0;0c3";
            var automato = new AutomatoGenerico(estados);

            foreach (var estado in estados.ArrayDeEstados())
            {
                var token = automato.ObterToken(estado);
                automato.MudarEstado(token);
            }

            Console.WriteLine("Autômato finalizado com sucesso!");
            Console.ReadKey();
        }
    }
}
