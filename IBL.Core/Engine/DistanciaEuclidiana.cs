using IBL.Core.Models;
using System;

namespace IBL.Core.Engine
{
    public class DistanciaEuclidiana
    {
        public double CalcularDistanciaEuclidiana(ItemNormalizado item1, ItemNormalizado item2, bool xNumeric, bool yNumeric)
        {
            double distanciaX, distanciaY;
            //se os atributos forem numéricos, faz o calculo da distância entre eles
            //se não forem, verifica se são iguais ou diferentes
            if (!xNumeric)
                distanciaX = item1.ItemOriginal.X.Valor.ToString() == item2.ItemOriginal.X.Valor.ToString() ? 0 : 1;
            else
                distanciaX = item1.ValorX - item2.ValorX;

            if (!yNumeric)
                distanciaY = item1.ItemOriginal.Y.Valor.ToString() == item2.ItemOriginal.Y.Valor.ToString() ? 0 : 1;
            else
                distanciaY = item1.ValorY - item2.ValorY;

            //DISTANCIA EUCLIDIANA = RAIZ QUADRADA (SOMA (DISTANCIAS AO QUADRADO))
            return Math.Sqrt(Math.Pow(distanciaX, 2) + Math.Pow(distanciaY, 2));
        }
    }
}
