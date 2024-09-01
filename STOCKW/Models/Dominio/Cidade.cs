namespace STOCKW.Models.Dominio
{
    public class Cidade
    {
        public int ID_Cidade { get; set; }
        public string? Nome { get; set; } // Propriedade anulável
        public string? UF { get; set; } // Propriedade anulável

        public ICollection<Pessoa>? Pessoas { get; set; } // Coleção anulável
    }
}
