namespace STOCKW.Models.Dominio
{
    public class Juridica : Pessoa
    {
        public string? CNPJ { get; set; }
        public string? InscricaoEstadual { get; set; }
        public string? InscricaoMunicipal { get; set; }
    }

}
