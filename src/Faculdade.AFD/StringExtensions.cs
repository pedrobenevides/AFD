using System.Collections.Generic;

namespace Faculdade.AFD
{
    public static class StringExtensions
    {
        public static IList<string> ArrayDeEstados(this string estados)
        {
            return estados.Split(';');
        }
    }
}
