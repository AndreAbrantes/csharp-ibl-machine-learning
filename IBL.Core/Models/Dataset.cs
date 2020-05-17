using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.Core.Models
{
    public class Dataset
    {
        public bool XNumeric { get; set; }
        public bool YNumeric { get; set; }
        public double MaiorX { get; set; }
        public double MenorX { get; set; }
        public double MaiorY { get; set; }
        public double MenorY { get; set; }

        public IList<ItemNormalizado> Itens { get; set; }

        public void AdicionarItensENormalizar(IEnumerable<Item> itens)
        {
            Itens = new List<ItemNormalizado>();

            foreach (var item in itens)
            {
                double valorX = 0, valorY = 0;
                if(XNumeric)
                    valorX = item.X.ValorNumerico / (MaiorX - MenorX);
                if(YNumeric)
                    valorY = item.Y.ValorNumerico / (MaiorY - MenorY);

                Itens.Add(new ItemNormalizado
                {
                    ItemOriginal = item,
                    ValorX = valorX,
                    ValorY = valorY
                });
            }
        }
    }
}
