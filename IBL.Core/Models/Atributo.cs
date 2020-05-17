using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBL.Core.Models
{
    public class Atributo
    {
        public object Valor { get; set; }

        public double ValorNumerico { get; set; }

        public bool IsNumeric()
        {
            var isNumeric = double.TryParse(Valor.ToString(), out double numeroSaida);
            ValorNumerico = numeroSaida;

            return isNumeric;
        }
    }
}
