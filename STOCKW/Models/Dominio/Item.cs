namespace STOCKW.Models.Dominio
{
    public class Item
    {
        public int ID_Item { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Material { get; set; }
        public string Dimensao { get; set; }
        public double Preco { get; set; }
        public string Caracteristica { get; set; }

        public ICollection<Movimentacao> Movimentacoes { get; set; }
    }

}
