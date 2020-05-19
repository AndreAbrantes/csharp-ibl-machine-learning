using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBL.Core.Models;

namespace IBL.Core.Engine
{
    public class LeaveOneOut
    {
        public (int acertos, int erros, decimal total) Fazer(IList<ItemNormalizado> itens)
        {
            var acertos = 0;
            var erros = 0;
            foreach (var oneOut in itens)
            {
                var newDataset = new ClassificadorIbl();
                var @out = oneOut;
                newDataset.CarregarDados(itens.Where(x => x != @out).Select(x => x.ItemOriginal));

                var classificacao = newDataset.Classificar(oneOut.ItemOriginal);

                if (classificacao.ItemOriginal.Classe == oneOut.ItemOriginal.Classe)
                    acertos++;
                else
                    erros++;
            }

            decimal total = acertos + erros;

            return (acertos, erros, total);
        }
    }
}
