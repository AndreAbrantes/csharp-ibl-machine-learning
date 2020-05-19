namespace IBL.Core.Models
{
    public class Atributo
    {
        //Valor do atributo
        public object Valor { get; set; }

        //Valor do atributo convertido para tipo numérico
        public double ValorNumerico { get; private set; }

        public bool IsNumeric()
        {
            //Verifica se o valor do atributo é nominal ou numérico
            var isNumeric = double.TryParse(Valor.ToString(), out double numeroSaida);

            //Se for numérico atribui o número para a variável, caso não seja, o valor é 0
            ValorNumerico = numeroSaida;

            return isNumeric;
        }
    }
}
