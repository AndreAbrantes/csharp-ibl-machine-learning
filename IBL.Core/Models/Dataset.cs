using System.Collections.Generic;
using IBL.Core.Engine;

namespace IBL.Core.Models
{
    public class Dataset
    {
        private Normalizador _normalizador;
        
        //Se "true", todos os atributos 1 do dataset são numéricos
        public bool XNumeric { get; set; }
        //Se "true", todos os atributos 2 do dataset são numéricos
        public bool YNumeric { get; set; }
        //Maior número de exemplo do atributo 1
        public double MaiorX { get; set; }
        //Menor número de exemplo do atributo 1
        public double MenorX { get; set; }
        //Maior número de exemplo do atributo 2
        public double MaiorY { get; set; }
        //Menor número de exemplo do atributo 2
        public double MenorY { get; set; }

        //Lista dos exemplos do dataset
        public IList<ItemNormalizado> Itens { get; set; }

        public void AdicionarItensENormalizar(IEnumerable<Item> itens)
        {
            _normalizador = new Normalizador(this);
            Itens = new List<ItemNormalizado>();

            //para cada exemplo do dataset faz a normalização
            foreach (var item in itens)
            {
                var itemNormalizado = _normalizador.Normalizar(item);
                Itens.Add(itemNormalizado);
            }
        }
    }
}
