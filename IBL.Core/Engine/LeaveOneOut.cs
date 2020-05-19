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
            //percorre a lista de exemplos
            foreach (var oneOut in itens)
            {
                var newDataset = new ClassificadorIbl();

                //separa um exemplo, e
                //carrega o algoritmo com todos os dados exceto o dado separado
                newDataset.CarregarDados(itens.Where(x => x != oneOut).Select(x => x.ItemOriginal));

                //classifica o item separado
                var classificacao = newDataset.Classificar(oneOut.ItemOriginal);

                //se o item foi classificado corretamente, conta um acerto, caso contrário, um erro
                if (classificacao.ItemOriginal.Classe == oneOut.ItemOriginal.Classe)
                    acertos++;
                else
                    erros++;
            }

            decimal total = acertos + erros;

            //retorna acertos erros e total de exemplos
            return (acertos, erros, total);
        }
    }
}
