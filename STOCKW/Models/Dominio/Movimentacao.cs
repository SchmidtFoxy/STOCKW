using STOCKW.Models.Identidade;
using STOCKW.Models.Dominio;

namespace STOCKW.Models.Dominio
{
    public class Movimentacao
    {
        public int ID_Movimentacao { get; set; }
        public int ID_Item { get; set; }
        public Item? Item { get; set; }

        public int ID_Pessoa { get; set; }
        public Pessoa? Pessoa { get; set; }

        public int ID_TipoMovimentacao { get; set; }
        public TipoMovimentacao? TipoMovimentacao { get; set; }

        public int ID_Usuario { get; set; }
        public Usuario? Usuario { get; set; }

        public DateTime Data { get; set; }
        public int QuantidadeMovimentada { get; set; }
    }

}
