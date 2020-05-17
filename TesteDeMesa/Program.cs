using IBL.Core.Engine;
using IBL.Core.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TesteDeMesa
{
    class Program
    {
        static void Main(string[] args)
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

            //var jsonString = JsonConvert.SerializeObject(lstItens.Select(a => new { 
            //    x = a.X.Valor,
            //    y = a.Y.Valor,
            //    title = a.Classe
            //}));

            //File.WriteAllText("sim.json", jsonString);

            // The MeshGrid method generates two matrices that can be 
            // used to generate all possible (x,y) pairs between two 
            // vector of points. For example, let's suppose we have 
            // the values: 
            // double[] a = { 1, 2, 3 }; double[] b = { 4, 5, 6 }; 
            // We can create a grid var grid = a.MeshGrid(b); 
            // get the x-axis values 
            // | 1 1 1 | double[,] x = grid.Item1; 
            // x = | 2 2 2 | 
            // | 3 3 3 | 
            // get the y-axis values 
            // | 4 5 6 | double[,] y = grid.Item2; 
            // y = | 4 5 6 | 
            // | 4 5 6 | 
            // we can either use those matrices separately (such as for plotting 
            // purposes) or we can also generate a grid of all the (x,y) pairs as 
            // double[,][] xy = x.ApplyWithIndex((v, i, j) => new[] { x[i, j], y[i, j] }); 
            // The result will be 
            // 
            // | (1, 4) (1, 5) (1, 6) | 
            // xy = | (2, 4) (2, 5) (2, 6) | 
            // | (3, 4) (3, 5) (3, 6)

            var ibl = new ClassificadorIbl();
            ibl.CarregarDados(lstItens);

            var x = ibl.VerDataset();

            var item = new Item
            {
                X = new Atributo { Valor = 34 },
                Y = new Atributo { Valor = 9 },
            };

            var novo = ibl.Classificar(item);

            var xxxx = novo;
        }
    }
}
