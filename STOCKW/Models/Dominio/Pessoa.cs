namespace STOCKW.Models.Dominio
{
    public class Pessoa
    {
        public int ID_Pessoa { get; set; }
        public string? Nome { get; set; }
        public string? Numero { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }

        public int ID_Cidade { get; set; }
        public Cidade? Cidade { get; set; }

        public string? Tipo { get; set; } // Indica se é física ou jurídica

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
    }
}
