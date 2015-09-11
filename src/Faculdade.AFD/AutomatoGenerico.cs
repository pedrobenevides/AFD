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
            var numeroDoEstadoAtual = arrayEstados.IndexOf(EstadoAtual);
            
            var proximoEstado = arrayEstados[++numeroDoEstadoAtual];

            if (token == proximoEstado.ElementAt(1))
            {
                Console.WriteLine("Passou do estado: {0} Para o estado: -> {1}", EstadoAtual, proximoEstado);
                EstadoAtual = proximoEstado;

                return;
            }

            throw new Exception("Token inválido.");
        }
        
        public bool MudarEstado2(char token)
        {
            if (EhEstadoInicial)
            {
                var q0 = ObterQ0();

                if (ObterToken(q0) != token)
                    throw new Exception("Token inválido para o estado inicial.");
                    
                EstadoAtual = q0;
                Console.WriteLine("Estado Inicial -> {0}", EstadoAtual);
                return false;
            }

            var arrayEstados = Estados.ArrayDeEstados();

            var estado = EstadoAtual.ToCharArray().Last();
            var proximoEstado = arrayEstados.Where(s => s[0] == estado).Select(x => x[1]);
            
            if (proximoEstado.Contains(token))
            {
                Console.WriteLine("Passou do estado: {0} Para o estado: -> {1}", EstadoAtual, arrayEstados.FirstOrDefault(x => x[0] == estado && x[1] == token));
                EstadoAtual = arrayEstados.FirstOrDefault(x => x[0] == estado && x[1] == token);

                if (EstadoAtual.ToCharArray().Last() == '4')
                {
                    Console.WriteLine("Automato finalizado com sucesso, palavra aceita!!!!!!");
                    return true;
                }

                return false;
            }

            Console.WriteLine("Token Invalido");
            return true;
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