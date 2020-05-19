namespace IBL.Core.Models
{
    public class ItemNormalizado
    {
        //ItemOriginal - Item que foi importado do dataset, com valores originais
        public Item ItemOriginal { get; set; }
        //ValorX - valor do atributo 1 normalizado
        public double ValorX { get; set; }
        //ValorY - valor do atributo 2 normalizado
        public double ValorY { get; set; }
    }
}
