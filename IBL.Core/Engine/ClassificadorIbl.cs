using IBL.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.Core.Engine
{
    public class ClassificadorIbl
    {
        public Dataset _dataset;

        public void CarregarDados(IEnumerable<Item> itensTreinamento)
        {
            _dataset = NormalizarDataset(itensTreinamento);
        }

        public Dataset NormalizarDataset(IEnumerable<Item> itensTreinamento)
        {
            var xNumeric = itensTreinamento.All(x => x.X.IsNumeric());
            var yNumeric = itensTreinamento.All(x => x.Y.IsNumeric());
            double maiorItemX = 0;
            double menorItemX = 0;
            double maiorItemY = 0;
            double menorItemY = 0;

            if (xNumeric)
            {
                maiorItemX = itensTreinamento.Max(x => x.X.ValorNumerico);
                menorItemX = itensTreinamento.Min(x => x.X.ValorNumerico);
            }

            if (yNumeric)
            {
                maiorItemY = itensTreinamento.Max(x => x.Y.ValorNumerico);
                menorItemY = itensTreinamento.Min(x => x.Y.ValorNumerico);
            }

            var dataset = new Dataset
            {
                XNumeric = xNumeric,
                YNumeric = yNumeric,
                MaiorX = maiorItemX,
                MenorX = menorItemX,
                MaiorY = maiorItemY,
                MenorY = menorItemY
            };

            dataset.AdicionarItensENormalizar(itensTreinamento);

            return dataset;
        }

        public ItemNormalizado Classificar(Item novoItem)
        {
            var calculadoraDistancia = new DistanciaEuclidiana();
            var itemNormalizado = Normalizar(novoItem);
            double? menorDistancia = null;
            ItemNormalizado itemMenorDistancia = null;

            foreach (var item in _dataset.Itens)
            {
                var distancia = calculadoraDistancia.CalcularDistanciaEuclidiana(
                    item, itemNormalizado, _dataset.XNumeric, _dataset.YNumeric
                );

                if (menorDistancia == null)
                {
                    menorDistancia = distancia;
                    itemMenorDistancia = item;
                    continue;
                }

                if (distancia < menorDistancia)
                {
                    menorDistancia = distancia;
                    itemMenorDistancia = item;
                }
            }

            return itemMenorDistancia;
        }

        private ItemNormalizado Normalizar(Item item)
        {

            double valorX = 0, valorY = 0;
            if (item.X.IsNumeric())
                valorX = (item.X.ValorNumerico - _dataset.MenorX) / (_dataset.MaiorX - _dataset.MenorX);
            if (item.Y.IsNumeric())
                valorY = (item.Y.ValorNumerico - _dataset.MenorY)  / (_dataset.MaiorY - _dataset.MenorY);

            return new ItemNormalizado
            {
                ItemOriginal = item,
                ValorX = valorX,
                ValorY = valorY
            };
        }

        public string[] Classes()
        {
            return _dataset.Itens.GroupBy(x => x.ItemOriginal.Classe).Select(x => x.Key).ToArray();
        }

        public void TreinoLeaveOneOut()
        {
            //COLOCAR TREINO AQUI
        }
    }
}
