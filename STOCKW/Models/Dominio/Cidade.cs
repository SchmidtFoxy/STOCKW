namespace STOCKW.Models.Dominio
{
    public class Cidade
    {
        public int ID_Cidade { get; set; }
        public string Nome { get; set; }
        public string UF { get; set; }

        public ICollection<Pessoa> Pessoas { get; set; }
    }
}
