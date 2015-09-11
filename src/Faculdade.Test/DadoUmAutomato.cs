 using System;
 using Faculdade.AFD;
 using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Faculdade.Test
{
     [TestClass]
    public class DadoUmAutomato
     {
         private string estados;
         private AutomatoGenerico automato;

         [TestInitialize]
         public void Cenario()
         {
             automato = new AutomatoGenerico("0a1;1b2;2b0;0c3");
         }

         [TestMethod]
         public void PossoObterOPrimeiroEstado()
         {
             var Q0 = automato.ObterQ0();
             Assert.AreEqual("0a1", Q0);
         }

         [TestMethod]
         public void AoMudarDeEstadoSeEstadoAtualForNuloEoTokenForIgualDoTokenDoQ0SetaOEstadoInicial()
         {
             automato.MudarEstado('a');
             Assert.AreNotEqual(null, automato.EstadoAtual);
         }

         [TestMethod, ExpectedException(typeof(Exception))]
         public void AoMudarDeEstadoSeEstadoAtualForNuloEoTokenForDiferenteDoTokenDoQ0LancaException()
         {
             automato.MudarEstado('b');
         }

         [TestMethod]
         public void PossoAvancarEstadoAposOInicialSeHouverEstadoAtual()
         {
             var estadoAtual = "0a1";
             automato.EstadoAtual = estadoAtual;
             automato.MudarEstado('b');
             Assert.AreNotEqual(estadoAtual, automato.EstadoAtual);
         }
    }
}
