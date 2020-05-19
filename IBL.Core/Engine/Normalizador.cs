using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL.Core.Models;

namespace IBL.Core.Engine
{
    public class Normalizador
    {
        private readonly Dataset _dataset;
        public Normalizador(Dataset dataset)
        {
            _dataset = dataset;
        }

        public ItemNormalizado Normalizar(Item item)
        {
            //para normalizar:
            //(VALOR do Exemplo - Menor valor de exemplo) / (Maior valor de exemplo - Menor valor)
            double valorX = 0, valorY = 0;
            if (item.X.IsNumeric())
                valorX = (item.X.ValorNumerico - _dataset.MenorX) / (_dataset.MaiorX - _dataset.MenorX);
            if (item.Y.IsNumeric())
                valorY = (item.Y.ValorNumerico - _dataset.MenorY) / (_dataset.MaiorY - _dataset.MenorY);

            return new ItemNormalizado
            {
                ItemOriginal = item,
                ValorX = valorX,
                ValorY = valorY
            };
        }
    }
}
