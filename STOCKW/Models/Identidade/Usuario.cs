using STOCKW.Models.Dominio;

namespace STOCKW.Models.Identidade
{
    public class Usuario
    {
        public int ID_Usuario { get; set; }
        public string? Nome { get; set; }
        public string? Senha { get; set; }
        public string? Contato { get; set; }

        public int ID_Permissao { get; set; }
        public Permissao? Permissao { get; set; }

        public ICollection<Movimentacao>? Movimentacoes { get; set; }
    }   
}
