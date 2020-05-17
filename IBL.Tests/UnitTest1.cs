using System;
using System.Collections.Generic;
using IBL.Core.Engine;
using IBL.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IBL.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var lstItens = new List<Item>();
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 35 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 45 },
                Y = new Atributo { Valor = 10 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 44 },
                Y = new Atributo { Valor = 11 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 40 },
                Y = new Atributo { Valor = 11 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 35 },
                Y = new Atributo { Valor = 20 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 36 },
                Y = new Atributo { Valor = 18 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 37 },
                Y = new Atributo { Valor = 17 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 39 },
                Y = new Atributo { Valor = 20 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 41 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 41 },
                Y = new Atributo { Valor = 14 },
                Classe = "SIM"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 38 },
                Y = new Atributo { Valor = 12 },
                Classe = "SIM"
            });

            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 36 },
                Y = new Atributo { Valor = 9 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 47 },
                Y = new Atributo { Valor = 6 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 46 },
                Y = new Atributo { Valor = 8 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 70 },
                Y = new Atributo { Valor = 21 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 47 },
                Y = new Atributo { Valor = 22 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 50 },
                Y = new Atributo { Valor = 25 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 55 },
                Y = new Atributo { Valor = 27 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 46 },
                Y = new Atributo { Valor = 55 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 20 },
                Y = new Atributo { Valor = 1 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 34 },
                Y = new Atributo { Valor = 5 },
                Classe = "NAO"
            });
            lstItens.Add(new Item
            {
                X = new Atributo { Valor = 33 },
                Y = new Atributo { Valor = 57 },
                Classe = "NAO"
            });

            var ibl = new ClassificadorIbl();
            ibl.CarregarDados(lstItens);

            var x = ibl.VerDataset();

            var a = x;

            Assert.AreEqual(a.Itens.Count, x.Itens.Count);

        }
    }
}
