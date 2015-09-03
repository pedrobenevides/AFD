﻿ using System;
 using System.Security.Policy;
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
         public void AoMudarDeEstadoSeEstadoAtualForNuloEoTokenForDiferenteDoTokenDoQ0()
         {
             automato.MudarEstado('b');
         }

         [TestMethod]
         public void PossoAvancarEstadoAposOInicialSeHouverEstadoAtual()
         {
             automato.EstadoAtual = "1a0";
             automato.MudarEstado('b');
             Assert.AreNotEqual("1a0", automato.EstadoAtual);
         }

         


    }
}