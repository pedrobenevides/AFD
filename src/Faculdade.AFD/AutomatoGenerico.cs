using System;
using System.Linq;

namespace Faculdade.AFD
{
    public class AutomatoGenerico
    {
        public AutomatoGenerico(string estados)
        {
            Estados = estados;
        }

        public string Estados { get; private set; }
        public string EstadoAtual { get; set; }

        public string ObterQ0()
        {
            return Estados.Split(';').FirstOrDefault();
        }

        public void MudarEstado(char token)
        {
            if (EhEstadoInicial)
            {
                var q0 = ObterQ0();

                if (ObterToken(q0) != token)
                    throw new Exception("Token inválido para o estado inicial.");
                    
                EstadoAtual = q0;
                Console.WriteLine("Estado Inicial -> {0}", EstadoAtual);
                return;
            }

            var arrayEstados = Estados.ArrayDeEstados();
            var numeroDoEstadoAtual = arrayEstados.IndexOf(EstadoAtual) * -1;
            
            var proximoEstado = arrayEstados[++numeroDoEstadoAtual];

            if (token == proximoEstado.ElementAt(1))
            {
                Console.WriteLine("{0} -> {1}", EstadoAtual, proximoEstado);
                EstadoAtual = proximoEstado;
                return;
            }

            throw new Exception("Token inválido.");
        }

        public bool EhEstadoInicial
        {
            get { return string.IsNullOrEmpty(EstadoAtual); }
        }

        public char ObterToken(string estado)
        {
            var a = estado.ElementAt(1);
            return estado.ElementAt(1);
        }
    }
}