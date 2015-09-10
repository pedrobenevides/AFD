using System;
using System.IO;
using Faculdade.AFD.Interfaces;

namespace Faculdade.AFD.Leitores
{
    public class LeitorTxt : ILeitor
    {
        public string Ler(string caminhoArquivo)
        {
            try
            {
                using (var streamReader = new StreamReader(caminhoArquivo))
                    return streamReader.ReadToEnd();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Ocorreu um erro na leitura do arquivo");
                Console.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
