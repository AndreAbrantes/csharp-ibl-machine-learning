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
            //verifica se os atributos do dataset são numéricos
            var xNumeric = itensTreinamento.All(x => x.X.IsNumeric());
            var yNumeric = itensTreinamento.All(x => x.Y.IsNumeric());
            double maiorItemX = 0;
            double menorItemX = 0;
            double maiorItemY = 0;
            double menorItemY = 0;

            //caso sejam, é setado o maior e o menor valor dos itens
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

            //os itens que vieram do dataset são normalizados
            dataset.AdicionarItensENormalizar(itensTreinamento);

            return dataset;
        }

        public ItemNormalizado Classificar(Item novoItem)
        {
            var calculadoraDistancia = new DistanciaEuclidiana();
            //Item a ser classificado é normalizado
            var itemNormalizado = Normalizar(novoItem);
            double? menorDistancia = null;
            ItemNormalizado itemMenorDistancia = null;

            //os itens do dataset são percorridos para acharmos o item que possui a menor distância
            //em relação ao item a ser classificado
            foreach (var item in _dataset.Itens)
            {
                //Calcula a distância euclidiana dos itens
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

            //retorna o item do dataset que possui a menor distância
            return itemMenorDistancia;
        }

        private ItemNormalizado Normalizar(Item item)
        {
            var normalizador = new Normalizador(_dataset);
            return normalizador.Normalizar(item);
        }

        public string[] Classes()
        {
            return _dataset.Itens.GroupBy(x => x.ItemOriginal.Classe).Select(x => x.Key).ToArray();
        }
    }
}
